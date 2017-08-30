using TrabalhandoComWord;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;


namespace TrabalhandoComWord
{
    public partial class FrmProcessamento : Form
    {

        // Object RPC
        Word.Application AplicativoWord;
        Word.Document DocumentoWord;

        // Atualização de Roteiros
        ProcessaRoteiroXML ProcessaRoteiro;

        // Constantes para serem repassados para o Object RPC
        Object ValorNulo = System.Reflection.Missing.Value;
        Object ValorVerdadeiro = true;
        Object ValorFalso = false;

        int TotalDeComandos = 0;

        public FrmProcessamento()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            btnExecutarRoteiro.Enabled = false;
            DialogSelecionarArquivo.FileName = "";
            lblAnaliseDoArquivo.Text = Properties.Resources.StatusSelecioneArquivoWord;

            ProcessaRoteiro = new ProcessaRoteiroXML();

            lstRoteiros.Items.Clear();
            foreach (String s in ProcessaRoteiro.ListRoteiros())
                lstRoteiros.Items.Add(s);

            popularGrade();
        }

        /// <summary>
        /// Seleciona o Documento de Word e Verifica quantos campos de formulário existem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelecionarDocumento_Click(object sender, EventArgs e)
        {
            DialogSelecionarArquivo.FileName = textBox1.Text;
            DialogSelecionarArquivo.ShowDialog();

            // Verificando a extensão do arquivo
            if (File.Exists(DialogSelecionarArquivo.FileName))
            {
                String Extensao = Path.GetExtension(DialogSelecionarArquivo.FileName).ToLower();
                textBox1.Text = "";
                if ((Extensao == ".doc") || (Extensao == ".docx"))
                    textBox1.Text = DialogSelecionarArquivo.FileName;
                else
                    MessageBox.Show(Properties.Resources.MensagemSelecioneArquivoWord);
            }

            lblAnaliseDoArquivo.Text = Properties.Resources.StatusAnalisandoArquivoWord;
            btnExecutarRoteiro.Enabled = false;
            Application.DoEvents(); //Processmessages;

            ManipulaMicrosoftWord(false, true, false);

        }

