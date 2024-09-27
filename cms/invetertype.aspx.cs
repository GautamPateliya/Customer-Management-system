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
    public partial class invetertype : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT id,inveter_type FROM [inveter]", con))
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
                string query = "DELETE FROM [inveter] WHERE id = @id";
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


            string inveter = txtinverter.Text;


            if (string.IsNullOrWhiteSpace(inveter))
            {
                Response.Write("<script>alert('Required fields are missing')</script>");
            }
            else
            {

                if (UserIdExists(inveter))
                {
                    // Display error message indicating user ID already exists


                    Response.Write("<script>alert('Inveter Type already exists.Please choose a different Inveter Type.')</script>");
                    return;
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO  inveter (inveter_type) VALUES (@inveter)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@inveter", inveter);


                            connection.Open();
                            command.ExecuteNonQuery();

                            ScriptManager.RegisterStartupScript(this, GetType(), "CreateInvetertypeSuccess", "showAlert();", true);
                            ClearFields();

                        }

                    }
                }
            }
        }

        private bool UserIdExists(object inveter)
        {
            string query = "SELECT COUNT(*) FROM [inveter] WHERE inveter_type= @inveter";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@inveter", inveter);

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


            // Redirect to the logout page or any other page
            Response.Redirect("~/login.aspx");
        }
        protected void ClearFields()
        {
            txtinverter.Text = "";

        }
        protected void btncancel_Click(object sender, EventArgs e)
        {


            // Redirect to the logout page or any other page
            Response.Redirect("~/homepage.aspx");
        }
    }
}