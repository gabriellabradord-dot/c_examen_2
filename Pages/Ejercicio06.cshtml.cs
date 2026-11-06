using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace c_examen_2.Pages;

public class Ejercicio06Model : PageModel
{
    [BindProperty]
    public string? Entrada { get; set; }

    public int[] Original { get; set; } = Array.Empty<int>();
    public int[] Invertido { get; set; } = Array.Empty<int>();
    public bool Mostrar { get; set; }
    public string? Error { get; set; }

    public void OnPostCalcular()
    {
        if (string.IsNullOrWhiteSpace(Entrada))
        {
            Original = Vectores.GenerarInts(150, 1, 1000);
        }
        else if (!Vectores.TryParseInts(Entrada, 150, out var valores, out var error))
        {
            Error = error;
            return;
        }
        else
        {
            Original = valores;
        }

        Invertido = new int[Original.Length];
        for (int i = 0; i < Original.Length; i++)
        {
            Invertido[i] = Original[Original.Length - 1 - i];
        }

        Mostrar = true;
    }

    public void OnPostGenerar()
    {
        Entrada = string.Join(" ", Vectores.GenerarInts(150, 1, 1000));
        OnPostCalcular();
    }
}