        private void ManipulaMicrosoftWord(bool ExibirWord, bool FecharWord, bool SalvarWord, List<string> DadosFormulario = null)
        {
            bool documentoAberto = false;

            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                // Abrindo o Microsoft Office
                TotalDeComandos = 0;
                try
                {
                    if (AplicativoWord == null) AplicativoWord = new Word.Application();
                    var test = AplicativoWord.Visible;
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    try { AplicativoWord = null; AplicativoWord = new Word.Application(); }
                    catch (Exception ex) { lblAnaliseDoArquivo.Text = ex.Message; }
                }

                // Abrindo o Handle do Documento do Word
                try
                {
                    if (DocumentoWord == null) DocumentoWord = new Word.Document();
                    var test = DocumentoWord.Name;
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    try { DocumentoWord = null; DocumentoWord = new Word.Document(); }
                    catch (Exception ex) { lblAnaliseDoArquivo.Text = ex.Message; }
                }

                // Fechando Arquivos Abertos Dentro do Handle
                try { DocumentoWord.Close(ref ValorFalso, ref ValorNulo, ref ValorNulo); }
                catch { try { DocumentoWord = null; DocumentoWord = new Word.Document(); } catch (Exception ex) { lblAnaliseDoArquivo.Text = ex.Message; } }

                // Abrindo o arquivo do usuário
                try
                {
                    DocumentoWord = AplicativoWord.Documents.Open(textBox1.Text,
                        ref ValorNulo, ref ValorNulo, ref ValorNulo, ref ValorNulo, ref ValorNulo, ref ValorNulo, ref ValorNulo, ref ValorNulo,
                        ref ValorNulo, ref ValorNulo, ref ValorNulo, ref ValorNulo, ref ValorNulo, ref ValorNulo, ref ValorNulo);
                    documentoAberto = true;
                }
                catch (Exception ex) { lblAnaliseDoArquivo.Text = ex.Message; }

                if (documentoAberto)
                {
                    TotalDeComandos = DocumentoWord.FormFields.Count;
                    lblAnaliseDoArquivo.Text = Properties.Resources.StatusAnaliseSemCampos;
                    btnExecutarRoteiro.Enabled = (TotalDeComandos > 0);
                    if (TotalDeComandos > 0)
                        lblAnaliseDoArquivo.Text = Properties.Resources.StatusAnaliseConcluida.Replace("%s", TotalDeComandos.ToString());

                    if (DadosFormulario != null)
                    {
                        var listEnumerator = DocumentoWord.FormFields.GetEnumerator(); // Get enumerator
                        for (var i = 0; listEnumerator.MoveNext() == true; i++)
                        {
                            object currentItem = listEnumerator.Current; // Get current item.
                            ((Word.FormField)currentItem).Result = DadosFormulario[i];
                        }
                    }

                    AplicativoWord.Visible = ExibirWord;

                    if (SalvarWord)
                    {
                        DialogSalvarArquivo.FileName = "";
                        DialogSalvarArquivo.DefaultExt = Path.GetExtension(textBox1.Text);
                        DialogSalvarArquivo.ShowDialog();
                        if (DialogSalvarArquivo.FileName != "")
                        {
                            try
                            {
                                DocumentoWord.SaveAs2(DialogSalvarArquivo.FileName, ref ValorNulo, ref ValorNulo, ref ValorNulo, ref ValorNulo, ref ValorNulo,
                                ref ValorNulo, ref ValorNulo, ref ValorNulo, ref ValorNulo, ref ValorNulo, ref ValorNulo, ref ValorNulo, ref ValorNulo,
                                ref ValorNulo, ref ValorNulo, ref ValorNulo);                                
                            }
                            catch (System.Runtime.InteropServices.COMException ex)
                            {
                                lblAnaliseDoArquivo.Text = ex.Message;
                            }
                            FecharWord = true;
                        }
                    }

                    if (FecharWord)
                        AplicativoWord.Quit(ref ValorFalso, ref ValorNulo, ref ValorNulo);
                }
            }
        }


        /// <summary>
        /// Executa o roteiro no Microsoft Word
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecutarRoteiro_Click(object sender, EventArgs e)
        {
            List<string> EnviarParaWord = new List<string>();
            Regex rex = new Regex("<(.*?)>");

            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];

                // Roteiro do Usuario
                foreach (String s in processador.Lines)
                {
                    String TempLinha = s;
                    String TempCampo = "";
                    MatchCollection mc = rex.Matches(TempLinha);
                    foreach (Match m in mc)
                    {
                        TempCampo = m.Value.Replace("<", "").Replace(">", "").ToLower();
                        foreach (DataGridViewColumn d in dataGridView1.Columns)
                        {
                            if (d.HeaderText.ToLower() == TempCampo)
                            {
                                TempLinha = TempLinha.Replace(m.Value, row.Cells[d.Index].Value.ToString());
                                break;
                            }
                        }
                    }
                    EnviarParaWord.Add(TempLinha);
                }

                if (TotalDeComandos <= EnviarParaWord.Count)
                {
                    ManipulaMicrosoftWord(true, false, true, EnviarParaWord);
                }

            }
        }

        /// <summary>
        /// Salva o Roteiro dentro do XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            String NomeDoRoteiro = "";
            if (lstRoteiros.Text == "Criar um Novo Roteiro")
                NomeDoRoteiro = "meu roteiro de teste";
            else
                NomeDoRoteiro = lstRoteiros.Text;
            ProcessaRoteiro.SalvarRoteiro(NomeDoRoteiro, processador.Lines);
            lstRoteiros.Items.Clear();
            foreach (String s in ProcessaRoteiro.ListRoteiros())
                lstRoteiros.Items.Add(s);
        }

        /// <summary>
        /// Remove o Roteiro Selecionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lstRoteiros.Text))
                ProcessaRoteiro.RemoverRoteiro(lstRoteiros.Text);
            lstRoteiros.Text = "";
            lstRoteiros.Items.Clear();
            foreach (String s in ProcessaRoteiro.ListRoteiros())
                lstRoteiros.Items.Add(s);
            processador.Clear();
        }

        /// <summary>
        /// Alterando o Processador de Texto ao Trocar o Roteiro a ser executado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstRoteiros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lstRoteiros.Text))
            {
                Roteiro r = ProcessaRoteiro.RoteiroExiste(lstRoteiros.Text);
                if (r != null)
                    processador.Lines = r.Linhas;
            }
        }

        /// <summary>
        /// populando a grade com os dados de exemplo
        /// </summary>
        private void popularGrade()
        {
            var source = new BindingSource();
            dataGridView1.AutoGenerateColumns = true;
            List<Cliente> list = new List<Cliente> { new Cliente("Jefferson", "Lupinacci", "(27) 98186-3223"), new Cliente("Juliane", "Prado", "(27) 98101-9122") };
            source.DataSource = list;
            dataGridView1.DataSource = source;
        }
    }

}