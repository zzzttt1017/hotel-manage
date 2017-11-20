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
    /// 菜品数据访问类
    /// </summary>
    public class DishService
    {
        /// <summary>
        /// 获取所有的菜品分类
        /// </summary>
        /// <returns></returns>
        public List<DishCategory> GetAllCategory()
        {
            string sql = "select CategoryId, CategoryName from DishCategory";
            List<DishCategory> list = new List<DishCategory>();
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            while (objReader.Read())
            {
                list.Add(new DishCategory()
                    {
                        CategoryId = Convert.ToInt32(objReader["CategoryId"]),
                        CategoryName = objReader["CategoryName"].ToString()
                    }
                );
            }

            //关闭reader
            objReader.Close();
            return list;

        }
        /// <summary>
        /// 添加菜品，获取添加后菜品的ID，用作图片的编号
        /// </summary>
        /// <param name="objDish"></param>
        /// <returns>菜品的ID</returns>
        public int AddDish(Dish objDish)
        {
            string sql = "insert into Dishes(DishName, UnitPrice, CategoryId) ";
            sql += " values(@DishName, @UnitPrice, @CategoryId); select @@identity";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@DishName", objDish.DishName),
                new SqlParameter("@UnitPrice", objDish.UnitPrice),
                new SqlParameter("@CategoryId", objDish.CategoryId)
            };

            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql, param));
            return result;
        }

        /// <summary>
        /// 根据菜品分类id获取菜品
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<Dish> GetDishes(String categoryId)
        {
            string sql = "select d.DishId, d.DishName, d.UnitPrice, d.CategoryId, c.CategoryName from Dishes d"
                + " inner join DishCategory c"
                + " on c.CategoryId = d.CategoryId ";

            List<Dish> list = new List<Dish>();
            SqlDataReader objReader = null;

            if (!string.IsNullOrEmpty(categoryId))
            {
                sql += " where d.CategoryId = @CategoryId";
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@CategoryId", categoryId)
                };
                objReader = SQLHelper.GetReader(sql, param);
            }
            else
            {
                objReader = SQLHelper.GetReader(sql);
            }

            while (objReader.Read())
            {
                list.Add(new Dish()
                    {
                        DishId = Convert.ToInt32(objReader["DishId"]),
                        DishName = objReader["DishName"].ToString(),
                        CategoryName = objReader["CategoryName"].ToString(),
                        CategoryId = Convert.ToInt32(objReader["CategoryId"]),
                        UnitPrice = Convert.ToInt32(objReader["UnitPrice"])
                    });
            }
            //注意关闭
            objReader.Close();
            return list;
        }
        /// <summary>
        /// 根据菜品Id，获取菜品
        /// </summary>
        /// <param name="dishId"></param>
        /// <returns></returns>
        public Dish GetDishById(string dishId)
        {
            string sql = "select DishName, UnitPrice, CategoryId from Dishes where DishId = @DishId";
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@DishId", dishId)
            };
            Dish dish = null;
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);

            if (objReader.Read())
            {
                dish = new Dish()
                {
                    DishId = Convert.ToInt32(dishId),
                    DishName = objReader["DishName"].ToString(),
                    CategoryId = Convert.ToInt32(objReader["CategoryId"]),
                    UnitPrice = Convert.ToInt32(objReader["UnitPrice"])
                };
            }
            objReader.Close();
            return dish;

        }

        /// <summary>
        /// 修改菜品
        /// </summary>
        /// <param name="objDish"></param>
        /// <returns></returns>
        public int ModifyDish(Dish objDish)
        {
            string sql = "update Dishes set DishName=@DishName, UnitPrice=@UnitPrice, CategoryId=@CategoryId "
                + " where DishId=@DishId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@DishName", objDish.DishName),
                new SqlParameter("@UnitPrice", objDish.UnitPrice),
                new SqlParameter("@CategoryId", objDish.CategoryId),
                new SqlParameter("@DishId", objDish.DishId)
            };
            return SQLHelper.Update(sql, param);
        }
        /// <summary>
        /// 删除菜品
        /// </summary>
        /// <param name="dishId"></param>
        /// <returns></returns>
        public int DeleteDish(string dishId)
        {
            string sql = "delete from Dishes where DishId=@DishId";
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@DishId", dishId)
            };
            return SQLHelper.Update(sql, param);
        }

    }
}
