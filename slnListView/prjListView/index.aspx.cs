using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjListView.Models;
namespace prjListView
{
    public partial class index : System.Web.UI.Page
    {
        MyDBEntities db = new MyDBEntities();

        void ShowData()
        {
            GridView1.DataSource = db.產品類別.OrderByDescending(m => m.類別編號).ToList();
            GridView1.DataBind();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowData();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            產品類別 category = new 產品類別();
            category.類別名稱 = txtCategory.Text;
            db.產品類別.Add(category);
            db.SaveChanges();
            ShowData();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            ShowData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            ShowData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblCategoryId = (Label)GridView1.Rows[e.RowIndex].FindControl("lblCategoryId");
            int categoryId = int.Parse(lblCategoryId.Text);

            var products = db.產品資料.Where(m => m.類別編號 == categoryId).ToList();
            var category = db.產品類別.Where(m => m.類別編號 == categoryId).FirstOrDefault();
            db.產品資料.RemoveRange(products);
            db.產品類別.Remove(category);
            db.SaveChanges();
            ShowData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            Label lblCategoryId = (Label)GridView1.Rows[e.RowIndex].FindControl("lblCategoryId");
            int categoryId = int.Parse(lblCategoryId.Text);
            
            TextBox txtCategoryName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtCategoryName");
            var category = db.產品類別.Where(m => m.類別編號 == categoryId).FirstOrDefault();
            
            category.類別名稱 = txtCategoryName.Text;
            db.SaveChanges();
            GridView1.EditIndex = -1;
            ShowData();

        }
    }
}