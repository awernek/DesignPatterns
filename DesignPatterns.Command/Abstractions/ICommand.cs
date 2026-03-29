namespace DesignPatterns.Command;

/// <summary>Command: encapsula uma ação no receiver e permite desfazer.</summary>
public interface ICommand
{
    void Execute();

    void Undo();
}
