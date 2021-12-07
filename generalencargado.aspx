<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="generalencargado.aspx.cs" Inherits="proyecto2APSW.generalencargado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/general.css" />
   <title>Pagina General Encargado</title>
 </head>
 <body>

	   <style>
	  .botontransp {
       background-color: transparent;
	  border: none;
    outline:none;
	color:white;
	width:90%;
	height:70%;
	font-size:12px;

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
         <li><a href="index.html">Inicio</a></li>
         <li><a href="contactenos.html">Contactenos</a></li>
		<li><a href="login2.aspx">Cerrar Sesion</a></li>
	 </div>
     </ul>
   </nav>


    <div class="wrapper">
  <h1> Bienvenido a <asp:Label ID="lblDepartamento" runat="server" Text="Label"></asp:Label></h1>
  <div class="cols">
			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://www.auditool.org/images/images/Fotolia_51023502_S.jpg)">
						<div class="inner">
							<p>Modelo de Madurez e Indicadores</p>
						</div>
					</div>
					<div class="back">
						<div class="inner">
							
							<asp:Button ID="Button1" runat="server" CssClass="botontransp" Text="Pantalla General e Indicadores" OnClick="Button1_Click" />
						</div>
					</div>
				</div>
			</div>
      	<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://c1.wallpaperflare.com/preview/1016/316/1009/computer-business-office-technology.jpg)">
						<div class="inner">
							
							<p>Revisión de Evidencias y Comunicación</p>
								
						</div>
					</div>
					<div class="back">
						<div class="inner">
							<a href="Muestra.aspx" style="color:white; text-decoration:none;">
						   <p>Revisión por fecha de cierre, Evidencias cumplidas y observaciones.</p>
							</a>
                        </div>
					</div>
				</div>
			</div>
		</div>
			 </form>
 </body>
</html>
