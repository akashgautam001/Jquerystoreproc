using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CrudWthStoreJquery.Models;

namespace CrudWthStoreJquery.Models
{
    public class DBhelper
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

        public string InsertData(Employess objcust, HttpPostedFileBase Image)
        {

            string result = "";
            try
            {
                SqlCommand cmd = new SqlCommand("Insert_Employes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", objcust.Name);
                cmd.Parameters.AddWithValue("@FatherName", objcust.FatherName);
                cmd.Parameters.AddWithValue("@Dob", objcust.Dob);
                cmd.Parameters.AddWithValue("@Phone", objcust.Phone);
                cmd.Parameters.AddWithValue("@Age", objcust.Age);
                cmd.Parameters.AddWithValue("@Image", objcust.Image);
                con.Open();
                cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        public List<Employess> Selectalldata()
        {
            DataSet ds = null;
            List<Employess> custlist = null;
            try
            {
                SqlCommand cmd = new SqlCommand("Select_Employes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                custlist = new List<Employess>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Employess cobj = new Employess();
                    cobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    cobj.FatherName = ds.Tables[0].Rows[i]["FatherName"].ToString();
                    cobj.Dob = ds.Tables[0].Rows[i]["Dob"].ToString();
                    cobj.Phone = ds.Tables[0].Rows[i]["Phone"].ToString();
                    cobj.Image = ds.Tables[0].Rows[i]["Image"].ToString();
                    cobj.Age = Convert.ToInt32(ds.Tables[0].Rows[i]["Age"].ToString());

                    custlist.Add(cobj);
                }
                return custlist;
            }
            catch
            {
                return custlist;
            }
            finally
            {
                con.Close();
            }
        }

        public int DeleteData(int Id)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteProject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return result = 0;
            }
            finally
            {
                con.Close();
            }



        }
    }
}