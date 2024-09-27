<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="invetertype.aspx.cs" Inherits="cms.invetertype" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inveter type</title>
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="~/assets/css/tailwind.output.css" />
    <script src="https://cdn.jsdelivr.net/gh/alpinejs/alpine@v2.x.x/dist/alpine.min.js" defer></script>
    <script src="~/assets/js/init-alpine.js"></script>
    <link rel="stylesheet" href="StyleSheet1.css" />
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
          integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css"
          integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr"
          crossorigin="anonymous" />
    <link rel="stylesheet" href="StyleSheet2.css" />
     
   <link rel="stylesheet" href="gridview.css" />
    


<style>
    .alert {
        padding: 20px;
        background-color:  black; /* Red background color */
        color: white;
        margin-bottom: 15px;
         font-size:larger;
    }

    .closebtn {
        margin-left: 15px;
        color: white;
        font-weight: bold;
       
        float: right;
        font-size:  larger;
        line-height: 20px;
        cursor: pointer;
        transition: 0.3s;
    }

    .closebtn:hover {
        color: red;
    }

    .custom-heading {
    font-size: 2rem; /* Adjust the font size as needed */
}

</style>
<script>
    function showAlert() {
        document.getElementById('alertBox').style.display = 'block';
        setTimeout(function () {
            document.getElementById('alertBox').style.display = 'none';
        },5000); // Hide the alert after 3 seconds (adjust as needed)
    }
</script>
    
</head>
<body>
    <form id="form1" runat="server">
        <div id="alertBox" class="alert" style="display:none;">
    <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
    <strong>Success!</strong> Successfully created a new Inveter Type.
</div>
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
        <main>
            <div class="flex items-center min-h-screen p-6 bg-gray-50 dark:bg-gray-900">
                <div class="flex-1 h-full max-w-4xl mx-auto overflow-hidden bg-white rounded-lg shadow-xl dark:bg-gray-800">
                    <div class="flex flex-col overflow-y-auto md:flex-row">
                        <div class="h-32 md:h-auto md:w-1/2">
                            <img aria-hidden="true" class="object-cover w-full h-full dark:hidden" src="\assets\inverter.jpg" alt="Office" />
                           
                        </div>
                        <div class="flex items-center justify-center p-6 sm:p-12 md:w-1/2">
                            <div class="w-full">
                               <h1 class="mb-4  custom-heading text-teal-500 font-semibold text-gray-700 dark:text-gray-200">Create New Inveter Type</h1>

                                <label class="block text-lg">
                                    <span class="text-gray-700 dark:text-gray-400 text-xl">Inveter Name:</span>
                                    <asp:TextBox ID="txtinverter" runat="server" CssClass="block w-full mt-1 text-lg dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input" Placeholder="solaryaan" />
                                </label>
                               <asp:Button ID="btnCreateRole" runat="server" OnClick="create" Text="Create New Type" CssClass="block w-full px-4 py-2 mt-4 text-lg font-medium leading-5 text-center text-white transition-colors duration-150 bg-purple-600 border border-transparent rounded-lg active:bg-purple-600 hover:bg-purple-700 focus:outline-none focus:shadow-outline-purple" />
                                 <asp:Button ID="Button1" runat="server" Text="cancel" CssClass="block w-full px-4 py-2 mt-4  text-xl font-medium leading-5 text-center text-white transition-colors duration-150 bg-purple-600 border border-transparent rounded-lg active:bg-purple-600 hover:bg-purple-700 focus:outline-none focus:shadow-outline-purple" OnClick="btncancel_Click" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
              <div class="custom-heading">

               
               </div>
          <div class="table-container">
              <asp:GridView ID="GridView2" runat="server" CssClass="custom-gridview" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" DataKeyNames="id" >
  
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" ItemStyle-CssClass="gridview-cell" />
            <asp:BoundField DataField="inveter_type" HeaderText="Inveter Name" ItemStyle-CssClass="gridview-cell" />
           
            
            <asp:TemplateField HeaderText="Delete">
              <ItemTemplate>
    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="\assets\bin.png" CommandName="DeleteRow" CommandArgument='<%# Eval("id") %>' CssClass="action-button delete-button" OnClientClick="return confirmDelete();" />
</ItemTemplate>


            </asp:TemplateField>
        </Columns>
        
       
        
    </asp:GridView>
</div>



        </main>

        <!-- footer -->
        <footer>
            <p>&copy; 2024 My Website. All Rights Reserved.</p>
        </footer>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js" integrity="sha384-w1Q4orYjBQndcko6MimVbzY0tgp4pWB4lZ7lr30WKz0vr/aWKhXdBNmNb5D92v7s" crossorigin="anonymous"></script>
   <script type="text/javascript">
       function confirmDelete() {
           return confirm("Are you sure you want to delete this type");
       }
   </script>

</body>

</html>

