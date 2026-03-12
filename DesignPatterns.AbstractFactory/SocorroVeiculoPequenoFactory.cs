namespace DesignPatterns.AbstractFactory;

public class SocorroVeiculoPequenoFactory : AutoSocorroFactory
{
    protected override Porte Porte => Porte.Pequeno;
}