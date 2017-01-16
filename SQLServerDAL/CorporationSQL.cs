using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Model;
using System.Data.SqlClient;
using System.Data;
using HR.Common;
using HR.DBUtility;

namespace HR.SQLServerDAL
{
    public class CorporationSQL
    {
        private string ConnectString
        {
            get
            {
                return SQLConnString.GetConnSting();
            }
        }
        public SelectModel CorporationListSelect(int pageIndex, int pageSize, string orderStr)
        {
            SelectModel select = new SelectModel();

            select.PageIndex = pageIndex;
            select.PageSize = pageSize;
            if (string.IsNullOrEmpty(orderStr))
                select.OrderStr = " CorpId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = "CorpId,CorpName,CorpAddress,CorpContacts,CorpTel,CorpEmail,PayCity,CorpStatus";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" Usr_Corporation ");

            select.TableName = sb.ToString();

            //sb.Length = 0;

            //sb.AppendFormat(" and di.PositionStatus >{0} ", (int)StatusEnum.已作废);

            //select.WhereStr = sb.ToString();

            return select;
        }
    }
}
