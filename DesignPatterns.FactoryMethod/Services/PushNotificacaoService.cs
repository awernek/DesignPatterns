namespace DesignPatterns.FactoryMethod;

/// <summary>Creator concreto: notificações push.</summary>
public class PushNotificacaoService : NotificacaoService
{
    /// <inheritdoc />
    protected override IMensagem CriarMensagem(string destinatario, string conteudo) =>
        new PushMensagem(destinatario, conteudo);

    /// <inheritdoc />
    protected override string ObterNomeDoCanal() => "Push Notification";
}
