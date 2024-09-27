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
    public partial class offertypemaster : System.Web.UI.Page
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=cms;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void create(object sender, EventArgs e)
        {

            // Replace with your actual connection string


            string offertype = txtRole.Text;

            if (string.IsNullOrWhiteSpace(offertype))
            {
                Response.Write("<script>alert('Required fields are missing')</script>");
            }
            else
            {

                if (UserIdExists(offertype))
                {
                    // Display error message indicating user ID already exists


                    Response.Write("<script>alert('Offer Type already exists.Please choose a different Offer type.')</script>");

                    ClearFields();
                    return;
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO offertypemaster (offertype) VALUES (@offertype)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@offertype", offertype);


                            connection.Open();
                            command.ExecuteNonQuery();

                            ScriptManager.RegisterStartupScript(this, GetType(), "CreateOffertypeSuccess", "showAlert();", true);
                            ClearFields();

                        }

                    }
                }
            }
        }

        private bool UserIdExists(object offertype)
        {
            string query = "SELECT COUNT(*) FROM [offertypemaster] WHERE offertype= @offertype";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@offertype", offertype);

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