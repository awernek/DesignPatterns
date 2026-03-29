namespace DesignPatterns.Singleton;

/// <summary>
/// Demonstração do Singleton: vários serviços compartilham o mesmo <see cref="Logger"/>.
/// </summary>
public static class ExecucaoSingleton
{
    public static void Executar()
    {
        Console.WriteLine();
        Console.WriteLine("Sistema — demonstração do Singleton (Logger)");

        var logger1 = Logger.Instancia;
        var logger2 = Logger.Instancia;

        Console.WriteLine();
        Console.WriteLine($"  Mesma instância? {ReferenceEquals(logger1, logger2)}");

        Console.WriteLine();
        Console.WriteLine("  — Serviço de Autenticação —");
        var auth = new ServicoDeAutenticacao();
        auth.Autenticar("admin");
        auth.Autenticar("hacker123");

        Console.WriteLine();
        Console.WriteLine("  — Serviço de Pagamento —");
        var pagamento = new ServicoDePagamento();
        pagamento.ProcessarPagamento(350.00m);
        pagamento.ProcessarPagamento(15000.00m);

        Console.WriteLine();
        Console.WriteLine("  — Serviço de Estoque —");
        var estoque = new ServicoDeEstoque();
        estoque.BaixarEstoque("Notebook Dell", 2);
        estoque.BaixarEstoque("Caneta Bic", 500);

        Logger.Instancia.ExibirHistorico();
    }
}
