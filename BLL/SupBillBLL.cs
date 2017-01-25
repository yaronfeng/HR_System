using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Model;
using HR.Common;
using System.Data.SqlClient;
using System.Data;


namespace HR.BLL
{
    public class SupBillBLL:Operate
    {
        public SupBillBLL()
        {

        }

        protected override List<SqlParameter> CreateInsertParameters(IModel obj, ref SqlParameter returnValue)
        {
            SupBill usr_supbill = (SupBill)obj;

            List<SqlParameter> paras = new List<SqlParameter>();
            returnValue.Direction = ParameterDirection.Output;
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.ParameterName = "@SupBillId";
            returnValue.Size = 4;
            paras.Add(returnValue);

            SqlParameter billdatepara = new SqlParameter("@BillDate", SqlDbType.DateTime, 8);
            billdatepara.Value = usr_supbill.BillDate;
            paras.Add(billdatepara);

            SqlParameter paydatepara = new SqlParameter("@PayDate", SqlDbType.DateTime, 8);
            paydatepara.Value = usr_supbill.PayDate;
            paras.Add(paydatepara);

            SqlParameter paycitypara = new SqlParameter("@PayCity", SqlDbType.Int, 4);
            paycitypara.Value = usr_supbill.PayCity;
            paras.Add(paycitypara);

            SqlParameter supidpara = new SqlParameter("@SupId", SqlDbType.Int, 4);
            supidpara.Value = usr_supbill.SupId;
            paras.Add(supidpara);

            SqlParameter billpensioninspara = new SqlParameter("@BillPensionIns", SqlDbType.Decimal, 9);
            billpensioninspara.Value = usr_supbill.BillPensionIns;
            paras.Add(billpensioninspara);

            SqlParameter billmedicalinspara = new SqlParameter("@BillMedicalIns", SqlDbType.Decimal, 9);
            billmedicalinspara.Value = usr_supbill.BillMedicalIns;
            paras.Add(billmedicalinspara);

            SqlParameter billunempinspara = new SqlParameter("@BillUnempIns", SqlDbType.Decimal, 9);
            billunempinspara.Value = usr_supbill.BillUnempIns;
            paras.Add(billunempinspara);

            SqlParameter billinjuryinspara = new SqlParameter("@BillInjuryIns", SqlDbType.Decimal, 9);
            billinjuryinspara.Value = usr_supbill.BillInjuryIns;
            paras.Add(billinjuryinspara);

            SqlParameter billbirthinspara = new SqlParameter("@BillBirthIns", SqlDbType.Decimal, 9);
            billbirthinspara.Value = usr_supbill.BillBirthIns;
            paras.Add(billbirthinspara);

            SqlParameter billdisabledinspara = new SqlParameter("@BillDisabledIns", SqlDbType.Decimal, 9);
            billdisabledinspara.Value = usr_supbill.BillDisabledIns;
            paras.Add(billdisabledinspara);

            SqlParameter billillnessinspara = new SqlParameter("@BillIllnessIns", SqlDbType.Decimal, 9);
            billillnessinspara.Value = usr_supbill.BillIllnessIns;
            paras.Add(billillnessinspara);

            SqlParameter billheatamountpara = new SqlParameter("@BillHeatAmount", SqlDbType.Decimal, 9);
            billheatamountpara.Value = usr_supbill.BillHeatAmount;
            paras.Add(billheatamountpara);

            SqlParameter billhousefundpara = new SqlParameter("@BillHouseFund", SqlDbType.Decimal, 9);
            billhousefundpara.Value = usr_supbill.BillHouseFund;
            paras.Add(billhousefundpara);

            SqlParameter billrepinjuryinspara = new SqlParameter("@BillRepInjuryIns", SqlDbType.Decimal, 9);
            billrepinjuryinspara.Value = usr_supbill.BillRepInjuryIns;
            paras.Add(billrepinjuryinspara);

            SqlParameter corpotherpaypara = new SqlParameter("@CorpOtherPay", SqlDbType.Decimal, 9);
            corpotherpaypara.Value = usr_supbill.CorpOtherPay;
            paras.Add(corpotherpaypara);

            SqlParameter empotherpaypara = new SqlParameter("@EmpOtherPay", SqlDbType.Decimal, 9);
            empotherpaypara.Value = usr_supbill.EmpOtherPay;
            paras.Add(empotherpaypara);

            SqlParameter serviceamountpara = new SqlParameter("@ServiceAmount", SqlDbType.Decimal, 9);
            serviceamountpara.Value = usr_supbill.ServiceAmount;
            paras.Add(serviceamountpara);

            SqlParameter totalamountpara = new SqlParameter("@TotalAmount", SqlDbType.Decimal, 9);
            totalamountpara.Value = usr_supbill.TotalAmount;
            paras.Add(totalamountpara);

            if (!string.IsNullOrEmpty(usr_supbill.Memo))
            {
                SqlParameter memopara = new SqlParameter("@Memo", SqlDbType.VarChar, 50);
                memopara.Value = usr_supbill.Memo;
                paras.Add(memopara);
            }

            SqlParameter corpbillstatuspara = new SqlParameter("@CorpBillStatus", SqlDbType.Int, 4);
            corpbillstatuspara.Value = usr_supbill.CorpBillStatus;
            paras.Add(corpbillstatuspara);

            SqlParameter creatoridpara = new SqlParameter("@CreatorId", SqlDbType.Int, 4);
            creatoridpara.Value = obj.CreatorId;
            paras.Add(creatoridpara);


            return paras;
        }

