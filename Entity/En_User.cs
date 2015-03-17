using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class En_User
    {
        private Guid uID;

        public Guid UID
        {
            get { return uID; }
            set { uID = value; }
        }

        private string uNum;

        public string UNum
        {
            get { return uNum; }
            set { uNum = value; }
        }

        private string uName;

        public string UName
        {
            get { return uName; }
            set { uName = value; }
        }

        private string uPwd;

        public string UPwd
        {
            get { return uPwd; }
            set { uPwd = value; }
        }

        private string uMail;

        public string UMail
        {
            get { return uMail; }
            set { uMail = value; }
        }

        private int uGrade;

        public int UGrade
        {
            get { return uGrade; }
            set { uGrade = value; }
        }

        private int uSex;

        public int USex
        {
            get { return uSex; }
            set { uSex = value; }
        }

        private string uTel;

        public string UTel
        {
            get { return uTel; }
            set { uTel = value; }
        }

        private string uPic;

        public string UPic
        {
            get { return uPic; }
            set { uPic = value; }
        }

        private string uIP;

        public string UIP
        {
            get { return uIP; }
            set { uIP = value; }
        }

        private DateTime registerTime;

        public DateTime RegisterTime
        {
            get { return registerTime; }
            set { registerTime = value; }
        }

        private string trueName;

        public string TrueName
        {
            get { return trueName; }
            set { trueName = value; }
        }

        private int state;

        public int State
        {
            get { return state; }
            set { state = value; }
        }

        private DateTime lastLogin;

        public DateTime LastLogin
        {
            get { return lastLogin; }
            set { lastLogin = value; }
        }

        public En_User() { }

        public En_User(Guid _uid, string _unum, string _uname, string _upwd, string _umail, int _ugrade, int _usex, string _utel, string _upic, string _uip, DateTime _registertime, string _truename, int _state, DateTime _lastlogin)
        {
            uID = _uid;
            uNum = _unum;
            uName = _uname;
            uPwd = _upwd;
            uMail = _umail;
            uGrade = _ugrade;
            uSex = _usex;
            uTel = _utel;
            uPic = _upic;
            uIP = _uip;
            registerTime = _registertime;
            trueName = _truename;
            lastLogin = _lastlogin;
            state = _state;
        }
    }
}
