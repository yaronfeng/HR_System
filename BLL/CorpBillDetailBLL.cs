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
    public class CorpBillDetailBLL : Operate
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public CorpBillDetailBLL()
        {
        }

        #endregion

        protected override List<SqlParameter> CreateInsertParameters(IModel obj, ref SqlParameter returnValue)
        {
            CorpBillDetail usr_corpbilldetail = (CorpBillDetail)obj;

            List<SqlParameter> paras = new List<SqlParameter>();
            returnValue.Direction = ParameterDirection.Output;
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.ParameterName = "@DetailId";
            returnValue.Size = 4;
            paras.Add(returnValue);

            SqlParameter corpbillidpara = new SqlParameter("@CorpBillId", SqlDbType.Int, 4);
            corpbillidpara.Value = usr_corpbilldetail.CorpBillId;
            paras.Add(corpbillidpara);

            SqlParameter empsalaryidpara = new SqlParameter("@EmpSalaryId", SqlDbType.Int, 4);
            empsalaryidpara.Value = usr_corpbilldetail.EmpSalaryId;
            paras.Add(empsalaryidpara);

            SqlParameter serviceamountpara = new SqlParameter("@ServiceAmount", SqlDbType.Decimal, 9);
            serviceamountpara.Value = usr_corpbilldetail.ServiceAmount;
            paras.Add(serviceamountpara);

            SqlParameter detailstatuspara = new SqlParameter("@DetailStatus", SqlDbType.Int, 4);
            detailstatuspara.Value = usr_corpbilldetail.DetailStatus;
            paras.Add(detailstatuspara);

            SqlParameter creatoridpara = new SqlParameter("@CreatorId", SqlDbType.Int, 4);
            creatoridpara.Value = obj.CreatorId;
            paras.Add(creatoridpara);


            return paras;
        }


        protected override IModel CreateModel(SqlDataReader dr)
        {
            CorpBillDetail corpbilldetail = new CorpBillDetail();

            int indexDetailId = dr.GetOrdinal("DetailId");
            corpbilldetail.DetailId = Convert.ToInt32(dr[indexDetailId]);
            int indexCorpBillId = dr.GetOrdinal("CorpBillId");
            if (dr[indexCorpBillId] != DBNull.Value)
            {
                corpbilldetail.CorpBillId = Convert.ToInt32(dr[indexCorpBillId]);
            }
            int indexEmpSalaryId = dr.GetOrdinal("EmpSalaryId");
            if (dr[indexEmpSalaryId] != DBNull.Value)
            {
                corpbilldetail.EmpSalaryId = Convert.ToInt32(dr[indexEmpSalaryId]);
            }
            int indexServiceAmount = dr.GetOrdinal("ServiceAmount");
            if (dr[indexServiceAmount] != DBNull.Value)
            {
                corpbilldetail.ServiceAmount = Convert.ToDecimal(dr[indexServiceAmount]);
            }
            int indexDetailStatus = dr.GetOrdinal("DetailStatus");
            if (dr[indexDetailStatus] != DBNull.Value)
            {
                corpbilldetail.DetailStatus = Convert.ToInt32(dr[indexDetailStatus]);
            }
            int indexCreatorId = dr.GetOrdinal("CreatorId");
            if (dr[indexCreatorId] != DBNull.Value)
            {
                corpbilldetail.CreatorId = Convert.ToInt32(dr[indexCreatorId]);
            }
            int indexCreateTime = dr.GetOrdinal("CreateTime");
            if (dr[indexCreateTime] != DBNull.Value)
            {
                corpbilldetail.CreateTime = Convert.ToDateTime(dr[indexCreateTime]);
            }
            int indexLastModifyId = dr.GetOrdinal("LastModifyId");
            if (dr[indexLastModifyId] != DBNull.Value)
            {
                corpbilldetail.LastModifyId = Convert.ToInt32(dr[indexLastModifyId]);
            }
            int indexLastModifyTime = dr.GetOrdinal("LastModifyTime");
            if (dr[indexLastModifyTime] != DBNull.Value)
            {
                corpbilldetail.LastModifyTime = Convert.ToDateTime(dr[indexLastModifyTime]);
            }

            return corpbilldetail;
        }

        public override string TableName
        {
            get
            {
                return "Usr_CorpBillDetail";
            }
        }

        public override List<SqlParameter> CreateUpdateParameters(IModel obj)
        {
            CorpBillDetail usr_corpbilldetail = (CorpBillDetail)obj;

            List<SqlParameter> paras = new List<SqlParameter>();

            SqlParameter detailidpara = new SqlParameter("@DetailId", SqlDbType.Int, 4);
            detailidpara.Value = usr_corpbilldetail.DetailId;
            paras.Add(detailidpara);

            SqlParameter corpbillidpara = new SqlParameter("@CorpBillId", SqlDbType.Int, 4);
            corpbillidpara.Value = usr_corpbilldetail.CorpBillId;
            paras.Add(corpbillidpara);

            SqlParameter empsalaryidpara = new SqlParameter("@EmpSalaryId", SqlDbType.Int, 4);
            empsalaryidpara.Value = usr_corpbilldetail.EmpSalaryId;
            paras.Add(empsalaryidpara);

            SqlParameter serviceamountpara = new SqlParameter("@ServiceAmount", SqlDbType.Decimal, 9);
            serviceamountpara.Value = usr_corpbilldetail.ServiceAmount;
            paras.Add(serviceamountpara);

            SqlParameter detailstatuspara = new SqlParameter("@DetailStatus", SqlDbType.Int, 4);
            detailstatuspara.Value = usr_corpbilldetail.DetailStatus;
            paras.Add(detailstatuspara);

            SqlParameter lastmodifyidpara = new SqlParameter("@LastModifyId", SqlDbType.Int, 4);
            lastmodifyidpara.Value = obj.LastModifyId;
            paras.Add(lastmodifyidpara);


            return paras;
        }
    }
}