        protected override IModel CreateModel(SqlDataReader dr)
        {
            SupBill supbill = new SupBill();

            int indexSupBillId = dr.GetOrdinal("SupBillId");
            supbill.SupBillId = Convert.ToInt32(dr[indexSupBillId]);
            int indexBillDate = dr.GetOrdinal("BillDate");
            if (dr[indexBillDate] != DBNull.Value)
            {
                supbill.BillDate = Convert.ToDateTime(dr[indexBillDate]);
            }
            int indexPayDate = dr.GetOrdinal("PayDate");
            if (dr[indexPayDate] != DBNull.Value)
            {
                supbill.PayDate = Convert.ToDateTime(dr[indexPayDate]);
            }
            int indexPayCity = dr.GetOrdinal("PayCity");
            if (dr[indexPayCity] != DBNull.Value)
            {
                supbill.PayCity = Convert.ToInt32(dr[indexPayCity]);
            }
            int indexSupId = dr.GetOrdinal("SupId");
            if (dr[indexSupId] != DBNull.Value)
            {
                supbill.SupId = Convert.ToInt32(dr[indexSupId]);
            }
            int indexBillPensionIns = dr.GetOrdinal("BillPensionIns");
            if (dr[indexBillPensionIns] != DBNull.Value)
            {
                supbill.BillPensionIns = Convert.ToDecimal(dr[indexBillPensionIns]);
            }
            int indexBillMedicalIns = dr.GetOrdinal("BillMedicalIns");
            if (dr[indexBillMedicalIns] != DBNull.Value)
            {
                supbill.BillMedicalIns = Convert.ToDecimal(dr[indexBillMedicalIns]);
            }
            int indexBillUnempIns = dr.GetOrdinal("BillUnempIns");
            if (dr[indexBillUnempIns] != DBNull.Value)
            {
                supbill.BillUnempIns = Convert.ToDecimal(dr[indexBillUnempIns]);
            }
            int indexBillInjuryIns = dr.GetOrdinal("BillInjuryIns");
            if (dr[indexBillInjuryIns] != DBNull.Value)
            {
                supbill.BillInjuryIns = Convert.ToDecimal(dr[indexBillInjuryIns]);
            }
            int indexBillBirthIns = dr.GetOrdinal("BillBirthIns");
            if (dr[indexBillBirthIns] != DBNull.Value)
            {
                supbill.BillBirthIns = Convert.ToDecimal(dr[indexBillBirthIns]);
            }
            int indexBillDisabledIns = dr.GetOrdinal("BillDisabledIns");
            if (dr[indexBillDisabledIns] != DBNull.Value)
            {
                supbill.BillDisabledIns = Convert.ToDecimal(dr[indexBillDisabledIns]);
            }
            int indexBillIllnessIns = dr.GetOrdinal("BillIllnessIns");
            if (dr[indexBillIllnessIns] != DBNull.Value)
            {
                supbill.BillIllnessIns = Convert.ToDecimal(dr[indexBillIllnessIns]);
            }
            int indexBillHeatAmount = dr.GetOrdinal("BillHeatAmount");
            if (dr[indexBillHeatAmount] != DBNull.Value)
            {
                supbill.BillHeatAmount = Convert.ToDecimal(dr[indexBillHeatAmount]);
            }
            int indexBillHouseFund = dr.GetOrdinal("BillHouseFund");
            if (dr[indexBillHouseFund] != DBNull.Value)
            {
                supbill.BillHouseFund = Convert.ToDecimal(dr[indexBillHouseFund]);
            }
            int indexBillRepInjuryIns = dr.GetOrdinal("BillRepInjuryIns");
            if (dr[indexBillRepInjuryIns] != DBNull.Value)
            {
                supbill.BillRepInjuryIns = Convert.ToDecimal(dr[indexBillRepInjuryIns]);
            }
            int indexCorpOtherPay = dr.GetOrdinal("CorpOtherPay");
            if (dr[indexCorpOtherPay] != DBNull.Value)
            {
                supbill.CorpOtherPay = Convert.ToDecimal(dr[indexCorpOtherPay]);
            }
            int indexEmpOtherPay = dr.GetOrdinal("EmpOtherPay");
            if (dr[indexEmpOtherPay] != DBNull.Value)
            {
                supbill.EmpOtherPay = Convert.ToDecimal(dr[indexEmpOtherPay]);
            }
            int indexServiceAmount = dr.GetOrdinal("ServiceAmount");
            if (dr[indexServiceAmount] != DBNull.Value)
            {
                supbill.ServiceAmount = Convert.ToDecimal(dr[indexServiceAmount]);
            }
            int indexTotalAmount = dr.GetOrdinal("TotalAmount");
            if (dr[indexTotalAmount] != DBNull.Value)
            {
                supbill.TotalAmount = Convert.ToDecimal(dr[indexTotalAmount]);
            }
            int indexMemo = dr.GetOrdinal("Memo");
            if (dr[indexMemo] != DBNull.Value)
            {
                supbill.Memo = Convert.ToString(dr[indexMemo]);
            }
            int indexCorpBillStatus = dr.GetOrdinal("CorpBillStatus");
            if (dr[indexCorpBillStatus] != DBNull.Value)
            {
                supbill.CorpBillStatus = Convert.ToInt32(dr[indexCorpBillStatus]);
            }
            int indexCreatorId = dr.GetOrdinal("CreatorId");
            if (dr[indexCreatorId] != DBNull.Value)
            {
                supbill.CreatorId = Convert.ToInt32(dr[indexCreatorId]);
            }
            int indexCreateTime = dr.GetOrdinal("CreateTime");
            if (dr[indexCreateTime] != DBNull.Value)
            {
                supbill.CreateTime = Convert.ToDateTime(dr[indexCreateTime]);
            }
            int indexLastModifyId = dr.GetOrdinal("LastModifyId");
            if (dr[indexLastModifyId] != DBNull.Value)
            {
                supbill.LastModifyId = Convert.ToInt32(dr[indexLastModifyId]);
            }
            int indexLastModifyTime = dr.GetOrdinal("LastModifyTime");
            if (dr[indexLastModifyTime] != DBNull.Value)
            {
                supbill.LastModifyTime = Convert.ToDateTime(dr[indexLastModifyTime]);
            }

            return supbill;
        }

