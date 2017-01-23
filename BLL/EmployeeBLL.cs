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

            SqlParameter socialfundnumpara = new SqlParameter("@SocialFundNum", SqlDbType.Decimal, 9);
            socialfundnumpara.Value = usr_employee.SocialFundNum;
            paras.Add(socialfundnumpara);

            SqlParameter housefundnumpara = new SqlParameter("@HouseFundNum", SqlDbType.Decimal, 9);
            housefundnumpara.Value = usr_employee.HouseFundNum;
            paras.Add(housefundnumpara);

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

        protected override IModel CreateModel(SqlDataReader rd)
        {
            Employee employee = new Employee();
            if (rd["EmpId"] != DBNull.Value)
                employee.EmpId = int.Parse(rd["EmpId"].ToString());
            employee.EmpName = rd["EmpName"].ToString();
            if (rd["Sex"] != DBNull.Value)
                employee.Sex = int.Parse(rd["Sex"].ToString());
            if (rd["CorpId"] != DBNull.Value)
                employee.CorpId = int.Parse(rd["CorpId"].ToString());
            employee.CardNo = rd["CardNo"].ToString();
            employee.Address = rd["Address"].ToString();
            employee.Phone = rd["Phone"].ToString();
            if (rd["EntryDate"] != DBNull.Value)
                employee.EntryDate = DateTime.Parse(rd["EntryDate"].ToString());
            if (rd["ConStartDate"] != DBNull.Value)
                employee.ConStartDate = DateTime.Parse(rd["ConStartDate"].ToString());
            if (rd["ConEndDate"] != DBNull.Value)
                employee.ConEndDate = DateTime.Parse(rd["ConEndDate"].ToString());
            if (rd["LeaveDate"] != DBNull.Value)
                employee.LeaveDate = DateTime.Parse(rd["LeaveDate"].ToString());
            if (rd["Degree"] != DBNull.Value)
                employee.Degree = int.Parse(rd["Degree"].ToString());
            employee.Jobs = rd["Jobs"].ToString();
            if (rd["TotalAmount"] != DBNull.Value)
                employee.TotalAmount = decimal.Parse(rd["TotalAmount"].ToString());
            if (rd["SocialFundNum"] != DBNull.Value)
                employee.SocialFundNum = decimal.Parse(rd["SocialFundNum"].ToString());
            if (rd["HouseFundNum"] != DBNull.Value)
                employee.HouseFundNum = decimal.Parse(rd["HouseFundNum"].ToString());
            if (rd["PayCity"] != DBNull.Value)
                employee.PayCity = int.Parse(rd["PayCity"].ToString());
            if (rd["SocialStartDate"] != DBNull.Value)
                employee.SocialStartDate = Convert.ToDateTime(rd["SocialStartDate"]);
            if (rd["HouseStartDate"] != DBNull.Value)
                employee.HouseStartDate = Convert.ToDateTime(rd["HouseStartDate"]);
            if (rd["HouseAccount"] != DBNull.Value)
                employee.HouseAccount = rd["HouseAccount"].ToString();
            if (rd["HandBook"] != DBNull.Value)
                employee.HandBook = Convert.ToInt32(rd["HandBook"]);
            if (rd["ResidentPermit"] != DBNull.Value)
                employee.ResidentPermit = Convert.ToInt32(rd["ResidentPermit"]);
            if (rd["Bank"] != DBNull.Value)
                employee.Bank = Convert.ToInt32(rd["Bank"]);
            employee.BankAccount = rd["BankAccount"].ToString();
            employee.ContractNo = rd["ContractNo"].ToString();
            if (rd["EmployDate"] != DBNull.Value)
                employee.EmployDate = Convert.ToDateTime(rd["EmployDate"]);
            if (rd["SocialSignDate"] != DBNull.Value)
                employee.SocialSignDate = Convert.ToDateTime(rd["SocialSignDate"]);
            if (rd["IsBirthIns"] != DBNull.Value)
                employee.IsBirthIns = Convert.ToInt32(rd["IsBirthIns"]);
            employee.InsCardNo = rd["InsCardNo"].ToString();
            employee.EmpEmail = rd["EmpEmail"].ToString();
            if (rd["EmpStatus"] != DBNull.Value)
                employee.EmpStatus = Convert.ToInt32(rd["EmpStatus"]);
            employee.Memo = rd["Memo"].ToString();
            if (rd["CreatorId"] != DBNull.Value)
                employee.CreatorId = Convert.ToInt32(rd["CreatorId"]);
            if (rd["CreateTime"] != DBNull.Value)
                employee.CreateTime = Convert.ToDateTime(rd["CreateTime"]);
            if (rd["LastModifyId"] != DBNull.Value)
                employee.LastModifyId = Convert.ToInt32(rd["LastModifyId"]);
            if (rd["LastModifyTime"] != DBNull.Value)
                employee.LastModifyTime = Convert.ToDateTime(rd["LastModifyTime"]);
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

            SqlParameter socialfundnumpara = new SqlParameter("@SocialFundNum", SqlDbType.Decimal, 9);
            socialfundnumpara.Value = usr_employee.SocialFundNum;
            paras.Add(socialfundnumpara);

            SqlParameter housefundnumpara = new SqlParameter("@HouseFundNum", SqlDbType.Decimal, 9);
            housefundnumpara.Value = usr_employee.HouseFundNum;
            paras.Add(housefundnumpara);

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
        public ResultModel LoadEmployeeList(int pageIndex, int pageSize, string orderStr)
        {
            SelectModel select = sql_insrance.EmployeeListSelect(pageIndex, pageSize, orderStr);
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

        public override string TableName
        {
            get
            {
                return "Usr_Employee";
            }
        }
    }
}
