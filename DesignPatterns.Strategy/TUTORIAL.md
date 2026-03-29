# Strategy — Tutorial

## O problema que resolve

Você tem um objeto (`Pedido`) cujo comportamento varia dependendo de uma escolha em runtime (qual modalidade de frete).  
Quer evitar `if/else` gigante ou `switch` que cresce a cada nova opção.

---

## A ideia em uma frase

> "Defina uma família de algoritmos, encapsule cada um e torne-os **intercambiáveis** — o contexto delega sem saber qual está usando."

---

## Analogia para memorização

Pense no **GPS do celular**.  
Você digita o destino e escolhe: carro, moto, a pé ou transporte público.  
O algoritmo de rota muda completamente — mas o GPS (contexto) não muda.  
Ele só chama "calcule rota" e a estratégia faz o trabalho.  
Troque a estratégia a qualquer momento sem reiniciar o GPS.

---

## Os três papéis

| Papel | No exemplo | Responsabilidade |
|---|---|---|
| **Strategy** | `IFreteStrategy` | interface do algoritmo intercambiável |
| **Concrete Strategy** | `CorreiosPacStrategy`, `TransportadoraExpressStrategy`, `RetiradaEmLojaStrategy` | cada um encapsula seu algoritmo |
| **Context** | `Pedido` | mantém referência à strategy; delega `CalcularFrete` e `PrazoEmDias` |

```csharp
// Context delega — não sabe qual algoritmo está usando
public void ExibirResumo()
{
    var frete = _strategy.CalcularFrete(PesoKg, DistanciaKm, ValorProduto);
    var prazo = _strategy.PrazoEmDias(DistanciaKm);
    // ... exibe resultados
}

// Troca em runtime sem instanciar novo contexto
public void TrocarStrategy(IFreteStrategy novaStrategy) => _strategy = novaStrategy;
```

---

## Como lembrar: a strategy é **injetada e substituível**

```
[Contexto] ──────────── tem ──────→ [IFreteStrategy]
                                         ↑
                            ┌────────────┼────────────┐
                     [PAC]        [Express]       [Loja]
```

Diferente de herança: o contexto **compõe** a strategy.  
A troca é simples como trocar o campo.

---

## Strategy vs Factory Method

| | Strategy | Factory Method |
|---|---|---|
| **O que varia** | O algoritmo de uso | O algoritmo de criação |
| **Como varia** | Composição (campo injetado) | Herança (subclasse sobrescreve) |
| **Substitui em runtime?** | Sim | Não (definido na herança) |

---

## Strategy vs Command

| | Strategy | Command |
|---|---|---|
| **Objetivo** | Algoritmo intercambiável | Ação encapsulada com undo |
| **Tem estado para reverter?** | Não | Sim |
| **É armazenado em pilha?** | Não | Sim (undo/redo) |

---

## Quando usar

- Múltiplas variações de algoritmo (ordenação, cálculo, validação, compressão).
- Eliminar `if/switch` que cresce toda vez que surge nova regra.
- Permitir que o usuário escolha o comportamento em runtime.

## Quando **não** usar

- Só existe uma variação — Strategy adiciona complexidade sem benefício.
- As variações raramente mudam — uma subclasse pode ser suficiente.

---

## Armadilhas comuns

1. **Context com lógica específica de uma strategy** — o context deve ser neutro; ele delega, não decide.
2. **Strategy com estado** — se a strategy acumula estado entre chamadas, pode causar bugs ao reutilizá-la em contextos diferentes.
3. **Expor detalhes do contexto para a strategy** — passe só o necessário como parâmetros de `CalcularFrete`.

---

## Extensão sem dor (OCP)

Chegou delivery por drone?  
Crie `DroneStrategy : IFreteStrategy`.  
`Pedido`, o loop de comparação e `ExecucaoStrategy` não mudam.
