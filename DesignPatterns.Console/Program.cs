using DesignPatterns.AbstractFactory;

var factorySelector = new AutoSocorroFactorySelector();

while (true)
{
    Console.Clear();
    Console.WriteLine("=== Design Patterns Playground ===");
    Console.WriteLine("1. Abstract Factory");
    Console.WriteLine("0. Sair");
    Console.Write("\nEscolha uma opção: ");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            ExecucaoAbstractFactory.Executar(factorySelector);
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}