using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TrabalhandoComWord
{
    public partial class ProcessadorDeTexto : UserControl
    {
        public ProcessadorDeTexto()
        {
            InitializeComponent();
            NumeroDaLinha.Font = new Font(EditorDeTexto.Font.FontFamily, EditorDeTexto.Font.Size + 1.019f);
        }

        private void AtualizarNumeroDePagina()
        {
            Point pos = new Point(0, 0);
            int PrimeirIndice = EditorDeTexto.GetCharIndexFromPosition(pos);
            int PrimeiraLinha = EditorDeTexto.GetLineFromCharIndex(PrimeirIndice);
            pos.X = ClientRectangle.Width;
            pos.Y = ClientRectangle.Height;
            int UltimoIndice = EditorDeTexto.GetCharIndexFromPosition(pos);
            int UltimaLinha = EditorDeTexto.GetLineFromCharIndex(UltimoIndice) - 1;
            pos = EditorDeTexto.GetPositionFromCharIndex(UltimoIndice);
            NumeroDaLinha.Text = "";
            for (int i = PrimeiraLinha; i <= UltimaLinha + 1; i++)
                NumeroDaLinha.Text += i + 1 + "\n";
        }

        private void EditorDeTexto_TextChanged(object sender, EventArgs e)
        {
            int s = EditorDeTexto.SelectionStart;
            
            EditorDeTexto.SelectionColor = Color.Black;
            Regex rex = new Regex("<(.*?)>");
            MatchCollection mc = rex.Matches(EditorDeTexto.Text);
            int PosicaoInicial = EditorDeTexto.SelectionStart;
            
            foreach (Match m in mc)
            {
                int IndiceInicial = m.Index;
                int IndiceFinal = m.Length;
                EditorDeTexto.Select(IndiceInicial, IndiceFinal);
                EditorDeTexto.SelectionColor = Color.Blue; // Colorindo a Tag               
            }

            AtualizarNumeroDePagina();
            EditorDeTexto.Select(s, 0);
            EditorDeTexto.SelectionColor = Color.Black;
        }

        private void EditorDeTexto_VScroll(object sender, EventArgs e)
        {
            int d = EditorDeTexto.GetPositionFromCharIndex(0).Y % (EditorDeTexto.Font.Height + 1);
            NumeroDaLinha.Location = new Point(0, d);
            AtualizarNumeroDePagina();
        }

        private void EditorDeTexto_Resize(object sender, EventArgs e)
        {
            EditorDeTexto_VScroll(null, null);
        }

        private void EditorDeTexto_FontChanged(object sender, EventArgs e)
        {
            AtualizarNumeroDePagina();
            EditorDeTexto_VScroll(null, null);
        }

        public String[] Lines
        {
            get {
                return EditorDeTexto.Lines;
            }
            set {
                EditorDeTexto.Lines = value;                
            }
        }

        public void Clear()
        { EditorDeTexto.Clear(); }

    }
}
