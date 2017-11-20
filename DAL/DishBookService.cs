using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Models;

namespace DAL
{
    /// <summary>
    /// 菜品预定管理数据访问
    /// </summary>
    public class DishBookService
    {
        /// <summary>
        /// 添加预定
        /// </summary>
        /// <param name="dishBook"></param>
        /// <returns></returns>
        public int Book(DishBook dishBook)
        {
            string sql = "insert into DishBook (HotelName, ConsumeTime, ConsumePersons, RoomType, CustomerName, CustomerPhone, CustomerEmail, Comments)"
                + " values(@HotelName, @ConsumeTime, @ConsumePersons, @RoomType, @CustomerName, @CustomerPhone, @CustomerEmail, @Comments) ";
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@HotelName", dishBook.HotelName),
                new SqlParameter("@ConsumeTime", dishBook.ConsumeTime),
                new SqlParameter("@ConsumePersons", dishBook.ConsumePersons),
                new SqlParameter("@RoomType", dishBook.RoomType),
                new SqlParameter("@CustomerName", dishBook.CustomerName),
                new SqlParameter("@CustomerPhone", dishBook.CustomerPhone),
                new SqlParameter("@CustomerEmail", dishBook.CustomerEmail),
                new SqlParameter("@Comments", dishBook.Comments)
            };
            return SQLHelper.Update(sql, param);
        }
        /// <summary>
        /// 修改订单的状态
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        public int ModifyBook(string bookId, string orderStatus)
        {
            string sql = "update DishBook set OrderStatus=@OrderStatus where BookId=@BookId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@OrderStatus", orderStatus),
                new SqlParameter("@BookId", bookId)
            };
            return SQLHelper.Update(sql, param);
        }
        /// <summary>
        /// 获取未关闭的订单
        /// </summary>
        /// <returns></returns>
        public List<DishBook> GetAllDishBook()
        {
            string sql = "select BookId, HotelName, ConsumeTime, ConsumePersons, RoomType, CustomerName, CustomerPhone, CustomerEmail, Comments, BookTime, OrderStatus"
               + " from DishBook where OrderStatus =0 or OrderStatus = 1 order by BookTime desc";
            List<DishBook> list = new List<DishBook>();
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            while (objReader.Read())
            {
                list.Add(new DishBook(){
                    BookId = Convert.ToInt32(objReader["BookId"]),
                    HotelName = objReader["HotelName"].ToString(),
                    ConsumeTime = Convert.ToDateTime(objReader["ConsumeTime"]),
                    ConsumePersons = Convert.ToInt32(objReader["ConsumePersons"]),
                    RoomType = objReader["RoomType"].ToString(),
                    CustomerName = objReader["CustomerName"].ToString(),
                    CustomerPhone = objReader["CustomerPhone"].ToString(),
                    CustomerEmail = objReader["CustomerEmail"].ToString(),
                    Comments = objReader["Comments"].ToString(),
                    BookTime = Convert.ToDateTime(objReader["BookTime"]),
                    OrderStatus = Convert.ToInt32(objReader["OrderStatus"])
                });
            }
            objReader.Close();
            return list;
        }

    }
}
