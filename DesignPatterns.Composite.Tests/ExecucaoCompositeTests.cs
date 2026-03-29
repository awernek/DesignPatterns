using System.IO;
using System.Text;

namespace DesignPatterns.Composite.Tests;

public class ExecucaoCompositeTests
{
    [Fact]
    public void Executar_MontaArvoreEImprimeResumo()
    {
        var saida = CapturarSaidaConsole(ExecucaoComposite.Executar);

        Assert.Contains("Sistema de arquivos — Composite", saida);
        Assert.Contains("+ Documentos/", saida);
        Assert.Contains("relatorio-q3.pdf", saida);
        Assert.Contains("Documentos (total):", saida);
        Assert.Contains("Curriculo (folha)", saida);
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
