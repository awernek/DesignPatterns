namespace DesignPatterns.FactoryMethod.Tests;

/// <summary>
/// Testes do <see cref="NotificacaoServiceSelector"/>.
/// Mostram que o seletor retorna o Creator concreto correto para cada canal,
/// sem o cliente precisar referenciar <see cref="EmailNotificacaoService"/>, etc.
/// </summary>
public class NotificacaoServiceSelectorTests
{
    [Theory]
    [InlineData(CanalNotificacao.Email, typeof(EmailNotificacaoService))]
    [InlineData(CanalNotificacao.Sms, typeof(SmsNotificacaoService))]
    [InlineData(CanalNotificacao.Push, typeof(PushNotificacaoService))]
    public void ObterServico_ParaCadaCanal_RetornaCreatorConcretoCorreto(
        CanalNotificacao canal,
        Type tipoServicoEsperado)
    {
        var selector = new NotificacaoServiceSelector();

        NotificacaoService service = selector.ObterServico(canal);

        Assert.IsType(tipoServicoEsperado, service);
    }

    [Fact]
    public void ObterServico_CanalInvalido_LancaArgumentException()
    {
        var selector = new NotificacaoServiceSelector();
        var canalInvalido = (CanalNotificacao)999;

        var ex = Assert.Throws<ArgumentException>(() => selector.ObterServico(canalInvalido));

        Assert.Contains("Canal de notificação inválido", ex.Message);
        Assert.Equal("canal", ex.ParamName);
    }
}
