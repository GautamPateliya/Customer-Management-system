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
    public partial class userrole : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT id,role FROM [role]", con))
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
                string query = "DELETE FROM [role] WHERE id = @id";
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


            string Role = txtRole.Text;

            if (string.IsNullOrWhiteSpace(Role))
            {
                Response.Write("<script>alert('Required fields are missing')</script>");
            }
            else
            {

                if (UserIdExists(Role))
                {
                    // Display error message indicating user ID already exists


                    Response.Write("<script>alert('User Role already exists.Please choose a different user Role.')</script>");
                    return;
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO role (role) VALUES (@Role)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Role", Role);


                            connection.Open();
                            command.ExecuteNonQuery();

                            ScriptManager.RegisterStartupScript(this, GetType(), "CreateUserRoleSuccess", "showAlert();", true);
                            BindGrid();
                            ClearFields();

                        }

                    }
                }
            }
        }

        private bool UserIdExists(object Role)
        {
            string query = "SELECT COUNT(*) FROM [role] WHERE role= @role";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@role", Role);

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
            txtRole.Text = "";

        }
        protected void btncancel_Click(object sender, EventArgs e)
        {


            // Redirect to the logout page or any other page
            Response.Redirect("~/homepage.aspx");
        }
    }
}