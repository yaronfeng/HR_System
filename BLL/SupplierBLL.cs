using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.SQLServerDAL;
using HR.Model;
using HR.Common;
using System.Data.SqlClient;
using System.Data;

namespace HR.BLL
{
    public class SupplierBLL : Operate
    {
        private CorporationSQL sql_insrance = new CorporationSQL();

        protected override List<SqlParameter> CreateInsertParameters(IModel obj, ref SqlParameter returnValue)
        {
            Supplier usr_supplier = (Supplier)obj;

            List<SqlParameter> paras = new List<SqlParameter>();
            returnValue.Direction = ParameterDirection.Output;
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.ParameterName = "@SupId";
            returnValue.Size = 4;
            paras.Add(returnValue);

            if (!string.IsNullOrEmpty(usr_supplier.SupCode))
            {
                SqlParameter supcodepara = new SqlParameter("@SupCode", SqlDbType.VarChar, 50);
                supcodepara.Value = usr_supplier.SupCode;
                paras.Add(supcodepara);
            }

            if (!string.IsNullOrEmpty(usr_supplier.SupName))
            {
                SqlParameter supnamepara = new SqlParameter("@SupName", SqlDbType.VarChar, 50);
                supnamepara.Value = usr_supplier.SupName;
                paras.Add(supnamepara);
            }

            if (!string.IsNullOrEmpty(usr_supplier.SupEName))
            {
                SqlParameter supenamepara = new SqlParameter("@SupEName", SqlDbType.VarChar, 50);
                supenamepara.Value = usr_supplier.SupEName;
                paras.Add(supenamepara);
            }

            if (!string.IsNullOrEmpty(usr_supplier.SupAddress))
            {
                SqlParameter supaddresspara = new SqlParameter("@SupAddress", SqlDbType.VarChar, 50);
                supaddresspara.Value = usr_supplier.SupAddress;
                paras.Add(supaddresspara);
            }

            if (!string.IsNullOrEmpty(usr_supplier.SupContacts))
            {
                SqlParameter supcontactspara = new SqlParameter("@SupContacts", SqlDbType.VarChar, 50);
                supcontactspara.Value = usr_supplier.SupContacts;
                paras.Add(supcontactspara);
            }

            if (!string.IsNullOrEmpty(usr_supplier.SupTel))
            {
                SqlParameter suptelpara = new SqlParameter("@SupTel", SqlDbType.VarChar, 50);
                suptelpara.Value = usr_supplier.SupTel;
                paras.Add(suptelpara);
            }

            if (!string.IsNullOrEmpty(usr_supplier.SupFax))
            {
                SqlParameter supfaxpara = new SqlParameter("@SupFax", SqlDbType.VarChar, 50);
                supfaxpara.Value = usr_supplier.SupFax;
                paras.Add(supfaxpara);
            }

            if (!string.IsNullOrEmpty(usr_supplier.SupZip))
            {
                SqlParameter supzippara = new SqlParameter("@SupZip", SqlDbType.VarChar, 50);
                supzippara.Value = usr_supplier.SupZip;
                paras.Add(supzippara);
            }

            if (!string.IsNullOrEmpty(usr_supplier.SupEmail))
            {
                SqlParameter supemailpara = new SqlParameter("@SupEmail", SqlDbType.VarChar, 50);
                supemailpara.Value = usr_supplier.SupEmail;
                paras.Add(supemailpara);
            }

            SqlParameter bankpara = new SqlParameter("@Bank", SqlDbType.Int, 4);
            bankpara.Value = usr_supplier.Bank;
            paras.Add(bankpara);

            if (!string.IsNullOrEmpty(usr_supplier.BankAccount))
            {
                SqlParameter bankaccountpara = new SqlParameter("@BankAccount", SqlDbType.VarChar, 50);
                bankaccountpara.Value = usr_supplier.BankAccount;
                paras.Add(bankaccountpara);
            }

            if (!string.IsNullOrEmpty(usr_supplier.ServiceAmount))
            {
                SqlParameter serviceamountpara = new SqlParameter("@ServiceAmount", SqlDbType.VarChar, 50);
                serviceamountpara.Value = usr_supplier.ServiceAmount;
                paras.Add(serviceamountpara);
            }

            SqlParameter supstatuspara = new SqlParameter("@SupStatus", SqlDbType.Int, 4);
            supstatuspara.Value = usr_supplier.SupStatus;
            paras.Add(supstatuspara);

            if (!string.IsNullOrEmpty(usr_supplier.Memo))
            {
                SqlParameter memopara = new SqlParameter("@Memo", SqlDbType.VarChar, 150);
                memopara.Value = usr_supplier.Memo;
                paras.Add(memopara);
            }

            SqlParameter creatoridpara = new SqlParameter("@CreatorId", SqlDbType.Int, 4);
            creatoridpara.Value = obj.CreatorId;
            paras.Add(creatoridpara);


            return paras;
        }
        public override List<SqlParameter> CreateUpdateParameters(IModel obj)
        {
            Supplier usr_supplier = (Supplier)obj;

            List<SqlParameter> paras = new List<SqlParameter>();

            SqlParameter supidpara = new SqlParameter("@SupId", SqlDbType.Int, 4);
            supidpara.Value = usr_supplier.SupId;
            paras.Add(supidpara);

            if (!string.IsNullOrEmpty(usr_supplier.SupCode))
            {
                SqlParameter supcodepara = new SqlParameter("@SupCode", SqlDbType.VarChar, 50);
                supcodepara.Value = usr_supplier.SupCode;
                paras.Add(supcodepara);
            }

            if (!string.IsNullOrEmpty(usr_supplier.SupName))
            {
                SqlParameter supnamepara = new SqlParameter("@SupName", SqlDbType.VarChar, 50);
                supnamepara.Value = usr_supplier.SupName;
                paras.Add(supnamepara);
            }

            if (!string.IsNullOrEmpty(usr_supplier.SupEName))
            {
                SqlParameter supenamepara = new SqlParameter("@SupEName", SqlDbType.VarChar, 50);
                supenamepara.Value = usr_supplier.SupEName;
                paras.Add(supenamepara);
            }

            if (!string.IsNullOrEmpty(usr_supplier.SupAddress))
            {
                SqlParameter supaddresspara = new SqlParameter("@SupAddress", SqlDbType.VarChar, 50);
                supaddresspara.Value = usr_supplier.SupAddress;
                paras.Add(supaddresspara);
            }

            if (!string.IsNullOrEmpty(usr_supplier.SupContacts))
            {
                SqlParameter supcontactspara = new SqlParameter("@SupContacts", SqlDbType.VarChar, 50);
                supcontactspara.Value = usr_supplier.SupContacts;
                paras.Add(supcontactspara);
            }

            if (!string.IsNullOrEmpty(usr_supplier.SupTel))
            {
                SqlParameter suptelpara = new SqlParameter("@SupTel", SqlDbType.VarChar, 50);
                suptelpara.Value = usr_supplier.SupTel;
                paras.Add(suptelpara);
            }

            if (!string.IsNullOrEmpty(usr_supplier.SupFax))
            {
                SqlParameter supfaxpara = new SqlParameter("@SupFax", SqlDbType.VarChar, 50);
                supfaxpara.Value = usr_supplier.SupFax;
                paras.Add(supfaxpara);
            }

            if (!string.IsNullOrEmpty(usr_supplier.SupZip))
            {
                SqlParameter supzippara = new SqlParameter("@SupZip", SqlDbType.VarChar, 50);
                supzippara.Value = usr_supplier.SupZip;
                paras.Add(supzippara);
            }

            if (!string.IsNullOrEmpty(usr_supplier.SupEmail))
            {
                SqlParameter supemailpara = new SqlParameter("@SupEmail", SqlDbType.VarChar, 50);
                supemailpara.Value = usr_supplier.SupEmail;
                paras.Add(supemailpara);
            }

            SqlParameter bankpara = new SqlParameter("@Bank", SqlDbType.Int, 4);
            bankpara.Value = usr_supplier.Bank;
            paras.Add(bankpara);

            if (!string.IsNullOrEmpty(usr_supplier.BankAccount))
            {
                SqlParameter bankaccountpara = new SqlParameter("@BankAccount", SqlDbType.VarChar, 50);
                bankaccountpara.Value = usr_supplier.BankAccount;
                paras.Add(bankaccountpara);
            }

            if (!string.IsNullOrEmpty(usr_supplier.ServiceAmount))
            {
                SqlParameter serviceamountpara = new SqlParameter("@ServiceAmount", SqlDbType.VarChar, 50);
                serviceamountpara.Value = usr_supplier.ServiceAmount;
                paras.Add(serviceamountpara);
            }

            SqlParameter supstatuspara = new SqlParameter("@SupStatus", SqlDbType.Int, 4);
            supstatuspara.Value = usr_supplier.SupStatus;
            paras.Add(supstatuspara);

            if (!string.IsNullOrEmpty(usr_supplier.Memo))
            {
                SqlParameter memopara = new SqlParameter("@Memo", SqlDbType.VarChar, 150);
                memopara.Value = usr_supplier.Memo;
                paras.Add(memopara);
            }

            SqlParameter lastmodifyidpara = new SqlParameter("@LastModifyId", SqlDbType.Int, 4);
            lastmodifyidpara.Value = obj.LastModifyId;
            paras.Add(lastmodifyidpara);


            return paras;
        }
        protected override IModel CreateModel(SqlDataReader dr)
        {
            Supplier supplier = new Supplier();

            int indexSupId = dr.GetOrdinal("SupId");
            supplier.SupId = Convert.ToInt32(dr[indexSupId]);
            int indexSupCode = dr.GetOrdinal("SupCode");
            if (dr[indexSupCode] != DBNull.Value)
            {
                supplier.SupCode = Convert.ToString(dr[indexSupCode]);
            }
            int indexSupName = dr.GetOrdinal("SupName");
            if (dr[indexSupName] != DBNull.Value)
            {
                supplier.SupName = Convert.ToString(dr[indexSupName]);
            }
            int indexSupEName = dr.GetOrdinal("SupEName");
            if (dr[indexSupEName] != DBNull.Value)
            {
                supplier.SupEName = Convert.ToString(dr[indexSupEName]);
            }
            int indexSupAddress = dr.GetOrdinal("SupAddress");
            if (dr[indexSupAddress] != DBNull.Value)
            {
                supplier.SupAddress = Convert.ToString(dr[indexSupAddress]);
            }
            int indexSupContacts = dr.GetOrdinal("SupContacts");
            if (dr[indexSupContacts] != DBNull.Value)
            {
                supplier.SupContacts = Convert.ToString(dr[indexSupContacts]);
            }
            int indexSupTel = dr.GetOrdinal("SupTel");
            if (dr[indexSupTel] != DBNull.Value)
            {
                supplier.SupTel = Convert.ToString(dr[indexSupTel]);
            }
            int indexSupFax = dr.GetOrdinal("SupFax");
            if (dr[indexSupFax] != DBNull.Value)
            {
                supplier.SupFax = Convert.ToString(dr[indexSupFax]);
            }
            int indexSupZip = dr.GetOrdinal("SupZip");
            if (dr[indexSupZip] != DBNull.Value)
            {
                supplier.SupZip = Convert.ToString(dr[indexSupZip]);
            }
            int indexSupEmail = dr.GetOrdinal("SupEmail");
            if (dr[indexSupEmail] != DBNull.Value)
            {
                supplier.SupEmail = Convert.ToString(dr[indexSupEmail]);
            }
            int indexBank = dr.GetOrdinal("Bank");
            if (dr[indexBank] != DBNull.Value)
            {
                supplier.Bank = Convert.ToInt32(dr[indexBank]);
            }
            int indexBankAccount = dr.GetOrdinal("BankAccount");
            if (dr[indexBankAccount] != DBNull.Value)
            {
                supplier.BankAccount = Convert.ToString(dr[indexBankAccount]);
            }
            int indexServiceAmount = dr.GetOrdinal("ServiceAmount");
            if (dr[indexServiceAmount] != DBNull.Value)
            {
                supplier.ServiceAmount = Convert.ToString(dr[indexServiceAmount]);
            }
            int indexSupStatus = dr.GetOrdinal("SupStatus");
            if (dr[indexSupStatus] != DBNull.Value)
            {
                supplier.SupStatus = Convert.ToInt32(dr[indexSupStatus]);
            }
            int indexMemo = dr.GetOrdinal("Memo");
            if (dr[indexMemo] != DBNull.Value)
            {
                supplier.Memo = Convert.ToString(dr[indexMemo]);
            }
            int indexCreatorId = dr.GetOrdinal("CreatorId");
            if (dr[indexCreatorId] != DBNull.Value)
            {
                supplier.CreatorId = Convert.ToInt32(dr[indexCreatorId]);
            }
            int indexCreateTime = dr.GetOrdinal("CreateTime");
            if (dr[indexCreateTime] != DBNull.Value)
            {
                supplier.CreateTime = Convert.ToDateTime(dr[indexCreateTime]);
            }
            int indexLastModifyId = dr.GetOrdinal("LastModifyId");
            if (dr[indexLastModifyId] != DBNull.Value)
            {
                supplier.LastModifyId = Convert.ToInt32(dr[indexLastModifyId]);
            }
            int indexLastModifyTime = dr.GetOrdinal("LastModifyTime");
            if (dr[indexLastModifyTime] != DBNull.Value)
            {
                supplier.LastModifyTime = Convert.ToDateTime(dr[indexLastModifyTime]);
            }

            return supplier;
        }
        public override string TableName
        {
            get
            {
                return "Usr_Supplier";
            }
        }
    }
}
