<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="asignacion.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="proyecto2APSW.asignacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/aceptacion1.css" />
   <title>Asignación</title>
</head>
 <body>
     <form id="form1" runat="server">
       <nav class="navbar">
     <!-- LOGO -->
     <div class="logo"></div>
     <!-- NAVIGATION MENU -->
     <ul class="nav-links">
       <!-- USING CHECKBOX HACK -->
       <input type="checkbox" id="checkbox_toggle" />
       <label for="checkbox_toggle" class="hamburger">&#9776;</label>
       <!-- NAVIGATION MENUS -->
       <div class="menu">
         <li><a href="generaldiscalizador.aspx.aspx">Inicio</a></li>
         <li><a href="contactenos.html">Contactenos</a></li>
         <li><a href="login2.aspx">Cerrar Sesion</a></li>
       </div>
     </ul>
   </nav>

<div class="central">
   <div class="caja">
<br>

<div class="group">
<label for="NombreCompleto" class="label">Nombre Completo</label> &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtNombre" CssClass="texto" runat="server"></asp:TextBox>
</div>
<br>
<div class="group">
<label for="Usuario" class="label">Usuario</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtUsuario" CssClass="texto" runat="server"></asp:TextBox>
</div>
<br>
<div class="group">
<label for="Contraseña" class="label">Contraseña</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtPass" CssClass="texto" runat="server"></asp:TextBox>
</div>
<br>
<div class="group">
<label for="Correo" class="label">Correo</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtCorreo" CssClass="texto" runat="server" TextMode="Email"></asp:TextBox>
</div>
<br>
  <div class="group">
        <label for="Area" class="label">Area</label>
        <br>
        
      <asp:DropDownList CssClass="opciones" ID="ddlArea" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged">
          <asp:ListItem>Administración</asp:ListItem>
        </asp:DropDownList>
        <br>
  </div>
<br>
    <div class="group">
        <label for="Dependencia" class="label">Dependencia</label>
        <br>
        <asp:DropDownList ID="ddlDependencia" CssClass="opciones" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged">
            <asp:ListItem>Depto. Registro</asp:ListItem>
        </asp:DropDownList>
        <br>
  </div>
<br>
    <div class="group">
        <label for="Cargo" class="label">Cargo</label>
        <br>
       

        <asp:DropDownList ID="ddlCargo" CssClass="opciones" runat="server">
            <asp:ListItem>Encargado</asp:ListItem>
        </asp:DropDownList>
        <br>
  </div>
<br>
<div class="group">
        <label for="Estado" class="label">Estado</label>
        <br>
       

    <asp:DropDownList CssClass="opciones" ID="ddlEstado" runat="server">
        <asp:ListItem>Habilitado</asp:ListItem>
            <asp:ListItem>Deshabilitado</asp:ListItem>
    </asp:DropDownList>
        <br>
  </div>
<br>
 

       <asp:Button ID="btnRegistrar" CssClass="button1" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
       <asp:Button ID="btnEliminar" CssClass="button2" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
       <asp:Button ID="btnModificar" CssClass="button3" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
<br>
</div>
</div>
<br>

<div class="fondo">
            <div class="contraste">
                <div class="div-tabla1">
                   <center>Lista De usuarios</center> 
                <br/>
                    <div class="filtro">
                        <label for="">Filtrar por:</label>
                       
                        <asp:DropDownList ID="ddlFiltro" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFiltro_SelectedIndexChanged">
                            <asp:ListItem>Área</asp:ListItem>
                            <asp:ListItem>Cargo</asp:ListItem>
                        </asp:DropDownList>
                   <br/>
                    </div>
                    <div class="contenedor-tabla">
                        <asp:Table ID="Table1" runat="server">


                        </asp:Table>
                    </div>          
                </div>           
            </form>

     <script>
         function cargar(c) {

             var nombrec = c.name;



             window.location.href = "asignacion.aspx/?nombre=" + nombrec+";"+"1";

         }
     </script>
</body>
</html>
