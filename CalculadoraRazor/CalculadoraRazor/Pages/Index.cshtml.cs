using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalculadoraRazor.Pages
{
    public class IndexModel : PageModel
    {
        public int? resultado;

        public void OnGet(int numero1, int numero2)
        {
            if (numero1 != 0 || numero2 != 0)
            {
                resultado = numero1 + numero2;
            }

        }

        [HttpPost]
        public ActionResult Total(int valor1, int valor2, string operador)
        {
            int total = 0;
            switch (operador)
            {
                case "Suma":
                    total = valor1 + valor2;
                    break;

                case "Resta":
                    total = valor1 - valor2;
                    break;

                case "Multiplicacion":
                    total = valor1 * valor2;
                    break;

                case "Division":
                    total = valor1 / valor2;
                    break;

                default:
                    total = 0;
                    break;
            }
        }




        public ActionResult OnPost()
        {
            //Obtiene los valores del formulario, segun name
            var n1 = Convert.ToInt32(Request.Form["numero1"]);
            var n2 = Convert.ToInt32(Request.Form["numero2"]);

            //Redirecciona Al GET con los parametros que enviamos
            return Redirect("Index?numero1=" + n1 + "&numero2=" + n2);
        }
    }
}
