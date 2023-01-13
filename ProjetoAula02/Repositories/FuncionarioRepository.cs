using Newtonsoft.Json;
using ProjetoAula02.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetoAula02.Repositories
{
    /// <summary>
    /// Classe para gravação dos dados de funcionário em arquivos
    /// </summary>
    public class FuncionarioRepository
    {
        /// <summary>
        /// Método para gravar os dados do funcionário em arquivo JSON
        /// </summary>
        public void ExportarJson(Funcionario funcionario)
        {
            //serializar os dados do funcionário para JSON
            var json = JsonConvert.SerializeObject(funcionario, Formatting.Indented);

            //abrindo um arquivo e gravar os dados
            using (var streamWriter = new StreamWriter($"c:\\temp\\funcionario_{funcionario.Id}.json"))
            {
                //escrever no arquivo
                streamWriter.WriteLine(json);
            }
        }

        /// <summary>
        /// Método para gravar os dados do funcionário em arquivo XML
        /// </summary>
        public void ExportarXml(Funcionario funcionario)
        {
            //serializar os dados do funcionário para XML
            var xml = new XmlSerializer(typeof(Funcionario));

            //abrindo um arquivo e gravar os dados
            using (var streamWriter = new StreamWriter($"c:\\temp\\funcionario_{funcionario.Id}.xml"))
            {
                //escrever no arquivo
                xml.Serialize(streamWriter, funcionario);
            }
        }
    }
}
