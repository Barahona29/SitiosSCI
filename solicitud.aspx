<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="solicitud.aspx.cs" Inherits="proyecto2APSW.solicitud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel="stylesheet" href="css/solicitud.css" />
       <script src="https://kit.fontawesome.com/a076d05399.js"></script>
       <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/waypoints/4.0.1/jquery.waypoints.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Counter-Up/1.0.0/jquery.counterup.min.js"></script>
 <title>Solicitud</title>
 </head>
 <body>
     <style>
         .botondesc 
         {
         background-color:black;
         color:white;
         }

         .counter-up{
  min-height: 50vh;
  background-size: cover;
  background-attachment: fixed;
  padding: 0 50px;
  position: relative;
  display: flex;
  align-items: center;
}
.counter-up::before{
  position: absolute;
  content: "";
  top: 0;
  left: 0;
  height: 100%;
  width: 100%;
 
}
.counter-up .content{
  z-index: 1;
  position: relative;
  display: flex;
  width: 100%;
  height: 100%;
  flex-wrap: wrap;
  align-items: center;
  justify-content: space-between;
}
.counter-up .content .box{

  display: flex;
  align-items: center;
  justify-content: space-evenly;
  flex-direction: column;
  padding: 10px;
}
.content .box .icon{
  font-size: 48px;
  color: #000000;
}
.content .box .counter{
  font-size: 50px;
  font-weight: 500;
  color: #000000;
  font-family: sans-serif;
}
.content .box .text{
  font-weight: 400;
  color: #000000;
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
          <li><a href="http://empresasci-001-site1.etempurl.com/generalfiscalizador.aspx">Inicio</a></li>
         <li><a href="http://empresasci-001-site1.etempurl.com/Muestra.aspx">Comunicación</a></li>
         <li><a href="http://empresasci-001-site1.etempurl.com/login2.aspx">Cerrar Sesión</a></li>
       </div>
     </ul>
   </nav>
<div class="bloque">
 <h1> SOLICITUDES </h1>
</div>
         <br />
        	<div style="text-align:center;">
                <div id="counterup" class="counter-up">
    <div id="content" class="content">
				<div class="box" >
        <div class="icon"><i id="icon1" class="fa fa-cogs"></i></div>
        <div id="cont1" class="counter"><asp:Label ID="lblpuntaje1" runat="server" Text=""></asp:Label></div>
        <div class="text">
            <asp:Label ID="lblpuntaje1texto" runat="server" Text=""></asp:Label></div>
      </div>
					&nbsp&nbsp&nbsp&nbsp&nbsp
					<div class="box" >
        <div class="icon"><i id="icon2" class="fa fa-cogs"></i></div>
        <div id="cont2" class="counter"><asp:Label ID="lblpuntaje2" runat="server" Text=""></asp:Label></div>
        <div class="text"><asp:Label ID="lblpuntaje2texto" runat="server" Text=""></asp:Label></div>
      </div>
					&nbsp&nbsp&nbsp&nbsp&nbsp
					<div class="box" >
        <div class="icon"><i id="icon3" class="fa fa-cogs"></i></div>
        <div id="cont3" class="counter"><asp:Label ID="lblpuntaje3" runat="server" Text=""></asp:Label></div>
        <div class="text"><asp:Label ID="lblpuntaje3texto" runat="server" Text=""></asp:Label></div>
      </div>
					</div>
                    </div>
                </div>
<br />
<div class="vertical3">
    <asp:Button ID="btnPendientes" class="botonpendiente" runat="server" Text="Pendientes" OnClick="btnPendientes_Click" />
    <asp:Button ID="btnAprobadas" class="botonbueno" runat="server" Text="Aprobadas" OnClick="btnAprobadas_Click" />
    <asp:Button ID="btnRechazadas" class="botonmal" runat="server" Text="Rechazadas" OnClick="btnRechazadas_Click" />
</div>
<div class="container">

<div class="card">
  <img src="../img/logo.png" class="logo" />
  <div class="card-details">
    <h2 class="card-head">
        <asp:Label ID="lblCodigo1" runat="server" Text="Label"></asp:Label></h2>
    <br>
      <asp:Label ID="lblDescripcion" runat="server" Text="Label"></asp:Label><br />
      <asp:Label ID="lblEvidencia" runat="server" Text="Label"></asp:Label><br />
      <asp:Label ID="lblInicio" runat="server" Text="Label"></asp:Label><br />
      <asp:Label ID="lblFin" runat="server" Text="Label"></asp:Label><br />
      <asp:Label ID="lblArea" runat="server" Text="Área"></asp:Label><br />
      <asp:Label ID="lblDepartamento" runat="server" Text="Label"></asp:Label><br />
      <asp:Label ID="lblModelo" runat="server" Text="Modelo: Ambiente de Control"></asp:Label><br />
      <asp:Label ID="lblComponente" runat="server" Text="Componente: Compromiso"></asp:Label>
      <asp:Button ID="btnDescargar" runat="server" Text="Ver evidencia" CssClass="botondesc" OnClick="btnDescargar_Click" /><br />
      <br>
      <asp:Button ID="btnAprobar1" CssClass="botonbueno" runat="server" Text="Aprobar" OnClick="btnAprobar1_Click" />
      <asp:Button ID="btnRechazar1" CssClass="botonmal" runat="server" Text="Rechazar" OnClick="btnRechazar1_Click" />
  </div>
</div>

<div class="card">
  <img src="../img/logo.png" class="logo" />
  <div class="card-details">
    <h2 class="card-head">
        <asp:Label ID="lblCodigo2" runat="server" Text="Label"></asp:Label></h2>
     <br>
  <asp:Label ID="lblDescripcion2" runat="server" Text="Label"></asp:Label><br />
      <asp:Label ID="lblEvidencia2" runat="server" Text="Label"></asp:Label><br />
      <asp:Label ID="lblInicio2" runat="server" Text="Label"></asp:Label><br />
      <asp:Label ID="lblFin2" runat="server" Text="Label"></asp:Label><br />
      <asp:Label ID="lblArea2" runat="server" Text="Área"></asp:Label><br />
      <asp:Label ID="lblDepartamento2" runat="server" Text="Label"></asp:Label><br />
      <asp:Label ID="lblModelo2" runat="server" Text="Modelo: Ambiente de Control"></asp:Label><br />
      <asp:Label ID="lblComponente2" runat="server" Text="Componente: Compromiso"></asp:Label>
            <asp:Button ID="btnDescargar2" runat="server" CssClass="botondesc" Text="Ver evidencia" OnClick="btnDescargar2_Click" /><br />
      <br>
      <asp:Button ID="btnAprobar2" CssClass="botonbueno" runat="server" Text="Aprobar" OnClick="btnAprobar2_Click" />
      <asp:Button ID="btnRechazar2" CssClass="botonmal" runat="server" Text="Rechazar" OnClick="btnRechazar2_Click" />
   <br>
  </div>
</div>

<div class="card">
  <img src="../img/logo.png" class="logo" />
  <div class="card-details">
    <h2 class="card-head">
        <asp:Label ID="lblCodigo3" runat="server" Text="Label"></asp:Label></h2>
     <br>
    <asp:Label ID="lblDescripcion3" runat="server" Text="Label"></asp:Label><br />
      <asp:Label ID="lblEvidencia3" runat="server" Text="Label"></asp:Label><br />
      <asp:Label ID="lblInicio3" runat="server" Text="Label"></asp:Label><br />
      <asp:Label ID="lblFin3" runat="server" Text="Label"></asp:Label><br />
      <asp:Label ID="lblArea3" runat="server" Text="Área"></asp:Label><br />
      <asp:Label ID="lblDepartamento3" runat="server" Text="Label"></asp:Label><br />
      <asp:Label ID="lblModelo3" runat="server" Text="Modelo: Ambiente de Control"></asp:Label><br />
      <asp:Label ID="lblComponente3" runat="server" Text="Componente: Compromiso"></asp:Label>
            <asp:Button ID="btnDescargar3" runat="server" CssClass="botondesc" Text="Ver evidencia" OnClick="btnDescargar3_Click" /><br />
      <br>
      <asp:Button ID="btnAprobar3" CssClass="botonbueno" runat="server" Text="Aprobar" OnClick="btnAprobar3_Click" />
      <asp:Button ID="btnRechazar3" CssClass="botonmal" runat="server" Text="Rechazar" OnClick="btnRechazar3_Click" />
     <br>
  </div>
</div>
</div>



<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>

<div class="fondo">
            <div class="contraste">
                <div class="div-tabla1">
                <div class="reporte">
                
                    <asp:Button ID="btnReporteGen" class="btnreporte" runat="server" Text="Reporte General" OnClick="btnReporteGen_Click" />
                </div>
                   <h1>Lista de Solicitud</h1> 
                <br/>
                    <div class="filtro">
                        <label class="label">Búsqueda por:</label>
                         <asp:DropDownList ID="ddlfiltro" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlfiltro_SelectedIndexChanged">
                        <asp:ListItem>Pendiente</asp:ListItem>
                        <asp:ListItem>Aprobadas</asp:ListItem>
                        <asp:ListItem>Rechazadas</asp:ListItem>
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

         function aceptar(c) {

             var nombrec = c.name;
             const valores = window.location.search;
             const datos = valores.split(';');
             const datoss = datos[0].split('=');

             window.location.href = "respuesta.aspx/?valor=" + nombrec + ";" + datos[2] + ";" + "1" + ";" + datoss[1] + ";" + datos[1];
         }

         function rechazar(c) {

             var nombrec = c.name;
             const valores = window.location.search;
             const datos = valores.split(';');
             const datoss = datos[0].split('=');

             window.location.href = "respuesta.aspx/?valor=" + nombrec + ";" + datos[2] + ";" + "2" + ";" + datoss[1] + ";" + datos[1];
         }

         function descargar(c) {

             var nombrec = c.name;
             const valores = window.location.search;
             const datos = valores.split(';');
             const datoss = datos[0].split('=');

             window.location.href = "respuesta.aspx/?valor=" + nombrec + ";" + datos[2] + ";" + "3" + ";" + datoss[1] + ";" + datos[1];

         }
     </script>
       <script>
           $(document).ready(function () {
               $('.counter').counterUp({
                   delay: 10,
                   time: 1200
               });
           });
  </script>
</body>
</html>
