namespace DesignPatterns.Command;

/// <summary>Item de linha do carrinho (receiver não conhece histórico).</summary>
public class ItemCarrinho
{
    public string Produto { get; set; } = "";

    public int Quantidade { get; set; }

    public decimal PrecoUnit { get; set; }

    public decimal Total => PrecoUnit * Quantidade;
}
