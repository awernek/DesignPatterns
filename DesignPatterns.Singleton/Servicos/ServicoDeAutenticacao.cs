namespace DesignPatterns.Singleton;

/// <summary>Exemplo de consumidor: usa <see cref="Logger.Instancia"/> para registrar eventos.</summary>
public class ServicoDeAutenticacao
{
    public void Autenticar(string usuario)
    {
        Logger.Instancia.Info($"Tentativa de login: {usuario}");

        if (usuario == "admin")
            Logger.Instancia.Info($"Login bem-sucedido: {usuario}");
        else
            Logger.Instancia.Aviso($"Usuário não encontrado: {usuario}");
    }
}
