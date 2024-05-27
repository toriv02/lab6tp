namespace lab6net6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            picDisplay = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            tbDirection = new TrackBar();
            lblDirection = new Label();
            lblGraviton1 = new Label();
            tbGraviton1 = new TrackBar();
            lblGraviton2 = new Label();
            tbGraviton2 = new TrackBar();
            lblAntiGrav = new Label();
            tbAntiGrav = new TrackBar();
            lblSpreading = new Label();
            tbSpreading = new TrackBar();
            EmiterCB = new CheckBox();
            PaintCB = new CheckBox();
            bindingSource1 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)picDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAntiGrav).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbSpreading).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // picDisplay
            // 
            picDisplay.Location = new Point(12, 12);
            picDisplay.Name = "picDisplay";
            picDisplay.Size = new Size(776, 426);
            picDisplay.TabIndex = 0;
            picDisplay.TabStop = false;
            picDisplay.MouseClick += picDisplay_MouseClick;
            picDisplay.MouseMove += picDisplay_MouseMove;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 40;
            timer1.Tick += timer1_Tick;
            // 
            // tbDirection
            // 
            tbDirection.Location = new Point(12, 466);
            tbDirection.Maximum = 359;
            tbDirection.Name = "tbDirection";
            tbDirection.Size = new Size(199, 45);
            tbDirection.TabIndex = 1;
            tbDirection.Scroll += trackBar1_Scroll;
            // 
            // lblDirection
            // 
            lblDirection.Location = new Point(12, 445);
            lblDirection.Name = "lblDirection";
            lblDirection.Size = new Size(188, 18);
            lblDirection.TabIndex = 2;
            lblDirection.Text = "Направление: 0°";
            // 
            // lblGraviton1
            // 
            lblGraviton1.Location = new Point(589, 445);
            lblGraviton1.Name = "lblGraviton1";
            lblGraviton1.Size = new Size(188, 18);
            lblGraviton1.TabIndex = 4;
            lblGraviton1.Text = "Сила гравитона: 0";
            // 
            // tbGraviton1
            // 
            tbGraviton1.Location = new Point(589, 466);
            tbGraviton1.Maximum = 600;
            tbGraviton1.Name = "tbGraviton1";
            tbGraviton1.Size = new Size(199, 45);
            tbGraviton1.TabIndex = 3;
            tbGraviton1.Scroll += tbGraviton_Scroll;
            // 
            // lblGraviton2
            // 
            lblGraviton2.Location = new Point(589, 513);
            lblGraviton2.Name = "lblGraviton2";
            lblGraviton2.Size = new Size(188, 18);
            lblGraviton2.TabIndex = 6;
            lblGraviton2.Text = "Сила гравитона: 0";
            // 
            // tbGraviton2
            // 
            tbGraviton2.Location = new Point(589, 534);
            tbGraviton2.Maximum = 600;
            tbGraviton2.Name = "tbGraviton2";
            tbGraviton2.Size = new Size(199, 45);
            tbGraviton2.TabIndex = 5;
            tbGraviton2.Scroll += tbGraviton2_Scroll;
            // 
            // lblAntiGrav
            // 
            lblAntiGrav.Location = new Point(384, 445);
            lblAntiGrav.Name = "lblAntiGrav";
            lblAntiGrav.Size = new Size(188, 18);
            lblAntiGrav.TabIndex = 8;
            lblAntiGrav.Text = "Сила антигравитона: 0";
            // 
            // tbAntiGrav
            // 
            tbAntiGrav.Location = new Point(384, 466);
            tbAntiGrav.Maximum = 600;
            tbAntiGrav.Name = "tbAntiGrav";
            tbAntiGrav.Size = new Size(199, 45);
            tbAntiGrav.TabIndex = 7;
            tbAntiGrav.Scroll += tbAntiGrav_Scroll;
            // 
            // lblSpreading
            // 
            lblSpreading.Location = new Point(12, 503);
            lblSpreading.Name = "lblSpreading";
            lblSpreading.Size = new Size(188, 18);
            lblSpreading.TabIndex = 10;
            lblSpreading.Text = "Распределение: 0°";
            // 
            // tbSpreading
            // 
            tbSpreading.Location = new Point(12, 524);
            tbSpreading.Maximum = 359;
            tbSpreading.Name = "tbSpreading";
            tbSpreading.Size = new Size(199, 45);
            tbSpreading.TabIndex = 9;
            tbSpreading.Scroll += trackBar1_Scroll_1;
            // 
            // EmiterCB
            // 
            EmiterCB.Location = new Point(384, 507);
            EmiterCB.Name = "EmiterCB";
            EmiterCB.Size = new Size(188, 24);
            EmiterCB.TabIndex = 11;
            EmiterCB.Text = "Падающие частицы";
            EmiterCB.UseVisualStyleBackColor = true;
            EmiterCB.CheckedChanged += EmiterCB_CheckedChanged;
            // 
            // PaintCB
            // 
            PaintCB.Location = new Point(384, 537);
            PaintCB.Name = "PaintCB";
            PaintCB.Size = new Size(188, 24);
            PaintCB.TabIndex = 12;
            PaintCB.Text = "Краска";
            PaintCB.UseVisualStyleBackColor = true;
            PaintCB.CheckedChanged += PaintCB_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 596);
            Controls.Add(PaintCB);
            Controls.Add(EmiterCB);
            Controls.Add(lblSpreading);
            Controls.Add(tbSpreading);
            Controls.Add(lblAntiGrav);
            Controls.Add(tbAntiGrav);
            Controls.Add(lblGraviton2);
            Controls.Add(tbGraviton2);
            Controls.Add(lblGraviton1);
            Controls.Add(tbGraviton1);
            Controls.Add(lblDirection);
            Controls.Add(tbDirection);
            Controls.Add(picDisplay);
            Name = "Form1";
            Text = "Particle task";
            ((System.ComponentModel.ISupportInitialize)picDisplay).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton2).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAntiGrav).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbSpreading).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private TrackBar tbDirection;
        private Label lblDirection;
        private Label lblGraviton1;
        private TrackBar tbGraviton1;
        private Label lblGraviton2;
        private TrackBar tbGraviton2;
        private Label lblAntiGrav;
        private TrackBar tbAntiGrav;
        private Label lblSpreading;
        private TrackBar tbSpreading;
        private CheckBox EmiterCB;
        private CheckBox PaintCB;
        private TextBox tbParticleCount;
        private Label lblParticleCount;
        private Label lblParticlePerTick;
        private TextBox tbParticlePerTick;
        private BindingSource bindingSource1;
    }
}
