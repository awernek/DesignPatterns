namespace DesignPatterns.FactoryMethod;

/// <summary>Canal pelo qual a notificação será enviada (define qual Creator concreto será usado).</summary>
public enum CanalNotificacao
{
    Email,
    Sms,
    Push
}
