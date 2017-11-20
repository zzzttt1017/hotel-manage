using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 菜品实体类
    /// </summary>
    [Serializable]
    public class Dish
    {
        //DishId int  identity(100,1)  primary key , --菜品编号
        //DishName varchar(100),--菜品名称
        //UnitPrice numeric(18,2), --价格
        //CategoryId int references DishCategory(CategoryId)--分类编号

        public int DishId { get; set; }
        public string DishName { get; set; }
        public int UnitPrice { get; set; }
        public int CategoryId { get; set; }
        //扩展属性
        public string CategoryName { get; set; }
    }
}
