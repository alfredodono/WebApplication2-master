<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="WebApplication2.Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="UTF-8" />
    <title>HRI Manager</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="shortcut icon" href="img/icon.ico" />
    <script src="js/bootstrap.min.js"></script>
    <script src="js/popper.min.js"></script>
    <link rel="stylesheet" type="text/css" href="datatables.min.css" />
    <script src="jquery/jquery-3.5.1.js"></script>
    <script src="jquery/jquery.dataTables.min.js"></script>
    <script src="js/ScrollableGridPlugin.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
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

        #gdvusuarios {
            border-radius: 27px 27px 27px 27px;
            -moz-border-radius: 27px 27px 27px 27px;
            -webkit-border-radius: 27px 27px 27px 27px;
            border: 0px solid #000000;
        }

        #centrado {
            display: flex;
            align-items: center;
            justify-content: center;
            min-height: 50vh;
        }
    </style>

    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-lignt">
           <asp:Button ID="Button2" class="navbar-brand text-white" BackColor="#800000" BorderStyle="None" runat="server" OnClick="btnHome_Click" Text="Nissan HRI" />
            <button class="navbar-toggler " type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon "></span>
            </button>

            <div class="collapse navbar-collapse text-white  " id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto text-white">
                    <li class="nav-item active text-white">
                        <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="BtnAlerts" runat="server" Text="Alerts" />
                    </li>
                    <li class="nav-item active text-white">
                        <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="btnHomes" runat="server" Text="Home" OnClick="btnHome_Click" />
                    </li>
                    <li class="nav-item">
                        <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="BtnUsers" runat="server" Text="Usuarios" OnClick="BtnUsers_Click" />


                    </li>
                    <li class="nav-item">
                        <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="btnHRI" runat="server" Text="HRI" OnClick="BtnHRI_Click" />


                    </li>
                    <li class="nav-item">
                        <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="BtnControl" runat="server" Text="Control" OnClick="BtnControl_Click" />


                    </li>


                </ul>
                <div id="yo">
                    <asp:Label ID="lblId" runat="server"></asp:Label>

                </div>

                <div class="nav-item">
                    <asp:Button class="nav-link text-white" ID="btnlogout" BackColor="#800000" BorderStyle="None" runat="server" Text="Logout" OnClick="btnlogout_Click" />
                </div>


            </div>
        </nav>


        <div id="Tablas" class=" container-fluid">
            <div class="text-center">
                <h3>Asignacion de IPs</h3>
            </div>
                  <div class="form-row text-center">
                        <div class="form-group col-md-2">
                           <asp:Button ID="btnVovler" runat="server" Text="◄ Volver " OnClick="btnVovler_Click"  type="button" class="btn btn-warning btn-block" ForeColor="White" />
                           
                        </div>
                        <div class="form-group col-md-2">
                            <asp:Button ID="btncHRI" runat="server" Text="Administrar preguntas 📝" OnClick="btncHRI_Click" type="button" class="btn btn-success btn-block" ForeColor="White" />
                           
                        </div>
                    </div>
           
            <div class="text-center">
                <h2>
                    <asp:Label ID="lblmensaje" class="badge badge-warning" runat="server" Text=""></asp:Label>

                </h2>
            </div>
            <div class="text-center">
                <h2>
                    <asp:Label ID="jolosoy" class="badge badge-success" runat="server" Text=""></asp:Label>
                </h2>
            </div>
            <div class="container">
            </div>
            <div class="row">
                <style>
                    #Tablas {
                        margin-left: 20px;
                    }
                </style>
                <div class="col-md-5  card">
                    <div class="text-center">
                        <h3>
                            <asp:Label ID="Label8" runat="server" Text="IPs Disponibles"></asp:Label>
                        </h3>
                    </div>

                       <div class="form-row">
                        <div class="form-group col-md-10">
                          
                            <asp:TextBox ID="TextBox1"  placeholder="Ingrese Nombre" runat="server" class="form-control" OnTextChanged="FiltroIps"  AutoPostBack="True"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-2">
                            <asp:Button ID="Button3" runat="server" Text="Buscar"  type="button" class="btn btn-warning btn-block" ForeColor="White" />
                           
                        </div>
                    </div>
                    <table class="table table-bordered table-striped" border="1" style="border-collapse: collapse; ">
                        <tbody>
                            <tr style="color: White; background-color: Maroon; border-style: None;">
                                  <td class="" style="width:">Id
                                </td>
                                <td class="" style="width: 450px;">
                                    <label>Nombre</label>
                                </td>
                               
                                <td class="" style="width: 200px;">IP
                                </td>

                                <td class="" style="width: 200px;">Type
                                </td>
                                <td class="" style="width: 5px;">Agregar
                                </td>

                            </tr>
                        </tbody>
                    </table>
                    <div class="text-center" style="height: 200px; width:auto;  overflow: auto;">

                        <%--                    <asp:TextBox ID="txtid" runat="server"></asp:TextBox>--%>

                        <asp:Label ID="cabecera" runat="server"></asp:Label>
                        <asp:GridView ID="TablaIp" DataKeyNames="ID" class="thead-dark text-center" OnRowUpdating="gdvHRI_RowUpdating" ShowHeader="false" CssClass="table table-bordered table-striped " RowHeaderColumn="hola, prros" AutoGenerateColumns="false" runat="server">

                            <Columns>
                                 <asp:BoundField DataField="ID" ItemStyle-CssClass="text-center" HeaderText="ID"  />
                                <asp:BoundField DataField="Nombre" ItemStyle-CssClass="text-center" HeaderText="Nombre"  />
                                <asp:BoundField DataField="IP" ItemStyle-CssClass="text-center" HeaderText="IP"  />
                                <asp:BoundField DataField="Type" ItemStyle-CssClass="text-center" HeaderText="Type"  />
                                
                                
                                <asp:TemplateField HeaderText="Agregar">
                                    <ItemTemplate>

                                        <h2>
                                            <asp:LinkButton Text="dc" runat="server" CommandName="Update">
                                        <img src="icons/add.png" width="40" height="40"> </asp:LinkButton>
                                        </h2>

                                    </ItemTemplate>

                                </asp:TemplateField>


                            </Columns>

                            <HeaderStyle BackColor="Maroon" BorderStyle="None" ForeColor="White" />
                        </asp:GridView>

                    </div>



                    <br />

                </div>
                <div class="col-md-1">
                </div>

                <div class="col-md-5  card">
                    <div class="text-center">
                        <h3>
                            <asp:Label ID="Label2" runat="server" Text="IPs Asignadas"></asp:Label>
                        </h3>
                    </div>

                    <div class="text-center">

                  
                    <table class="table table-bordered table-striped" border="1" style="border-collapse: collapse; ">
                        <tbody>
                            <tr style="color: White; background-color: Maroon; border-style: None;">

                                <td class="" style="width: px;">
                                    <label>id</label>
                                </td>
                                <td class="" style="width: 250px;">NOMBRE
                                </td>
                                 <td class="" style="width: 250px;">IP
                                </td>
                                <td class="" style="width: 130px;">Type
                                </td>
                                <td class="" style="width: 150px;">Quitar
                                </td>

                            </tr>
                        </tbody>
                    </table>
                          </div>
                    <div class="text-center" style="height: 200px; width:auto;  overflow: auto;">

                        <%--                    <asp:TextBox ID="txtid" runat="server"></asp:TextBox>--%>

                        <asp:Label ID="Label9" runat="server"></asp:Label>
                        <asp:GridView ID="gdvIpA" DataKeyNames="ID" class="thead-dark text-center" OnRowUpdating="gdvHRI_borrar" ShowHeader="false" CssClass="table table-bordered table-striped " RowHeaderColumn="hola, prros" AutoGenerateColumns="false" runat="server">

                            <Columns>
                                 <asp:BoundField DataField="ID" ItemStyle-CssClass="text-center" HeaderText="ID"  />
                                <asp:BoundField DataField="Nombre" ItemStyle-CssClass="text-center" HeaderText="Nombre"  />
                                <asp:BoundField DataField="IP" ItemStyle-CssClass="text-center" HeaderText="IP"  />
                                <asp:BoundField DataField="Type" ItemStyle-CssClass="text-center" HeaderText="Type"  />
                                <asp:TemplateField HeaderText="Agregar">
                                    <ItemTemplate>

                                        <h2>
                                            <asp:LinkButton Text="dc" runat="server" CommandName="Update">
                                        <img src="icons/cancel.png" width="40" height="40"> </asp:LinkButton>
                                        </h2>

                                    </ItemTemplate>

                                </asp:TemplateField>


                            </Columns>

                            <HeaderStyle BackColor="Maroon" BorderStyle="None" ForeColor="White" />
                        </asp:GridView>

                    </div>



                    <br />

                </div>





            </div>

            <div class="row">

                <div class="col-md-5  card">
                  
                    <div class="text-center">
                        <h3>
                            <asp:Label ID="Label4" runat="server" Text="Maquinas Especiales disponibles"></asp:Label>
                        </h3>
                    </div>

                 
                       <div class="form-row">
                        <div class="form-group col-md-10">
                          
                            <asp:TextBox ID="TextBox3" runat="server" placeholder="Ingrese Maquina Especial" class="form-control"  OnTextChanged="FiltroMaA"  AutoPostBack="True"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-2">
                            <asp:Button ID="Button1" runat="server" Text="Buscar" type="button"  class="btn btn-warning btn-block" ForeColor="White" />
                           
                        </div>
                    </div>
                    <table class="table table-bordered table-striped" border="1" style="border-collapse: collapse; ">
                        <tbody>
                            <tr style="color: White; background-color: Maroon; border-style: None;">
                                <td class="" >
                                    <label>ID</label>
                                </td>
                                <td class=""  style="width:430px;">
                                    <label>Nombre</label>
                                </td>
                               
                                <td class="" style="width: 150px;">Agregar
                                </td>

                            </tr>
                        </tbody>
                    </table>
                    <div class="text-center" style="height: 200px; width:auto;  overflow: auto;">

                        <%--                    <asp:TextBox ID="txtid" runat="server"></asp:TextBox>--%>

                        <asp:Label ID="Label10" runat="server"></asp:Label>
                        <asp:GridView ID="GdvEsp"  DataKeyNames="ID" OnRowUpdating="GDVEspAd" class="table table-condensed thead-dark text-center"  ShowHeader="false" CssClass="table table-bordered table-striped " RowHeaderColumn="hola, prros" AutoGenerateColumns="false" runat="server">

                            <Columns>
                                 <asp:BoundField DataField="ID" ItemStyle-CssClass="text-center" HeaderText="ID"  />
                                <asp:BoundField DataField="Nombre" ItemStyle-CssClass="text-center" HeaderText="Nombre"  />
                          
                                <asp:TemplateField HeaderText="Agregar">
                                    <ItemTemplate>

                                        <h2>
                                            <asp:LinkButton Text="dc" runat="server" CommandName="Update">
                                        <img src="icons/add.png" width="40" height="40"> </asp:LinkButton>
                                        </h2>

                                    </ItemTemplate>

                                </asp:TemplateField>


                            </Columns>

                            <HeaderStyle BackColor="Maroon" BorderStyle="None" ForeColor="White" />
                        </asp:GridView>

                    </div>



                    <br />

                </div>
                <div class="col-md-1">
                </div>

                <div class="col-md-5  card">
                    <div class="text-center">
                        <h3>
                            <asp:Label ID="Label6" runat="server" Text="Maquinas especiales Asignadas"></asp:Label>
                        </h3>
                    </div>
                        <div class="text-center">

                     
                    <table class="table table-bordered table-striped" border="1" style="border-collapse: collapse; ">
                        <tbody>
                            <tr style="color: White; background-color: Maroon; border-style: None;">
                                <td class="">
                                    <label>ID</label>
                                </td>
                                <td class="" style="width:450px;">
                                    <label>Nombre</label>
                                </td>
                              
                                <td class="" style="width: 150px;">Quitar
                                </td>

                            </tr>
                        </tbody>
                    </table>
                               </div>
                    <div class="text-center" style="height: 200px; width:auto;  overflow: auto;">

                        <%--                    <asp:TextBox ID="txtid" runat="server"></asp:TextBox>--%>

                        <asp:Label ID="Label11" runat="server"></asp:Label>
                        <asp:GridView ID="gdvEspAs" DataKeyNames="ID" OnRowUpdating="gdbEspBS" class="thead-dark text-center" ShowHeader="false" CssClass="table table-bordered table-striped " RowHeaderColumn="hola, prros" AutoGenerateColumns="false" runat="server">

                            <Columns>

                                
                                <asp:BoundField DataField="ID" ItemStyle-CssClass="text-center" HeaderText="ID"  />
                                <asp:BoundField DataField="Nombre" ItemStyle-CssClass="text-center" HeaderText="Nombre"  />
                              
                                <asp:TemplateField HeaderText="Quitar">
                                    <ItemTemplate>

                                        <h2>
                                            <asp:LinkButton Text="dc" runat="server" CommandName="Update">
                                        <img src="icons/cancel.png" width="40" height="40"> </asp:LinkButton>
                                        </h2>

                                    </ItemTemplate>

                                </asp:TemplateField>


                            </Columns>

                            <HeaderStyle BackColor="Maroon" BorderStyle="None" ForeColor="White" />
                        </asp:GridView>

                    </div>



                    <br />

                </div>




            </div>
        </div>

    </form>
    <br />
    <div>
    </div>
    <div id="hola ">
        <footer class="footer page-footer font-small sticky-footer ">
            <div align="center">
                <div class="row col-md-7">
                    <div class="col-md-8">
                        <p class="text-white">
                            <br/>
                            <br/>
                            <b>Nissan Mexicana             
                                <br/>
                                <b>Extensiones Soporte: 2153,2154,2155,2156</b>
                                <br/>Nissan HRI Web Portal V0.1.1 (Release)
                       
                        </p>
                    </div>

                    <div class="col-md-4">
                        <img src="img/aad.png" alt="" height="200" width="200"/>
                    </div>

                </div>




            </div>

        </footer>
    </div>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script type="text/javascript" src="datatables.min.js"></script>
    <script src="js/jquery-3.5.1.min.js"></script>
</body>
</html>
