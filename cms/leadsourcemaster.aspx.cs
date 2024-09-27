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
    public partial class leadsourcemaster : System.Web.UI.Page
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=cms;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }


        }
        private void BindGrid()
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT id,source_of_lead FROM [source_master]", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "DeleteRow")
            {
                // Get the UserID of the row to be deleted
                string Id = e.CommandArgument.ToString();

                // Call the method to delete the row from the database
                DeleteRowFromDatabase(Id);

                // Rebind the GridView to reflect the changes
                BindGrid();
            }
        }

        private void DeleteRowFromDatabase(string Id)
        {
            // Your code to delete the row from the database goes here
            // Example:
            // string connectionString = "YourConnectionStringHere";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM [source_master] WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", Id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        protected void create(object sender, EventArgs e)
        {

            // Replace with your actual connection string
            var source = txtLeadSource.Text;
            if (string.IsNullOrWhiteSpace(source))
            {
                Response.Write("<script>alert('Required fields are missing')</script>");
            }
            else
            {
                if (UserIdExists(source))
                {
                    // Display error message indicating user ID already exists


                    Response.Write("<script>alert('lead source already exists.Please choose a different lead source.')</script>");
                    return;
                }
                else
                {

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO source_master (source_of_lead) VALUES (@source_of_lead)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@source_of_lead", source);

                            connection.Open();
                            command.ExecuteNonQuery();

                            // Register startup script directly
                            string script = "<script type='text/javascript'>showAlert();</script>";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CreateleadsourceSuccess", script);
                            BindGrid();
                            clearfiled();

                        }



                    }
                }
            }
        }

        private void clearfiled()
        {
            txtLeadSource.Text = "";
        }

        private bool UserIdExists(string source)
        {



            string query = "SELECT COUNT(*) FROM [source_master] WHERE source_of_lead= @source_of_lead";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@source_of_lead", source);

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

        protected void btnLogout_Click(object sender, EventArgs e)
        {


            Response.Redirect("login.aspx"); // Redirect to the login page
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {


            // Redirect to the logout page or any other page
            Response.Redirect("~/homepage.aspx");
        }
    }
}