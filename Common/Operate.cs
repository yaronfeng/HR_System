using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HR.DBUtility;

namespace HR.Common
{
    public abstract class Operate
    {
        private string ConnectString
        {
            get
            {
                return SQLConnString.GetConnSting();
            }
        }

        public abstract string TableName { get; }

        #region 查询
        /// <summary>
        /// 通过SqlDateReader创建对象实体
        /// </summary>
        /// <param name="dr">reader对象</param>
        /// <returns></returns>
        protected abstract IModel CreateModel(SqlDataReader dr);

        /// <summary>
        /// 通过Reader创建实体。泛型方法
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="dr">reader对象</param>
        /// <returns></returns>
        protected virtual T CreateModel<T>(SqlDataReader dr)
            where T : class, IModel
        {
            IModel model = this.CreateModel(dr);
            T t = (T)model;
            return t;
        }
        /// <summary>
        /// 通过ID获取实体
        /// </summary>
        /// <param name="user">当前用户</param>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual ResultModel Get(int id)
        {
            ResultModel result = new ResultModel();

            if (id < 1)
            {
                result.Message = "序号不能小于1";
                result.ResultStatus = -1;
                return result;
            }

            List<SqlParameter> paras = new List<SqlParameter>();
            SqlParameter para = new SqlParameter("@id", SqlDbType.Int, 4);
            para.Value = id;
            paras.Add(para);

            return this.Get(CommandType.StoredProcedure, this.GetName, paras.ToArray());
        }

        /// <summary>
        /// 通过查询语句获取实体
        /// </summary>
        /// <param name="user">当前用户</param>
        /// <param name="cmdType">执行类型</param>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="paras">SQL参数</param>
        /// <returns></returns>
        public virtual ResultModel Get(CommandType cmdType, string cmdText, SqlParameter[] paras)
        {
            ResultModel result = new ResultModel();

            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectString, cmdType, cmdText, paras);

                IModel model = null;

