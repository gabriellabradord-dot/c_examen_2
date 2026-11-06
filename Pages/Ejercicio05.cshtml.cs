using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
namespace c_examen_2.Pages;
public class Ejercicio05Model : PageModel
{
    [BindProperty] public string? Entrada { get; set; }
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
        if (string.IsNullOrWhiteSpace(Entrada)) Vector = Vectores.GenerarInts(300, -100, 100);
        else if (!Vectores.TryParseInts(Entrada, 300, out var valores, out var error)) { Error = error; return; }
        else Vector = valores;

        Ceros = Vector.Count(x => x == 0);
        Negativos = Vector.Count(x => x < 0);
        Positivos = Vector.Count(x => x > 0);
        SumaNegativos = Vector.Where(x => x < 0).Sum(x => (long)x);
        SumaPositivos = Vector.Where(x => x > 0).Sum(x => (long)x);
        Mostrar = true;
    }

    public void OnPostGenerar()
    {
        Entrada = string.Join(" ", Vectores.GenerarInts(300, -100, 100));
        OnPostCalcular();
    }
}
