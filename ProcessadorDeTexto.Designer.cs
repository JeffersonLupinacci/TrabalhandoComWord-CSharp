namespace TrabalhandoComWord
{
    partial class ProcessadorDeTexto
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NumeroDaLinha = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.EditorDeTexto = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NumeroDaLinha
            // 
            this.NumeroDaLinha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.NumeroDaLinha.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NumeroDaLinha.Location = new System.Drawing.Point(3, 0);
            this.NumeroDaLinha.Name = "NumeroDaLinha";
            this.NumeroDaLinha.Size = new System.Drawing.Size(37, 267);
            this.NumeroDaLinha.TabIndex = 1;
            this.NumeroDaLinha.Text = "1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11\r\n12\r\n13\r\n14\r\n15\r\n16";
            this.NumeroDaLinha.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.NumeroDaLinha);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.EditorDeTexto);
            this.splitContainer1.Size = new System.Drawing.Size(403, 267);
            this.splitContainer1.SplitterDistance = 41;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.Text = "splitContainer1";
            // 
            // EditorDeTexto
            // 
            this.EditorDeTexto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EditorDeTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditorDeTexto.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EditorDeTexto.Location = new System.Drawing.Point(0, 0);
            this.EditorDeTexto.Name = "EditorDeTexto";
            this.EditorDeTexto.Size = new System.Drawing.Size(361, 267);
            this.EditorDeTexto.TabIndex = 0;
            this.EditorDeTexto.Text = "";
            this.EditorDeTexto.WordWrap = false;
            this.EditorDeTexto.VScroll += new System.EventHandler(this.EditorDeTexto_VScroll);
            this.EditorDeTexto.FontChanged += new System.EventHandler(this.EditorDeTexto_FontChanged);
            this.EditorDeTexto.TextChanged += new System.EventHandler(this.EditorDeTexto_TextChanged);
            this.EditorDeTexto.Resize += new System.EventHandler(this.EditorDeTexto_Resize);
            // 
            // ProcessadorDeTexto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ProcessadorDeTexto";
            this.Size = new System.Drawing.Size(403, 267);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox EditorDeTexto;
        private System.Windows.Forms.Label NumeroDaLinha;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
