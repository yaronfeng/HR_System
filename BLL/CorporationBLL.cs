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
    public class CorporationBLL : Operate
    {
        private CorporationSQL sql_insrance = new CorporationSQL();

        public ResultModel LoadCorporationList(int pageIndex, int pageSize, string orderStr)
        {
            SelectModel select = sql_insrance.CorporationListSelect(pageIndex, pageSize, orderStr);
            ResultModel result = Load(select);

            return result;
        }
        protected override List<SqlParameter> CreateInsertParameters(IModel obj, ref SqlParameter returnValue)
        {
            Corporation corp = (Corporation)obj;

            List<SqlParameter> paras = new List<SqlParameter>();
            returnValue.Direction = ParameterDirection.Output;
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.ParameterName = "@CorpId";
            returnValue.Size = 4;
            paras.Add(returnValue);

            if (!string.IsNullOrEmpty(corp.CorpCode))
            {
                SqlParameter corpcodepara = new SqlParameter("@CorpCode", SqlDbType.VarChar, 20);
                corpcodepara.Value = corp.CorpCode;
                paras.Add(corpcodepara);
            }
            if (!string.IsNullOrEmpty(corp.CorpName))
            {
                SqlParameter corpnamepara = new SqlParameter("@CorpName", SqlDbType.VarChar, 20);
                corpnamepara.Value = corp.CorpName;
                paras.Add(corpnamepara);
            }
            if (!string.IsNullOrEmpty(corp.CorpEName))
            {
                SqlParameter corpenamepara = new SqlParameter("@CorpEName", SqlDbType.VarChar, 20);
                corpenamepara.Value = corp.CorpEName;
                paras.Add(corpenamepara);
            }
            if (!string.IsNullOrEmpty(corp.CorpAddress))
            {
                SqlParameter corpaddresspara = new SqlParameter("@CorpAddress", SqlDbType.VarChar, 20);
                corpaddresspara.Value = corp.CorpAddress;
                paras.Add(corpaddresspara);
            }
            if (!string.IsNullOrEmpty(corp.CorpContacts))
            {
                SqlParameter corpcontactspara = new SqlParameter("@CorpContacts", SqlDbType.VarChar, 20);
                corpcontactspara.Value = corp.CorpContacts;
                paras.Add(corpcontactspara);
            }
            if (!string.IsNullOrEmpty(corp.CorpTel))
            {
                SqlParameter corptelpara = new SqlParameter("@CorpTel", SqlDbType.VarChar, 20);
                corptelpara.Value = corp.CorpTel;
                paras.Add(corptelpara);
            }
            if (!string.IsNullOrEmpty(corp.CorpFax))
            {
                SqlParameter corpfaxpara = new SqlParameter("@CorpFax", SqlDbType.VarChar, 20);
                corpfaxpara.Value = corp.CorpFax;
                paras.Add(corpfaxpara);
            }
            if (!string.IsNullOrEmpty(corp.CorpZip))
            {
                SqlParameter corpzippara = new SqlParameter("@CorpZip", SqlDbType.VarChar, 20);
                corpzippara.Value = corp.CorpZip;
                paras.Add(corpzippara);
            }
            if (!string.IsNullOrEmpty(corp.CorpEmail))
            {
                SqlParameter corpemailpara = new SqlParameter("@CorpEmail", SqlDbType.VarChar, 20);
                corpemailpara.Value = corp.CorpEmail;
                paras.Add(corpemailpara);
            }
            if (!string.IsNullOrEmpty(corp.OrganizationCode))
            {
                SqlParameter organizationcodepara = new SqlParameter("@OrganizationCode", SqlDbType.VarChar, 20);
                organizationcodepara.Value = corp.OrganizationCode;
                paras.Add(organizationcodepara);
            }
            if (!string.IsNullOrEmpty(corp.InternetPWD))
            {
                SqlParameter internetpwdpara = new SqlParameter("@InternetPWD", SqlDbType.VarChar, 20);
                internetpwdpara.Value = corp.InternetPWD;
                paras.Add(internetpwdpara);
            }
            if (!string.IsNullOrEmpty(corp.SocialRegCode))
            {
                SqlParameter socialregcodepara = new SqlParameter("@SocialRegCode", SqlDbType.VarChar, 20);
                socialregcodepara.Value = corp.SocialRegCode;
                paras.Add(socialregcodepara);
            }

            SqlParameter paycitypara = new SqlParameter("@PayCity", SqlDbType.Int, 4);
            paycitypara.Value = corp.PayCity;
            paras.Add(paycitypara);

            if (!string.IsNullOrEmpty(corp.HouseAccount))
            {
                SqlParameter houseaccountpara = new SqlParameter("@HouseAccount", SqlDbType.VarChar, 20);
                houseaccountpara.Value = corp.HouseAccount;
                paras.Add(houseaccountpara);
            }

            SqlParameter housebankpara = new SqlParameter("@HouseBank", SqlDbType.VarChar, 20);
            housebankpara.Value = corp.HouseBank;
            paras.Add(housebankpara);

            if (!string.IsNullOrEmpty(corp.HousePWD))
            {
                SqlParameter housepwdpara = new SqlParameter("@HousePWD", SqlDbType.VarChar, 20);
                housepwdpara.Value = corp.HousePWD;
                paras.Add(housepwdpara);
            }

            if (!string.IsNullOrEmpty(corp.Memo))
            {
                SqlParameter memopara = new SqlParameter("@Memo", SqlDbType.VarChar, 4000);
                memopara.Value = corp.Memo;
                paras.Add(memopara);
            }

            SqlParameter corpstatuspara = new SqlParameter("@CorpStatus", SqlDbType.Int, 4);
            corpstatuspara.Value = corp.CorpStatus;
            paras.Add(corpstatuspara);

            SqlParameter creatoridpara = new SqlParameter("@CreatorId", SqlDbType.Int, 4);
            creatoridpara.Value = obj.CreatorId;
            paras.Add(creatoridpara);

            return paras;
        }
        protected override IModel CreateModel(SqlDataReader rd)
        {
            Corporation corp = new Corporation();
            if (rd["CorpId"] != DBNull.Value)
                corp.CorpId = int.Parse(rd["CorpId"].ToString());
            corp.CorpName = rd["CorpName"].ToString();
            corp.CorpEName = rd["CorpEName"].ToString();
            corp.CorpAddress = rd["CorpAddress"].ToString();
            corp.CorpContacts = rd["CorpContacts"].ToString();
            corp.CorpTel = rd["CorpTel"].ToString();
            corp.CorpFax = rd["CorpFax"].ToString();
            corp.CorpZip = rd["CorpZip"].ToString();
            corp.CorpEmail = rd["CorpEmail"].ToString();
            corp.OrganizationCode = rd["OrganizationCode"].ToString();
            corp.InternetPWD = rd["InternetPWD"].ToString();
            corp.SocialRegCode = rd["SocialRegCode"].ToString();
            if (rd["PayCity"] != DBNull.Value)
                corp.PayCity = Convert.ToInt32(rd["PayCity"]);
            corp.HouseAccount = rd["HouseAccount"].ToString();
            if (rd["HouseBank"] != DBNull.Value)
                corp.HouseBank = Convert.ToInt32(rd["HouseBank"]);
            corp.HousePWD = rd["HousePWD"].ToString();
            if (rd["CorpStatus"] != DBNull.Value)
                corp.CorpStatus = Convert.ToInt32(rd["CorpStatus"]);
            corp.Memo = rd["Memo"].ToString();
            if (rd["CreatorId"] != DBNull.Value)
                corp.CreatorId = Convert.ToInt32(rd["CreatorId"]);
            if (rd["CreateTime"] != DBNull.Value)
                corp.CreateTime = Convert.ToDateTime(rd["CreateTime"]);
            if (rd["LastModifyId"] != DBNull.Value)
                corp.LastModifyId = Convert.ToInt32(rd["LastModifyId"]);
            if (rd["LastModifyTime"] != DBNull.Value)
                corp.LastModifyTime = Convert.ToDateTime(rd["LastModifyTime"]);
            return corp;
        }

        public override List<SqlParameter> CreateUpdateParameters(IModel obj)
        {
            Corporation corp = (Corporation)obj;

            List<SqlParameter> paras = new List<SqlParameter>();

            SqlParameter corpidpara = new SqlParameter("@CorpId", SqlDbType.Int, 4);
            corpidpara.Value = corp.CorpId;
            paras.Add(corpidpara);

            if (!string.IsNullOrEmpty(corp.CorpCode))
            {
                SqlParameter corpcodepara = new SqlParameter("@CorpCode", SqlDbType.VarChar, 20);
                corpcodepara.Value = corp.CorpCode;
                paras.Add(corpcodepara);
            }
            if (!string.IsNullOrEmpty(corp.CorpName))
            {
                SqlParameter corpnamepara = new SqlParameter("@CorpName", SqlDbType.VarChar, 20);
                corpnamepara.Value = corp.CorpName;
                paras.Add(corpnamepara);
            }
            if (!string.IsNullOrEmpty(corp.CorpEName))
            {
                SqlParameter corpenamepara = new SqlParameter("@CorpEName", SqlDbType.VarChar, 20);
                corpenamepara.Value = corp.CorpEName;
                paras.Add(corpenamepara);
            }
            if (!string.IsNullOrEmpty(corp.CorpAddress))
            {
                SqlParameter corpaddresspara = new SqlParameter("@CorpAddress", SqlDbType.VarChar, 20);
                corpaddresspara.Value = corp.CorpAddress;
                paras.Add(corpaddresspara);
            }
            if (!string.IsNullOrEmpty(corp.CorpContacts))
            {
                SqlParameter corpcontactspara = new SqlParameter("@CorpContacts", SqlDbType.VarChar, 20);
                corpcontactspara.Value = corp.CorpContacts;
                paras.Add(corpcontactspara);
            }
            if (!string.IsNullOrEmpty(corp.CorpTel))
            {
                SqlParameter corptelpara = new SqlParameter("@CorpTel", SqlDbType.VarChar, 20);
                corptelpara.Value = corp.CorpTel;
                paras.Add(corptelpara);
            }
            if (!string.IsNullOrEmpty(corp.CorpFax))
            {
                SqlParameter corpfaxpara = new SqlParameter("@CorpFax", SqlDbType.VarChar, 20);
                corpfaxpara.Value = corp.CorpFax;
                paras.Add(corpfaxpara);
            }
            if (!string.IsNullOrEmpty(corp.CorpZip))
            {
                SqlParameter corpzippara = new SqlParameter("@CorpZip", SqlDbType.VarChar, 20);
                corpzippara.Value = corp.CorpZip;
                paras.Add(corpzippara);
            }
            if (!string.IsNullOrEmpty(corp.CorpEmail))
            {
                SqlParameter corpemailpara = new SqlParameter("@CorpEmail", SqlDbType.VarChar, 20);
                corpemailpara.Value = corp.CorpEmail;
                paras.Add(corpemailpara);
            }
            if (!string.IsNullOrEmpty(corp.OrganizationCode))
            {
                SqlParameter organizationcodepara = new SqlParameter("@OrganizationCode", SqlDbType.VarChar, 20);
                organizationcodepara.Value = corp.OrganizationCode;
                paras.Add(organizationcodepara);
            }
            if (!string.IsNullOrEmpty(corp.InternetPWD))
            {
                SqlParameter internetpwdpara = new SqlParameter("@InternetPWD", SqlDbType.VarChar, 20);
                internetpwdpara.Value = corp.InternetPWD;
                paras.Add(internetpwdpara);
            }
            if (!string.IsNullOrEmpty(corp.SocialRegCode))
            {
                SqlParameter socialregcodepara = new SqlParameter("@SocialRegCode", SqlDbType.VarChar, 20);
                socialregcodepara.Value = corp.SocialRegCode;
                paras.Add(socialregcodepara);
            }

            SqlParameter paycitypara = new SqlParameter("@PayCity", SqlDbType.Int, 4);
            paycitypara.Value = corp.PayCity;
            paras.Add(paycitypara);

            if (!string.IsNullOrEmpty(corp.HouseAccount))
            {
                SqlParameter houseaccountpara = new SqlParameter("@HouseAccount", SqlDbType.VarChar, 20);
                houseaccountpara.Value = corp.HouseAccount;
                paras.Add(houseaccountpara);
            }

            SqlParameter housebankpara = new SqlParameter("@HouseBank", SqlDbType.VarChar, 20);
            housebankpara.Value = corp.HouseBank;
            paras.Add(housebankpara);

            if (!string.IsNullOrEmpty(corp.HousePWD))
            {
                SqlParameter housepwdpara = new SqlParameter("@HousePWD", SqlDbType.VarChar, 20);
                housepwdpara.Value = corp.HousePWD;
                paras.Add(housepwdpara);
            }

            if (!string.IsNullOrEmpty(corp.Memo))
            {
                SqlParameter memopara = new SqlParameter("@Memo", SqlDbType.VarChar, 4000);
                memopara.Value = corp.Memo;
                paras.Add(memopara);
            }

            SqlParameter corpstatuspara = new SqlParameter("@CorpStatus", SqlDbType.Int, 4);
            corpstatuspara.Value = corp.CorpStatus;
            paras.Add(corpstatuspara);

            SqlParameter lastmodifyidpara = new SqlParameter("@LastModifyId", SqlDbType.Int, 4);
            lastmodifyidpara.Value = corp.LastModifyId;
            paras.Add(lastmodifyidpara);

            return paras;
        }

        public override string TableName
        {
            get
            {
                return "Usr_Corporation";
            }
        }
    }
}
