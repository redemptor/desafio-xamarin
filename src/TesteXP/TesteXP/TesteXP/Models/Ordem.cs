using System;
using TesteXP.Enums;

namespace TesteXP.Models
{
    public class Ordem
    {
        public DateTime DataHora { get; set; }
        public Acessor Assessor { get; set; }
        public uint Conta { get; set; }
        public string Ativo { get; set; }
        public EnumTipo Tipo { get; set; }
        public uint Quantidade { get; set; }
        public uint QuantidadeAparente { get; set; }
        public uint QuantidadeDisponivel { get; set; }
        public uint QuantidadeCancelada { get; set; }
        public uint QuantidadeExecutada { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorDisparo { get; set; }
        public decimal Objetivo { get; set; }
        public decimal ObjetivoDisparo { get; set; }
        public float Reducao { get; set; }
    }
}
