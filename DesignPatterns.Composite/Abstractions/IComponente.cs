namespace DesignPatterns.Composite;

/// <summary>
/// Componente comum: folha (<see cref="Arquivo"/>) e composto (<see cref="Pasta"/>) expõem o mesmo contrato.
/// </summary>
public interface IComponente
{
    string Nome { get; }

    long ObterTamanho();

    void Exibir(int nivel = 0);
}
