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
        BaseProvider()
        {
            corporations = new List<Model.Corporation>();
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
