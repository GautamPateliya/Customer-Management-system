<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Leaddatashow.aspx.cs" Inherits="cms.Leaddatashow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Leads Data</title>

    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="~/assets/css/tailwind.output.css" />
   
 <!-- SweetAlert library for nice alerts -->

    <link rel="stylesheet" href="StyleSheet2.css" />
        <link rel="stylesheet" href="gridview.css" />
    
     <link rel="stylesheet" href="StyleSheet1.css" />
    
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js" integrity="sha384-w1Q4orYjBQndcko6MimVbzY0tgp4pWB4lZ7lr30WKz0vr/aWKhXdBNmNb5D92v7s" crossorigin="anonymous"></script>

    

</head>
<body>
    <form id="form1" runat="server">
 <div>
           <header class="font">
           <div>
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
               <asp:Image ID="Image1" runat="server" ImageUrl="\assets\logo3.png" style="width: 180px; height: 80px;" />
                 <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse text-2xl  text-uppercase " id="navbarSupportedContent">
                    <ul class="navbar-nav p-2 mr-auto">
                        <li class="nav-item active">
                            <a class="nav-link" href="homepage.aspx">User Management<span class="sr-only">(current)</span></a>
                        </li>
                      <li class="nav-item dropdown">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown2" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Lead Master</a>
    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
        <a class="dropdown-item" href="leadmaster.aspx">New Lead</a>
        <a class="dropdown-item" href="leadsourcemaster.aspx">New Lead Source </a>
         <a class="dropdown-item" href="Leaddatashow.aspx">Register Leads </a>
    </div>
</li>
                         <li class="nav-item dropdown  ">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown1" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Site Visit</a>
    <div class="dropdown-menu " aria-labelledby="navbarDropdown">
        <a class="dropdown-item " href="sitemaster.aspx">Site visit</a>
        <a class="dropdown-item" href="showsitemasterdata.aspx">Site Visit Details </a>
       
    </div>
</li>


                        <li class="nav-item dropdown  ">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Offer</a>
    <div class="dropdown-menu " aria-labelledby="navbarDropdown">
       
        <a class="dropdown-item" href="itemmaster.aspx">Item Master </a>
        <a class="dropdown-item" href="Preperofffer.aspx">Prepar Offer  </a>
         <a class="dropdown-item" href="showitemmasterdata.aspx">Item master Details </a>
         <a class="dropdown-item" href="prepaofferdatashow.aspx">Prepared Offers  </a>
         <a class="dropdown-item" href="invetertype.aspx">Inverter</a>
    </div>
</li>





                        <li class="nav-item"></li>



                    </ul>
                 <a href="login.aspx" id="btnLogout" class="btn btn-outline-success">Log Out</a>

</div>


            </nav>
               </div>
        </header>
       
        </div>
        <div>

               
      
           
                <h1 class="mb-4 custom-heading   p-6 text-teal-500  font-semibold text-gray-700 dark:text-gray-200 flex items-center justify-center h-full">
    Register Leads 
</h1>
        
            </div>
      <div class="table-container">
 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="custom-gridview" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand" DataKeyNames="id">
        <Columns>
             <asp:BoundField DataField="id" HeaderText="Lead ID" />
            <asp:BoundField DataField="lead_name" HeaderText="Lead Name" />
            <asp:BoundField DataField="area_of_city" HeaderText="Area of City" />
            <asp:BoundField DataField="city" HeaderText="City" />
            <asp:BoundField DataField="mobile_number" HeaderText="Mobile Number" />
            <asp:BoundField DataField="source_lead" HeaderText="Lead Source" />
            <asp:BoundField DataField="area_of_lead" HeaderText="Lead Area" />
            <asp:BoundField DataField="meter_type" HeaderText="Meter Type" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <!-- Update Button -->
                    <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~\assets\pencil-fill.svg" CommandName="EditRow"  CommandArgument='<%# Container.DataItemIndex %>' CssClass="action-button update-button" />
                    <!-- Delete Button -->
                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/assets/bin.png" CommandName="Delete" CommandArgument='<%# Container.DataItemIndex %>' CssClass="action-button delete-button" OnClientClick="return confirmDelete();" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>





              
             
        </div>

         
    </form>
    <script type="text/javascript">
    function confirmDelete() {
        return confirm("Are you sure you want to delete this Lead?");
    }
    </script>
    <script>
        // Add an event listener to the logout button
        document.getElementById("btnLogout").addEventListener("click", function (event) {
            // Prevent the default action of the anchor tag
            event.preventDefault();

            // Perform the logout action here, such as redirecting to the logout page
            // Replace "logout.aspx" with the actual URL of your logout page
            window.location.href = "login.aspx";
        });
    </script>
</body>
</html>