﻿using System.ComponentModel.DataAnnotations;

namespace infnet_bl6_fdaN_tp3.Models
{
    public class Pessoa
    {
        #region atributos
        private int _pessoaId;
        private string _nome;
        private string _sobrenome;
        private DateTime _dataNascimento;
        #endregion

        #region propriedades
        public int PessoaId
        {
            get { return _pessoaId; }
            set { _pessoaId = value; }
        }
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Sobrenome
        {
            get { return _sobrenome; }
            set { _sobrenome = value; }
        }

        [DataType(DataType.Date)]
        public DateTime DataNascimento
        {
            get { return _dataNascimento; }
            set { _dataNascimento = value; }
        }
        public string NomeCompleto
        {
            get { return _nome + " " + _sobrenome; }
        }

        public List<Pessoa> Pessoas = new List<Pessoa>();
        #endregion

        #region métodos
        public Pessoa() { }

        public DateOnly ProximoAniversario()
        {

            DateTime dataProximoAniversario = new DateTime(DateTime.Now.Year, _dataNascimento.Month, _dataNascimento.Day, 0, 0, 0);
            if (DateTime.Compare(dataProximoAniversario, DateTime.Now) < 0)
            {
                dataProximoAniversario = dataProximoAniversario.AddYears(1);
            }
            return DateOnly.FromDateTime(dataProximoAniversario);
        }
        public int CalculaDiasFaltantes()
        {
            DateTime dataAtual = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            DateOnly dataAniversario = ProximoAniversario();
            DateTime dataProximoAniversario = dataAniversario.ToDateTime(TimeOnly.Parse("00:00"));

            if (dataAtual.Month == dataAniversario.Month &&
                dataAtual.Day == dataAniversario.Day)
            {
                return 0;
            }
            int difDatas = (int)dataAtual.Subtract(dataProximoAniversario).TotalDays;
            if (difDatas < 0) { difDatas = difDatas * -1; }

            return difDatas;
        }
        #endregion
    }
}