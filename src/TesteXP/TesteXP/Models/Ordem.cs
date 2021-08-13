using System;
using TesteXP.Enums;

namespace TesteXP.Models
{
    public class Ordem
    {
        public Ordem() { }

        public Ordem(
            ulong id,
            DateTime dataHora,
            Assessor assessor,
            uint conta,
            string ativo,
            EnumTipo tipo,
            int quantidade,
            int quantidadeAparente,
            int quantidadeDisponivel,
            int quantidadeCancelada,
            int quantidadeExecutada,
            decimal valor,
            decimal valorDisparo,
            decimal objetivo,
            decimal objetivoDisparo,
            double reducao)
        {
            Id = id;
            DataHora = dataHora;
            Assessor = assessor;
            Conta = conta;
            Ativo = ativo;
            Tipo = tipo;
            Quantidade = quantidade;
            QuantidadeAparente = quantidadeAparente;
            QuantidadeDisponivel = quantidadeDisponivel;
            QuantidadeCancelada = quantidadeCancelada;
            QuantidadeExecutada = quantidadeExecutada;
            Valor = valor;
            ValorDisparo = valorDisparo;
            Objetivo = objetivo;
            ObjetivoDisparo = objetivoDisparo;
            Reducao = reducao;
        }

        public ulong Id { get; set; }
        public DateTime DataHora { get; set; }
        public Assessor Assessor { get; set; }
        public uint Conta { get; set; }
        public string Ativo { get; set; }
        public EnumTipo Tipo { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeAparente { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public int QuantidadeCancelada { get; set; }
        public int QuantidadeExecutada { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorDisparo { get; set; }
        public decimal Objetivo { get; set; }
        public decimal ObjetivoDisparo { get; set; }
        public double Reducao { get; set; }
    }
}
