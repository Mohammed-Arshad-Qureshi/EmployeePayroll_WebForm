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
    public partial class Register : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

     
        protected void Button2_Click(object sender, EventArgs e)
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand("spAddEmployee", this.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", TextBox1.Text);
                command.Parameters.AddWithValue("@LastName", TextBox2.Text);
                command.Parameters.AddWithValue("@Email", TextBox3.Text);
                command.Parameters.AddWithValue("@Password", TextBox4.Text);
                command.Parameters.AddWithValue("@Mobile", TextBox6.Text);
                this.connection.Open();

                int result = command.ExecuteNonQuery();
                if(result == 0 || result == -1)
                {
                    Label8.Text = "Email already Exists Please use another";
                }
                else
                {
                    Response.Redirect("Login.aspx"); 
                }

            }
        }
    }
}