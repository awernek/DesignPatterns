namespace DesignPatterns.AbstractFactory;

public interface IAutoSocorroFactory
{
    Guincho CriarGuincho();
    Veiculo CriarVeiculo(string modelo, Porte porte);
}
