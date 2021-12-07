<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ambientecontrol.aspx.cs" Inherits="proyecto2APSW.ambientecontrol" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
		 <link rel="stylesheet" href="css/pagina7.css" />
    <title></title>
</head>
  <body>
	   <style>
	  .botontransp 
	  {
       background-color: transparent;
	  border: none;
    outline:none;
	color:white;
	width:70%;
	height:70%;
	font-size:12px;
      }
	 </style>
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
         <li class="services">
           <a href="/ ">Services</a>
           <!-- DROPDOWN MENU -->
           <ul class="dropdown">
             <li><a href="/">Dropdown 1 </a></li>
             <li><a href="/">Dropdown 2</a></li>
             <li><a href="/">Dropdown 2</a></li>
             <li><a href="/">Dropdown 3</a></li>
             <li><a href="/">Dropdown 4</a></li>
           </ul>
         </li>
         <li><a href="login2.aspx">Cerrar Sesión</a></li>
         <li><a href="contactenos.html">Contactenos</a></li>
       </div>
     </ul>
   </nav>

	  <br />
	 <br />
	 <br />

            <div class="wrapper">
  <h1>Ambiente de control</h1>
  <div class="cols">
			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://cdn-3.expansion.mx/dims4/default/b81e305/2147483647/strip/true/crop/1254x837+0+0/resize/1800x1201!/format/webp/quality/90/?url=https%3A%2F%2Fcdn-3.expansion.mx%2F7e%2Fb9%2Fd6740f3344c8b4c6d6bf710deb40%2Foficina.jpg)">
						<div class="inner">
							<p>Compromiso</p>
						</div>
					</div>
					<div class="back">
						<div class="inner">
							<a href="compromiso.aspx" style="text-decoration:none; color:white;">
						  <p>El jerarca y los titulares subordinados deben apoyar constantemente el 
							  sistema de control interno y demostrar su compromiso 
							  con el diseño, la implantación, el fortalecimiento y la evaluación del sistema.</p>
								</a>
						</div>
					</div>
				</div>
			</div>
            			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://i2.wp.com/www.revistanuve.com/wp-content/uploads/2020/08/Oficina.jpg2_.jpg)">
						<div class="inner">
							<p>Ética</p>
						</div>
					</div>
					<div class="back">
						<div class="inner">
							<a href="etica.aspx" style="text-decoration:none; color:white;">
								<p>La ética en el desempeño institucional como parte del ambiente de control, debe fortalecerse mediante la implantación y fortalecimiento de medidas,  instrumentos y demás elementos en materia ética, lo cual debe integrarse en los sistemas de gestión.</p>
						</a>
								</div>
					</div>
				</div>
			</div>
			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(http://www.solucionespm.com/wp-content/uploads/2018/04/Oficina.jpg)">
						<div class="inner">
							<p>Personal</p>
						</div>
					</div>
					<div class="back">
						<div class="inner">
							<a href="personal.aspx" style="text-decoration:none; color:white;">
							<p>El funcionamiento éxitoso del sistema de control interno requiere que el personal de la institución reúna las competencias y los valores requeridos para el desempeño de los puestos y la operación de las actividades de control correspondientes a los diversos puestos.</p>
						</a>
								</div>
					</div>
				</div>
			</div>
			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://www.esan.edu.pe/conexion/actualidad/2019/09/09/1500x844_oficinas_satelites.jpg)">
						<div class="inner">
							<p>Estructura</p>
						</div>
					</div>
					<div class="back">
						<div class="inner">
							<a href="Estructura.aspx" style="text-decoration:none; color:white;">
							<p>La estructura orgánica debe propiciar el logro de los objetivos institucionales, y en consecuencia, apoyar el sistema de control interno, mediante la definición de la organización formal, sus relaciones jerárquicas, líneas de dependencia y coordinación; asimismo, debe ajustarse según lo requieran la dinámica institucional, del entorno y de los riesgos relevantes.</p>
						</a>
								</div>
					</div>
				</div>
			</div>
		

			
	
 </body>
</html>