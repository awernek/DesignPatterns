using System.IO;
using System.Text;

namespace DesignPatterns.FactoryMethod.Tests;

/// <summary>
/// Testes de <see cref="ExecucaoFactoryMethod"/>: o ponto de demonstração orquestra seletor + canal
/// (equivalente ao papel de <c>ExecucaoAbstractFactory</c> no outro padrão).
/// </summary>
public class ExecucaoFactoryMethodTests
{
    [Fact]
    public void Executar_ComCanalEmail_ProduzSaidaDeEmail()
    {
        INotificacaoServiceSelector selector = new NotificacaoServiceSelector();

        var saida = CapturarSaidaConsole(() =>
            ExecucaoFactoryMethod.Executar(selector, CanalNotificacao.Email));

        Assert.Contains("Formatando HTML", saida);
        Assert.Contains("fatura de energia", saida);
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
