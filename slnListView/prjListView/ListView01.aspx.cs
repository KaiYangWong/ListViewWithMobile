using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjListView.Models;

namespace prjListView
{
    public partial class ListView01 : System.Web.UI.Page
    {
        MyDBEntities db = new MyDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //下拉式清單繫結產品類別表
                DropDownList1.DataSource = db.產品類別.ToList();
                DropDownList1.DataValueField = "類別編號";
                DropDownList1.DataTextField = "類別名稱";
                DropDownList1.DataBind();
                ShowData(0);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowData(0);
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "刪除")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                var product = db.產品資料.Where(m => m.編號 == id).FirstOrDefault();
                string imgName = product.圖示;
                db.產品資料.Remove(product);
                db.SaveChanges();
                if (imgName != "q.jpg")
                {
                    System.IO.File.Delete(Server.MapPath("~/images") + "/" + imgName);
                }
                ShowData(0);
            }
        }

        void ShowData(int page)
        {
            //page虛引數代表的是目前在第幾頁, 0表示ListView第1頁, 1表示ListView第2頁

            //取得清單中的類別編號指定給categoryId
            int categoryId = int.Parse(DropDownList1.SelectedValue);
            //依類別編號categoryId取得產品資料，並依編號做遞減排序
            var products = db.產品資料
                .Where(m => m.類別編號 == categoryId)
                .OrderByDescending(m => m.編號).ToList();
            //pageSize一頁筆數, pageTotal全部頁數, recordCount記錄筆數
            int pageSize, pageTotal, recordCount;
            pageSize = 3;
            recordCount = products.Count();
            //記錄筆數 除 一頁筆數 等於 全部頁數
            pageTotal = recordCount / pageSize;
            //判斷記錄總數 % 一頁筆數 若為0 ，則pageTotal減1
            if ((products.Count() % pageSize) == 0)
            {
                pageTotal -= 1;
            }
            //若記錄筆數為0則不顯示資料，並離開方法
            if (recordCount == 0)
            {
                btnPrev.Visible = false;
                btnNext.Visible = false;
                lblPageInfo.Text = "無資料";
                ListView1.DataSource = null;
                ListView1.DataBind();
                return;
            }
            else if (page == 0 && recordCount <= 3) // 判斷page=0且recordCount小於等於3，表示不需上下頁切換
            {
                btnPrev.Visible = false;
                btnNext.Visible = false;
                page = 0;
            }
            else if (page == 0 && recordCount > 3) //判斷page = 0且recordCount大於3，則btnPrev按鈕不顯示，btnNext按鈕顯示
            {
                btnPrev.Visible = false;
                btnNext.Visible = true;
                page = 0;
            }
            else if (page >= pageTotal) //page>=pageTotal，表示在最末頁，則btnPrev按鈕顯示，btnNext按鈕不顯示
            {
                btnPrev.Visible = true;
                btnNext.Visible = false;
                page = pageTotal;
            }
            else  //若不在第1頁或最末頁，btnPrev與btnNext按鈕顯示
            {
                btnPrev.Visible = true;
                btnNext.Visible = true;
            }
            lblPage.Text = page.ToString();  //記錄目前所在頁次
            lblPageInfo.Text = string.Format("第{0}頁/共{1}頁,共{2}筆記錄",
                (page + 1), (pageTotal + 1), recordCount);
            // 指定要呈現資料記錄，Skip可跳到指定的筆數，Take指定要顯示的筆數
            ListView1.DataSource = products.Skip(pageSize * page).Take(pageSize);
            ListView1.DataBind();
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPage.Text) - 1;
            ShowData(page);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            int page = int.Parse(lblPage.Text) + 1;
            ShowData(page);
        }
    }
}