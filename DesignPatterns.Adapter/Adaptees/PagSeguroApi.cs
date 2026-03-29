namespace DesignPatterns.Adapter;

/// <summary>
/// Adaptee: simula SDK externa com API incompatível com <see cref="IProcessadorPagamento"/>.
/// Tratada como código que não deve ser alterado para atender ao seu domínio.
/// </summary>
public class PagSeguroApi
{
    public string IniciarTransacao(string numeroCartao, double quantia)
    {
        var id = $"PS-{Random.Shared.Next(10000, 99999)}";
        Console.WriteLine($"  [PagSeguro] Transação iniciada: {id} | R$ {quantia:F2}");
        return id;
    }

    public int CancelarTransacao(string idTransacao)
    {
        Console.WriteLine($"  [PagSeguro] Cancelando transação: {idTransacao}");
        return 0;
    }

    public string[] ObterDetalhesTransacao(string idTransacao) =>
        new[] { idTransacao, "APROVADO", "R$ 350,00", "2024-01-15" };
}
