# Observer — Tutorial

## O problema que resolve

Quando um objeto muda de estado, **vários outros** precisam reagir — e você não quer que o objeto que mudou conheça nenhum deles diretamente.

---

## A ideia em uma frase

> "Um subject publica eventos; observers assinam e reagem — nenhum dos dois sabe os detalhes do outro."

---

## Analogia para memorização

Pense nas **notificações push do celular**.  
O aplicativo de e-commerce (subject) publica "pedido enviado".  
Seu celular, seu smartwatch e o e-mail do comprador (observers) reagem cada um à sua forma.  
O e-commerce não sabe quantos dispositivos existem — só publica.  
Você pode desinstalar do smartwatch (desinscrever) sem o e-commerce perceber.

---

## Os papéis

| Papel | No exemplo | Responsabilidade |
|---|---|---|
| **Subject** | `Pedido` | guarda lista de observers; notifica ao mudar estado |
| **Observer** | `IObserver` | contrato: `Atualizar(numeroPedido, status)` |
| **Concrete Observer** | `ServicoDeEmail`, `ControleDeEstoque`, `ProgramaDeFidelidade`, `SistemaDeRastreio` | reagem ao evento cada um à sua forma |

```csharp
// Subject publica — não sabe quem está ouvindo
public void AtualizarStatus(StatusPedido novoStatus)
{
    _status = novoStatus;
    Notificar(); // dispara para todos os inscritos
}

public void Notificar()
{
    foreach (var observer in _observers)
        observer.Atualizar(NumeroPedido, _status); // só conhece a interface
}
```

---

## Como lembrar: o fluxo é **1 → N**

```
[Subject: Pedido]
    │  AtualizarStatus(Enviado)
    └─ Notificar()
         ├─→ [ServicoDeEmail].Atualizar()       → envia e-mail
         ├─→ [ControleDeEstoque].Atualizar()    → baixa estoque
         └─→ [SistemaDeRastreio].Atualizar()    → gera código
```

O subject só conhece `IObserver`.  
Cada observer reage de forma independente.

---

## Dinâmica de assinatura

```csharp
pedido.Inscrever(new ProgramaDeFidelidade("123.456.789-00")); // assina
// ... mudanças recebidas normalmente ...
pedido.Desinscrever(fidelidade);                              // cancela
pedido.AtualizarStatus(StatusPedido.Cancelado);              // fidelidade não recebe
```

---

## Quando usar

- Eventos de domínio: status de pedido, alertas de estoque, notificações.
- UI reativa: quando o modelo muda, a view precisa atualizar (MVC/MVVM).
- Sistemas de mensageria leve (pub/sub local).

## Quando **não** usar

- Poucos observers e raramente mudam — acoplamento direto é mais simples.
- Cadeia de observers que dependem um do outro — a ordem de notificação pode criar dependências ocultas.
- Quando o subject precisa de resposta do observer — Observer é fire-and-forget; use outro padrão (Chain of Responsibility, Command).

---

## Diferença: Observer vs Event (C#)

| | Observer (padrão GoF) | `event` em C# |
|---|---|---|
| **Mecanismo** | Interface `IObserver` | delegados e eventos |
| **Tipagem** | manual | fortemente tipado pelo delegate |
| **Desinscrição** | `Desinscrever(obj)` | `-= handler` |
| **Quando usar** | controle fino de lista | integração com ecossistema .NET |

Na prática, eventos C# **implementam o padrão Observer** — a interface `IObserver` é substituída pelo delegate.

---

## Armadilhas comuns

1. **Ordem de notificação importa** — se observers têm dependências entre si, o resultado muda com a ordem de inscrição.
2. **Observer esquecido inscrito** — memory leak se o observer viver menos que o subject. Use `Desinscrever` explicitamente ou `WeakReference`.
3. **Subject notifica com frequência alta** — pode degradar performance. Considere coalescing (agrupe notificações).
4. **Exceção em um observer derruba os outros** — envolva cada `Atualizar` em try/catch no `Notificar` em cenários críticos.

---

## Extensão sem dor (OCP)

Chegou integração com SMS?  
Crie `ServicoDeSmS : IObserver` e implemente `Atualizar`.  
Inscreva no pedido.  
`Pedido.Notificar()` não muda uma linha.
