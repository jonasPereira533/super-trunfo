using Xunit;
using SuperTrunfo;

namespace SuperTrunfo.Tests
{
    // A Batalha não escreve mais no Console, então não precisamos
    // redirecionar a saída para testar.
    public class IniciarBatalhaTests
    {
        private const string ATRIBUTO_ATAQUE = "Ataque";
        private const string ATRIBUTO_DEFESA = "Defesa";

        private readonly Batalha _batalha = new Batalha();

        [Fact]
        public void IniciarBatalha_WhenPokemon1HasHigherEffectiveValue_ReturnsJogador1()
        {
            // Arrange
            var pokemon1 = new Pokemon { Nome = "Charmander", TipoElemento = Elementos.Fogo, Ataque = 50 };
            var pokemon2 = new Pokemon { Nome = "Bulbasaur", TipoElemento = Elementos.Planta, Ataque = 50 };

            // Act
            var resultado = _batalha.IniciarBatalha(pokemon1, pokemon2, ATRIBUTO_ATAQUE);

            // Assert
            Assert.Equal(ResultadoRodada.Jogador1, resultado.Vencedor);
        }

        [Fact]
        public void IniciarBatalha_WhenPokemon2HasHigherEffectiveValue_ReturnsJogador2()
        {
            // Arrange
            var pokemon1 = new Pokemon { Nome = "Bulbasaur", TipoElemento = Elementos.Planta, Ataque = 50 };
            var pokemon2 = new Pokemon { Nome = "Charmander", TipoElemento = Elementos.Fogo, Ataque = 50 };

            // Act
            var resultado = _batalha.IniciarBatalha(pokemon1, pokemon2, ATRIBUTO_ATAQUE);

            // Assert
            Assert.Equal(ResultadoRodada.Jogador2, resultado.Vencedor);
        }

        [Fact]
        public void IniciarBatalha_WhenBothHaveEqualEffectiveValue_ReturnsEmpate()
        {
            // Arrange
            var pokemon1 = new Pokemon { Nome = "Charmander", TipoElemento = Elementos.Fogo, Ataque = 50 };
            var pokemon2 = new Pokemon { Nome = "Growlithe", TipoElemento = Elementos.Fogo, Ataque = 50 };

            // Act
            var resultado = _batalha.IniciarBatalha(pokemon1, pokemon2, ATRIBUTO_ATAQUE);

            // Assert
            Assert.Equal(50m, resultado.ValorJogador1);
            Assert.Equal(50m, resultado.ValorJogador2);
            Assert.Equal(ResultadoRodada.Empate, resultado.Vencedor);
        }

        [Fact]
        public void IniciarBatalha_WhenAttackerHasTypeAdvantage_DoublesTheEffectiveValue()
        {
            // Arrange
            var pokemon1 = new Pokemon { Nome = "Charmander", TipoElemento = Elementos.Fogo, Ataque = 50 };
            var pokemon2 = new Pokemon { Nome = "Bulbasaur", TipoElemento = Elementos.Planta, Ataque = 50 };

            // Act
            var resultado = _batalha.IniciarBatalha(pokemon1, pokemon2, ATRIBUTO_ATAQUE);

            // Assert
            Assert.Equal(100m, resultado.ValorJogador1);
        }

        [Fact]
        public void IniciarBatalha_WhenAttackerHasTypeDisadvantage_HalvesTheEffectiveValue()
        {
            // Arrange
            var pokemon1 = new Pokemon { Nome = "Bulbasaur", TipoElemento = Elementos.Planta, Ataque = 50 };
            var pokemon2 = new Pokemon { Nome = "Charmander", TipoElemento = Elementos.Fogo, Ataque = 50 };

            // Act
            var resultado = _batalha.IniciarBatalha(pokemon1, pokemon2, ATRIBUTO_ATAQUE);

            // Assert
            Assert.Equal(25m, resultado.ValorJogador1);
        }

        [Fact]
        public void IniciarBatalha_WhenAttributeIsDefesa_UsesDefesaAndAppliesTypeMultiplier()
        {
            // Arrange
            // Squirtle (Agua) defendendo contra Planta tem desvantagem: 100 x 0,5 = 50.
            // Bulbasaur (Planta) contra Agua tem vantagem: 10 x 2 = 20.
            // Se o metodo usasse Ataque em vez de Defesa, o vencedor seria o Jogador 2.
            var pokemon1 = new Pokemon { Nome = "Squirtle", TipoElemento = Elementos.Agua, Ataque = 10, Defesa = 100 };
            var pokemon2 = new Pokemon { Nome = "Bulbasaur", TipoElemento = Elementos.Planta, Ataque = 10, Defesa = 10 };

            // Act
            var resultado = _batalha.IniciarBatalha(pokemon1, pokemon2, ATRIBUTO_DEFESA);

            // Assert
            Assert.Equal(50m, resultado.ValorJogador1);
            Assert.Equal(20m, resultado.ValorJogador2);
            Assert.Equal(ResultadoRodada.Jogador1, resultado.Vencedor);
        }

        [Fact]
        public void IniciarBatalha_WhenAttributeIsInvalid_ThrowsAtributoInvalidoException()
        {
            // Arrange
            var pokemon1 = new Pokemon { Nome = "Charmander", TipoElemento = Elementos.Fogo, Ataque = 50 };
            var pokemon2 = new Pokemon { Nome = "Bulbasaur", TipoElemento = Elementos.Planta, Ataque = 50 };

            // Act + Assert
            Assert.Throws<AtributoInvalidoException>(
                () => _batalha.IniciarBatalha(pokemon1, pokemon2, "Velocidade"));
        }
    }
}
