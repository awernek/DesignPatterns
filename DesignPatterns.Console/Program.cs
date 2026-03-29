using DesignPatterns.AbstractFactory;
using DesignPatterns.FactoryMethod;
using DesignPatterns.Singleton;
using DesignPatterns.Adapter;
using DesignPatterns.Facade;
using DesignPatterns.Composite;
using DesignPatterns.Command;
using DesignPatterns.Strategy;
using DesignPatterns.Observer;

var factorySelector = new AutoSocorroFactorySelector();
var notificacaoServiceSelector = new NotificacaoServiceSelector();

while (true)
{
    Console.Clear();
    Console.WriteLine("=== Design Patterns Playground ===");
    Console.WriteLine("1. Abstract Factory");
    Console.WriteLine("2. Factory Method");
    Console.WriteLine("3. Singleton");
    Console.WriteLine("4. Adapter");
    Console.WriteLine("5. Facade");
    Console.WriteLine("6. Composite");
    Console.WriteLine("7. Command");
    Console.WriteLine("8. Strategy");
    Console.WriteLine("9. Observer");
    Console.WriteLine("0. Sair");
    Console.Write("\nEscolha uma opção: ");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            ExecucaoAbstractFactory.Executar(factorySelector);
            break;
        case "2":
            Console.WriteLine();
            Console.WriteLine("Canal de notificação:");
            Console.WriteLine("1 - E-mail  |  2 - SMS  |  3 - Push");
            Console.Write("Escolha: ");
            var canalOpcao = Console.ReadLine();
            var canal = canalOpcao switch
            {
                "1" => CanalNotificacao.Email,
                "2" => CanalNotificacao.Sms,
                "3" => CanalNotificacao.Push,
                _ => CanalNotificacao.Email
            };
            ExecucaoFactoryMethod.Executar(notificacaoServiceSelector, canal);
            break;
        case "3":
            ExecucaoSingleton.Executar();
            break;
        case "4":
            ExecucaoAdapter.Executar();
            break;
        case "5":
            ExecucaoFacadePagamento.Executar();
            break;
        case "6":
            ExecucaoComposite.Executar();
            break;
        case "7":
            ExecucaoCarrinho.Executar();
            break;
        case "8":
            ExecucaoStrategy.Executar();
            break;
        case "9":
            ExecucaoObserver.Executar();
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
