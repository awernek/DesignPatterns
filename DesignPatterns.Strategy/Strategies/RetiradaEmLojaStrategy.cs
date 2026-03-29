namespace DesignPatterns.Strategy;

/// <summary>Retirada na loja: sem frete e prazo imediato.</summary>
public class RetiradaEmLojaStrategy : IFreteStrategy
{
    public string NomeDaModalidade => "Retirada em Loja";

    public decimal CalcularFrete(decimal pesoKg, decimal distanciaKm, decimal valorPedido)
    {
        Console.WriteLine("  [Loja] Sem custo de frete — retirada presencial.");
        return 0;
    }

    public int PrazoEmDias(decimal distanciaKm) => 0;
}
