using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Model;
using HR.Common;

namespace HR.BLL
{
    public class BaseProvider
    {
        private static List<Model.Corporation> corporations;
        private static List<Model.Supplier> suppliers;
        private static List<Model.StyleDetail> styleDetails;

        BaseProvider()
        {
            corporations = new List<Model.Corporation>();
            suppliers = new List<Supplier>();
            styleDetails = new List<StyleDetail>();
        }

        /// <summary>
        /// 企业列表
        /// </summary>
        public static List<Model.Corporation> Corporations
        {
            get
            {
                if (corporations != null && corporations.Count > 0)
                    return corporations;

                corporations = RegisterBaseData<Model.Corporation>(new CorporationBLL());

                return corporations;
            }
        }

        /// <summary>
        /// 供应商列表
        /// </summary>
        public static List<Model.Supplier> Suppliers
        {
            get
            {
                if (suppliers != null && suppliers.Count > 0)
                    return suppliers;

                suppliers = RegisterBaseData<Model.Supplier>(new SupplierBLL());

                return suppliers;
            }
        }

        /// <summary>
        /// 类型方式明细集合
        /// </summary>
        public static List<Model.StyleDetail> StyleDetails
        {
            get
            {
                if (styleDetails == null || styleDetails.Count == 0)
                    styleDetails = RegisterBaseData<Model.StyleDetail>(new StyleDetailBLL());

                return styleDetails;
            }
        }

        private static List<T> RegisterBaseData<T>(Operate operate)
            where T : class, IModel
        {
            ResultModel<T> result = operate.Load<T>();
            if (result.ResultStatus != 0 || result.ReturnValues == null)
                throw new Exception("加载失败");

            return result.ReturnValues;
        }
    }
}
