using Dapper;
using mediflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mediflow.Repository
{
    public class SliderRepository
    {

        DynamicParameters parm = new DynamicParameters();
        readonly DBConnection db = new DBConnection();

        public void Insert(slider s)
        {

            db.Connection();
            try
            {

                db.con.Open();

                parm.Add("title", s.title);
                parm.Add("image", s.image);
                parm.Add("@status", s.status);
                parm.Add("@flag", "Insert");
                db.con.Execute("sp_slider", parm, commandType: System.Data.CommandType.StoredProcedure);

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

        public List<slider> GetPSliderList()
        {
            db.Connection();
            try
            {
                db.con.Open();
                parm.Add("@flag", "List");
                var data = SqlMapper.Query<slider>(db.con, "sp_slider", parm, commandType: System.Data.CommandType.StoredProcedure).ToList();
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

        public slider GetById(int id)
        {
            db.Connection();
            try
            {
                db.con.Open();
                parm.Add("@id", id);
                parm.Add("@flag", "getbyid");
                var data = SqlMapper.Query<slider>(db.con, "sp_slider", parm, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
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

        public void Delete(slider s)
        {
            db.Connection();
            try
            {
                db.con.Open();
                parm.Add("@id", s.id);
                parm.Add("@flag", "delete");
                db.con.Execute("sp_slider", parm, commandType: System.Data.CommandType.StoredProcedure);
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

        public void Update(slider s)
        {
            db.Connection();
            try
            {
                db.con.Open();
                parm.Add("@id", s.id);
                parm.Add("@title", s.title);
                parm.Add("@image", s.image);
                parm.Add("@status", s.status);
                parm.Add("@flag", "update");
                db.con.Execute("sp_slider", parm, commandType: System.Data.CommandType.StoredProcedure);

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