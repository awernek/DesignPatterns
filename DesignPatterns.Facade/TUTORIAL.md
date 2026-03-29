# Facade — Tutorial

## O problema que resolve

Um subsistema complexo tem várias classes com APIs diferentes.  
O cliente precisa conhecer e coordenar todas elas — ordem de chamada, conversões, tratamento de erro.  
A Facade oferece **uma única porta de entrada simples**.

---

## A ideia em uma frase

> "Uma classe que simplifica o acesso a um conjunto de subsistemas — o cliente faz uma chamada, a fachada orquestra o resto."

---

## Analogia para memorização

Pense numa **recepcionista de hotel**.  
Você diz: "quero room service, lavanderia e táxi para amanhã cedo."  
Ela coordena três departamentos diferentes.  
Você não fala com cada departamento — só com ela.  
Os departamentos continuam existindo e podem ser acessados diretamente se necessário.

---

## Os papéis

| Papel | No exemplo | Responsabilidade |
|---|---|---|
| **Facade** | `PagamentoFacade` | interface simples; orquestra subsistemas |
| **Subsistemas** | `PayPal`, `MercadoPago`, `PicPay`, `NotificacaoPagamento` | lógica própria; ignoram a existência da Facade |
| **Cliente** | `ExecucaoFacadePagamento` | chama apenas `Pagar(...)` |

```csharp
// Cliente só sabe disso:
facade.Pagar("paypal", "joao@email.com", 350.00m);

// Internamente, a Facade coordena:
// 1. Roteia para o provedor correto (PayPal, MercadoPago, PicPay)
// 2. Chama o subsistema de notificação se bem-sucedido
// 3. Exibe o resultado
```

---

## Como lembrar: Facade é **conveniência, não prisão**

```
[Cliente]  →  [Facade]  →  [Subsistema A]
                       →  [Subsistema B]
                       →  [Subsistema C]

[Cliente avançado]  →  [Subsistema B diretamente]  ✓ também válido
```

A Facade não substitui os subsistemas.  
Quem precisar de controle fino continua acessando-os direto.

---

## SOLID & OOP

### Pilares OOP em ação

| Pilar | Como aparece |
|---|---|
| **Encapsulamento** | `PagamentoFacade` esconde os subsistemas: o cliente não sabe que PayPal e MercadoPago existem |
| **Abstração** | A Facade expõe uma API de alto nível (`Pagar`) sobre API de baixo nível dos subsistemas |
| **Composição** | Facade **compõe** subsistemas via injeção no construtor — não herda deles |
| **Polimorfismo** | Não é o foco: a variação aqui é de *orquestração*, não de *comportamento do objeto* |

### Princípios SOLID

| Princípio | Situação | Avaliação |
|---|---|---|
| **SRP** | Cada subsistema tem sua responsabilidade | Atende — PayPal processa, Notificação notifica, Facade só coordena |
| **OCP** | Adicionar novo provedor | **Tensão**: a Facade precisa ser modificada para rotear para o novo provedor. Mitigação: use um dicionário ou strategy de roteamento interno |
| **LSP** | Não é o foco | Facade geralmente não é substituída polimorficamente |
| **ISP** | Interface da Facade | `Pagar(...)` é a API mínima exposta — subsistemas não vazam para o cliente |
| **DIP** | Subsistemas injetados | Atende quando os subsistemas têm interfaces — `PagamentoFacade` dependeria de abstrações, não de classes concretas |

> **Tensão com OCP**: toda vez que um novo provedor de pagamento chega, a `PagamentoFacade` muda.  
> Solução: use uma **Strategy de roteamento** dentro da Facade:
>
> ```csharp
> // Dentro da Facade, em vez de if/switch:
> private readonly Dictionary<string, IProvedorPagamento> _provedores;
> _provedores[provedor].Processar(conta, valor); // roteamento via Strategy
> ```
>
> Assim novos provedores são registrados sem mudar a Facade.

## Quando usar

- Simplificar acesso a uma biblioteca ou API complexa.
- Criar camada de serviço que esconde a orquestração de domínio.
- Reduzir dependências: cliente depende de 1 classe em vez de 5.

## Quando **não** usar

- Quando o subsistema já é simples — Facade vira redundância.
- Quando você quer esconder a API **permanentemente** — use Adapter (que traduz) em vez de Facade (que simplifica).
- Não use Facade como "God Object" que sabe de tudo — mantenha coesão.

---

## Diferença: Facade vs Adapter

| | Facade | Adapter |
|---|---|---|
| **Objetivo** | Simplificar uma API complexa | Traduzir interfaces incompatíveis |
| **Muda a interface?** | Não (cria nova de zero) | Sim (mapeia Target → Adaptee) |
| **Quantos subsistemas?** | Vários | Um (o Adaptee) |

---

## Armadilhas comuns

1. **Facade que expõe detalhes internos** — vaza a complexidade que devia esconder.
2. **Facade que torna os subsistemas inacessíveis** — remova `private` se o subsistema precisar ser acessado diretamente.
3. **Facade com responsabilidade de negócio** — regras de negócio ficam nos subsistemas; Facade só coordena.

---

## Extensão sem dor (OCP)

Chegou integração com PicPay Plus?  
Adicione o subsistema e injete-o na `PagamentoFacade`.  
O cliente continua chamando `Pagar(...)`.
