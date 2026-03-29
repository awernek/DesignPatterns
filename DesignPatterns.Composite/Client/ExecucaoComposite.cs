namespace DesignPatterns.Composite;

/// <summary>Demonstração: árvore de pastas e arquivos tratada uniformemente via <see cref="IComponente"/>.</summary>
public static class ExecucaoComposite
{
    public static void Executar()
    {
        Console.WriteLine();
        Console.WriteLine("Sistema de arquivos — Composite");

        var raiz = new Pasta("Documentos");

        var trabalho = new Pasta("Trabalho");
        trabalho.Adicionar(new Arquivo("relatorio-q3", "pdf", 2_400_000));
        trabalho.Adicionar(new Arquivo("planilha", "xlsx", 850_000));
        trabalho.Adicionar(new Arquivo("apresentacao", "pdf", 5_100_000));

        var projetos = new Pasta("Projetos");
        projetos.Adicionar(new Arquivo("DesignPatterns", "cs", 45_000));
        projetos.Adicionar(new Arquivo("readme", "pdf", 12_000));

        trabalho.Adicionar(projetos);

        var pessoal = new Pasta("Pessoal");
        pessoal.Adicionar(new Arquivo("curriculo", "pdf", 320_000));
        pessoal.Adicionar(new Arquivo("foto-perfil", "jpg", 1_200_000));
        pessoal.Adicionar(new Arquivo("video-ferias", "mp4", 98_000_000));

        raiz.Adicionar(trabalho);
        raiz.Adicionar(pessoal);

        Console.WriteLine();
        Console.WriteLine("— Estrutura completa —");
        Console.WriteLine();
        raiz.Exibir();

        Console.WriteLine();
        Console.WriteLine("— Tamanhos individuais —");
        Console.WriteLine();
        Console.WriteLine($"  Documentos (total): {raiz.ObterTamanho() / (1024 * 1024)} MB");
        Console.WriteLine($"  Trabalho          : {trabalho.ObterTamanho() / (1024 * 1024)} MB");
        Console.WriteLine($"  Pessoal           : {pessoal.ObterTamanho() / (1024 * 1024)} MB");

        IComponente arquivo = new Arquivo("curriculo", "pdf", 320_000);
        Console.WriteLine($"  Curriculo (folha) : {arquivo.ObterTamanho() / 1024} KB");
    }
}
