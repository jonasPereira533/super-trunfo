using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTrunfo
{
    internal class Batalha
    {
        public void IniciarBatalha(Pokemon pokemon1, Pokemon pokemon2)
        {
            Console.WriteLine($"Batalha entre {pokemon1.Nome} e {pokemon2.Nome}!");
            Console.WriteLine($"Atributos de {pokemon1.Nome}: Ataque = {pokemon1.Ataque}, Defesa = {pokemon1.Defesa}");
            Console.WriteLine($"Atributos de {pokemon2.Nome}: Ataque = {pokemon2.Ataque}, Defesa = {pokemon2.Defesa}");
            if (pokemon1.Ataque > pokemon2.Defesa)
            {
                Console.WriteLine($"{pokemon1.Nome} venceu a batalha!");
            }
            else if (pokemon2.Ataque > pokemon1.Defesa)
            {
                Console.WriteLine($"{pokemon2.Nome} venceu a batalha!");
            }
            else
            {
                Console.WriteLine("A batalha terminou em empate!");
            }
        }

        public decimal Efetivo (Pokemon pokemon1, Pokemon pokemon2)
        {
            decimal efetivo = 0;
            if (pokemon1.Tipo == "Fogo" && pokemon2.Tipo == "Planta")
            {
                efetivo = 2;
            }
            else if (pokemon1.Tipo == "Planta" && pokemon2.Tipo == "Fogo")
            {
                efetivo = 0.5m;
            }
            else if (pokemon1.Tipo == "Agua" && pokemon2.Tipo == "Fogo")
            {
                efetivo = 2;
            }
            else if (pokemon1.Tipo == "Fogo" && pokemon2.Tipo == "Agua")
            {
                efetivo = 0.5m;
            }
            else if (pokemon1.Tipo == "Agua" && pokemon2.Tipo == "Planta")
            {
                efetivo = 0.5m;
            }
            else if (pokemon1.Tipo == "Planta" && pokemon2.Tipo == "Agua")
            {
                efetivo = 2;
            }
            else
            {
                efetivo = 1;
            }
            return efetivo;
        } 
    }
}
