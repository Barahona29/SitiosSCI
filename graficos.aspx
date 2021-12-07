<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="graficos.aspx.cs" Inherits="proyecto2APSW.graficos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/grafico.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.min.js"></script>
   <title>Graficos</title>
 </head>
 <body style="max-width:1280px">
 <style>
     
     .contraste2
     {
        text-align: center;
        position: absolute;
        content: "";
        top: 0;
        left: 0;
        height: 140%;
        width: 100%;
        background: rgba(0,0,0,0.8);
        color: #ccc;
         

    }

     .fondoblanco 
     {
         background-color:white;
         width:50%;
     }

    

     .central2 
     {
         left:25%;
        position:relative;
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
           <a href="/ ">Servicios</a>
           <!-- DROPDOWN MENU -->
           <ul class="dropdown">
             <li><a href="/">Dropdown 1 </a></li>
             <li><a href="/">Dropdown 2</a></li>
             <li><a href="/">Dropdown 2</a></li>
             <li><a href="/">Dropdown 3</a></li>
             <li><a href="/">Dropdown 4</a></li>
           </ul>
         </li>
         <li><a href="login2.aspx">Cerrar Sesion</a></li>
         <li><a href="contactenos.html">Contactenos</a></li>
       </div>
     </ul>
   </nav>


 <div class="fondo" style="max-width:1280px">
      <div class="contraste" style="max-width:1280px">
         <div class="central2" style="max-width:1280px">
      <canvas id="myChart" style="width:100%;max-width:600px"></canvas>
  </div>
  </div>
 </div>
    
 <div class="fondo" style="max-width:1280px">
      <div class="contraste2" style="max-width:1280px">
         <div class="central2" style="max-width:1280px">
             <div class="fondoblanco" style="max-width:1280px">
         <canvas id="myChart2" style="width:100%;max-width:600px""></canvas>
             </div>
  </div>
  </div>
  </div>
     
<script>
    const valores = window.location.search;
    const datos = valores.split(';');

    var xValues = ["Seguimiento del SCI", "Sistemas de Informacion", "Actividades de Control", "Valoracion del Riesgo", "Ambiente de Control"," "];
    var yValues = [datos[1], datos[2], datos[3], datos[4], datos[5],10];
var barColors = ["red", "green","blue","orange","brown"];

new Chart("myChart", {
  type: "bar",
  data: {
    labels: xValues,
    datasets: [{
      backgroundColor: barColors,
      data: yValues
    }]
  },
  options: {
    legend: {display: false},
    title: {
      display: true,
      text: "Puntajes por componentes del Sistema de Control Interno"
    }
  }
});



</script>

<script>
    const valoress = window.location.search;
    const datoss = valoress.split(';');
    var data = {
        datasets: [{
            data: [datoss[1], datoss[2], datoss[3], datoss[4], datoss[5], 0],
            backgroundColor: [
                "#FF6384",
                "#4BC0C0",
                "#FFCE56",
                "#E7E9ED",
                "#36A2EB",
                "#FFFFFF"
            ],
            label: 'My dataset' // for legend
        }],
        labels: ["Seguimiento del SCI", "Sistemas de Informacion", "Actividades de Control", "Valoracion del Riesgo", "Ambiente de Control", " "]
    };
    const ctx = document.getElementById('myChart2').getContext('2d');
    new Chart(ctx, {
        data: data,
        type: 'polarArea'
    });
</script>

 </body>
</html> 
