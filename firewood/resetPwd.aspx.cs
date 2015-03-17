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
    public partial class resetPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["stuNum"] == null)
            {
                Response.Write("<script>alert('请先验证学号');self.location='checkNum.aspx?id=0'</script>");
            }
        }

        protected void rePwd(object sender, EventArgs e)
        {
            string rePwd = RegularExpressions.MyEncodeInputString(pwd.Value.Trim());
            string rePwd1 = RegularExpressions.MyEncodeInputString(pwd1.Value.Trim());
            if (rePwd.Equals(rePwd1))
            {
                if (BADL_User.ChangePwd(Md5.MD5_encrypt(rePwd), Session["stuNum"].ToString()))
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    Response.Write("<script>alert('更新密码异常');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('密码不一致');</script>");
            }
        }
    }
}