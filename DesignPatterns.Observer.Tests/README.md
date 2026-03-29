# Testes do Observer

Documentação executável do padrão **Observer** no exemplo de **status de pedido**.

## O que cada arquivo testa

| Arquivo | Ideia do padrão |
|--------|------------------|
| **PedidoSubjectTests** | O **subject** notifica todos os inscritos; `Desinscrever` interrompe as próximas notificações. |
| **ServicoDeEmailTests** | **Observer concreto** reage só aos status relevantes (ex.: não envia e-mail em `Aguardando`). |
| **ExecucaoObserverTests** | Fluxo completo; no segundo pedido, após `Desinscrever` da fidelidade, o cancelamento não dispara estorno de pontos. |

## Como rodar

```bash
dotnet test DesignPatterns.Observer.Tests
```

## Conceitos que os testes evidenciam

1. **Acoplamento fraco** — `Pedido` depende de `IObserver`, não de e-mail ou estoque.
2. **Extensibilidade (OCP)** — novo observer = nova classe; o subject não muda.
3. **Assinatura dinâmica** — `Inscrever` / `Desinscrever` alteram quem reage sem reiniciar o pedido.
