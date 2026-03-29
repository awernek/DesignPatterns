# Testes do Singleton

Documentação executável do padrão **Singleton** no exemplo do `Logger` compartilhado por serviços.

## O que cada arquivo testa

| Arquivo | Ideia do padrão |
|--------|------------------|
| **LoggerTests** | Uma única referência via `Logger.Instancia`; histórico compartilhado entre serviços; `ResetInstanciaParaTestes` isola cenários. |
| **ExecucaoSingletonTests** | O fluxo de demonstração imprime a prova de identidade (`Mesma instância? True`) e o histórico consolidado. |

## Como rodar

```bash
dotnet test DesignPatterns.Singleton.Tests
```

## Conceitos que os testes evidenciam

1. **Construtor privado + instância lazy** — o cliente não usa `new Logger()`; o acesso passa pela propriedade estática.
2. **Estado global coordenado** — autenticação, pagamento e estoque escrevem no mesmo histórico porque compartilham a mesma instância.
3. **Testabilidade** — `ResetInstanciaParaTestes` (interno, visível ao projeto de testes) evita vazamento de estado entre testes. Não use em produção como “limpeza” de rotina; é apenas para testes.
