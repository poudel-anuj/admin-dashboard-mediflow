using Dapper;
using mediflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mediflow.Repository
{
    public class CategoryRepository
    {
        DynamicParameters parm = new DynamicParameters();
        readonly DBConnection db = new DBConnection();

        public string Insert(category p)
        {
            db.Connection();
            try
            {
                db.con.Open();
                parm.Add("@id", p.id);
                parm.Add("categoryName", p.categoryName);
                parm.Add("@status", p.status);
                parm.Add("@flag", "Insert");
                var data = SqlMapper.Query<string>(db.con, "sp_category", parm, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
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

        public category GetCategoryById(int id)
        {
            db.Connection();
            try
            {
                db.con.Open();
                parm.Add("@id", id);
                parm.Add("@flag", "getbyid");
                var data = SqlMapper.Query<category>(db.con, "sp_category", parm, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
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

        public List<category> GetCategoryList()
        {
            db.Connection();
            try
            {
                db.con.Open();
                parm.Add("@flag", "List");
                var data = SqlMapper.Query<category>(db.con, "sp_category", parm, commandType: System.Data.CommandType.StoredProcedure).ToList();
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

        public string Delete(category c)
        {
            db.Connection();
            try
            {
                db.con.Open();
                parm.Add("@id", c.id);
                parm.Add("@flag", "delete");














                var data = SqlMapper.Query<string>(db.con, "sp_category", parm, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
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

        public void Update(category p)
        {
            db.Connection();
            try
            {
                db.con.Open();
                parm.Add("@id", p.id);
                parm.Add("@categoryName", p.categoryName);
                parm.Add("@status", p.status);
                parm.Add("@flag", "update");
                db.con.Execute("sp_category", parm, commandType: System.Data.CommandType.StoredProcedure);
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
