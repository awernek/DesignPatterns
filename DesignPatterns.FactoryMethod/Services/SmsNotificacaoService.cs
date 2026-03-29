namespace DesignPatterns.FactoryMethod;

/// <summary>Creator concreto: notificações por SMS.</summary>
public class SmsNotificacaoService : NotificacaoService
{
    /// <inheritdoc />
    protected override IMensagem CriarMensagem(string destinatario, string conteudo) =>
        new SmsMensagem(destinatario, conteudo);

    /// <inheritdoc />
    protected override string ObterNomeDoCanal() => "SMS";
}
