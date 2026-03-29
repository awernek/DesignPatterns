namespace DesignPatterns.FactoryMethod;

/// <summary>Mensagem de notificação via e-mail.</summary>
public class EmailMensagem : IMensagem
{
    private readonly string _destinatario;
    private readonly string _conteudo;

    public EmailMensagem(string destinatario, string conteudo)
    {
        _destinatario = destinatario;
        _conteudo = conteudo;
    }

    /// <inheritdoc />
    public string Canal => "E-mail";

    /// <inheritdoc />
    public void Preparar() =>
        Console.WriteLine($"  Formatando HTML para: {_destinatario}");

    /// <inheritdoc />
    public void Enviar() =>
        Console.WriteLine($"  Enviando e-mail via SMTP: \"{_conteudo}\"");

    /// <inheritdoc />
    public void RegistrarLog() =>
        Console.WriteLine("  Log: e-mail registrado no servidor de auditoria.");
}
