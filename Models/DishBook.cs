using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 菜品预定实体类
    /// </summary>
    [Serializable]
    public class DishBook
    {
        //BookId int  identity(10000,1) primary key , --预定编号
        //HotelName varchar(50),   --分店名称
        //ConsumeTime datetime,--消费时间
        //ConsumePersons int,--消费人数
        //RoomType varchar(20),--包间类型
        //CustomerName varchar(20),--预定人姓名
        //CustomerPhone varchar(100),--联系电话
        //CustomerEmail varchar(100),  --电子邮件
        //Comments nvarchar(500), --备注内容
        //BookTime datetime default(getdate()),--预定时间
        //OrderStatus int default(0), --订单状态（0，未审核；1，审核通过，-1 ，撤销，2，消费完毕）	

        public int BookId { get; set; }
        public string HotelName { get; set; }
        public DateTime ConsumeTime { get; set; }
        public int ConsumePersons { get; set; }
        public String RoomType { get; set; }
        public String CustomerName { get; set; }
        public String CustomerPhone { get; set; }
        public String CustomerEmail { get; set; }
        public String Comments { get; set; }
        public DateTime BookTime { get; set; }
        public int OrderStatus { get; set; }


    }
}
