namespace DesignPatterns.AbstractFactory;

/// <summary>Fábrica que cria veículo e guincho da família de porte grande.</summary>
public class SocorroVeiculoGrandeFactory : AutoSocorroFactory
{
    /// <inheritdoc />
    protected override Porte Porte => Porte.Grande;
}
