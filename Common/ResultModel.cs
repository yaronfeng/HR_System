
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Common
{
    /// <summary>
    /// 系统通用返回实体类型
    /// </summary>
    [Serializable()]
    public class ResultModel
    {
        private int affectCount = -1;
        private string message = "默认错误";
        private int resultStatus = -1;
        private object resultValue = null;

        public ResultModel()
        {

        }

        public ResultModel(string message)
        {
            this.Message = message;
        }

        private static ResultModel notLoginResult = new ResultModel("用户未登录");

        /// <summary>
        /// 用户未登录返回结果对象
        /// </summary>
        public static ResultModel NotLoginResult
        {
            get { return notLoginResult; }
        }

        /// <summary>
        /// 泛型结果对象转换为普通结果对象
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="genericResult">泛型结果对象</param>
        /// <returns>普通结果对象</returns>
        public static ResultModel GenericResult<T>(ResultModel<T> genericResult)
            where T : IModel
        {
            ResultModel result = new ResultModel();

            result.AffectCount = genericResult.AffectCount;
            result.Message = genericResult.Message;
            result.ResultStatus = genericResult.ResultStatus;

            if (genericResult.ReturnValue != null)
                result.ReturnValue = genericResult.ReturnValue;
            else
                result.ReturnValue = genericResult.ReturnValues;

            return result;
        }

        /// <summary>
        /// 受影响的行数
        /// </summary>
        public int AffectCount
        {
            get { return this.affectCount; }
            set { this.affectCount = value; }
        }

        /// <summary>
        /// 返回的消息
        /// </summary>
        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }

        /// <summary>
        /// 消息状态。0为完成，其他为错误
        /// </summary>
        public int ResultStatus
        {
            get { return this.resultStatus; }
            set { this.resultStatus = value; }
        }

        /// <summary>
        /// 返回结果
        /// </summary>
        public object ReturnValue
        {
            get { return this.resultValue; }
            set { this.resultValue = value; }
        }
    }

    [Serializable()]
    public class ResultModel<T>
        where T : IModel
    {
        private int affectCount = -1;
        private string message = "默认错误";
        private int resultStatus = -1;
        private T resultValue = default(T);

        public ResultModel()
        {

        }

        /// <summary>
        /// 受影响的行数
        /// </summary>
        public int AffectCount
        {
            get { return this.affectCount; }
            set { this.affectCount = value; }
        }

        /// <summary>
        /// 返回的消息
        /// </summary>
        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }

        /// <summary>
        /// 消息状态。0为完成，其他为错误
        /// </summary>
        public int ResultStatus
        {
            get { return this.resultStatus; }
            set { this.resultStatus = value; }
        }

        /// <summary>
        /// 返回对象
        /// </summary>
        public T ReturnValue
        {
            get { return this.resultValue; }
            set { this.resultValue = value; }
        }

        private List<T> returnValues = new List<T>();
        /// <summary>
        /// 返回对象集合
        /// </summary>
        public List<T> ReturnValues
        {
            get { return this.returnValues; }
            set { this.returnValues = value; }
        }
    }
}
