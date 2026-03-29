namespace DesignPatterns.FactoryMethod;

/// <summary>
/// Creator abstrato do Factory Method: define o algoritmo <see cref="Notificar"/> (template)
/// e delega a criação do produto ao método <see cref="CriarMensagem"/>.
/// </summary>
public abstract class NotificacaoService
{
    /// <summary>Factory Method: cada subclasse instancia o <see cref="IMensagem"/> adequado ao canal.</summary>
    protected abstract IMensagem CriarMensagem(string destinatario, string conteudo);

    /// <summary>
    /// Fluxo estável de notificação: preparar, enviar e registrar log usando o produto criado por <see cref="CriarMensagem"/>.
    /// </summary>
    public void Notificar(string destinatario, string conteudo)
    {
        Console.WriteLine();
        Console.WriteLine($"Canal: {ObterNomeDoCanal()}");
        Console.WriteLine(new string('-', 50));

        var mensagem = CriarMensagem(destinatario, conteudo);

        mensagem.Preparar();
        mensagem.Enviar();
        mensagem.RegistrarLog();

        Console.WriteLine($"Notificação entregue via {mensagem.Canal}.");
    }

    /// <summary>Nome exibido no cabeçalho da demonstração; pode ser sobrescrito pelos Creators concretos.</summary>
    protected virtual string ObterNomeDoCanal() => "Canal genérico";
}
