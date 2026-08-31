using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTrunfo
{
    public class Jogador
    {
        public string nome { get; internal set; }
        public Pokemon pokemon { get; set; }
        public Jogador( string nome, Pokemon pokemon) {
            this.nome = nome;
            this.pokemon = pokemon;
        }
       
    }
}
