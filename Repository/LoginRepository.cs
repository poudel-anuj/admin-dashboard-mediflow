using Dapper;
using mediflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mediflow.Repository
{
    public class LoginRepository
    {
        DynamicParameters parm = new DynamicParameters();
        readonly DBConnection db = new DBConnection();
        //public string Insert(login log)
        //{

        //    db.Connection();
        //    try
        //    {

        //        db.con.Open();

        //        parm.Add("username", log.username);
        //        parm.Add("password", log.password);
        //        parm.Add("@flag", "Insert");
        //        var data = SqlMapper.Query<string>(db.con, "sp_login", parm, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        db.con.Close();
        //    }

        //}


        //}
    }
}