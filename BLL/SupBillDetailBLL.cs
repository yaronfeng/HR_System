using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Model;
using HR.Common;
using System.Data.SqlClient;
using System.Data;

namespace HR.BLL
{
    public class SupBillDetailBLL:Operate
    {
        public SupBillDetailBLL()
        {

        }
        protected override List<SqlParameter> CreateInsertParameters(IModel obj, ref SqlParameter returnValue)
        {
            SupBillDetail usr_supbilldetail = (SupBillDetail)obj;

            List<SqlParameter> paras = new List<SqlParameter>();
            returnValue.Direction = ParameterDirection.Output;
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.ParameterName = "@DetailId";
            returnValue.Size = 4;
            paras.Add(returnValue);

            SqlParameter supbillidpara = new SqlParameter("@SupBillId", SqlDbType.Int, 4);
            supbillidpara.Value = usr_supbilldetail.SupBillId;
            paras.Add(supbillidpara);

            SqlParameter empsalaryidpara = new SqlParameter("@EmpSalaryId", SqlDbType.Int, 4);
            empsalaryidpara.Value = usr_supbilldetail.EmpSalaryId;
            paras.Add(empsalaryidpara);

            SqlParameter serviceamountpara = new SqlParameter("@ServiceAmount", SqlDbType.Decimal, 9);
            serviceamountpara.Value = usr_supbilldetail.ServiceAmount;
            paras.Add(serviceamountpara);

            SqlParameter detailstatuspara = new SqlParameter("@DetailStatus", SqlDbType.Int, 4);
            detailstatuspara.Value = usr_supbilldetail.DetailStatus;
            paras.Add(detailstatuspara);

            SqlParameter creatoridpara = new SqlParameter("@CreatorId", SqlDbType.VarChar, 10);
            creatoridpara.Value = obj.CreatorId;
            paras.Add(creatoridpara);


            return paras;
        }
        
        protected override IModel CreateModel(SqlDataReader dr)
        {
            SupBillDetail supbilldetail = new SupBillDetail();

            int indexDetailId = dr.GetOrdinal("DetailId");
            supbilldetail.DetailId = Convert.ToInt32(dr[indexDetailId]);
            int indexSupBillId = dr.GetOrdinal("SupBillId");
            if (dr[indexSupBillId] != DBNull.Value)
            {
                supbilldetail.SupBillId = Convert.ToInt32(dr[indexSupBillId]);
            }
            int indexEmpSalaryId = dr.GetOrdinal("EmpSalaryId");
            if (dr[indexEmpSalaryId] != DBNull.Value)
            {
                supbilldetail.EmpSalaryId = Convert.ToInt32(dr[indexEmpSalaryId]);
            }
            int indexServiceAmount = dr.GetOrdinal("ServiceAmount");
            if (dr[indexServiceAmount] != DBNull.Value)
            {
                supbilldetail.ServiceAmount = Convert.ToDecimal(dr[indexServiceAmount]);
            }
            int indexDetailStatus = dr.GetOrdinal("DetailStatus");
            if (dr[indexDetailStatus] != DBNull.Value)
            {
                supbilldetail.DetailStatus = Convert.ToInt32(dr[indexDetailStatus]);
            }
            int indexCreatorId = dr.GetOrdinal("CreatorId");
            if (dr[indexCreatorId] != DBNull.Value)
            {
                supbilldetail.CreatorId = Convert.ToInt32((dr[indexCreatorId]));
            }
            int indexCreateTime = dr.GetOrdinal("CreateTime");
            if (dr[indexCreateTime] != DBNull.Value)
            {
                supbilldetail.CreateTime = Convert.ToDateTime(dr[indexCreateTime]);
            }
            int indexLastModifyId = dr.GetOrdinal("LastModifyId");
            if (dr[indexLastModifyId] != DBNull.Value)
            {
                supbilldetail.LastModifyId = Convert.ToInt32(dr[indexLastModifyId]);
            }
            int indexLastModifyTime = dr.GetOrdinal("LastModifyTime");
            if (dr[indexLastModifyTime] != DBNull.Value)
            {
                supbilldetail.LastModifyTime = Convert.ToDateTime(dr[indexLastModifyTime]);
            }

            return supbilldetail;
        }

        public override string TableName
        {
            get
            {
                return "Usr_SupBillDetail";
            }
        }

        public override List<SqlParameter> CreateUpdateParameters(IModel obj)
        {
            SupBillDetail usr_supbilldetail = (SupBillDetail)obj;

            List<SqlParameter> paras = new List<SqlParameter>();

            SqlParameter detailidpara = new SqlParameter("@DetailId", SqlDbType.Int, 4);
            detailidpara.Value = usr_supbilldetail.DetailId;
            paras.Add(detailidpara);

            SqlParameter supbillidpara = new SqlParameter("@SupBillId", SqlDbType.Int, 4);
            supbillidpara.Value = usr_supbilldetail.SupBillId;
            paras.Add(supbillidpara);

            SqlParameter empsalaryidpara = new SqlParameter("@EmpSalaryId", SqlDbType.Int, 4);
            empsalaryidpara.Value = usr_supbilldetail.EmpSalaryId;
            paras.Add(empsalaryidpara);

            SqlParameter serviceamountpara = new SqlParameter("@ServiceAmount", SqlDbType.Decimal, 9);
            serviceamountpara.Value = usr_supbilldetail.ServiceAmount;
            paras.Add(serviceamountpara);

            SqlParameter detailstatuspara = new SqlParameter("@DetailStatus", SqlDbType.Int, 4);
            detailstatuspara.Value = usr_supbilldetail.DetailStatus;
            paras.Add(detailstatuspara);

            SqlParameter lastmodifyidpara = new SqlParameter("@LastModifyId", SqlDbType.Int, 4);
            lastmodifyidpara.Value = obj.LastModifyId;
            paras.Add(lastmodifyidpara);


            return paras;
        }
    }
}
