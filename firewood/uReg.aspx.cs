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

namespace firewood
{
    public partial class uReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["stuNum"] == null)
            {
                Response.Write("<script>alert('请先验证学号');self.location='checkNum.aspx?id=0'</script>");
            }
        }

        [WebMethod]
        public static string uNamePost(string uName)
        {
            string UName = RegularExpressions.MyEncodeInputString(uName.Trim());
            if (!BADL_User.IsNameExsit(UName))
            {
                return "0";
            }
            else
                return "1";//昵称存在
        }

        [WebMethod]
        public static string uMailPost(string uMail)
        {
            string UMail = RegularExpressions.MyEncodeInputString(uMail.Trim());
            if (!BADL_User.IsMailExsit(UMail))
            {
                return "2";
            }
            else
                return "3";//邮箱存在
        }

        [WebMethod]
        public static string uCheckPost(string uCheck)
        {
            string ucheck = RegularExpressions.MyEncodeInputString(uCheck.Trim());
            if (HttpContext.Current.Session["check"] != null)
            {
                string check = HttpContext.Current.Session["check"].ToString();
                if (!check.ToUpper().Equals(ucheck.ToUpper()))
                {
                    return "4";//验证码输入错误
                }
                else
                {
                    return "5";//验证码OK
                }
            }
            else return "6";//验证码生成错误
        }

        protected void uRegister(object sender, EventArgs e)
        {
            string uname = RegularExpressions.MyEncodeInputString(uName.Value.Trim());
            string upwd = RegularExpressions.MyEncodeInputString(pwd.Value.Trim());
            string upwd1 = RegularExpressions.MyEncodeInputString(pwd1.Value.Trim());
            string umail = RegularExpressions.MyEncodeInputString(uMail.Value.Trim());
            string ucheck = RegularExpressions.MyEncodeInputString(uCheck.Value.Trim());

            if (!upwd.Equals(upwd1))
            {
                Response.Write("<script>alert('密码不一致')</script>");
            }
            else if (HttpContext.Current.Session["check"] != null)//判断验证码
            {
                string check = HttpContext.Current.Session["check"].ToString();
                if (!check.ToUpper().Equals(ucheck.ToUpper()))
                {
                    //Response.Write("<script>alert('验证码输入错误')</script>");
                }
                else
                {
                    En_User eu = new En_User();
                    eu.UNum = Session["stuNum"].ToString().Trim();
                    eu.UName = RegularExpressions.MyEncodeInputString(uname);
                    eu.UPwd = Md5.MD5_encrypt(RegularExpressions.MyEncodeInputString(upwd1));
                    eu.UMail = RegularExpressions.MyEncodeInputString(umail);
                    eu.RegisterTime = DateTime.Now;
                    eu.LastLogin = DateTime.Now;
                    eu.State = 0;
                    int blank = BADL_User.IsBlankReg(eu);//判断字段长度
                    if (blank == 5)
                    {
                        if (!BADL_User.IsStunumExsit(eu.UNum))
                        {
                            if (!BADL_User.IsNameExsit(eu.UName))
                            {
                                if (BADL_User.InsertUser(eu))
                                {
                                    Response.Redirect("login.aspx");//注册成功,跳转到登录界面
                                }
                                else
                                {
                                    Response.Write("<script>alert('注册异常')</script>");
                                }
                            }
                            else Response.Write("<script>alert('昵称存在')</script>");
                        }
                        else
                            Response.Write("<script>alert('学号存在')</script>");
                    }
                    else
                    {
                        //Response.Write("<script>alert('字段长度不符')</script>");
                    }
                }
            }
            else
            {
                //Response.Write("<script>alert('验证码生成错误')</script>");
            }
        }
    }
}