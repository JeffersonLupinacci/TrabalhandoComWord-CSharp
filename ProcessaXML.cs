using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TrabalhandoComWord
{
    class ProcessaRoteiroXML
    {
        ListaDeRoteiros RoteirosExistentes = null;

        public List<String> ListRoteiros()
        {
            List<String> resultados = new List<String>();
            if (RoteirosExistentes != null)
                foreach (Roteiro r in RoteirosExistentes.Roteiros)
                    resultados.Add(r.Descricao);
            return resultados;
        }

        public void SalvarRoteiro(String descricao, String[] linhas)
        {
            if ((RoteirosExistentes != null) && (!string.IsNullOrEmpty(descricao)))
            {
                Roteiro roteiro = RoteiroExiste(descricao);
                if (roteiro == null)
                    RoteirosExistentes.Roteiros.Add(new Roteiro() { Descricao = descricao, Linhas = linhas });
                else
                    roteiro.Linhas = linhas;
                Salvar();
            }
        }

        public Roteiro RoteiroExiste(String descricao)
        {
            Carregar();
            Roteiro resultado = null;
            if ((RoteirosExistentes != null) && (RoteirosExistentes.Roteiros.Count > 0))
                foreach (Roteiro temp in RoteirosExistentes.Roteiros)
                    if (temp.Descricao == descricao) { resultado = temp; break; }
            return resultado;
        }

        public void RemoverRoteiro(String descricao)
        {
            if ((RoteirosExistentes != null) && (RoteirosExistentes.Roteiros.Count > 0))
                RoteirosExistentes.Roteiros.RemoveAll(x => x.Descricao == descricao);
            Salvar();
        }

        public ProcessaRoteiroXML()
        {
            Carregar();
        }

        private void Carregar()
        {
            RoteirosExistentes = null;
            if (File.Exists("Roteiros.xml"))
            {
                FileStream fs = new FileStream("Roteiros.xml", FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(ListaDeRoteiros));
                RoteirosExistentes = (ListaDeRoteiros)serializer.Deserialize(fs);
                fs.Close();
            }
            else
            {
                RoteirosExistentes = new ListaDeRoteiros();
                Salvar();
            }
        }

        private void Salvar()
        {
            if (RoteirosExistentes != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ListaDeRoteiros));
                FileStream fs = new FileStream("Roteiros.xml", FileMode.Create);
                serializer.Serialize(fs, RoteirosExistentes);
                fs.Close();
            }
        }

    }
}

public class Roteiro
{
    [XmlAttribute("Descricao", DataType = "string")]
    public String Descricao;

    [XmlArray("Linhas")]
    [XmlArrayItem("Linhas")]
    public String[] Linhas { get; set; }
}

[XmlRoot("Processador")]
[XmlInclude(typeof(Roteiro))]
public class ListaDeRoteiros
{
    [XmlArray("Roteiros")]
    [XmlArrayItem("Roteiro")]
    public List<Roteiro> Roteiros = new List<Roteiro>();
}

