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
    public partial class userleadupdate : System.Web.UI.Page
    {
        string connectionString = "Data Source = localhost\\SQLEXPRESS01; Initial Catalog = cms; Integrated Security = True";

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
                if (Session["id"] != null && Session["mobile"] != null && Session["leadname"] != null && Session["aeaofcity"] != null && Session["source"] != null && Session["areaoflead"] != null && Session["metertype"] != null)
                {
                    // Retrieve data from session variables
                    var id = Session["id"].ToString();
                    string mobile = Session["mobile"].ToString();
                    string leadname = Session["leadname"].ToString();
                    string areaofcity = Session["aeaofcity"].ToString();
                    string city = Session["city"].ToString();
                    string source = Session["source"].ToString();
                    string areaoflead = Session["areaoflead"].ToString();
                    string metertype = Session["metertype"].ToString();
                    // Set the values of the textboxes

                    txid.Text = id;
                    txtCity.Text = city ?? "";
                    txtAreaOfCity.Text = areaofcity ?? "";
                    txtLeadName.Text = leadname;
                    //  ddlRole.SelectedValue = role;
                    txtAreaOfCity.Text = areaofcity;
                    // txtCity.Text = city;
                    txtMobileNumber.Text = mobile;
                    ddlLeadSources.SelectedValue = source;

                    if (areaoflead == "Urban")
                    {
                        rdbUber.Checked = true;
                    }
                    else if (areaoflead == "Rular")
                    {
                        rdbRuler.Checked = true;
                    }

                    if (metertype == "Common Meter")
                    {
                        rdbCommonMeter.Checked = true;
                    }
                    else if (metertype == "Individual Meter")
                    {
                        rdbIndividualMeter.Checked = true;
                    }
                    // Add more conditions for other areas if needed
                }
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

        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {


            // Redirect to the logout page or any other page
            Response.Redirect("~/login.aspx");
        }
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string id = txid.Text;

            string leadname = txtLeadName.Text;
            string areaofcity = txtAreaOfCity.Text;
            string city = txtCity.Text;
            string mobile = txtMobileNumber.Text;
            string source = ddlLeadSources.SelectedValue;

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

            // Perform validation here if needed

            // Check if the password and confirm password match

            // Assuming you're using SQL Server
            string connectionString = "Data Source = localhost\\SQLEXPRESS01; Initial Catalog = cms; Integrated Security = True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE [leadmaster2] SET lead_name = @leadname, area_of_city = @areaofcity, city = @city, source_lead=@source, area_of_lead=@areaoflead , meter_type=@metertype , mobile_number= @mobile  WHERE id=@id ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@leadname", leadname);
                command.Parameters.AddWithValue("@areaofcity", areaofcity);
                command.Parameters.AddWithValue("@city", city);
                command.Parameters.AddWithValue("@source", source);
                command.Parameters.AddWithValue("@areaoflead", area_of_lead);
                command.Parameters.AddWithValue("@metertype", metertype);
                command.Parameters.AddWithValue("@mobile", mobile);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    // Check if the update was successful
                    if (rowsAffected > 0)
                    {
                        // Update successful
                        // Optionally, you can display a success message or redirect the user to another page
                        ScriptManager.RegisterStartupScript(this, GetType(), "UpdateSuccess", "showAlert(); window.location.href = 'userleadmasterdata.aspx';", true);
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
            Response.Redirect("~/userleadmasterdata.aspx");
        }
    }
}