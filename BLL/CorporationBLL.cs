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

        protected override List<SqlParameter> CreateInsertParameters(IModel obj, ref SqlParameter returnValue)
        {
            Corporation usr_corporation = (Corporation)obj;

            List<SqlParameter> paras = new List<SqlParameter>();
            returnValue.Direction = ParameterDirection.Output;
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.ParameterName = "@CorpId";
            returnValue.Size = 4;
            paras.Add(returnValue);

            if (!string.IsNullOrEmpty(usr_corporation.CorpCode))
            {
                SqlParameter corpcodepara = new SqlParameter("@CorpCode", SqlDbType.VarChar, 50);
                corpcodepara.Value = usr_corporation.CorpCode;
                paras.Add(corpcodepara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.CorpName))
            {
                SqlParameter corpnamepara = new SqlParameter("@CorpName", SqlDbType.VarChar, 50);
                corpnamepara.Value = usr_corporation.CorpName;
                paras.Add(corpnamepara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.CorpEName))
            {
                SqlParameter corpenamepara = new SqlParameter("@CorpEName", SqlDbType.VarChar, 50);
                corpenamepara.Value = usr_corporation.CorpEName;
                paras.Add(corpenamepara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.CorpAddress))
            {
                SqlParameter corpaddresspara = new SqlParameter("@CorpAddress", SqlDbType.VarChar, 150);
                corpaddresspara.Value = usr_corporation.CorpAddress;
                paras.Add(corpaddresspara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.CorpContacts))
            {
                SqlParameter corpcontactspara = new SqlParameter("@CorpContacts", SqlDbType.VarChar, 50);
                corpcontactspara.Value = usr_corporation.CorpContacts;
                paras.Add(corpcontactspara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.CorpTel))
            {
                SqlParameter corptelpara = new SqlParameter("@CorpTel", SqlDbType.VarChar, 50);
                corptelpara.Value = usr_corporation.CorpTel;
                paras.Add(corptelpara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.CorpFax))
            {
                SqlParameter corpfaxpara = new SqlParameter("@CorpFax", SqlDbType.VarChar, 50);
                corpfaxpara.Value = usr_corporation.CorpFax;
                paras.Add(corpfaxpara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.CorpZip))
            {
                SqlParameter corpzippara = new SqlParameter("@CorpZip", SqlDbType.VarChar, 50);
                corpzippara.Value = usr_corporation.CorpZip;
                paras.Add(corpzippara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.CorpEmail))
            {
                SqlParameter corpemailpara = new SqlParameter("@CorpEmail", SqlDbType.VarChar, 50);
                corpemailpara.Value = usr_corporation.CorpEmail;
                paras.Add(corpemailpara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.OrganizationCode))
            {
                SqlParameter organizationcodepara = new SqlParameter("@OrganizationCode", SqlDbType.VarChar, 50);
                organizationcodepara.Value = usr_corporation.OrganizationCode;
                paras.Add(organizationcodepara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.InternetPWD))
            {
                SqlParameter internetpwdpara = new SqlParameter("@InternetPWD", SqlDbType.VarChar, 50);
                internetpwdpara.Value = usr_corporation.InternetPWD;
                paras.Add(internetpwdpara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.SocialRegCode))
            {
                SqlParameter socialregcodepara = new SqlParameter("@SocialRegCode", SqlDbType.VarChar, 50);
                socialregcodepara.Value = usr_corporation.SocialRegCode;
                paras.Add(socialregcodepara);
            }

            SqlParameter paycitypara = new SqlParameter("@PayCity", SqlDbType.Int, 4);
            paycitypara.Value = usr_corporation.PayCity;
            paras.Add(paycitypara);

            if (!string.IsNullOrEmpty(usr_corporation.HouseAccount))
            {
                SqlParameter houseaccountpara = new SqlParameter("@HouseAccount", SqlDbType.VarChar, 50);
                houseaccountpara.Value = usr_corporation.HouseAccount;
                paras.Add(houseaccountpara);
            }

            SqlParameter housebankpara = new SqlParameter("@HouseBank", SqlDbType.Int, 4);
            housebankpara.Value = usr_corporation.HouseBank;
            paras.Add(housebankpara);

            if (!string.IsNullOrEmpty(usr_corporation.HousePWD))
            {
                SqlParameter housepwdpara = new SqlParameter("@HousePWD", SqlDbType.VarChar, 50);
                housepwdpara.Value = usr_corporation.HousePWD;
                paras.Add(housepwdpara);
            }

            SqlParameter serviceamountpara = new SqlParameter("@ServiceAmount", SqlDbType.Decimal, 9);
            serviceamountpara.Value = usr_corporation.ServiceAmount;
            paras.Add(serviceamountpara);

            SqlParameter corpstatuspara = new SqlParameter("@CorpStatus", SqlDbType.Int, 4);
            corpstatuspara.Value = usr_corporation.CorpStatus;
            paras.Add(corpstatuspara);

            if (!string.IsNullOrEmpty(usr_corporation.Memo))
            {
                SqlParameter memopara = new SqlParameter("@Memo", SqlDbType.VarChar, 150);
                memopara.Value = usr_corporation.Memo;
                paras.Add(memopara);
            }

            SqlParameter creatoridpara = new SqlParameter("@CreatorId", SqlDbType.Int, 4);
            creatoridpara.Value = obj.CreatorId;
            paras.Add(creatoridpara);


            return paras;
        }

        protected override IModel CreateModel(SqlDataReader dr)
        {
            Corporation corporation = new Corporation();

            int indexCorpId = dr.GetOrdinal("CorpId");
            corporation.CorpId = Convert.ToInt32(dr[indexCorpId]);
            int indexCorpCode = dr.GetOrdinal("CorpCode");
            if (dr[indexCorpCode] != DBNull.Value)
            {
                corporation.CorpCode = Convert.ToString(dr[indexCorpCode]);
            }
            int indexCorpName = dr.GetOrdinal("CorpName");
            if (dr[indexCorpName] != DBNull.Value)
            {
                corporation.CorpName = Convert.ToString(dr[indexCorpName]);
            }
            int indexCorpEName = dr.GetOrdinal("CorpEName");
            if (dr[indexCorpEName] != DBNull.Value)
            {
                corporation.CorpEName = Convert.ToString(dr[indexCorpEName]);
            }
            int indexCorpAddress = dr.GetOrdinal("CorpAddress");
            if (dr[indexCorpAddress] != DBNull.Value)
            {
                corporation.CorpAddress = Convert.ToString(dr[indexCorpAddress]);
            }
            int indexCorpContacts = dr.GetOrdinal("CorpContacts");
            if (dr[indexCorpContacts] != DBNull.Value)
            {
                corporation.CorpContacts = Convert.ToString(dr[indexCorpContacts]);
            }
            int indexCorpTel = dr.GetOrdinal("CorpTel");
            if (dr[indexCorpTel] != DBNull.Value)
            {
                corporation.CorpTel = Convert.ToString(dr[indexCorpTel]);
            }
            int indexCorpFax = dr.GetOrdinal("CorpFax");
            if (dr[indexCorpFax] != DBNull.Value)
            {
                corporation.CorpFax = Convert.ToString(dr[indexCorpFax]);
            }
            int indexCorpZip = dr.GetOrdinal("CorpZip");
            if (dr[indexCorpZip] != DBNull.Value)
            {
                corporation.CorpZip = Convert.ToString(dr[indexCorpZip]);
            }
            int indexCorpEmail = dr.GetOrdinal("CorpEmail");
            if (dr[indexCorpEmail] != DBNull.Value)
            {
                corporation.CorpEmail = Convert.ToString(dr[indexCorpEmail]);
            }
            int indexOrganizationCode = dr.GetOrdinal("OrganizationCode");
            if (dr[indexOrganizationCode] != DBNull.Value)
            {
                corporation.OrganizationCode = Convert.ToString(dr[indexOrganizationCode]);
            }
            int indexInternetPWD = dr.GetOrdinal("InternetPWD");
            if (dr[indexInternetPWD] != DBNull.Value)
            {
                corporation.InternetPWD = Convert.ToString(dr[indexInternetPWD]);
            }
            int indexSocialRegCode = dr.GetOrdinal("SocialRegCode");
            if (dr[indexSocialRegCode] != DBNull.Value)
            {
                corporation.SocialRegCode = Convert.ToString(dr[indexSocialRegCode]);
            }
            int indexPayCity = dr.GetOrdinal("PayCity");
            if (dr[indexPayCity] != DBNull.Value)
            {
                corporation.PayCity = Convert.ToInt32(dr[indexPayCity]);
            }
            int indexHouseAccount = dr.GetOrdinal("HouseAccount");
            if (dr[indexHouseAccount] != DBNull.Value)
            {
                corporation.HouseAccount = Convert.ToString(dr[indexHouseAccount]);
            }
            int indexHouseBank = dr.GetOrdinal("HouseBank");
            if (dr[indexHouseBank] != DBNull.Value)
            {
                corporation.HouseBank = Convert.ToInt32(dr[indexHouseBank]);
            }
            int indexHousePWD = dr.GetOrdinal("HousePWD");
            if (dr[indexHousePWD] != DBNull.Value)
            {
                corporation.HousePWD = Convert.ToString(dr[indexHousePWD]);
            }
            int indexServiceAmount = dr.GetOrdinal("ServiceAmount");
            if (dr[indexServiceAmount] != DBNull.Value)
            {
                corporation.ServiceAmount = Convert.ToDecimal(dr[indexServiceAmount]);
            }
            int indexCorpStatus = dr.GetOrdinal("CorpStatus");
            if (dr[indexCorpStatus] != DBNull.Value)
            {
                corporation.CorpStatus = Convert.ToInt32(dr[indexCorpStatus]);
            }
            int indexMemo = dr.GetOrdinal("Memo");
            if (dr[indexMemo] != DBNull.Value)
            {
                corporation.Memo = Convert.ToString(dr[indexMemo]);
            }
            int indexCreatorId = dr.GetOrdinal("CreatorId");
            if (dr[indexCreatorId] != DBNull.Value)
            {
                corporation.CreatorId = Convert.ToInt32(dr[indexCreatorId]);
            }
            int indexCreateTime = dr.GetOrdinal("CreateTime");
            if (dr[indexCreateTime] != DBNull.Value)
            {
                corporation.CreateTime = Convert.ToDateTime(dr[indexCreateTime]);
            }
            int indexLastModifyId = dr.GetOrdinal("LastModifyId");
            if (dr[indexLastModifyId] != DBNull.Value)
            {
                corporation.LastModifyId = Convert.ToInt32(dr[indexLastModifyId]);
            }
            int indexLastModifyTime = dr.GetOrdinal("LastModifyTime");
            if (dr[indexLastModifyTime] != DBNull.Value)
            {
                corporation.LastModifyTime = Convert.ToDateTime(dr[indexLastModifyTime]);
            }

            return corporation;
        }

        public override List<SqlParameter> CreateUpdateParameters(IModel obj)
        {
            Corporation usr_corporation = (Corporation)obj;

            List<SqlParameter> paras = new List<SqlParameter>();

            SqlParameter corpidpara = new SqlParameter("@CorpId", SqlDbType.Int, 4);
            corpidpara.Value = usr_corporation.CorpId;
            paras.Add(corpidpara);

            if (!string.IsNullOrEmpty(usr_corporation.CorpCode))
            {
                SqlParameter corpcodepara = new SqlParameter("@CorpCode", SqlDbType.VarChar, 50);
                corpcodepara.Value = usr_corporation.CorpCode;
                paras.Add(corpcodepara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.CorpName))
            {
                SqlParameter corpnamepara = new SqlParameter("@CorpName", SqlDbType.VarChar, 50);
                corpnamepara.Value = usr_corporation.CorpName;
                paras.Add(corpnamepara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.CorpEName))
            {
                SqlParameter corpenamepara = new SqlParameter("@CorpEName", SqlDbType.VarChar, 50);
                corpenamepara.Value = usr_corporation.CorpEName;
                paras.Add(corpenamepara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.CorpAddress))
            {
                SqlParameter corpaddresspara = new SqlParameter("@CorpAddress", SqlDbType.VarChar, 150);
                corpaddresspara.Value = usr_corporation.CorpAddress;
                paras.Add(corpaddresspara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.CorpContacts))
            {
                SqlParameter corpcontactspara = new SqlParameter("@CorpContacts", SqlDbType.VarChar, 50);
                corpcontactspara.Value = usr_corporation.CorpContacts;
                paras.Add(corpcontactspara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.CorpTel))
            {
                SqlParameter corptelpara = new SqlParameter("@CorpTel", SqlDbType.VarChar, 50);
                corptelpara.Value = usr_corporation.CorpTel;
                paras.Add(corptelpara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.CorpFax))
            {
                SqlParameter corpfaxpara = new SqlParameter("@CorpFax", SqlDbType.VarChar, 50);
                corpfaxpara.Value = usr_corporation.CorpFax;
                paras.Add(corpfaxpara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.CorpZip))
            {
                SqlParameter corpzippara = new SqlParameter("@CorpZip", SqlDbType.VarChar, 50);
                corpzippara.Value = usr_corporation.CorpZip;
                paras.Add(corpzippara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.CorpEmail))
            {
                SqlParameter corpemailpara = new SqlParameter("@CorpEmail", SqlDbType.VarChar, 50);
                corpemailpara.Value = usr_corporation.CorpEmail;
                paras.Add(corpemailpara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.OrganizationCode))
            {
                SqlParameter organizationcodepara = new SqlParameter("@OrganizationCode", SqlDbType.VarChar, 50);
                organizationcodepara.Value = usr_corporation.OrganizationCode;
                paras.Add(organizationcodepara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.InternetPWD))
            {
                SqlParameter internetpwdpara = new SqlParameter("@InternetPWD", SqlDbType.VarChar, 50);
                internetpwdpara.Value = usr_corporation.InternetPWD;
                paras.Add(internetpwdpara);
            }

            if (!string.IsNullOrEmpty(usr_corporation.SocialRegCode))
            {
                SqlParameter socialregcodepara = new SqlParameter("@SocialRegCode", SqlDbType.VarChar, 50);
                socialregcodepara.Value = usr_corporation.SocialRegCode;
                paras.Add(socialregcodepara);
            }

            SqlParameter paycitypara = new SqlParameter("@PayCity", SqlDbType.Int, 4);
            paycitypara.Value = usr_corporation.PayCity;
            paras.Add(paycitypara);

            if (!string.IsNullOrEmpty(usr_corporation.HouseAccount))
            {
                SqlParameter houseaccountpara = new SqlParameter("@HouseAccount", SqlDbType.VarChar, 50);
                houseaccountpara.Value = usr_corporation.HouseAccount;
                paras.Add(houseaccountpara);
            }

            SqlParameter housebankpara = new SqlParameter("@HouseBank", SqlDbType.Int, 4);
            housebankpara.Value = usr_corporation.HouseBank;
            paras.Add(housebankpara);

            if (!string.IsNullOrEmpty(usr_corporation.HousePWD))
            {
                SqlParameter housepwdpara = new SqlParameter("@HousePWD", SqlDbType.VarChar, 50);
                housepwdpara.Value = usr_corporation.HousePWD;
                paras.Add(housepwdpara);
            }

            SqlParameter serviceamountpara = new SqlParameter("@ServiceAmount", SqlDbType.Decimal, 9);
            serviceamountpara.Value = usr_corporation.ServiceAmount;
            paras.Add(serviceamountpara);

            SqlParameter corpstatuspara = new SqlParameter("@CorpStatus", SqlDbType.Int, 4);
            corpstatuspara.Value = usr_corporation.CorpStatus;
            paras.Add(corpstatuspara);

            if (!string.IsNullOrEmpty(usr_corporation.Memo))
            {
                SqlParameter memopara = new SqlParameter("@Memo", SqlDbType.VarChar, 150);
                memopara.Value = usr_corporation.Memo;
                paras.Add(memopara);
            }

            SqlParameter lastmodifyidpara = new SqlParameter("@LastModifyId", SqlDbType.Int, 4);
            lastmodifyidpara.Value = obj.LastModifyId;
            paras.Add(lastmodifyidpara);


            return paras;
        }

        public ResultModel LoadCorporationList(int pageIndex, int pageSize, string orderStr,int corpId)
        {
            SelectModel select = sql_insrance.CorporationListSelect(pageIndex, pageSize, orderStr, corpId);
            ResultModel result = Load(select);

            return result;
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
