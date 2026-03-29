namespace DesignPatterns.FactoryMethod;

/// <summary>
/// Contrato do produto: qualquer mensagem de notificação, independente do canal.
/// O <see cref="NotificacaoService"/> só depende desta interface — não das classes concretas.
/// </summary>
public interface IMensagem
{
    string Canal { get; }

    void Preparar();

    void Enviar();

    void RegistrarLog();
}
