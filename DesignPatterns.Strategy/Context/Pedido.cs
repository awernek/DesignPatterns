namespace DesignPatterns.Strategy;

/// <summary>Context: delega cálculo de frete à <see cref="IFreteStrategy"/> configurada.</summary>
public class Pedido
{
    private IFreteStrategy _strategy;

    public string Descricao { get; }
    public decimal PesoKg { get; }
    public decimal DistanciaKm { get; }
    public decimal ValorProduto { get; }

    public Pedido(
        string descricao,
        decimal pesoKg,
        decimal distanciaKm,
        decimal valorProduto,
        IFreteStrategy strategy)
    {
        ArgumentNullException.ThrowIfNull(descricao);
        ArgumentNullException.ThrowIfNull(strategy);

        Descricao = descricao;
        PesoKg = pesoKg;
        DistanciaKm = distanciaKm;
        ValorProduto = valorProduto;
        _strategy = strategy;
    }

    public void TrocarStrategy(IFreteStrategy novaStrategy)
    {
        ArgumentNullException.ThrowIfNull(novaStrategy);

        Console.WriteLine();
        Console.WriteLine($"  Modalidade alterada: {_strategy.NomeDaModalidade} → {novaStrategy.NomeDaModalidade}");
        _strategy = novaStrategy;
    }

    public void ExibirResumo()
    {
        var frete = _strategy.CalcularFrete(PesoKg, DistanciaKm, ValorProduto);
        var prazo = _strategy.PrazoEmDias(DistanciaKm);
        var total = ValorProduto + frete;

        var linha = new string('-', 48);
        Console.WriteLine();
        Console.WriteLine($"  {linha}");
        Console.WriteLine($"  Pedido     : {Descricao}");
        Console.WriteLine($"  Modalidade : {_strategy.NomeDaModalidade}");
        Console.WriteLine($"  Peso       : {PesoKg} kg");
        Console.WriteLine($"  Distância  : {DistanciaKm} km");
        Console.WriteLine($"  {linha}");
        Console.WriteLine($"  Produtos      R$ {ValorProduto:F2}");
        Console.WriteLine($"  Frete         R$ {frete:F2}");
        Console.WriteLine($"  Total         R$ {total:F2}");
        Console.WriteLine($"  Prazo         {(prazo == 0 ? "Disponível agora" : $"{prazo} dia(s) úteis")}");
        Console.WriteLine($"  {linha}");
    }
}
