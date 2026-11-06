using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace c_examen_2.Pages;

public class Ejercicio10Model : PageModel
{
    [BindProperty]
    public string? EntradaA { get; set; }

    [BindProperty]
    public string? EntradaB { get; set; }

    public double[] A { get; set; } = Array.Empty<double>();
    public double[] B { get; set; } = Array.Empty<double>();
    public double[] C { get; set; } = Array.Empty<double>();
    public bool Mostrar { get; set; }
    public string? Error { get; set; }

    private void Calcular()
    {
        if (string.IsNullOrWhiteSpace(EntradaA))
        {
            A = Vectores.GenerarDobles(20, 1, 10);
        }
        else if (!Vectores.TryParseDobles(EntradaA, 20, out var valoresA, out var errorA))
        {
            Error = $"Vector A: {errorA}";
            return;
        }
        else
        {
            A = valoresA;
        }

        if (string.IsNullOrWhiteSpace(EntradaB))
        {
            B = Vectores.GenerarDobles(20, 1, 10);
        }
        else if (!Vectores.TryParseDobles(EntradaB, 20, out var valoresB, out var errorB))
        {
            Error = $"Vector B: {errorB}";
            return;
        }
        else
        {
            B = valoresB;
        }

        C = new double[20];
        for (int i = 0; i < C.Length; i++)
        {
            C[i] = A[i] * B[B.Length - 1 - i];
        }

        Mostrar = true;
    }

    public void OnPostCalcular()
    {
        Calcular();
    }

    public void OnPostGenerar()
    {
        A = Vectores.GenerarDobles(20, 1, 10);
        B = Vectores.GenerarDobles(20, 1, 10);
        EntradaA = string.Join(" ", A);
        EntradaB = string.Join(" ", B);
        Calcular();
    }
}
