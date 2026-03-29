namespace DesignPatterns.Composite;

internal static class FormatadorTamanhoBytes
{
    public static string Formatar(long bytes) => bytes switch
    {
        < 1024 => $"{bytes} B",
        < 1024 * 1024 => $"{bytes / 1024} KB",
        _ => $"{bytes / (1024 * 1024)} MB"
    };
}
