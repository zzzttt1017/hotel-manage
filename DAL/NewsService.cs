using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 新闻数据访问类
    /// </summary>
    public class NewsService
    {
        /// <summary>
        /// 发布新闻
        /// </summary>
        /// <param name="objNews"></param>
        /// <returns></returns>
        public int PublishNews(News objNews)
        {
            string sql = "insert into News (NewsTitle, NewsContents, CategoryId) "
                + "values(@NewsTitle, @NewsContents, @CategoryId)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NewsTitle", objNews.NewsTitle),
                new SqlParameter("@NewsContents", objNews.NewsContents),
                new SqlParameter("@CategoryId", objNews.CategoryId)
            };
            return SQLHelper.Update(sql, param);
        }

        /// <summary>
        /// 修改新闻
        /// </summary>
        /// <param name="objNews"></param>
        /// <returns></returns>
        public int ModifyNews(News objNews)
        {
            string sql = "update News set NewsTitle=@NewsTitle, NewsContents=@NewsContents, CategoryId=@CategoryId "
                + " where NewsId=@NewsId ";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NewsTitle", objNews.NewsTitle),
                new SqlParameter("@NewsContents", objNews.NewsContents),
                new SqlParameter("@CategoryId", objNews.CategoryId),
                new SqlParameter("@NewsId", objNews.NewsId)
            };
            return SQLHelper.Update(sql, param);
        }
        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public int DeleteNews(string newsId)
        {
            string sql = "delete from News where NewsId=@NewsId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NewsId", newsId)
            };
            return SQLHelper.Update(sql, param);
        }
        /// <summary>
        /// 查询新闻
        /// </summary>
        /// <returns></returns>
        public List<News> GetNews(int count)
        {
            string sql = "select top " + count + " NewsId, NewsTitle, n.CategoryId, CategoryName, PublishTime from News n";
            sql += " inner join NewsCategory c on c.CategoryId = n.CategoryId  order by PublishTime desc";
            List<News> list = new List<News>();
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            while (objReader.Read())
            {
                list.Add(new News(){
                    NewsId = Convert.ToInt32(objReader["NewsId"]),
                    NewsTitle = objReader["NewsTitle"].ToString(),
                    CategoryId = Convert.ToInt32(objReader["CategoryId"]),
                    CategoryName = objReader["CategoryName"].ToString(),
                    PublishTime = Convert.ToDateTime(objReader["PublishTime"])
                });
            }
            objReader.Close();
            return list;
        }
        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public News GetNewsById(string newsId)
        {
            string sql = "select NewsId, NewsTitle, NewsContents, CategoryId, PublishTime from News"
                + " where NewsId = @NewsId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NewsId", newsId)
            };
            News news = null;
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            if (objReader.Read())
            {
                news = new News()
                {
                    NewsId = Convert.ToInt32(objReader["NewsId"]),
                    NewsTitle = objReader["NewsTitle"].ToString(),
                    CategoryId = Convert.ToInt32(objReader["CategoryId"]),
                    NewsContents = objReader["NewsContents"].ToString(),
                    PublishTime = Convert.ToDateTime(objReader["PublishTime"])
                };
            }
            objReader.Close();
            return news;
        }

    }
}
