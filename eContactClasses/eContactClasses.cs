using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Econtacts.eContactClasses
{

    internal class eContactClass
    {
        //public int Cust_id { get; set; }
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public string ContactNum { get; set; }
         public string City { get; set; }


         static string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

        
        //reflecting data from db
        public DataTable ShowAllRecords()
        {

            //Step:1 database connection
            SqlConnection conn = new SqlConnection(ConnString);
            DataTable dt = new DataTable();
            try
            {
                //Writing SQL query
                string sql = "SELECT * FROM CustomerDetails";

                //creating CMD using Sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Creating datadaptor using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        //inserting data into db
        public bool Insert(eContactClass c)
        {
            bool isSuccess = false;
            

            SqlConnection conn = new SqlConnection(ConnString);
            try
            {
                string sql = "INSERT INTO CustomerDetails (FirstName,LastName,ContactNum,City) VALUES (@FirstName,@LastName,@ContactNum,@City)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNum", c.ContactNum);
                cmd.Parameters.AddWithValue("@City", c.City);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                    return isSuccess;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();

            }
            return isSuccess;
        }

        //updating Data into db
        public bool Update(eContactClass c)
        {
            bool isSuccess = false;


            SqlConnection conn = new SqlConnection(ConnString);
            try
            {
                string sql = "UPDATE CustomerDetails SET FirstName=@FirstName, LastName=@LastName,City=@City WHERE ContactNum=@ContactNum";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNum", c.ContactNum);
                cmd.Parameters.AddWithValue("@City", c.City);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                    return isSuccess;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();

            }
            return isSuccess;
        }

        public bool Delete(eContactClass c)
        {
            bool isSuccess = false;


            SqlConnection conn = new SqlConnection(ConnString);
            try
            {
                string sql = "DELETE FROM CustomerDetails WHERE ContactNum=@ContactNum";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ContactNum", c.ContactNum);
                
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                    return isSuccess;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();

            }
            return isSuccess;
        }

    }
}
    
