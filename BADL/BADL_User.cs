using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Common;
using System.Data.Sql;
using System.Data;
using System.Configuration;

namespace BADL
{
    public class BADL_User
    {
        static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["conGhyusers"].ConnectionString;
        public static bool InsertUser(En_User user)//注册
        {
            string sql = @"INSERT INTO [ghyusers].[dbo].[user]
           ([uNum]
           ,[uName]
           ,[uPwd]
           ,[uMail]
           ,[uIP]
           ,[registerTime]
           ,[lastLogin]
           ,[state])
     VALUES
           ('" + user.UNum + "',N'" + user.UName + "',N'" + user.UPwd + "',N'" + user.UMail + "',N'" + user.UIP + "',N'" + user.RegisterTime.ToString("yyyy-MM-dd HH:mm:ss") + "','" + user.LastLogin.ToString("yyyy-MM-dd HH:mm:ss") + "','" + user.State + "')";
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(constr, CommandType.Text, sql) > 0 ? true : false;
        }

        public static En_User Login(string userInfo, string password)//登录判断，若成功，返回En_User对象
        {
            string regMail = @"^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$";
            string sql = "";
            SqlHelper helper = new SqlHelper();

            if(System.Text.RegularExpressions.Regex.IsMatch(userInfo,regMail))//如果输入的是邮箱
            {
                sql = "select * from [user] where uMail=N'" + userInfo + "' and uPwd=N'" + password + "'";
            }
            else//如果输入的是昵称
            {
                sql = "select * from [user] where uName=N'" + userInfo + "' and uPwd=N'" + password + "'";
            }
            
            DataTable userTable = helper.ExcuteDataTable(constr, CommandType.Text, sql);
            if (userTable.Rows.Count == 1)
            {
                En_User eu = new En_User();
                object[] item = userTable.Rows[0].ItemArray;
                eu.UID = new Guid(item[0].ToString());
                eu.UNum = item[1].ToString();
                eu.UName = item[2].ToString();
                eu.UPwd = item[3].ToString();
                eu.UMail = item[4].ToString();
                eu.UGrade = item[5] == System.DBNull.Value ? 0 : Int32.Parse(item[5].ToString());
                eu.USex = item[6] == System.DBNull.Value ? 2 : Int32.Parse(item[6].ToString());
                eu.UTel = item[7].ToString();
                eu.UPic = item[8].ToString();
                eu.UIP = item[9].ToString();
                eu.RegisterTime = (DateTime)item[10];
                eu.TrueName = item[11].ToString();
                eu.State = Int32.Parse(item[12].ToString());
                eu.LastLogin = (DateTime)item[13];
                return eu;
            }
            else
                return null;
        }
        public static bool updatePwd(int worknum, string newPwd)//由学号修改密码
        {
            string sql = "update [user] set uPwd=N'" + newPwd + "' where uNum=N'" + worknum + "'";
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(constr, CommandType.Text, sql) > 0 ? true : false;
        }
        public static En_User Login(string worknum)//验证学号是否已注册，若已注册，返回En_User对象
        {
            SqlHelper helper = new SqlHelper();
            string sql = "select * from [user] where uNum='" + worknum + "'";
            DataTable userTable = helper.ExcuteDataTable(constr, CommandType.Text, sql);
            if (userTable.Rows.Count == 1)
            {
                En_User eu = new En_User();
                object[] item = userTable.Rows[0].ItemArray;
                eu.UID = new Guid(item[0].ToString());
                eu.UNum = item[1].ToString();
                eu.UName = item[2].ToString();
                eu.UPwd = item[3].ToString();
                eu.UMail = item[4].ToString();
                eu.UGrade = item[5] == System.DBNull.Value ? 0 : Int32.Parse(item[5].ToString());
                eu.USex = item[6] == System.DBNull.Value ? 2 : Int32.Parse(item[6].ToString());
                eu.UTel = item[7].ToString();
                eu.UPic = item[8].ToString();
                eu.UIP = item[9].ToString();
                eu.RegisterTime = (DateTime)item[10];
                eu.TrueName = item[11].ToString();
                eu.State = Int32.Parse(item[12].ToString());
                eu.LastLogin = (DateTime)item[13];
                return eu;
            }
            else
                return null;
        }
        public static int IsBlankReg(En_User eu)//注册字符串长度判断
        {
            if (eu.UNum.Equals("") || eu.UNum.Length > 20)
            {
                return 1;//学号长度不符
            }
            else if (eu.UName .Equals("") || eu.UName.Length > 20)
            {
                return 2;//昵称长度不符
            }
            else if (eu.UPwd.Equals("") || eu.UPwd.Length > 50)
            {
                return 3;//密码长度不符
            }
            else if (eu.UMail.Equals("") || eu.UMail.Length > 50)
            {
                return 4;//邮箱长度不符
            }            
            else
                return 5;
        }

