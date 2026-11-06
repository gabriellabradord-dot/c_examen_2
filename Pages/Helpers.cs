namespace c_examen_2.Pages;

public static class Vectores
{
    private static readonly char[] Separadores = [' ', ',', ';', '\t', '\n', '\r'];

    public static bool TryParseDobles(string? texto, int cantidad, out double[] valores, out string error)
    {
        valores = Array.Empty<double>();
        error = string.Empty;
        var partes = Separar(texto);
        var resultado = new double[partes.Length];

        for (var i = 0; i < partes.Length; i++)
        {
            if (!double.TryParse(partes[i], System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.CurrentCulture, out resultado[i]) &&
                !double.TryParse(partes[i], System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture, out resultado[i]))
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
        var partes = Separar(texto);
        var resultado = new int[partes.Length];

        for (var i = 0; i < partes.Length; i++)
        {
            if (!int.TryParse(partes[i], System.Globalization.NumberStyles.Integer,
                    System.Globalization.CultureInfo.CurrentCulture, out resultado[i]) &&
                !int.TryParse(partes[i], System.Globalization.NumberStyles.Integer,
                    System.Globalization.CultureInfo.InvariantCulture, out resultado[i]))
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
        var partes = Separar(texto);
        var resultado = new long[partes.Length];

        for (var i = 0; i < partes.Length; i++)
        {
            if (!long.TryParse(partes[i], System.Globalization.NumberStyles.Integer,
                    System.Globalization.CultureInfo.CurrentCulture, out resultado[i]) &&
                !long.TryParse(partes[i], System.Globalization.NumberStyles.Integer,
                    System.Globalization.CultureInfo.InvariantCulture, out resultado[i]))
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
        => string.IsNullOrWhiteSpace(texto)
            ? Array.Empty<string>()
            : texto.Split(Separadores, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

    public static double[] GenerarDobles(int n, int min = 1, int max = 100)
    {
        var a = new double[n];
        for (int i = 0; i < n; i++) a[i] = Random.Shared.Next(min, max + 1);
        return a;
    }

    public static int[] GenerarInts(int n, int min = -50, int max = 100)
    {
        var a = new int[n];
        for (int i = 0; i < n; i++) a[i] = Random.Shared.Next(min, max + 1);
        return a;
    }

    public static long[] GenerarLongs(int n, int min = 1, int max = 100)
    {
        var a = new long[n];
        for (int i = 0; i < n; i++) a[i] = Random.Shared.Next(min, max + 1);
        return a;
    }

}
