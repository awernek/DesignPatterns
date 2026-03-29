namespace DesignPatterns.Strategy;

/// <summary>Transportadora expressa: percentual do pedido + urgência + sobrepeso.</summary>
public class TransportadoraExpressStrategy : IFreteStrategy
{
    public string NomeDaModalidade => "Transportadora Express";

    public decimal CalcularFrete(decimal pesoKg, decimal distanciaKm, decimal valorPedido)
    {
        var percentualPedido = valorPedido * 0.03m;
        var taxaUrgencia = 25.00m;
        var taxaPeso = pesoKg > 10 ? (pesoKg - 10) * 5.00m : 0;

        return percentualPedido + taxaUrgencia + taxaPeso;
    }

    public int PrazoEmDias(decimal distanciaKm) =>
        distanciaKm <= 300 ? 1 : 2;
}
