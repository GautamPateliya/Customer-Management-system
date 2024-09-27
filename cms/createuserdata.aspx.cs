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
    public partial class createuserdata : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT userid, email, role, password FROM [user]", con))
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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "DeleteRow")
            {
                // Get the UserID of the row to be deleted
                string userId = e.CommandArgument.ToString();

                // Call the method to delete the row from the database
                DeleteRowFromDatabase(userId);

                // Rebind the GridView to reflect the changes
                BindGrid();
            }

            if (e.CommandName == "EditRow")
            {
                // Retrieve the index of the clicked row
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                // Retrieve the data associated with the clicked row
                string userId = GridView2.DataKeys[rowIndex]["userid"].ToString();
                string role = GridView2.Rows[rowIndex].Cells[1].Text; // Assuming UserId is in the first column
                string email = GridView2.Rows[rowIndex].Cells[2].Text;
                string password = GridView2.Rows[rowIndex].Cells[3].Text;
               // string password = ((TextBox)GridView2.Rows[rowIndex].Cells[3].FindControl("password")).Text;
                // Store the data in session variables
                Session["UserId"] = userId;
                Session["role"] = role;
                Session["email"] = email;
                Session["password"] = password;

                // Redirect to another page
                Response.Redirect("createuserupdate.aspx");
            }
        }

        private void DeleteRowFromDatabase(string userId)
        {
            // Your code to delete the row from the database goes here
            // Example:
            // string connectionString = "YourConnectionStringHere";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM [user] WHERE userid = @userid";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userid", userId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
           
        }

       


      


    }
}