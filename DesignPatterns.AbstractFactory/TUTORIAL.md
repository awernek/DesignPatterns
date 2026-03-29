# Abstract Factory — Tutorial

## O problema que resolve

Você precisa criar **famílias de objetos relacionados** (ex.: veículo + guincho do mesmo porte) garantindo que os produtos combinem entre si — sem que o cliente saiba qual família concreta está sendo criada.

---

## A ideia em uma frase

> "Receba uma fábrica de fora → use-a para criar todos os produtos da mesma família."

---

## Analogia para memorização

Pense num **fornecedor de montagem de carros**.  
Você pede ao fornecedor (Factory) de veículos pequenos e recebe parafusos pequenos, rodas pequenas e motor pequeno — todos compatíveis.  
Se trocar o fornecedor por um de veículos grandes, tudo muda junto.  
Você nunca mistura peças de fornecedores diferentes.

---

## Os três papéis

| Papel | No exemplo | Responsabilidade |
|---|---|---|
| **Abstract Factory** | `IAutoSocorroFactory` | define os métodos `CriarVeiculo` e `CriarGuincho` |
| **Concrete Factory** | `SocorroVeiculoPequenoFactory` | decide qual produto concreto criar |
| **Client** | `AutoSocorro` | recebe a factory e usa só a abstração |

```csharp
// Client só conhece a interface — nunca as classes concretas
public AutoSocorro(IAutoSocorroFactory factory, Veiculo veiculo)
{
    _veiculo = factory.CriarVeiculo(veiculo.Modelo, veiculo.Porte);
    _guincho = factory.CriarGuincho();
}
```

---

## Como lembrar: a fábrica é **injetada de fora**

```
[Cliente] ← recebe → [Factory (abstrata)]
                           ↓ delega
                    [Concrete Factory] → cria → [Produto A + Produto B]
```

A factory **entra no cliente** pelo construtor ou seletor.  
O cliente não faz `new`. A fábrica faz.

---

## Diferença crucial: Abstract Factory vs Factory Method

| | Abstract Factory | Factory Method |
|---|---|---|
| **De onde vem a factory?** | Injetada de fora | Vive dentro da própria classe |
| **Quantos produtos cria?** | Família inteira | Um produto |
| **Como estender?** | Nova classe de factory | Nova subclasse do Creator |

---

## SOLID & OOP

### Pilares OOP em ação

| Pilar | Como aparece |
|---|---|
| **Abstração** | `IAutoSocorroFactory`, `IVeiculo`, `IGuincho` — o cliente manipula só interfaces |
| **Polimorfismo** | `factory.CriarVeiculo()` retorna `VeiculoPequeno` ou `VeiculoGrande` sem o cliente saber |
| **Encapsulamento** | A factory concreta esconde qual classe instancia; o cliente nunca vê `new VeiculoPequeno()` |
| **Herança** | Secundário aqui; o padrão prefere **composição** (o cliente recebe a factory) |

### Princípios SOLID

| Princípio | Situação | Como o padrão atende |
|---|---|---|
| **SRP** | Quem cria vs. quem usa | Cada factory cria uma família; `AutoSocorro` só usa |
| **OCP** | Novo porte | Nova classe de factory — nenhuma classe existente muda |
| **LSP** | Substituição | `SocorroVeiculoPequenoFactory` pode substituir qualquer `IAutoSocorroFactory` sem surpresas |
| **ISP** | Interface da factory | Expõe só os métodos dos produtos da família — não vaza métodos irrelevantes |
| **DIP** | Dependência | `AutoSocorro` depende de `IAutoSocorroFactory` (abstração), não de fábricas concretas |

> DIP é o núcleo deste padrão: a inversão acontece porque a factory **entra de fora** pelo construtor.

## Quando usar

- Famílias de produtos que devem ser compatíveis entre si.
- Você quer isolar o código de criação do código de uso.
- Precisa trocar famílias inteiras em runtime (ex.: tema claro / escuro, ambiente de testes / produção).

## Quando **não** usar

- Você só precisa criar **um** tipo de objeto → use Factory Method ou um simples factory estático.
- A família tem apenas um produto → complexidade desnecessária.

---

## Armadilhas comuns

1. **Adicionar métodos que não fazem parte da família** na interface da factory — viola ISP.
2. **Fazer o cliente conhecer a factory concreta** — perde o ponto do padrão.
3. **Usar quando o Factory Method resolve** — Abstract Factory tem mais cerimônia.

---

## Extensão sem dor (OCP)

Novo porte surgiu? Crie `SocorroVeiculoExtraGrandeFactory` e implemente os dois métodos.  
`AutoSocorro` e `AutoSocorroFactorySelector` não mudam — só o seletor ganha um `case`.
