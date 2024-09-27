<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pdfupload.aspx.cs" Inherits="cms.pdfupload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Crate New User Role</title>
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
     
    <style>
* Dropdown styles */
.dropdown-menu {
    display: none;
    position: absolute;
    background-color: #fff;
    min-width: 160px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    z-index: 1;
}

.dropdown-menu a {
    color: #333;
    padding: 10px 15px;
    display: block;
    text-decoration: none;
}

.dropdown-menu a:hover {
    background-color: #f5f5f5;
}

.navbar .nav-item.dropdown:hover .dropdown-menu {
    display: block;
}
    </style>





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
    font-size: 2rem;
    text-align: center;
    margin-top:10px;/* Adjust the font size as needed */
}

    .custom-file-upload {
    /* FileUpload control styles */
    
    border: 2px solid #ccc; /* Example border */
    padding: 8px;
    border-radius: 4px;
    background-color: #f9f9f9;
    font-size: 16px;
    width: 200px; /* Adjust width as needed */
}

.custom-button {
    /* Button control styles */
    padding: 10px 20px;
    background-color: #4CAF50; /* Green */
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    font-size: 16px;
}

.custom-button:hover {
    background-color: #45a049; /* Darker Green */
}
.c {
    display: flex;
    justify-content: center;
}
.container {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    height: 100vh; /* Adjust the height as needed */
}
.custom-file-upload {
    /* FileUpload control styles */
     justify-content: center;
    border: 2px solid #ccc; /* Example border */
    padding: 8px;
    border-radius: 4px;
    background-color: #f9f9f9;
    font-size: 16px;
    width: 300px; /* Adjust width as needed */

     
   
    align-items: center;
  
   
}

.custom-button {
    /* Button control styles */
     justify-content: center;
    padding: 10px 20px;
    background-color: #4CAF50; /* Green */
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    font-size: 16px;
    margin-left:20px;
}

.custom-button:hover {
    background-color: #45a049; /* Darker Green */
}


</style>
<style>
         .custom-heading {
    font-size: 2rem; /* Adjust the font size as needed */
}
    </style>
    <style>
   /* CSS for the container */
.table-container {
    margin: 20px auto; /* Center the table horizontally */
    width: 90%; /* Adjust the width as needed */
}

/* CSS for the GridView */
.custom-gridview {
    width: 100%;
    border-collapse: collapse;
}

/* CSS for the header row */
.custom-gridview th {
    background-color:    dimgray;
    border: 1px solid #ddd;
    padding: 6px;
    text-align: center;
     color:white;
     font-size:  x-large;
}

/* CSS for the data rows */
.custom-gridview td {
    border: 1px solid #ddd;
    padding: 6px;
    text-align: center;
     font-size: larger;
}

/* CSS for alternate rows */
.custom-gridview tr:nth-child(even) {
    background-color:  gainsboro;
}

/* CSS for the data rows */
.custom-gridview td {
    border: 1px solid #000; /* Set border color to black */
    border-bottom: 1px solid #000; /* Add bottom border */
    padding: 6px;
   

}
        .custom-gridview th {
            border: 1px solid #ddd;
            border-bottom: 1px solid #ddd; /* Add bottom border */
            padding: 6px;
        }



        /* CSS for the update and delete buttons */
/* CSS for the update and delete buttons */
.action-button {
    width: 25px;
    height: 25px;
    cursor: pointer;
    margin-right:1px;
}

.update-button {
    background-image: url('../assets/pencil-fill.svg'); /* Path to the update button image */
    background-size: cover;
    margin-right:10px;/* Ensure the image covers the button */
}

.delete-button {
    background-image: url('../assets/bin.png'); /* Path to the delete button image */
    background-size: cover;
     /* Ensure the image covers the button */
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
    <strong>Success!</strong> Successfully created a new user role.
</div>
      <div>
          <header>
           <div>
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
                <a class="navbar-brand  text-uppercase" href="homepage.aspx">RoofTOP</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse  text-uppercase text-2xl" id="navbarSupportedContent">
                    <ul class="navbar-nav p-2 mr-auto">
                        <li class="nav-item active">
                            <a class="nav-link" href="homepage.aspx">User Management<span class="sr-only">(current)</span></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Site Master</a>
                        </li>
                        <li class="nav-item dropdown">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Lad Master</a>
    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
        <a class="dropdown-item" href="leadmaster.aspx">New Lead</a>
        <a class="dropdown-item" href="leadsourcemaster.aspx">New Lead Source </a>
    </div>
</li>

<li class="nav-item dropdown">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown2" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Lad Master</a>
    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
        <a class="dropdown-item" href="leadmaster.aspx">New Lead</a>
        <a class="dropdown-item" href="leadsourcemaster.aspx">New Lead Source </a>
    </div>
</li>
<li class="nav-item dropdown">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown3" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Lad Master</a>
    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
        <a class="dropdown-item" href="leadmaster.aspx">New Lead</a>
        <a class="dropdown-item" href="leadsourcemaster.aspx">New Lead Source </a>
    </div>
</li>


                        <li class="nav-item"></li>



                    </ul>
               <asp:Button ID="btnLogout" runat="server" Text="Log Out" CssClass="btn btn-outline-success" OnClick="btnLogout_Click" />

</div>


            </nav>
               </div>
        </header>
       
        </div>

        <main>
           
              
                   
                        
                       
                          <div class="w-full">
                             
    <h1 class="mb-4 custom-heading text-teal-500 font-semibold text-gray-700 dark:text-gray-200">New Pdf Upload</h1>
 <div class="c">
    <asp:FileUpload ID="fileUpload" runat="server" CssClass="custom-file-upload" />
<asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="custom-button" OnClick="btnUpload_Click" OnClientClick="return validateFile();" />
</div>
</div>

 <div class="table-container">

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="custom-gridview" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand" DataKeyNames="id">
    <Columns>
        <asp:BoundField DataField="id" HeaderText="ID" />
        <asp:BoundField DataField="pdfname" HeaderText="File Name" />
        <asp:TemplateField HeaderText="View">
            <ItemTemplate>
                <asp:LinkButton ID="btnView" runat="server" CommandName="ViewFile" CommandArgument='<%# Eval("id") %>' Text="View" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Download">
            <ItemTemplate>
                <asp:LinkButton ID="btnDownload" runat="server" CommandName="DownloadFile" CommandArgument='<%# Eval("id") %>' Text="Download" />
          
            </ItemTemplate>

             
        </asp:TemplateField>
        

          <asp:TemplateField HeaderText="Delete">
            <ItemTemplate>
               
          
                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/assets/bin.png" CommandName="Delete" CommandArgument='<%# Container.DataItemIndex %>' CssClass="action-button delete-button" OnClientClick="return confirmDelete();" />
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
            return confirm("Are you sure you want to delete this pdf file ?");
        }
    </script>
    <script>
        function validateFile() {
            var fileInput = document.getElementById('<%= fileUpload.ClientID %>');
            var filePath = fileInput.value;
            var allowedExtensions = /(\.pdf)$/i;
            if (!allowedExtensions.exec(filePath)) {
                alert('Please select a PDF file.');
                return false;
            }
            return true;
        }
</script>

</body>

</html>