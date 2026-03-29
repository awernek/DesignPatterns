# Adapter — Tutorial

## O problema que resolve

Você quer usar uma classe externa (SDK, API legada) mas ela tem **interface incompatível** com o que seu sistema espera.  
Não pode modificar nenhum dos dois lados.

---

## A ideia em uma frase

> "Uma classe no meio que traduz a linguagem do cliente para a linguagem do Adaptee — sem alterar nenhum dos dois."

---

## Analogia para memorização

Pense num **adaptador de tomada elétrica** de viagem.  
Sua ferramenta tem pino de três entradas (padrão BR).  
A tomada do hotel é de dois pinos (padrão EU).  
O adaptador encaixa dos dois lados e converte — você não mudou a ferramenta, não mudou a tomada.

---

## Os três papéis

| Papel | No exemplo | Responsabilidade |
|---|---|---|
| **Target** | `IProcessadorPagamento` | interface que o seu sistema conhece |
| **Adaptee** | `PagSeguroApi` | classe externa com API incompatível |
| **Adapter** | `PagSeguroAdapter` | implementa Target, delega para Adaptee |

```csharp
public class PagSeguroAdapter : IProcessadorPagamento   // fala a língua do cliente
{
    private readonly PagSeguroApi _pagSeguro;           // conhece o Adaptee

    public bool ProcessarPagamento(string cartao, decimal valor, string moeda)
    {
        // converte decimal → double; ignora moeda (Adaptee não usa)
        var id = _pagSeguro.IniciarTransacao(cartao, (double)valor);
        return !string.IsNullOrEmpty(id);               // converte string → bool
    }
}
```

---

## Como lembrar: o Adapter é o **único** que conhece os dois lados

```
[Cliente]  →  [IProcessadorPagamento]  ←implements─  [PagSeguroAdapter]  →  [PagSeguroApi]
                (Target)                                (Adapter)              (Adaptee)
```

O cliente só enxerga o Target.  
O Adaptee só enxerga suas próprias chamadas.  
O Adapter é a cola invisível.

---

## Dois sabores de Adapter

| | Object Adapter (este exemplo) | Class Adapter |
|---|---|---|
| **Como acessa o Adaptee** | Composição (campo) | Herança múltipla |
| **Flexível em runtime?** | Sim (injeta no construtor) | Não |
| **Disponível em C#** | Sim | Não (C# não tem herança múltipla) |

Prefira sempre **Object Adapter** em C#.

---

## Quando usar

- Integrar SDKs de terceiros sem contaminar o domínio.
- Manter código legado funcional enquanto migra para nova interface.
- Criar camada anti-corrupção entre seu domínio e sistemas externos.

## Quando **não** usar

- Você controla os dois lados — renomeie ou refatore diretamente.
- O Adaptee tem dezenas de métodos e você usa todos — provavelmente é o mesmo contrato, não precisa de Adapter.

---

## Armadilhas comuns

1. **Adapter com lógica de negócio** — ele só converte; regras pertencem ao domínio.
2. **Criar Adapter para tudo** — se a interface já é compatível, adiciona complexidade sem benefício.
3. **Adaptar o Adaptee parcialmente e esquecer casos** — documente quais campos são descartados e por quê.

---

## Extensão sem dor (OCP)

Chegou integração com Stripe?  
Crie `StripeAdapter : IProcessadorPagamento` + `StripeApi`.  
`ServicoDeCheckout` não muda uma linha.
