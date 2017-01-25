using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Common;

namespace HR.Model
{
    public class SocialBase : MasterModel
    {
        #region 字段

        private int socId;
        private int cityId;
        private string socName = String.Empty;
        private decimal pensionInsNum;
        private decimal medicalInsNum;
        private decimal unempInsNum;
        private decimal injuryInsNum;
        private decimal birthInsNum;
        private decimal disabledInsNum;
        private decimal illnessInsNum;
        private decimal heatAmountNum;
        private decimal houseFundINum;
        private decimal repInjuryInsNum;
        private decimal corpPensionInsPoint;
        private decimal corpMedicalInsPoint;
        private decimal corpUnempInsPoint;
        private decimal corpInjuryInsPoint;
        private decimal corpBirthInsPoint;
        private decimal corpDisabledInsPoint;
        private decimal corpIllnessInsPoint;
        private decimal corpHeatAmountPoint;
        private decimal corpHouseFundPoint;
        private decimal corpRepInjuryInsPoint;
        private decimal empPensionInsPoint;
        private decimal empMedicalInsPoint;
        private decimal empUnempInsPoint;
        private decimal empInjuryInsPoint;
        private decimal empBirthInsPoint;
        private decimal empDisabledInsPoint;
        private decimal empIllnessInsPoint;
        private decimal empHeatAmountPoint;
        private decimal empHouseFundPoint;
        private decimal empRepInjuryInsPoint;
        private decimal pensionInsFix;
        private decimal medicalInsFix;
        private decimal unempInsFix;
        private decimal injuryInsFix;
        private decimal birthInsFix;
        private decimal disabledInsFix;
        private decimal illnessInsFix;
        private decimal heatAmountFix;
        private decimal houseFundFix;
        private decimal repInjuryInsFix;
        #endregion

        #region 构造函数

        public SocialBase()
        {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 
        /// </summary>
        public int SocId
        {
            get { return socId; }
            set { socId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public int CityId
        {
            get { return cityId; }
            set { cityId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public string SocName
        {
            get { return socName; }
            set { socName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal PensionInsNum
        {
            get { return pensionInsNum; }
            set { pensionInsNum = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal MedicalInsNum
        {
            get { return medicalInsNum; }
            set { medicalInsNum = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal UnempInsNum
        {
            get { return unempInsNum; }
            set { unempInsNum = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal InjuryInsNum
        {
            get { return injuryInsNum; }
            set { injuryInsNum = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal BirthInsNum
        {
            get { return birthInsNum; }
            set { birthInsNum = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal DisabledInsNum
        {
            get { return disabledInsNum; }
            set { disabledInsNum = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal IllnessInsNum
        {
            get { return illnessInsNum; }
            set { illnessInsNum = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal HeatAmountNum
        {
            get { return heatAmountNum; }
            set { heatAmountNum = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal HouseFundINum
        {
            get { return houseFundINum; }
            set { houseFundINum = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal RepInjuryInsNum
        {
            get { return repInjuryInsNum; }
            set { repInjuryInsNum = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal CorpPensionInsPoint
        {
            get { return corpPensionInsPoint; }
            set { corpPensionInsPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal CorpMedicalInsPoint
        {
            get { return corpMedicalInsPoint; }
            set { corpMedicalInsPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal CorpUnempInsPoint
        {
            get { return corpUnempInsPoint; }
            set { corpUnempInsPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal CorpInjuryInsPoint
        {
            get { return corpInjuryInsPoint; }
            set { corpInjuryInsPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal CorpBirthInsPoint
        {
            get { return corpBirthInsPoint; }
            set { corpBirthInsPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal CorpDisabledInsPoint
        {
            get { return corpDisabledInsPoint; }
            set { corpDisabledInsPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal CorpIllnessInsPoint
        {
            get { return corpIllnessInsPoint; }
            set { corpIllnessInsPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal CorpHeatAmountPoint
        {
            get { return corpHeatAmountPoint; }
            set { corpHeatAmountPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal CorpHouseFundPoint
        {
            get { return corpHouseFundPoint; }
            set { corpHouseFundPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal CorpRepInjuryInsPoint
        {
            get { return corpRepInjuryInsPoint; }
            set { corpRepInjuryInsPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal EmpPensionInsPoint
        {
            get { return empPensionInsPoint; }
            set { empPensionInsPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal EmpMedicalInsPoint
        {
            get { return empMedicalInsPoint; }
            set { empMedicalInsPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal EmpUnempInsPoint
        {
            get { return empUnempInsPoint; }
            set { empUnempInsPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal EmpInjuryInsPoint
        {
            get { return empInjuryInsPoint; }
            set { empInjuryInsPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal EmpBirthInsPoint
        {
            get { return empBirthInsPoint; }
            set { empBirthInsPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal EmpDisabledInsPoint
        {
            get { return empDisabledInsPoint; }
            set { empDisabledInsPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal EmpIllnessInsPoint
        {
            get { return empIllnessInsPoint; }
            set { empIllnessInsPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal EmpHeatAmountPoint
        {
            get { return empHeatAmountPoint; }
            set { empHeatAmountPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal EmpHouseFundPoint
        {
            get { return empHouseFundPoint; }
            set { empHouseFundPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal EmpRepInjuryInsPoint
        {
            get { return empRepInjuryInsPoint; }
            set { empRepInjuryInsPoint = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal PensionInsFix
        {
            get { return pensionInsFix; }
            set { pensionInsFix = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal MedicalInsFix
        {
            get { return medicalInsFix; }
            set { medicalInsFix = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal UnempInsFix
        {
            get { return unempInsFix; }
            set { unempInsFix = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal InjuryInsFix
        {
            get { return injuryInsFix; }
            set { injuryInsFix = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal BirthInsFix
        {
            get { return birthInsFix; }
            set { birthInsFix = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal DisabledInsFix
        {
            get { return disabledInsFix; }
            set { disabledInsFix = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal IllnessInsFix
        {
            get { return illnessInsFix; }
            set { illnessInsFix = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal HeatAmountFix
        {
            get { return heatAmountFix; }
            set { heatAmountFix = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal HouseFundFix
        {
            get { return houseFundFix; }
            set { houseFundFix = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal RepInjuryInsFix
        {
            get { return repInjuryInsFix; }
            set { repInjuryInsFix = value; }
        }
        #endregion
    }
}
