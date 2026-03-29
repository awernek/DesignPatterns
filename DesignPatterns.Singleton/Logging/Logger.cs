namespace DesignPatterns.Singleton;

/// <summary>
/// Singleton thread-safe (double-check locking): uma única instância de logger na aplicação,
/// com construtor privado, campo estático e ponto de acesso <see cref="Instancia"/>.
/// </summary>
public sealed class Logger
{
    private static Logger? _instancia;

    private static readonly object _lock = new();

    private readonly List<string> _historico = new();

    private Logger()
    {
        Console.WriteLine("  [Logger] Instância criada pela primeira vez.");
    }

    /// <summary>Único ponto de acesso global à instância (lazy, thread-safe).</summary>
    public static Logger Instancia
    {
        get
        {
            if (_instancia is null)
            {
                lock (_lock)
                {
                    if (_instancia is null)
                    {
                        _instancia = new Logger();
                    }
                }
            }

            return _instancia;
        }
    }

    /// <summary>Total de linhas registradas no histórico em memória.</summary>
    public int TotalDeEntradas => _historico.Count;

    /// <summary>Histórico somente leitura (para testes e inspeção).</summary>
    public IReadOnlyList<string> EntradasDoHistorico => _historico;

    public void Info(string mensagem) => Registrar("INFO   ", mensagem);

    public void Aviso(string mensagem) => Registrar("AVISO  ", mensagem);

    public void Erro(string mensagem) => Registrar("ERRO   ", mensagem);

    private void Registrar(string nivel, string mensagem)
    {
        var entrada = $"[{DateTime.Now:HH:mm:ss}] [{nivel}] {mensagem}";
        _historico.Add(entrada);
        Console.WriteLine($"  {entrada}");
    }

    public void ExibirHistorico()
    {
        var linha = new string('-', 46);
        Console.WriteLine();
        Console.WriteLine($"  {linha}");
        Console.WriteLine($"  Histórico completo ({_historico.Count} entradas):");
        Console.WriteLine($"  {linha}");
        foreach (var e in _historico)
        {
            Console.WriteLine($"  {e}");
        }
    }

    /// <summary>Limpa a instância estática — uso exclusivo dos testes.</summary>
    internal static void ResetInstanciaParaTestes()
    {
        lock (_lock)
        {
            _instancia = null;
        }
    }
}
