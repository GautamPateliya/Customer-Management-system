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
    public partial class showsitemasterdata : System.Web.UI.Page
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=cms;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }

        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Implement your logout logic here
            // For example, you can clear the session and redirect the user to the login page
            // Clear session data
            Response.Redirect("Login.aspx"); // Redirect to the login page
        }
        private void BindGridView()
        {
            // Fetch data from the database
            DataTable dt = GetDataFromDatabase();

            // Check if the DataTable contains data
            if (dt != null && dt.Rows.Count > 0)
            {
                // Bind the DataTable to the GridView
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                // Handle the case where no data is retrieved from the database
                // For example, display a message or hide the GridView
                GridView1.Visible = false;
                // You can also display a message to indicate no data
            }
        }

      
        private DataTable GetDataFromDatabase()
        {
            // Connect to the database and execute SQL query to fetch data
            // Replace this with your actual database connection and query
            // Example:


            string query = "SELECT lead_name,kw,address, area_of_city, city, mobile_no, source_lead, area_lead, meter_type,price,addsitephoto FROM dbo.sitemaster";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                   
                    return dt;
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Find the Image control in the current GridView row
                Image img = (Image)e.Row.FindControl("btnViewImage");

                // Get the binary image data from the DataRow
                object imageDataObj = DataBinder.Eval(e.Row.DataItem, "addsitephoto");

                // Check if the imageDataObj is DBNull
                if (imageDataObj != DBNull.Value)
                {
                    // Convert the binary image data to byte array
                    byte[] imageData = (byte[])imageDataObj;

                    // Convert the byte array to Base64 string
                    string base64String = Convert.ToBase64String(imageData, 0, imageData.Length);

                    // Set the ImageUrl of the Image control to the Base64 string
                    img.ImageUrl = "data:image/jpeg;base64," + base64String;
                }
                else
                {
                    // If the imageDataObj is DBNull, set a default image or leave it blank
                    img.ImageUrl = "~/Images/default.jpg"; // Replace with your default image path
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Retrieve the mobile number from the DataKeys collection using the current row index
            string mobileNumber = GridView1.DataKeys[e.RowIndex].Value.ToString();

            // Call the method to delete the row from the database using the mobile number
            DeleteRowFromDatabase(mobileNumber);

            // Rebind the GridView to reflect the changes

          
            BindGridView();

        }


        private void DeleteRowFromDatabase(string mobileNumber)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM sitemaster WHERE  mobile_no= @mobile_number";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@mobile_number", mobileNumber);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }


        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                // Retrieve the index of the clicked row
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                // Retrieve the data associated with the clicked row
                string mobile = GridView1.DataKeys[rowIndex].Value.ToString();

                string leadname = GridView1.Rows[rowIndex].Cells[0].Text; // Assuming UserId is in the first column
                string address = GridView1.Rows[rowIndex].Cells[2].Text;
                string kw = GridView1.Rows[rowIndex].Cells[1].Text;
                string price = GridView1.Rows[rowIndex].Cells[9].Text;
              
                // Store the data in session variables
                Session["mobile"] = mobile;
                Session["leadname"] = leadname;
                Session["address"] = address;
                Session["kw"] = kw;
                Session["price"] = price;

                // Redirect to another page for editing
                Response.Redirect("updatesitemaster.aspx");
            }

           

          
            

        }

        protected void btnViewImage_Click(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            string mobile_no = btn.CommandArgument;
            byte[] imageData = GetImageDataFromDatabase(mobile_no);

            if (imageData != null)
            {
                string base64String = Convert.ToBase64String(imageData);
                string imageUrl = "data:image/jpeg;base64," + base64String;
                LargeImage.ImageUrl = imageUrl;
                ModalPopupExtender1.Show(); // Show the modal popup
            }
            else
            {
                // Handle the case where imageData is null
                // For example, display a default image or show an error message
            }
        }

        private byte[] GetImageDataFromDatabase(string mobile_no)
        {
            byte[] imageData = null;

            string query = "SELECT addsitephoto FROM sitemaster WHERE mobile_no = @mobile_number";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mobile_number", mobile_no);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                imageData = (byte[])reader[0]; // Assuming addsitephoto is the first column in the result set
                            }
                        }
                    }
                }
            }

            return imageData;
        }
    }
}