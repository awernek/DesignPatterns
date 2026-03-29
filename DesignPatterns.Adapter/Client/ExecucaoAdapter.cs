namespace DesignPatterns.Adapter;

/// <summary>
/// Demonstração: monta Adaptee → Adapter → cliente (<see cref="ServicoDeCheckout"/>).
/// </summary>
public static class ExecucaoAdapter
{
    public static void Executar()
    {
        Console.WriteLine();
        Console.WriteLine("Sistema de checkout — Adapter (gateway PagSeguro)");

        var pagSeguroApi = new PagSeguroApi();
        var adapter = new PagSeguroAdapter(pagSeguroApi);
        var checkout = new ServicoDeCheckout(adapter);

        checkout.FinalizarCompra("4111-1111-1111-1111", 350.00m);
        checkout.EstornarCompra("PS-12345");
    }
}
