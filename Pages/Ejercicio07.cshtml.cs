using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace c_examen_2.Pages;
public class Ejercicio07Model : PageModel
{
    [BindProperty] public string? EntradaM { get; set; }
    [BindProperty] public string? EntradaN { get; set; }
    public bool Iguales { get; set; }
    public string Mensaje { get; set; } = "";
    public int PrimeraDiferencia { get; set; }
    public string? ValorM { get; set; }
    public string? ValorN { get; set; }
    public bool Mostrar { get; set; }
    public string? Error { get; set; }
    private void Comparar(double[] M, double[] N)
    {
        PrimeraDiferencia = 0;
        ValorM = null;
        ValorN = null;
        if (M.Length != N.Length) { Iguales = false; Mensaje = "Diferentes"; }
        else
        {
            Iguales = true;
            for (int i = 0; i < M.Length; i++) if (M[i] != N[i]) { Iguales = false; PrimeraDiferencia = i + 1; ValorM = M[i].ToString(); ValorN = N[i].ToString(); break; }
            Mensaje = Iguales ? "Iguales" : "Diferentes";
        }
        Mostrar = true;
    }
    public void OnPostCalcular()
    {
        double[] M;
        if (string.IsNullOrWhiteSpace(EntradaM)) M = Vectores.GenerarDobles(100, 1, 100);
        else if (!Vectores.TryParseDobles(EntradaM, 100, out M, out var errorM)) { Error = $"Vector M: {errorM}"; return; }

        double[] N;
        if (string.IsNullOrWhiteSpace(EntradaN)) N = (double[])M.Clone();
        else if (!Vectores.TryParseDobles(EntradaN, 100, out N, out var errorN)) { Error = $"Vector N: {errorN}"; return; }

        Comparar(M, N);
    }
    public void OnPostGenerarIguales()
    {
        var M = Vectores.GenerarDobles(100, 1, 100); var N = (double[])M.Clone();
        EntradaM = string.Join(" ", M); EntradaN = string.Join(" ", N); Comparar(M, N);
    }
    public void OnPostGenerarDiferentes()
    {
        var M = Vectores.GenerarDobles(100, 1, 100); var N = (double[])M.Clone();
        N[0] = M[0] == 100 ? 99 : M[0] + 1;
        EntradaM = string.Join(" ", M); EntradaN = string.Join(" ", N); Comparar(M, N);
    }
}
