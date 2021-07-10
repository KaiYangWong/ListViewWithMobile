using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjListView.Models;
namespace prjListView
{
    public partial class CreateProduct : System.Web.UI.Page
    {
        MyDBEntities db = new MyDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlCategory.DataSource = db.產品類別.ToList();
                ddlCategory.DataValueField = "類別編號";
                ddlCategory.DataTextField = "類別名稱";
                ddlCategory.DataBind();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string imgfile = Guid.NewGuid().ToString() + ".jpg";
                if (FileUpload1.HasFile)
                {
                    FileUpload1.SaveAs(Server.MapPath("images") + "\\" +
                       imgfile);
                }
                else
                {
                    imgfile = "q.jpg";
                }

                產品資料 p = new 產品資料();
                p.產品編號 = txtProductId.Text;
                p.品名 = txtProductName.Text;
                p.單價 = int.Parse(txtPrice.Text);
                p.類別編號 = int.Parse(ddlCategory.SelectedValue.ToString());
                p.圖示 = imgfile;
                db.產品資料.Add(p);
                db.SaveChanges();
                Response.Redirect("ListView01.aspx");
            }
            catch (Exception ex)
            {
                Label1.Text = "產品編號必填且不可重複";
            }
        }
    }
}