<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication2._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="css/bootstrap.css"/>

    <link rel="shortcut icon" href="img/icon.ico" />
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>administrator HRI</title>
</head>
<body id="fondo">
    <div class="container"  id="form">
        <style>
            #fondo {
                background-color: #800000;
            }

            #form {
                display: flex;
                align-items: center;
                justify-content: center;
                min-height: 100vh;
            }

            #formc {
                border-radius: 11px 11px 11px 11px;
                -moz-border-radius: 11px 11px 11px 11px;
                -webkit-border-radius: 11px 11px 11px 11px;
                border: 0px solid #000000;
                -webkit-box-shadow: 0px 3px 14px 2px rgba(0, 0, 0, 0.75);
                -moz-box-shadow: 0px 3px 14px 2px rgba(0, 0, 0, 0.75);
                box-shadow: 0px 3px 14px 2px rgba(0, 0, 0, 0.75);
            }

            #img {
                background-color: #800000;
            }

            .btn-primary {
                background-color: #800000;
            }
        </style>
        <div id="formc" class="card mb-12" style="max-width: 800px;">
            <div class="row no-gutters">
                <div class="col-md-5">

                    <img src="img/aad.png" id="img"
                        width="280" height="400" class="card-img" alt="..."/>
                </div>
                <div class="col-md-7">
                    <div class="card-body text-center">

                        <h2 class=" text-center" style="font-family: Ginebra;">HRI ADMINISTRATOR</h2>


                        <form id="form1" runat="server">
                            <div class="form-group 'has-error' : ''; ?>">
                                <label>Usuario</label>
                                <asp:TextBox ID="txtuser" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group 'has-error' : ''; ?>">
                                <label>Contraseña</label>
                              
                                <asp:TextBox ID="txtpassword" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnlogin" class="btn btn-primary" runat="server" Text="Login" OnClick="btnlogin_Click"></asp:Button>
                                    <h3><asp:Label ID="logg" runat="server" Text="" class="form-text text-danger"></asp:Label></h3>
                                 
                            </div>

                        </form>
                    </div>
                </div>
            </div>
        </div>





    </div>




    <script src="js/bootstrap.js"></script>


</body>
</html>
