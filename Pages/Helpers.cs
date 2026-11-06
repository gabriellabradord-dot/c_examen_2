using System.Globalization;

namespace c_examen_2.Pages;

public static class Vectores
{
    private static readonly char[] Separadores = [' ', ',', ';', '\t', '\n', '\r'];

    public static bool TryParseDobles(string? texto, int cantidad, out double[] valores, out string error)
    {
        valores = Array.Empty<double>();
        error = string.Empty;
        string[] partes = Separar(texto);
        double[] resultado = new double[partes.Length];

        for (var i = 0; i < partes.Length; i++)
        {
            bool esNumeroValido = double.TryParse(
                partes[i],
                NumberStyles.Float,
                CultureInfo.CurrentCulture,
                out resultado[i]);

            if (!esNumeroValido)
            {
                esNumeroValido = double.TryParse(
                    partes[i],
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out resultado[i]);
            }

            if (!esNumeroValido)
            {
                error = $"«{partes[i]}» no es un número válido.";
                return false;
            }

            if (!double.IsFinite(resultado[i]))
            {
                error = "Los valores deben ser números finitos.";
                return false;
            }
        }

        if (resultado.Length != cantidad)
        {
            error = $"Se esperaban {cantidad} valores y se recibieron {resultado.Length}.";
            return false;
        }

        valores = resultado;
        return true;
    }

    public static bool TryParseInts(string? texto, int cantidad, out int[] valores, out string error)
    {
        valores = Array.Empty<int>();
        error = string.Empty;
        string[] partes = Separar(texto);
        int[] resultado = new int[partes.Length];

        for (var i = 0; i < partes.Length; i++)
        {
            bool esNumeroValido = int.TryParse(
                partes[i],
                NumberStyles.Integer,
                CultureInfo.CurrentCulture,
                out resultado[i]);

            if (!esNumeroValido)
            {
                esNumeroValido = int.TryParse(
                    partes[i],
                    NumberStyles.Integer,
                    CultureInfo.InvariantCulture,
                    out resultado[i]);
            }

            if (!esNumeroValido)
            {
                error = $"«{partes[i]}» no es un número entero válido.";
                return false;
            }
        }

        if (resultado.Length != cantidad)
        {
            error = $"Se esperaban {cantidad} valores y se recibieron {resultado.Length}.";
            return false;
        }

        valores = resultado;
        return true;
    }

    public static bool TryParseLongs(string? texto, int cantidad, out long[] valores, out string error)
    {
        valores = Array.Empty<long>();
        error = string.Empty;
        string[] partes = Separar(texto);
        long[] resultado = new long[partes.Length];

        for (var i = 0; i < partes.Length; i++)
        {
            bool esNumeroValido = long.TryParse(
                partes[i],
                NumberStyles.Integer,
                CultureInfo.CurrentCulture,
                out resultado[i]);

            if (!esNumeroValido)
            {
                esNumeroValido = long.TryParse(
                    partes[i],
                    NumberStyles.Integer,
                    CultureInfo.InvariantCulture,
                    out resultado[i]);
            }

            if (!esNumeroValido)
            {
                error = $"«{partes[i]}» no es un número entero válido.";
                return false;
            }
        }

        if (resultado.Length != cantidad)
        {
            error = $"Se esperaban {cantidad} valores y se recibieron {resultado.Length}.";
            return false;
        }

        valores = resultado;
        return true;
    }

    private static string[] Separar(string? texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
        {
            return Array.Empty<string>();
        }

        return texto.Split(
            Separadores,
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    }

    public static double[] GenerarDobles(int n, int min = 1, int max = 100)
    {
        double[] valores = new double[n];

        for (int i = 0; i < n; i++)
        {
            valores[i] = Random.Shared.Next(min, max + 1);
        }

        return valores;
    }

    public static int[] GenerarInts(int n, int min = -50, int max = 100)
    {
        int[] valores = new int[n];

        for (int i = 0; i < n; i++)
        {
            valores[i] = Random.Shared.Next(min, max + 1);
        }

        return valores;
    }

    public static long[] GenerarLongs(int n, int min = 1, int max = 100)
    {
        long[] valores = new long[n];

        for (int i = 0; i < n; i++)
        {
            valores[i] = Random.Shared.Next(min, max + 1);
        }

        return valores;
    }
}