                if (dr.Read())
                {
                    model = CreateModel(dr);

                    result.AffectCount = 1;
                    result.Message = "读取成功";
                    result.ResultStatus = 0;
                    result.ReturnValue = model;
                }
                else
                {
                    result.Message = "无数据或读取失败";
                    result.AffectCount = 0;
                }
            }
            catch (Exception ex)
            {
                result.ResultStatus = -1;
                result.Message = ex.Message;
            }
            finally
            {
                if (dr != null)
                    dr.Dispose();
            }
            return result;
        }

        public virtual ResultModel<T> Get<T>(int id)
            where T : class, IModel
        {
            if (id < 1)
            {
                ResultModel<T> result = new ResultModel<T>();
                result.Message = "序号不能小于1";
                return result;
            }

            List<SqlParameter> paras = new List<SqlParameter>();
            SqlParameter para = new SqlParameter("@id", SqlDbType.Int, 4);
            para.Value = id;
            paras.Add(para);

            return this.Get<T>(CommandType.StoredProcedure, this.GetName, paras.ToArray());
        }

        /// <summary>
        /// 通过查询语句获取实体
        /// </summary>
        /// <param name="user">当前用户</param>
        /// <param name="cmdType">执行类型</param>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="paras">SQL参数</param>
        /// <returns></returns>
        public virtual ResultModel<T> Get<T>(CommandType cmdType, string cmdText, SqlParameter[] paras)
            where T : class, IModel
        {
            ResultModel<T> result = new ResultModel<T>();

            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectString, cmdType, cmdText, paras);

                T model = default(T);

                if (dr.Read())
                {
                    model = CreateModel<T>(dr);

                    result.AffectCount = 1;
                    result.Message = "读取成功";
                    result.ResultStatus = 0;
                    result.ReturnValue = model;
                }
                else
                {
                    result.Message = "无数据或读取失败";
                    result.AffectCount = 0;
                }
            }
            catch (Exception ex)
            {
                result.ResultStatus = -1;
                result.Message = ex.Message;
            }
            finally
            {
                if (dr != null)
                    dr.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 获取所有数据行
        /// </summary>
        /// <typeparam name="T">泛型，实体类型</typeparam>
        /// <param name="user">当前用户</param>
        /// <returns>返回数据实体集合</returns>
        public virtual ResultModel<T> Load<T>()
            where T : class, IModel
        {
            return this.Load<T>( CommandType.StoredProcedure, this.LoadName);
        }

        /// <summary>
        /// 根据查询语句，获取数据行
        /// </summary>
        /// <typeparam name="T">泛型，实体类型</typeparam>
        /// <param name="user">当前用户</param>
        /// <param name="cmdType">System.Data.CommandType值之一</param>
        /// <param name="cmdText">查询语句</param>
        /// <returns>返回数据实体集合</returns>
        public virtual ResultModel<T> Load<T>(CommandType cmdType, string cmdText)
            where T : class, IModel
        {
            ResultModel<T> result = new ResultModel<T>();

            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectString, cmdType, cmdText, null);
                List<T> models = new List<T>();

                int i = 0;
                while (dr.Read())
                {
                    T t = this.CreateModel<T>(dr);
                    models.Add(t);
                    i++;
                }

                result.AffectCount = i;
                result.Message = "获取列表成功";
                result.ResultStatus = 0;
                result.ReturnValues = models;
            }
            catch (Exception ex)
            {
                result.ResultStatus = -1;
                result.Message = ex.Message;
            }
            finally
            {
                if (dr != null)
                    dr.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 根据查询实体，获取数据行
        /// </summary>
        /// <param name="user">当前用户</param>
        /// <param name="select">查询实体对象</param>
        /// <param name="authority">数据权限对象</param>
        /// <returns>System.Data.DataTable类型数据列表</returns>
        public virtual ResultModel Load(SelectModel select)
        {
            ResultModel result = new ResultModel();

            try
            {
                if (select == null)
                {
                    result.Message = "查询对象不能为null";
                    return result;
                }
                if (string.IsNullOrEmpty(select.TableName))
                {
                    result.Message = "查询表名不能为空";
                    return result;
                }

                List<SqlParameter> paras = new List<SqlParameter>();

                SqlParameter pageIndexPara = new SqlParameter("@pageIndex", SqlDbType.Int, 4);
                pageIndexPara.Value = select.PageIndex;
                paras.Add(pageIndexPara);

                SqlParameter pageSizePara = new SqlParameter("@pageSize", SqlDbType.Int, 4);
                pageSizePara.Value = select.PageSize;
                paras.Add(pageSizePara);

                SqlParameter columnNamePara = new SqlParameter("@columnName", SqlDbType.VarChar);
                columnNamePara.Value = select.ColumnName;
                paras.Add(columnNamePara);

                SqlParameter tableNamePara = new SqlParameter("@tableName", SqlDbType.VarChar);
                tableNamePara.Value = select.TableName;
                paras.Add(tableNamePara);

                SqlParameter orderStrPara = new SqlParameter("@orderStr", SqlDbType.VarChar);
                orderStrPara.Value = select.OrderStr;
                paras.Add(orderStrPara);

                SqlParameter whereStrPara = new SqlParameter("@whereStr", SqlDbType.VarChar);

                if (string.IsNullOrEmpty(select.WhereStr))
                    select.WhereStr = "1=1 ";

                whereStrPara.Value = select.WhereStr;
                paras.Add(whereStrPara);

                SqlParameter rowCountPara = new SqlParameter();
                rowCountPara.Direction = ParameterDirection.InputOutput;
                rowCountPara.SqlDbType = SqlDbType.Int;
                rowCountPara.ParameterName = "@rowCount";
                rowCountPara.Size = 4;
                rowCountPara.Value = 0;
                paras.Add(rowCountPara);

                System.Data.DataTable dt = SqlHelper.ExecuteDataTable(this.ConnectString, "dbo.SelectPage", paras.ToArray(), CommandType.StoredProcedure);

                if (dt != null)
                {
                    result.AffectCount = (int)rowCountPara.Value;
                    result.ResultStatus = 0;
                    result.Message = "获取数据成功";
                    result.ReturnValue = dt;
                }
                else
                    result.Message = "获取数据失败失败";
            }
            catch (Exception ex)
            {
                result.ResultStatus = -1;
                result.Message = ex.Message;
            }

            return result;
        }

        #endregion

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="user">当前用户</param>
        /// <param name="obj">新样对象</param>
        /// <returns></returns>
        public virtual ResultModel Insert(IModel obj)
        {
            ResultModel result = new ResultModel();
            try
            {
                if (obj == null)
                {
                    result.Message = "插入对象不能为null";
                    return result;
                }

                SqlParameter returnValue = new SqlParameter();

                if ((int)obj.Status == 0)
                    obj.Status = (int)StatusEnum.已完成;

                int i = SqlHelper.ExecuteNonQuery(ConnectString, CommandType.StoredProcedure, this.InsertName, CreateInsertParameters(obj, ref returnValue).ToArray());

                if (i > 0)
                {
                    result.AffectCount = i;
                    result.ResultStatus = 0;
                    result.Message = "添加成功";
                    result.ReturnValue = returnValue.Value;
                }
                else
                    result.Message = "添加失败";
            }
            catch (Exception ex)
            {
                result.ResultStatus = -1;
                result.Message = ex.Message;
            }

            return result;
        }

        protected abstract List<SqlParameter> CreateInsertParameters(IModel obj, ref SqlParameter returnValue);

        public virtual ResultModel Update(IModel obj)
        {
            ResultModel result = new ResultModel();

            try
            {
                if (obj == null)
                {
                    result.Message = "更新对象不能为null";
                    return result;
                }

                int i = SqlHelper.ExecuteNonQuery(ConnectString, CommandType.StoredProcedure, this.UpdateName, CreateUpdateParameters(obj).ToArray());

                if (i == 1)
                {
                    result.Message = "更新成功";
                    result.ResultStatus = 0;
                }
                else
                {
                    result.ResultStatus = -1;
                    result.Message = "更新失败";
                }

                result.AffectCount = i;
                result.ReturnValue = i;
            }
            catch (Exception ex)
            {
                result.ResultStatus = -1;
                result.Message = ex.Message;
            }

            return result;
        }

        public abstract List<SqlParameter> CreateUpdateParameters(IModel obj);

        #region 存储过程名获取
        /// <summary>
        /// Get存储过程名
        /// </summary>
        protected virtual string GetName
        {
            get { return string.Format("{0}_{1}", this.TableName, "Get"); }
        }
        /// <summary>
        /// Load存储过程名
        /// </summary>
        protected virtual string LoadName
        {
            get { return string.Format("{0}_{1}", this.TableName, "Load"); }
        }
        /// <summary>
        /// Insert存储过程名
        /// </summary>
        protected virtual string InsertName
        {
            get { return string.Format("{0}_{1}", this.TableName, "Insert"); }
        }
        /// <summary>
        /// Update存储过程名
        /// </summary>
        protected virtual string UpdateName
        {
            get { return string.Format("{0}_{1}", this.TableName, "Update"); }
        }
        #endregion
    }
}
