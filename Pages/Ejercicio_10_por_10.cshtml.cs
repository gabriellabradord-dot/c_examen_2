using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace c_examen_2.Pages;

public class Ejercicio_10_por_10Model : PageModel
{
    [BindProperty]
    public string? Entrada { get; set; }

    public int[,] Matriz { get; set; } = new int[10, 10];
    public int Mayor { get; set; }
    public int FilaMayor { get; set; }
    public int ColumnaMayor { get; set; }
    public bool Mostrar { get; set; }
    public string? Error { get; set; }

    private void Calcular()
    {
        if (string.IsNullOrWhiteSpace(Entrada))
        {
            Matriz = GenerarMatrizPrueba();
        }
        else if (!Vectores.TryParseInts(Entrada, 100, out var valores, out var error))
        {
            Error = error;
            return;
        }
        else
        {
            Matriz = new int[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Matriz[i, j] = valores[i * 10 + j];
                }
            }
        }

        Mayor = Matriz[0, 0];
        FilaMayor = 0;
        ColumnaMayor = 0;

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (Matriz[i, j] > Mayor)
                {
                    Mayor = Matriz[i, j];
                    FilaMayor = i;
                    ColumnaMayor = j;
                }
            }
        }

        Mostrar = true;
    }

    public void OnPostCalcular()
    {
        Calcular();
    }

    public void OnPostGenerar()
    {
        Matriz = GenerarMatrizPrueba();
        Entrada = ConvertirMatrizAString(Matriz);
        Calcular();
    }

    public static int[,] GenerarMatrizPrueba()
    {
        var matriz = new int[10, 10];
        var usados = new HashSet<int>();
        var indice = 0;

        while (usados.Count < 100)
        {
            var numero = Random.Shared.Next(1, 1000);

            if (usados.Add(numero))
            {
                var fila = indice / 10;
                var columna = indice % 10;
                matriz[fila, columna] = numero;
                indice++;
            }
        }

        return matriz;
    }

    private static string ConvertirMatrizAString(int[,] matriz)
    {
        var valores = new List<string>();

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                valores.Add(matriz[i, j].ToString());
            }
        }

        return string.Join(" ", valores);
    }
}
