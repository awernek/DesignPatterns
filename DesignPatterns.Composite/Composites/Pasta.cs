namespace DesignPatterns.Composite;

/// <summary>Composto: pasta que agrega outros <see cref="IComponente"/>.</summary>
public class Pasta : IComponente
{
    private readonly List<IComponente> _filhos = new();

    public Pasta(string nome)
    {
        ArgumentNullException.ThrowIfNull(nome);
        Nome = nome;
    }

    public string Nome { get; }

    public void Adicionar(IComponente componente)
    {
        ArgumentNullException.ThrowIfNull(componente);
        _filhos.Add(componente);
    }

    public void Remover(IComponente componente) => _filhos.Remove(componente);

    public long ObterTamanho() => _filhos.Sum(f => f.ObterTamanho());

    public void Exibir(int nivel = 0)
    {
        var indent = new string(' ', nivel * 3);
        Console.WriteLine($"{indent}+ {Nome}/ ({FormatadorTamanhoBytes.Formatar(ObterTamanho())})");

        foreach (var filho in _filhos)
            filho.Exibir(nivel + 1);
    }
}
