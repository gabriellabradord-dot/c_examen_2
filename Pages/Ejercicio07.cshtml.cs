using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace c_examen_2.Pages;

public class Ejercicio07Model : PageModel
{
    [BindProperty]
    public string? EntradaM { get; set; }

    [BindProperty]
    public string? EntradaN { get; set; }

    public bool Iguales { get; set; }
    public string Mensaje { get; set; } = string.Empty;
    public int PrimeraDiferencia { get; set; }
    public string? ValorM { get; set; }
    public string? ValorN { get; set; }
    public bool Mostrar { get; set; }
    public string? Error { get; set; }

    private void Comparar(double[] vectorM, double[] vectorN)
    {
        PrimeraDiferencia = 0;
        ValorM = null;
        ValorN = null;

        if (vectorM.Length != vectorN.Length)
        {
            Iguales = false;
            Mensaje = "Diferentes";
        }
        else
        {
            Iguales = true;
            for (int i = 0; i < vectorM.Length; i++)
            {
                if (vectorM[i] != vectorN[i])
                {
                    Iguales = false;
                    PrimeraDiferencia = i + 1;
                    ValorM = vectorM[i].ToString();
                    ValorN = vectorN[i].ToString();
                    break;
                }
            }

            Mensaje = Iguales ? "Iguales" : "Diferentes";
        }

        Mostrar = true;
    }

    public void OnPostCalcular()
    {
        double[] vectorM;
        if (string.IsNullOrWhiteSpace(EntradaM))
        {
            vectorM = Vectores.GenerarDobles(100, 1, 100);
        }
        else if (!Vectores.TryParseDobles(EntradaM, 100, out vectorM, out var errorM))
        {
            Error = $"Vector M: {errorM}";
            return;
        }

        double[] vectorN;
        if (string.IsNullOrWhiteSpace(EntradaN))
        {
            vectorN = (double[])vectorM.Clone();
        }
        else if (!Vectores.TryParseDobles(EntradaN, 100, out vectorN, out var errorN))
        {
            Error = $"Vector N: {errorN}";
            return;
        }

        Comparar(vectorM, vectorN);
    }

    public void OnPostGenerarIguales()
    {
        double[] vectorM = Vectores.GenerarDobles(100, 1, 100);
        double[] vectorN = (double[])vectorM.Clone();

        EntradaM = string.Join(" ", vectorM);
        EntradaN = string.Join(" ", vectorN);
        Comparar(vectorM, vectorN);
    }

    public void OnPostGenerarDiferentes()
    {
        double[] vectorM = Vectores.GenerarDobles(100, 1, 100);
        double[] vectorN = (double[])vectorM.Clone();
        vectorN[0] = vectorM[0] == 100 ? 99 : vectorM[0] + 1;

        EntradaM = string.Join(" ", vectorM);
        EntradaN = string.Join(" ", vectorN);
        Comparar(vectorM, vectorN);
    }
}
