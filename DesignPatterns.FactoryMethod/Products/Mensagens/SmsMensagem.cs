namespace DesignPatterns.FactoryMethod;

/// <summary>Mensagem de notificação via SMS (conteúdo limitado a 160 caracteres).</summary>
public class SmsMensagem : IMensagem
{
    private readonly string _destinatario;
    private readonly string _conteudo;

    public SmsMensagem(string destinatario, string conteudo)
    {
        _destinatario = destinatario;
        _conteudo = conteudo.Length > 160
            ? conteudo[..157] + "..."
            : conteudo;
    }

    /// <inheritdoc />
    public string Canal => "SMS";

    /// <inheritdoc />
    public void Preparar() =>
        Console.WriteLine($"  Validando número e truncando mensagem ({_conteudo.Length}/160 caracteres)");

    /// <inheritdoc />
    public void Enviar() =>
        Console.WriteLine($"  Disparando SMS para {_destinatario}: \"{_conteudo}\"");

    /// <inheritdoc />
    public void RegistrarLog() =>
        Console.WriteLine("  Log: SMS registrado na operadora.");
}
