using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace c_examen_2.Pages;

public class Ejercicio05Model : PageModel
{
    [BindProperty]
    public string? Entrada { get; set; }

    public int[] Vector { get; set; } = Array.Empty<int>();
    public int Ceros { get; set; }
    public int Negativos { get; set; }
    public int Positivos { get; set; }
    public long SumaNegativos { get; set; }
    public long SumaPositivos { get; set; }
    public bool Mostrar { get; set; }
    public string? Error { get; set; }

    public void OnPostCalcular()
    {
        if (string.IsNullOrWhiteSpace(Entrada))
        {
            Vector = Vectores.GenerarInts(300, -100, 100);
        }
        else if (!Vectores.TryParseInts(Entrada, 300, out var valores, out var error))
        {
            Error = error;
            return;
        }
        else
        {
            Vector = valores;
        }

        Ceros = 0;
        Negativos = 0;
        Positivos = 0;
        SumaNegativos = 0;
        SumaPositivos = 0;

        foreach (int valor in Vector)
        {
            if (valor == 0)
            {
                Ceros++;
            }
            else if (valor < 0)
            {
                Negativos++;
                SumaNegativos += valor;
            }
            else
            {
                Positivos++;
                SumaPositivos += valor;
            }
        }

        Mostrar = true;
    }

    public void OnPostGenerar()
    {
        Vector = Vectores.GenerarInts(300, -100, 100);
        Entrada = string.Join(" ", Vector);
        OnPostCalcular();
    }
}
