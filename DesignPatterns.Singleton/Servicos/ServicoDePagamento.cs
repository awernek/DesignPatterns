namespace DesignPatterns.Singleton;

/// <summary>Exemplo de consumidor do logger singleton.</summary>
public class ServicoDePagamento
{
    public void ProcessarPagamento(decimal valor)
    {
        Logger.Instancia.Info($"Iniciando pagamento: R$ {valor:F2}");

        if (valor > 10000)
            Logger.Instancia.Aviso($"Pagamento acima do limite: R$ {valor:F2}");
        else
            Logger.Instancia.Info($"Pagamento aprovado: R$ {valor:F2}");
    }
}
