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
    /// 招聘数据库访问类
    /// </summary>
    public class RecruitmentService
    {
        /// <summary>
        /// 发布招聘信息
        /// </summary>
        /// <param name="recruitment"></param>
        /// <returns></returns>
        public int PublishRecruitment(Recruitment recruitment)
        {
            string sql = " insert into Recruitment (PostName, PostType, PostPlace, PostDesc, PostRequire,"
            + "Experience, EduBackground, RequireCount, Manager, PhoneNumber, Email)";
            sql += " values(@PostName, @PostType, @PostPlace, @PostDesc, @PostRequire, ";
            sql += " @Experience, @EduBackground, @RequireCount, @Manager, @PhoneNumber, @Email)";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@PostName", recruitment.PostName),
                new SqlParameter("@PostType", recruitment.PostType),
                new SqlParameter("@PostPlace", recruitment.PostPlace),
                new SqlParameter("@PostDesc", recruitment.PostDesc),
                new SqlParameter("@PostRequire", recruitment.PostRequire),
                new SqlParameter("@Experience", recruitment.Experience),
                new SqlParameter("@EduBackground", recruitment.EduBackground),
                new SqlParameter("@RequireCount", recruitment.RequireCount),
                new SqlParameter("@Manager", recruitment.Manager),
                new SqlParameter("@PhoneNumber", recruitment.PhoneNumber),
                new SqlParameter("@Email", recruitment.Email)
            };
            return SQLHelper.Update(sql, param);
        }
        /// <summary>
        /// 查询所有的职位
        /// </summary>
        /// <returns></returns>
        public List<Recruitment> GetAllRecList()
        {
            string sql = "select PostId, PostName, PostType, Experience, EduBackground, RequireCount, PostPlace ";
            sql += "from Recruitment order by PublishTime desc";
            List<Recruitment> list = new List<Recruitment>();
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            while (objReader.Read())
            {
                list.Add(new Recruitment()
                {
                    PostId = Convert.ToInt32(objReader["PostId"]),
                    PostName = objReader["PostName"].ToString(),
                    PostType = objReader["PostType"].ToString(),
                    Experience = objReader["Experience"].ToString(),
                    EduBackground = objReader["EduBackground"].ToString(),
                    RequireCount = Convert.ToInt32(objReader["RequireCount"]),
                    PostPlace = objReader["PostPlace"].ToString()

                });
            }
            objReader.Close();
            return list;
        }

        /// <summary>
        /// 根据职位编号查询职位详细信息
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public Recruitment GetPostById(string postId)
        {
            string sql = "select PostId, PostName, PostType, PostPlace, PostDesc, PostRequire, Experience, EduBackground, RequireCount, Manager, PublishTime,PhoneNumber, Email";
            sql += " from  Recruitment where PostId=@PostId ";
            Recruitment objRec = null;
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@PostId", postId)
            };
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            if (objReader.Read())
            {
                objRec = new Recruitment()
                {
                    PostId = Convert.ToInt32(objReader["PostId"]),
                    PostName = objReader["PostName"].ToString(),
                    PostType = objReader["PostType"].ToString(),
                    PostPlace = objReader["PostPlace"].ToString(),
                    PostDesc = objReader["PostDesc"].ToString(),
                    PostRequire = objReader["PostRequire"].ToString(),
                    Experience = objReader["Experience"].ToString(),
                    EduBackground = objReader["EduBackground"].ToString(),
                    RequireCount = Convert.ToInt32(objReader["RequireCount"]),
                    Manager = objReader["Manager"].ToString(),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    Email = objReader["Email"].ToString(),
                    PublishTime = Convert.ToDateTime(objReader["PublishTime"])

                };
            }
            objReader.Close();
            return objRec;
        }
        /// <summary>
        /// 修改招聘信息
        /// </summary>
        /// <param name="objRecruitment"></param>
        /// <returns></returns>
        public int ModifyRecruitment(Recruitment objRecruitment)
        {
            string sql = " update Recruitment set PostName=@PostName, PostType=@PostType, PostPlace=@PostPlace, PostDesc=@PostDesc, PostRequire=@PostRequire,"
                + "Experience=@Experience, EduBackground=@EduBackground, RequireCount=@RequireCount, Manager=@Manager, PhoneNumber=@PhoneNumber, Email=@Email";
            sql += " where PostId=@PostId ";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@PostName", objRecruitment.PostName),
                new SqlParameter("@PostType", objRecruitment.PostType),
                new SqlParameter("@PostPlace", objRecruitment.PostPlace),
                new SqlParameter("@PostDesc", objRecruitment.PostDesc),
                new SqlParameter("@PostRequire", objRecruitment.PostRequire),
                new SqlParameter("@Experience", objRecruitment.Experience),
                new SqlParameter("@EduBackground", objRecruitment.EduBackground),
                new SqlParameter("@RequireCount", objRecruitment.RequireCount),
                new SqlParameter("@Manager", objRecruitment.Manager),
                new SqlParameter("@PhoneNumber", objRecruitment.PhoneNumber),
                new SqlParameter("@Email", objRecruitment.Email),
                new SqlParameter("@PostId", objRecruitment.PostId),
            };
            return SQLHelper.Update(sql, param);
        }
        /// <summary>
        /// 删除招聘信息
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public int DeleteRecruitment(string postId)
        {
            string sql = "delete from Recruitment where PostId=@PostId";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@PostId", postId)};
            return SQLHelper.Update(sql, param);
        }

    }
}
