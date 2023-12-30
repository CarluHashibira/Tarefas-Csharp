using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04_Tabuada
{
    public partial class FrmTabuada : Form
    {
        public FrmTabuada()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (Verifica())
            {
                int numero = int.Parse(mskNumero.Text);
                lstResultado.Items.Clear();
                for (int i = 1; i <= 10; i++)
                {
                    lstResultado.Items.Add(numero + " X " + i + " = " + (numero * i));
                }
            }
        }

        public bool Verifica()
        {
            if (mskNumero.Text == string.Empty)
            {
                MessageBox.Show("Digite um numero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskNumero.Focus();
                return false;
            }
            return true;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            mskNumero.Clear();
            rdb1.Checked = false;
            rdb2.Checked = false;
            rdb3.Checked = false;
            rdb4.Checked = false;
            rdb5.Checked = false;
            rdb6.Checked = false;
            rdb7.Checked = false;
            rdb8.Checked = false;
            rdb9.Checked = false;
            rdb10.Checked = false;
            lstResultado.Items.Clear();
            mskNumero.Focus();
        }

        private void rdb1_CheckedChanged(object sender, EventArgs e)
        {
            int numero = 1;
            lstResultado.Items.Clear();
            for (int i = 1; i <= 10; i++)
            {
                lstResultado.Items.Add(numero + " X " + i + " = " + (numero * i));
            }
        }

        private void rdb2_CheckedChanged(object sender, EventArgs e)
        {
            int numero = 2;
            lstResultado.Items.Clear();
            for (int i = 1; i <= 10; i++)
            {
                lstResultado.Items.Add(numero + " X " + i + " = " + (numero * i));
            }
        }

        private void rdb3_CheckedChanged(object sender, EventArgs e)
        {
            int numero = 3;
            lstResultado.Items.Clear();
            for (int i = 1; i <= 10; i++)
            {
                lstResultado.Items.Add(numero + " X " + i + " = " + (numero * i));
            }
        }

        private void rdb4_CheckedChanged(object sender, EventArgs e)
        {
            int numero = 4;
            lstResultado.Items.Clear();
            for (int i = 1; i <= 10; i++)
            {
                lstResultado.Items.Add(numero + " X " + i + " = " + (numero * i));
            }
        }

        private void rdb5_CheckedChanged(object sender, EventArgs e)
        {
            int numero = 5;
            lstResultado.Items.Clear();
            for (int i = 1; i <= 10; i++)
            {
                lstResultado.Items.Add(numero + " X " + i + " = " + (numero * i));
            }
        }

        private void rdb6_CheckedChanged(object sender, EventArgs e)
        {
            int numero = 6;
            lstResultado.Items.Clear();
            for (int i = 1; i <= 10; i++)
            {
                lstResultado.Items.Add(numero + " X " + i + " = " + (numero * i));
            }
        }

        private void rdb7_CheckedChanged(object sender, EventArgs e)
        {
            int numero = 7;
            lstResultado.Items.Clear();
            for (int i = 1; i <= 10; i++)
            {
                lstResultado.Items.Add(numero + " X " + i + " = " + (numero * i));
            }
        }

        private void rdb8_CheckedChanged(object sender, EventArgs e)
        {
            int numero = 8;
            lstResultado.Items.Clear();
            for (int i = 1; i <= 10; i++)
            {
                lstResultado.Items.Add(numero + " X " + i + " = " + (numero * i));
            }
        }

        private void rdb9_CheckedChanged(object sender, EventArgs e)
        {
            int numero = 9;
            lstResultado.Items.Clear();
            for (int i = 1; i <= 10; i++)
            {
                lstResultado.Items.Add(numero + " X " + i + " = " + (numero * i));
            }
        }

        private void rdb10_CheckedChanged(object sender, EventArgs e)
        {
            int numero = 10;
            lstResultado.Items.Clear();
            for (int i = 1; i <= 10; i++)
            {
                lstResultado.Items.Add(numero + " X " + i + " = " + (numero * i));
            }
        }
    }
}
