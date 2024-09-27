<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userpreparoffer.aspx.cs" Inherits="cms.userpreparoffer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Prepar Offer</title>
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="~/assets/css/tailwind.output.css" />
    <script src="https://cdn.jsdelivr.net/gh/alpinejs/alpine@v2.x.x/dist/alpine.min.js" defer></script>
    <link rel="stylesheet" href="StyleSheet1.css" />
      <link rel="stylesheet" href="StyleSheet2.css" />
   
  

   
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js" integrity="sha384-w1Q4orYjBQndcko6MimVbzY0tgp4pWB4lZ7lr30WKz0vr/aWKhXdBNmNb5D92v7s" crossorigin="anonymous"></script>


    <style>
        /* Styles for the list container */
        #listContainer {
            list-style-type: none;
            padding: 0;
           
        }

        /* Styles for hiding the list initially */
        .hidden {
            display: none;
        }
        
    </style>
<style>
    .custom-label {
    font-size: 22px; /* Adjust the font size as needed */
}
 .custom-radio {
    font-size: 20px; /* Adjust the font size as needed */
}

  
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
  <style>
        .hidden {
            display: none;
        }
    </style>
  
<script>
    function showAlert() {
        document.getElementById('alertBox').style.display = 'block';
        setTimeout(function () {
            document.getElementById('alertBox').style.display = 'none';
        }, 3000); // Hide the alert after 3 seconds (adjust as needed)
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
              <div id="alertBox" class="alert" style="display:none;">
    <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
    <strong>Success!</strong> "Created  new Offer Successfuly".
</div>
          <div>
         <header class="font">
           <div>
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
               <asp:Image ID="Image1" runat="server" ImageUrl="\assets\logo3.png" style="width: 200px; height: 80px;" />
                 <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse text-2xl  text-uppercase " id="navbarSupportedContent">
                    <ul class="navbar-nav p-2 mr-auto">
                       <li class="nav-item active">
                            <a class="nav-link" href="userhomepage.aspx">Home<span class="sr-only">(current)</span></a>
                        </li>
                      <li class="nav-item dropdown">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown2" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Lead Master</a>
    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
        <a class="dropdown-item" href="userleadmaster.aspx">New Lead</a>
        <a class="dropdown-item" href="userleadsource.aspx">New Lead Source </a>
         <a class="dropdown-item" href="userleadmasterdata.aspx">Register Leads </a>
    </div>
</li>


                         <li class="nav-item dropdown  ">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown1" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Site Visit</a>
    <div class="dropdown-menu " aria-labelledby="navbarDropdown">
        <a class="dropdown-item " href="usersitemaster.aspx">Site visit</a>
        <a class="dropdown-item" href="usershowsitemasterdata.aspx">Site Visit Details </a>
       
    </div>
</li>


                        <li class="nav-item dropdown  ">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Offer </a>
    <div class="dropdown-menu " aria-labelledby="navbarDropdown">
       
        <a class="dropdown-item" href="userpreparoffer.aspx">Prepar Offer  </a>
       
         <a class="dropdown-item" href="userpreparedofferdata.aspx">Prepared Offers  </a>

    </div>
</li>



                        <li class="nav-item"></li>



                    </ul>
               <a href="login.aspx" id="btnLogout" class="btn btn-outline-success">Log Out</a>

</div>


            </nav>
         
      

        </div>
             </header>
             <main>
                         <asp:ScriptManager ID="ScriptManager1" runat="server">  </asp:ScriptManager>
        <div class="flex items-center min-h-screen p-6 bg-gray-50 dark:bg-gray-900">
                <div class="flex-1 h-full max-w-4xl mx-auto overflow-hidden bg-white rounded-lg shadow-xl dark:bg-gray-800">
                    <div class="flex flex-col overflow-y-auto md:flex-row">
                        <div class="h-32 md:h-auto md:w-1/2">
                            <img aria-hidden="true" class="object-cover w-full h-full dark:hidden" src="../assets/img/create-account-office.jpeg" alt="Office" />
                        </div>
                        <div class="flex items-center justify-center p-6 sm:p-12 md:w-1/2">
                            <div class="w-full">
                                <h1 class="mb-4 text-x1 text-teal-500 font-semibold text-gray-700 dark:text-gray-200">Prepar Offer</h1>
                                 <label for="country" class="block text-lg  custom-label mt-2">Lead Name:</label>
                                
                                
                                



                                <asp:DropDownList ID="ddlLeadSources2" runat="server" AutoPostBack="true" CssClass=" custom-radio block w-full mt-1 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input">
</asp:DropDownList>
                         <div class="form-group radio-group flex items-center mt-4">
    <asp:CheckBox ID="chkSiteSurvey" runat="server" CssClass="h-10 w-10 text-indigo-600 mr-2" />
    <asp:Label ID="lblSiteSurvey" runat="server" AssociatedControlID="chkSiteSurvey" CssClass="text-lg custom-label" Text="Include Site Survey Data:" />
</div>
 

 <label for="country" class="block text-lg  custom-label mt-2">Inveter Type:</label>
                                
<div class="flex justify items-center ">
    <asp:Button ID="showListButton" runat="server" Text="Inveter Names " OnClick="showListButton_Click" CssClass="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" />
    <asp:Panel ID="listContainer" runat="server" CssClass="hidden">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
    <li>
        <asp:CheckBox ID="ItemCheckbox" runat="server" AutoPostBack="false" CssClass="form-checkbox text-blue-500 ml-4 h-5 w-5"  />
        <asp:Label ID="ItemLabel" runat="server" Text='<%# Eval("inveter_type") %>' CssClass="ml-2 text-lg text-gray-800" />
    </li>
</ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
</div>


     <label class="block mt-2 custom-label">
                <span class="text-gray-700 dark:text-gray-400">PV Brand</span>
                <asp:TextBox ID="txtSearch" ClientIDMode="Static" runat="server" CssClass="block w-full mt-1 text-lg dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input" Placeholder="Vadodara" onkeyup="getSuggestions(this.value)" />
                <ul id="suggestionList" class="mt-2 p-2 bg-gray-100 dark:bg-gray-800 rounded shadow-md"></ul>
            </label> 
                                
           

                                <asp:Button ID="btnCreatelead_Click" runat="server" Text="Submit" CssClass="block w-full px-4 py-2 mt-4 text-lg font-medium leading-5 text-center text-white transition-colors duration-150 bg-purple-600 border border-transparent rounded-lg active:bg-purple-600 hover:bg-purple-700 focus:outline-none focus:shadow-outline-purple" OnClick="create"  />

                                 <asp:Button ID="Button1" runat="server" Text="cancel" CssClass="block w-full px-4 py-2 mt-4  text-xl font-medium leading-5 text-center text-white transition-colors duration-150 bg-purple-600 border border-transparent rounded-lg active:bg-purple-600 hover:bg-purple-700 focus:outline-none focus:shadow-outline-purple" OnClick="btncancel_Click" />

                            </div>
                        </div>
                    </div>
                </div>
            
        </main>
        <footer>
            <p>&copy; 2024 My Website. All Rights Reserved.</p>
        </footer>





    </form>
     <script type="text/javascript">
         function getSuggestions(searchText) {
             if (searchText.length >= 1) {
                 fetch('preperofffer.aspx/GetSuggestions', {
                     method: 'POST',
                     headers: {
                         'Content-Type': 'application/json'
                     },
                     body: JSON.stringify({ searchText: searchText })
                 })
                     .then(response => response.json())
                     .then(data => {
                         var suggestions = data.d;
                         var suggestionList = document.getElementById('suggestionList');
                         suggestionList.innerHTML = ''; // Clear previous suggestions
                         if (suggestions.length > 0) {
                             suggestions.forEach(function (value) {
                                 var li = document.createElement('li');
                                 li.textContent = value;
                                 li.onclick = function () { // Add onclick event to suggestion items
                                     document.getElementById('txtSearch').value = value; // Set value to textbox
                                     suggestionList.style.display = 'none'; // Hide suggestion list
                                 };
                                 suggestionList.appendChild(li);
                             });
                             suggestionList.style.display = 'block'; // Show the suggestion list
                         } else {
                             suggestionList.style.display = 'none'; // Hide the suggestion list if no suggestions found
                         }
                     })
                     .catch(error => console.error('Error:', error));
             } else {
                 document.getElementById('suggestionList').innerHTML = ''; // Clear suggestions if less than 3 characters
                 document.getElementById('suggestionList').style.display = 'none'; // Hide the suggestion list
             }
         }
     </script>
   
</body>
</html>
