using Microsoft.AspNetCore.Mvc;
using nominas_apap_apec.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nominas_apap_apec.Controllers
{
    public class HomeController : Controller
    {
        static IList<DatosNomina> datosNominas = new List<DatosNomina>
        {
            new DatosNomina(){id=1,cedula="40200000001",nombre="Manolo Abc",cuenta="1234567891234567",codigo_moneda="DOP", sueldo=30000},
            new DatosNomina(){id=2,cedula="40200000002",nombre="Moises Manuel",cuenta="9876543219876543",codigo_moneda="DOP", sueldo=40000},
            new DatosNomina(){id=3,cedula="40200000003",nombre="Empleado Cualquiera",cuenta="9876543211234567",codigo_moneda="DOP", sueldo=50000},
        };

        public IActionResult Index()
        {


            return View();
        }

        //apec

            public void push(DateTime fechaEnvio, DateTime fechaDeposito)
            {
                
                try
                {
                    //Open the File
                    StreamWriter sw = new StreamWriter("C:\\Test1.txt", true, Encoding.ASCII);

                    //Escribir encabezado
                    sw.WriteLine("N  401005107{0}{1}", fechaEnvio.ToShortDateString(), fechaDeposito.ToShortDateString());

                    //Escribir detalle
                    foreach (DatosNomina d in datosNominas)
                    {
                        //asegurarse del tamaño de los nombres
                        string nombre = d.nombre;
                        while (nombre.Length < 50) nombre += " ";
                        //escribir el registro
                        sw.WriteLine("E{0}{1}{2}{3}{4}", d.cedula, nombre, d.cuenta, d.codigo_moneda, d.sueldo);
                    }

                    //Escribir sumario
                    sw.WriteLine("S{0}", datosNominas.Count);

                    //close the file
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }


        

        //apap
        public void pull() {
            DatosNomina datos = new DatosNomina();

        }

        public IActionResult APAP()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
