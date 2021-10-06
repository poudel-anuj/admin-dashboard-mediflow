using Dapper;
using mediflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace mediflow.Repository
{
    public class RegisterRepository
    {
        DynamicParameters parm = new DynamicParameters();
        readonly DBConnection db = new DBConnection();

        public string Insert(register r)
        {
            db.Connection();
            try
            {
                db.con.Open();
                parm.Add("name", r.name);
                parm.Add("username", r.username);
                parm.Add("password", r.password);
                parm.Add("email", r.email);
                parm.Add("occupation", r.occupation);
                parm.Add("about", r.about);
          
                parm.Add("entrydate", DateTime.Now);
                parm.Add("@flag", "Insert");
                var data = SqlMapper.Query<string>(db.con, "sp_register", parm, commandType: CommandType.StoredProcedure).FirstOrDefault();
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


        public register login(string email, string password)
        {
            db.Connection();

            try
            {
                db.con.Open();
                DynamicParameters parm = new DynamicParameters();
                parm.Add("@email", email);
                parm.Add("@password", password);
                parm.Add("flag", "login");
                var data = SqlMapper.Query<register>(db.con, "sp_register", parm, commandType: CommandType.StoredProcedure).FirstOrDefault();
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

        public string UpdatePassword(register reg)
        {
            db.Connection();
            try
            {
                db.con.Open();
                DynamicParameters parm = new DynamicParameters();
                parm.Add("@id", reg.id);
                parm.Add("@email", reg.email);
                parm.Add("@password", reg.password);
                parm.Add("@new_pwd", reg.new_pwd);
                parm.Add("@old_pwd", reg.old_pwd);
               
                parm.Add("@flag", "changepw");
                var data = SqlMapper.Query<string>(db.con, "sp_register", parm, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
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

        public register GetById(int id)
        {
            db.Connection();
            try
            {

                db.con.Open();
                parm.Add("@id", id);
                parm.Add("@flag", "getbyid");
                var data = SqlMapper.Query<register>(db.con, "sp_register", parm, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
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

        public void ProfileUpdate(register r)
        {
            db.Connection();
            try
            {
                db.con.Open();
                parm.Add("@id", r.id);
                parm.Add("@name", r.name);
                parm.Add("@username", r.username);
                parm.Add("@email", r.email);
                parm.Add("@occupation", r.occupation);
                parm.Add("@about", r.about);
                parm.Add("@image", r.image);
       
                parm.Add("@flag", "update");
                db.con.Execute("sp_register", parm, commandType: System.Data.CommandType.StoredProcedure);

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