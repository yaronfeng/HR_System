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
    public class EmployeeSalaryBLL : Operate
    {
        private EmployeeSalarySQL sql_insrance = new EmployeeSalarySQL();
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public EmployeeSalaryBLL()
        {
        }
        #endregion

        protected override List<SqlParameter> CreateInsertParameters(IModel obj, ref SqlParameter returnValue)
        {
            EmployeeSalary usr_employeesalary = (EmployeeSalary)obj;

            List<SqlParameter> paras = new List<SqlParameter>();
            returnValue.Direction = ParameterDirection.Output;
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.ParameterName = "@EmpSalaryId";
            returnValue.Size = 4;
            paras.Add(returnValue);

            SqlParameter empidpara = new SqlParameter("@EmpId", SqlDbType.Int, 4);
            empidpara.Value = usr_employeesalary.EmpId;
            paras.Add(empidpara);

            SqlParameter paycitypara = new SqlParameter("@PayCity", SqlDbType.Int, 4);
            paycitypara.Value = usr_employeesalary.PayCity;
            paras.Add(paycitypara);

            SqlParameter corpidpara = new SqlParameter("@CorpId", SqlDbType.Int, 4);
            corpidpara.Value = usr_employeesalary.CorpId;
            paras.Add(corpidpara);

            SqlParameter supidpara = new SqlParameter("@SupId", SqlDbType.Int, 4);
            supidpara.Value = usr_employeesalary.SupId;
            paras.Add(supidpara);

            SqlParameter corppensioninspara = new SqlParameter("@CorpPensionIns", SqlDbType.Decimal, 9);
            corppensioninspara.Value = usr_employeesalary.CorpPensionIns;
            paras.Add(corppensioninspara);

            SqlParameter corpmedicalinspara = new SqlParameter("@CorpMedicalIns", SqlDbType.Decimal, 9);
            corpmedicalinspara.Value = usr_employeesalary.CorpMedicalIns;
            paras.Add(corpmedicalinspara);

            SqlParameter corpunempinspara = new SqlParameter("@CorpUnempIns", SqlDbType.Decimal, 9);
            corpunempinspara.Value = usr_employeesalary.CorpUnempIns;
            paras.Add(corpunempinspara);

            SqlParameter corpinjuryinspara = new SqlParameter("@CorpInjuryIns", SqlDbType.Decimal, 9);
            corpinjuryinspara.Value = usr_employeesalary.CorpInjuryIns;
            paras.Add(corpinjuryinspara);

            SqlParameter corpbirthinspara = new SqlParameter("@CorpBirthIns", SqlDbType.Decimal, 9);
            corpbirthinspara.Value = usr_employeesalary.CorpBirthIns;
            paras.Add(corpbirthinspara);

            SqlParameter corpdisabledinspara = new SqlParameter("@CorpDisabledIns", SqlDbType.Decimal, 9);
            corpdisabledinspara.Value = usr_employeesalary.CorpDisabledIns;
            paras.Add(corpdisabledinspara);

            SqlParameter corpillnessinspara = new SqlParameter("@CorpIllnessIns", SqlDbType.Decimal, 9);
            corpillnessinspara.Value = usr_employeesalary.CorpIllnessIns;
            paras.Add(corpillnessinspara);

            SqlParameter corpheatamountpara = new SqlParameter("@CorpHeatAmount", SqlDbType.Decimal, 9);
            corpheatamountpara.Value = usr_employeesalary.CorpHeatAmount;
            paras.Add(corpheatamountpara);

            SqlParameter corphousefundpara = new SqlParameter("@CorpHouseFund", SqlDbType.Decimal, 9);
            corphousefundpara.Value = usr_employeesalary.CorpHouseFund;
            paras.Add(corphousefundpara);

            SqlParameter corprepinjuryinspara = new SqlParameter("@CorpRepInjuryIns", SqlDbType.Decimal, 9);
            corprepinjuryinspara.Value = usr_employeesalary.CorpRepInjuryIns;
            paras.Add(corprepinjuryinspara);

            SqlParameter corptotalpara = new SqlParameter("@CorpTotal", SqlDbType.Decimal, 9);
            corptotalpara.Value = usr_employeesalary.CorpTotal;
            paras.Add(corptotalpara);

            SqlParameter emppensioninspara = new SqlParameter("@EmpPensionIns", SqlDbType.Decimal, 9);
            emppensioninspara.Value = usr_employeesalary.EmpPensionIns;
            paras.Add(emppensioninspara);

            SqlParameter empmedicalinspara = new SqlParameter("@EmpMedicalIns", SqlDbType.Decimal, 9);
            empmedicalinspara.Value = usr_employeesalary.EmpMedicalIns;
            paras.Add(empmedicalinspara);

            SqlParameter empunempinspara = new SqlParameter("@EmpUnempIns", SqlDbType.Decimal, 9);
            empunempinspara.Value = usr_employeesalary.EmpUnempIns;
            paras.Add(empunempinspara);

            SqlParameter empinjuryinspara = new SqlParameter("@EmpInjuryIns", SqlDbType.Decimal, 9);
            empinjuryinspara.Value = usr_employeesalary.EmpInjuryIns;
            paras.Add(empinjuryinspara);

            SqlParameter empbirthinspara = new SqlParameter("@EmpBirthIns", SqlDbType.Decimal, 9);
            empbirthinspara.Value = usr_employeesalary.EmpBirthIns;
            paras.Add(empbirthinspara);

            SqlParameter empdisabledinspara = new SqlParameter("@EmpDisabledIns", SqlDbType.Decimal, 9);
            empdisabledinspara.Value = usr_employeesalary.EmpDisabledIns;
            paras.Add(empdisabledinspara);

            SqlParameter empillnessinspara = new SqlParameter("@EmpIllnessIns", SqlDbType.Decimal, 9);
            empillnessinspara.Value = usr_employeesalary.EmpIllnessIns;
            paras.Add(empillnessinspara);

            SqlParameter empheatamountpara = new SqlParameter("@EmpHeatAmount", SqlDbType.Decimal, 9);
            empheatamountpara.Value = usr_employeesalary.EmpHeatAmount;
            paras.Add(empheatamountpara);

            SqlParameter emphousefundpara = new SqlParameter("@EmpHouseFund", SqlDbType.Decimal, 9);
            emphousefundpara.Value = usr_employeesalary.EmpHouseFund;
            paras.Add(emphousefundpara);

            SqlParameter emprepinjuryinspara = new SqlParameter("@EmpRepInjuryIns", SqlDbType.Decimal, 9);
            emprepinjuryinspara.Value = usr_employeesalary.EmpRepInjuryIns;
            paras.Add(emprepinjuryinspara);

            SqlParameter emptotalpara = new SqlParameter("@EmpTotal", SqlDbType.Decimal, 9);
            emptotalpara.Value = usr_employeesalary.EmpTotal;
            paras.Add(emptotalpara);

            SqlParameter personaltaxpara = new SqlParameter("@PersonalTax", SqlDbType.Decimal, 9);
            personaltaxpara.Value = usr_employeesalary.PersonalTax;
            paras.Add(personaltaxpara);

            SqlParameter totalamountpara = new SqlParameter("@TotalAmount", SqlDbType.Decimal, 9);
            totalamountpara.Value = usr_employeesalary.TotalAmount;
            paras.Add(totalamountpara);

            SqlParameter repairamountpara = new SqlParameter("@RepairAmount", SqlDbType.Decimal, 9);
            repairamountpara.Value = usr_employeesalary.RepairAmount;
            paras.Add(repairamountpara);

            SqlParameter grossamountpara = new SqlParameter("@GrossAmount", SqlDbType.Decimal, 9);
            grossamountpara.Value = usr_employeesalary.GrossAmount;
            paras.Add(grossamountpara);

            SqlParameter finalamountpara = new SqlParameter("@FinalAmount", SqlDbType.Decimal, 9);
            finalamountpara.Value = usr_employeesalary.FinalAmount;
            paras.Add(finalamountpara);

            SqlParameter serviceamountpara = new SqlParameter("@ServiceAmount", SqlDbType.Decimal, 9);
            serviceamountpara.Value = usr_employeesalary.ServiceAmount;
            paras.Add(serviceamountpara);

            SqlParameter refundamountpara = new SqlParameter("@RefundAmount", SqlDbType.Decimal, 9);
            refundamountpara.Value = usr_employeesalary.RefundAmount;
            paras.Add(refundamountpara);

            SqlParameter paydatepara = new SqlParameter("@PayDate", SqlDbType.DateTime, 8);
            paydatepara.Value = usr_employeesalary.PayDate;
            paras.Add(paydatepara);

            SqlParameter empsalarystatuspara = new SqlParameter("@EmpSalaryStatus", SqlDbType.Int, 4);
            empsalarystatuspara.Value = usr_employeesalary.EmpSalaryStatus;
            paras.Add(empsalarystatuspara);

            if (!string.IsNullOrEmpty(usr_employeesalary.Memo))
            {
                SqlParameter memopara = new SqlParameter("@Memo", SqlDbType.VarChar, 150);
                memopara.Value = usr_employeesalary.Memo;
                paras.Add(memopara);
            }

            SqlParameter creatoridpara = new SqlParameter("@CreatorId", SqlDbType.Int, 4);
            creatoridpara.Value = obj.CreatorId;
            paras.Add(creatoridpara);


            return paras;
        }
        
        protected override IModel CreateModel(SqlDataReader dr)
        {
            EmployeeSalary employeesalary = new EmployeeSalary();

            int indexEmpSalaryId = dr.GetOrdinal("EmpSalaryId");
            employeesalary.EmpSalaryId = Convert.ToInt32(dr[indexEmpSalaryId]);
            int indexEmpId = dr.GetOrdinal("EmpId");
            if (dr[indexEmpId] != DBNull.Value)
            {
                employeesalary.EmpId = Convert.ToInt32(dr[indexEmpId]);
            }
            int indexPayCity = dr.GetOrdinal("PayCity");
            if (dr[indexPayCity] != DBNull.Value)
            {
                employeesalary.PayCity = Convert.ToInt32(dr[indexPayCity]);
            }
            int indexCorpId = dr.GetOrdinal("CorpId");
            if (dr[indexCorpId] != DBNull.Value)
            {
                employeesalary.CorpId = Convert.ToInt32(dr[indexCorpId]);
            }
            int indexSupId = dr.GetOrdinal("SupId");
            if (dr[indexSupId] != DBNull.Value)
            {
                employeesalary.SupId = Convert.ToInt32(dr[indexSupId]);
            }
            int indexCorpPensionIns = dr.GetOrdinal("CorpPensionIns");
            if (dr[indexCorpPensionIns] != DBNull.Value)
            {
                employeesalary.CorpPensionIns = Convert.ToDecimal(dr[indexCorpPensionIns]);
            }
            int indexCorpMedicalIns = dr.GetOrdinal("CorpMedicalIns");
            if (dr[indexCorpMedicalIns] != DBNull.Value)
            {
                employeesalary.CorpMedicalIns = Convert.ToDecimal(dr[indexCorpMedicalIns]);
            }
            int indexCorpUnempIns = dr.GetOrdinal("CorpUnempIns");
            if (dr[indexCorpUnempIns] != DBNull.Value)
            {
                employeesalary.CorpUnempIns = Convert.ToDecimal(dr[indexCorpUnempIns]);
            }
            int indexCorpInjuryIns = dr.GetOrdinal("CorpInjuryIns");
            if (dr[indexCorpInjuryIns] != DBNull.Value)
            {
                employeesalary.CorpInjuryIns = Convert.ToDecimal(dr[indexCorpInjuryIns]);
            }
            int indexCorpBirthIns = dr.GetOrdinal("CorpBirthIns");
            if (dr[indexCorpBirthIns] != DBNull.Value)
            {
                employeesalary.CorpBirthIns = Convert.ToDecimal(dr[indexCorpBirthIns]);
            }
            int indexCorpDisabledIns = dr.GetOrdinal("CorpDisabledIns");
            if (dr[indexCorpDisabledIns] != DBNull.Value)
            {
                employeesalary.CorpDisabledIns = Convert.ToDecimal(dr[indexCorpDisabledIns]);
            }
            int indexCorpIllnessIns = dr.GetOrdinal("CorpIllnessIns");
            if (dr[indexCorpIllnessIns] != DBNull.Value)
            {
                employeesalary.CorpIllnessIns = Convert.ToDecimal(dr[indexCorpIllnessIns]);
            }
            int indexCorpHeatAmount = dr.GetOrdinal("CorpHeatAmount");
            if (dr[indexCorpHeatAmount] != DBNull.Value)
            {
                employeesalary.CorpHeatAmount = Convert.ToDecimal(dr[indexCorpHeatAmount]);
            }
            int indexCorpHouseFund = dr.GetOrdinal("CorpHouseFund");
            if (dr[indexCorpHouseFund] != DBNull.Value)
            {
                employeesalary.CorpHouseFund = Convert.ToDecimal(dr[indexCorpHouseFund]);
            }
            int indexCorpRepInjuryIns = dr.GetOrdinal("CorpRepInjuryIns");
            if (dr[indexCorpRepInjuryIns] != DBNull.Value)
            {
                employeesalary.CorpRepInjuryIns = Convert.ToDecimal(dr[indexCorpRepInjuryIns]);
            }
            int indexCorpTotal = dr.GetOrdinal("CorpTotal");
            if (dr[indexCorpTotal] != DBNull.Value)
            {
                employeesalary.CorpTotal = Convert.ToDecimal(dr[indexCorpTotal]);
            }
            int indexEmpPensionIns = dr.GetOrdinal("EmpPensionIns");
            if (dr[indexEmpPensionIns] != DBNull.Value)
            {
                employeesalary.EmpPensionIns = Convert.ToDecimal(dr[indexEmpPensionIns]);
            }
            int indexEmpMedicalIns = dr.GetOrdinal("EmpMedicalIns");
            if (dr[indexEmpMedicalIns] != DBNull.Value)
            {
                employeesalary.EmpMedicalIns = Convert.ToDecimal(dr[indexEmpMedicalIns]);
            }
            int indexEmpUnempIns = dr.GetOrdinal("EmpUnempIns");
            if (dr[indexEmpUnempIns] != DBNull.Value)
            {
                employeesalary.EmpUnempIns = Convert.ToDecimal(dr[indexEmpUnempIns]);
            }
            int indexEmpInjuryIns = dr.GetOrdinal("EmpInjuryIns");
            if (dr[indexEmpInjuryIns] != DBNull.Value)
            {
                employeesalary.EmpInjuryIns = Convert.ToDecimal(dr[indexEmpInjuryIns]);
            }
            int indexEmpBirthIns = dr.GetOrdinal("EmpBirthIns");
            if (dr[indexEmpBirthIns] != DBNull.Value)
            {
                employeesalary.EmpBirthIns = Convert.ToDecimal(dr[indexEmpBirthIns]);
            }
            int indexEmpDisabledIns = dr.GetOrdinal("EmpDisabledIns");
            if (dr[indexEmpDisabledIns] != DBNull.Value)
            {
                employeesalary.EmpDisabledIns = Convert.ToDecimal(dr[indexEmpDisabledIns]);
            }
            int indexEmpIllnessIns = dr.GetOrdinal("EmpIllnessIns");
            if (dr[indexEmpIllnessIns] != DBNull.Value)
            {
                employeesalary.EmpIllnessIns = Convert.ToDecimal(dr[indexEmpIllnessIns]);
            }
            int indexEmpHeatAmount = dr.GetOrdinal("EmpHeatAmount");
            if (dr[indexEmpHeatAmount] != DBNull.Value)
            {
                employeesalary.EmpHeatAmount = Convert.ToDecimal(dr[indexEmpHeatAmount]);
            }
            int indexEmpHouseFund = dr.GetOrdinal("EmpHouseFund");
            if (dr[indexEmpHouseFund] != DBNull.Value)
            {
                employeesalary.EmpHouseFund = Convert.ToDecimal(dr[indexEmpHouseFund]);
            }
            int indexEmpRepInjuryIns = dr.GetOrdinal("EmpRepInjuryIns");
            if (dr[indexEmpRepInjuryIns] != DBNull.Value)
            {
                employeesalary.EmpRepInjuryIns = Convert.ToDecimal(dr[indexEmpRepInjuryIns]);
            }
            int indexEmpTotal = dr.GetOrdinal("EmpTotal");
            if (dr[indexEmpTotal] != DBNull.Value)
            {
                employeesalary.EmpTotal = Convert.ToDecimal(dr[indexEmpTotal]);
            }
            int indexPersonalTax = dr.GetOrdinal("PersonalTax");
            if (dr[indexPersonalTax] != DBNull.Value)
            {
                employeesalary.PersonalTax = Convert.ToDecimal(dr[indexPersonalTax]);
            }
            int indexTotalAmount = dr.GetOrdinal("TotalAmount");
            if (dr[indexTotalAmount] != DBNull.Value)
            {
                employeesalary.TotalAmount = Convert.ToDecimal(dr[indexTotalAmount]);
            }
            int indexRepairAmount = dr.GetOrdinal("RepairAmount");
            if (dr[indexRepairAmount] != DBNull.Value)
            {
                employeesalary.RepairAmount = Convert.ToDecimal(dr[indexRepairAmount]);
            }
            int indexGrossAmount = dr.GetOrdinal("GrossAmount");
            if (dr[indexGrossAmount] != DBNull.Value)
            {
                employeesalary.GrossAmount = Convert.ToDecimal(dr[indexGrossAmount]);
            }
            int indexFinalAmount = dr.GetOrdinal("FinalAmount");
            if (dr[indexFinalAmount] != DBNull.Value)
            {
                employeesalary.FinalAmount = Convert.ToDecimal(dr[indexFinalAmount]);
            }
            int indexServiceAmount = dr.GetOrdinal("ServiceAmount");
            if (dr[indexServiceAmount] != DBNull.Value)
            {
                employeesalary.ServiceAmount = Convert.ToDecimal(dr[indexServiceAmount]);
            }
            int indexRefundAmount = dr.GetOrdinal("RefundAmount");
            if (dr[indexRefundAmount] != DBNull.Value)
            {
                employeesalary.RefundAmount = Convert.ToDecimal(dr[indexRefundAmount]);
            }
            int indexPayDate = dr.GetOrdinal("PayDate");
            if (dr[indexPayDate] != DBNull.Value)
            {
                employeesalary.PayDate = Convert.ToDateTime(dr[indexPayDate]);
            }
            int indexEmpSalaryStatus = dr.GetOrdinal("EmpSalaryStatus");
            if (dr[indexEmpSalaryStatus] != DBNull.Value)
            {
                employeesalary.EmpSalaryStatus = Convert.ToInt32(dr[indexEmpSalaryStatus]);
            }
            int indexMemo = dr.GetOrdinal("Memo");
            if (dr[indexMemo] != DBNull.Value)
            {
                employeesalary.Memo = Convert.ToString(dr[indexMemo]);
            }
            int indexCreatorId = dr.GetOrdinal("CreatorId");
            if (dr[indexCreatorId] != DBNull.Value)
            {
                employeesalary.CreatorId = Convert.ToInt32(dr[indexCreatorId]);
            }
            int indexCreateTime = dr.GetOrdinal("CreateTime");
            if (dr[indexCreateTime] != DBNull.Value)
            {
                employeesalary.CreateTime = Convert.ToDateTime(dr[indexCreateTime]);
            }
            int indexLastModifyId = dr.GetOrdinal("LastModifyId");
            if (dr[indexLastModifyId] != DBNull.Value)
            {
                employeesalary.LastModifyId = Convert.ToInt32(dr[indexLastModifyId]);
            }
            int indexLastModifyTime = dr.GetOrdinal("LastModifyTime");
            if (dr[indexLastModifyTime] != DBNull.Value)
            {
                employeesalary.LastModifyTime = Convert.ToDateTime(dr[indexLastModifyTime]);
            }

            return employeesalary;
        }

        public override List<SqlParameter> CreateUpdateParameters(IModel obj)
        {
            EmployeeSalary usr_employeesalary = (EmployeeSalary)obj;

            List<SqlParameter> paras = new List<SqlParameter>();

            SqlParameter empsalaryidpara = new SqlParameter("@EmpSalaryId", SqlDbType.Int, 4);
            empsalaryidpara.Value = usr_employeesalary.EmpSalaryId;
            paras.Add(empsalaryidpara);

            SqlParameter empidpara = new SqlParameter("@EmpId", SqlDbType.Int, 4);
            empidpara.Value = usr_employeesalary.EmpId;
            paras.Add(empidpara);

            SqlParameter paycitypara = new SqlParameter("@PayCity", SqlDbType.Int, 4);
            paycitypara.Value = usr_employeesalary.PayCity;
            paras.Add(paycitypara);

            SqlParameter corpidpara = new SqlParameter("@CorpId", SqlDbType.Int, 4);
            corpidpara.Value = usr_employeesalary.CorpId;
            paras.Add(corpidpara);

            SqlParameter supidpara = new SqlParameter("@SupId", SqlDbType.Int, 4);
            supidpara.Value = usr_employeesalary.SupId;
            paras.Add(supidpara);

            SqlParameter corppensioninspara = new SqlParameter("@CorpPensionIns", SqlDbType.Decimal, 9);
            corppensioninspara.Value = usr_employeesalary.CorpPensionIns;
            paras.Add(corppensioninspara);

            SqlParameter corpmedicalinspara = new SqlParameter("@CorpMedicalIns", SqlDbType.Decimal, 9);
            corpmedicalinspara.Value = usr_employeesalary.CorpMedicalIns;
            paras.Add(corpmedicalinspara);

            SqlParameter corpunempinspara = new SqlParameter("@CorpUnempIns", SqlDbType.Decimal, 9);
            corpunempinspara.Value = usr_employeesalary.CorpUnempIns;
            paras.Add(corpunempinspara);

            SqlParameter corpinjuryinspara = new SqlParameter("@CorpInjuryIns", SqlDbType.Decimal, 9);
            corpinjuryinspara.Value = usr_employeesalary.CorpInjuryIns;
            paras.Add(corpinjuryinspara);

            SqlParameter corpbirthinspara = new SqlParameter("@CorpBirthIns", SqlDbType.Decimal, 9);
            corpbirthinspara.Value = usr_employeesalary.CorpBirthIns;
            paras.Add(corpbirthinspara);

            SqlParameter corpdisabledinspara = new SqlParameter("@CorpDisabledIns", SqlDbType.Decimal, 9);
            corpdisabledinspara.Value = usr_employeesalary.CorpDisabledIns;
            paras.Add(corpdisabledinspara);

            SqlParameter corpillnessinspara = new SqlParameter("@CorpIllnessIns", SqlDbType.Decimal, 9);
            corpillnessinspara.Value = usr_employeesalary.CorpIllnessIns;
            paras.Add(corpillnessinspara);

            SqlParameter corpheatamountpara = new SqlParameter("@CorpHeatAmount", SqlDbType.Decimal, 9);
            corpheatamountpara.Value = usr_employeesalary.CorpHeatAmount;
            paras.Add(corpheatamountpara);

            SqlParameter corphousefundpara = new SqlParameter("@CorpHouseFund", SqlDbType.Decimal, 9);
            corphousefundpara.Value = usr_employeesalary.CorpHouseFund;
            paras.Add(corphousefundpara);

            SqlParameter corprepinjuryinspara = new SqlParameter("@CorpRepInjuryIns", SqlDbType.Decimal, 9);
            corprepinjuryinspara.Value = usr_employeesalary.CorpRepInjuryIns;
            paras.Add(corprepinjuryinspara);

            SqlParameter corptotalpara = new SqlParameter("@CorpTotal", SqlDbType.Decimal, 9);
            corptotalpara.Value = usr_employeesalary.CorpTotal;
            paras.Add(corptotalpara);

            SqlParameter emppensioninspara = new SqlParameter("@EmpPensionIns", SqlDbType.Decimal, 9);
            emppensioninspara.Value = usr_employeesalary.EmpPensionIns;
            paras.Add(emppensioninspara);

            SqlParameter empmedicalinspara = new SqlParameter("@EmpMedicalIns", SqlDbType.Decimal, 9);
            empmedicalinspara.Value = usr_employeesalary.EmpMedicalIns;
            paras.Add(empmedicalinspara);

            SqlParameter empunempinspara = new SqlParameter("@EmpUnempIns", SqlDbType.Decimal, 9);
            empunempinspara.Value = usr_employeesalary.EmpUnempIns;
            paras.Add(empunempinspara);

            SqlParameter empinjuryinspara = new SqlParameter("@EmpInjuryIns", SqlDbType.Decimal, 9);
            empinjuryinspara.Value = usr_employeesalary.EmpInjuryIns;
            paras.Add(empinjuryinspara);

            SqlParameter empbirthinspara = new SqlParameter("@EmpBirthIns", SqlDbType.Decimal, 9);
            empbirthinspara.Value = usr_employeesalary.EmpBirthIns;
            paras.Add(empbirthinspara);

            SqlParameter empdisabledinspara = new SqlParameter("@EmpDisabledIns", SqlDbType.Decimal, 9);
            empdisabledinspara.Value = usr_employeesalary.EmpDisabledIns;
            paras.Add(empdisabledinspara);

            SqlParameter empillnessinspara = new SqlParameter("@EmpIllnessIns", SqlDbType.Decimal, 9);
            empillnessinspara.Value = usr_employeesalary.EmpIllnessIns;
            paras.Add(empillnessinspara);

            SqlParameter empheatamountpara = new SqlParameter("@EmpHeatAmount", SqlDbType.Decimal, 9);
            empheatamountpara.Value = usr_employeesalary.EmpHeatAmount;
            paras.Add(empheatamountpara);

            SqlParameter emphousefundpara = new SqlParameter("@EmpHouseFund", SqlDbType.Decimal, 9);
            emphousefundpara.Value = usr_employeesalary.EmpHouseFund;
            paras.Add(emphousefundpara);

            SqlParameter emprepinjuryinspara = new SqlParameter("@EmpRepInjuryIns", SqlDbType.Decimal, 9);
            emprepinjuryinspara.Value = usr_employeesalary.EmpRepInjuryIns;
            paras.Add(emprepinjuryinspara);

            SqlParameter emptotalpara = new SqlParameter("@EmpTotal", SqlDbType.Decimal, 9);
            emptotalpara.Value = usr_employeesalary.EmpTotal;
            paras.Add(emptotalpara);

            SqlParameter personaltaxpara = new SqlParameter("@PersonalTax", SqlDbType.Decimal, 9);
            personaltaxpara.Value = usr_employeesalary.PersonalTax;
            paras.Add(personaltaxpara);

            SqlParameter totalamountpara = new SqlParameter("@TotalAmount", SqlDbType.Decimal, 9);
            totalamountpara.Value = usr_employeesalary.TotalAmount;
            paras.Add(totalamountpara);

            SqlParameter repairamountpara = new SqlParameter("@RepairAmount", SqlDbType.Decimal, 9);
            repairamountpara.Value = usr_employeesalary.RepairAmount;
            paras.Add(repairamountpara);

            SqlParameter grossamountpara = new SqlParameter("@GrossAmount", SqlDbType.Decimal, 9);
            grossamountpara.Value = usr_employeesalary.GrossAmount;
            paras.Add(grossamountpara);

            SqlParameter finalamountpara = new SqlParameter("@FinalAmount", SqlDbType.Decimal, 9);
            finalamountpara.Value = usr_employeesalary.FinalAmount;
            paras.Add(finalamountpara);

            SqlParameter serviceamountpara = new SqlParameter("@ServiceAmount", SqlDbType.Decimal, 9);
            serviceamountpara.Value = usr_employeesalary.ServiceAmount;
            paras.Add(serviceamountpara);

            SqlParameter refundamountpara = new SqlParameter("@RefundAmount", SqlDbType.Decimal, 9);
            refundamountpara.Value = usr_employeesalary.RefundAmount;
            paras.Add(refundamountpara);

            SqlParameter paydatepara = new SqlParameter("@PayDate", SqlDbType.DateTime, 8);
            paydatepara.Value = usr_employeesalary.PayDate;
            paras.Add(paydatepara);

            SqlParameter empsalarystatuspara = new SqlParameter("@EmpSalaryStatus", SqlDbType.Int, 4);
            empsalarystatuspara.Value = usr_employeesalary.EmpSalaryStatus;
            paras.Add(empsalarystatuspara);

            if (!string.IsNullOrEmpty(usr_employeesalary.Memo))
            {
                SqlParameter memopara = new SqlParameter("@Memo", SqlDbType.VarChar, 150);
                memopara.Value = usr_employeesalary.Memo;
                paras.Add(memopara);
            }

            SqlParameter lastmodifyidpara = new SqlParameter("@LastModifyId", SqlDbType.Int, 4);
            lastmodifyidpara.Value = obj.LastModifyId;
            paras.Add(lastmodifyidpara);


            return paras;
        }

        public override string TableName
        {
            get
            {
                return "Usr_EmployeeSalary";
            }
        }

        public ResultModel LoadEmployeeSalaryList(int pageIndex, int pageSize, string orderStr, string empName, int corpId)
        {
            SelectModel select = sql_insrance.EmployeeSalaryListSelect(pageIndex, pageSize, orderStr, empName, corpId);
            ResultModel result = Load(select);

            return result;
        }

        public ResultModel<EmployeeSalary> LoadEmployeeSalaryCheckOne(int empId,DateTime payDate)
        {
            string cmdText = string.Format(" select * from Usr_EmployeeSalary where EmpId = {0} and datediff(month,[PayDate],'{1}')= 0  ", empId, payDate);
            ResultModel<EmployeeSalary> result = this.Load<EmployeeSalary>(System.Data.CommandType.Text, cmdText);
            return result;
        }
    }
}
