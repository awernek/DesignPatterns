namespace DesignPatterns.Facade;

/// <summary>Subsistema: cobrança via Mercado Pago.</summary>
public class MercadoPago
{
    public bool RealizarCobranca(string cpf, decimal valor)
    {
        Console.WriteLine($"  [MercadoPago] Processando R$ {valor:F2} para CPF {cpf}...");
        Console.WriteLine("  [MercadoPago] Cobrança aprovada.");
        return true;
    }
}
