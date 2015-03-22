using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BADL;
using Common;

namespace firewood
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnInit(sender, e);
            }
        }

        protected void OnInit(object sender, EventArgs e)//如果有cookie或session的话，已是登录状态，直接跳转
        {
            if (Session["User"] == null)
            {
                if (Request.Cookies["UserLog"] != null)//session过期，查看cookie是否存在
                {
                    string[] message = Request.Cookies["UserLog"].Value.Split('+');
                    if (message.Length == 2)
                    {
                        string worknum = message[0];
                        string password = message[1];
                        if (BADL_User.CheckCookies(worknum, password))//判断cookie的真实性
                        {
                            Session["User"] = BADL_User.Login(worknum);//写入session
                            Response.Redirect("index.aspx");
                        }
                    }
                }
            }
            else//session未过期，直接登录，跳转到首页
            {
               Response.Redirect("index.aspx");
            }
        }
        protected void Log(object sender, EventArgs e)
        {
            En_User user = BADL_User.Login(RegularExpressions.MyEncodeInputString(uInfo.Value.Trim()), Md5.MD5_encrypt(RegularExpressions.MyEncodeInputString(uPwd.Value.Trim())));
            if (user != null)
            {
                Session["User"] = user;//将user写入session

                if (!BADL_User.ChangeLogInfor(user.UNum, DateTime.Now))//更新登录时间异常
                {
                    Response.Write("<script>alert('更新登录时间异常，登录失败')</script>");
                }
                else
                {
                    HttpCookie cookieUserName = new HttpCookie("UserName");//将用户名写入cookie
                    cookieUserName.Value = user.UName;
                    cookieUserName.Expires = System.DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookieUserName);

                    string userRole = BADL_User.GetUserRole(user.UNum);//得到用户的角色
                    Session["UserRole"] = userRole;//将userRole写入session,一般用户的role为"0"
                    HttpCookie cookieUserRole = new HttpCookie("UserRole");//将userRole写入cookie
                    cookieUserRole.Value = userRole;
                    cookieUserRole.Expires = System.DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookieUserRole);


                    if (savePwd.Checked)//如果用户记住密码，将学号和登录密码写入cookie
                    {
                        HttpCookie cookieUser = new HttpCookie("UserLog");
                        cookieUser.Value = user.UNum + "+" + Md5.MD5_encrypt(uPwd.Value);
                        cookieUser.Expires = System.DateTime.Now.AddDays(1);
                        Response.Cookies.Add(cookieUser);
                    }
                    Response.Redirect("index.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('登录失败，用户名或密码不正确')</script>");
            }
        }
    }
}