namespace DesignPatterns.Strategy;

/// <summary>Demonstração: mesmo pedido com strategies diferentes e comparação em loop.</summary>
public static class ExecucaoStrategy
{
    public static void Executar()
    {
        Console.WriteLine();
        Console.WriteLine("Cálculo de frete — Strategy");

        var pedido = new Pedido(
            descricao: "Notebook Dell + Acessórios",
            pesoKg: 3.5m,
            distanciaKm: 420m,
            valorProduto: 3849.70m,
            strategy: new CorreiosPacStrategy());

        pedido.ExibirResumo();

        pedido.TrocarStrategy(new TransportadoraExpressStrategy());
        pedido.ExibirResumo();

        pedido.TrocarStrategy(new RetiradaEmLojaStrategy());
        pedido.ExibirResumo();

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("  === Comparação de modalidades ===");
        Console.WriteLine("  (Pedido: Mouse R$ 89,90 · 0,3 kg · 150 km)");
        Console.WriteLine();

        IFreteStrategy[] strategies =
        {
            new CorreiosPacStrategy(),
            new TransportadoraExpressStrategy(),
            new RetiradaEmLojaStrategy()
        };

        foreach (var strategy in strategies)
        {
            var frete = strategy.CalcularFrete(0.3m, 150m, 89.90m);
            var prazo = strategy.PrazoEmDias(150m);
            var prazoTxt = prazo == 0 ? "agora" : $"{prazo}d";
            Console.WriteLine($"  {strategy.NomeDaModalidade,-30} R$ {frete,8:F2}  {prazoTxt}");
        }
    }
}
