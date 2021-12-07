<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="apertura2.aspx.cs" Inherits="proyecto2APSW.apertura2" %>

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
          <li> <asp:Button ID="btnRevision" runat="server" CssClass="botontranspar" Text="Revisión" OnClick="btnRevision_Click" /></li>
         <li><a href="login2.aspx">Cerrar Sesión</a></li>
       </div>
     </ul>
   </nav>


<div class="central">
   <div class="caja" style="height: 700px;">
 <h1>Modificar evidencia</h1>
 <div class="vertical3">
<label class="label">Descripción</label>
<label class="label">Evidencia</label>

</div>
 <div class="verticaltxt">
     <asp:TextBox ID="txtDescripción" CssClass="texto" runat="server" TextMode="MultiLine"></asp:TextBox>
     <asp:TextBox ID="txtEvidencia" CssClass="texto" runat="server" TextMode="MultiLine"></asp:TextBox>
</div>
<br>
 <div class="vertical3">
<label class="label">Estado</label>
</div>
<div class="vertical">

    <asp:DropDownList ID="ddlTipo" CssClass="opciones" runat="server">
        <asp:ListItem>Opcional</asp:ListItem>
        <asp:ListItem>Obligatorio</asp:ListItem>
    </asp:DropDownList>
</div>
<br>    
<div class="vertical2">
<label class="label">Área</label>
</div>    
<div class="vertical">
    <asp:DropDownList ID="ddlModelo" CssClass="opciones" AutoPostBack="true" Enabled="false"  runat="server" OnSelectedIndexChanged="ddlModelo_SelectedIndexChanged">
        <asp:ListItem>Ambiente de Control</asp:ListItem>
    </asp:DropDownList>
</div>
<br>
 
<br>
       
       <asp:Button ID="btnModificar" CssClass="button3" runat="server" Text="Modificar" Visible="False" OnClick="btnModificar_Click" />

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
                   <h1>Lista de evidencias</h1> 
                <br/>
                    <div class="filtro">
                        <label class="label">Búsqueda por:</label>
                        <asp:DropDownList ID="ddlFiltro" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlFiltro_SelectedIndexChanged">
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



             window.location.href = "apertura2.aspx/?nombre=" + nombrec+";Cerrado";

          }
          function cargar2(c) {

              var nombrec = c.name;



              window.location.href = "apertura2.aspx/?nombre=" + nombrec + ";Abierto";

          }
     </script>
</body>
</html>