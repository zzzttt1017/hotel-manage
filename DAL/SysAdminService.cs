using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    /// <summary>
    /// 管理员数据访问类
    /// </summary>
    public class SysAdminService
    {
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="loginPwd"></param>
        /// <returns></returns>
        public SysAdmin AdminLogin(string loginId, string loginPwd)
        {
            string sql = "select LoginName from SysAdmins "
                + " where LoginId=@LoginId and LoginPwd=@LoginPwd";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@LoginId", loginId),
                new SqlParameter("@LoginPwd", loginPwd)
            };
            SysAdmin objAdmin = null;
            object result = SQLHelper.GetSingleResult(sql, parameters);
            if (result != null)
            {
                objAdmin = new SysAdmin()
                {
                    LoginId = Convert.ToInt32(loginId),
                    LoginName = result.ToString(),
                    LoginPwd = loginPwd
                };
            }
            return objAdmin;
        }
    }
}
