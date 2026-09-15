# Super Trunfo Pokémon

Trabalho acadêmico de Programação — UGB/FERP.
Aplicação de console em C# (.NET 10) que implementa o jogo Super Trunfo com a
temática Pokémon, usando classes, tratamento de exceções e testes de unidade.

## Como rodar

```bash
dotnet run --project SuperTrunfo
```

## Como rodar os testes

```bash
dotnet test
```

## Regras do jogo

1. Cada jogador digita seu nome e escolhe **3 pokémons** da Pokédex (9 cartas, 3 de cada tipo).
   Um jogador não pode repetir a mesma carta no próprio baralho (os dois jogadores podem, sim, escolher a mesma carta).
2. As cartas são jogadas na ordem em que foram escolhidas (o baralho é uma fila, `Queue`).
3. A cada rodada, os dois jogadores viram uma carta e um atributo é escolhido: **Ataque** ou **Defesa**.
4. O valor do atributo é multiplicado pela **efetividade do tipo**:

   | Atacante | Defensor | Multiplicador |
   |---|---|---|
   | Fogo | Planta | 2x |
   | Planta | Água | 2x |
   | Água | Fogo | 2x |
   | Planta | Fogo | 0,5x |
   | Água | Planta | 0,5x |
   | Fogo | Água | 0,5x |
   | tipos iguais | — | 1x |

5. Quem tiver o maior valor efetivo vence a rodada. Ao fim das 3 rodadas, quem venceu mais rodadas vence o jogo.

## Classes do projeto

| Classe | Responsabilidade |
|---|---|
| `Pokemon` | A carta: Nome, Ataque, Defesa, TipoElemento. `ObterAtributo` devolve o valor pedido. |
| `Elementos` | Enum com os tipos: Fogo, Planta, Agua. |
| `Pokedex` | Classe estática com a lista de cartas disponíveis. |
| `Jogador` | Nome e baralho (`Queue<Pokemon>`). `EscolherPokemon` e `ProximoPokemon`. |
| `Batalha` | `IniciarBatalha` calcula o resultado da rodada; `Efetivo` aplica a tabela de tipos. Não escreve na tela. |
| `ResultadoBatalha` | Guarda o resultado calculado: valores dos dois jogadores e o vencedor. |
| `ResultadoRodada` | Enum: Empate, Jogador1, Jogador2. |
| `ConsoleUI` | Classe estática responsável por tudo que aparece na tela. |
| `SuperTrunfoException` | Classe base das exceções do jogo. |
| `AtributoInvalidoException` | Atributo digitado não é Ataque nem Defesa. |
| `BaralhoCheioException` | Tentativa de adicionar uma carta além do limite de 3. |
| `PokemonDuplicadoException` | Carta já presente no baralho. |
| `BaralhoVazioException` | Tentativa de jogar sem cartas no baralho. |

## Tratamento de exceções

As classes de domínio (`Pokemon`, `Jogador`) **lançam** as exceções; o `Program`
**captura** e trata. São três níveis de `try/catch`:

- **Externo**, envolvendo o jogo inteiro: `catch (SuperTrunfoException)` para erros de
  regra, `catch (Exception)` como rede de segurança e um `finally` que sempre executa.
- **Na escolha das cartas**: `FormatException` (letras), `OverflowException` (número
  gigante), `ArgumentOutOfRangeException` (número fora da lista) e `PokemonDuplicadoException`.
- **Na escolha do atributo**: `AtributoInvalidoException`, lançada pela própria classe `Pokemon`.

Em todos os casos o jogo avisa em vermelho e pergunta de novo, sem encerrar.

## Testes de unidade

Projeto `test-super-trunfo`, com xUnit, no padrão Arrange/Act/Assert.

| Classe de teste | O que cobre |
|---|---|
| `EfetivoTests` | A tabela de efetividade completa, com `[Theory]` + `[InlineData]`. |
| `IniciarBatalhaTests` | Vitória de cada jogador, empate, aplicação do multiplicador, disputa por Defesa e propagação de `AtributoInvalidoException`. |
| `PokemonTests` | `ObterAtributo` nos caminhos válidos, com maiúsculas/espaços, e as exceções. |
| `JogadorTests` | Nome vazio, limite de 3 cartas, carta repetida, ordem FIFO e baralho vazio. |

## Repositório

https://github.com/jonasPereira533/super-trunfo
