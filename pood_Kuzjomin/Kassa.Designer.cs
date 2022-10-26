namespace pood_Kuzjomin
{
    partial class Kassa
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Lisa_btn = new System.Windows.Forms.Button();
            this.Tsekk_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.kassa_img = new System.Windows.Forms.PictureBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nimi1_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kassa_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(422, 426);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // Lisa_btn
            // 
            this.Lisa_btn.Location = new System.Drawing.Point(452, 374);
            this.Lisa_btn.Name = "Lisa_btn";
            this.Lisa_btn.Size = new System.Drawing.Size(150, 64);
            this.Lisa_btn.TabIndex = 1;
            this.Lisa_btn.Text = "Lisa kaup ostukorvi";
            this.Lisa_btn.UseVisualStyleBackColor = true;
            this.Lisa_btn.Click += new System.EventHandler(this.Lisa_btn_Click);
            // 
            // Tsekk_btn
            // 
            this.Tsekk_btn.Location = new System.Drawing.Point(627, 374);
            this.Tsekk_btn.Name = "Tsekk_btn";
            this.Tsekk_btn.Size = new System.Drawing.Size(150, 64);
            this.Tsekk_btn.TabIndex = 2;
            this.Tsekk_btn.Text = "Trükki tšekk";
            this.Tsekk_btn.UseVisualStyleBackColor = true;
            this.Tsekk_btn.Click += new System.EventHandler(this.Tsekk_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(525, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Toode nimetus:";
            // 
            // kassa_img
            // 
            this.kassa_img.Location = new System.Drawing.Point(478, 43);
            this.kassa_img.Name = "kassa_img";
            this.kassa_img.Size = new System.Drawing.Size(275, 270);
            this.kassa_img.TabIndex = 5;
            this.kassa_img.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(596, 337);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(111, 20);
            this.numericUpDown1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(525, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Kogus";
            // 
            // nimi1_lbl
            // 
            this.nimi1_lbl.AutoSize = true;
            this.nimi1_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.nimi1_lbl.Location = new System.Drawing.Point(624, 12);
            this.nimi1_lbl.Name = "nimi1_lbl";
            this.nimi1_lbl.Size = new System.Drawing.Size(97, 16);
            this.nimi1_lbl.TabIndex = 8;
            this.nimi1_lbl.Text = "Toode nimetus";
            // 
            // Kassa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nimi1_lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.kassa_img);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tsekk_btn);
            this.Controls.Add(this.Lisa_btn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Kassa";
            this.Text = "Kassa";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kassa_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Lisa_btn;
        private System.Windows.Forms.Button Tsekk_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox kassa_img;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label nimi1_lbl;
    }
}