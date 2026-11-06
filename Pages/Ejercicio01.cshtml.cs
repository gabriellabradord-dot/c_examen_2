using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace c_examen_2.Pages;

public class Ejercicio01Model : PageModel
{
    [BindProperty] public string? Entrada { get; set; }
    public double[] Vector { get; set; } = Array.Empty<double>();
    public double Promedio { get; set; }
    public double[] Resultado { get; set; } = Array.Empty<double>();
    public int CantidadMayores { get; set; }
    public bool Mostrar { get; set; }
    public string? Error { get; set; }

    public void OnPostCalcular()
    {
        if (string.IsNullOrWhiteSpace(Entrada))
            Vector = Vectores.GenerarDobles(50, 1, 100);
        else if (!Vectores.TryParseDobles(Entrada, 50, out var valores, out var error))
        {
            Error = error;
            return;
        }
        else
            Vector = valores;

        Promedio = Vector.Sum(valor => valor / Vector.Length);
        Resultado = Vector.Where(x => x > Promedio).ToArray();
        CantidadMayores = Resultado.Length;
        Mostrar = true;
    }
    public void OnPostGenerar()
    {
        Vector = Vectores.GenerarDobles(50, 1, 100);
        Entrada = string.Join(" ", Vector);
        Promedio = Vector.Average();
        Resultado = Vector.Where(x => x > Promedio).ToArray();
        CantidadMayores = Resultado.Length;
        Entrada = string.Join(" ", Vector);
        Mostrar = true;
    }
}
