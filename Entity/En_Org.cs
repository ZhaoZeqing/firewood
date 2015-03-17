using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class En_Org
    {
        private Guid orgID;

        public Guid OrgID
        {
            get { return orgID; }
            set { orgID = value; }
        }

        private string orgName;

        public string OrgName
        {
            get { return orgName; }
            set { orgName = value; }
        }

        private string orgPwd;

        public string OrgPwd
        {
            get { return orgPwd; }
            set { orgPwd = value; }
        }

        private string orgPrincipal;

        public string OrgPrincipal
        {
            get { return orgPrincipal; }
            set { orgPrincipal = value; }
        }

        private string orgTel;

        public string OrgTel
        {
            get { return orgTel; }
            set { orgTel = value; }
        }

        private string orgDepartment;

        public string OrgDepartment
        {
            get { return orgDepartment; }
            set { orgDepartment = value; }
        }

        private string orgPic;

        public string OrgPic
        {
            get { return orgPic; }
            set { orgPic = value; }
        }

        private string orgIntroduction;

        public string OrgIntroduction
        {
            get { return orgIntroduction; }
            set { orgIntroduction = value; }
        }

        private string orgContact;

        public string OrgContact
        {
            get { return orgContact; }
            set { orgContact = value; }
        }

        private string orgIP;

        public string OrgIP
        {
            get { return orgIP; }
            set { orgIP = value; }
        }

        private DateTime registerTime;

        public DateTime RegisterTime
        {
            get { return registerTime; }
            set { registerTime = value; }
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

        public En_Org() { }

        public En_Org(Guid _orgid, string _orgname, string _orgpwd, string _orgpricipal, string _orgtel, string  _orgdepartment, string _orgpic, string _orgintroduction, string _orgcontact, string _orgip, DateTime _registertime, int _state, DateTime _lastlogin)
        {
            orgID = _orgid;
            orgName = _orgname;
            orgPwd = _orgpwd;
            orgPrincipal = _orgpricipal;
            orgTel = _orgtel;
            orgDepartment = _orgdepartment;
            orgPic = _orgpic;
            orgIntroduction = _orgintroduction;
            orgContact = _orgcontact;
            orgIP = _orgip;
            registerTime = _registertime;
            state = _state;
            lastLogin = _lastlogin;
        }
    }
}
