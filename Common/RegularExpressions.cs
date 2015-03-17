using System;
using System.Collections.Generic;
using System.Web;
using System.Text.RegularExpressions;

namespace Common
{
    public class RegularExpressions
    {
        public static bool CheckNum(string num)
        {
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.
            Regex(@"^[-]?[1-9]{1}\d*$|^[0]{1}$");
            bool ismatch = reg1.IsMatch(num);
            return ismatch;
        }
        public static bool CheckPassWord(string password)
        {
            return Regex.Match(password, @"^[a-zA-Z]\w{5,15}$").Success;
        }
        /// <summary>
        /// 过滤sql字符
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string MyEncodeInputString(string inputString)
        {
            //要替换的敏感字
            string SqlStr = @"and|or|exec|execute|insert|select|delete|update|alter|create|drop|count|\*|chr|char|asc|mid|substring|master|truncate|declare|xp_cmdshell|restore|backup|net +user|net +localgroup +administrators";
            try
            {
                if ((inputString != null) && (inputString != String.Empty))
                {
                    string str_Regex = @"\b(" + SqlStr + @")\b";

                    Regex Regex = new Regex(str_Regex, RegexOptions.IgnoreCase);
                    //string s = Regex.Match(inputString).Value; 
                    MatchCollection matches = Regex.Matches(inputString);
                    for (int i = 0; i < matches.Count; i++)
                        inputString = inputString.Replace(matches[i].Value, "[" + matches[i].Value + "]");

                }
            }
            catch
            {
                return "";
            }
            return inputString;
        }
        /// <summary>
        /// 省略文章字符
        /// </summary>
        /// <param name="s"></param>
        /// <param name="l">截取的位置</param>
        /// <param name="showdot">是否显示“。。”</param>
        /// <returns></returns>
        public static string CutWord(string s, int l, bool showdot)
        {
            string ss;
            if (s.Length > l)
            {
                ss = s.Remove(l); if (showdot)
                    ss += "...";
            }
            else
                ss = s;


            return ss;
        }
        public static string CheckHtml(string html)
        {
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" no[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>]+\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex9 = new System.Text.RegularExpressions.Regex(@"<[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记   
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性   
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件   
            html = regex4.Replace(html, ""); //过滤iframe   
            html = regex5.Replace(html, ""); //过滤frameset   
            html = regex6.Replace(html, ""); //过滤frameset   
            html = regex7.Replace(html, ""); //过滤frameset   
            html = regex8.Replace(html, ""); //过滤frameset   
            html = regex9.Replace(html, "");
            html = html.Replace(" ", "");
            html = html.Replace("</strong>", "");
            html = html.Replace("<strong>", "");
            return html;
        }
    }
}