using System.IO;
using System.Text;

namespace DesignPatterns.Singleton.Tests;

/// <summary>Testes da demonstração <see cref="ExecucaoSingleton"/>.</summary>
public class ExecucaoSingletonTests : IDisposable
{
    public ExecucaoSingletonTests()
    {
        Logger.ResetInstanciaParaTestes();
    }

    public void Dispose()
    {
        Logger.ResetInstanciaParaTestes();
    }

    [Fact]
    public void Executar_ProduzSaidaEsperada()
    {
        var saida = CapturarSaidaConsole(ExecucaoSingleton.Executar);

        Assert.Contains("Mesma instância? True", saida);
        Assert.Contains("Tentativa de login", saida);
        Assert.Contains("Histórico completo", saida);
    }

    private static string CapturarSaidaConsole(Action acao)
    {
        var originalOut = Console.Out;
        try
        {
            using var writer = new StringWriter(new StringBuilder());
            Console.SetOut(writer);
            acao();
            return writer.ToString();
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }
}
