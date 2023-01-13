using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAula02.Entities
{
    /// <summary>
    /// Classe de modelo de dados para a entidade Funcionário
    /// </summary>
    public class Funcionario
    {
        private Guid _id;
        private string _nome;
        private string _cpf;
        private string _matricula;
        private DateTime _dataAdmissao;
        private Funcao _funcao;

        /// <summary>
        /// Método para encapsulamento do atributo _id
        /// </summary>
        public Guid Id {
            set {

                if(value == Guid.Empty)
                    throw new ArgumentException("Por favor, informe um ID válido.");

                _id = value;
            }
            get => _id;
        }

        /// <summary>
        /// Método para encapsulamento do atributo _nome
        /// </summary>
        public string Nome {
            set {

                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Por favor, informe o nome do funcionário.");

                var regex = new Regex("^[A-Za-zÀ-Üà-ü\\s]{8,100}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Por favor, informe um nome válido.");

                _nome = value; 
            }
            get => _nome;
        }

        /// <summary>
        /// Método para encapsulamento do atributo _cpf
        /// </summary>
        public string Cpf {
            set {

                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Por favor, informe o cpf do funcionário.");

                var regex = new Regex("^[0-9]{11}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Por favor, informe um cpf com somente 11 dígitos numéricos.");

                _cpf = value; 
            }
            get => _cpf;
        }

        /// <summary>
        /// Método para encapsulamento do atributo _matricula
        /// </summary>
        public string Matricula {
            set {

                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Por favor, informe a matrícula do funcionário.");

                var regex = new Regex("^[A-Z0-9]{6,10}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Por favor, informe uma matrícula válida.");

                _matricula = value; 
            }
            get => _matricula;
        }

        /// <summary>
        /// Método para encapsulamento do atributo _dataAdmissao
        /// </summary>
        public DateTime DataAdmissao {
            set {

                if (value == DateTime.MinValue)
                    throw new ArgumentException("Por favor, informe a data de admissão do funcionário.");

                _dataAdmissao = value; 
            }
            get => _dataAdmissao;
        }

        /// <summary>
        /// Método para encapsulamento do atributo _funcao
        /// </summary>
        public Funcao Funcao {
            set { _funcao = value; }
            get => _funcao;
        }
    }
}
