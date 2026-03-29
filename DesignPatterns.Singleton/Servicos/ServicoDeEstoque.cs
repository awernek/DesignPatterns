namespace DesignPatterns.Singleton;

/// <summary>Exemplo de consumidor do logger singleton.</summary>
public class ServicoDeEstoque
{
    public void BaixarEstoque(string produto, int quantidade)
    {
        Logger.Instancia.Info($"Baixando estoque: {quantidade}x {produto}");

        if (quantidade > 100)
            Logger.Instancia.Erro($"Quantidade inválida para: {produto}");
        else
            Logger.Instancia.Info($"Estoque atualizado: {produto}");
    }
}
