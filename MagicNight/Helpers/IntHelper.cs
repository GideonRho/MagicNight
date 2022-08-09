namespace MagicNight.Helpers;

public static class IntHelper
{
    public static int Modulo(this int k, int n) => ((k %= n) < 0) ? k+n : k;
}