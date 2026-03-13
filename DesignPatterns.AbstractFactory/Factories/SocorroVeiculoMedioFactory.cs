namespace DesignPatterns.AbstractFactory;

/// <summary>Fábrica que cria veículo e guincho da família de porte médio.</summary>
public class SocorroVeiculoMedioFactory : AutoSocorroFactory
{
    /// <inheritdoc />
    protected override Porte Porte => Porte.Medio;
}
