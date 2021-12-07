<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modelomadurez.aspx.cs" Inherits="proyecto2APSW.modelomadurez" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	 <link rel="stylesheet" href="css/pagina7.css" />
	      <script src="https://kit.fontawesome.com/a076d05399.js"></script>
       <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/waypoints/4.0.1/jquery.waypoints.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Counter-Up/1.0.0/jquery.counterup.min.js"></script>
    <title>Modelo de madurez</title>
</head>
 <body>
	 <style>
	  .botontransp {
       background-color: transparent;
	  border: none;
    outline:none;
	color:white;
	width:70%;
	height:70%;
	font-size:12px;

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
         <li><a href="index.html">Inicio</a></li>
         <li><a href="contactenos.html">Contactenos</a></li>
         <li><a href="login2.aspx">Login</a></li>
       </div>
     </ul>
   </nav>


            <div class="wrapper">
  <h1> Modelo de Madurez</h1>
				
     
				<div style="text-align:center;">
					<div id="counterup" class="counter-up">
    <div id="content" class="content">
				<div class="box" >
        <div class="icon"><i id="icon1" class="fa fa-file-alt"></i></div>
        <div id="cont1" class="counter"><asp:Label ID="lblpuntaje1" runat="server" Text=""></asp:Label></div>
        <div class="text">
            <asp:Label ID="lblpuntaje1texto" runat="server" Text=""></asp:Label></div>
      </div>

					&nbsp&nbsp&nbsp&nbsp&nbsp
					<div class="box" >
        <div class="icon"><i id="icon2" class="fa fa-check-square"></i></div>
        <div id="cont2" class="counter"><asp:Label ID="lblpuntaje2" runat="server" Text=""></asp:Label></div>
        <div class="text"><asp:Label ID="lblpuntaje2texto" runat="server" Text=""></asp:Label></div>
      </div>
					&nbsp&nbsp&nbsp&nbsp&nbsp
					<div class="box" >
        <div class="icon"><i id="icon3" class="fa fa-times-circle"></i></div>
        <div id="cont3" class="counter"><asp:Label ID="lblpuntaje3" runat="server" Text=""></asp:Label></div>
        <div class="text"><asp:Label ID="lblpuntaje3texto" runat="server" Text=""></asp:Label></div>
      </div>
					</div>
					</div>
		 </div>
				
  <div class="cols">
	  
			<div class="col"  ontouchstart="this.classList.toggle('hover');">
				<div  class="container">
					<div class="front" style="background-image: url(https://mejialora.com/wp-content/uploads/2020/07/Ambiente-de-control.jpg)">
						<div class="inner">
							<p>Ambiente de Control</p>
						</div>
					</div>
					
					<div id="ambcontrol" class="back">
						
						<div class="inner">
							<a href="ambientecontrol.aspx" id="ahref"   style="text-decoration:none; color:white;">
						  <p>El modelo de madurez contempla los siguientes cuatro atributos en relación con el ambiente de control: 
						  <br>
						  <br>Compromiso
						  <br>Ética
						  <br>Personal 
						  <br>Estructura</p>
								</a>
						</div>
							
					</div>
						
				</div>
			</div>
            			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://www.compliance-antisoborno.com/wp-content/uploads/2020/02/Recomendaciones-para-mejorar-la-gestion-de-riesgos-a-terceros.jpg)">
						<div class="inner">
							<p>Valoración de Riesgos</p>
						</div>
					</div>
					<div class="back">
						<div class="inner">
								<a href="valoracionriesgos.aspx" id="ahref2"   style="text-decoration:none; color:white;">
						  
								<p>El modelo de madurez contempla los siguientes cuatro atributos en relación con la valoración del riesgo: 
								<br>
								<br>Marco orientador
								<br>Herramienta para la administración de la información
								<br>Funcionamiento del SEVRI
								<br>Documentación y comunicación</p>

								</a>
						</div>
					</div>
				</div>
			</div>

	
			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://www.auditool.org/images/images/Fotolia_51023502_S.jpg)">
						
						<div class="inner">
							  
							<p>Actividades de Control</p>
						</div>
							
					</div>
					
					<div class="back">
						
						<div class="inner">
								<a href="actividadescontrol.aspx" id="ahref3"   style="text-decoration:none; color:white;">
						  
						El modelo de madurez contempla los siguientes atributos respecto de las actividades de control:
							<br> 
							<br>Características
							<br>Alcance
							<br>Formalidad 
							<br>Aplicación</p>

									</a>
						</div>
							
					</div>
						
				</div>
			</div>
		  
			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://wallpaperaccess.com/full/7061626.jpg)">
						<div class="inner">
							<p>Sistema de Información</p>
						</div>
					</div>
					<div class="back">
						<div class="inner">
								<a href="sistemainfo.aspx" id="ahref4"   style="text-decoration:none; color:white;">
						  
							<p>El modelo de madurez contempla los siguientes cuatro atributos en relación con los sistemas de información:
								<br>
								<br>Alcance de los sistemas de información
								<br>Calidad de la información
								<br>Calidad de la comunicación
								<br>Control de los sistemas de información</p>

									</a>
						</div>
					</div>
				</div>
			</div>
			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(http://www.aemes.biz/wp-content/uploads/2018/02/sistema-MES-para-f%C3%A1bricas-de-piensos-y-harinas-1024x683.jpg)">
						<div class="inner">
							<p>Seguimiento del Control Interno</p>
						</div>
					</div>
					<div class="back">
						<div class="inner">
								<a href="seguimientoci.aspx" id="ahref5"   style="text-decoration:none; color:white;">
						  
							<p>El modelo de madurez incluye los siguientes cuatro atributos en relación con el seguimiento: 
							<br>
							<br>Participantes
							<br>Formalidad
							<br>Alcance
							<br>Contribución a la mejora del sistema de control interno</p>

									</a>

						</div>
					</div>
				</div>
			</div>
	  </div>
	  <div class="wrapper">
			<h1> Indicadores</h1>
			<div class="cols">
			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://www.camarabaq.org.co/wp-content/uploads/2020/05/20643-scaled.jpg)">
						<div class="inner">
							
							<p>Acciones a realizar por sección</p>

								
						</div>
					</div>
					<div class="back">
						<div class="inner">
							<a href="ambientecontrol.aspx" id="ahref6"   style="text-decoration:none; color:white;">
						  
							<p>Acciones por realizar con base en los resultados obtenidos.</p>

								</a>
						</div>
					</div>
				</div>
			</div>
						<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://us.123rf.com/450wm/3dart/3dart1312/3dart131200129/25587638-abstract-3d-numbers-background.jpg?ver=6)">
						<div class="inner">
							
							<p>Puntajes obtenidos por sección</p>

								
						</div>
					</div>
					<div class="back">
						<div class="inner">
							<a  id="ahref8"  style="text-decoration:none; color:white;">
						  
							<p>Tabla resumen de la encuesta y puntajes obtenidos por la dependencia.</p>

								</a>
						</div>
					</div>
				</div>
			</div>
						<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://objectifqvt.fr/contenus/blog/Vignettes/Statistique-aide-decision.jpg)">
						<div class="inner">
							<p>Gráfico</p>
						</div>
					</div>
					<div class="back">
						<div class="inner">
							
							
                                <asp:Button ID="btnGraficos" CssClass="botontransp" runat="server" Text="Resultado de Gráficos" OnClick="btnGraficos_Click" />
								
					</div>
					</div>
				</div>
			</div>
			</div>
		  </div>
	  <script>

		  const valores = window.location.search;
          const datos = valores.split(';');
         

		  function deshabilitar() {


              if (datos[0] == "?valor=Supervisor") {


				  const variable = document.getElementById("ahref");
				  variable.innerHTML = "No disponible";
				  variable.removeAttribute("href");

				  const variable2 = document.getElementById("ahref2");
				  variable2.innerHTML = "No disponible";
				  variable2.removeAttribute("href");

				  const variable3 = document.getElementById("ahref3");
				  variable3.innerHTML = "No disponible";
				  variable3.removeAttribute("href");

				  const variable4 = document.getElementById("ahref4");
				  variable4.innerHTML = "No disponible";
				  variable4.removeAttribute("href");

				  const variable5 = document.getElementById("ahref5");
				  variable5.innerHTML = "No disponible";
				  variable5.removeAttribute("href");

				  const variable8 = document.getElementById("ahref8");
                  variable8.setAttribute('href', 'puntajecompleto.aspx?valores=' + datos[1] + ';' + datos[2]);
                
			  }
              else if (datos[0] == "?valor=Encargado")
			  {
                  const variable8 = document.getElementById("ahref8");
                  variable8.setAttribute('href', 'puntajecompleto.aspx?valores=' + datos[1] + ';' + datos[2]);
			  }
			  else {


                      const variable = document.getElementById("ahref");
                      variable.innerHTML = "No disponible";
                      variable.removeAttribute("href");

                      const variable2 = document.getElementById("ahref2");
                      variable2.innerHTML = "No disponible";
                      variable2.removeAttribute("href");

                      const variable3 = document.getElementById("ahref3");
                      variable3.innerHTML = "No disponible";
                      variable3.removeAttribute("href");

                      const variable4 = document.getElementById("ahref4");
                      variable4.innerHTML = "No disponible";
                      variable4.removeAttribute("href");

                      const variable5 = document.getElementById("ahref5");
                      variable5.innerHTML = "No disponible";
				  variable5.removeAttribute("href");

                  const variable6 = document.getElementById("ahref6");
                  variable6.innerHTML = "No disponible";
                  variable6.removeAttribute("href");

				  const variable7 = document.getElementById("icon1");
				  variable7.style.display = 'none';

                  const variable8 = document.getElementById("icon2");
				  variable8.style.display = 'none';

                  const variable9 = document.getElementById("icon3");
				  variable9.style.display = 'none';

                  const variable10 = document.getElementById("cont1");
                  variable10.style.display = 'none'; 

                  const variable11 = document.getElementById("cont2");
				  variable11.style.display = 'none';

                  const variable12 = document.getElementById("cont3");
				  variable12.style.display = 'none';

                  const variable13 = document.getElementById("counterup");
                  variable13.style.display = 'none';

                  const variable14 = document.getElementById("content");
                  variable14.style.display = 'none';
			  }
			  

			  }
		  

		  window.onload = deshabilitar;
			

	  </script>
	  <script>
          $(document).ready(function () {
              $('.counter').counterUp({
                  delay: 10,
                  time: 1200
              });
          });
  </script>
	 </form>	
 </body>
</html>