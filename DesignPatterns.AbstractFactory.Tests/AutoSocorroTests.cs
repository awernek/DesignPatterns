using System.IO;
using System.Text;

namespace DesignPatterns.AbstractFactory.Tests;

/// <summary>
/// Testes do <see cref="AutoSocorro"/>.
/// O AutoSocorro é o "cliente" do Abstract Factory: recebe uma fábrica (abstração)
/// e um veículo, e delega à fábrica a criação do par veículo+guincho compatível.
/// Ao realizar o atendimento, o guincho correto é acionado — validamos pela saída no console.
/// </summary>
public class AutoSocorroTests
{
    [Theory]
    [InlineData(Porte.Pequeno, "Celta", "guincho pequeno")]
    [InlineData(Porte.Medio, "Jetta", "guincho médio")]
    [InlineData(Porte.Grande, "BMW X6", "guincho grande")]
    public void RealizarAtendimento_ComFabricaDoPorte_GuinchoCorretoSocorreVeiculo(Porte porte, string modelo, string textoGuinchoEsperado)
    {
        var selector = new AutoSocorroFactorySelector();
        IAutoSocorroFactory factory = selector.ObterFactory(porte);
        var veiculo = VeiculoCreator.Criar(modelo, porte);

        var autoSocorro = new AutoSocorro(factory, veiculo);
        var saida = CapturarSaidaConsole(() => autoSocorro.RealizarAtendimento());

        Assert.Contains(modelo, saida);
        Assert.Contains(textoGuinchoEsperado, saida);
    }

    [Fact]
    public void RealizarAtendimento_VeiculoCriadoPelaFabrica_UsadoNoAtendimento()
    {
        var factory = new SocorroVeiculoPequenoFactory();
        var veiculo = VeiculoCreator.Criar("Fiat 500", Porte.Pequeno);
        var autoSocorro = new AutoSocorro(factory, veiculo);

        var saida = CapturarSaidaConsole(() => autoSocorro.RealizarAtendimento());

        Assert.Contains("Veículo Pequeno", saida);
        Assert.Contains("Fiat 500", saida);
        Assert.Contains("guincho pequeno", saida);
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
