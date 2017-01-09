using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Common
{
    public abstract class MasterModel : IModel
    {
        public StatusEnum Status { get; set; }

        public string TableName { get; }

        private int creatorId;
        public int CreatorId
        {
            get { return this.creatorId; }
            set { this.creatorId = value; }
        }

        private DateTime createTime;
        public DateTime CreateTime
        {
            get { return this.createTime; }
            set { this.createTime = value; }
        }

        private int lastModifyId;
        public int LastModifyId
        {
            get { return this.lastModifyId; }
            set { this.lastModifyId = value; }
        }

        private DateTime lastModifyTime;
        public DateTime LastModifyTime
        {
            get { return this.lastModifyTime; }
            set { this.lastModifyTime = value; }
        }
    }
}
