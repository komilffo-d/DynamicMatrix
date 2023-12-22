using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicMatrix_WF
{
    public enum ModeRandom
    {
        LEFT,
        RIGHT,
        BOTH
    }
    public partial class ChoiceModeGeneration : Form
    {
        public ModeRandom modeRandom;
        public ChoiceModeGeneration()
        {
            InitializeComponent();
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            if (Left.Checked)
            {
                this.modeRandom=ModeRandom.LEFT;
            }
            else if (Right.Checked)
            {
                this.modeRandom = ModeRandom.RIGHT;
            }
            else if (Both.Checked)
            {
                this.modeRandom = ModeRandom.BOTH;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
