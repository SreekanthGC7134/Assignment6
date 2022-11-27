using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Assignment6.DAL
{
    public class desgDal
    {
        public SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public desgDal()
        {
            //call conncetionstring;conncetion string should be set in the web.conf file
            string conn = ConfigurationManager.ConnectionStrings["sree"].ConnectionString;
            con = new SqlConnection(conn);
            cmd.Connection = con;
        }
        public SqlConnection GetCon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public DataTable Getdeprt(BAL.desgBal obj)
        {
            string s = "SELECT * FROM tbl_dpt";
            SqlCommand cmd = new SqlCommand(s, GetCon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int InsertDesig(BAL.desgBal obj)
        {
            string qry = "insert into Designation values('" + obj.Desgination + "','" + obj.DepId + "')";
            SqlCommand cmd = new SqlCommand(qry, GetCon());
            return cmd.ExecuteNonQuery();
        }

        public DataTable desigview(BAL.desgBal obj)
        {
            string s = "select * from Designation td inner join tbl_dpt dt on td.Department_id=dt.Department_id";
            SqlCommand cmd = new SqlCommand(s, GetCon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int desgUpdate(BAL.desgBal obj)
        {
            string s = "update Designation set DesignationName='" + obj.Desgination + "' where DesignationId='" + obj.DesgId + "'";
            SqlCommand cmd = new SqlCommand(s, GetCon());
            return cmd.ExecuteNonQuery();
        }

        public int Deletedesig(BAL.desgBal obj)
        {
            string s = "delete from Designation where DesignationId='" + obj.DesgId + "'";
            SqlCommand cmd = new SqlCommand(s, GetCon());
            return cmd.ExecuteNonQuery();
        }
    }
}