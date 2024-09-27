using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.Script.Services;
namespace cms
{
    public partial class userpreparoffer : System.Web.UI.Page
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
        protected void showListButton_Click(object sender, EventArgs e)
        {
            hide();





        }

        private void hide()
        {
            try
            {
                if (listContainer.CssClass.Contains("hidden"))
                {
                    PopulateListFromDatabase();
                    listContainer.CssClass = "";
                }
                else
                {
                    listContainer.CssClass = "hidden";
                }
            }
            catch (Exception ex)
            {
                // Handle specific exceptions related to button click event
                // Log the exception or display an error message
                // Example: lblMessage.Text = "An error occurred: " + ex.Message;
            }
        }

        private void PopulateListFromDatabase()
        {
            try
            {
                string query = "SELECT inveter_type FROM inveter";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            DataTable table = new DataTable();
                            table.Load(reader);
                            Repeater1.DataSource = table;
                            Repeater1.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle specific exceptions related to list population
                // Log the exception or display an error message
                // Example: lblMessage.Text = "An error occurred while populating list: " + ex.Message;
            }
        }




        [WebMethod]
        public static List<string> GetSuggestions(string searchText)
        {
            List<string> suggestions = new List<string>();

            // Replace connection string with your database connection string

            string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=cms;Integrated Security=True";


            // Replace SQL query with your actual query to fetch suggestions from the database
            string query = "SELECT pv_brand FROM itemmaster WHERE pv_brand LIKE @searchText";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Parameterized query to prevent SQL injection
                    command.Parameters.AddWithValue("@searchText", searchText + "%");

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming suggestionColumn is the name of the column in your database table
                            string suggestion = reader["pv_brand"].ToString();
                            suggestions.Add(suggestion);
                        }
                    }
                }
            }

            return suggestions;
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {


            // Redirect to the logout page or any other page
            Response.Redirect("~/userhomepage.aspx");
        }



        protected void create(object sender, EventArgs e)
        {
            // Define variables to store retrieved values
            string kw = "";
            string subsidy = "";
            string areaOfCity = "";
            string mobileNumber = "";
            string price = "";

            // Retrieve lead name from dropdown list
            string leadname = ddlLeadSources2.SelectedValue;

            // Check if SiteSurvey checkbox is checked
            if (chkSiteSurvey.Checked)
            {
                string query = "SELECT kw,  area_of_city, mobile_no, price FROM sitemaster WHERE lead_name = @lead_name";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@lead_name", leadname);

                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    // Retrieve values from the database
                                    //  kw = reader["kw"].ToString();

                                    areaOfCity = reader["area_of_city"].ToString();
                                    mobileNumber = reader["mobile_no"].ToString();
                                    // price = reader["price"].ToString();

                                    // Insert the retrieved values into another table
                                    //   InsertIntoOtherTable(kw, address, areaOfCity, mobileNumber, price);
                                }
                            }
                            else
                            {
                                // Handle case where no rows are returned
                            }

                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            // Handle exceptions
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                }
            }

            string pvbrand = txtSearch.Text;
            string pvqty = " ";
            string wp = " ";

            string query2 = "SELECT pv_qty,kw,wp,total_price,subsidy FROM itemmaster WHERE pv_brand = @pv_brand";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    command.Parameters.AddWithValue("@pv_brand", pvbrand);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                pvqty = reader["pv_qty"].ToString();
                                // Process the data as needed
                                wp = reader["wp"].ToString();
                                kw = reader["kw"].ToString();
                                price = reader["total_price"].ToString();
                                subsidy = reader["subsidy"].ToString();

                            }
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }



            List<string> invetertype = new List<string>();
            foreach (RepeaterItem item in Repeater1.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    // Find the CheckBox and Label controls within the RepeaterItem
                    CheckBox checkBox = (CheckBox)item.FindControl("ItemCheckbox");
                    Label label = (Label)item.FindControl("ItemLabel");

                    // Check if the CheckBox is checked
                    if (checkBox.Checked)
                    {
                        // Insert the checked value into the SQL table
                        invetertype.Add(label.Text);
                    }
                }
            }
            string invetertypeString = string.Join("/,", invetertype);




            if (Pvbreandexists(pvbrand))
            {

                if (string.IsNullOrWhiteSpace(leadname) || string.IsNullOrWhiteSpace(pvbrand))
                {
                    // Display an error message to the user indicating required fields are missing
                    Response.Write("<script>alert('required fields are missing')</script>");
                }

                else
                {
                    if (UserIdExists(leadname))
                    {
                        //  Display error message indicating user ID already exists


                        Response.Write("<script>alert('offer  already created.Please choose a different offer')</script>");
                        return;
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO preparoffer (lead_name, kw, subsidy, area_of_city, mobile_number, price, pv_brand, pv_qty,wp,invetertype) VALUES (@leadname, @kw, @subsidy, @areaOfCity, @mobileNumber, @price, @pvbrand, @pvqty,@wp,@invetertype)";

                        // Establish connection and command
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            using (SqlCommand command = new SqlCommand(insertQuery, connection))
                            {
                                // Add parameters
                                command.Parameters.AddWithValue("@kw", kw);
                                command.Parameters.AddWithValue("@subsidy", subsidy);
                                command.Parameters.AddWithValue("@areaOfCity", areaOfCity);
                                command.Parameters.AddWithValue("@mobileNumber", mobileNumber);
                                command.Parameters.AddWithValue("@price", price);
                                command.Parameters.AddWithValue("@leadname", leadname);
                                command.Parameters.AddWithValue("@pvbrand", pvbrand);
                                command.Parameters.AddWithValue("@pvqty", pvqty);
                                command.Parameters.AddWithValue("@wp", wp);
                                command.Parameters.AddWithValue("@invetertype", invetertypeString);
                                try
                                {
                                    // Open connection and execute the query
                                    connection.Open();
                                    int rowsAffected = command.ExecuteNonQuery();
                                    Response.Write("<script>alert('offer successfully created')</script>");
                                    ClearFields();
                                    // Optionally, you can check the number of rows affected to ensure successful insertion.
                                }
                                catch (Exception ex)
                                {
                                    // Handle exceptions
                                    Console.WriteLine("Error: " + ex.Message);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (pvbrand == "")
                {
                    Response.Write("<script>alert('required fields are missing')</script>");
                }
                else
                {
                    // Assuming you've sanitized pvbrand before this point
                    Response.Write("<script>alert('PV brand does not exist. Please choose a different PV brand')</script>");
                    return;
                }

            }
        }

        private bool Pvbreandexists(string pvbrand)
        {
            string query = "SELECT COUNT(*) FROM [itemmaster] WHERE pv_brand= @pvbrand";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@pvbrand", pvbrand);

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

        private bool UserIdExists(string leadname)
        {
            string query = "SELECT COUNT(*) FROM [preparoffer] WHERE lead_name= @leadname";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@leadname", leadname);

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

        private void ClearFields()
        {
            txtSearch.Text = "";
            chkSiteSurvey.Checked = false;
            ddlLeadSources2.SelectedIndex = 0;
            hide();



        }

    }
}