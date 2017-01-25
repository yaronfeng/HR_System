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

            SqlParameter pensioninsnumpara = new SqlParameter("@PensionInsNum", SqlDbType.Decimal, 9);
            pensioninsnumpara.Value = bd_socialbase.PensionInsNum;
            paras.Add(pensioninsnumpara);

            SqlParameter medicalinsnumpara = new SqlParameter("@MedicalInsNum", SqlDbType.Decimal, 9);
            medicalinsnumpara.Value = bd_socialbase.MedicalInsNum;
            paras.Add(medicalinsnumpara);

            SqlParameter unempinsnumpara = new SqlParameter("@UnempInsNum", SqlDbType.Decimal, 9);
            unempinsnumpara.Value = bd_socialbase.UnempInsNum;
            paras.Add(unempinsnumpara);

            SqlParameter injuryinsnumpara = new SqlParameter("@InjuryInsNum", SqlDbType.Decimal, 9);
            injuryinsnumpara.Value = bd_socialbase.InjuryInsNum;
            paras.Add(injuryinsnumpara);

            SqlParameter birthinsnumpara = new SqlParameter("@BirthInsNum", SqlDbType.Decimal, 9);
            birthinsnumpara.Value = bd_socialbase.BirthInsNum;
            paras.Add(birthinsnumpara);

            SqlParameter disabledinsnumpara = new SqlParameter("@DisabledInsNum", SqlDbType.Decimal, 9);
            disabledinsnumpara.Value = bd_socialbase.DisabledInsNum;
            paras.Add(disabledinsnumpara);

            SqlParameter illnessinsnumpara = new SqlParameter("@IllnessInsNum", SqlDbType.Decimal, 9);
            illnessinsnumpara.Value = bd_socialbase.IllnessInsNum;
            paras.Add(illnessinsnumpara);

            SqlParameter heatamountnumpara = new SqlParameter("@HeatAmountNum", SqlDbType.Decimal, 9);
            heatamountnumpara.Value = bd_socialbase.HeatAmountNum;
            paras.Add(heatamountnumpara);

            SqlParameter housefundinumpara = new SqlParameter("@HouseFundINum", SqlDbType.Decimal, 9);
            housefundinumpara.Value = bd_socialbase.HouseFundINum;
            paras.Add(housefundinumpara);

            SqlParameter repinjuryinsnumpara = new SqlParameter("@RepInjuryInsNum", SqlDbType.Decimal, 9);
            repinjuryinsnumpara.Value = bd_socialbase.RepInjuryInsNum;
            paras.Add(repinjuryinsnumpara);

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

            SqlParameter pensioninsfixpara = new SqlParameter("@PensionInsFix", SqlDbType.Decimal, 9);
            pensioninsfixpara.Value = bd_socialbase.PensionInsFix;
            paras.Add(pensioninsfixpara);

            SqlParameter medicalinsfixpara = new SqlParameter("@MedicalInsFix", SqlDbType.Decimal, 9);
            medicalinsfixpara.Value = bd_socialbase.MedicalInsFix;
            paras.Add(medicalinsfixpara);

            SqlParameter unempinsfixpara = new SqlParameter("@UnempInsFix", SqlDbType.Decimal, 9);
            unempinsfixpara.Value = bd_socialbase.UnempInsFix;
            paras.Add(unempinsfixpara);

            SqlParameter injuryinsfixpara = new SqlParameter("@InjuryInsFix", SqlDbType.Decimal, 9);
            injuryinsfixpara.Value = bd_socialbase.InjuryInsFix;
            paras.Add(injuryinsfixpara);

            SqlParameter birthinsfixpara = new SqlParameter("@BirthInsFix", SqlDbType.Decimal, 9);
            birthinsfixpara.Value = bd_socialbase.BirthInsFix;
            paras.Add(birthinsfixpara);

            SqlParameter disabledinsfixpara = new SqlParameter("@DisabledInsFix", SqlDbType.Decimal, 9);
            disabledinsfixpara.Value = bd_socialbase.DisabledInsFix;
            paras.Add(disabledinsfixpara);

            SqlParameter illnessinsfixpara = new SqlParameter("@IllnessInsFix", SqlDbType.Decimal, 9);
            illnessinsfixpara.Value = bd_socialbase.IllnessInsFix;
            paras.Add(illnessinsfixpara);

            SqlParameter heatamountfixpara = new SqlParameter("@HeatAmountFix", SqlDbType.Decimal, 9);
            heatamountfixpara.Value = bd_socialbase.HeatAmountFix;
            paras.Add(heatamountfixpara);

            SqlParameter housefundfixpara = new SqlParameter("@HouseFundFix", SqlDbType.Decimal, 9);
            housefundfixpara.Value = bd_socialbase.HouseFundFix;
            paras.Add(housefundfixpara);

            SqlParameter repinjuryinsfixpara = new SqlParameter("@RepInjuryInsFix", SqlDbType.Decimal, 9);
            repinjuryinsfixpara.Value = bd_socialbase.RepInjuryInsFix;
            paras.Add(repinjuryinsfixpara);


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
            int indexPensionInsNum = dr.GetOrdinal("PensionInsNum");
            if (dr[indexPensionInsNum] != DBNull.Value)
            {
                socialbase.PensionInsNum = Convert.ToDecimal(dr[indexPensionInsNum]);
            }
            int indexMedicalInsNum = dr.GetOrdinal("MedicalInsNum");
            if (dr[indexMedicalInsNum] != DBNull.Value)
            {
                socialbase.MedicalInsNum = Convert.ToDecimal(dr[indexMedicalInsNum]);
            }
            int indexUnempInsNum = dr.GetOrdinal("UnempInsNum");
            if (dr[indexUnempInsNum] != DBNull.Value)
            {
                socialbase.UnempInsNum = Convert.ToDecimal(dr[indexUnempInsNum]);
            }
            int indexInjuryInsNum = dr.GetOrdinal("InjuryInsNum");
            if (dr[indexInjuryInsNum] != DBNull.Value)
            {
                socialbase.InjuryInsNum = Convert.ToDecimal(dr[indexInjuryInsNum]);
            }
            int indexBirthInsNum = dr.GetOrdinal("BirthInsNum");
            if (dr[indexBirthInsNum] != DBNull.Value)
            {
                socialbase.BirthInsNum = Convert.ToDecimal(dr[indexBirthInsNum]);
            }
            int indexDisabledInsNum = dr.GetOrdinal("DisabledInsNum");
            if (dr[indexDisabledInsNum] != DBNull.Value)
            {
                socialbase.DisabledInsNum = Convert.ToDecimal(dr[indexDisabledInsNum]);
            }
            int indexIllnessInsNum = dr.GetOrdinal("IllnessInsNum");
            if (dr[indexIllnessInsNum] != DBNull.Value)
            {
                socialbase.IllnessInsNum = Convert.ToDecimal(dr[indexIllnessInsNum]);
            }
            int indexHeatAmountNum = dr.GetOrdinal("HeatAmountNum");
            if (dr[indexHeatAmountNum] != DBNull.Value)
            {
                socialbase.HeatAmountNum = Convert.ToDecimal(dr[indexHeatAmountNum]);
            }
            int indexHouseFundINum = dr.GetOrdinal("HouseFundINum");
            if (dr[indexHouseFundINum] != DBNull.Value)
            {
                socialbase.HouseFundINum = Convert.ToDecimal(dr[indexHouseFundINum]);
            }
            int indexRepInjuryInsNum = dr.GetOrdinal("RepInjuryInsNum");
            if (dr[indexRepInjuryInsNum] != DBNull.Value)
            {
                socialbase.RepInjuryInsNum = Convert.ToDecimal(dr[indexRepInjuryInsNum]);
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
            int indexPensionInsFix = dr.GetOrdinal("PensionInsFix");
            if (dr[indexPensionInsFix] != DBNull.Value)
            {
                socialbase.PensionInsFix = Convert.ToDecimal(dr[indexPensionInsFix]);
            }
            int indexMedicalInsFix = dr.GetOrdinal("MedicalInsFix");
            if (dr[indexMedicalInsFix] != DBNull.Value)
            {
                socialbase.MedicalInsFix = Convert.ToDecimal(dr[indexMedicalInsFix]);
            }
            int indexUnempInsFix = dr.GetOrdinal("UnempInsFix");
            if (dr[indexUnempInsFix] != DBNull.Value)
            {
                socialbase.UnempInsFix = Convert.ToDecimal(dr[indexUnempInsFix]);
            }
            int indexInjuryInsFix = dr.GetOrdinal("InjuryInsFix");
            if (dr[indexInjuryInsFix] != DBNull.Value)
            {
                socialbase.InjuryInsFix = Convert.ToDecimal(dr[indexInjuryInsFix]);
            }
            int indexBirthInsFix = dr.GetOrdinal("BirthInsFix");
            if (dr[indexBirthInsFix] != DBNull.Value)
            {
                socialbase.BirthInsFix = Convert.ToDecimal(dr[indexBirthInsFix]);
            }
            int indexDisabledInsFix = dr.GetOrdinal("DisabledInsFix");
            if (dr[indexDisabledInsFix] != DBNull.Value)
            {
                socialbase.DisabledInsFix = Convert.ToDecimal(dr[indexDisabledInsFix]);
            }
            int indexIllnessInsFix = dr.GetOrdinal("IllnessInsFix");
            if (dr[indexIllnessInsFix] != DBNull.Value)
            {
                socialbase.IllnessInsFix = Convert.ToDecimal(dr[indexIllnessInsFix]);
            }
            int indexHeatAmountFix = dr.GetOrdinal("HeatAmountFix");
            if (dr[indexHeatAmountFix] != DBNull.Value)
            {
                socialbase.HeatAmountFix = Convert.ToDecimal(dr[indexHeatAmountFix]);
            }
            int indexHouseFundFix = dr.GetOrdinal("HouseFundFix");
            if (dr[indexHouseFundFix] != DBNull.Value)
            {
                socialbase.HouseFundFix = Convert.ToDecimal(dr[indexHouseFundFix]);
            }
            int indexRepInjuryInsFix = dr.GetOrdinal("RepInjuryInsFix");
            if (dr[indexRepInjuryInsFix] != DBNull.Value)
            {
                socialbase.RepInjuryInsFix = Convert.ToDecimal(dr[indexRepInjuryInsFix]);
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

            SqlParameter pensioninsnumpara = new SqlParameter("@PensionInsNum", SqlDbType.Decimal, 9);
            pensioninsnumpara.Value = bd_socialbase.PensionInsNum;
            paras.Add(pensioninsnumpara);

            SqlParameter medicalinsnumpara = new SqlParameter("@MedicalInsNum", SqlDbType.Decimal, 9);
            medicalinsnumpara.Value = bd_socialbase.MedicalInsNum;
            paras.Add(medicalinsnumpara);

            SqlParameter unempinsnumpara = new SqlParameter("@UnempInsNum", SqlDbType.Decimal, 9);
            unempinsnumpara.Value = bd_socialbase.UnempInsNum;
            paras.Add(unempinsnumpara);

            SqlParameter injuryinsnumpara = new SqlParameter("@InjuryInsNum", SqlDbType.Decimal, 9);
            injuryinsnumpara.Value = bd_socialbase.InjuryInsNum;
            paras.Add(injuryinsnumpara);

            SqlParameter birthinsnumpara = new SqlParameter("@BirthInsNum", SqlDbType.Decimal, 9);
            birthinsnumpara.Value = bd_socialbase.BirthInsNum;
            paras.Add(birthinsnumpara);

            SqlParameter disabledinsnumpara = new SqlParameter("@DisabledInsNum", SqlDbType.Decimal, 9);
            disabledinsnumpara.Value = bd_socialbase.DisabledInsNum;
            paras.Add(disabledinsnumpara);

            SqlParameter illnessinsnumpara = new SqlParameter("@IllnessInsNum", SqlDbType.Decimal, 9);
            illnessinsnumpara.Value = bd_socialbase.IllnessInsNum;
            paras.Add(illnessinsnumpara);

            SqlParameter heatamountnumpara = new SqlParameter("@HeatAmountNum", SqlDbType.Decimal, 9);
            heatamountnumpara.Value = bd_socialbase.HeatAmountNum;
            paras.Add(heatamountnumpara);

            SqlParameter housefundinumpara = new SqlParameter("@HouseFundINum", SqlDbType.Decimal, 9);
            housefundinumpara.Value = bd_socialbase.HouseFundINum;
            paras.Add(housefundinumpara);

            SqlParameter repinjuryinsnumpara = new SqlParameter("@RepInjuryInsNum", SqlDbType.Decimal, 9);
            repinjuryinsnumpara.Value = bd_socialbase.RepInjuryInsNum;
            paras.Add(repinjuryinsnumpara);

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

            SqlParameter pensioninsfixpara = new SqlParameter("@PensionInsFix", SqlDbType.Decimal, 9);
            pensioninsfixpara.Value = bd_socialbase.PensionInsFix;
            paras.Add(pensioninsfixpara);

            SqlParameter medicalinsfixpara = new SqlParameter("@MedicalInsFix", SqlDbType.Decimal, 9);
            medicalinsfixpara.Value = bd_socialbase.MedicalInsFix;
            paras.Add(medicalinsfixpara);

            SqlParameter unempinsfixpara = new SqlParameter("@UnempInsFix", SqlDbType.Decimal, 9);
            unempinsfixpara.Value = bd_socialbase.UnempInsFix;
            paras.Add(unempinsfixpara);

            SqlParameter injuryinsfixpara = new SqlParameter("@InjuryInsFix", SqlDbType.Decimal, 9);
            injuryinsfixpara.Value = bd_socialbase.InjuryInsFix;
            paras.Add(injuryinsfixpara);

            SqlParameter birthinsfixpara = new SqlParameter("@BirthInsFix", SqlDbType.Decimal, 9);
            birthinsfixpara.Value = bd_socialbase.BirthInsFix;
            paras.Add(birthinsfixpara);

            SqlParameter disabledinsfixpara = new SqlParameter("@DisabledInsFix", SqlDbType.Decimal, 9);
            disabledinsfixpara.Value = bd_socialbase.DisabledInsFix;
            paras.Add(disabledinsfixpara);

            SqlParameter illnessinsfixpara = new SqlParameter("@IllnessInsFix", SqlDbType.Decimal, 9);
            illnessinsfixpara.Value = bd_socialbase.IllnessInsFix;
            paras.Add(illnessinsfixpara);

            SqlParameter heatamountfixpara = new SqlParameter("@HeatAmountFix", SqlDbType.Decimal, 9);
            heatamountfixpara.Value = bd_socialbase.HeatAmountFix;
            paras.Add(heatamountfixpara);

            SqlParameter housefundfixpara = new SqlParameter("@HouseFundFix", SqlDbType.Decimal, 9);
            housefundfixpara.Value = bd_socialbase.HouseFundFix;
            paras.Add(housefundfixpara);

            SqlParameter repinjuryinsfixpara = new SqlParameter("@RepInjuryInsFix", SqlDbType.Decimal, 9);
            repinjuryinsfixpara.Value = bd_socialbase.RepInjuryInsFix;
            paras.Add(repinjuryinsfixpara);


            return paras;
        }
    }
}
