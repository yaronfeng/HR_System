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
    public class StyleDetailBLL:Operate
    {
        public StyleDetailBLL()
        {
        }

        protected override List<SqlParameter> CreateInsertParameters(IModel obj, ref SqlParameter returnValue)
        {
            StyleDetail bd_styledetail = (StyleDetail)obj;

            List<SqlParameter> paras = new List<SqlParameter>();
            SqlParameter detailidpara = new SqlParameter("@DetailId", SqlDbType.Int, 4);
            detailidpara.Value = bd_styledetail.DetailId;
            paras.Add(detailidpara);

            SqlParameter styleidpara = new SqlParameter("@StyleId", SqlDbType.Int, 4);
            styleidpara.Value = bd_styledetail.StyleId;
            paras.Add(styleidpara);

            if (!string.IsNullOrEmpty(bd_styledetail.DetailCode))
            {
                SqlParameter detailcodepara = new SqlParameter("@DetailCode", SqlDbType.VarChar, 50);
                detailcodepara.Value = bd_styledetail.DetailCode;
                paras.Add(detailcodepara);
            }

            if (!string.IsNullOrEmpty(bd_styledetail.DetailName))
            {
                SqlParameter detailnamepara = new SqlParameter("@DetailName", SqlDbType.VarChar, 50);
                detailnamepara.Value = bd_styledetail.DetailName;
                paras.Add(detailnamepara);
            }

            SqlParameter detailstatuspara = new SqlParameter("@DetailStatus", SqlDbType.Int, 4);
            detailstatuspara.Value = bd_styledetail.DetailStatus;
            paras.Add(detailstatuspara);


            return paras;
        }

        protected override IModel CreateModel(SqlDataReader dr)
        {
            StyleDetail styledetail = new StyleDetail();

            int indexDetailId = dr.GetOrdinal("DetailId");
            styledetail.DetailId = Convert.ToInt32(dr[indexDetailId]);
            int indexStyleId = dr.GetOrdinal("StyleId");
            if (dr[indexStyleId] != DBNull.Value)
            {
                styledetail.StyleId = Convert.ToInt32(dr[indexStyleId]);
            }
            int indexDetailCode = dr.GetOrdinal("DetailCode");
            if (dr[indexDetailCode] != DBNull.Value)
            {
                styledetail.DetailCode = Convert.ToString(dr[indexDetailCode]);
            }
            int indexDetailName = dr.GetOrdinal("DetailName");
            if (dr[indexDetailName] != DBNull.Value)
            {
                styledetail.DetailName = Convert.ToString(dr[indexDetailName]);
            }
            int indexDetailStatus = dr.GetOrdinal("DetailStatus");
            if (dr[indexDetailStatus] != DBNull.Value)
            {
                styledetail.DetailStatus = Convert.ToInt32(dr[indexDetailStatus]);
            }

            return styledetail;
        }

        public override string TableName
        {
            get
            {
                return "bd_StyleDetail";
            }
        }

        public override List<SqlParameter> CreateUpdateParameters(IModel obj)
        {
            StyleDetail bd_styledetail = (StyleDetail)obj;

            List<SqlParameter> paras = new List<SqlParameter>();

            SqlParameter detailidpara = new SqlParameter("@DetailId", SqlDbType.Int, 4);
            detailidpara.Value = bd_styledetail.DetailId;
            paras.Add(detailidpara);

            SqlParameter styleidpara = new SqlParameter("@StyleId", SqlDbType.Int, 4);
            styleidpara.Value = bd_styledetail.StyleId;
            paras.Add(styleidpara);

            if (!string.IsNullOrEmpty(bd_styledetail.DetailCode))
            {
                SqlParameter detailcodepara = new SqlParameter("@DetailCode", SqlDbType.VarChar, 50);
                detailcodepara.Value = bd_styledetail.DetailCode;
                paras.Add(detailcodepara);
            }

            if (!string.IsNullOrEmpty(bd_styledetail.DetailName))
            {
                SqlParameter detailnamepara = new SqlParameter("@DetailName", SqlDbType.VarChar, 50);
                detailnamepara.Value = bd_styledetail.DetailName;
                paras.Add(detailnamepara);
            }

            SqlParameter detailstatuspara = new SqlParameter("@DetailStatus", SqlDbType.Int, 4);
            detailstatuspara.Value = bd_styledetail.DetailStatus;
            paras.Add(detailstatuspara);


            return paras;
        }
    }
}
