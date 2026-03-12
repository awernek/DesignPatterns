namespace DesignPatterns.AbstractFactory;

/// <summary>Cria instâncias de <see cref="Guincho"/> conforme o <see cref="Porte"/> informado.</summary>
public static class GuinchoCreator
{
    /// <summary>Cria um guincho do tipo correspondente ao porte (Pequeno, Medio ou Grande).</summary>
    /// <param name="porte">Porte que define a classe concreta de guincho retornada.</param>
    public static Guincho Criar(Porte porte) => porte switch
    {
        Porte.Pequeno => new GuinchoPequeno(porte),
        Porte.Medio => new GuinchoMedio(porte),
        Porte.Grande => new GuinchoGrande(porte),
        _ => throw new ArgumentException("Porte desconhecido.", nameof(porte))
    };
}
