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
    public partial class usersitemasterupdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["leadname"] != null && Session["mobile"] != null && Session["kw"] != null && Session["address"] != null && Session["price"] != null)
                {
                    // Retrieve data from session variables
                    var leadname = Session["leadname"].ToString();
                    string mobile = Session["mobile"].ToString();
                    string kw = Session["kw"].ToString();
                    string address = Session["address"].ToString();

                    string price = Session["price"].ToString();
                    // Set the values of the textboxes

                    txleadname.Text = leadname;

                    txtMobileNumber.Text = mobile;

                    txkw.Text = kw;
                    txaddress.Text = address;
                    txprice.Text = price;


                }
                else
                {
                    Response.Write("<script>alert('data not found')</script>");
                }
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Implement your logout logic here
            // For example, you can clear the session and redirect the user to the login page
            // Clear session data
            Response.Redirect("Login.aspx"); // Redirect to the login page
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {


            string leadname = txleadname.Text;


            string kw = txkw.Text;
            string address = txaddress.Text;

            string mobile = txtMobileNumber.Text;
            string price = txprice.Text;




            // Assuming you're using SQL Server
            string connectionString = "Data Source = localhost\\SQLEXPRESS01; Initial Catalog = cms; Integrated Security = True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE [sitemaster] SET lead_name = @leadname, kw = @kw, address = @address, price=@price  WHERE mobile_no=@mobile";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@leadname", leadname);
                command.Parameters.AddWithValue("@kw", kw);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@price", price);

                command.Parameters.AddWithValue("@mobile", mobile);


                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    // Check if the update was successful
                    if (rowsAffected > 0)
                    {
                        // Update successful
                        // Optionally, you can display a success message or redirect the user to another page
                        ScriptManager.RegisterStartupScript(this, GetType(), "UpdateSuccess", "showAlert(); window.location.href = 'usershowsitemasterdata.aspx';", true);
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
        protected void btncancel_Click(object sender, EventArgs e)
        {


            // Redirect to the logout page or any other page
            Response.Redirect("~/usershowsitemasterdata.aspx");
        }

    }
}