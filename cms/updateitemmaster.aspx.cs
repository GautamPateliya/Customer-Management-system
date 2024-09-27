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
    public partial class updateitemmaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Id"] != null && Session["pvbrand"] != null && Session["pvqty"] != null && Session["wp"] != null && Session["kw"] != null && Session["subsidy"] != null && Session["price"] != null)
                {
                    // Retrieve data from session variables
                    string Id = Session["Id"].ToString();
                    string pvbrand = Session["pvbrand"].ToString();
                    string pvqty = Session["pvqty"].ToString();
                    string wp = Session["wp"].ToString();
                    string kw = Session["kw"].ToString();
                    string subsidy = Session["subsidy"].ToString();
                    string price = Session["price"].ToString();
                    // Set the values of the textboxes

                    txpvbrand.Text = pvbrand;
                    txpvqty.Text = pvqty;
                    txtwp.Text = wp;
                    txtprice.Text = price;
                    txtsubsidy.Text = subsidy;
                    Txid.Text = Id;


                }
            }

        }
        protected void create(object sender, EventArgs e)
        {
            string pvbrand = txpvbrand.Text;
            string pvqty = txpvqty.Text;
            string wp = txtwp.Text;
            string kw = txkwHidden.Value;

            string subsidy = txtsubsidy.Text;
            string id = Txid.Text;
            string price = txtprice.Text;



            // Perform validation here if needed

            // Check if the password and confirm password match
            
                // Assuming you're using SQL Server
                string connectionString = "Data Source = localhost\\SQLEXPRESS01; Initial Catalog = cms; Integrated Security = True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE [itemmaster] SET pv_brand = @pv_brand, pv_qty = @pv_qty, wp = @wp, kw=@kw, subsidy=@subsidy, total_price=@price WHERE id = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@pv_brand", pvbrand);
                    command.Parameters.AddWithValue("@pv_qty", pvqty);
                    command.Parameters.AddWithValue("@wp", wp);
                    command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@kw", kw);
                command.Parameters.AddWithValue("@subsidy", subsidy);
                command.Parameters.AddWithValue("@price", price);


                try
                {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        // Check if the update was successful
                        if (rowsAffected > 0)
                        {
                            // Update successful
                            // Optionally, you can display a success message or redirect the user to another page
                            ScriptManager.RegisterStartupScript(this, GetType(), "UpdateSuccess", "showAlert(); window.location.href = 'showitemmasterdata.aspx';", true);
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
            Response.Redirect("~/createuserdata.aspx");
        }
    }
}