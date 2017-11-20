using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 招聘实体类
    /// </summary>
    public class Recruitment
    {
        //PostId int identity(100000,1) primary key ,
        //PostName nvarchar(50), --职位名称
        //PostType char(4),--(全职、兼职)
        //PostPlace nvarchar(50),--工作地点
        //PostDesc text,--职位描述
        //PostRequire text,--具体要求
        //Experience nvarchar(100),--工作经验
        //EduBackground nvarchar(100),--学历
        //RequireCount int ,--招聘人数
        //PublishTime datetime default(getdate()), --发布时间
        //Manager varchar(20),--联系人
        //PhoneNumber varchar(100),--电话
        //Email varchar(100) --电子邮件

        public int PostId { get; set; }
        public string PostName { get; set; }
        public string PostType { get; set; }
        public string PostPlace { get; set; }
        public string PostDesc { get; set; }
        public string PostRequire { get; set; }
        public string Experience { get; set; }
        public string EduBackground { get; set; }
        public int RequireCount { get; set; }
        public DateTime PublishTime { get; set; }
        public string Manager { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
