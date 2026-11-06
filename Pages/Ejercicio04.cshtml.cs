using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Numerics;
namespace c_examen_2.Pages;
public class Ejercicio04Model : PageModel
{
    [Microsoft.AspNetCore.Mvc.BindProperty] public string? Entrada { get; set; }
    public long[] Original { get; set; } = Array.Empty<long>();
    public BigInteger[] Cuadrados { get; set; } = Array.Empty<BigInteger>();
    public bool Mostrar { get; set; }
    public string? Error { get; set; }
    public void OnPostCalcular()
    {
        if (string.IsNullOrWhiteSpace(Entrada)) Original = Vectores.GenerarLongs(500, 1, 100);
        else if (!Vectores.TryParseLongs(Entrada, 500, out var valores, out var error)) { Error = error; return; }
        else Original = valores;

        Cuadrados = new BigInteger[500];
        for (int i = 0; i < 500; i++) Cuadrados[i] = (BigInteger)Original[i] * Original[i];
        Mostrar = true;
    }

    public void OnPostGenerar()
    {
        Entrada = string.Join(" ", Vectores.GenerarLongs(500, 1, 100));
        OnPostCalcular();
    }
}
