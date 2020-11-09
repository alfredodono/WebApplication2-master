<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="WebApplication2.welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="UTF-8"/>
    <title>Welcome</title>

    <link rel="stylesheet" href="css/bootstrap.min.css"/>
       <link rel="shortcut icon" href="img/icon.ico" />
    <script src="js/bootstrap.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/jquery-3.5.1.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
</head>
<body>
    
    <style>
        #yo {
            padding-right: 2rem;
            
            align-content: center;
        }


        .navbar {
            background-color: #800000;
        }

        .footer {
            background-color: #800000;
        }

        #hola {}
    </style>
      

    <form id="form1" runat="server">
       
        <nav class="navbar navbar-expand-lg navbar-light bg-lignt">
        <a class="navbar-brand text-white " href="#">Nissan HRI</a>
        <button class="navbar-toggler " type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon "></span>
        </button>

        <div class="collapse navbar-collapse text-white  " id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto text-white">
                  <li class="nav-item active text-white">
                    <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="BtnAlerts" runat="server" Text="Alerts" />
                </li>
                <li class="nav-item active text-white">
                    <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="btnHome" runat="server" Text="Home" />
                </li>
                <li class="nav-item">
                    <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="BtnUsers" runat="server" Text="Usuarios" OnClick="BtnUsers_Click" />
                    
                   
                </li>
                 <li class="nav-item">
                    <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="btnHRI" runat="server" Text="HRI" OnClick="BtnHRI_Click" />
                    
                   
                </li>
                 <li class="nav-item">
                    <asp:Button class="nav-link text-white" BackColor="#800000"  BorderStyle="None" ID="BtnControl" runat="server" Text="Control" />
                    
                   
                </li>
                

            </ul>
            <div id="yo">
                <asp:Label ID="lblId" runat="server" ></asp:Label>
                
            </div>

            <div class="nav-item">
                <asp:Button class="nav-link text-white" ID="btnlogout" BackColor="#800000" BorderStyle="None" runat="server" Text="Logout" OnClick="btnlogout_Click" />
               </div>
           

        </div>
    </nav>
    <div>
   
    </div>
        
    </form>







    <div id="hola ">
        <footer class="footer page-footer font-small  fixed-bottom ">
         
            <div align="center">
                <div class="row col-md-5">
                    <div class="col-md-8">
                        <p class="text-white">
                            <br>
                            <br>
                            <b> Nissan Mexicana</b>
                            <br> <b>Extensiones Soporte: 2153,2154,2155,2156</b>
                            <br>Nissan HRI Web Portal V0.1.1 (Release)
                        </p>
                    </div>

                    <div class="col-md-4">
                        <img src="img/aad.png" alt="" height="200" width="200">
                    </div>

                </div>




            </div>

        </footer>
    </div>


  <script src="js/bootstrap.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/jquery-3.5.1.min.js"></script>
    <script src="js/jquery-3.4.1.slim.min.js"></script>
    <script src="js/popper.min.js"></script>
</body>
</html>
