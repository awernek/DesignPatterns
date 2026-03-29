namespace DesignPatterns.FactoryMethod;

/// <summary>Creator concreto: notificações por e-mail.</summary>
public class EmailNotificacaoService : NotificacaoService
{
    /// <inheritdoc />
    protected override IMensagem CriarMensagem(string destinatario, string conteudo) =>
        new EmailMensagem(destinatario, conteudo);

    /// <inheritdoc />
    protected override string ObterNomeDoCanal() => "E-mail";
}
