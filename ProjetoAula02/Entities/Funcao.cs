using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAula02.Entities
{
    /// <summary>
    /// Classe de modelo de dados para a entidade Função
    /// </summary>
    public class Funcao
    {
        private Guid _id;
        private string _descricao;

        public Guid Id {
            set {
                
                if(value == Guid.Empty)
                    throw new ArgumentException("Por favor, informe o id da função.");

                _id = value; 
            }
            get => _id;
        }

        public string Descricao {
            set {

                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Por favor, informe a descrição da função.");

                var regex = new Regex("^[A-Za-zÀ-Üà-ü\\s]{6,100}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Por favor, informe uma descrição válida.");

                _descricao = value; 
            }
            get => _descricao;
        }
    }
}
