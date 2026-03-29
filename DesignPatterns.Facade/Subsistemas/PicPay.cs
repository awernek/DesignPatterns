namespace DesignPatterns.Facade;

/// <summary>Subsistema: pagamento via PicPay.</summary>
public class PicPay
{
    public bool EfetuarPagamento(string usuario, decimal valor)
    {
        Console.WriteLine($"  [PicPay] Transferindo R$ {valor:F2} do usuário @{usuario}...");
        Console.WriteLine("  [PicPay] Pagamento confirmado.");
        return true;
    }
}
