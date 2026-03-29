# Command — Tutorial

## O problema que resolve

Você precisa **desfazer e refazer** ações, enfileirá-las, auditá-las ou agendá-las — sem o cliente saber o que cada ação faz internamente.

---

## A ideia em uma frase

> "Encapsule uma ação como objeto — assim você pode armazená-la, desfazê-la e refazê-la."

---

## Analogia para memorização

Pense no **Ctrl+Z / Ctrl+Y do Word**.  
Quando você digita uma letra, o Word não simplesmente a insere — ele cria um objeto "InserirLetraA" com o estado necessário para desfazer.  
A pilha de undo é uma pilha desses objetos.  
O Word (Invoker) não sabe o que cada objeto faz — só chama `Execute` e `Undo`.

---

## Os quatro papéis

| Papel | No exemplo | Responsabilidade |
|---|---|---|
| **Command** | `ICommand` | `Execute()` e `Undo()` |
| **Concrete Command** | `AdicionarItemCommand` | encapsula ação + estado para reversão |
| **Receiver** | `Carrinho` | sabe executar a operação real |
| **Invoker** | `HistoricoCarrinho` | gerencia pilhas undo/redo sem saber o que executa |

```csharp
// Concrete Command guarda o mínimo para desfazer
public void Execute()
{
    var item = _carrinho.Itens.FirstOrDefault(i => i.Produto == _produto);
    _quantidadeAnterior = item?.Quantidade ?? 0; // guarda estado anterior
    _carrinho.AlterarQuantidade(_produto, _novaQuantidade);
}

public void Undo() => _carrinho.AlterarQuantidade(_produto, _quantidadeAnterior);
```

---

## Como lembrar: o comando é **um objeto com memória**

```
[Invoker]  →  Executar(cmd)  →  cmd.Execute()  →  [Receiver]
                 push undo ↑
            Desfazer()       →  cmd.Undo()     →  [Receiver]
```

O Invoker gerencia **pilhas**.  
O Command guarda **estado suficiente para reverter**.  
O Receiver **sabe fazer a operação real**.

---

## O que cada Command guarda para desfazer

| Comando | Estado guardado |
|---|---|
| `AdicionarItemCommand` | produto, quantidade, preço |
| `AlterarQuantidadeCommand` | `_quantidadeAnterior` (capturada no `Execute`) |
| `AplicarCupomCommand` | cupom e desconto (para remover no `Undo`) |

---

## Quando usar

- Undo/Redo (editores, carrinho, gráficos).
- Fila de comandos para execução assíncrona ou agendada.
- Histórico de auditoria (log de operações).
- Macro: executar uma sequência de comandos como se fosse um.

## Quando **não** usar

- Operações simples sem necessidade de reversão — adiciona cerimônia desnecessária.
- Quando o estado para reverter seria muito custoso de armazenar.

---

## Diferença: Command vs Strategy

| | Command | Strategy |
|---|---|---|
| **Objetivo** | Encapsular uma *ação* (com undo) | Encapsular um *algoritmo* intercambiável |
| **Tem estado interno?** | Sim (para reverter) | Geralmente não |
| **É armazenado?** | Sim (pilha undo) | Não |

---

## Armadilhas comuns

1. **Capturar o estado para undo após a operação** — capture **antes** de executar (como `_quantidadeAnterior`).
2. **Invoker com lógica de negócio** — ele só gerencia pilhas; regras ficam no Receiver.
3. **Undo sem testar o estado atual** — uma sequência de undos pode chegar a estado inválido se o Receiver não validar.
4. **Refazer sem limpar a pilha de redo** — ao executar um novo comando, o redo deve ser zerado.
