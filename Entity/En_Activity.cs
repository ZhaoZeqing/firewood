using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    class En_Activity
    {
        private Guid activityID;

        public Guid ActivityID
        {
            get { return activityID; }
            set { activityID = value; }
        }

        private string aName;

        public string AName
        {
            get { return aName; }
            set { aName = value; }
        }

        private int orgID;

        public int OrgID
        {
            get { return orgID; }
            set { orgID = value; }
        }

        private string class1;

        public string Class1
        {
            get { return class1; }
            set { class1 = value; }
        }

        private string class2;

        public string Class2
        {
            get { return class2; }
            set { class2 = value; }
        }

        private string place;

        public string Place
        {
            get { return place; }
            set { place = value; }
        }

        private DateTime beginTime;

        public DateTime BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }

        private DateTime endTime;

        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        private int moneyState;

        public int MoneyState
        {
            get { return moneyState; }
            set { moneyState = value; }
        }

        private int scoreState;

        public int ScoreState
        {
            get { return scoreState; }
            set { scoreState = value; }
        }

        private int awardState;

        public int AwardState
        {
            get { return awardState; }
            set { awardState = value; }
        }

        private int voteState;

        public int VoteState
        {
            get { return voteState; }
            set { voteState = value; }
        }

        private string aIntroduction;

        public string AIntroduction
        {
            get { return aIntroduction; }
            set { aIntroduction = value; }
        }

        private string aPic;

        public string APic
        {
            get { return aPic; }
            set { aPic = value; }
        }

        private int state;

        public int State
        {
            get { return state; }
            set { state = value; }
        }

        public En_Activity() { }

        public En_Activity(Guid _activityid, string _aName, int _orgid, string _class1, string _class2, string _place, DateTime _begintime, DateTime _endtime, int _moneystate, int _scorestate, int _awardstate, int _votestate, string _aintroduction, string _apic, int _state)
        {
            activityID = _activityid;
            aName = _aName;
            orgID = _orgid;
            class1 = _class1;
            class2 = _class2;
            place = _place;
            beginTime = _begintime;
            endTime = _endtime;
            moneyState = _moneystate;
            scoreState = _scorestate;
            awardState = _awardstate;
            voteState = _votestate;
            aIntroduction = _aintroduction;
            aPic = _apic;
            state = _state;
        }
    }
}
