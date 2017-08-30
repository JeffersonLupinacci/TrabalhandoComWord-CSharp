namespace TrabalhandoComWord
{
    partial class FrmProcessamento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSelecionarDocumento = new System.Windows.Forms.Button();
            this.DialogSelecionarArquivo = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExecutarRoteiro = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblAnaliseDoArquivo = new System.Windows.Forms.Label();
            this.lstRoteiros = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DialogSalvarArquivo = new System.Windows.Forms.SaveFileDialog();
            this.processador = new TrabalhandoComWord.ProcessadorDeTexto();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnSelecionarDocumento);
            this.groupBox1.Location = new System.Drawing.Point(384, 226);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 53);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecione o Modelo do Documento do Microsoft Word";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(174, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(349, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.TabStop = false;
            // 
            // btnSelecionarDocumento
            // 
            this.btnSelecionarDocumento.Location = new System.Drawing.Point(6, 19);
            this.btnSelecionarDocumento.Name = "btnSelecionarDocumento";
            this.btnSelecionarDocumento.Size = new System.Drawing.Size(162, 23);
            this.btnSelecionarDocumento.TabIndex = 4;
            this.btnSelecionarDocumento.Text = "Selecionar documento";
            this.btnSelecionarDocumento.UseVisualStyleBackColor = true;
            this.btnSelecionarDocumento.Click += new System.EventHandler(this.btnSelecionarDocumento_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnExecutarRoteiro);
            this.panel2.Location = new System.Drawing.Point(385, 328);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(537, 51);
            this.panel2.TabIndex = 8;
            // 
            // btnExecutarRoteiro
            // 
            this.btnExecutarRoteiro.Location = new System.Drawing.Point(5, 4);
            this.btnExecutarRoteiro.Name = "btnExecutarRoteiro";
            this.btnExecutarRoteiro.Size = new System.Drawing.Size(280, 39);
            this.btnExecutarRoteiro.TabIndex = 7;
            this.btnExecutarRoteiro.Text = "Executar Roteiro no Documento Selecionado";
            this.btnExecutarRoteiro.UseVisualStyleBackColor = true;
            this.btnExecutarRoteiro.Click += new System.EventHandler(this.btnExecutarRoteiro_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblAnaliseDoArquivo);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox2.Location = new System.Drawing.Point(385, 285);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 37);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // lblAnaliseDoArquivo
            // 
            this.lblAnaliseDoArquivo.AutoSize = true;
            this.lblAnaliseDoArquivo.Location = new System.Drawing.Point(6, 14);
            this.lblAnaliseDoArquivo.Name = "lblAnaliseDoArquivo";
            this.lblAnaliseDoArquivo.Size = new System.Drawing.Size(281, 13);
            this.lblAnaliseDoArquivo.TabIndex = 0;
            this.lblAnaliseDoArquivo.Text = "Selecione um documento do microsoft word para começar";
            // 
            // lstRoteiros
            // 
            this.lstRoteiros.FormattingEnabled = true;
            this.lstRoteiros.Items.AddRange(new object[] {
            "Criar um Novo Roteiro"});
            this.lstRoteiros.Location = new System.Drawing.Point(58, 358);
            this.lstRoteiros.Name = "lstRoteiros";
            this.lstRoteiros.Size = new System.Drawing.Size(164, 21);
            this.lstRoteiros.TabIndex = 10;
            this.lstRoteiros.SelectedIndexChanged += new System.EventHandler(this.lstRoteiros_SelectedIndexChanged);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(227, 357);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 12;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(308, 357);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(71, 23);
            this.btnRemover.TabIndex = 13;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Roteiro:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(385, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(536, 199);
            this.dataGridView1.TabIndex = 16;
            // 
            // DialogSalvarArquivo
            // 
            this.DialogSalvarArquivo.AddExtension = false;
            // 
            // processador
            // 
            this.processador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.processador.Lines = new string[0];
            this.processador.Location = new System.Drawing.Point(12, 12);
            this.processador.Name = "processador";
            this.processador.Size = new System.Drawing.Size(367, 340);
            this.processador.TabIndex = 0;
            // 
            // FrmProcessamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 421);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lstRoteiros);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.processador);
            this.Name = "FrmProcessamento";
            this.Text = "Trabalhando com o Microsoft Word";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProcessadorDeTexto processador;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSelecionarDocumento;
        private System.Windows.Forms.OpenFileDialog DialogSelecionarArquivo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExecutarRoteiro;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblAnaliseDoArquivo;
        private System.Windows.Forms.ComboBox lstRoteiros;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SaveFileDialog DialogSalvarArquivo;
    }
}

