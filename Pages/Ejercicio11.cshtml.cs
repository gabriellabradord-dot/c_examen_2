using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Numerics;

namespace c_examen_2.Pages;

public class Ejercicio11Model : PageModel
{
    public BigInteger[] FIB { get; set; } = Array.Empty<BigInteger>();
    public bool Mostrar { get; set; }

    public void OnPostCalcular()
    {
        FIB = new BigInteger[100];
        FIB[0] = 0;
        FIB[1] = 1;

        for (int i = 2; i < FIB.Length; i++)
        {
            FIB[i] = FIB[i - 1] + FIB[i - 2];
        }

        Mostrar = true;
    }
}
