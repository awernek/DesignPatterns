namespace DesignPatterns.Adapter;

/// <summary>
/// Adapter: implementa <see cref="IProcessadorPagamento"/> e delega em <see cref="PagSeguroApi"/>,
/// convertendo tipos e semântica entre os dois mundos.
/// </summary>
public class PagSeguroAdapter : IProcessadorPagamento
{
    private readonly PagSeguroApi _pagSeguro;

    public PagSeguroAdapter(PagSeguroApi pagSeguro)
    {
        _pagSeguro = pagSeguro;
    }

    /// <inheritdoc />
    public bool ProcessarPagamento(string cartao, decimal valor, string moeda)
    {
        ArgumentNullException.ThrowIfNull(cartao);
        ArgumentNullException.ThrowIfNull(moeda);
        Console.WriteLine("  [Adapter] ProcessarPagamento → IniciarTransacao");

        var idTransacao = _pagSeguro.IniciarTransacao(cartao, (double)valor);
        return !string.IsNullOrEmpty(idTransacao);
    }

    /// <inheritdoc />
    public bool EstornarPagamento(string transacaoId)
    {
        ArgumentNullException.ThrowIfNull(transacaoId);
        Console.WriteLine("  [Adapter] EstornarPagamento → CancelarTransacao");

        var resultado = _pagSeguro.CancelarTransacao(transacaoId);
        return resultado == 0;
    }

    /// <inheritdoc />
    public string ConsultarStatus(string transacaoId)
    {
        ArgumentNullException.ThrowIfNull(transacaoId);
        Console.WriteLine("  [Adapter] ConsultarStatus → ObterDetalhesTransacao");

        var detalhes = _pagSeguro.ObterDetalhesTransacao(transacaoId);
        return detalhes[1];
    }
}
