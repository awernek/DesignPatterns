# Composite — Tutorial

## O problema que resolve

Você tem objetos que formam **estruturas de árvore**: arquivos dentro de pastas dentro de pastas.  
Quer que o cliente trate um arquivo individual e uma pasta com centenas de itens **exatamente da mesma forma**.

---

## A ideia em uma frase

> "Folhas e compostos implementam a mesma interface — o cliente nunca precisa saber com qual está lidando."

---

## Analogia para memorização

Pense no **tamanho de uma pasta no Windows**.  
Você clica com o botão direito em um arquivo ou em uma pasta — em ambos aparece "Propriedades → Tamanho".  
Para o sistema operacional, a operação é **idêntica**.  
A pasta calcula delegando para seus filhos; o arquivo retorna seu próprio tamanho.

---

## Os três papéis

| Papel | No exemplo | Responsabilidade |
|---|---|---|
| **Component** | `IComponente` | interface comum: `ObterTamanho()`, `Exibir()` |
| **Leaf** | `Arquivo` | sem filhos; responde por si mesmo |
| **Composite** | `Pasta` | contém `List<IComponente>`; delega para os filhos |

```csharp
// Composite: delega para os filhos — que podem ser folhas ou outros compostos
public long ObterTamanho() => _filhos.Sum(f => f.ObterTamanho());

// Leaf: responde diretamente
public long ObterTamanho() => _tamanhoBytes;
```

---

## Como lembrar: a recursão é **transparente**

```
IComponente
├── Arquivo (Leaf)         → retorna próprio tamanho
└── Pasta (Composite)      → soma os filhos
        ├── Arquivo (Leaf)
        └── Pasta (Composite)
                └── Arquivo (Leaf)
```

O cliente chama `raiz.ObterTamanho()` e não sabe quantos níveis existem.  
A recursão acontece naturalmente.

---

## Quando usar

- Estruturas hierárquicas: sistema de arquivos, menu/submenu, organograma, componentes de UI, carrinho com sub-kits.
- Quando o cliente deve tratar objetos individuais e coleções uniformemente.

## Quando **não** usar

- Estrutura plana sem hierarquia — use lista simples.
- Quando folha e composto têm comportamentos radicalmente diferentes — a interface comum vira abstração forçada.

---

## Diferença: Composite vs Decorator

| | Composite | Decorator |
|---|---|---|
| **Objetivo** | Estrutura em árvore | Adicionar comportamento dinamicamente |
| **Filhos?** | Sim (lista) | Um (wrapping) |
| **Profundidade** | Ilimitada | Geralmente uma camada |

---

## Armadilhas comuns

1. **Colocar métodos `Adicionar`/`Remover` na interface `IComponente`** — folhas teriam que lançar `NotSupportedException`, o que é confuso. Prefira expô-los só em `Pasta`.
2. **Esquecer a validação de nulo ao adicionar** — `Adicionar(null)` pode causar NullReferenceException silencioso na próxima travessia.
3. **Referência cíclica** — uma `Pasta` que contém a si mesma causa loop infinito em `ObterTamanho`. Considere validação se o domínio permitir.

---

## Extensão sem dor (OCP)

Quer um `ArquivoComprimido` que computa o tamanho diferente?  
Implemente `IComponente` e adicione à pasta normalmente.  
`Pasta.ObterTamanho()` não muda.
