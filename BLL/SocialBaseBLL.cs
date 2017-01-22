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
    public class SocialBaseBLL : Operate
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SocialBaseBLL()
        {
        }

        private SocialBaseSQL sql_insrance = new SocialBaseSQL();

        public ResultModel LoadSocialBaseList(int pageIndex, int pageSize, string orderStr)
        {
            SelectModel select = sql_insrance.SocialBaseListSelect(pageIndex, pageSize, orderStr);
            ResultModel result = Load(select);

            return result;
        }

        protected override List<SqlParameter> CreateInsertParameters(IModel obj, ref SqlParameter returnValue)
        {
            SocialBase bd_socialbase = (SocialBase)obj;

            List<SqlParameter> paras = new List<SqlParameter>();
            returnValue.Direction = ParameterDirection.Output;
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.ParameterName = "@SocId";
            returnValue.Size = 4;
            paras.Add(returnValue);

            SqlParameter cityidpara = new SqlParameter("@CityId", SqlDbType.Int, 4);
            cityidpara.Value = bd_socialbase.CityId;
            paras.Add(cityidpara);

            if (!string.IsNullOrEmpty(bd_socialbase.SocName))
            {
                SqlParameter socnamepara = new SqlParameter("@SocName", SqlDbType.VarChar, 50);
                socnamepara.Value = bd_socialbase.SocName;
                paras.Add(socnamepara);
            }

            SqlParameter socialfundnumpara = new SqlParameter("@SocialFundNum", SqlDbType.Decimal, 9);
            socialfundnumpara.Value = bd_socialbase.SocialFundNum;
            paras.Add(socialfundnumpara);

            SqlParameter housefundnumpara = new SqlParameter("@HouseFundNum", SqlDbType.Decimal, 9);
            housefundnumpara.Value = bd_socialbase.HouseFundNum;
            paras.Add(housefundnumpara);

            SqlParameter corppensioninspointpara = new SqlParameter("@CorpPensionInsPoint", SqlDbType.Decimal, 9);
            corppensioninspointpara.Value = bd_socialbase.CorpPensionInsPoint;
            paras.Add(corppensioninspointpara);

            SqlParameter corpmedicalinspointpara = new SqlParameter("@CorpMedicalInsPoint", SqlDbType.Decimal, 9);
            corpmedicalinspointpara.Value = bd_socialbase.CorpMedicalInsPoint;
            paras.Add(corpmedicalinspointpara);

            SqlParameter corpunempinspointpara = new SqlParameter("@CorpUnempInsPoint", SqlDbType.Decimal, 9);
            corpunempinspointpara.Value = bd_socialbase.CorpUnempInsPoint;
            paras.Add(corpunempinspointpara);

            SqlParameter corpinjuryinspointpara = new SqlParameter("@CorpInjuryInsPoint", SqlDbType.Decimal, 9);
            corpinjuryinspointpara.Value = bd_socialbase.CorpInjuryInsPoint;
            paras.Add(corpinjuryinspointpara);

            SqlParameter corpbirthinspointpara = new SqlParameter("@CorpBirthInsPoint", SqlDbType.Decimal, 9);
            corpbirthinspointpara.Value = bd_socialbase.CorpBirthInsPoint;
            paras.Add(corpbirthinspointpara);

            SqlParameter corpdisabledinspointpara = new SqlParameter("@CorpDisabledInsPoint", SqlDbType.Decimal, 9);
            corpdisabledinspointpara.Value = bd_socialbase.CorpDisabledInsPoint;
            paras.Add(corpdisabledinspointpara);

            SqlParameter corpillnessinspointpara = new SqlParameter("@CorpIllnessInsPoint", SqlDbType.Decimal, 9);
            corpillnessinspointpara.Value = bd_socialbase.CorpIllnessInsPoint;
            paras.Add(corpillnessinspointpara);

            SqlParameter corpheatamountpointpara = new SqlParameter("@CorpHeatAmountPoint", SqlDbType.Decimal, 9);
            corpheatamountpointpara.Value = bd_socialbase.CorpHeatAmountPoint;
            paras.Add(corpheatamountpointpara);

            SqlParameter corphousefundpointpara = new SqlParameter("@CorpHouseFundPoint", SqlDbType.Decimal, 9);
            corphousefundpointpara.Value = bd_socialbase.CorpHouseFundPoint;
            paras.Add(corphousefundpointpara);

            SqlParameter corprepinjuryinspointpara = new SqlParameter("@CorpRepInjuryInsPoint", SqlDbType.Decimal, 9);
            corprepinjuryinspointpara.Value = bd_socialbase.CorpRepInjuryInsPoint;
            paras.Add(corprepinjuryinspointpara);

            SqlParameter emppensioninspointpara = new SqlParameter("@EmpPensionInsPoint", SqlDbType.Decimal, 9);
            emppensioninspointpara.Value = bd_socialbase.EmpPensionInsPoint;
            paras.Add(emppensioninspointpara);

            SqlParameter empmedicalinspointpara = new SqlParameter("@EmpMedicalInsPoint", SqlDbType.Decimal, 9);
            empmedicalinspointpara.Value = bd_socialbase.EmpMedicalInsPoint;
            paras.Add(empmedicalinspointpara);

            SqlParameter empunempinspointpara = new SqlParameter("@EmpUnempInsPoint", SqlDbType.Decimal, 9);
            empunempinspointpara.Value = bd_socialbase.EmpUnempInsPoint;
            paras.Add(empunempinspointpara);

            SqlParameter empinjuryinspointpara = new SqlParameter("@EmpInjuryInsPoint", SqlDbType.Decimal, 9);
            empinjuryinspointpara.Value = bd_socialbase.EmpInjuryInsPoint;
            paras.Add(empinjuryinspointpara);

            SqlParameter empbirthinspointpara = new SqlParameter("@EmpBirthInsPoint", SqlDbType.Decimal, 9);
            empbirthinspointpara.Value = bd_socialbase.EmpBirthInsPoint;
            paras.Add(empbirthinspointpara);

            SqlParameter empdisabledinspointpara = new SqlParameter("@EmpDisabledInsPoint", SqlDbType.Decimal, 9);
            empdisabledinspointpara.Value = bd_socialbase.EmpDisabledInsPoint;
            paras.Add(empdisabledinspointpara);

            SqlParameter empillnessinspointpara = new SqlParameter("@EmpIllnessInsPoint", SqlDbType.Decimal, 9);
            empillnessinspointpara.Value = bd_socialbase.EmpIllnessInsPoint;
            paras.Add(empillnessinspointpara);

            SqlParameter empheatamountpointpara = new SqlParameter("@EmpHeatAmountPoint", SqlDbType.Decimal, 9);
            empheatamountpointpara.Value = bd_socialbase.EmpHeatAmountPoint;
            paras.Add(empheatamountpointpara);

            SqlParameter emphousefundpointpara = new SqlParameter("@EmpHouseFundPoint", SqlDbType.Decimal, 9);
            emphousefundpointpara.Value = bd_socialbase.EmpHouseFundPoint;
            paras.Add(emphousefundpointpara);

            SqlParameter emprepinjuryinspointpara = new SqlParameter("@EmpRepInjuryInsPoint", SqlDbType.Decimal, 9);
            emprepinjuryinspointpara.Value = bd_socialbase.EmpRepInjuryInsPoint;
            paras.Add(emprepinjuryinspointpara);


            return paras;
        }

        protected override IModel CreateModel(SqlDataReader dr)
        {
            SocialBase socialbase = new SocialBase();

            int indexSocId = dr.GetOrdinal("SocId");
            socialbase.SocId = Convert.ToInt32(dr[indexSocId]);
            int indexCityId = dr.GetOrdinal("CityId");
            socialbase.CityId = Convert.ToInt32(dr[indexCityId]);
            int indexSocName = dr.GetOrdinal("SocName");
            if (dr[indexSocName] != DBNull.Value)
            {
                socialbase.SocName = Convert.ToString(dr[indexSocName]);
            }
            int indexSocialFundNum = dr.GetOrdinal("SocialFundNum");
            if (dr[indexSocialFundNum] != DBNull.Value)
            {
                socialbase.SocialFundNum = Convert.ToDecimal(dr[indexSocialFundNum]);
            }
            int indexHouseFundNum = dr.GetOrdinal("HouseFundNum");
            if (dr[indexHouseFundNum] != DBNull.Value)
            {
                socialbase.HouseFundNum = Convert.ToDecimal(dr[indexHouseFundNum]);
            }
            int indexCorpPensionInsPoint = dr.GetOrdinal("CorpPensionInsPoint");
            if (dr[indexCorpPensionInsPoint] != DBNull.Value)
            {
                socialbase.CorpPensionInsPoint = Convert.ToDecimal(dr[indexCorpPensionInsPoint]);
            }
            int indexCorpMedicalInsPoint = dr.GetOrdinal("CorpMedicalInsPoint");
            if (dr[indexCorpMedicalInsPoint] != DBNull.Value)
            {
                socialbase.CorpMedicalInsPoint = Convert.ToDecimal(dr[indexCorpMedicalInsPoint]);
            }
            int indexCorpUnempInsPoint = dr.GetOrdinal("CorpUnempInsPoint");
            if (dr[indexCorpUnempInsPoint] != DBNull.Value)
            {
                socialbase.CorpUnempInsPoint = Convert.ToDecimal(dr[indexCorpUnempInsPoint]);
            }
            int indexCorpInjuryInsPoint = dr.GetOrdinal("CorpInjuryInsPoint");
            if (dr[indexCorpInjuryInsPoint] != DBNull.Value)
            {
                socialbase.CorpInjuryInsPoint = Convert.ToDecimal(dr[indexCorpInjuryInsPoint]);
            }
            int indexCorpBirthInsPoint = dr.GetOrdinal("CorpBirthInsPoint");
            if (dr[indexCorpBirthInsPoint] != DBNull.Value)
            {
                socialbase.CorpBirthInsPoint = Convert.ToDecimal(dr[indexCorpBirthInsPoint]);
            }
            int indexCorpDisabledInsPoint = dr.GetOrdinal("CorpDisabledInsPoint");
            if (dr[indexCorpDisabledInsPoint] != DBNull.Value)
            {
                socialbase.CorpDisabledInsPoint = Convert.ToDecimal(dr[indexCorpDisabledInsPoint]);
            }
            int indexCorpIllnessInsPoint = dr.GetOrdinal("CorpIllnessInsPoint");
            if (dr[indexCorpIllnessInsPoint] != DBNull.Value)
            {
                socialbase.CorpIllnessInsPoint = Convert.ToDecimal(dr[indexCorpIllnessInsPoint]);
            }
            int indexCorpHeatAmountPoint = dr.GetOrdinal("CorpHeatAmountPoint");
            if (dr[indexCorpHeatAmountPoint] != DBNull.Value)
            {
                socialbase.CorpHeatAmountPoint = Convert.ToDecimal(dr[indexCorpHeatAmountPoint]);
            }
            int indexCorpHouseFundPoint = dr.GetOrdinal("CorpHouseFundPoint");
            if (dr[indexCorpHouseFundPoint] != DBNull.Value)
            {
                socialbase.CorpHouseFundPoint = Convert.ToDecimal(dr[indexCorpHouseFundPoint]);
            }
            int indexCorpRepInjuryInsPoint = dr.GetOrdinal("CorpRepInjuryInsPoint");
            if (dr[indexCorpRepInjuryInsPoint] != DBNull.Value)
            {
                socialbase.CorpRepInjuryInsPoint = Convert.ToDecimal(dr[indexCorpRepInjuryInsPoint]);
            }
            int indexEmpPensionInsPoint = dr.GetOrdinal("EmpPensionInsPoint");
            if (dr[indexEmpPensionInsPoint] != DBNull.Value)
            {
                socialbase.EmpPensionInsPoint = Convert.ToDecimal(dr[indexEmpPensionInsPoint]);
            }
            int indexEmpMedicalInsPoint = dr.GetOrdinal("EmpMedicalInsPoint");
            if (dr[indexEmpMedicalInsPoint] != DBNull.Value)
            {
                socialbase.EmpMedicalInsPoint = Convert.ToDecimal(dr[indexEmpMedicalInsPoint]);
            }
            int indexEmpUnempInsPoint = dr.GetOrdinal("EmpUnempInsPoint");
            if (dr[indexEmpUnempInsPoint] != DBNull.Value)
            {
                socialbase.EmpUnempInsPoint = Convert.ToDecimal(dr[indexEmpUnempInsPoint]);
            }
            int indexEmpInjuryInsPoint = dr.GetOrdinal("EmpInjuryInsPoint");
            if (dr[indexEmpInjuryInsPoint] != DBNull.Value)
            {
                socialbase.EmpInjuryInsPoint = Convert.ToDecimal(dr[indexEmpInjuryInsPoint]);
            }
            int indexEmpBirthInsPoint = dr.GetOrdinal("EmpBirthInsPoint");
            if (dr[indexEmpBirthInsPoint] != DBNull.Value)
            {
                socialbase.EmpBirthInsPoint = Convert.ToDecimal(dr[indexEmpBirthInsPoint]);
            }
            int indexEmpDisabledInsPoint = dr.GetOrdinal("EmpDisabledInsPoint");
            if (dr[indexEmpDisabledInsPoint] != DBNull.Value)
            {
                socialbase.EmpDisabledInsPoint = Convert.ToDecimal(dr[indexEmpDisabledInsPoint]);
            }
            int indexEmpIllnessInsPoint = dr.GetOrdinal("EmpIllnessInsPoint");
            if (dr[indexEmpIllnessInsPoint] != DBNull.Value)
            {
                socialbase.EmpIllnessInsPoint = Convert.ToDecimal(dr[indexEmpIllnessInsPoint]);
            }
            int indexEmpHeatAmountPoint = dr.GetOrdinal("EmpHeatAmountPoint");
            if (dr[indexEmpHeatAmountPoint] != DBNull.Value)
            {
                socialbase.EmpHeatAmountPoint = Convert.ToDecimal(dr[indexEmpHeatAmountPoint]);
            }
            int indexEmpHouseFundPoint = dr.GetOrdinal("EmpHouseFundPoint");
            if (dr[indexEmpHouseFundPoint] != DBNull.Value)
            {
                socialbase.EmpHouseFundPoint = Convert.ToDecimal(dr[indexEmpHouseFundPoint]);
            }
            int indexEmpRepInjuryInsPoint = dr.GetOrdinal("EmpRepInjuryInsPoint");
            if (dr[indexEmpRepInjuryInsPoint] != DBNull.Value)
            {
                socialbase.EmpRepInjuryInsPoint = Convert.ToDecimal(dr[indexEmpRepInjuryInsPoint]);
            }

            return socialbase;
        }

        public override string TableName
        {
            get
            {
                return "bd_SocialBase";
            }
        }

        public override List<SqlParameter> CreateUpdateParameters(IModel obj)
        {
            SocialBase bd_socialbase = (SocialBase)obj;

            List<SqlParameter> paras = new List<SqlParameter>();

            SqlParameter socidpara = new SqlParameter("@SocId", SqlDbType.Int, 4);
            socidpara.Value = bd_socialbase.SocId;
            paras.Add(socidpara);

            SqlParameter cityidpara = new SqlParameter("@CityId", SqlDbType.Int, 4);
            cityidpara.Value = bd_socialbase.CityId;
            paras.Add(cityidpara);

            if (!string.IsNullOrEmpty(bd_socialbase.SocName))
            {
                SqlParameter socnamepara = new SqlParameter("@SocName", SqlDbType.VarChar, 50);
                socnamepara.Value = bd_socialbase.SocName;
                paras.Add(socnamepara);
            }

            SqlParameter socialfundnumpara = new SqlParameter("@SocialFundNum", SqlDbType.Decimal, 9);
            socialfundnumpara.Value = bd_socialbase.SocialFundNum;
            paras.Add(socialfundnumpara);

            SqlParameter housefundnumpara = new SqlParameter("@HouseFundNum", SqlDbType.Decimal, 9);
            housefundnumpara.Value = bd_socialbase.HouseFundNum;
            paras.Add(housefundnumpara);

            SqlParameter corppensioninspointpara = new SqlParameter("@CorpPensionInsPoint", SqlDbType.Decimal, 9);
            corppensioninspointpara.Value = bd_socialbase.CorpPensionInsPoint;
            paras.Add(corppensioninspointpara);

            SqlParameter corpmedicalinspointpara = new SqlParameter("@CorpMedicalInsPoint", SqlDbType.Decimal, 9);
            corpmedicalinspointpara.Value = bd_socialbase.CorpMedicalInsPoint;
            paras.Add(corpmedicalinspointpara);

            SqlParameter corpunempinspointpara = new SqlParameter("@CorpUnempInsPoint", SqlDbType.Decimal, 9);
            corpunempinspointpara.Value = bd_socialbase.CorpUnempInsPoint;
            paras.Add(corpunempinspointpara);

            SqlParameter corpinjuryinspointpara = new SqlParameter("@CorpInjuryInsPoint", SqlDbType.Decimal, 9);
            corpinjuryinspointpara.Value = bd_socialbase.CorpInjuryInsPoint;
            paras.Add(corpinjuryinspointpara);

            SqlParameter corpbirthinspointpara = new SqlParameter("@CorpBirthInsPoint", SqlDbType.Decimal, 9);
            corpbirthinspointpara.Value = bd_socialbase.CorpBirthInsPoint;
            paras.Add(corpbirthinspointpara);

            SqlParameter corpdisabledinspointpara = new SqlParameter("@CorpDisabledInsPoint", SqlDbType.Decimal, 9);
            corpdisabledinspointpara.Value = bd_socialbase.CorpDisabledInsPoint;
            paras.Add(corpdisabledinspointpara);

            SqlParameter corpillnessinspointpara = new SqlParameter("@CorpIllnessInsPoint", SqlDbType.Decimal, 9);
            corpillnessinspointpara.Value = bd_socialbase.CorpIllnessInsPoint;
            paras.Add(corpillnessinspointpara);

            SqlParameter corpheatamountpointpara = new SqlParameter("@CorpHeatAmountPoint", SqlDbType.Decimal, 9);
            corpheatamountpointpara.Value = bd_socialbase.CorpHeatAmountPoint;
            paras.Add(corpheatamountpointpara);

            SqlParameter corphousefundpointpara = new SqlParameter("@CorpHouseFundPoint", SqlDbType.Decimal, 9);
            corphousefundpointpara.Value = bd_socialbase.CorpHouseFundPoint;
            paras.Add(corphousefundpointpara);

            SqlParameter corprepinjuryinspointpara = new SqlParameter("@CorpRepInjuryInsPoint", SqlDbType.Decimal, 9);
            corprepinjuryinspointpara.Value = bd_socialbase.CorpRepInjuryInsPoint;
            paras.Add(corprepinjuryinspointpara);

            SqlParameter emppensioninspointpara = new SqlParameter("@EmpPensionInsPoint", SqlDbType.Decimal, 9);
            emppensioninspointpara.Value = bd_socialbase.EmpPensionInsPoint;
            paras.Add(emppensioninspointpara);

            SqlParameter empmedicalinspointpara = new SqlParameter("@EmpMedicalInsPoint", SqlDbType.Decimal, 9);
            empmedicalinspointpara.Value = bd_socialbase.EmpMedicalInsPoint;
            paras.Add(empmedicalinspointpara);

            SqlParameter empunempinspointpara = new SqlParameter("@EmpUnempInsPoint", SqlDbType.Decimal, 9);
            empunempinspointpara.Value = bd_socialbase.EmpUnempInsPoint;
            paras.Add(empunempinspointpara);

            SqlParameter empinjuryinspointpara = new SqlParameter("@EmpInjuryInsPoint", SqlDbType.Decimal, 9);
            empinjuryinspointpara.Value = bd_socialbase.EmpInjuryInsPoint;
            paras.Add(empinjuryinspointpara);

            SqlParameter empbirthinspointpara = new SqlParameter("@EmpBirthInsPoint", SqlDbType.Decimal, 9);
            empbirthinspointpara.Value = bd_socialbase.EmpBirthInsPoint;
            paras.Add(empbirthinspointpara);

            SqlParameter empdisabledinspointpara = new SqlParameter("@EmpDisabledInsPoint", SqlDbType.Decimal, 9);
            empdisabledinspointpara.Value = bd_socialbase.EmpDisabledInsPoint;
            paras.Add(empdisabledinspointpara);

            SqlParameter empillnessinspointpara = new SqlParameter("@EmpIllnessInsPoint", SqlDbType.Decimal, 9);
            empillnessinspointpara.Value = bd_socialbase.EmpIllnessInsPoint;
            paras.Add(empillnessinspointpara);

            SqlParameter empheatamountpointpara = new SqlParameter("@EmpHeatAmountPoint", SqlDbType.Decimal, 9);
            empheatamountpointpara.Value = bd_socialbase.EmpHeatAmountPoint;
            paras.Add(empheatamountpointpara);

            SqlParameter emphousefundpointpara = new SqlParameter("@EmpHouseFundPoint", SqlDbType.Decimal, 9);
            emphousefundpointpara.Value = bd_socialbase.EmpHouseFundPoint;
            paras.Add(emphousefundpointpara);

            SqlParameter emprepinjuryinspointpara = new SqlParameter("@EmpRepInjuryInsPoint", SqlDbType.Decimal, 9);
            emprepinjuryinspointpara.Value = bd_socialbase.EmpRepInjuryInsPoint;
            paras.Add(emprepinjuryinspointpara);


            return paras;
        }
    }
}
