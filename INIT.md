# Inicialização do projeto (INIT)

Passos para configurar e rodar o repositório **Design Patterns** pela primeira vez.

## 1. Pré-requisitos

- **.NET 10 SDK** instalado. Verifique:

  ```bash
  dotnet --version
  ```

  Se precisar instalar: [Download .NET](https://dotnet.microsoft.com/download).

## 2. Clonar / abrir o repositório

- Se for clone via Git: `git clone <url>` e `cd DesignPatterns`.
- Se já tiver a pasta: abra a raiz do repositório no terminal.

## 3. Restaurar e compilar

Na raiz do repositório (`DesignPatterns/`):

```bash
dotnet restore
dotnet build
```

## 4. Executar a aplicação

```bash
cd DesignPatterns.Console
dotnet run
```

Ou, a partir da raiz:

```bash
dotnet run --project DesignPatterns.Console
```

## 5. Adicionar um novo padrão ao solution

Para incluir um novo projeto de exemplo (ex.: `DesignPatterns.FactoryMethod`):

```bash
dotnet new classlib -n DesignPatterns.FactoryMethod -o DesignPatterns.FactoryMethod
dotnet sln add DesignPatterns.FactoryMethod/DesignPatterns.FactoryMethod.csproj
dotnet add DesignPatterns.Console/DesignPatterns.Console.csproj reference DesignPatterns.FactoryMethod/DesignPatterns.FactoryMethod.csproj
```

Depois, registrar a opção no menu em `DesignPatterns.Console/Program.cs` e chamar a execução do novo padrão.

## 6. Estrutura mínima esperada

Após o init, na raiz você deve ter:

- `README.md` — visão geral e como usar.
- `INIT.md` — este guia de inicialização.
- `.gitignore` — ignorar `bin/`, `obj/`, `.vs/`, etc.
- `DesignPatterns.slnx` (ou `.sln`) — solution.
- `DesignPatterns.Console/` — app de console.
- `DesignPatterns.AbstractFactory/` — exemplo do padrão Abstract Factory.

Com isso o projeto está inicializado e pronto para uso e para novos padrões.
