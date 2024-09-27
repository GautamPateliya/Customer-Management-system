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
    public partial class userleadmasterdata : System.Web.UI.Page
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


            // Redirect to the logout page or any other page
            Response.Redirect("~/login.aspx");
        }

        protected void BindGridView()
        {
            // Connection string to your database


            string query = "SELECT id,lead_name, area_of_city, city, mobile_number, source_lead, area_of_lead, meter_type FROM dbo.leadmaster2";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Open the connection
                    connection.Open();

                    // Execute the command and load data into a DataTable
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);

                    // Bind the DataTable to the GridView
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            // Retrieve the mobile number from the DataKeys collection using the current row index
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();

            // Call the method to delete the row from the database using the mobile number
            DeleteRowFromDatabase(id);

            // Rebind the GridView to reflect the changes
            BindGridView();



        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                // Retrieve the index of the clicked row
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                // Retrieve the data associated with the clicked row
                string id = GridView1.DataKeys[rowIndex].Value.ToString();
                string leadname = GridView1.Rows[rowIndex].Cells[1].Text; // Assuming UserId is in the first column
                string area_of_city = GridView1.Rows[rowIndex].Cells[2].Text;
                string city = GridView1.Rows[rowIndex].Cells[3].Text;
                string mobile = GridView1.Rows[rowIndex].Cells[4].Text;

                string source_lead = GridView1.Rows[rowIndex].Cells[5].Text;
                string area_of_lead = GridView1.Rows[rowIndex].Cells[6].Text;
                string meter_type = GridView1.Rows[rowIndex].Cells[7].Text;

                if (city == "&nbsp;" || city == "&amp;nbsp;")
                {
                    city = "";
                }

                if (area_of_city == "&nbsp;" || area_of_city == "&amp;nbsp;")
                {
                    area_of_city = "";
                }

                // Store the data in session variables
                Session["id"] = id;
                Session["leadname"] = leadname;
                Session["aeaofcity"] = area_of_city;
                Session["city"] = city;
                Session["mobile"] = mobile;
                Session["source"] = source_lead;
                Session["areaoflead"] = area_of_lead;
                Session["metertype"] = meter_type;


                // Redirect to another page
                Response.Redirect("userleadupdate.aspx");
            }
        }

        private void DeleteRowFromDatabase(string id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM leadmaster2 WHERE  id= @id ";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }


        }
    }




}