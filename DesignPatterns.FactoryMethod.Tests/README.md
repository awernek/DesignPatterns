# Testes do Factory Method

Estes testes reforçam o entendimento do padrão **Factory Method** no exemplo de sistema de notificações.

## O que cada arquivo testa

| Arquivo | Ideia do padrão |
|--------|------------------|
| **NotificacaoServiceSelectorTests** | O cliente não instancia `EmailNotificacaoService` diretamente; usa um seletor que, dado o canal, devolve o Creator concreto. |
| **NotificacaoServiceTests** | O método `Notificar` é o template estável; cada subclasse só varia `CriarMensagem`. Inclui o caso SMS com truncamento de texto. |
| **ExecucaoFactoryMethodTests** | A classe de execução (`ExecucaoFactoryMethod`) combina seletor + canal, no mesmo espírito do `ExecucaoAbstractFactory`. |

## Como rodar

Na raiz do repositório:

```bash
dotnet test DesignPatterns.FactoryMethod.Tests
```

## Conceitos que os testes evidenciam

1. **Creator e Factory Method**  
   `NotificacaoService` define o algoritmo; `CriarMensagem` é o único ponto sobrescrito nas subclasses.

2. **Diferença em relação ao Abstract Factory (neste repositório)**  
   Não há uma fábrica separada injetada para criar famílias de produtos: a criação do produto fica **dentro** do Creator (`NotificacaoService`), e o seletor só escolhe **qual** Creator usar.

3. **Extensibilidade (OCP)**  
   Novo canal = nova `IMensagem` + novo `NotificacaoService` + entrada no `NotificacaoServiceSelector`; o fluxo `Notificar` permanece igual.
