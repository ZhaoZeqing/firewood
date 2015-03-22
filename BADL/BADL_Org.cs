using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Common;
using System.Data.Sql;
using System.Data;
using System.Configuration;

namespace BADL
{
    public class BADL_Org
    {
        static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["conFirewood"].ConnectionString;
        public static bool InsertOrg(En_Org org)//注册
        {
            string sql = @"INSERT INTO [firewood].[dbo].[org]
           ([orgName]
           ,[orgPwd]
           ,[orgPrincipal]
           ,[orgTel]
           ,[orgDepartment]
           ,[orgPic]
           ,[orgIntroduction]
           ,[orgContact]
           ,[orgIP]
           ,[registerTime]
           ,[lastLogin]
           ,[state])
     VALUES
           ('" + org.OrgName + "',N'" + org.OrgPwd + "',N'" + org.OrgPrincipal + "',N'" + org.OrgTel + "',N'" + org.OrgDepartment + "',N'" + org.OrgPic + "',N'" + org.OrgIntroduction + "',N'" + org.OrgContact + "',N'" + org.OrgIP + "',N'" + org.RegisterTime.ToString("yyyy-MM-dd HH:mm:ss") + "','" + org.LastLogin.ToString("yyyy-MM-dd HH:mm:ss") + "','" + org.State + "')";
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(constr, CommandType.Text, sql) > 0 ? true : false;
        }

        public static En_Org Login(string orgName, string orgPwd)//登录判断，若成功，返回En_Org对象
        {
            SqlHelper helper = new SqlHelper();
            string sql = "select * from [user] where orgName=N'" + orgName + "' and orgPwd=N'" + orgPwd + "'";

            DataTable userTable = helper.ExcuteDataTable(constr, CommandType.Text, sql);
            if (userTable.Rows.Count == 1)
            {
                En_Org eu = new En_Org();
                object[] item = userTable.Rows[0].ItemArray;
                eu.OrgID = new Guid(item[0].ToString());
                eu.OrgName = item[1].ToString();
                eu.OrgPwd = item[2].ToString();
                eu.OrgPrincipal = item[3].ToString();
                eu.OrgTel = item[4].ToString();
                eu.OrgDepartment = item[5].ToString();
                eu.OrgPic = item[6].ToString();
                eu.OrgIntroduction = item[7].ToString();
                eu.OrgContact = item[8].ToString();
                eu.OrgIP = item[9].ToString();
                eu.RegisterTime = (DateTime)item[10];
                eu.State = Int32.Parse(item[11].ToString());
                eu.LastLogin = (DateTime)item[12];
                return eu;
            }
            else
                return null;
        }

        public static En_Org Login(string orgName)//验证该社团是否已注册，若已注册，返回En_Org对象
        {
            SqlHelper helper = new SqlHelper();
            string sql = "select * from [org] where orgName='" + orgName + "'";
            DataTable userTable = helper.ExcuteDataTable(constr, CommandType.Text, sql);
            if (userTable.Rows.Count == 1)
            {
                En_Org eu = new En_Org();
                object[] item = userTable.Rows[0].ItemArray;
                eu.OrgID = new Guid(item[0].ToString());
                eu.OrgName = item[1].ToString();
                eu.OrgPwd = item[2].ToString();
                eu.OrgPrincipal = item[3].ToString();
                eu.OrgTel = item[4].ToString();
                eu.OrgDepartment = item[5].ToString();
                eu.OrgPic = item[6].ToString();
                eu.OrgIntroduction = item[7].ToString();
                eu.OrgContact = item[8].ToString();
                eu.OrgIP = item[9].ToString();
                eu.RegisterTime = (DateTime)item[10];
                eu.State = Int32.Parse(item[11].ToString());
                eu.LastLogin = (DateTime)item[12];
                return eu;
            }
            else
                return null;
        }

        public static int IsBlankReg(En_Org eu)//注册字符串长度判断
        {
            if (eu.OrgName.Equals("") || eu.OrgName.Length > 20)
            {
                return 1;//社团名称长度不符
            }
            else if (eu.OrgPwd.Equals("") || eu.OrgPwd.Length > 50)
            {
                return 2;//密码长度不符
            }
            else if (eu.OrgPrincipal.Equals("") || eu.OrgPrincipal.Length > 20)
            {
                return 3;//负责人姓名长度不符
            }
            else if (eu.OrgTel.Equals("") || eu.OrgTel.Length > 50)
            {
                return 4;//负责人电话长度不符
            }
            else if (eu.OrgDepartment.Equals("") || eu.OrgDepartment.Length > 20)
            {
                return 5;//所属部门名称长度不符
            }
            else if (eu.OrgIntroduction.Equals("") || eu.OrgIntroduction.Length > 500)
            {
                return 6;//社团/组织介绍长度不符
            }
            else if (eu.OrgContact.Equals("") || eu.OrgContact.Length > 20)
            {
                return 7;//社团/组织联系方式长度不符
            }
            else
                return 8;
        }

        public static bool IsNameExsit(string name)//社团名称是否存在
        {
            SqlHelper helper = new SqlHelper();
            string update = "update [org] set orgName=N'" + name + "'   where orgName=N'" + name + "'";
            int count;
            count = helper.ExecuteNonQuery(constr, CommandType.Text, update);
            if (count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckCookies(string orgID, string password)//验证cookies是否可信
        {
            string realpassword = "";
            SqlHelper helper = new SqlHelper();
            string sql = "select [orgPwd] from [org] where orgID='" + orgID + "'";
            if (helper.ExecuteScalar(constr, CommandType.Text, sql) != null)
                realpassword = helper.ExecuteScalar(constr, CommandType.Text, sql).ToString();
            if (!String.IsNullOrEmpty(realpassword)) { return password.Equals(realpassword.Trim()); }
            else return false;
        }

        public static bool ChangeLogInfor(string orgName, DateTime time)//更新登录时间
        {
            SqlHelper helper = new SqlHelper();
            string sql = "update [org] set lastLogin='" + time.ToString("yyyy-MM-dd HH:mm:ss") + "' where orgName='" + orgName + "'";
            return helper.ExecuteNonQuery(constr, CommandType.Text, sql) == 1 ? true : false;
        }

        public static bool ChangePwd(string orgName, string orgPwd)//更新密码
        {
            SqlHelper helper = new SqlHelper();
            string sql = "update [org] set orgPwd='" + orgPwd + "' where orgName='" + orgName + "'";
            return helper.ExecuteNonQuery(constr, CommandType.Text, sql) == 1 ? true : false;
        }

        public static String GetOrgID(string orgName)//由社团名称获得id
        {
            SqlHelper helper = new SqlHelper();
            string sql = "select [orgID] from [org] where orgName='" + orgName + "'";
            object result = helper.ExecuteScalar(constr, CommandType.Text, sql);
            return result == null ? "0" : result.ToString();
        }
    }
}
