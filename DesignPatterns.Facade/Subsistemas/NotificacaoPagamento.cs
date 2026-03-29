namespace DesignPatterns.Facade;

/// <summary>Subsistema: envio de confirmação após pagamento.</summary>
public class NotificacaoPagamento
{
    public void Confirmar(string destinatario, decimal valor, string provedor)
    {
        ArgumentNullException.ThrowIfNull(destinatario);
        ArgumentNullException.ThrowIfNull(provedor);

        Console.WriteLine($"  [Email] Confirmação enviada para {destinatario}:");
        Console.WriteLine($"  [Email] \"Pagamento de R$ {valor:F2} via {provedor} realizado!\"");
    }
}
