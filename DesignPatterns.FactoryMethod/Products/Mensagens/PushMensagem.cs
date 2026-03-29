namespace DesignPatterns.FactoryMethod;

/// <summary>Mensagem de notificação push (ex.: FCM).</summary>
public class PushMensagem : IMensagem
{
    private readonly string _destinatario;
    private readonly string _conteudo;

    public PushMensagem(string destinatario, string conteudo)
    {
        _destinatario = destinatario;
        _conteudo = conteudo;
    }

    /// <inheritdoc />
    public string Canal => "Push Notification";

    /// <inheritdoc />
    public void Preparar() =>
        Console.WriteLine($"  Buscando device token do usuário: {_destinatario}");

    /// <inheritdoc />
    public void Enviar() =>
        Console.WriteLine($"  Enviando push via FCM: \"{_conteudo}\"");

    /// <inheritdoc />
    public void RegistrarLog() =>
        Console.WriteLine("  Log: push registrado no painel de analytics.");
}
