<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlertsHRI.aspx.cs" Inherits="WebApplication2.AlertsHRI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="UTF-8" />
    <title>Alerts Control</title>

    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="shortcut icon" href="img/icos/image.ico" />
    <script src="js/bootstrap.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/jquery-3.5.1.min.js"></script>
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

        #hola {
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
            <asp:Button ID="btnHome" class="navbar-brand text-white" BackColor="#800000" BorderStyle="None" runat="server" OnClick="btnHomes_Click" Text="Nissan HRI" />
            <button class="navbar-toggler " type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon "></span>
            </button>

            <div class="collapse navbar-collapse text-white  " id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto text-white">
                    <li class="nav-item active text-white">
                        <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="BtnAlerts" runat="server" Text="Alerts" OnClick="BtnAlerts_Click" />
                    </li>
                    <li class="nav-item active text-white">
                        <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="btnHomes" runat="server" Text="Home" OnClick="btnHomes_Click" />
                    </li>
                    <li class="nav-item">
                        <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="BtnUsers" runat="server" Text="Usuarios" OnClick="BtnUsers_Click" />


                    </li>
                    <li class="nav-item">
                        <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="btnHRI" runat="server" Text="HRI" OnClick="btnHRI_Click" />


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
        <div>
        </div>
        <div class="container-fluid">
            <div class="text-center">
                <h3>Alerts Control</h3>
                <div class="text-center">
                    <h3>
                        <asp:Label ID="lblmensaje" class="badge badge-warning" runat="server" Text=""></asp:Label>

                    </h3>
                </div>
                <div class="text-center">
                    <h3>
                        <asp:Label ID="jolosoy" class="badge badge-success" runat="server" Text=""></asp:Label>

                    </h3>
                </div>
            </div>
            <div class="card">

                <br />
                <div class="form-Group col-md-12">
                    <div class="form-row text-center">
                        <div class="form-group col-md-6">
                            <label for="inputEmail4">Status</label>
                            <asp:DropDownList ID="dpcheck" OnTextChanged="dpcheck_TextChanged" AutoPostBack="True" class="control " runat="server">
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>OK</asp:ListItem>
                                <asp:ListItem>Check</asp:ListItem>
                                <asp:ListItem>No Check</asp:ListItem>
                            </asp:DropDownList>

                            <label for="inputEmail4">From </label>
                            <asp:TextBox ID="txtfrom" OnTextChanged="txtfrom_TextChanged" TextMode="Date" runat="server" AutoPostBack="True"></asp:TextBox>
                            <label for="inputEmail4">To </label>
                            <asp:TextBox ID="Txtto" TextMode="Date" OnTextChanged="txtfrom_TextChanged" AutoPostBack="True" runat="server"></asp:TextBox>
                            <label for="inputEmail4" class="col-md-1"></label>

                            <%--<asp:TextBox ID="TextBox4"  class="col-md-2" runat="server"></asp:TextBox>--%>
                        </div>

                        <div class="form-group col-md-2">
                            <asp:TextBox ID="TextBox5" placeholder="Buscar" OnTextChanged="TextBox5_TextChanged" AutoPostBack="true" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-2">
                            <asp:Button ID="Button1" runat="server" Text="Buscar" type="button" class="btn btn-warning btn-block" ForeColor="White" />

                        </div>
                    </div>
                    <div class="form-row ">
                    </div>

                </div>

            </div>
            <div class="form-group">
                <div class="row">

                    <div class="col-md-8 " style="padding-left: 1rem;">




                        <table class="table table-bordered table-striped" border="1" style="border-collapse: collapse;">
                            <tbody>
                                <tr style="color: White; background-color: Maroon; border-style: None;">
                                    <td class="" style="width: 50px;">Id
                                    </td>
                                    <td class="" style="width: 100px;">
                                        <label>HRI</label>
                                    </td>
                                    <td class="" style="width: 50px;">Machine Name
                                    </td>
                                    <td class="" style="width: 200px;">Equipo Especial
                                    </td>
                                    <td class="" style="width: 300px;">Question
                                    </td>
                                    <td class="" style="width: 1px;">fecha
                                    </td>
                                    <td class="" style="width: 1px;">status
                                    </td>
                                    <td class="" style="width: 1px;">foto
                                    </td>
                                    <td class="" style="width: 1px;">visualizar
                                    </td>
                                    <td class="" style="width: 1px;">checado
                                    </td>
                                    <td class="" style="width: 1px;">Download
                                    </td>


                                </tr>
                            </tbody>
                        </table>
                        <div class="text-center" style="height: 500px; width: auto; overflow: auto;">

                            <%--                    <asp:TextBox ID="txtid" runat="server"></asp:TextBox>--%>

                            <asp:Label ID="cabecera" runat="server"></asp:Label>
                            <asp:GridView ID="gdvAnswer" DataKeyNames="ID" OnRowUpdating="gdvAnswer_RowUpdating" OnRowDataBound="gdvAnswer_RowDataBound" OnRowDeleting="gdvAnswer_RowDeleting" class="thead-dark text-center" ShowHeader="false" CssClass="table table-bordered table-striped " RowHeaderColumn="hola, prros" AutoGenerateColumns="false" runat="server">

                                <Columns>
                                    <asp:BoundField DataField="ID" ItemStyle-CssClass="text-center" HeaderText="ID" />
                                    <asp:BoundField DataField="NameHRI" ItemStyle-CssClass="text-center" HeaderText="NameHRI" />
                                    <asp:BoundField DataField="Machine_Name" ItemStyle-CssClass="text-center" HeaderText="Machine_Name" />
                                    <asp:BoundField DataField="EquipoEspecial" ItemStyle-CssClass="text-center" HeaderText="EquipoEspecial" />
                                    <asp:BoundField DataField="question" ItemStyle-CssClass="text-center" HeaderText="question" />
                                    <asp:BoundField DataField="Date" ItemStyle-CssClass="text-center" HeaderText="Date" />
                                    <asp:BoundField DataField="status" ItemStyle-CssClass="text-center" HeaderText="status" />
                                    <asp:TemplateField HeaderText="foto">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" Width="40" Height="40"  ImageUrl="~/img/adds.png" />
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Update">
                                        <ItemTemplate>

                                            <h2>
                                                <asp:LinkButton Text="dc" runat="server" CommandName="Update">
                                        <img src="img/lent.png" width="40" height="40"> </asp:LinkButton>
                                            </h2>

                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>

                                            <h2>
                                                <asp:LinkButton runat="server" CommandName="Delete">
                                                     <asp:Image ID="hol" runat="server" Width="40" Height="40"  ImageUrl="img/check.png" />
                                                    
                                                </asp:LinkButton>
                                            </h2>

                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="DownloadFile"
                                                CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>

                                <HeaderStyle BackColor="Maroon" BorderStyle="None" ForeColor="White" />
                            </asp:GridView>

                        </div>

                    </div>

                    <br />


                   
                    <div class="col-md-3 " style="">
                    <br />
                        <div class="text-center">
                            <h3>
                                <asp:Label ID="Label1" runat="server" Text="Visualizar imagen"></asp:Label>
                            </h3>
                        </div>



                        <div class="text-center" style="height: 400px; width: auto; overflow: auto;">

                            <%--                    <asp:TextBox ID="txtid" runat="server"></asp:TextBox>--%>


                            <asp:Image ID="Image2" runat="server" Width="300" Height="300" ImageUrl="~/img/aaaa.png" />

                        </div>

                        <div class="text-center">
                            <h3>
                                <asp:Label ID="txterror" runat="server" Text=""></asp:Label></h3>


                            
                        </div>

                    </div>

                

            </div>
        </div>
    </form>







    <div id="hola ">
        <footer class="footer page-footer font-small   ">

            <div align="center">
                <div class="row col-md-5">
                    <div class="col-md-8">
                        <p class="text-white">
                            <br />

                            <b>Nissan Mexicana</b>
                            <br />
                            <b>Extensiones Soporte: 2153,2154,2155,2156</b>
                            <br />
                            Nissan HRI Web Portal V0.1.1 (Release)
                       
                        </p>
                    </div>

                    <div class="col-md-4">
                        <img src="img/image.png" alt="" height="150" width="200" />
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
