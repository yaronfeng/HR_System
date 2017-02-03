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
    public class BillDetailBLL : Operate
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public BillDetailBLL()
        {
        }

        #endregion

        protected override List<SqlParameter> CreateInsertParameters(IModel obj, ref SqlParameter returnValue)
        {
            BillDetail usr_billdetail = (BillDetail)obj;

            List<SqlParameter> paras = new List<SqlParameter>();
            returnValue.Direction = ParameterDirection.Output;
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.ParameterName = "@DetailId";
            returnValue.Size = 4;
            paras.Add(returnValue);

            SqlParameter corpbillidpara = new SqlParameter("@CorpBillId", SqlDbType.Int, 4);
            corpbillidpara.Value = usr_billdetail.CorpBillId;
            paras.Add(corpbillidpara);

            SqlParameter empsalaryidpara = new SqlParameter("@EmpSalaryId", SqlDbType.Int, 4);
            empsalaryidpara.Value = usr_billdetail.EmpSalaryId;
            paras.Add(empsalaryidpara);

            SqlParameter detailstatuspara = new SqlParameter("@DetailStatus", SqlDbType.Int, 4);
            detailstatuspara.Value = usr_billdetail.DetailStatus;
            paras.Add(detailstatuspara);

            SqlParameter creatoridpara = new SqlParameter("@CreatorId", SqlDbType.Int, 4);
            creatoridpara.Value = obj.CreatorId;
            paras.Add(creatoridpara);


            return paras;
        }

        protected override IModel CreateModel(SqlDataReader dr)
        {
            BillDetail billdetail = new BillDetail();

            int indexDetailId = dr.GetOrdinal("DetailId");
            billdetail.DetailId = Convert.ToInt32(dr[indexDetailId]);
            int indexCorpBillId = dr.GetOrdinal("CorpBillId");
            if (dr[indexCorpBillId] != DBNull.Value)
            {
                billdetail.CorpBillId = Convert.ToInt32(dr[indexCorpBillId]);
            }
            int indexEmpSalaryId = dr.GetOrdinal("EmpSalaryId");
            if (dr[indexEmpSalaryId] != DBNull.Value)
            {
                billdetail.EmpSalaryId = Convert.ToInt32(dr[indexEmpSalaryId]);
            }
            int indexDetailStatus = dr.GetOrdinal("DetailStatus");
            if (dr[indexDetailStatus] != DBNull.Value)
            {
                billdetail.DetailStatus = Convert.ToInt32(dr[indexDetailStatus]);
            }
            int indexCreatorId = dr.GetOrdinal("CreatorId");
            if (dr[indexCreatorId] != DBNull.Value)
            {
                billdetail.CreatorId = Convert.ToInt32(dr[indexCreatorId]);
            }
            int indexCreateTime = dr.GetOrdinal("CreateTime");
            if (dr[indexCreateTime] != DBNull.Value)
            {
                billdetail.CreateTime = Convert.ToDateTime(dr[indexCreateTime]);
            }
            int indexLastModifyId = dr.GetOrdinal("LastModifyId");
            if (dr[indexLastModifyId] != DBNull.Value)
            {
                billdetail.LastModifyId = Convert.ToInt32(dr[indexLastModifyId]);
            }
            int indexLastModifyTime = dr.GetOrdinal("LastModifyTime");
            if (dr[indexLastModifyTime] != DBNull.Value)
            {
                billdetail.LastModifyTime = Convert.ToDateTime(dr[indexLastModifyTime]);
            }

            return billdetail;
        }

        public override string TableName
        {
            get
            {
                return "Usr_BillDetail";
            }
        }

        public override List<SqlParameter> CreateUpdateParameters(IModel obj)
        {
            BillDetail usr_billdetail = (BillDetail)obj;

            List<SqlParameter> paras = new List<SqlParameter>();

            SqlParameter detailidpara = new SqlParameter("@DetailId", SqlDbType.Int, 4);
            detailidpara.Value = usr_billdetail.DetailId;
            paras.Add(detailidpara);

            SqlParameter corpbillidpara = new SqlParameter("@CorpBillId", SqlDbType.Int, 4);
            corpbillidpara.Value = usr_billdetail.CorpBillId;
            paras.Add(corpbillidpara);

            SqlParameter empsalaryidpara = new SqlParameter("@EmpSalaryId", SqlDbType.Int, 4);
            empsalaryidpara.Value = usr_billdetail.EmpSalaryId;
            paras.Add(empsalaryidpara);

            SqlParameter detailstatuspara = new SqlParameter("@DetailStatus", SqlDbType.Int, 4);
            detailstatuspara.Value = usr_billdetail.DetailStatus;
            paras.Add(detailstatuspara);

            SqlParameter lastmodifyidpara = new SqlParameter("@LastModifyId", SqlDbType.Int, 4);
            lastmodifyidpara.Value = obj.LastModifyId;
            paras.Add(lastmodifyidpara);


            return paras;
        }
    }
}
