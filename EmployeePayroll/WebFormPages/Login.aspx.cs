using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeePayroll.WebFormPages
{
    public partial class Login : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        string Email, Password;
        int EmpId;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand("spSignIn", this.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Email", TextBox1.Text);
                command.Parameters.AddWithValue("@Password", TextBox2.Text);
                this.connection.Open();
                SqlDataReader rd = command.ExecuteReader();
                if (rd.Read())
                {
                    EmpId = rd["EmpId"] == DBNull.Value ? default : rd.GetInt32(0);
                    Email = rd["Email"] == DBNull.Value ? default : rd.GetString(3);
                    Password = rd["password"] == DBNull.Value ? default : rd.GetString(4);

                }

                if (Email != TextBox1.Text && Password != TextBox2.Text)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Session["id"] = EmpId;
                    Response.Redirect("Home.aspx");
                }

            }

        }
    }
}