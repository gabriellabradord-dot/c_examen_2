using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace c_examen_2.Pages;

public class Ejercicio08Model : PageModel
{
    [BindProperty]
    public string? Entrada { get; set; }

    public double[] Vector { get; set; } = Array.Empty<double>();
    public bool Ordenado { get; set; }
    public string Mensaje { get; set; } = string.Empty;
    public bool Mostrar { get; set; }
    public string? Error { get; set; }

    private void Verificar()
    {
        Ordenado = true;
        for (int i = 1; i < Vector.Length; i++)
        {
            if (Vector[i] < Vector[i - 1])
            {
                Ordenado = false;
                break;
            }
        }

        Mensaje = Ordenado ? "SI" : "NO";
        Mostrar = true;
    }

    public void OnPostCalcular()
    {
        if (string.IsNullOrWhiteSpace(Entrada))
        {
            Vector = Vectores.GenerarDobles(100, 1, 100);
        }
        else if (!Vectores.TryParseDobles(Entrada, 100, out var valores, out var error))
        {
            Error = error;
            return;
        }
        else
        {
            Vector = valores;
        }

        Verificar();
    }

    public void OnPostGenerarSi()
    {
        Vector = Vectores.GenerarDobles(100, 1, 100);
        Array.Sort(Vector);
        Entrada = string.Join(" ", Vector);
        Verificar();
    }

    public void OnPostGenerarNo()
    {
        Vector = Vectores.GenerarDobles(100, 1, 100);
        Vector[0] = 100;
        Vector[1] = 1;
        Entrada = string.Join(" ", Vector);
        Verificar();
    }
}
