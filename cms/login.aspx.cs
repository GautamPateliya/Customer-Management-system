using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using Org.BouncyCastle.Crypto.Generators;

namespace cms
{
    public partial class login : System.Web.UI.Page
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=cms;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void loginbtn(object sender, EventArgs e)
        {
            var Userid = txtUserMobileNumber.Text;
            var password = txtPassword.Text;

            // Input Validation: Validate user inputs
            if (string.IsNullOrWhiteSpace(Userid) || string.IsNullOrWhiteSpace(password))
            {
                // Display an error message to the user indicating required fields are missing
                Response.Write("<script>alert('Required fields are missing')</script>");
                return; // Exit function to prevent further execution
            }

            // Check if the login is for the super admin
            // Assuming conn is your SqlConnection object and cmd is your SqlCommand object

            // Construct the SQL command to check if the user ID and password match any records in the database
            // Assuming conn is your SqlConnection object and cmd is your SqlCommand object

            // Construct the SQL query to check if the provided user ID and password match any records in the adminid table
            string query2 = "SELECT COUNT(*) FROM adminid WHERE userid = @UserId AND password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    // Use parameterized query to prevent SQL injection
                    command.Parameters.AddWithValue("@UserId", Userid);
                    command.Parameters.AddWithValue("@Password", password);

                    // Open the connection
                    connection.Open();

                    // Execute the query
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        // Login successful
                        Session["UserId"] = Userid;
                        // Regenerate session ID to prevent session fixation
                        RegenerateSession();
                        // Redirect to super admin homepage
                        Response.Redirect("homepage.aspx");
                        return; // Exit function
                    }
                    else
                    {
                        // Login failed
                        // Handle incorrect user ID or password
                    }
                }
            }


            // Database query to check user credentials for regular users
            string query = "SELECT userid, password, role FROM [user] WHERE userid = @Userid";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Userid", Userid);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            string storedPassword = reader["password"].ToString(); // Assuming password is stored as plain text
                                                                                   // Verify the entered password against the stored password
                            if (password == storedPassword)
                            {
                                // Authentication successful
                                // Store user information in session
                                string role = reader["role"].ToString(); // Assuming role is retrieved from the database

                                Session["UserId"] = Userid;
                                Session["Role"] = role;

                                // Regenerate session ID to prevent session fixation
                                RegenerateSession();

                                // Redirect based on user role
                                if (role == "sales" || role=="SALES" || role== "Sales")
                                {
                                    Response.Redirect("userhomepage.aspx");
                                }
                                else if (role == "Admin" || role == "admin" || role == "ADMIN")
                                {
                                    Response.Redirect("homepage.aspx");
                                }

                                else
                                {
                                    Response.Redirect("userhomepage.aspx");
                                }
                            }
                            else
                            {
                                // Invalid credentials, show error message
                                Response.Write("<script>alert('Invalid User Id Or Password')</script>");
                            }
                        }
                        else
                        {
                            // User not found, show error message
                            Response.Write("<script>alert('User not found')</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        Response.Write("<script>alert('An error occurred: " + ex.Message + "')</script>");
                    }
                }
            }
        }

        private void RegenerateSession()
        {
            Session.Clear(); // Clear existing session
            Session.Abandon(); // Abandon session
            Session.RemoveAll(); // Remove all session variables
            SessionIDManager manager = new SessionIDManager();
            string newSessionId = manager.CreateSessionID(HttpContext.Current);
            bool isRedirected = false;
            bool isAdded = false;
            manager.SaveSessionID(HttpContext.Current, newSessionId, out isRedirected, out isAdded);
        }



    }
}