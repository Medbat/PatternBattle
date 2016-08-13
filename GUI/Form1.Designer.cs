using System.ComponentModel;
using System.Windows.Forms;

namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.Strategy1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Strategy2 = new System.Windows.Forms.Button();
            this.Strategy3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DoTickButton = new System.Windows.Forms.Button();
            this.UndoButton = new System.Windows.Forms.Button();
            this.RedoButton = new System.Windows.Forms.Button();
            this.FullBattleButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.RestartButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.FightTextBox = new System.Windows.Forms.RichTextBox();
            this.SpecialActionTextBox = new System.Windows.Forms.RichTextBox();
            this.DeathTextBox = new System.Windows.Forms.RichTextBox();
            this.ArmyTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.totalPriceTextBox = new System.Windows.Forms.TextBox();
            this.acceptTotalPriceButton = new System.Windows.Forms.Button();
            this.priceNow = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Strategy1
            // 
            this.Strategy1.Location = new System.Drawing.Point(1265, 26);
            this.Strategy1.Name = "Strategy1";
            this.Strategy1.Size = new System.Drawing.Size(75, 23);
            this.Strategy1.TabIndex = 0;
            this.Strategy1.Text = "1х1";
            this.Strategy1.UseVisualStyleBackColor = true;
            this.Strategy1.Click += new System.EventHandler(this.Strategy1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1262, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Смена тактики";
            // 
            // Strategy2
            // 
            this.Strategy2.Location = new System.Drawing.Point(1265, 55);
            this.Strategy2.Name = "Strategy2";
            this.Strategy2.Size = new System.Drawing.Size(75, 23);
            this.Strategy2.TabIndex = 2;
            this.Strategy2.Text = "3x3";
            this.Strategy2.UseVisualStyleBackColor = true;
            this.Strategy2.Click += new System.EventHandler(this.Strategy2_Click);
            // 
            // Strategy3
            // 
            this.Strategy3.Location = new System.Drawing.Point(1265, 84);
            this.Strategy3.Name = "Strategy3";
            this.Strategy3.Size = new System.Drawing.Size(75, 23);
            this.Strategy3.TabIndex = 3;
            this.Strategy3.Text = "deathmatch";
            this.Strategy3.UseVisualStyleBackColor = true;
            this.Strategy3.Click += new System.EventHandler(this.Strategy3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1262, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Процесс игры";
            // 
            // DoTickButton
            // 
            this.DoTickButton.Location = new System.Drawing.Point(1265, 126);
            this.DoTickButton.Name = "DoTickButton";
            this.DoTickButton.Size = new System.Drawing.Size(75, 23);
            this.DoTickButton.TabIndex = 5;
            this.DoTickButton.Text = "Далее";
            this.DoTickButton.UseVisualStyleBackColor = true;
            this.DoTickButton.Click += new System.EventHandler(this.DoTickButton_Click);
            // 
            // UndoButton
            // 
            this.UndoButton.Location = new System.Drawing.Point(1266, 200);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(75, 23);
            this.UndoButton.TabIndex = 6;
            this.UndoButton.Text = "Undo";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // RedoButton
            // 
            this.RedoButton.Location = new System.Drawing.Point(1266, 229);
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(75, 23);
            this.RedoButton.TabIndex = 7;
            this.RedoButton.Text = "Redo";
            this.RedoButton.UseVisualStyleBackColor = true;
            this.RedoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // FullBattleButton
            // 
            this.FullBattleButton.Location = new System.Drawing.Point(1266, 155);
            this.FullBattleButton.Name = "FullBattleButton";
            this.FullBattleButton.Size = new System.Drawing.Size(75, 39);
            this.FullBattleButton.TabIndex = 8;
            this.FullBattleButton.Text = "Далее до конца";
            this.FullBattleButton.UseVisualStyleBackColor = true;
            this.FullBattleButton.Click += new System.EventHandler(this.FullBattleButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1267, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Общее меню";
            // 
            // RestartButton
            // 
            this.RestartButton.Location = new System.Drawing.Point(1257, 271);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(88, 35);
            this.RestartButton.TabIndex = 10;
            this.RestartButton.Text = "Перегенерить армии";
            this.RestartButton.UseVisualStyleBackColor = true;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(1266, 312);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 11;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // FightTextBox
            // 
			this.FightTextBox.HideSelection = false;
            this.FightTextBox.Location = new System.Drawing.Point(12, 10);
            this.FightTextBox.Name = "FightTextBox";
            this.FightTextBox.ReadOnly = true;
            this.FightTextBox.Size = new System.Drawing.Size(356, 553);
            this.FightTextBox.TabIndex = 12;
            this.FightTextBox.Text = "";
			this.FightTextBox.TextChanged += new System.EventHandler(this.FightTextBox_TextChanged);
            // 
            // SpecialActionTextBox
            // 
			this.SpecialActionTextBox.HideSelection = false;
            this.SpecialActionTextBox.Location = new System.Drawing.Point(374, 10);
            this.SpecialActionTextBox.Name = "SpecialActionTextBox";
            this.SpecialActionTextBox.ReadOnly = true;
            this.SpecialActionTextBox.Size = new System.Drawing.Size(360, 554);
            this.SpecialActionTextBox.TabIndex = 13;
            this.SpecialActionTextBox.Text = "";
			this.SpecialActionTextBox.TextChanged += new System.EventHandler(this.SpecialActionTextBox_TextChanged);
            // 
            // DeathTextBox
            // 
			this.DeathTextBox.HideSelection = false;
            this.DeathTextBox.Location = new System.Drawing.Point(740, 10);
            this.DeathTextBox.Name = "DeathTextBox";
            this.DeathTextBox.ReadOnly = true;
            this.DeathTextBox.Size = new System.Drawing.Size(268, 553);
            this.DeathTextBox.TabIndex = 14;
            this.DeathTextBox.Text = "";
            this.DeathTextBox.TextChanged += new System.EventHandler(this.DeathTextBox_TextChanged);
            // 
            // ArmyTextBox
            // 
			this.ArmyTextBox.HideSelection = false;
            this.ArmyTextBox.Location = new System.Drawing.Point(1014, 10);
            this.ArmyTextBox.Name = "ArmyTextBox";
            this.ArmyTextBox.ReadOnly = true;
            this.ArmyTextBox.Size = new System.Drawing.Size(242, 553);
            this.ArmyTextBox.TabIndex = 15;
            this.ArmyTextBox.Text = "";
            this.ArmyTextBox.TextChanged += new System.EventHandler(this.ArmyTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1267, 338);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Цена армий";
            // 
            // totalPriceTextBox
            // 
            this.totalPriceTextBox.Location = new System.Drawing.Point(1257, 392);
            this.totalPriceTextBox.MaxLength = 7;
            this.totalPriceTextBox.Name = "totalPriceTextBox";
            this.totalPriceTextBox.Size = new System.Drawing.Size(98, 20);
            this.totalPriceTextBox.TabIndex = 17;
            this.totalPriceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.totalPriceTextBox_KeyPress);
            // 
            // acceptTotalPriceButton
            // 
            this.acceptTotalPriceButton.Location = new System.Drawing.Point(1265, 418);
            this.acceptTotalPriceButton.Name = "acceptTotalPriceButton";
            this.acceptTotalPriceButton.Size = new System.Drawing.Size(75, 23);
            this.acceptTotalPriceButton.TabIndex = 18;
            this.acceptTotalPriceButton.Text = "Задать";
            this.acceptTotalPriceButton.UseVisualStyleBackColor = true;
            this.acceptTotalPriceButton.Click += new System.EventHandler(this.acceptTotalPriceButton_Click);
            // 
            // priceNow
            // 
            this.priceNow.AutoSize = true;
            this.priceNow.Location = new System.Drawing.Point(1283, 363);
            this.priceNow.Name = "priceNow";
            this.priceNow.Size = new System.Drawing.Size(35, 13);
            this.priceNow.TabIndex = 19;
            this.priceNow.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 573);
            this.Controls.Add(this.priceNow);
            this.Controls.Add(this.acceptTotalPriceButton);
            this.Controls.Add(this.totalPriceTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ArmyTextBox);
            this.Controls.Add(this.DeathTextBox);
            this.Controls.Add(this.SpecialActionTextBox);
            this.Controls.Add(this.FightTextBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FullBattleButton);
            this.Controls.Add(this.RedoButton);
            this.Controls.Add(this.UndoButton);
            this.Controls.Add(this.DoTickButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Strategy3);
            this.Controls.Add(this.Strategy2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Strategy1);
            this.Name = "Form1";
            this.Text = "Pattern Battle GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Strategy1;
        private Label label1;
        private Button Strategy2;
        private Button Strategy3;
        private Label label2;
        private Button DoTickButton;
        private Button UndoButton;
        private Button RedoButton;
        private Button FullBattleButton;
        private Label label3;
        private Button RestartButton;
        private Button ExitButton;
        private RichTextBox ArmyTextBox;
        private RichTextBox DeathTextBox;
        private RichTextBox SpecialActionTextBox;
        private RichTextBox FightTextBox;
        private Label label4;
        private TextBox totalPriceTextBox;
        private Button acceptTotalPriceButton;
        private Label priceNow;
    }
}

