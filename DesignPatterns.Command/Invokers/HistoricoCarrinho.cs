namespace DesignPatterns.Command;

/// <summary>Invoker: mantém pilhas de undo/redo sem conhecer comandos concretos.</summary>
public class HistoricoCarrinho
{
    private readonly Stack<ICommand> _undo = new();
    private readonly Stack<ICommand> _redo = new();

    public void Executar(ICommand comando)
    {
        ArgumentNullException.ThrowIfNull(comando);

        comando.Execute();
        _undo.Push(comando);
        _redo.Clear();
    }

    public void Desfazer()
    {
        if (_undo.Count == 0)
        {
            Console.WriteLine("  Nada para desfazer.");
            return;
        }

        var cmd = _undo.Pop();
        cmd.Undo();
        _redo.Push(cmd);
    }

    public void Refazer()
    {
        if (_redo.Count == 0)
        {
            Console.WriteLine("  Nada para refazer.");
            return;
        }

        var cmd = _redo.Pop();
        cmd.Execute();
        _undo.Push(cmd);
    }
}
