# Factory Method — Tutorial

## O problema que resolve

Você tem um **algoritmo fixo** (ex.: "preparar → enviar → logar") mas o objeto criado no meio varia.  
Quer que subclasses decidam o que criar, sem alterar o fluxo principal.

---

## A ideia em uma frase

> "O algoritmo fica na classe base; **um único ponto de criação** é sobrescrito pelas subclasses."

---

## Analogia para memorização

Pense numa **receita de bolo genérica**: misture os ingredientes, asse por 40 min, decore.  
A receita não muda.  
Mas cada confeiteiro escolhe *que ingredientes* colocar — um usa chocolate, outro baunilha.  
O "escolher ingredientes" é o Factory Method.

---

## Os três papéis

| Papel | No exemplo | Responsabilidade |
|---|---|---|
| **Abstract Creator** | `NotificacaoService` | define `Notificar()` (template) e declara `CriarMensagem()` como abstrato |
| **Concrete Creator** | `EmailNotificacaoService` | sobrescreve só `CriarMensagem()` |
| **Product** | `IMensagem` / `EmailMensagem` | o que é criado |

```csharp
// Creator abstrato — o algoritmo nunca muda
public void Notificar(string destinatario, string conteudo)
{
    var mensagem = CriarMensagem(destinatario, conteudo); // ← Factory Method
    mensagem.Preparar();
    mensagem.Enviar();
    mensagem.RegistrarLog();
}

// Concrete Creator — só isso precisa mudar
protected override IMensagem CriarMensagem(string destinatario, string conteudo)
    => new EmailMensagem(destinatario, conteudo);
```

---

## Como lembrar: a criação é **interna** à hierarquia

```
[Creator] → template usa → CriarMensagem()
                               ↑
                    [Concrete Creator] sobrescreve
```

Ao contrário do Abstract Factory, nada é **injetado de fora**.  
A variação vem da **herança** de dentro.

---

## Diferença crucial: Factory Method vs Abstract Factory

| | Factory Method | Abstract Factory |
|---|---|---|
| **De onde vem?** | Dentro da hierarquia (herança) | Injetada de fora (composição) |
| **Quantos produtos?** | Um | Família |
| **Extensão** | Nova subclasse | Nova factory |

---

## SOLID & OOP

### Pilares OOP em ação

| Pilar | Como aparece |
|---|---|
| **Herança** | Mecanismo central — a subclasse existe *apenas* para sobrescrever `CriarMensagem()` |
| **Polimorfismo** | `Notificar()` chama `CriarMensagem()` e recebe `EmailMensagem`, `SmsMensagem` ou `PushMensagem` em runtime |
| **Abstração** | `IMensagem` e a classe abstrata `NotificacaoService` isolam o que varia do que é fixo |
| **Encapsulamento** | O Creator esconde qual classe concreta foi instanciada; o cliente vê só `Notificar()` |

### Princípios SOLID

| Princípio | Situação | Como o padrão atende |
|---|---|---|
| **SRP** | Quem define o fluxo vs. quem decide o que criar | Creator controla o algoritmo; Concrete Creator decide a instanciação |
| **OCP** | Novo canal (WhatsApp) | Nova subclasse — `Notificar()` não toca |
| **LSP** | Concrete Creators | Qualquer `NotificacaoService` concreto pode substituir o abstrato sem quebrar `NotificacaoServiceSelector` |
| **ISP** | `IMensagem` | Expõe só os três passos do fluxo (`Preparar`, `Enviar`, `RegistrarLog`) |
| **DIP** | `Notificar()` depende de `IMensagem` | O template method não sabe qual classe concreta foi criada — depende da abstração |

> **Herança aqui é necessária**, ao contrário do que DIP normalmente sugere. O padrão usa herança *controlada*: apenas um método varia.

## Quando usar

- Um algoritmo fixo com um ponto de variação (qual objeto criar).
- Frameworks onde o framework define o esqueleto, o usuário define a criação.
- Substituir condicionais `switch` para decidir qual classe instanciar.

## Quando **não** usar

- Você precisa criar famílias de objetos → Abstract Factory.
- A lógica de criação é trivial → `new` direto ou factory estático simples.

---

## Armadilhas comuns

1. **Colocar lógica de negócio no Factory Method** — ele só cria.
2. **Sobrescrever o método template** nas subclasses — só o Factory Method deve variar.
3. **Confundir com Abstract Factory** — lembre: Factory Method é herança, Abstract Factory é composição.

---

## Extensão sem dor (OCP)

Chegou canal WhatsApp? Crie `WhatsAppNotificacaoService` e implemente `CriarMensagem`.  
`Notificar` e `NotificacaoServiceSelector` ficam praticamente intactos.
