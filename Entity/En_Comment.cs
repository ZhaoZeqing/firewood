using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    class En_Comment
    {
        private Guid commentID;

        public Guid CommentID
        {
            get { return commentID; }
            set { commentID = value; }
        }

        private Guid userID;

        public Guid UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private Guid orgID;

        public Guid OrgID
        {
            get { return orgID; }
            set { orgID = value; }
        }

        private Guid activityID;

        public Guid ActivityID
        {
            get { return activityID; }
            set { activityID = value; }
        }

        private string commentCon;

        public string CommentCon
        {
            get { return commentCon; }
            set { commentCon = value; }
        }

        private DateTime time;

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        private int state;

        public int State
        {
            get { return state; }
            set { state = value; }
        }
    }
}
