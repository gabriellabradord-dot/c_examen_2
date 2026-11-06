using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MyApp.Namespace
{
    public class suma_matriz_inputModel : PageModel
    {
        [BindProperty]
        public int[][] numeros { get; set; } = new int[2][]
        {
            new int[3],
            new int[3]
        };

        public List<string> operacionesPorFila { get; set; } = new List<string>();
        public bool datosEnviados { get; set; }

        public void OnPost()
        {
            datosEnviados = true;

            for (int i = 0; i < numeros.Length; i++)
            {
                int sumaFila = 0;
                string expresion = "";

                for (int j = 0; j < numeros[i].Length; j++)
                {
                    sumaFila += numeros[i][j];

                    if (j > 0)
                    {
                        expresion += " + ";
                    }
                    expresion += numeros[i][j];
                }

                expresion += $" = {sumaFila}";
                operacionesPorFila.Add(expresion);
            }
        }
    }
}
