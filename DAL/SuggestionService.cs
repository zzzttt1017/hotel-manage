using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 投诉受理数据访问类
    /// </summary>
    public class SuggestionService
    {
        /// <summary>
        /// 提交投诉
        /// </summary>
        /// <param name="suggestion"></param>
        /// <returns></returns>
        public int SubmitSuggestion(Suggestion suggestion)
        {
            string sql = "insert into Suggestion (CustomerName, ConsumeDesc, SuggestionDesc, PhoneNumber, Email) ";
            sql += " values(@CustomerName, @ConsumeDesc, @SuggestionDesc, @PhoneNumber, @Email) ";
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@CustomerName", suggestion.CustomerName),
                new SqlParameter("@ConsumeDesc", suggestion.ConsumeDesc),
                new SqlParameter("@SuggestionDesc", suggestion.SuggestionDesc),
                new SqlParameter("@PhoneNumber", suggestion.PhoneNumber),
                new SqlParameter("@Email", suggestion.Email)
            };
            return SQLHelper.Update(sql, param);
        }

        /// <summary>
        /// 获取投诉建议
        /// </summary>
        /// <returns></returns>
        public List<Suggestion> GetSuggestion()
        {
            string sql = "select SuggestionId, CustomerName, ConsumeDesc, SuggestionDesc, SuggestTime, PhoneNumber, Email, StatusId";
            sql += " from Suggestion where StatusId=0 order by SuggestTime desc";
            List<Suggestion> list = new List<Suggestion>();
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            while (objReader.Read())
            {
                list.Add(new Suggestion()
                {
                    SuggestionId = Convert.ToInt32(objReader["SuggestionId"]),
                    CustomerName = objReader["CustomerName"].ToString(),
                    ConsumeDesc = objReader["ConsumeDesc"].ToString(),
                    SuggestionDesc = objReader["SuggestionDesc"].ToString(),
                    SuggestTime = Convert.ToDateTime(objReader["SuggestTime"]),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    Email = objReader["Email"].ToString(),
                    StatusId = Convert.ToInt32(objReader["StatusId"])

                });
            }
            objReader.Close();
            return list;
        }

        /// <summary>
        /// 受理投诉建议
        /// </summary>
        /// <param name="SuggestionId"></param>
        /// <returns></returns>
        public int HandlerSuggestion(string SuggestionId)
        {
            string sql = "update Suggestion set StatusId=1 where SuggestionId=@SuggestionId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SuggestionId", SuggestionId)
            };
            return SQLHelper.Update(sql, param);
        }

    }
}
