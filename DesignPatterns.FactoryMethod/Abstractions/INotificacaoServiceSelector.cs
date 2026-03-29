namespace DesignPatterns.FactoryMethod;

/// <summary>
/// Seletor que retorna o serviço de notificação (Creator) adequado ao canal,
/// desacoplando o cliente da escolha das subclasses concretas.
/// </summary>
public interface INotificacaoServiceSelector
{
    /// <summary>
    /// Obtém o Creator concreto que implementa o Factory Method <c>CriarMensagem</c> para o canal informado.
    /// </summary>
    /// <param name="canal">Canal desejado (e-mail, SMS ou push).</param>
    /// <returns>Serviço que encapsula a criação do produto e o algoritmo <see cref="NotificacaoService.Notificar"/>.</returns>
    NotificacaoService ObterServico(CanalNotificacao canal);
}
