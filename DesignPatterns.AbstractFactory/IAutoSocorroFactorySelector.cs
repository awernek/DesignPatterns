namespace DesignPatterns.AbstractFactory;

public interface IAutoSocorroFactorySelector
{
    IAutoSocorroFactory ObterFactory(Porte porte);
}
