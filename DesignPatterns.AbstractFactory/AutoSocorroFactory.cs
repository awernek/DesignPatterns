namespace DesignPatterns.AbstractFactory;

/// <summary>
/// Classe base abstrata das fábricas de auto-socorro. Define o porte da família e
/// implementa a criação de guincho e veículo via creators, permitindo que subclasses
/// apenas exponham o <see cref="Porte"/>.
/// </summary>
public abstract class AutoSocorroFactory : IAutoSocorroFactory
{
    /// <summary>Porte da família de produtos (pequeno, médio ou grande) que esta fábrica cria.</summary>
    protected abstract Porte Porte { get; }

    /// <inheritdoc />
    public virtual Guincho CriarGuincho() => GuinchoCreator.Criar(Porte);

    /// <inheritdoc />
    public virtual Veiculo CriarVeiculo(string modelo, Porte porte) => VeiculoCreator.Criar(modelo, porte);
}