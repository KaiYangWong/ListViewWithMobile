using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjListView.Models;
namespace prjListView
{
    public partial class EditProduct : System.Web.UI.Page
    {
        MyDBEntities db = new MyDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null) Response.Redirect("ListView01.aspx");

            if (!Page.IsPostBack)
            {
                ddlCategory.DataSource = db.產品類別.ToList();
                ddlCategory.DataValueField = "類別編號";
                ddlCategory.DataTextField = "類別名稱";
                ddlCategory.DataBind();

                int id = int.Parse(Request.QueryString["id"].ToString());
                var product = db.產品資料
                    .Where(m => m.編號 == id).FirstOrDefault();

                txtProductId.Text = product.產品編號.ToString();
                txtProductName.Text = product.品名;
                txtPrice.Text = product.單價.ToString();
                txtImg.Text = product.圖示;
                txtImg.Visible = false;

                Image1.ImageUrl = "~/images/" + product.圖示;
                ddlCategory.SelectedValue = product.類別編號.ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                string imgfile = Guid.NewGuid().ToString() + ".jpg";
                var product = db.產品資料.Where(m => m.編號 == id).FirstOrDefault();

                if (FileUpload1.HasFile)
                {
                    FileUpload1.SaveAs(Server.MapPath("images") + "\\" +
                       imgfile);
                }
                else
                {
                    imgfile = txtImg.Text;
                }

                product.類別編號 = int.Parse(ddlCategory.SelectedValue.ToString());
                product.品名 = txtProductName.Text;
                product.單價 = int.Parse(txtPrice.Text);
                product.圖示 = imgfile;
                db.SaveChanges();
                Image1.ImageUrl = "~/images/" + product.圖示;
                Response.Redirect("ListView01.aspx");
            }
            catch (Exception ex)
            {
                Label1.Text = "修改失敗";
            }
        }
    }
}