using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using prjListView.Models;

namespace prjListView
{
    public partial class mobileProducts : System.Web.UI.Page
    {
        MyDBEntities db = new MyDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["cid"] == null) Response.Redirect("mobileIndex.aspx");
            int cid = int.Parse(Request.QueryString["cid"].ToString());
            
            if (!Page.IsPostBack)
            {
                var products = db.產品資料
                                 .Where(m => m.類別編號 == cid)
                                 .OrderByDescending(m => m.編號)
                                 .ToList();
                ListView1.DataSource = products.ToList();
                ListView1.DataBind();
            }
        }
    }
}