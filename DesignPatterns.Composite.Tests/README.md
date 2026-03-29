# Testes do Composite

Documentação executável do padrão **Composite** no exemplo de sistema de arquivos (pastas e arquivos).

## O que cada arquivo testa

| Arquivo | Ideia do padrão |
|--------|------------------|
| **FormatadorTamanhoBytesTests** | Formatação B / KB / MB usada igualmente por folha e composto. |
| **ArquivoTests** | Folha: tamanho próprio e validações. |
| **PastaTests** | Composto: soma recursiva, filhos, `Exibir` com indentação, `Adicionar(null)`. |
| **IComponentePolimorfismoTests** | Mesma operação `ObterTamanho()` via `IComponente` para folha e pasta. |
| **ExecucaoCompositeTests** | Demonstração completa da árvore do exemplo. |

## Como rodar

```bash
dotnet test DesignPatterns.Composite.Tests
```

## Conceitos que os testes evidenciam

1. **Uniformidade** — cliente pode tratar tudo como `IComponente`.
2. **Recursão** — `Pasta.ObterTamanho` delega aos filhos, que podem ser outras pastas.
3. **Transparência** — não é preciso ramificar “se arquivo então… se pasta então…” para obter tamanho ou exibir.
