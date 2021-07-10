using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjListView.Models;
namespace prjListView
{
    public partial class login : System.Web.UI.Page
    {
        MyDBEntities db = new MyDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string uid, pwd;
            uid = txtUId.Text;
            pwd = txtPwd.Text;
            
            var admin = db.管理者
                          .Where(m => m.帳號 == uid && m.密碼 == pwd)
                          .FirstOrDefault();

            if (admin == null)
            {
                lblShow.Text = "非管理者，無法進入";
                return;
            }

            Session["admin"] = admin;
            Response.Redirect("index.aspx");
        }
    }
}