using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace firewood
{
    public partial class exit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = RegularExpressions.MyEncodeInputString(Request["id"].Trim());
            Session.Abandon();
            if (Request.Cookies["UserName"] != null)
            {
                HttpCookie myCookie = new HttpCookie("UserName");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            if (Request.Cookies["UserLog"] != null)
            {
                HttpCookie myCookie = new HttpCookie("UserLog");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }

            if(id.Equals("0"))
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}