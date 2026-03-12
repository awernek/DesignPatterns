namespace DesignPatterns.AbstractFactory;

public class SocorroVeiculoGrandeFactory : AutoSocorroFactory
{
    protected override Porte Porte => Porte.Grande;
}