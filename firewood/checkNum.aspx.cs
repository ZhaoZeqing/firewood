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
        protected void Page_Load(object sender, EventArgs e)
        {
            id = RegularExpressions.MyEncodeInputString(Request["id"].Trim());
        }

        protected void check(object sender, EventArgs e)
        {
            string stunumStr = RegularExpressions.MyEncodeInputString(worknum.Value.Trim());
            string pwdStr = RegularExpressions.MyEncodeInputString(pwd.Value.Trim());
            int isStuNumExsit = BADL_User.IsStunumExsit(stunumStr) ? 0 : 1;//0:学号存在，1:学号不存在

            if (CheckUserNum(stunumStr, pwdStr))
            {
                if (id.Equals("0"))
                {
                    if (isStuNumExsit == 1)
                    {
                        Session["stuNum"] = stunumStr;
                        Response.Redirect("uReg.aspx");
                    }
                    else if (isStuNumExsit == 0)
                    {
                        Response.Write("<script>alert('该学号已被注册')</script>");
                    }
                }
                else if (id.Equals("1"))
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
                    Response.Write("<script>alert('参数错误')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('验证失败，学号或上网密码错误')</script>");
            }
        }
        public static bool CheckUserNum(string userNum, string password)
        {
            string Url = @"http://v.ghy.swufe.edu.cn/Service.asmx/chkUser?userNum=" + userNum + "&password=" + password;//验证该用户，存在就是2，不存在就是1

            WebClient wc = new WebClient();

            wc.Credentials = CredentialCache.DefaultCredentials;//此处不懂，此处不懂，语句不懂

            byte[] dataBuffer = wc.DownloadData(Url);

            string strWebData = Encoding.Default.GetString(dataBuffer);

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(strWebData);//获取webservice返回的xmlstring，读到doc中

            string a = doc.GetElementsByTagName("int")[0].InnerText;

            if (a.Equals("2"))//验证节点内容，确定返回值
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}