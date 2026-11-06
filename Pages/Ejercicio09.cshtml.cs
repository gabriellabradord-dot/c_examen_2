using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace c_examen_2.Pages;
public class Ejercicio09Model : PageModel
{
    [BindProperty] public string? Entrada { get; set; }
    [BindProperty] public double? Buscado { get; set; }
    public double[] Vector { get; set; } = Array.Empty<double>();
    public bool Encontrado { get; set; }
    public int Indice { get; set; } = -1;
    public int Posicion { get; set; }
    public bool Mostrar { get; set; }
    public string? Error { get; set; }
    private void Buscar()
    {
        Encontrado = false;
        Indice = -1;
        Posicion = 0;
        for (int i = 0; i < Vector.Length; i++) if (Vector[i] == Buscado) { Encontrado = true; Indice = i; Posicion = i + 1; break; }
        Mostrar = true;
    }
    public void OnPostBuscar()
    {
        if (Buscado is null) { Error = "Escribe el número que quieres buscar."; return; }
        if (string.IsNullOrWhiteSpace(Entrada)) Vector = Vectores.GenerarDobles(80, 1, 100);
        else if (!Vectores.TryParseDobles(Entrada, 80, out var valores, out var error)) { Error = error; return; }
        else Vector = valores;
        Buscar();
    }
    public void OnPostGenerar() { Vector = Vectores.GenerarDobles(80, 1, 100); Entrada = string.Join(" ", Vector); Buscado = Vector[37]; Buscar(); }
}
