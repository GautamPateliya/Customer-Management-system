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
    public partial class showitemmasterdata : System.Web.UI.Page
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=cms;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }

        }

        private void BindGrid()
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [itemmaster]", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
            }
        }
        protected void UpdateButton_Click(object sender, EventArgs e)
        {

        }
        

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "DeleteRow")
            {
                // Get the UserID of the row to be deleted
                string Id = e.CommandArgument.ToString();

                // Call the method to delete the row from the database
                DeleteRowFromDatabase(Id);

                // Rebind the GridView to reflect the changes
                BindGrid();
            }

            if (e.CommandName == "EditRow")
            {
                // Retrieve the index of the clicked row
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                // Retrieve the data associated with the clicked row
                string Id = GridView2.DataKeys[rowIndex]["id"].ToString();
                string pvbreand = GridView2.Rows[rowIndex].Cells[1].Text; // Assuming UserId is in the first column
                string pvqty = GridView2.Rows[rowIndex].Cells[2].Text;
                string wp = GridView2.Rows[rowIndex].Cells[3].Text;
                string kw = GridView2.Rows[rowIndex].Cells[4].Text;
                
                string subsidy = GridView2.Rows[rowIndex].Cells[5].Text;
                string price = GridView2.Rows[rowIndex].Cells[6].Text;
                
                // Store the data in session variables
                Session["Id"] = Id;
                Session["pvbrand"] = pvbreand;
                Session["pvqty"] = pvqty;
                Session["wp"] = wp;
                Session["kw"] = kw;
                Session["subsidy"] = subsidy;
                Session["price"] = price;

                // Redirect to another page
                Response.Redirect("updateitemmaster.aspx");
            }
        }


    

         private void DeleteRowFromDatabase(string Id)
        {
            // Your code to delete the row from the database goes here
            // Example:
            // string connectionString = "YourConnectionStringHere";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM [itemmaster] WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", Id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
 }