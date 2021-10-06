using Dapper;
using mediflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mediflow.Repository
{
    public class PostRepository
    {
        DynamicParameters parm = new DynamicParameters();
        readonly DBConnection db = new DBConnection();

        public void Insert(post p)
        {
            db.Connection();
            try
            {       
                db.con.Open();
                parm.Add("title", p.id);
                parm.Add("title", p.title);
                parm.Add("userId", p.userId);
                parm.Add("slug", p.slug);
                parm.Add("description", p.description);
                parm.Add("categoryId", p.categoryId);
                parm.Add("image", p.image);
                parm.Add("metaDescription", p.metaDescription);
                parm.Add("metaKeyword", p.metaKeyword);
                parm.Add("@status", p.status);
                parm.Add("@flag", "Insert");
                db.con.Execute("sp_post", parm, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.con.Close();
            }

        }

        public List<post> GetPostList()
        {
            db.Connection();
            try
            {
                db.con.Open();
                parm.Add("@flag", "List");
                var data = SqlMapper.Query<post>(db.con, "sp_post", parm, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }

        public post GetById(int id)
        {
            db.Connection();
            try
            {

                db.con.Open();
                parm.Add("@id", id);
                parm.Add("@flag", "getbyid");
                var data = SqlMapper.Query<post>(db.con, "sp_post", parm, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }

        public void Delete(post p)
        {
            db.Connection();
            try
            {
                db.con.Open();
                parm.Add("@id", p.id);
                parm.Add("@userId", p.userId);
                parm.Add("@flag", "delete");
                db.con.Execute("sp_post", parm, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }

        public void Update(post p)
        {
            db.Connection();
            try
            {
                db.con.Open();
                parm.Add("@id", p.id);
                parm.Add("@userId", p.userId);
                parm.Add("@title", p.title);
                parm.Add("@slug", p.slug);
                parm.Add("@description", p.description);
                parm.Add("@categoryId", p.categoryId);
                parm.Add("@image", p.image);
                parm.Add("@metaDescription", p.metaDescription);
                parm.Add("@metaKeyword", p.metaKeyword);
                parm.Add("@status", p.status);
                parm.Add("@flag", "update");
                db.con.Execute("sp_post", parm, commandType: System.Data.CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }
    }
}