using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 管理员实体类
    /// </summary>
    [Serializable]
    public class SysAdmin
    {
        //LoginId int primary key ,--登录账号
        //LoginName varchar(20), --登录名称
        //LoginPwd varchar(20)	 --登录密码
        public int LoginId { get; set; }
        public string LoginName { get; set; }
        public string LoginPwd { get; set; }
    }
}
