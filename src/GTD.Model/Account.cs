using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTD.Model
{

    #region EntityBase类定义
    //[DataContract]
    //public abstract class EntityBase
    //{  
    //在客户端和服务端需分别指定具体实现
    //    //从服务端获取数据的接口（一般为实体做的增、删、改、查）
    //    public static IEntityMethod Method= null;
    //    /// <summary>
    //    /// 加载引用类型的对象
    //    /// </summary>
    //    public abstract void LoadRefrenceObject();
    //}
    #endregion



    #region EtAccount
    /// <summary>
    ///  Account实体.
    /// </summary>
    public class EtAccount
    {
        /****1个主键***/
        protected int _Id;
        protected string _AccountName = String.Empty;
        protected int _Type;
        protected int _Status;
        protected int _ProfileId;
        protected int _ModifierId;
        protected DateTime _ModifiedTime;

        public EtAccount()
        {
        }
        #region 公开属性

        #region 主键
        /****1个主键***/
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        #endregion
        #region 其它字段
        public string AccountName
        {
            get { return _AccountName; }
            set
            {
                _AccountName = value;
            }
        }

        public int Type
        {
            get { return _Type; }
            set
            {
                _Type = value;
            }
        }

        public int Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
            }
        }

        public int ProfileId
        {
            get { return _ProfileId; }
            set
            {
                _ProfileId = value;
            }
        }

        public int ModifierId
        {
            get { return _ModifierId; }
            set
            {
                _ModifierId = value;
            }
        }

        public DateTime ModifiedTime
        {
            get { return _ModifiedTime; }
            set
            {
                _ModifiedTime = value;
            }
        }
        #endregion

        #endregion
        /// <summary>
        /// DataRow转为对象
        /// </summary>
        /// <param name="row"></param>
        internal EtAccount(DataRow row)
        {
            try
            {
                /****1个主键***/
                _Id = int.Parse(row["Id"].ToString());
                _AccountName = row["AccountName"].ToString();
                _Type = int.Parse(row["Type"].ToString());
                _Status = int.Parse(row["Status"].ToString());
                _ProfileId = int.Parse(row["ProfileId"].ToString());
                _ModifierId = int.Parse(row["ModifierId"].ToString());
                _ModifiedTime = DateTime.Parse(row["ModifiedTime"].ToString());
            }
            catch (Exception ex)
            {
                //JLog.Instance.MethodName = MethodBase.GetCurrentMethod().Name;
                //JLog.Instance.Error(ex.Message);
            }

        }
        /****1个主键***/
        /// <summary>
        /// 根据主键获取对象
        /// </summary>
        /// <param name="id"></param>
		internal EtAccount(int id)
        {
            using (SqlConnection conn = new SqlConnection(SQLDBHelper.ConnectionString))
            {
                EtAccount Relse = null;
                /****1个主键***/
                string sql = "SELECT * FROM [Account] WHERE Id = '" + id.ToString() + "'";

                using (var cnn = new SqlConnection(SQLDBHelper.ConnectionString))
                {
                    cnn.Open();
                    Relse = cnn.Query<EtAccount>(sql, null).Single();
                    cnn.Close();
                    if (Relse != null)
                        DeepCopy(Relse);

                }
            }
        }
        /// <summary>
        /// 拷贝对象内容
        /// </summary>
        /// <param name="Oject"></param>
        protected void DeepCopy(EtAccount Oject)
        {
            try
            {
                if (Oject != null)
                {
                    this._Id = Oject.Id;
                    this._AccountName = Oject.AccountName;
                    this._Type = Oject.Type;
                    this._Status = Oject.Status;
                    this._ProfileId = Oject.ProfileId;
                    this._ModifierId = Oject.ModifierId;
                    this._ModifiedTime = Oject.ModifiedTime;
                }
            }
            catch (Exception ex)
            {
                JLog.Instance.MethodName = MethodBase.GetCurrentMethod().Name;
                JLog.Instance.Error(ex.Message);
            }
        }



    }
    #endregion
}
