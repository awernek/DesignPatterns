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
