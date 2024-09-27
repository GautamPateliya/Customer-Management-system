using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace cms
{
    public partial class Createnewuser : System.Web.UI.Page
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=cms;Integrated Security=True";
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
        protected void create(object sender, EventArgs e)
        {

            var userid = txtUserMobileNumber.Text;
            var role = ddlRole.SelectedValue;
            var email = txtEmail.Text;
            var password = txtPassword.Text;
            if (string.IsNullOrWhiteSpace(userid) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                // Display an error message to the user indicating required fields are missing
                Response.Write("<script>alert('required fields are missing')</script>");


                // Check if the user ID already exists in the database



            }
            else
            {
                if (UserIdExists(userid))
                {
                    // Display error message indicating user ID already exists


                    Response.Write("<script>alert('User ID already exists.Please choose a different user ID.')</script>");
                    return;
                }
                else
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "INSERT INTO [user] (userid, role, email, [password]) VALUES (@userid, @role, @email, @password)";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@userid", userid);
                                command.Parameters.AddWithValue("@role", role);
                                command.Parameters.AddWithValue("@email", email);
                                command.Parameters.AddWithValue("@password", password);

                                connection.Open();
                                int rowsAffected = command.ExecuteNonQuery();


                                ScriptManager.RegisterStartupScript(this, GetType(), "Created  new User Successfuly", "showAlert();", true);
                                ClearFields();

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                }
            }

        }

        private bool UserIdExists(string userid)
        {
            string query = "SELECT COUNT(*) FROM [user] WHERE userid= @userid";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userid", userid);

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

        protected void customValidatorEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Regular expression pattern for validating email address
            string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";

            // Check if the email matches the pattern
            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(args.Value, emailPattern);
        }

       
        protected void ClearFields()
        {
            txtConfirmPassword.Text = "";
            txtEmail.Text = "";
            txtUserMobileNumber.Text = "";
            txtPassword.Text = "";

        }
        protected void btncancel_Click(object sender, EventArgs e)
        {


            // Redirect to the logout page or any other page
            Response.Redirect("~/homepage.aspx");
        }
    }
}