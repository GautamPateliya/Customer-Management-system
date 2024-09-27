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
    public partial class itemmaster : System.Web.UI.Page
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=cms;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

       

        protected void create(object sender, EventArgs e)
        {

            string pvbrand = txpvbrand.Text;
            string pvqty = txpvqty.Text;
            string wp = txtwp.Text;
           // string kw = txkw.Text;
            string subsidy = txtsubsidy.Text;
            string price = txtprice.Text;

            string kw = txkwHidden.Value;



            if (string.IsNullOrWhiteSpace(kw) || string.IsNullOrWhiteSpace(pvbrand) || string.IsNullOrWhiteSpace(pvqty) || string.IsNullOrWhiteSpace(wp)  || string.IsNullOrWhiteSpace(subsidy) || string.IsNullOrWhiteSpace(price))
            {
                // Display an error message to the user indicating required fields are missing
                Response.Write("<script>alert('required fields are missing')</script>");


                // Check if the user ID already exists in the database



            }
            else
            {
               
                
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "INSERT INTO [itemmaster] (pv_brand, pv_qty, wp, kw, subsidy, total_price) VALUES (@pv_brand, @pv_qty, @wp, @kw, @subsidy, @total_price)";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@pv_brand", pvbrand);
                                command.Parameters.AddWithValue("@pv_qty", pvqty);
                                command.Parameters.AddWithValue("@wp", wp);
                                command.Parameters.AddWithValue("@kw", kw);
                                command.Parameters.AddWithValue("@subsidy", subsidy);
                                command.Parameters.AddWithValue("@total_price", price);

                                connection.Open();
                                int rowsAffected = command.ExecuteNonQuery();


                                ScriptManager.RegisterStartupScript(this, GetType(), "Created  new Item Master Successfuly", "showAlert();", true);
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

       
        private void ClearFields()
        {
            txkw.Text = "";
            txpvbrand.Text = "";
            txpvqty.Text = "";
            txtprice.Text = "";
            txtsubsidy.Text = "";
            txtwp.Text = "";

        }

      

      
        protected void btncancel_Click(object sender, EventArgs e)
        {


            // Redirect to the logout page or any other page
            Response.Redirect("~/homepage.aspx");
        }

        
    }
}