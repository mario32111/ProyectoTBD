namespace ProyectoTBD
{
    partial class Detalles
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 55);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 0;
            label1.Text = "ID Detalle";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 84);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 1;
            label2.Text = "ID Pedido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 112);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 2;
            label3.Text = "Cantidad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 141);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 3;
            label4.Text = "Precio";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 169);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 4;
            label5.Text = "ID Producto";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(97, 47);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(97, 76);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(97, 104);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(97, 133);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 8;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(97, 161);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 9;
            // 
            // button1
            // 
            button1.Location = new Point(73, 217);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(73, 246);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 11;
            button2.Text = "Editar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(73, 274);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 12;
            button3.Text = "Eliminar";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(73, 303);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 13;
            button4.Text = "Buscar";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(188, 12);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 14;
            button5.Text = "salir";
            button5.UseVisualStyleBackColor = true;
            // 
            // Detalles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(275, 372);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Detalles";
            Text = "Detalles";
            Load += Detalles_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}