using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace cms
{
    public partial class superadminupdateid : System.Web.UI.Page
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=cms;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void create(object sender, EventArgs e)
        {
            string oldid = txtUserMobileNumber.Text;
            string oldpassword = txtoldPassword.Text;
            string newid = txuserid.Text;
            string newpassword = txtPassword.Text;
            int id = 1;

            if (UserIdExists(oldid) && oldpasswordExists(oldpassword))
            {
                // Code to execute if both the old user ID and old password exist

                string connectionString = "Data Source = localhost\\SQLEXPRESS01; Initial Catalog = cms; Integrated Security = True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE [adminid] SET userid = @userid, password = @password WHERE id =@id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@userid",newid);
                    command.Parameters.AddWithValue("@password",newpassword);
                    command.Parameters.AddWithValue("@id", id);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        // Check if the update was successful
                        if (rowsAffected > 0)
                        {
                            // Update successful
                            // Optionally, you can display a success message or redirect the user to another page
                            ScriptManager.RegisterStartupScript(this, GetType(), "UpdateSuccess", "showAlert(); ", true);
                            clearfiled();

                        }

                        else
                        {
                            // Update failed
                            Response.Write("Update failed!");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        Response.Write("An error occurred: " + ex.Message);
                    }
                }
            
        }
            else
            {
                Response.Write("<script>alert('User ID Invalid.Please choose a different user ID and password.')</script>");
                return;
            }

        }

        private void clearfiled()
        {
            txtoldPassword.Text = "";
            txtPassword.Text = "";
            txuserid.Text = "";
            txtoldPassword.Text = "";

        }

        private bool oldpasswordExists(string oldpassword)
        {
            string query = "SELECT COUNT(*) FROM [adminid] WHERE password= @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@password", oldpassword);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();

                        // If count is greater than 0, user ID already exists
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception (e.g., log it, display an error message)
                        // In a production application, you should handle exceptions more gracefully
                        throw; // Rethrow the exception to propagate it up the call stack
                    }
                }
            }
        }

        private bool UserIdExists(string oldid)
        {
            string query = "SELECT COUNT(*) FROM [adminid] WHERE userid= @userid";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userid", oldid);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();

                        // If count is greater than 0, user ID already exists
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception (e.g., log it, display an error message)
                        // In a production application, you should handle exceptions more gracefully
                        throw; // Rethrow the exception to propagate it up the call stack
                    }
                }
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {


            // Redirect to the logout page or any other page
            Response.Redirect("~/homepage.aspx");
        }

        
    }

    }