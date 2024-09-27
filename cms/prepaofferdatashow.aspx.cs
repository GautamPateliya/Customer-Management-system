using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;

using System.IO;
using System.Web.UI;

namespace cms
{
    public partial class prepaofferdatashow : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [preparoffer]", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
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
            BindGrid();
        }


        private void DeleteRowFromDatabase(string id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM preparoffer WHERE  id= @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
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
                string id = GridView1.DataKeys[rowIndex].Value.ToString();

                string leadname = GridView1.Rows[rowIndex].Cells[1].Text; // Assuming UserId is in the first column
                                                                          //   string address = GridView1.Rows[rowIndex].Cells[8].Text;
                string kw = GridView1.Rows[rowIndex].Cells[5].Text;
                string price = GridView1.Rows[rowIndex].Cells[7].Text;
                string item = GridView1.Rows[rowIndex].Cells[6].Text;
                string pvqty = GridView1.Rows[rowIndex].Cells[3].Text;
                string mobile = GridView1.Rows[rowIndex].Cells[2].Text;
                string wp = GridView1.Rows[rowIndex].Cells[4].Text;
                string area = GridView1.Rows[rowIndex].Cells[9].Text;
                // Store the data in session variables
                Session["id"] = id;
                Session["mobile"] = mobile;

                Session["leadname"] = leadname;
                //  Session["address"] = address;
                Session["kw"] = kw;
                Session["price"] = price;
                Session["item"] = item;
                Session["pvqty"] = pvqty;
                Session["wp"] = wp;
                Session["area"] = area;
                // Redirect to another page for editing
                Response.Redirect("preparofferdataupdate.aspx");
            }
            if (e.CommandName == "ViewData")
            {

                int rowIndex = Convert.ToInt32(e.CommandArgument);

                // Retrieve the data associated with the clicked row
                string id = GridView1.DataKeys[rowIndex].Value.ToString();
                string additionalData = GetAdditionalDataFromDatabase(id);



                GeneratePdfAndInsertIntoDatabase(id, additionalData);


            }

        }

        public string GetAdditionalDataFromDatabase(string id)
        {
            // Initialize additional data string

            string additionalData = "";


            // Your SQL query to retrieve additional data based on the label text
            string query = "SELECT lead_name, kw,subsidy,area_of_city,price,pv_qty,invetertype,pv_brand,wp FROM preparoffer WHERE id = @id";

            // Create a SqlConnection and SqlCommand objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter for label text
                    command.Parameters.AddWithValue("@id",id);

                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the command
                        SqlDataReader reader = command.ExecuteReader();

                        // Check if there are any rows returned
                        if (reader.HasRows)
                        {
                            // Read the data
                            while (reader.Read())
                            {
                                // Extract data from the reader
                                string leadname = reader["lead_name"].ToString();
                                string kw = reader["kw"].ToString();
                                string subsidy = reader["subsidy"].ToString();
                                string areaOfCity = reader["area_of_city"].ToString();
                                string pv_qty = reader["pv_qty"].ToString();
                                string invetertype = reader["invetertype"].ToString();
                                string price = reader["price"].ToString();
                                string pvbrand = reader["pv_brand"].ToString();
                                string wp = reader["wp"].ToString();

                                // Append the data to additionalData string
                                additionalData += $"{leadname} ^ {subsidy}^ {areaOfCity}^ {kw}^ {price} ^ {pv_qty} ^ {invetertype} ^ {pvbrand} ^ {wp} ";
                            }
                        }

                        // Close the reader
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions here
                        // Log the exception or show an error message
                    }
                }
            }

            return additionalData;
        }

        private void GeneratePdfAndInsertIntoDatabase(string id, string additionalData)

        {      //
            // Assuming you have a DataTable named pdfUpload containing the PDF file data
            DataTable pdfUpload = GetPdfDataFromDatabase(); // You need to implement this method

            // Assuming you have some new data to be added to the PDF
            string newData = additionalData;

            // Call the EditPdfFromDataTable method to edit the PDF file
            byte[] editedPdfData = EditPdfFromDataTable(pdfUpload, newData, id);

            // Now you can do something with the edited PDF data, such as save it to a file or send it to a client
            // For example, you can save it to a file
            //  File.WriteAllBytes("edited_pdf.pdf", editedPdfData);

            byte[] pdfData = editedPdfData;

            DownloadPdf(pdfData);

            // Insert PDF data into database
            // InsertPdfIntoDatabase(id, pdfData);

        }

        private void DownloadPdf(byte[] pdfData)
        {
            string fileName = "file.pdf";

            // Download the file
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(pdfData);
            Response.Flush(); // Flush the response to ensure all data is sent to the client
            Response.End();
        }


        private DataTable GetPdfDataFromDatabase()
        {
            DataTable pdfUpload = new DataTable();
            int id = 85;

            // SQL query to retrieve PDF data
            string query = "SELECT pdfdata FROM pdfupload where id=@id";

            // Create SqlConnection and SqlCommand objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    // Open connection
                    connection.Open();

                    // Execute the query and fill the DataTable with the results
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(pdfUpload);
                }
            }

            return pdfUpload;
        }
        public static byte[] EditPdfFromDataTable(DataTable pdfUpload, string newData, string id)
        {
            if (pdfUpload == null || pdfUpload.Rows.Count == 0 || pdfUpload.Columns.Count == 0)
            {
                throw new ArgumentException("PDF upload DataTable is empty or invalid.");
            }




            byte[] pdfData = (byte[])pdfUpload.Rows[0]["PdfData"];
            byte[] editedPdfData = EditPdf(pdfData, newData);

            //  byte[] editLabelData = EditLabelData(pdfData, labelText);

            // Combine the edited PDF data and the edited label data into a single PDF
            byte[] combinedPdfData = CombinePdfPages(editedPdfData);

            return combinedPdfData;
        }

        public static byte[] EditPdf(byte[] pdfData, string newData)
        {



            using (MemoryStream ms = new MemoryStream())
            {
                using (PdfReader reader = new PdfReader(pdfData))
                {
                    // Split the new data based on the delimiter ","
                    string[] newDataArray = newData.Split('^');
                    string name = newDataArray[0]; // Access the first substring
                    string subsidy = newDataArray[1];
                    string area = newDataArray[2];
                    string kw = newDataArray[3];
                    string price = newDataArray[4];
                    string pvqty = newDataArray[5];
                    string inveter = newDataArray[6];
                    string pvbrand = newDataArray[7];
                    string wp = newDataArray[8];
                    string cprices = "";
                    DateTime currentDate = DateTime.Now;
                    string Date = currentDate.ToString("dd/MM/yyyy");
                    string[] elements2 = pvbrand.Split(new char[] { 'w', 'W' }, 2);

                    string[] namespilt = name.Split('-');

                    kw += "kw";
                    wp += "wp";



                    try
                    {
                        int iprice = Convert.ToInt32(price);
                        int isubsidy = Convert.ToInt32(subsidy);

                        int cprice = iprice - isubsidy;
                        cprices = cprice.ToString();

                        // Use cprices as needed
                    }
                    catch (FormatException ex)
                    {
                        // Handle the case where the input strings are not valid integers
                        Console.WriteLine("Error: Input strings are not valid integers.");
                        Console.WriteLine(ex.Message);
                    }

                    using (PdfStamper stamper = new PdfStamper(reader, ms))
                    {
                        float nameX = 100f; // Example X coordinate for the name
                        float nameY = 662f; // Example Y coordinate for the name
                        float areaX = 100f; // Example X coordinate for the subsidy
                        float areaY = 646f;
                        float kwX = 424f; // Example X coordinate for the subsidy
                        float kwY = 662f;
                        float pvqtyX = 424f; // Example X coordinate for the subsidy
                        float pvqtyY = 645f;
                        float kw2X = 275f; // Example X coordinate for the subsidy
                        float kw2Y = 627f;
                        float priceX = 457f; // Example X coordinate for the subsidy
                        float priceY =563f;
                        float subsidyx = 457f;
                        float subsidyy =526f;
                        float price2x = 457f;
                        float price2y = 450f;
                        float cpricex = 457;
                        float cpricey = 490f;
                        float datex =424f;
                        float datey =677f;

                        // Repeat for other pieces of data...

                        // Get the content of the first page
                        PdfContentByte content = stamper.GetOverContent(1);

                        // Set the font and size f
                        //or the data
                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        content.SetFontAndSize(bf, 12);

                        // Write each piece of data at its specified coordinates
                        content.BeginText();
                        content.ShowTextAligned(Element.ALIGN_LEFT, namespilt[1].Trim(), nameX, nameY, 0);
                        content.ShowTextAligned(Element.ALIGN_LEFT, area.Trim(), areaX, areaY, 0);
                        content.ShowTextAligned(Element.ALIGN_LEFT, kw.Trim(), kwX, kwY, 0);
                        // Repeat for other pieces of data...
                        content.ShowTextAligned(Element.ALIGN_LEFT, pvqty.Trim(), pvqtyX, pvqtyY, 0);
                        content.ShowTextAligned(Element.ALIGN_LEFT, kw.Trim(), kw2X, kw2Y, 0);

                        content.ShowTextAligned(Element.ALIGN_LEFT, price.Trim(), priceX,priceY, 0);
                        content.ShowTextAligned(Element.ALIGN_LEFT, subsidy.Trim(), subsidyx, subsidyy, 0);
                        content.ShowTextAligned(Element.ALIGN_LEFT, price.Trim(), price2x, price2y, 0);
                        content.ShowTextAligned(Element.ALIGN_LEFT, cprices.Trim(), cpricex,cpricey, 0);
                        content.ShowTextAligned(Element.ALIGN_LEFT, Date.Trim(), datex, datey, 0);
                        content.EndText();

                        float kw3X = 355f; // Example X coordinate for the subsidy
                        float kw3Y = 700f;
                        float inveterx = 292f; // Example X coordinate for the subsidy
                        float inveterY = 570f;
                        float pvqty2x = 240f; // Example X coordinate for the subsidy
                        float pvqty2Y = 640f;
                        float pvbrand2x = 292f; // Example X coordinate for the subsidy
                        float pvbrand2Y = 640f;
                        float wpx = 150f;
                        float wpy = 643f;


                        PdfContentByte content2 = stamper.GetOverContent(2);

                        // Set the font and size f
                        //or the data
                        BaseFont bf2 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        content2.SetFontAndSize(bf2, 12);

                        // Repeat for other pieces of data...
                        content2.ShowTextAligned(Element.ALIGN_LEFT, kw.Trim(), kw3X, kw3Y, 0);
                        string[] elements = inveter.Split(',');

                        // Iterate over the split elements
                        // Change this to the desired font size

                        // Iterate over the split elements
                        for (int i = 0; i < elements.Length; i++)
                        {
                            // Adjust y-coordinate for each element to create spacing between them
                            float yCoordinate = inveterY - i * 10; // Adjust 10 as needed for spacing between elements

                            // Set the font size
                            
                            // Display each element at the specified position
                            content2.ShowTextAligned(Element.ALIGN_LEFT, elements[i].Trim(), inveterx, yCoordinate, 0);
                        }
                        content2.ShowTextAligned(Element.ALIGN_LEFT, pvqty.Trim(), pvqty2x, pvqty2Y, 0);
                        content2.ShowTextAligned(Element.ALIGN_LEFT, elements2[1].Trim(), pvbrand2x, pvbrand2Y, 0);
                        content2.ShowTextAligned(Element.ALIGN_LEFT, wp.Trim(), wpx, wpy, 0);


                        content2.EndText();
                      


                    }
                }
                return ms.ToArray();
            }
        }


        private static byte[] CombinePdfPages(byte[] pdfData1)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (Document document = new Document())
                {
                    using (PdfCopy copy = new PdfCopy(document, ms))
                    {
                        document.Open();

                        // Add pages from the first PDF
                        using (PdfReader reader1 = new PdfReader(pdfData1))
                        {
                            for (int i = 1; i <= reader1.NumberOfPages; i++)
                            {
                                copy.AddPage(copy.GetImportedPage(reader1, i));
                            }
                        }


                    }
                }

                return ms.ToArray();
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {

        }
    }
}