namespace DesignPatterns.AbstractFactory;

public class SocorroVeiculoMedioFactory : AutoSocorroFactory
{
    protected override Porte Porte => Porte.Medio;
}
