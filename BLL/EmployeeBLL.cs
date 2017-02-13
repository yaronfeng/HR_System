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
    public class EmployeeBLL : Operate
    {
        private EmployeeSQL sql_insrance = new EmployeeSQL();

        protected override List<SqlParameter> CreateInsertParameters(IModel obj, ref SqlParameter returnValue)
        {
            Employee usr_employee = (Employee)obj;

            List<SqlParameter> paras = new List<SqlParameter>();
            returnValue.Direction = ParameterDirection.Output;
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.ParameterName = "@EmpId";
            returnValue.Size = 4;
            paras.Add(returnValue);

            if (!string.IsNullOrEmpty(usr_employee.EmpName))
            {
                SqlParameter empnamepara = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);
                empnamepara.Value = usr_employee.EmpName;
                paras.Add(empnamepara);
            }

            SqlParameter sexpara = new SqlParameter("@Sex", SqlDbType.Int, 4);
            sexpara.Value = usr_employee.Sex;
            paras.Add(sexpara);

            SqlParameter corpidpara = new SqlParameter("@CorpId", SqlDbType.Int, 4);
            corpidpara.Value = usr_employee.CorpId;
            paras.Add(corpidpara);

            SqlParameter supidpara = new SqlParameter("@SupId", SqlDbType.Int, 4);
            supidpara.Value = usr_employee.SupId;
            paras.Add(supidpara);

            if (!string.IsNullOrEmpty(usr_employee.CardNo))
            {
                SqlParameter cardnopara = new SqlParameter("@CardNo", SqlDbType.VarChar, 50);
                cardnopara.Value = usr_employee.CardNo;
                paras.Add(cardnopara);
            }

            if (!string.IsNullOrEmpty(usr_employee.Address))
            {
                SqlParameter addresspara = new SqlParameter("@Address", SqlDbType.VarChar, 50);
                addresspara.Value = usr_employee.Address;
                paras.Add(addresspara);
            }

            if (!string.IsNullOrEmpty(usr_employee.Phone))
            {
                SqlParameter phonepara = new SqlParameter("@Phone", SqlDbType.VarChar, 50);
                phonepara.Value = usr_employee.Phone;
                paras.Add(phonepara);
            }

            SqlParameter entrydatepara = new SqlParameter("@EntryDate", SqlDbType.DateTime, 8);
            entrydatepara.Value = usr_employee.EntryDate;
            paras.Add(entrydatepara);

            SqlParameter iscontractpara = new SqlParameter("@IsContract", SqlDbType.Int, 4);
            iscontractpara.Value = usr_employee.IsContract;
            paras.Add(iscontractpara);

            SqlParameter constartdatepara = new SqlParameter("@ConStartDate", SqlDbType.DateTime, 8);
            constartdatepara.Value = usr_employee.ConStartDate;
            paras.Add(constartdatepara);

            SqlParameter conenddatepara = new SqlParameter("@ConEndDate", SqlDbType.DateTime, 8);
            conenddatepara.Value = usr_employee.ConEndDate;
            paras.Add(conenddatepara);

            SqlParameter leavedatepara = new SqlParameter("@LeaveDate", SqlDbType.DateTime, 8);
            leavedatepara.Value = usr_employee.LeaveDate;
            paras.Add(leavedatepara);

            SqlParameter degreepara = new SqlParameter("@Degree", SqlDbType.Int, 4);
            degreepara.Value = usr_employee.Degree;
            paras.Add(degreepara);

            if (!string.IsNullOrEmpty(usr_employee.Jobs))
            {
                SqlParameter jobspara = new SqlParameter("@Jobs", SqlDbType.VarChar, 50);
                jobspara.Value = usr_employee.Jobs;
                paras.Add(jobspara);
            }

            SqlParameter totalamountpara = new SqlParameter("@TotalAmount", SqlDbType.Decimal, 9);
            totalamountpara.Value = usr_employee.TotalAmount;
            paras.Add(totalamountpara);

            SqlParameter pisinumpara = new SqlParameter("@PISINum", SqlDbType.Decimal, 9);
            pisinumpara.Value = usr_employee.PISINum;
            paras.Add(pisinumpara);

            SqlParameter misinumpara = new SqlParameter("@MISINum", SqlDbType.Decimal, 9);
            misinumpara.Value = usr_employee.MISINum;
            paras.Add(misinumpara);

            SqlParameter uisinumpara = new SqlParameter("@UISINum", SqlDbType.Decimal, 9);
            uisinumpara.Value = usr_employee.UISINum;
            paras.Add(uisinumpara);

            SqlParameter iisinumpara = new SqlParameter("@IISINum", SqlDbType.Decimal, 9);
            iisinumpara.Value = usr_employee.IISINum;
            paras.Add(iisinumpara);

            SqlParameter bisinumpara = new SqlParameter("@BISINum", SqlDbType.Decimal, 9);
            bisinumpara.Value = usr_employee.BISINum;
            paras.Add(bisinumpara);

            SqlParameter disinumpara = new SqlParameter("@DISINum", SqlDbType.Decimal, 9);
            disinumpara.Value = usr_employee.DISINum;
            paras.Add(disinumpara);

            SqlParameter lisinumpara = new SqlParameter("@LISINum", SqlDbType.Decimal, 9);
            lisinumpara.Value = usr_employee.LISINum;
            paras.Add(lisinumpara);

            SqlParameter hasinumpara = new SqlParameter("@HASINum", SqlDbType.Decimal, 9);
            hasinumpara.Value = usr_employee.HASINum;
            paras.Add(hasinumpara);

            SqlParameter hfsinumpara = new SqlParameter("@HFSINum", SqlDbType.Decimal, 9);
            hfsinumpara.Value = usr_employee.HFSINum;
            paras.Add(hfsinumpara);

            SqlParameter risinumpara = new SqlParameter("@RISINum", SqlDbType.Decimal, 9);
            risinumpara.Value = usr_employee.RISINum;
            paras.Add(risinumpara);

            SqlParameter paycitypara = new SqlParameter("@PayCity", SqlDbType.Int, 4);
            paycitypara.Value = usr_employee.PayCity;
            paras.Add(paycitypara);

            SqlParameter socialstartdatepara = new SqlParameter("@SocialStartDate", SqlDbType.DateTime, 8);
            socialstartdatepara.Value = usr_employee.SocialStartDate;
            paras.Add(socialstartdatepara);

            SqlParameter housestartdatepara = new SqlParameter("@HouseStartDate", SqlDbType.DateTime, 8);
            housestartdatepara.Value = usr_employee.HouseStartDate;
            paras.Add(housestartdatepara);

            if (!string.IsNullOrEmpty(usr_employee.HouseAccount))
            {
                SqlParameter houseaccountpara = new SqlParameter("@HouseAccount", SqlDbType.VarChar, 50);
                houseaccountpara.Value = usr_employee.HouseAccount;
                paras.Add(houseaccountpara);
            }

            SqlParameter handbookpara = new SqlParameter("@HandBook", SqlDbType.Int, 4);
            handbookpara.Value = usr_employee.HandBook;
            paras.Add(handbookpara);

            SqlParameter residentpermitpara = new SqlParameter("@ResidentPermit", SqlDbType.Int, 4);
            residentpermitpara.Value = usr_employee.ResidentPermit;
            paras.Add(residentpermitpara);

            SqlParameter bankpara = new SqlParameter("@Bank", SqlDbType.Int, 4);
            bankpara.Value = usr_employee.Bank;
            paras.Add(bankpara);

            if (!string.IsNullOrEmpty(usr_employee.BankAccount))
            {
                SqlParameter bankaccountpara = new SqlParameter("@BankAccount", SqlDbType.VarChar, 50);
                bankaccountpara.Value = usr_employee.BankAccount;
                paras.Add(bankaccountpara);
            }

            if (!string.IsNullOrEmpty(usr_employee.ContractNo))
            {
                SqlParameter contractnopara = new SqlParameter("@ContractNo", SqlDbType.VarChar, 50);
                contractnopara.Value = usr_employee.ContractNo;
                paras.Add(contractnopara);
            }

            SqlParameter employdatepara = new SqlParameter("@EmployDate", SqlDbType.DateTime, 8);
            employdatepara.Value = usr_employee.EmployDate;
            paras.Add(employdatepara);

            SqlParameter socialsigndatepara = new SqlParameter("@SocialSignDate", SqlDbType.DateTime, 8);
            socialsigndatepara.Value = usr_employee.SocialSignDate;
            paras.Add(socialsigndatepara);

            SqlParameter isbirthinspara = new SqlParameter("@IsBirthIns", SqlDbType.Int, 4);
            isbirthinspara.Value = usr_employee.IsBirthIns;
            paras.Add(isbirthinspara);

            if (!string.IsNullOrEmpty(usr_employee.InsCardNo))
            {
                SqlParameter inscardnopara = new SqlParameter("@InsCardNo", SqlDbType.VarChar, 50);
                inscardnopara.Value = usr_employee.InsCardNo;
                paras.Add(inscardnopara);
            }

            if (!string.IsNullOrEmpty(usr_employee.EmpEmail))
            {
                SqlParameter empemailpara = new SqlParameter("@EmpEmail", SqlDbType.VarChar, 50);
                empemailpara.Value = usr_employee.EmpEmail;
                paras.Add(empemailpara);
            }

            SqlParameter empstatuspara = new SqlParameter("@EmpStatus", SqlDbType.Int, 4);
            empstatuspara.Value = usr_employee.EmpStatus;
            paras.Add(empstatuspara);

            if (!string.IsNullOrEmpty(usr_employee.Memo))
            {
                SqlParameter memopara = new SqlParameter("@Memo", SqlDbType.VarChar, 150);
                memopara.Value = usr_employee.Memo;
                paras.Add(memopara);
            }

            SqlParameter creatoridpara = new SqlParameter("@CreatorId", SqlDbType.Int, 4);
            creatoridpara.Value = obj.CreatorId;
            paras.Add(creatoridpara);


            return paras;
        }

        protected override IModel CreateModel(SqlDataReader dr)
        {
            Employee employee = new Employee();

            int indexEmpId = dr.GetOrdinal("EmpId");
            employee.EmpId = Convert.ToInt32(dr[indexEmpId]);
            int indexEmpName = dr.GetOrdinal("EmpName");
            if (dr[indexEmpName] != DBNull.Value)
            {
                employee.EmpName = Convert.ToString(dr[indexEmpName]);
            }
            int indexSex = dr.GetOrdinal("Sex");
            if (dr[indexSex] != DBNull.Value)
            {
                employee.Sex = Convert.ToInt32(dr[indexSex]);
            }
            int indexCorpId = dr.GetOrdinal("CorpId");
            if (dr[indexCorpId] != DBNull.Value)
            {
                employee.CorpId = Convert.ToInt32(dr[indexCorpId]);
            }
            int indexSupId = dr.GetOrdinal("SupId");
            if (dr[indexSupId] != DBNull.Value)
            {
                employee.SupId = Convert.ToInt32(dr[indexSupId]);
            }
            int indexCardNo = dr.GetOrdinal("CardNo");
            if (dr[indexCardNo] != DBNull.Value)
            {
                employee.CardNo = Convert.ToString(dr[indexCardNo]);
            }
            int indexAddress = dr.GetOrdinal("Address");
            if (dr[indexAddress] != DBNull.Value)
            {
                employee.Address = Convert.ToString(dr[indexAddress]);
            }
            int indexPhone = dr.GetOrdinal("Phone");
            if (dr[indexPhone] != DBNull.Value)
            {
                employee.Phone = Convert.ToString(dr[indexPhone]);
            }
            int indexEntryDate = dr.GetOrdinal("EntryDate");
            if (dr[indexEntryDate] != DBNull.Value)
            {
                employee.EntryDate = Convert.ToDateTime(dr[indexEntryDate]);
            }
            int indexIsContract = dr.GetOrdinal("IsContract");
            if (dr[indexIsContract] != DBNull.Value)
            {
                employee.IsContract = Convert.ToInt32(dr[indexIsContract]);
            }
            int indexConStartDate = dr.GetOrdinal("ConStartDate");
            if (dr[indexConStartDate] != DBNull.Value)
            {
                employee.ConStartDate = Convert.ToDateTime(dr[indexConStartDate]);
            }
            int indexConEndDate = dr.GetOrdinal("ConEndDate");
            if (dr[indexConEndDate] != DBNull.Value)
            {
                employee.ConEndDate = Convert.ToDateTime(dr[indexConEndDate]);
            }
            int indexLeaveDate = dr.GetOrdinal("LeaveDate");
            if (dr[indexLeaveDate] != DBNull.Value)
            {
                employee.LeaveDate = Convert.ToDateTime(dr[indexLeaveDate]);
            }
            int indexDegree = dr.GetOrdinal("Degree");
            if (dr[indexDegree] != DBNull.Value)
            {
                employee.Degree = Convert.ToInt32(dr[indexDegree]);
            }
            int indexJobs = dr.GetOrdinal("Jobs");
            if (dr[indexJobs] != DBNull.Value)
            {
                employee.Jobs = Convert.ToString(dr[indexJobs]);
            }
            int indexTotalAmount = dr.GetOrdinal("TotalAmount");
            if (dr[indexTotalAmount] != DBNull.Value)
            {
                employee.TotalAmount = Convert.ToDecimal(dr[indexTotalAmount]);
            }
            int indexPISINum = dr.GetOrdinal("PISINum");
            if (dr[indexPISINum] != DBNull.Value)
            {
                employee.PISINum = Convert.ToDecimal(dr[indexPISINum]);
            }
            int indexMISINum = dr.GetOrdinal("MISINum");
            if (dr[indexMISINum] != DBNull.Value)
            {
                employee.MISINum = Convert.ToDecimal(dr[indexMISINum]);
            }
            int indexUISINum = dr.GetOrdinal("UISINum");
            if (dr[indexUISINum] != DBNull.Value)
            {
                employee.UISINum = Convert.ToDecimal(dr[indexUISINum]);
            }
            int indexIISINum = dr.GetOrdinal("IISINum");
            if (dr[indexIISINum] != DBNull.Value)
            {
                employee.IISINum = Convert.ToDecimal(dr[indexIISINum]);
            }
            int indexBISINum = dr.GetOrdinal("BISINum");
            if (dr[indexBISINum] != DBNull.Value)
            {
                employee.BISINum = Convert.ToDecimal(dr[indexBISINum]);
            }
            int indexDISINum = dr.GetOrdinal("DISINum");
            if (dr[indexDISINum] != DBNull.Value)
            {
                employee.DISINum = Convert.ToDecimal(dr[indexDISINum]);
            }
            int indexLISINum = dr.GetOrdinal("LISINum");
            if (dr[indexLISINum] != DBNull.Value)
            {
                employee.LISINum = Convert.ToDecimal(dr[indexLISINum]);
            }
            int indexHASINum = dr.GetOrdinal("HASINum");
            if (dr[indexHASINum] != DBNull.Value)
            {
                employee.HASINum = Convert.ToDecimal(dr[indexHASINum]);
            }
            int indexHFSINum = dr.GetOrdinal("HFSINum");
            if (dr[indexHFSINum] != DBNull.Value)
            {
                employee.HFSINum = Convert.ToDecimal(dr[indexHFSINum]);
            }
            int indexRISINum = dr.GetOrdinal("RISINum");
            if (dr[indexRISINum] != DBNull.Value)
            {
                employee.RISINum = Convert.ToDecimal(dr[indexRISINum]);
            }
            int indexPayCity = dr.GetOrdinal("PayCity");
            if (dr[indexPayCity] != DBNull.Value)
            {
                employee.PayCity = Convert.ToInt32(dr[indexPayCity]);
            }
            int indexSocialStartDate = dr.GetOrdinal("SocialStartDate");
            if (dr[indexSocialStartDate] != DBNull.Value)
            {
                employee.SocialStartDate = Convert.ToDateTime(dr[indexSocialStartDate]);
            }
            int indexHouseStartDate = dr.GetOrdinal("HouseStartDate");
            if (dr[indexHouseStartDate] != DBNull.Value)
            {
                employee.HouseStartDate = Convert.ToDateTime(dr[indexHouseStartDate]);
            }
            int indexHouseAccount = dr.GetOrdinal("HouseAccount");
            if (dr[indexHouseAccount] != DBNull.Value)
            {
                employee.HouseAccount = Convert.ToString(dr[indexHouseAccount]);
            }
            int indexHandBook = dr.GetOrdinal("HandBook");
            if (dr[indexHandBook] != DBNull.Value)
            {
                employee.HandBook = Convert.ToInt32(dr[indexHandBook]);
            }
            int indexResidentPermit = dr.GetOrdinal("ResidentPermit");
            if (dr[indexResidentPermit] != DBNull.Value)
            {
                employee.ResidentPermit = Convert.ToInt32(dr[indexResidentPermit]);
            }
            int indexBank = dr.GetOrdinal("Bank");
            if (dr[indexBank] != DBNull.Value)
            {
                employee.Bank = Convert.ToInt32(dr[indexBank]);
            }
            int indexBankAccount = dr.GetOrdinal("BankAccount");
            if (dr[indexBankAccount] != DBNull.Value)
            {
                employee.BankAccount = Convert.ToString(dr[indexBankAccount]);
            }
            int indexContractNo = dr.GetOrdinal("ContractNo");
            if (dr[indexContractNo] != DBNull.Value)
            {
                employee.ContractNo = Convert.ToString(dr[indexContractNo]);
            }
            int indexEmployDate = dr.GetOrdinal("EmployDate");
            if (dr[indexEmployDate] != DBNull.Value)
            {
                employee.EmployDate = Convert.ToDateTime(dr[indexEmployDate]);
            }
            int indexSocialSignDate = dr.GetOrdinal("SocialSignDate");
            if (dr[indexSocialSignDate] != DBNull.Value)
            {
                employee.SocialSignDate = Convert.ToDateTime(dr[indexSocialSignDate]);
            }
            int indexIsBirthIns = dr.GetOrdinal("IsBirthIns");
            if (dr[indexIsBirthIns] != DBNull.Value)
            {
                employee.IsBirthIns = Convert.ToInt32(dr[indexIsBirthIns]);
            }
            int indexInsCardNo = dr.GetOrdinal("InsCardNo");
            if (dr[indexInsCardNo] != DBNull.Value)
            {
                employee.InsCardNo = Convert.ToString(dr[indexInsCardNo]);
            }
            int indexEmpEmail = dr.GetOrdinal("EmpEmail");
            if (dr[indexEmpEmail] != DBNull.Value)
            {
                employee.EmpEmail = Convert.ToString(dr[indexEmpEmail]);
            }
            int indexEmpStatus = dr.GetOrdinal("EmpStatus");
            if (dr[indexEmpStatus] != DBNull.Value)
            {
                employee.EmpStatus = Convert.ToInt32(dr[indexEmpStatus]);
            }
            int indexMemo = dr.GetOrdinal("Memo");
            if (dr[indexMemo] != DBNull.Value)
            {
                employee.Memo = Convert.ToString(dr[indexMemo]);
            }
            int indexCreatorId = dr.GetOrdinal("CreatorId");
            if (dr[indexCreatorId] != DBNull.Value)
            {
                employee.CreatorId = Convert.ToInt32(dr[indexCreatorId]);
            }
            int indexCreateTime = dr.GetOrdinal("CreateTime");
            if (dr[indexCreateTime] != DBNull.Value)
            {
                employee.CreateTime = Convert.ToDateTime(dr[indexCreateTime]);
            }
            int indexLastModifyId = dr.GetOrdinal("LastModifyId");
            if (dr[indexLastModifyId] != DBNull.Value)
            {
                employee.LastModifyId = Convert.ToInt32(dr[indexLastModifyId]);
            }
            int indexLastModifyTime = dr.GetOrdinal("LastModifyTime");
            if (dr[indexLastModifyTime] != DBNull.Value)
            {
                employee.LastModifyTime = Convert.ToDateTime(dr[indexLastModifyTime]);
            }

            return employee;
        }

        public override List<SqlParameter> CreateUpdateParameters(IModel obj)
        {
            Employee usr_employee = (Employee)obj;

            List<SqlParameter> paras = new List<SqlParameter>();

            SqlParameter empidpara = new SqlParameter("@EmpId", SqlDbType.Int, 4);
            empidpara.Value = usr_employee.EmpId;
            paras.Add(empidpara);

            if (!string.IsNullOrEmpty(usr_employee.EmpName))
            {
                SqlParameter empnamepara = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);
                empnamepara.Value = usr_employee.EmpName;
                paras.Add(empnamepara);
            }

            SqlParameter sexpara = new SqlParameter("@Sex", SqlDbType.Int, 4);
            sexpara.Value = usr_employee.Sex;
            paras.Add(sexpara);

            SqlParameter corpidpara = new SqlParameter("@CorpId", SqlDbType.Int, 4);
            corpidpara.Value = usr_employee.CorpId;
            paras.Add(corpidpara);

            SqlParameter supidpara = new SqlParameter("@SupId", SqlDbType.Int, 4);
            supidpara.Value = usr_employee.SupId;
            paras.Add(supidpara);

            if (!string.IsNullOrEmpty(usr_employee.CardNo))
            {
                SqlParameter cardnopara = new SqlParameter("@CardNo", SqlDbType.VarChar, 50);
                cardnopara.Value = usr_employee.CardNo;
                paras.Add(cardnopara);
            }

            if (!string.IsNullOrEmpty(usr_employee.Address))
            {
                SqlParameter addresspara = new SqlParameter("@Address", SqlDbType.VarChar, 50);
                addresspara.Value = usr_employee.Address;
                paras.Add(addresspara);
            }

            if (!string.IsNullOrEmpty(usr_employee.Phone))
            {
                SqlParameter phonepara = new SqlParameter("@Phone", SqlDbType.VarChar, 50);
                phonepara.Value = usr_employee.Phone;
                paras.Add(phonepara);
            }

            SqlParameter entrydatepara = new SqlParameter("@EntryDate", SqlDbType.DateTime, 8);
            entrydatepara.Value = usr_employee.EntryDate;
            paras.Add(entrydatepara);

            SqlParameter iscontractpara = new SqlParameter("@IsContract", SqlDbType.Int, 4);
            iscontractpara.Value = usr_employee.IsContract;
            paras.Add(iscontractpara);

            SqlParameter constartdatepara = new SqlParameter("@ConStartDate", SqlDbType.DateTime, 8);
            constartdatepara.Value = usr_employee.ConStartDate;
            paras.Add(constartdatepara);

            SqlParameter conenddatepara = new SqlParameter("@ConEndDate", SqlDbType.DateTime, 8);
            conenddatepara.Value = usr_employee.ConEndDate;
            paras.Add(conenddatepara);

            SqlParameter leavedatepara = new SqlParameter("@LeaveDate", SqlDbType.DateTime, 8);
            leavedatepara.Value = usr_employee.LeaveDate;
            paras.Add(leavedatepara);

            SqlParameter degreepara = new SqlParameter("@Degree", SqlDbType.Int, 4);
            degreepara.Value = usr_employee.Degree;
            paras.Add(degreepara);

            if (!string.IsNullOrEmpty(usr_employee.Jobs))
            {
                SqlParameter jobspara = new SqlParameter("@Jobs", SqlDbType.VarChar, 50);
                jobspara.Value = usr_employee.Jobs;
                paras.Add(jobspara);
            }

            SqlParameter totalamountpara = new SqlParameter("@TotalAmount", SqlDbType.Decimal, 9);
            totalamountpara.Value = usr_employee.TotalAmount;
            paras.Add(totalamountpara);

            SqlParameter pisinumpara = new SqlParameter("@PISINum", SqlDbType.Decimal, 9);
            pisinumpara.Value = usr_employee.PISINum;
            paras.Add(pisinumpara);

            SqlParameter misinumpara = new SqlParameter("@MISINum", SqlDbType.Decimal, 9);
            misinumpara.Value = usr_employee.MISINum;
            paras.Add(misinumpara);

            SqlParameter uisinumpara = new SqlParameter("@UISINum", SqlDbType.Decimal, 9);
            uisinumpara.Value = usr_employee.UISINum;
            paras.Add(uisinumpara);

            SqlParameter iisinumpara = new SqlParameter("@IISINum", SqlDbType.Decimal, 9);
            iisinumpara.Value = usr_employee.IISINum;
            paras.Add(iisinumpara);

            SqlParameter bisinumpara = new SqlParameter("@BISINum", SqlDbType.Decimal, 9);
            bisinumpara.Value = usr_employee.BISINum;
            paras.Add(bisinumpara);

            SqlParameter disinumpara = new SqlParameter("@DISINum", SqlDbType.Decimal, 9);
            disinumpara.Value = usr_employee.DISINum;
            paras.Add(disinumpara);

            SqlParameter lisinumpara = new SqlParameter("@LISINum", SqlDbType.Decimal, 9);
            lisinumpara.Value = usr_employee.LISINum;
            paras.Add(lisinumpara);

            SqlParameter hasinumpara = new SqlParameter("@HASINum", SqlDbType.Decimal, 9);
            hasinumpara.Value = usr_employee.HASINum;
            paras.Add(hasinumpara);

            SqlParameter hfsinumpara = new SqlParameter("@HFSINum", SqlDbType.Decimal, 9);
            hfsinumpara.Value = usr_employee.HFSINum;
            paras.Add(hfsinumpara);

            SqlParameter risinumpara = new SqlParameter("@RISINum", SqlDbType.Decimal, 9);
            risinumpara.Value = usr_employee.RISINum;
            paras.Add(risinumpara);

            SqlParameter paycitypara = new SqlParameter("@PayCity", SqlDbType.Int, 4);
            paycitypara.Value = usr_employee.PayCity;
            paras.Add(paycitypara);

            SqlParameter socialstartdatepara = new SqlParameter("@SocialStartDate", SqlDbType.DateTime, 8);
            socialstartdatepara.Value = usr_employee.SocialStartDate;
            paras.Add(socialstartdatepara);

            SqlParameter housestartdatepara = new SqlParameter("@HouseStartDate", SqlDbType.DateTime, 8);
            housestartdatepara.Value = usr_employee.HouseStartDate;
            paras.Add(housestartdatepara);

            if (!string.IsNullOrEmpty(usr_employee.HouseAccount))
            {
                SqlParameter houseaccountpara = new SqlParameter("@HouseAccount", SqlDbType.VarChar, 50);
                houseaccountpara.Value = usr_employee.HouseAccount;
                paras.Add(houseaccountpara);
            }

            SqlParameter handbookpara = new SqlParameter("@HandBook", SqlDbType.Int, 4);
            handbookpara.Value = usr_employee.HandBook;
            paras.Add(handbookpara);

            SqlParameter residentpermitpara = new SqlParameter("@ResidentPermit", SqlDbType.Int, 4);
            residentpermitpara.Value = usr_employee.ResidentPermit;
            paras.Add(residentpermitpara);

            SqlParameter bankpara = new SqlParameter("@Bank", SqlDbType.Int, 4);
            bankpara.Value = usr_employee.Bank;
            paras.Add(bankpara);

            if (!string.IsNullOrEmpty(usr_employee.BankAccount))
            {
                SqlParameter bankaccountpara = new SqlParameter("@BankAccount", SqlDbType.VarChar, 50);
                bankaccountpara.Value = usr_employee.BankAccount;
                paras.Add(bankaccountpara);
            }

            if (!string.IsNullOrEmpty(usr_employee.ContractNo))
            {
                SqlParameter contractnopara = new SqlParameter("@ContractNo", SqlDbType.VarChar, 50);
                contractnopara.Value = usr_employee.ContractNo;
                paras.Add(contractnopara);
            }

            SqlParameter employdatepara = new SqlParameter("@EmployDate", SqlDbType.DateTime, 8);
            employdatepara.Value = usr_employee.EmployDate;
            paras.Add(employdatepara);

            SqlParameter socialsigndatepara = new SqlParameter("@SocialSignDate", SqlDbType.DateTime, 8);
            socialsigndatepara.Value = usr_employee.SocialSignDate;
            paras.Add(socialsigndatepara);

            SqlParameter isbirthinspara = new SqlParameter("@IsBirthIns", SqlDbType.Int, 4);
            isbirthinspara.Value = usr_employee.IsBirthIns;
            paras.Add(isbirthinspara);

            if (!string.IsNullOrEmpty(usr_employee.InsCardNo))
            {
                SqlParameter inscardnopara = new SqlParameter("@InsCardNo", SqlDbType.VarChar, 50);
                inscardnopara.Value = usr_employee.InsCardNo;
                paras.Add(inscardnopara);
            }

            if (!string.IsNullOrEmpty(usr_employee.EmpEmail))
            {
                SqlParameter empemailpara = new SqlParameter("@EmpEmail", SqlDbType.VarChar, 50);
                empemailpara.Value = usr_employee.EmpEmail;
                paras.Add(empemailpara);
            }

            SqlParameter empstatuspara = new SqlParameter("@EmpStatus", SqlDbType.Int, 4);
            empstatuspara.Value = usr_employee.EmpStatus;
            paras.Add(empstatuspara);

            if (!string.IsNullOrEmpty(usr_employee.Memo))
            {
                SqlParameter memopara = new SqlParameter("@Memo", SqlDbType.VarChar, 150);
                memopara.Value = usr_employee.Memo;
                paras.Add(memopara);
            }

            SqlParameter lastmodifyidpara = new SqlParameter("@LastModifyId", SqlDbType.Int, 4);
            lastmodifyidpara.Value = obj.LastModifyId;
            paras.Add(lastmodifyidpara);


            return paras;
        }
        public ResultModel LoadEmployeeList(int pageIndex, int pageSize, string orderStr, string empName, int corpId, DateTime conStartDate, DateTime conEndDate)
        {
            SelectModel select = sql_insrance.EmployeeListSelect(pageIndex, pageSize, orderStr, empName, corpId, conStartDate, conEndDate);
            ResultModel result = Load(select);

            return result;
        }

        public ResultModel LoadEmployeeSalaryList(int pageIndex, int pageSize, string orderStr, int empId)
        {
            SelectModel select = sql_insrance.EmployeeSalaryListSelect(pageIndex, pageSize, orderStr, empId);
            ResultModel result = Load(select);

            return result;
        }

        public ResultModel LoadEmployeeExpireList(int pageIndex, int pageSize, string orderStr)
        {
            SelectModel select = sql_insrance.EmployeeExpireListSelect(pageIndex, pageSize, orderStr);
            ResultModel result = Load(select);

            return result;
        }

        public ResultModel LoadEmployeePayList(int pageIndex, int pageSize, string orderStr, int corpId, DateTime payDate)
        {
            SelectModel select = sql_insrance.EmployeePayListSelect(pageIndex, pageSize, orderStr, corpId, payDate);
            ResultModel result = Load(select);

            return result;
        }

        public override string TableName
        {
            get
            {
                return "Usr_Employee";
            }
        }
    }
}
