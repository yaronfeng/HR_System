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

        public SelectModel SupplierListSelect(int pageIndex, int pageSize, string orderStr,int supId)
        {
            SelectModel select = new SelectModel();

            select.PageIndex = pageIndex;
            select.PageSize = pageSize;
            if (string.IsNullOrEmpty(orderStr))
                select.OrderStr = " SupId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = "SupId,SupCode,SupName,SupEName,SupAddress,SupContacts,SupTel,SupFax,SupZip,SupEmail,Bank,BankAccount,ServiceAmount,SupStatus,sd.DetailName as StatusName";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" Usr_Supplier sup");
            sb.AppendFormat(" inner join bd_StyleDetail sd on sd.DetailId = sup.SupStatus and sd.StyleId = {0}", (int)StyleTypeEnum.通用状态);

            select.TableName = sb.ToString();

            sb.Length = 0;
            if(supId>0)
                sb.AppendFormat(" sup.SupId = {0} ", supId);

            select.WhereStr = sb.ToString();

            return select;
        }
    }
}