        public static int IsBlankAdd(En_User eu)//完善信息字符串判断
        {
            if (eu.UTel.Equals("") || eu.UTel.Length > 50)
            {
                return 1;//电话长度不符
            }
            else if (eu.TrueName.Equals("") || eu.TrueName.Length > 20)
            {
                return 2;//trueName长度不符
            }
            else
                return 3;
        }


        public static bool IsStunumExsit(string worknum)//学号是否存在
        {
            SqlHelper helper = new SqlHelper();
            string update = "update [user] set uNum=N'" + worknum + "' where uNum=N'" + worknum + "'";
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
        public static bool IsNameExsit(string name)//昵称是否存在
        {
            SqlHelper helper = new SqlHelper();
            string update = "update [user] set uName=N'" + name + "'   where uName=N'" + name + "'";
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
        public static bool IsMailExsit(string umail)//邮箱是否存在
        {
            SqlHelper helper = new SqlHelper();
            string update = "update [user] set uMail=N'" + umail + "'   where uMail=N'" + umail + "'";
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
        public static bool HasUserID(int userid)
        {
            SqlHelper helper = new SqlHelper();
            string sql = "select [uID] from [user] where uID='" + userid + "'";
            object res = helper.ExecuteScalar(constr, CommandType.Text, sql);
            if (res != null) { return true; }
            else return false;
        }

        public static bool CheckCookies(string worknum, string password)//验证cookies是否可信
        {
            string realpassword = "";
            SqlHelper helper = new SqlHelper();
            string sql = "select [uPwd] from [user] where uNum='" + worknum + "'";
            if (helper.ExecuteScalar(constr, CommandType.Text, sql) != null)
                realpassword = helper.ExecuteScalar(constr, CommandType.Text, sql).ToString();
            if (!String.IsNullOrEmpty(realpassword)) { return password.Equals(realpassword.Trim()); }
            else return false;
        }
        public static bool ChangeLogInfor(string worknum, DateTime time)//更新登录时间
        {
            SqlHelper helper = new SqlHelper();
            string sql = "update [user] set lastLogin='" + time.ToString("yyyy-MM-dd HH:mm:ss") + "' where uNum='" + worknum + "'";
            return helper.ExecuteNonQuery(constr, CommandType.Text, sql) == 1 ? true : false;
        }
        public static bool ChangePwd(string pwd, string worknum)//更新密码
        {
            SqlHelper helper = new SqlHelper();
            string sql = "update [user] set uPwd='" + pwd + "' where uNum='" + worknum + "'";
            return helper.ExecuteNonQuery(constr, CommandType.Text, sql) == 1 ? true : false;
        }
        public static string GetUserID(string worknum)//由学号获得id
        {
            SqlHelper helper = new SqlHelper();
            string sql = "select [uID] from [user] where uNum='" + worknum + "'";
            object result = helper.ExecuteScalar(constr, CommandType.Text, sql);
            return result == null ? "0" : result.ToString();
        }
        public static string GetUserName(string worknum)//由学号获得昵称
        {
            SqlHelper helper = new SqlHelper();
            string sql = "select [uName] from [user] where uNum='" + worknum + "'";
            object result = helper.ExecuteScalar(constr, CommandType.Text, sql);
            return result == null ? "" : result.ToString();
        }
        public static string GetUserMail(string worknum)//由学号获得邮箱
        {
            SqlHelper helper = new SqlHelper();
            string sql = "select [uMail] from [user] where uNum='" + worknum + "'";
            object result = helper.ExecuteScalar(constr, CommandType.Text, sql);
            return result == null ? "" : result.ToString();
        }

        public static string GetUserRole(string worknum)//由学号获得用户角色
        {
            SqlHelper helper = new SqlHelper();
            string sql = "select [roleName] from [role],[user-role] where [role].[roleID] = [user-role].[roleID] and [uID]='" + GetUserID(worknum) + "'";
            object result = helper.ExecuteScalar(constr, CommandType.Text, sql);
            return result == null ? "0" : result.ToString();
        }
    }
}
