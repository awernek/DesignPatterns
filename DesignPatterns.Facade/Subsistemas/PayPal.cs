namespace DesignPatterns.Facade;

/// <summary>Subsistema: cobrança via PayPal.</summary>
public class PayPal
{
    public bool Cobrar(string email, decimal valor)
    {
        Console.WriteLine($"  [PayPal] Cobrando R$ {valor:F2} da conta {email}...");
        Console.WriteLine("  [PayPal] Pagamento aprovado.");
        return true;
    }
}
