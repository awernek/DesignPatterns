namespace DesignPatterns.FactoryMethod;

/// <summary>
/// Implementação do seletor: mapeia cada <see cref="CanalNotificacao"/> para o Creator concreto correspondente.
/// </summary>
public class NotificacaoServiceSelector : INotificacaoServiceSelector
{
    /// <inheritdoc />
    public NotificacaoService ObterServico(CanalNotificacao canal) => canal switch
    {
        CanalNotificacao.Email => new EmailNotificacaoService(),
        CanalNotificacao.Sms => new SmsNotificacaoService(),
        CanalNotificacao.Push => new PushNotificacaoService(),
        _ => throw new ArgumentException("Canal de notificação inválido.", nameof(canal))
    };
}
