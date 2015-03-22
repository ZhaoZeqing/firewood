using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Xml;
using System.Text;
using BADL;
using Common;

namespace firewood
{
    public partial class checknum : System.Web.UI.Page
    {
        string id;
        protected void Page_Load(object sender, EventArgs e){}

        protected void check(object sender, EventArgs e)
        {
            string stunumStr = RegularExpressions.MyEncodeInputString(worknum.Value.Trim());
            string pwdStr = RegularExpressions.MyEncodeInputString(pwd.Value.Trim());
            int isStuNumExsit = BADL_User.IsStunumExsit(stunumStr) ? 0 : 1;//0:学号存在，1:学号不存在

            if (CheckNum.CheckUserNum(stunumStr, pwdStr))
            {
                Session["stuNum"] = stunumStr;
                string uname = BADL_User.GetUserName(stunumStr);
                string umail = BADL_User.GetUserMail(stunumStr);
                if (isStuNumExsit == 1)
                {
                    Response.Write("<script>alert('该学号未注册,请注册');self.location='uReg.aspx'</script>");
                }
                else if (isStuNumExsit == 0)
                {
                    HttpCookie cookies = new HttpCookie("getUser");
                    cookies.Value = uname + "+" + umail;
                    cookies.Expires = System.DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookies);
                    Response.Redirect("resetPwd.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('验证失败，学号或上网密码错误')</script>");
            }
        }
        
    }
}