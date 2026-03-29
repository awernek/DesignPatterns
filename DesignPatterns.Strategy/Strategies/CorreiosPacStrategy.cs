namespace DesignPatterns.Strategy;

/// <summary>Correios PAC: custo por peso e distância; frete grátis acima de R$ 299.</summary>
public class CorreiosPacStrategy : IFreteStrategy
{
    public string NomeDaModalidade => "Correios PAC";

    public decimal CalcularFrete(decimal pesoKg, decimal distanciaKm, decimal valorPedido)
    {
        var taxaBase = 8.90m;
        var taxaPeso = pesoKg * 2.50m;
        var taxaDist = distanciaKm * 0.02m;

        if (valorPedido >= 299)
        {
            Console.WriteLine("  [PAC] Frete grátis aplicado (pedido acima de R$ 299)");
            return 0;
        }

        return taxaBase + taxaPeso + taxaDist;
    }

    public int PrazoEmDias(decimal distanciaKm) =>
        distanciaKm <= 500 ? 5 : 10;
}
