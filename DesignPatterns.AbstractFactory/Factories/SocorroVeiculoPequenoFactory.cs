namespace DesignPatterns.AbstractFactory;

/// <summary>Fábrica que cria veículo e guincho da família de porte pequeno.</summary>
public class SocorroVeiculoPequenoFactory : AutoSocorroFactory
{
    /// <inheritdoc />
    protected override Porte Porte => Porte.Pequeno;
}
