namespace DesignPatterns.AbstractFactory;

public abstract class AutoSocorroFactory : IAutoSocorroFactory
{
    protected abstract Porte Porte { get; }

    public virtual Guincho CriarGuincho() => GuinchoCreator.Criar(Porte);

    public virtual Veiculo CriarVeiculo(string modelo, Porte porte) => VeiculoCreator.Criar(modelo, porte);
}