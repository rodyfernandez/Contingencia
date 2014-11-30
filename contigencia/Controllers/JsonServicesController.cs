using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using contigencia.Models;
namespace contigencia.Controllers
{
    public class JsonServicesController : Controller
    {

        private ContingenciaEntities db = new ContingenciaEntities();
        //
        // GET: /JsonServices/
        [HttpPost]
        public JsonResult GetData(int id)
        {
            return Json( new {Nombre = "Juan", Apellido= "Juiz"});
        }

        [HttpPost]
        public JsonResult GetInstrucciones(int id)
        {


            var list = db.Instrucciones;
            return Json(list , JsonRequestBehavior.AllowGet);
        }

// en la view 
// <script>
//       //When DOM loaded we attach click event to button
//       $(document).ready(function() {
            
//           //after button is clicked we download the data
//           $('#mybutton').click(function(){

//               //start ajax request
//               $.ajax({
//                   url: "/JsonServices/GetData",
//                   type: "POST",
//                   contentType: "application/json;charset=utf-8",
//                   //force to handle it as text
//                   dataType: "json",
//                   data: "{}",
//                   success: function(data) {
                        
//                       //data downloaded so we call parseJSON function 
//                       //and pass downloaded data
//                       alert(data);
//                       var json = $.parseJSON(data);
//                       //now json variable contains data in json format
//                       //let's display a few items
//                       $('#results').html('Nombre ' + json.Nombre + '<br />Apellido: ' + json.Apellido);
//                   }
//               });
//           });
//       });
//    </script>

//@*<script class="brush: javascript" type="syntaxhighlighter">
//    function getMyObject(onSuccess) {
//    $.ajax({
//    type: "POST",
//    contentType: "application/json;charset=utf-8",
//    url: "/JsonService/MyJsonMethod",
//    data: "{}",
//    dataType: "json",
//    success: onSuccess
//    });
//    }
//</script>*@

//<input type="button" name="mybutton" id="mybutton" value="Get and parse JSON" class="button" />
//<br />
//<span id="results"></span>


	}
}