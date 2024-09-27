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
    public partial class leadmaster : System.Web.UI.Page
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
               // Response.Write("An error occurred: " + ex.Message);
            }
        }

        private void BindDropdown()
        {
            if (ddlLeadSources != null) // Ensure ddlRole is instantiated
            {
               
                string query = "SELECT source_of_lead FROM source_master";

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
                            ddlLeadSources.DataSource = dt;
                            ddlLeadSources.DataTextField = "source_of_lead"; // Column name to display in dropdown
                            ddlLeadSources.DataValueField = "source_of_lead"; // Column name for the value of each item
                            ddlLeadSources.DataBind();
                        }
                    }
                }

            }
            throw new NotImplementedException();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Implement your logout logic here
            // For example, you can clear the session and redirect the user to the login page
             // Clear session data
            Response.Redirect("Login.aspx"); // Redirect to the login page
        }
        protected void BtnCreatelead_Click(object sender, EventArgs e)
        {
            var leadname = txtLeadName.Text;
            var area_of_city = txtAreaOfCity.Text;
            var city = txtCity.Text;
            var mobile = txtMobileNumber.Text;

            var source = ddlLeadSources.SelectedValue;
            string area_of_lead = "";

            if (rdbRuler.Checked)
            {
                area_of_lead = rdbRuler.Text;
            }
            else if(rdbUber.Checked)
            {
                area_of_lead = rdbUber.Text;
            }

            string metertype = "";

            if (rdbCommonMeter.Checked)
            {
                metertype = rdbCommonMeter.Text;
            }
            else if(rdbIndividualMeter.Checked)
            {
                metertype = rdbIndividualMeter.Text;
            }

            if (string.IsNullOrWhiteSpace(leadname)  || string.IsNullOrWhiteSpace(mobile) )
            {
                // Display an error message to the user indicating required fields are missing
                Response.Write("<script>alert('required fields are missing')</script>");
            }


            else
            {
                if (UserIdExists(mobile))
                {
                    // Display error message indicating user ID already exists


                    Response.Write("<script>alert('Lead  Id already exists.Please choose a different Lead Id.')</script>");
                    return;
                }
                else
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "INSERT INTO [leadmaster2] (lead_name,area_of_city, city, mobile_number,source_lead,area_of_lead,meter_type) VALUES (@leadname, @area_of_city, @city, @mobile,@source,@area_of_lead,@meter_type)";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@leadname", leadname);
                                command.Parameters.AddWithValue("@area_of_city", area_of_city);
                                command.Parameters.AddWithValue("@city", city);
                                command.Parameters.AddWithValue("@mobile", mobile);
                                command.Parameters.AddWithValue("@source", source);
                                command.Parameters.AddWithValue("@area_of_lead", area_of_lead);
                                command.Parameters.AddWithValue("@meter_type", metertype);

                                connection.Open();
                                int rowsAffected = command.ExecuteNonQuery();


                                ScriptManager.RegisterStartupScript(this, GetType(), "Created  new lead Successfuly", "showAlert();", true);
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

        private bool UserIdExists(string mobile)
        {
            string query = "SELECT COUNT(*) FROM [leadmaster2] WHERE mobile_number= @mobile";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mobile", mobile);

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

                throw new NotImplementedException();
            }
        }
        protected void ClearFields()
        {
            // Clear the text of textboxes
            txtLeadName.Text = "";
            txtAreaOfCity.Text = "";
           txtCity.Text = "";
            txtMobileNumber.Text = "";
            // Clear the selection of radio buttons
            rdbRuler.Checked = false;
            rdbUber.Checked = false;
            rdbIndividualMeter.Checked = false;
            rdbCommonMeter.Checked = false;
            // Clear the selection of dropdown lists
            ddlLeadSources.SelectedIndex = 0; // Assuming the first item is a default value
                                          // Add additional field clearing logic as needed
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {


            // Redirect to the logout page or any other page
            Response.Redirect("~/homepage.aspx");
        }

    }

}
