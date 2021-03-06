﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Entity;
using BADL;

namespace firewood.org
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
            if (Session["Org"] == null)
            {
                if (Request.Cookies["OrgLog"] != null)//session过期，查看cookie是否存在
                {
                    string[] message = Request.Cookies["OrgLog"].Value.Split('+');
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
            else//session未过期，直接登录，跳转到社团/组织管理页面
            {
                Response.Redirect("index.aspx");
            }
        }
        protected void Log(object sender, EventArgs e)
        {
            En_User user = BADL_User.Login(RegularExpressions.MyEncodeInputString(uInfo.Value.Trim()), Md5.MD5_encrypt(RegularExpressions.MyEncodeInputString(uPwd.Value.Trim())));
            if (user != null)
            {
                Session["Org"] = user;//写入session

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