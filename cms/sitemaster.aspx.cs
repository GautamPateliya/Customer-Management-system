using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace cms
{
    public partial class sitemaster : System.Web.UI.Page
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

            try
            {
                if (!IsPostBack)
                {
                    BindDropdownleadsource();
                }
            }
            catch (Exception ex)
            {
                // Catching a general exception type
                Response.Write("An error occurred: " + ex.Message);
            }

        }

        private void BindDropdownleadsource()
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

            }

        
        private void BindDropdown()
        {

            string query = "SELECT id, CONCAT(id, ' - ', lead_name) AS display_text FROM leadmaster2"; // Assuming you want to display both ID and lead_name

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
                        ddlLeadSources2.DataSource = dt;
                        ddlLeadSources2.DataTextField = "display_text"; // Column name containing concatenated values
                        ddlLeadSources2.DataValueField = "display_text"; // Column name for the value of each item (assuming id is the value field)
                        ddlLeadSources2.DataBind();
                    }
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


        protected void ddlLeadNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLeadName = ddlLeadSources2.SelectedValue;

            dynamic leadSourceData = GetLeadSourceData(selectedLeadName);

            if (leadSourceData != null)
            {
                txtAreaOfCity.Text = leadSourceData.Adress;
                txtCity.Text = leadSourceData.city;
                txtMobileNumber.Text = leadSourceData.mobile;

                // Verify if the selected value exists in the dropdown list items of ddlLeadSources
                if (ddlLeadSources.Items.FindByValue(leadSourceData.source) != null)
                {
                    ddlLeadSources.SelectedValue = leadSourceData.source;
                }
                else
                {
                    // Handle the case where the selected value doesn't exist in the dropdown list items
                    // For example, reset the selection to a default value or display an error message
                    ddlLeadSources.SelectedIndex = 0;
                    // Or display an error message to the user
                    //errorMessageLabel.Text = "Selected value is not valid for ddlLeadSources.";
                }

                // Set radio button states for area of lead
                SetRadioButtonState(rdbRuler, leadSourceData.arealead == "Rular");
                SetRadioButtonState(rdbUber, leadSourceData.arealead == "Urban");

                // Set radio button states for meter type
                SetRadioButtonState(rdbCommonMeter, leadSourceData.meter == "Common Meter");
                SetRadioButtonState(rdbIndividualMeter, leadSourceData.meter == "Individual Meter");
            }
            else
            {
                txtAreaOfCity.Text = "No data found for the selected lead.";
                txtCity.Text = "";
            }
        }


        private void SetRadioButtonState(RadioButton radioButton, bool state)
        {
            radioButton.Checked = state;
        }

        public static dynamic GetLeadSourceData(string selectedLeadName)
        {
            string[] splitid = selectedLeadName.Split('-');
            string selectedid = splitid[0];

            string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=cms;Integrated Security=True";
            string query = "SELECT area_of_city, city , mobile_number , source_lead , area_of_lead , meter_type FROM leadmaster2 WHERE id = @id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", selectedid);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new { Adress = reader["area_of_city"].ToString(), city = reader["city"].ToString(), mobile = reader["mobile_number"].ToString() , source = reader["source_lead"].ToString() , arealead = reader["area_of_lead"].ToString(),meter =reader["meter_type"].ToString()};
                    }
                }
            }
            return null;
        }
        protected void BtnCreatelead_Click(object sender, EventArgs e)
        {
            var leadname = ddlLeadSources2.SelectedValue;
            var kw = txkw.Text;
            var address = txaddress.Text;

            var area_of_city = txtAreaOfCity.Text;
            var city = txtCity.Text;
            var mobile = txtMobileNumber.Text;

            //  var source = txleadsources.Text;
            var source = ddlLeadSources.SelectedValue;
            var price = txprice.Text;

            string area_of_lead = "";

            if (rdbRuler.Checked)
            {
                area_of_lead = rdbRuler.Text;
            }
            else if (rdbUber.Checked)
            {
                area_of_lead = rdbUber.Text;
            }

            string metertype = "";

            if (rdbCommonMeter.Checked)
            {
                metertype = rdbCommonMeter.Text;
            }
            else if (rdbIndividualMeter.Checked)
            {
                metertype = rdbIndividualMeter.Text;
            }

            byte[] fileData = null; // Initialize the variable

            // Check if a file has been uploaded
            if (fileUpload.HasFile)
            {
                // Read the binary data of the uploaded file
                fileData = fileUpload.FileBytes;
            }

            // Check if any required fields are missing
            if (string.IsNullOrWhiteSpace(leadname) || string.IsNullOrWhiteSpace(area_of_city) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(mobile) || string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(area_of_lead) || string.IsNullOrWhiteSpace(metertype) || string.IsNullOrWhiteSpace(kw) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(price))
            {
                // Display an error message to the user indicating required fields are missing
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Required fields are missing');", true);
            }
            else
            {
                // Check if the mobile number already exists
                if (UserIdExists(mobile))
                {
                    // Display error message indicating user ID already exists
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Lead ID already exists. Please choose a different Lead Name.');", true);
                }
                else
                {
                    // Insert data into the database
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "INSERT INTO [sitemaster] (lead_name, kw, address, area_of_city, city, mobile_no, area_lead, meter_type, source_lead, price, addsitephoto) VALUES (@leadname, @kw, @address, @area_of_city, @city, @mobile, @area_of_lead, @meter_type, @source, @price, @fileData)";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@leadname", leadname);
                                command.Parameters.AddWithValue("@kw", kw);
                                command.Parameters.AddWithValue("@address", address);
                                command.Parameters.AddWithValue("@area_of_city", area_of_city);
                                command.Parameters.AddWithValue("@city", city);
                                command.Parameters.AddWithValue("@mobile", mobile);
                                command.Parameters.AddWithValue("@area_of_lead", area_of_lead);
                                command.Parameters.AddWithValue("@meter_type", metertype);
                                command.Parameters.AddWithValue("@source", source);
                                command.Parameters.AddWithValue("@price", price);

                                // Check if fileData is not null (i.e., if a file was uploaded)
                                if (fileData != null)
                                {
                                    command.Parameters.AddWithValue("@fileData", fileData);
                                }
                                else
                                {
                                    // If no file was uploaded, insert NULL into the database
                                    command.Parameters.AddWithValue("@fileData", DBNull.Value);
                                }

                                connection.Open();
                                int rowsAffected = command.ExecuteNonQuery();

                                // Display success message
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data submitted successfully.');", true);
                                ClearFields(); // Clear form fields
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('An error occurred while submitting the data: " + ex.Message + "');", true);
                    }
                }
            }

                   
            
        }
       
            private void ClearFields()
        {
            // Clear the text of textboxes
            ddlLeadSources.SelectedIndex = 0;
            txkw.Text = "";
            txaddress.Text = "";
            ddlLeadSources2.SelectedIndex = 0;
            txprice.Text = "";
            txtAreaOfCity.Text = "";
            txtCity.Text = "";
            txtMobileNumber.Text = "";
            rdbCommonMeter.Checked = false;
            rdbIndividualMeter.Checked = false;
            rdbRuler.Checked = false;
            rdbUber.Checked = false;

            txprice.Text = "";


            // Clear the selection of radio buttons
           
           
            // Clear the selection of dropdown lists
            ddlLeadSources2.SelectedIndex = 0;
           
        }

        private bool UserIdExists(string mobile)
        {
            string query = "SELECT COUNT(*) FROM [sitemaster] WHERE mobile_no= @mobile";

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
                         // Rethrow the exception to propagate it up the call stack
                    }
                }

                throw new NotImplementedException();
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {


            // Redirect to the logout page or any other page
            Response.Redirect("~/homepage.aspx");
        }
    }

       
    
}