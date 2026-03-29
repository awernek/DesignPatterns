using System.IO;
using System.Text;

namespace DesignPatterns.FactoryMethod.Tests;

/// <summary>
/// Testes dos Creators concretos e do fluxo <see cref="NotificacaoService.Notificar"/>:
/// o algoritmo é herdado; apenas <c>CriarMensagem</c> varia entre subclasses.
/// </summary>
public class NotificacaoServiceTests
{
    [Theory]
    [InlineData(CanalNotificacao.Email, "E-mail", "Formatando HTML", "SMTP")]
    [InlineData(CanalNotificacao.Sms, "SMS", "Validando número", "Disparando SMS")]
    [InlineData(CanalNotificacao.Push, "Push Notification", "device token", "FCM")]
    public void Notificar_ViaSelector_ExecutaFluxoDoCanal(
        CanalNotificacao canal,
        string textoCanalEsperado,
        string trechoPreparar,
        string trechoEnviar)
    {
        var selector = new NotificacaoServiceSelector();
        NotificacaoService service = selector.ObterServico(canal);

        var saida = CapturarSaidaConsole(() => service.Notificar("dest", "Mensagem de teste."));

        Assert.Contains(textoCanalEsperado, saida);
        Assert.Contains(trechoPreparar, saida);
        Assert.Contains(trechoEnviar, saida);
        Assert.Contains("Notificação entregue via", saida);
    }

    [Fact]
    public void Notificar_SmsComTextoLongo_TruncaParaLimiteDe160Caracteres()
    {
        var service = new SmsNotificacaoService();
        var textoLongo = new string('x', 200);

        var saida = CapturarSaidaConsole(() => service.Notificar("5511999990000", textoLongo));

        Assert.Contains("(160/160 caracteres)", saida);
        Assert.Contains("xxx...", saida);
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
