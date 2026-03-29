namespace DesignPatterns.Adapter;

/// <summary>
/// Target: contrato que o domínio da aplicação conhece (processamento de pagamento agnóstico de gateway).
/// </summary>
public interface IProcessadorPagamento
{
    bool ProcessarPagamento(string cartao, decimal valor, string moeda);

    bool EstornarPagamento(string transacaoId);

    string ConsultarStatus(string transacaoId);
}
