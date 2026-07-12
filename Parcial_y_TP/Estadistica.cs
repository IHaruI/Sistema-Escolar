using Biblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_y_TP
{
    public partial class Estadistica : Form
    {
        public Estadistica()
        {
            InitializeComponent();
        }

        private void Estadistica_Load(object sender, EventArgs e)
        {
            foreach (var item in Sql.LeerInscripciones())
            {
                if (!cmbMaterias.Items.Contains(item.Nombre))
                {
                    cmbMaterias.Items.Add(item.Nombre);
                }
            }
        }

        private void cmbMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cmbMaterias.SelectedIndex;

            double totalMateria;
            double promedio1;
            double? promedio2;
            double? sumador = 0;
            double contador = 0;

            foreach (var item in Sql.LeerInscripciones())
            {
                if (item.Nombre == cmbMaterias.Items[indice].ToString())
                {
                    sumador = sumador + item.Promedio;
                    contador++;
                }
            }

            totalMateria = Sql.LeerInscripciones().Count;
            promedio1 = totalMateria / contador;
            promedio2 = sumador / contador;

            lblPromedioDeAlumnos.Text = promedio1.ToString();
            lblPromedioDeCadaMateria.Text = promedio2.ToString();
        }
    }
}
