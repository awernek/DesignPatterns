namespace DesignPatterns.Composite;

/// <summary>Folha: arquivo sem filhos.</summary>
public class Arquivo : IComponente
{
    private readonly long _tamanhoBytes;
    private readonly string _extensao;

    public Arquivo(string nome, string extensao, long tamanhoBytes)
    {
        ArgumentNullException.ThrowIfNull(nome);
        ArgumentNullException.ThrowIfNull(extensao);
        if (tamanhoBytes < 0)
            throw new ArgumentOutOfRangeException(nameof(tamanhoBytes));

        Nome = nome;
        _extensao = extensao;
        _tamanhoBytes = tamanhoBytes;
    }

    public string Nome { get; }

    public long ObterTamanho() => _tamanhoBytes;

    public void Exibir(int nivel = 0)
    {
        var indent = new string(' ', nivel * 3);
        Console.WriteLine($"{indent}- {Nome}.{_extensao} ({FormatadorTamanhoBytes.Formatar(_tamanhoBytes)})");
    }
}
