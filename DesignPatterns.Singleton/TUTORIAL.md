# Singleton — Tutorial

## O problema que resolve

Certas responsabilidades precisam de **exatamente uma instância**: arquivo de log, pool de conexões, cache global, configuração.  
Criar múltiplas instâncias quebraria a consistência ou desperdiçaria recursos.

---

## A ideia em uma frase

> "Uma classe que garante que ela própria existe **no máximo uma vez** e fornece acesso global."

---

## Analogia para memorização

Pense no **presidente de um país**.  
Não importa quantas vezes alguém perguntar "quem é o presidente?" — a resposta é sempre a mesma pessoa.  
Você não elege um novo presidente a cada pergunta.

---

## As três peças

| Peça | No exemplo | Por quê existe |
|---|---|---|
| **Construtor `private`** | `private Logger()` | impede `new Logger()` de fora |
| **Instância `static`** | `private static Logger? _instancia` | a única cópia vive na classe, não em objetos |
| **Propriedade de acesso** | `public static Logger Instancia` | único ponto de entrada; cria se ainda não existe |

```csharp
public static Logger Instancia
{
    get
    {
        if (_instancia is null)
        {
            lock (_lock)                   // thread-safe
            {
                if (_instancia is null)    // double-check
                    _instancia = new Logger();
            }
        }
        return _instancia;
    }
}
```

---

## Como lembrar: as três regras

```
1. private constructor  →  ninguém faz new de fora
2. static field         →  a instância mora na classe, não em objetos
3. static property      →  único ponto de acesso, cria se necessário
```

---

## Por que double-check locking?

- **1º `if`**: evita o custo do `lock` quando a instância já existe (99% das vezes).
- **`lock`**: garante que só uma thread entre na seção crítica na criação.
- **2º `if`**: evita que a segunda thread (que esperou no `lock`) crie uma segunda instância.

---

## Quando usar

- Logger, pool de conexões, configuração da aplicação, cache em memória.
- Recurso compartilhado que deve ser único e consistente.

## Quando **não** usar

- Quando a instância única é só conveniente, não necessária → prefira injeção de dependência.
- Em testes: Singletons dificultam isolamento (use `ResetInstanciaParaTestes` interno, ou prefira DI).
- Quando diferentes partes da aplicação precisam de "instâncias únicas por escopo" → escopo de DI resolve melhor.

---

## Armadilhas comuns

1. **Singleton sem `lock`** — race condition em ambientes multi-thread.
2. **Singleton testável impossível** — exponha um método `internal` de reset para testes ou evite estado global.
3. **Usar Singleton para injeção de dependência** — DI containers já gerenciam ciclo de vida; Singleton manual vira dívida técnica.
4. **Confundir `static class` com Singleton** — classe estática não implementa interfaces, não tem herança, não é instanciável. Singleton é um objeto real.

---

## Singleton vs Static Class

| | Singleton | Static Class |
|---|---|---|
| Instância real | Sim | Não |
| Implementa interface | Sim | Não |
| Lazy initialization | Sim | N/A |
| Testabilidade | Com esforço | Difícil |
