using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using prjListView.Models;

namespace prjListView
{
    public partial class mobileIndex : System.Web.UI.Page
    {
        MyDBEntities db = new MyDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                var category = from c in db.產品類別
                               join p in db.產品資料
                               on c.類別編號 equals p.類別編號
                               into t
                               select new
                               {
                                   類別編號 = c.類別編號,
                                   類別名稱 = c.類別名稱,
                                   數量 = t.Count()
                               };
                ListView1.DataSource = category.ToList();
                ListView1.DataBind();
            }
        }
    }
}