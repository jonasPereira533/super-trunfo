

using SuperTrunfo;
;

Pokemon pokemon1 = new Pokemon
{
    Nome = "Charmander",
    Tipo = "Fogo",
    Ataque = 52,
    Defesa = 43,
    TipoElemento = Elementos.Fogo
};

Pokemon pokemon2 = new Pokemon
{
    Nome = "Bulbasaur",
    Tipo = "Planta",
    Ataque = 49,
    Defesa = 49,
    TipoElemento = Elementos.Planta
};

Pokemon pokemon3 = new Pokemon
{
    Nome = "Squirtle",
    Tipo = "Agua",
    Ataque = 48,
    Defesa = 65,
    TipoElemento = Elementos.Agua
};

Pokemon pokemon4 = new Pokemon
{
    Nome = "Magmar",
    Tipo = "Fogo",
    Ataque = 55,
    Defesa = 40,
    TipoElemento = Elementos.Fogo // Ajuste conforme necessário
};

Jogador jogador1 = new Jogador("Jonas", pokemon1);
Jogador jogador2 = new Jogador("Myrella", pokemon2);