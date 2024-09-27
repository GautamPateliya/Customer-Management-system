<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="itemmaster.aspx.cs" Inherits="cms.itemmaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Item Master</title>

     <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="~/assets/css/tailwind.output.css" />
    <script src="https://cdn.jsdelivr.net/gh/alpinejs/alpine@v2.x.x/dist/alpine.min.js" defer></script>
    <script src="~/assets/js/init-alpine.js"></script>

    <link rel="stylesheet" href="StyleSheet1.css" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ho+j7jyWK8fNQe+A12Hb8AhRq26LrZ/JpcUGGOn+Y7RsweNrtN/tE3MoK7ZeZDyx" crossorigin="anonymous"></script>
   
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
          integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css"
          integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr"
          crossorigin="anonymous" />
    <link rel="stylesheet" href="StyleSheet2.css" />
  
    
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
        <div>
            
       <div id="alertBox" class="alert" style="display:none;">
    <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
    <strong>Success!</strong> "Created  New Item  Successfuly".
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
                            <img aria-hidden="true" class="object-cover w-full h-full dark:hidden" src="../assets/img/create-account-office.jpeg" alt="Office" />
                        </div>
                        <div class="flex items-center justify-center p-6 sm:p-12 md:w-1/2">
                            <div class="w-full">
                               
                                <h1 class="mb-4 text-teal-500 font-bold text-gray-700 dark:text-gray-200" style="font-size: 2em;">Item Master</h1>

                                 <label class="block mt-4  text-xl">
                                    <span class="text-gray-700 dark:text-gray-400">PV Brand</span>
                                    <asp:TextBox ID="txpvbrand" runat="server" CssClass="block w-full mt-1 text-lg dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input"  Placeholder="" />
                            
                                
                                </label>

                                 <label class="block mt-4  text-xl">
                                    <span class="text-gray-700 dark:text-gray-400">PV Qty</span>
                                    <asp:TextBox ID="txpvqty" runat="server" CssClass="block w-full mt-1 text-lg dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input"  Placeholder="1000"    />
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
    ControlToValidate="txpvqty" ErrorMessage="Please enter a valid  Value."
    ValidationExpression="^\d+(\.\d+)?$"  ForeColor="Red" Display="Dynamic"/>



                                
                                </label>

                                 <label class="block mt-4  text-xl">
                                    <span class="text-gray-700 dark:text-gray-400">WP:</span>
                                    <asp:TextBox ID="txtwp" runat="server" CssClass="block w-full mt-1 text-lg dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input"  Placeholder="1000"    />
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
    ControlToValidate="txpvqty" ErrorMessage="Please enter a valid  Value."
    ValidationExpression="^\d+(\.\d+)?$"  ForeColor="Red" Display="Dynamic"/>

                                
                                </label>


                                <label class="block text-xl">
                                    <span class="text-gray-700 dark:text-gray-400">KW:</span>
                                <asp:TextBox ID="txkw" ReadOnly="true" runat="server" CssClass="block w-full mt-1 text-lg dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input" Placeholder="3" />
<asp:HiddenField ID="txkwHidden" runat="server" />

                                       </label>


                                  <label class="block mt-4  text-xl">

                                      <span class="text-gray-700 dark:text-gray-400">Subsidy</span>
                        <div class="relative">
    <asp:TextBox ID="txtsubsidy" runat="server" CssClass="block w-full mt-1 text-lg dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input pr-10" 
        Placeholder="78000" />
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
    ControlToValidate="txtsubsidy" ErrorMessage="Please enter a valid  Value."
    ValidationExpression="^\d+(\.\d+)?$"  ForeColor="Red" Display="Dynamic"/>

                 


                                </label>

                              
                                <label class="block  text-xl mt-4">
                                 
                                    <span class="text-gray-700 dark:text-gray-400">Total Price</span>


  <asp:TextBox ID="txtprice" runat="server" CssClass="block w-full mt-1 text-lg dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input" 
    Placeholder="120000"  />
 <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
    ControlToValidate="txtprice" ErrorMessage="Please enter a valid  Value."
    ValidationExpression="^\d+(\.\d+)?$"  ForeColor="Red" Display="Dynamic"/>

                 






      
                                </label>
                              

                               
                               
                                

                      <asp:Button ID="btnCreateAccount" runat="server" OnClick="create" Text="Create Item "  CssClass="block w-full px-4 py-2 mt-4  text-xl font-medium leading-5 text-center text-white transition-colors duration-150 bg-purple-600 border border-transparent rounded-lg active:bg-purple-600 hover:bg-purple-700 focus:outline-none focus:shadow-outline-purple" />
 <asp:Button ID="Button1" runat="server" Text="cancel" CssClass="block w-full px-4 py-2 mt-4  text-xl font-medium leading-5 text-center text-white transition-colors duration-150 bg-purple-600 border border-transparent rounded-lg active:bg-purple-600 hover:bg-purple-700 focus:outline-none focus:shadow-outline-purple" OnClick="btncancel_Click" />



                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>

        <!-- footer -->
        <footer>
            <p>&copy; 2024 My Website. All Rights Reserved.</p>
        </footer>
    </form>
      <script type="text/javascript">
          window.onload = function () {
              // Function to calculate KW
              function calculateKW() {
                  var txtwp = document.getElementById('<%= txtwp.ClientID %>').value;
            var txpvqty = document.getElementById('<%= txpvqty.ClientID %>').value;

            var wp = parseInt(txtwp) || 0;
            var pvqty = parseInt(txpvqty) || 0;

            var kw = (wp * pvqty / 1000);
            document.getElementById('<%= txkw.ClientID %>').value = kw;

            // Update hidden field with the calculated value
            var txkwHidden = document.getElementById('<%= txkwHidden.ClientID %>');
            txkwHidden.value = kw;
        }

        // Attach calculateKW to onchange event of txtwp and txpvqty
        document.getElementById('<%= txtwp.ClientID %>').onchange = calculateKW;
        document.getElementById('<%= txpvqty.ClientID %>').onchange = calculateKW;

              // Call calculateKW initially to ensure the initial value is calculated
              calculateKW();
          };
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
