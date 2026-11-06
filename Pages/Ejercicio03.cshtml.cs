using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace c_examen_2.Pages;
public class Ejercicio03Model : PageModel
{
    [BindProperty] public string? Entrada { get; set; }
    public double[] Vector { get; set; } = Array.Empty<double>();
    public double Mayor { get; set; }
    public int Indice { get; set; }
    public int Posicion { get; set; }
    public bool Mostrar { get; set; }
    public string? Error { get; set; }
    private void Calcular()
    {
        if (string.IsNullOrWhiteSpace(Entrada)) Vector = Vectores.GenerarDobles(20, 1, 200);
        else if (!Vectores.TryParseDobles(Entrada, 20, out var valores, out var error)) { Error = error; return; }
        else Vector = valores;

        Indice = 0; Mayor = Vector[0];
        for (int i = 1; i < Vector.Length; i++) if (Vector[i] > Mayor) { Mayor = Vector[i]; Indice = i; }
        Posicion = Indice + 1; Mostrar = true;
    }
    public void OnPostCalcular() => Calcular();
    public void OnPostGenerar() { Vector = Vectores.GenerarDobles(20, 1, 200); Entrada = string.Join(" ", Vector); Calcular(); }
}
