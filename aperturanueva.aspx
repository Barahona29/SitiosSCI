<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aperturanueva.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="proyecto2APSW.aperturanueva" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <link rel="stylesheet" href="css/apertura.css" />
    <title>Apertura</title>
 </head>
 <body>
     <style>
         .calendario1
         {
         left: 17%;
         position:absolute;
         }
         .calendario2 
         {
         left: 55%;
         position:absolute;
         }
        
    .botontranspar 
    {
    background-color: transparent;
	border: none;
    outline:none;
	color:black;
    font-size:20px;
    }
     </style>
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
         <li><a href="generaldiscalizador.aspx">Inicio</a></li>
          <li> <asp:Button ID="btnRevision" runat="server" CssClass="botontranspar" Text="Revisión" OnClick="btnRevision_Click"/></li>
         <li><a href="login2.aspx">Cerrar Sesión</a></li>
       </div>
     </ul>
   </nav>


<div class="central">
   <div class="caja" style="height: 1000px;">
 <h1>Apertura</h1>

 <div class="vertical3">
<label class="label">Modelo</label>
</div>
<div class="vertical">

   <asp:DropDownList ID="ddlModelo" CssClass="opciones" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddlModelo_SelectedIndexChanged">
        <asp:ListItem>Ambiente de Control</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
</div>
       <div class="vertical3">
<label class="label">Formulario</label>
</div>
<div class="vertical">

   <asp:DropDownList ID="ddlComponente" CssClass="opciones"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlComponente_SelectedIndexChanged">
        <asp:ListItem>Compromiso</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
</div>

          <div class="vertical3">
<label class="label">Área</label>
</div>
<div class="vertical">

   <asp:DropDownList ID="ddlArea" CssClass="opciones"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged">
        <asp:ListItem>Compromiso</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
</div>
          <div class="vertical3">
<label class="label">Departamento</label>
</div>
<div class="vertical">

   <asp:DropDownList ID="ddlDepartamento" CssClass="opciones"  runat="server" AutoPostBack="true">
        <asp:ListItem>Compromiso</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
</div>
<br />


<div class="vertical">
 &nbsp;&nbsp;&nbsp;<label class="label">Inicio de apertura</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<label class="label">Fin de apertura</label><div class="calendario1"><asp:Calendar ID="CalendarInicio" runat="server" Height="166px" Width="373px"></asp:Calendar></div>
    &nbsp;&nbsp;&nbsp;
 <div class="calendario2"><asp:Calendar ID="CalendarFin" Height="166px" Width="373px" runat="server"></asp:Calendar></div>
</div> 
<br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
        


<br>

<br>
       <asp:Button ID="btnEnviar" CssClass="button2" runat="server" Text="Abrir formulario" OnClick="btnEnviar_Click" />
       <asp:Button ID="btnModificar" CssClass="button3" runat="server" Text="Modificar" Visible="False"/>

<br>
</div>
</div>
<br />

<div class="fondo">
            <div class="contraste">
                <div class="div-tabla1">
                <div class="reporte">
                    <asp:Button ID="btnReporte" runat="server" Text="Generar reporte" CssClass="btnreporte" OnClick="btnReporte_Click" />
                </div>
                   <h1>Lista de Apertura</h1> 
                <br/>
                    <div class="filtro">
                        <asp:DropDownList ID="ddlFiltro" AutoPostBack="true" Visible="false" runat="server" OnSelectedIndexChanged="ddlFiltro_SelectedIndexChanged">
                            <asp:ListItem>Ambiente de control</asp:ListItem>
                            <asp:ListItem>Valoración de riesgo</asp:ListItem>
                            <asp:ListItem>Actividades de control</asp:ListItem>
                            <asp:ListItem>Sistema de información</asp:ListItem>
                            <asp:ListItem>Seguimiento de CI</asp:ListItem>

                        </asp:DropDownList>
                   <br/>
                    </div>
                    <div class="contenedor-tabla">
                        <asp:Table ID="Table1" runat="server"></asp:Table>
                    </div>          
                </div>           
                </form>
      <script>
         function cargar(c) {

             var nombrec = c.name;

             window.location.href = "apertura2.aspx/?nombre=" + nombrec;

         }
     </script>
</body>
</html>
