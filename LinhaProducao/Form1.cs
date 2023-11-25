using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinhaProducao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Funcionarios  funcionarios = new Funcionarios();

                funcionarios.nome = "Samuel";
                funcionarios.id_empresa = 1;
                funcionarios.email = "samuca";
                funcionarios.SetNivel(1);
                funcionarios.SetSenha("42424f2a2");

                funcionarios.Insert();

                MessageBox.Show("Funcionario adicionado com sucesso");

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
