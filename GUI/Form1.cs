using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Pattern_Battle;
using Pattern_Battle.Strategies;

namespace GUI
{
    public partial class Form1 : Form
    {
        private int _tickIndex;

        public Form1()
        {
            InitializeComponent();
        }

        private void BlockStrategyButton()
        {
            if (Consts.Strategy is OneLineStrategy)
                Strategy1.Enabled = false;
            else
                Strategy1.Enabled = true;
            if (Consts.Strategy is ThreeLinesStrategy)
                Strategy2.Enabled = false;
            else
                Strategy2.Enabled = true;
            if (Consts.Strategy is MaxLinesStrategy)
                Strategy3.Enabled = false;
            else
                Strategy3.Enabled = true;
        }

        private void UpdateArmiesTextBox()
        {
            ArmyTextBox.Text = Core.GetArmiesTextRepresentation();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BlockStrategyButton();
            RestartButton_Click(this, e);
            totalPriceTextBox.Text = Consts.TotalPrice.ToString();
            acceptTotalPriceButton_Click(this, e);
            UpdateArmiesTextBox();
        }

        private void Strategy1_Click(object sender, EventArgs e)
        {
            Consts.Strategy = new OneLineStrategy();
            BlockStrategyButton();
        }

        private void Strategy2_Click(object sender, EventArgs e)
        {
            Consts.Strategy = new ThreeLinesStrategy();
            BlockStrategyButton();
        }

        private void Strategy3_Click(object sender, EventArgs e)
        {
            Consts.Strategy = new MaxLinesStrategy();
            BlockStrategyButton();
        }

	    private bool Tick()
	    {
			if (!(Consts.SevenNationArmies[0].Any() && Consts.SevenNationArmies[1].Any()) || Consts.DeadLock)
			{
				FightTextBox.Text +=
					$@"{Environment.NewLine}The battle is over. Generate new armies. {Environment.NewLine}Result: {Core.GetBattleResult()}";
				return false;
			}

			Core.TryBattleTick();

			StreamWriter sw;
			using (sw = new StreamWriter(Consts.FightFilePath, true))
			{
				sw.WriteLine("End of " + _tickIndex + " tick");
			}

			using (sw = new StreamWriter(Consts.DeathFilePath, true))
			{
				sw.WriteLine("End of " + _tickIndex + " tick");
			}

			using (sw = new StreamWriter(Consts.SpecialActionFilePath, true))
			{
				sw.WriteLine("End of " + _tickIndex + " tick");
			}
			_tickIndex++;

			FightTextBox.Text = File.ReadAllText(Consts.FightFilePath);
			SpecialActionTextBox.Text = File.ReadAllText(Consts.SpecialActionFilePath);
			DeathTextBox.Text = File.ReadAllText(Consts.DeathFilePath);
			ArmyTextBox.Text += "\r\nTick " + _tickIndex + "\r\n" + Core.GetArmiesTextRepresentation();

		    return true;
	    }

		private void DoTickButton_Click(object sender, EventArgs e)
        {
			Tick();   
        }

	    private void FullBattleButton_Click(object sender, EventArgs e)
	    {
		    while (Tick())
		    {
		    }
	    }

	    private void UndoButton_Click(object sender, EventArgs e)
        {
            if (Consts.Invoker.CanUndo())
            {
                _tickIndex--;
                Consts.Invoker.CtrlZ();
                FightTextBox.Text = File.ReadAllText(Consts.FightFilePath);
                ArmyTextBox.Text += "\nUndo to "+ _tickIndex + "Tick\n" + Core.GetArmiesTextRepresentation();
            }
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            if (Consts.Invoker.CanRedo())
            {
                _tickIndex++;
                Consts.Invoker.CtrlY();
                FightTextBox.Text = File.ReadAllText(Consts.FightFilePath);
                ArmyTextBox.Text += "\nRedo to " + _tickIndex + "Tick\n" + Core.GetArmiesTextRepresentation();
                
            }
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            Consts.Invoker.ClearCommands();
            Core.CreateRandomArmies();

            FightTextBox.Text = @"Now we are ready to start";

            using (new StreamWriter(Consts.DeathFilePath, false)) { }
            using (new StreamWriter(Consts.SpecialActionFilePath, false)) { }
            using (new StreamWriter(Consts.FightFilePath, false)) { }

            SpecialActionTextBox.Text = string.Empty;
            DeathTextBox.Text = string.Empty;
            ArmyTextBox.Text = "Tick 0\n" + Core.GetArmiesTextRepresentation();
            _tickIndex = 0;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void totalPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void acceptTotalPriceButton_Click(object sender, EventArgs e)
        {
            Consts.TotalPrice = int.Parse(totalPriceTextBox.Text);
            priceNow.Text = Consts.TotalPrice.ToString();
            totalPriceTextBox.Text = Consts.TotalPrice.ToString();
        }

        private void DeathTextBox_TextChanged(object sender, EventArgs e)
        {
			DeathTextBox.SelectionStart = DeathTextBox.Text.Length;
			DeathTextBox.ScrollToCaret();
        }

        private void ArmyTextBox_TextChanged(object sender, EventArgs e)
		{
			ArmyTextBox.SelectionStart = ArmyTextBox.Text.Length;
			ArmyTextBox.ScrollToCaret();
        }

		private void FightTextBox_TextChanged(object sender, EventArgs e)
        {
			FightTextBox.SelectionStart = ArmyTextBox.Text.Length;
			FightTextBox.ScrollToCaret();
		}

		private void SpecialActionTextBox_TextChanged(object sender, EventArgs e)
		{
			SpecialActionTextBox.SelectionStart = ArmyTextBox.Text.Length;
			SpecialActionTextBox.ScrollToCaret();
        }
    }
}
