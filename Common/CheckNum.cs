using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Xml;

namespace Common
{
    public class CheckNum
    {
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
