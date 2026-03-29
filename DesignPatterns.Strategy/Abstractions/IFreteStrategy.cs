namespace DesignPatterns.Strategy;

/// <summary>Strategy: algoritmo de frete intercambiável.</summary>
public interface IFreteStrategy
{
    string NomeDaModalidade { get; }

    decimal CalcularFrete(decimal pesoKg, decimal distanciaKm, decimal valorPedido);

    int PrazoEmDias(decimal distanciaKm);
}
