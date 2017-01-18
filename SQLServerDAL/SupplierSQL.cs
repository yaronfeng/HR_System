using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.DBUtility;
using HR.Model;
using System.Data.SqlClient;
using System.Data;
using HR.Common;

namespace HR.SQLServerDAL
{
    public class SupplierSQL
    {
        private string ConnectString
        {
            get
            {
                return SQLConnString.GetConnSting();
            }
        }

        public SelectModel SupplierListSelect(int pageIndex, int pageSize, string orderStr)
        {
            SelectModel select = new SelectModel();

            select.PageIndex = pageIndex;
            select.PageSize = pageSize;
            if (string.IsNullOrEmpty(orderStr))
                select.OrderStr = " SupId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = "SupId,SupCode,SupName,SupEName,SupAddress,SupContacts,SupTel,SupFax,SupZip,SupEmail,Bank,BankAccount,ServiceAmount,SupStatus";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" Usr_Supplier ");

            select.TableName = sb.ToString();

            //sb.Length = 0;

            //sb.AppendFormat(" and di.PositionStatus >{0} ", (int)StatusEnum.已作废);

            //select.WhereStr = sb.ToString();

            return select;
        }
    }
}
