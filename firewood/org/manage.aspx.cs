using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using Common;
using System.Web.Services;
using BADL;

namespace firewood.org
{
    public partial class manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userRole = (string)Session["UserRole"];
            if (userRole != "Admin" && userRole != "firewoodAdmin")
            {
                Response.Write("<script>self.location='../index.aspx'</script>");
            }
        }

        protected void orgRegister(object sender, EventArgs e)
        {
            string orgname = RegularExpressions.MyEncodeInputString(orgName.Value.Trim());
            string orgpwd = RegularExpressions.MyEncodeInputString(orgPwd.Value.Trim());
            string orgpwd1 = RegularExpressions.MyEncodeInputString(orgPwd1.Value.Trim());
            string orgprincipal = RegularExpressions.MyEncodeInputString(orgPrincipal.Value.Trim());
            string orgtel = RegularExpressions.MyEncodeInputString(orgTel.Value.Trim());
            string orgdepartment = RegularExpressions.MyEncodeInputString(orgDepartment.Value.Trim());

            if (!orgpwd.Equals(orgpwd1))
            {
                Response.Write("<script>alert('密码不一致')</script>");
            }
            else
            {
                En_Org eu = new En_Org();
                eu.OrgName = orgname;
                eu.OrgPwd = Md5.MD5_encrypt(orgpwd);
                eu.OrgPrincipal = orgprincipal;
                eu.OrgTel = orgtel;
                eu.OrgDepartment = orgdepartment;
                eu.RegisterTime = DateTime.Now;
                eu.LastLogin = DateTime.Now;
                eu.State = 0;

                /*int blank = BADL_Org.IsBlankReg(eu);//判断字段长度
                if (blank != 5)
                {
                    Response.Write("<script>alert('字段长度不符')</script>");
                }
                else if (BADL_User.IsStunumExsit(unum))
                {
                    Response.Write("<script>alert('学号存在')</script>");
                }
                else if (BADL_User.IsNameExsit(uname))
                {
                    Response.Write("<script>alert('昵称存在')</script>");
                }
                else if (BADL_User.InsertUser(eu))
                {
                    Response.Redirect("login.aspx");//注册成功,跳转到登录界面
                }
                else
                {
                    Response.Write("<script>alert('注册异常')</script>");
                }*/
            }
        }

        protected void orgDel(object sender, EventArgs e)
        {

        }
    }
}