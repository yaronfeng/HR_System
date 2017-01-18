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
        BaseProvider()
        {
            corporations = new List<Model.Corporation>();
            suppliers = new List<Supplier>();
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

                corporations = RegisterUser<Model.Corporation>(new CorporationBLL());

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

                suppliers = RegisterUser<Model.Supplier>(new SupplierBLL());

                return suppliers;
            }
        }
        private static List<T> RegisterUser<T>(Operate operate)
            where T : class, IModel
        {
            ResultModel<T> result = operate.Load<T>();
            if (result.ResultStatus != 0 || result.ReturnValues == null)
                throw new Exception("加载失败");

            return result.ReturnValues;
        }
    }
}
