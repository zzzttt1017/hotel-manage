using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 投诉实体类
    /// </summary>
    public class Suggestion
    {
        //SuggestionId int identity(100000,1) primary key ,
        //CustomerName nvarchar(50), --客户姓名
        //ConsumeDesc text,--消费说明
        //SuggestionDesc text,--投诉建议内容
        //SuggestTime datetime default(getdate()), --投诉时间	
        //PhoneNumber varchar(100),--电话
        //Email varchar(100), --电子邮件
        //StatusId int default(0)--投诉状态（0：未受理；1：已受理）

        public int SuggestionId { get; set; }
        public string CustomerName { get; set; }
        public string ConsumeDesc { get; set; }
        public string SuggestionDesc { get; set; }
        public DateTime SuggestTime { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int StatusId { get; set; }
    }
}