        public override string TableName
        {
            get
            {
                return "Usr_SupBill";
            }
        }

        public override List<SqlParameter> CreateUpdateParameters(IModel obj)
        {
            SupBill usr_supbill = (SupBill)obj;

            List<SqlParameter> paras = new List<SqlParameter>();

            SqlParameter supbillidpara = new SqlParameter("@SupBillId", SqlDbType.Int, 4);
            supbillidpara.Value = usr_supbill.SupBillId;
            paras.Add(supbillidpara);

            SqlParameter billdatepara = new SqlParameter("@BillDate", SqlDbType.DateTime, 8);
            billdatepara.Value = usr_supbill.BillDate;
            paras.Add(billdatepara);

            SqlParameter paydatepara = new SqlParameter("@PayDate", SqlDbType.DateTime, 8);
            paydatepara.Value = usr_supbill.PayDate;
            paras.Add(paydatepara);

            SqlParameter paycitypara = new SqlParameter("@PayCity", SqlDbType.Int, 4);
            paycitypara.Value = usr_supbill.PayCity;
            paras.Add(paycitypara);

            SqlParameter supidpara = new SqlParameter("@SupId", SqlDbType.Int, 4);
            supidpara.Value = usr_supbill.SupId;
            paras.Add(supidpara);

            SqlParameter billpensioninspara = new SqlParameter("@BillPensionIns", SqlDbType.Decimal, 9);
            billpensioninspara.Value = usr_supbill.BillPensionIns;
            paras.Add(billpensioninspara);

            SqlParameter billmedicalinspara = new SqlParameter("@BillMedicalIns", SqlDbType.Decimal, 9);
            billmedicalinspara.Value = usr_supbill.BillMedicalIns;
            paras.Add(billmedicalinspara);

            SqlParameter billunempinspara = new SqlParameter("@BillUnempIns", SqlDbType.Decimal, 9);
            billunempinspara.Value = usr_supbill.BillUnempIns;
            paras.Add(billunempinspara);

            SqlParameter billinjuryinspara = new SqlParameter("@BillInjuryIns", SqlDbType.Decimal, 9);
            billinjuryinspara.Value = usr_supbill.BillInjuryIns;
            paras.Add(billinjuryinspara);

            SqlParameter billbirthinspara = new SqlParameter("@BillBirthIns", SqlDbType.Decimal, 9);
            billbirthinspara.Value = usr_supbill.BillBirthIns;
            paras.Add(billbirthinspara);

            SqlParameter billdisabledinspara = new SqlParameter("@BillDisabledIns", SqlDbType.Decimal, 9);
            billdisabledinspara.Value = usr_supbill.BillDisabledIns;
            paras.Add(billdisabledinspara);

            SqlParameter billillnessinspara = new SqlParameter("@BillIllnessIns", SqlDbType.Decimal, 9);
            billillnessinspara.Value = usr_supbill.BillIllnessIns;
            paras.Add(billillnessinspara);

            SqlParameter billheatamountpara = new SqlParameter("@BillHeatAmount", SqlDbType.Decimal, 9);
            billheatamountpara.Value = usr_supbill.BillHeatAmount;
            paras.Add(billheatamountpara);

            SqlParameter billhousefundpara = new SqlParameter("@BillHouseFund", SqlDbType.Decimal, 9);
            billhousefundpara.Value = usr_supbill.BillHouseFund;
            paras.Add(billhousefundpara);

            SqlParameter billrepinjuryinspara = new SqlParameter("@BillRepInjuryIns", SqlDbType.Decimal, 9);
            billrepinjuryinspara.Value = usr_supbill.BillRepInjuryIns;
            paras.Add(billrepinjuryinspara);

            SqlParameter corpotherpaypara = new SqlParameter("@CorpOtherPay", SqlDbType.Decimal, 9);
            corpotherpaypara.Value = usr_supbill.CorpOtherPay;
            paras.Add(corpotherpaypara);

            SqlParameter empotherpaypara = new SqlParameter("@EmpOtherPay", SqlDbType.Decimal, 9);
            empotherpaypara.Value = usr_supbill.EmpOtherPay;
            paras.Add(empotherpaypara);

            SqlParameter serviceamountpara = new SqlParameter("@ServiceAmount", SqlDbType.Decimal, 9);
            serviceamountpara.Value = usr_supbill.ServiceAmount;
            paras.Add(serviceamountpara);

            SqlParameter totalamountpara = new SqlParameter("@TotalAmount", SqlDbType.Decimal, 9);
            totalamountpara.Value = usr_supbill.TotalAmount;
            paras.Add(totalamountpara);

            if (!string.IsNullOrEmpty(usr_supbill.Memo))
            {
                SqlParameter memopara = new SqlParameter("@Memo", SqlDbType.VarChar, 50);
                memopara.Value = usr_supbill.Memo;
                paras.Add(memopara);
            }

            SqlParameter corpbillstatuspara = new SqlParameter("@CorpBillStatus", SqlDbType.Int, 4);
            corpbillstatuspara.Value = usr_supbill.CorpBillStatus;
            paras.Add(corpbillstatuspara);

            SqlParameter lastmodifyidpara = new SqlParameter("@LastModifyId", SqlDbType.Int, 4);
            lastmodifyidpara.Value = obj.LastModifyId;
            paras.Add(lastmodifyidpara);


            return paras;
        }
    }
}
