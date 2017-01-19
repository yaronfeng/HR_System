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
    public class CorpBillBLL:Operate
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public CorpBillBLL()
        {
        }

        private CorpBillSQL sql_insrance = new CorpBillSQL();

        public ResultModel LoadCorpBillReadyList(int pageIndex, int pageSize, string orderStr)
        {
            SelectModel select = sql_insrance.CorpBillReadyList(pageIndex, pageSize, orderStr);
            ResultModel result = Load(select);

            return result;
        }

        public ResultModel LoadCorpEmployeeList(int pageIndex, int pageSize, string orderStr,int corpId)
        {
            SelectModel select = sql_insrance.EmployeeByCorpIdSelect(pageIndex, pageSize, orderStr, corpId);
            ResultModel result = Load(select);

            return result;
        }

        #endregion
        protected override List<SqlParameter> CreateInsertParameters(IModel obj, ref SqlParameter returnValue)
        {
            CorpBill usr_corpbill = (CorpBill)obj;

            List<SqlParameter> paras = new List<SqlParameter>();
            returnValue.Direction = ParameterDirection.Output;
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.ParameterName = "@CorpBillId";
            returnValue.Size = 4;
            paras.Add(returnValue);

            SqlParameter billdatepara = new SqlParameter("@BillDate", SqlDbType.DateTime, 8);
            billdatepara.Value = usr_corpbill.BillDate;
            paras.Add(billdatepara);

            SqlParameter paydatepara = new SqlParameter("@PayDate", SqlDbType.DateTime, 8);
            paydatepara.Value = usr_corpbill.PayDate;
            paras.Add(paydatepara);

            SqlParameter paycitypara = new SqlParameter("@PayCity", SqlDbType.Int, 4);
            paycitypara.Value = usr_corpbill.PayCity;
            paras.Add(paycitypara);

            SqlParameter corpidpara = new SqlParameter("@CorpId", SqlDbType.Int, 4);
            corpidpara.Value = usr_corpbill.CorpId;
            paras.Add(corpidpara);

            SqlParameter supidpara = new SqlParameter("@SupId", SqlDbType.Int, 4);
            supidpara.Value = usr_corpbill.SupId;
            paras.Add(supidpara);

            SqlParameter billpensioninspara = new SqlParameter("@BillPensionIns", SqlDbType.Decimal, 9);
            billpensioninspara.Value = usr_corpbill.BillPensionIns;
            paras.Add(billpensioninspara);

            SqlParameter billmedicalinspara = new SqlParameter("@BillMedicalIns", SqlDbType.Decimal, 9);
            billmedicalinspara.Value = usr_corpbill.BillMedicalIns;
            paras.Add(billmedicalinspara);

            SqlParameter billunempinspara = new SqlParameter("@BillUnempIns", SqlDbType.Decimal, 9);
            billunempinspara.Value = usr_corpbill.BillUnempIns;
            paras.Add(billunempinspara);

            SqlParameter billinjuryinspara = new SqlParameter("@BillInjuryIns", SqlDbType.Decimal, 9);
            billinjuryinspara.Value = usr_corpbill.BillInjuryIns;
            paras.Add(billinjuryinspara);

            SqlParameter billbirthinspara = new SqlParameter("@BillBirthIns", SqlDbType.Decimal, 9);
            billbirthinspara.Value = usr_corpbill.BillBirthIns;
            paras.Add(billbirthinspara);

            SqlParameter billdisabledinspara = new SqlParameter("@BillDisabledIns", SqlDbType.Decimal, 9);
            billdisabledinspara.Value = usr_corpbill.BillDisabledIns;
            paras.Add(billdisabledinspara);

            SqlParameter billillnessinspara = new SqlParameter("@BillIllnessIns", SqlDbType.Decimal, 9);
            billillnessinspara.Value = usr_corpbill.BillIllnessIns;
            paras.Add(billillnessinspara);

            SqlParameter billheatamountpara = new SqlParameter("@BillHeatAmount", SqlDbType.Decimal, 9);
            billheatamountpara.Value = usr_corpbill.BillHeatAmount;
            paras.Add(billheatamountpara);

            SqlParameter billhousefundpara = new SqlParameter("@BillHouseFund", SqlDbType.Decimal, 9);
            billhousefundpara.Value = usr_corpbill.BillHouseFund;
            paras.Add(billhousefundpara);

            SqlParameter billrepinjuryinspara = new SqlParameter("@BillRepInjuryIns", SqlDbType.Decimal, 9);
            billrepinjuryinspara.Value = usr_corpbill.BillRepInjuryIns;
            paras.Add(billrepinjuryinspara);

            SqlParameter corpotherpaypara = new SqlParameter("@CorpOtherPay", SqlDbType.Decimal, 9);
            corpotherpaypara.Value = usr_corpbill.CorpOtherPay;
            paras.Add(corpotherpaypara);

            SqlParameter empotherpaypara = new SqlParameter("@EmpOtherPay", SqlDbType.Decimal, 9);
            empotherpaypara.Value = usr_corpbill.EmpOtherPay;
            paras.Add(empotherpaypara);

            SqlParameter serviceamountpara = new SqlParameter("@ServiceAmount", SqlDbType.Decimal, 9);
            serviceamountpara.Value = usr_corpbill.ServiceAmount;
            paras.Add(serviceamountpara);

            SqlParameter totalamountpara = new SqlParameter("@TotalAmount", SqlDbType.Decimal, 9);
            totalamountpara.Value = usr_corpbill.TotalAmount;
            paras.Add(totalamountpara);

            if (!string.IsNullOrEmpty(usr_corpbill.Memo))
            {
                SqlParameter memopara = new SqlParameter("@Memo", SqlDbType.VarChar, 150);
                memopara.Value = usr_corpbill.Memo;
                paras.Add(memopara);
            }

            SqlParameter corpbillstatuspara = new SqlParameter("@CorpBillStatus", SqlDbType.Int, 4);
            corpbillstatuspara.Value = usr_corpbill.CorpBillStatus;
            paras.Add(corpbillstatuspara);

            SqlParameter creatoridpara = new SqlParameter("@CreatorId", SqlDbType.Int, 4);
            creatoridpara.Value = obj.CreatorId;
            paras.Add(creatoridpara);


            return paras;
        }

        protected override IModel CreateModel(SqlDataReader dr)
        {
            CorpBill corpbill = new CorpBill();

            int indexCorpBillId = dr.GetOrdinal("CorpBillId");
            corpbill.CorpBillId = Convert.ToInt32(dr[indexCorpBillId]);
            int indexBillDate = dr.GetOrdinal("BillDate");
            corpbill.BillDate = Convert.ToDateTime(dr[indexBillDate]);
            int indexPayDate = dr.GetOrdinal("PayDate");
            corpbill.PayDate = Convert.ToDateTime(dr[indexPayDate]);
            int indexPayCity = dr.GetOrdinal("PayCity");
            corpbill.PayCity = Convert.ToInt32(dr[indexPayCity]);
            int indexCorpId = dr.GetOrdinal("CorpId");
            corpbill.CorpId = Convert.ToInt32(dr[indexCorpId]);
            int indexSupId = dr.GetOrdinal("SupId");
            corpbill.SupId = Convert.ToInt32(dr[indexSupId]);
            int indexBillPensionIns = dr.GetOrdinal("BillPensionIns");
            if (dr[indexBillPensionIns] != DBNull.Value)
            {
                corpbill.BillPensionIns = Convert.ToDecimal(dr[indexBillPensionIns]);
            }
            int indexBillMedicalIns = dr.GetOrdinal("BillMedicalIns");
            if (dr[indexBillMedicalIns] != DBNull.Value)
            {
                corpbill.BillMedicalIns = Convert.ToDecimal(dr[indexBillMedicalIns]);
            }
            int indexBillUnempIns = dr.GetOrdinal("BillUnempIns");
            if (dr[indexBillUnempIns] != DBNull.Value)
            {
                corpbill.BillUnempIns = Convert.ToDecimal(dr[indexBillUnempIns]);
            }
            int indexBillInjuryIns = dr.GetOrdinal("BillInjuryIns");
            if (dr[indexBillInjuryIns] != DBNull.Value)
            {
                corpbill.BillInjuryIns = Convert.ToDecimal(dr[indexBillInjuryIns]);
            }
            int indexBillBirthIns = dr.GetOrdinal("BillBirthIns");
            if (dr[indexBillBirthIns] != DBNull.Value)
            {
                corpbill.BillBirthIns = Convert.ToDecimal(dr[indexBillBirthIns]);
            }
            int indexBillDisabledIns = dr.GetOrdinal("BillDisabledIns");
            if (dr[indexBillDisabledIns] != DBNull.Value)
            {
                corpbill.BillDisabledIns = Convert.ToDecimal(dr[indexBillDisabledIns]);
            }
            int indexBillIllnessIns = dr.GetOrdinal("BillIllnessIns");
            if (dr[indexBillIllnessIns] != DBNull.Value)
            {
                corpbill.BillIllnessIns = Convert.ToDecimal(dr[indexBillIllnessIns]);
            }
            int indexBillHeatAmount = dr.GetOrdinal("BillHeatAmount");
            if (dr[indexBillHeatAmount] != DBNull.Value)
            {
                corpbill.BillHeatAmount = Convert.ToDecimal(dr[indexBillHeatAmount]);
            }
            int indexBillHouseFund = dr.GetOrdinal("BillHouseFund");
            if (dr[indexBillHouseFund] != DBNull.Value)
            {
                corpbill.BillHouseFund = Convert.ToDecimal(dr[indexBillHouseFund]);
            }
            int indexBillRepInjuryIns = dr.GetOrdinal("BillRepInjuryIns");
            if (dr[indexBillRepInjuryIns] != DBNull.Value)
            {
                corpbill.BillRepInjuryIns = Convert.ToDecimal(dr[indexBillRepInjuryIns]);
            }
            int indexCorpOtherPay = dr.GetOrdinal("CorpOtherPay");
            if (dr[indexCorpOtherPay] != DBNull.Value)
            {
                corpbill.CorpOtherPay = Convert.ToDecimal(dr[indexCorpOtherPay]);
            }
            int indexEmpOtherPay = dr.GetOrdinal("EmpOtherPay");
            if (dr[indexEmpOtherPay] != DBNull.Value)
            {
                corpbill.EmpOtherPay = Convert.ToDecimal(dr[indexEmpOtherPay]);
            }
            int indexServiceAmount = dr.GetOrdinal("ServiceAmount");
            if (dr[indexServiceAmount] != DBNull.Value)
            {
                corpbill.ServiceAmount = Convert.ToDecimal(dr[indexServiceAmount]);
            }
            int indexTotalAmount = dr.GetOrdinal("TotalAmount");
            if (dr[indexTotalAmount] != DBNull.Value)
            {
                corpbill.TotalAmount = Convert.ToDecimal(dr[indexTotalAmount]);
            }
            int indexMemo = dr.GetOrdinal("Memo");
            if (dr[indexMemo] != DBNull.Value)
            {
                corpbill.Memo = Convert.ToString(dr[indexMemo]);
            }
            int indexCorpBillStatus = dr.GetOrdinal("CorpBillStatus");
            if (dr[indexCorpBillStatus] != DBNull.Value)
            {
                corpbill.CorpBillStatus = Convert.ToInt32(dr[indexCorpBillStatus]);
            }
            int indexCreatorId = dr.GetOrdinal("CreatorId");
            if (dr[indexCreatorId] != DBNull.Value)
            {
                corpbill.CreatorId = Convert.ToInt32(dr[indexCreatorId]);
            }
            int indexCreateTime = dr.GetOrdinal("CreateTime");
            if (dr[indexCreateTime] != DBNull.Value)
            {
                corpbill.CreateTime = Convert.ToDateTime(dr[indexCreateTime]);
            }
            int indexLastModifyId = dr.GetOrdinal("LastModifyId");
            if (dr[indexLastModifyId] != DBNull.Value)
            {
                corpbill.LastModifyId = Convert.ToInt32(dr[indexLastModifyId]);
            }
            int indexLastModifyTime = dr.GetOrdinal("LastModifyTime");
            if (dr[indexLastModifyTime] != DBNull.Value)
            {
                corpbill.LastModifyTime = Convert.ToDateTime(dr[indexLastModifyTime]);
            }

            return corpbill;
        }

        public override List<SqlParameter> CreateUpdateParameters(IModel obj)
        {
            CorpBill usr_corpbill = (CorpBill)obj;

            List<SqlParameter> paras = new List<SqlParameter>();

            SqlParameter corpbillidpara = new SqlParameter("@CorpBillId", SqlDbType.Int, 4);
            corpbillidpara.Value = usr_corpbill.CorpBillId;
            paras.Add(corpbillidpara);

            SqlParameter billdatepara = new SqlParameter("@BillDate", SqlDbType.DateTime, 8);
            billdatepara.Value = usr_corpbill.BillDate;
            paras.Add(billdatepara);

            SqlParameter paydatepara = new SqlParameter("@PayDate", SqlDbType.DateTime, 8);
            paydatepara.Value = usr_corpbill.PayDate;
            paras.Add(paydatepara);

            SqlParameter paycitypara = new SqlParameter("@PayCity", SqlDbType.Int, 4);
            paycitypara.Value = usr_corpbill.PayCity;
            paras.Add(paycitypara);

            SqlParameter corpidpara = new SqlParameter("@CorpId", SqlDbType.Int, 4);
            corpidpara.Value = usr_corpbill.CorpId;
            paras.Add(corpidpara);

            SqlParameter supidpara = new SqlParameter("@SupId", SqlDbType.Int, 4);
            supidpara.Value = usr_corpbill.SupId;
            paras.Add(supidpara);

            SqlParameter billpensioninspara = new SqlParameter("@BillPensionIns", SqlDbType.Decimal, 9);
            billpensioninspara.Value = usr_corpbill.BillPensionIns;
            paras.Add(billpensioninspara);

            SqlParameter billmedicalinspara = new SqlParameter("@BillMedicalIns", SqlDbType.Decimal, 9);
            billmedicalinspara.Value = usr_corpbill.BillMedicalIns;
            paras.Add(billmedicalinspara);

            SqlParameter billunempinspara = new SqlParameter("@BillUnempIns", SqlDbType.Decimal, 9);
            billunempinspara.Value = usr_corpbill.BillUnempIns;
            paras.Add(billunempinspara);

            SqlParameter billinjuryinspara = new SqlParameter("@BillInjuryIns", SqlDbType.Decimal, 9);
            billinjuryinspara.Value = usr_corpbill.BillInjuryIns;
            paras.Add(billinjuryinspara);

            SqlParameter billbirthinspara = new SqlParameter("@BillBirthIns", SqlDbType.Decimal, 9);
            billbirthinspara.Value = usr_corpbill.BillBirthIns;
            paras.Add(billbirthinspara);

            SqlParameter billdisabledinspara = new SqlParameter("@BillDisabledIns", SqlDbType.Decimal, 9);
            billdisabledinspara.Value = usr_corpbill.BillDisabledIns;
            paras.Add(billdisabledinspara);

            SqlParameter billillnessinspara = new SqlParameter("@BillIllnessIns", SqlDbType.Decimal, 9);
            billillnessinspara.Value = usr_corpbill.BillIllnessIns;
            paras.Add(billillnessinspara);

            SqlParameter billheatamountpara = new SqlParameter("@BillHeatAmount", SqlDbType.Decimal, 9);
            billheatamountpara.Value = usr_corpbill.BillHeatAmount;
            paras.Add(billheatamountpara);

            SqlParameter billhousefundpara = new SqlParameter("@BillHouseFund", SqlDbType.Decimal, 9);
            billhousefundpara.Value = usr_corpbill.BillHouseFund;
            paras.Add(billhousefundpara);

            SqlParameter billrepinjuryinspara = new SqlParameter("@BillRepInjuryIns", SqlDbType.Decimal, 9);
            billrepinjuryinspara.Value = usr_corpbill.BillRepInjuryIns;
            paras.Add(billrepinjuryinspara);

            SqlParameter corpotherpaypara = new SqlParameter("@CorpOtherPay", SqlDbType.Decimal, 9);
            corpotherpaypara.Value = usr_corpbill.CorpOtherPay;
            paras.Add(corpotherpaypara);

            SqlParameter empotherpaypara = new SqlParameter("@EmpOtherPay", SqlDbType.Decimal, 9);
            empotherpaypara.Value = usr_corpbill.EmpOtherPay;
            paras.Add(empotherpaypara);

            SqlParameter serviceamountpara = new SqlParameter("@ServiceAmount", SqlDbType.Decimal, 9);
            serviceamountpara.Value = usr_corpbill.ServiceAmount;
            paras.Add(serviceamountpara);

            SqlParameter totalamountpara = new SqlParameter("@TotalAmount", SqlDbType.Decimal, 9);
            totalamountpara.Value = usr_corpbill.TotalAmount;
            paras.Add(totalamountpara);

            if (!string.IsNullOrEmpty(usr_corpbill.Memo))
            {
                SqlParameter memopara = new SqlParameter("@Memo", SqlDbType.VarChar, 150);
                memopara.Value = usr_corpbill.Memo;
                paras.Add(memopara);
            }

            SqlParameter corpbillstatuspara = new SqlParameter("@CorpBillStatus", SqlDbType.Int, 4);
            corpbillstatuspara.Value = usr_corpbill.CorpBillStatus;
            paras.Add(corpbillstatuspara);

            SqlParameter lastmodifyidpara = new SqlParameter("@LastModifyId", SqlDbType.Int, 4);
            lastmodifyidpara.Value = obj.LastModifyId;
            paras.Add(lastmodifyidpara);


            return paras;
        }

        public override string TableName
        {
            get
            {
                return "Usr_CorpBill";
            }
        }
    }
}
