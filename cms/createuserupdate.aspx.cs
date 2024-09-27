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
    public partial class showpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindDropdown();
                }
            }
            catch (Exception ex)
            {
                // Catching a general exception type
                Response.Write("An error occurred: " + ex.Message);
            }

            if (!IsPostBack)
            {
                if (Session["UserId"] != null && Session["role"] != null && Session["email"] != null && Session["password"] != null)
                {
                    // Retrieve data from session variables
                    string userId = Session["UserId"].ToString();
                    string role = Session["role"].ToString();
                    string email = Session["email"].ToString();
                    string password = Session["password"].ToString();
                   
                    // Set the values of the textboxes
                    txtUserMobileNumber.Text = userId;
                    ddlRole.SelectedValue = role;
                    txtEmail.Text = email;
                    txtPassword.Text = password;
                    txtConfirmPassword.Text = password;
                }
            }
        }
        private void BindDropdown()
        {
            if (ddlRole != null) // Ensure ddlRole is instantiated
            {
                string con = "Data Source = localhost\\SQLEXPRESS01; Initial Catalog = cms; Integrated Security = True";
                string connectionString = con;
                string query = "SELECT role FROM role";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt != null && dt.Rows.Count > 0) // Ensure dt is not null and contains rows
                        {
                            ddlRole.DataSource = dt;
                            ddlRole.DataTextField = "role"; // Column name to display in dropdown
                            ddlRole.DataValueField = "role"; // Column name for the value of each item
                            ddlRole.DataBind();
                        }
                    }
                }

            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {


            // Redirect to the logout page or any other page
            Response.Redirect("~/login.aspx");
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {


            // Redirect to the logout page or any other page
            Response.Redirect("~/createuserdata.aspx");
        }
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string userId = txtUserMobileNumber.Text;
            string role = ddlRole.SelectedValue;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            // Perform validation here if needed

            // Check if the password and confirm password match
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                // Assuming you're using SQL Server
                string connectionString = "Data Source = localhost\\SQLEXPRESS01; Initial Catalog = cms; Integrated Security = True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE [user] SET role = @Role, email = @Email, password = @Password WHERE userid = @UserId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Role", role);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@UserId", userId);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        // Check if the update was successful
                        if (rowsAffected > 0)
                        {
                            // Update successful
                            // Optionally, you can display a success message or redirect the user to another page
                            ScriptManager.RegisterStartupScript(this, GetType(), "UpdateSuccess", "showAlert(); window.location.href = 'createuserdata.aspx';", true);
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
                // Password and confirm password do not match
                Response.Write("Password and confirm password do not match!");
            }
        }



    }
}