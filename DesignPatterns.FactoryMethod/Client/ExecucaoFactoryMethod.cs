namespace DesignPatterns.FactoryMethod;

/// <summary>
/// Ponto de entrada para demonstração do padrão Factory Method:
/// obtém o Creator adequado via <paramref name="serviceSelector"/> e executa o fluxo <see cref="NotificacaoService.Notificar"/>.
/// </summary>
/// <remarks>
/// Em Abstract Factory o cliente recebe uma fábrica injetada; aqui o cliente escolhe o canal e o seletor devolve
/// o serviço (Creator) cuja única variação é o Factory Method <c>CriarMensagem</c>, encapsulado dentro da hierarquia.
/// </remarks>
public static class ExecucaoFactoryMethod
{
    /// <summary>
    /// Executa uma notificação de exemplo no canal informado, usando o seletor para resolver o Creator concreto.
    /// </summary>
    /// <param name="serviceSelector">Seletor que retorna o <see cref="NotificacaoService"/> adequado ao canal.</param>
    /// <param name="canal">Canal de envio (e-mail, SMS ou push).</param>
    public static void Executar(INotificacaoServiceSelector serviceSelector, CanalNotificacao canal)
    {
        NotificacaoService service = serviceSelector.ObterServico(canal);
        service.Notificar(
            destinatario: "joao@email.com / +55 21 99999-0000",
            conteudo: "Sua fatura de energia vence em 3 dias. Valor: R$ 187,50.");
    }
}
