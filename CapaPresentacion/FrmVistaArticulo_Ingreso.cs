﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmVistaArticulo_Ingreso : Form
    {
        public FrmVistaArticulo_Ingreso()
        {
            InitializeComponent();
        }

        private void FrmVistaArticulo_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();


        }

        //Ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[8].Visible = false;
        }

        //Metodo Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulo.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros : " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros : " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        /// <summary>
        /// Envia los datos seleccionados a las cajas de texto del FrmIngreso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmIngreso form = FrmIngreso.GetInstacia();

            //Parametros
            string par1, par2;

            par1 = Convert.ToString (this.dataListado.CurrentRow.Cells["idarticulo"].Value);
            par2 = Convert .ToString (this.dataListado.CurrentRow.Cells["nombre"].Value);

            form.setArticulo(par1, par2);

            this.Hide();
        }

    }
}
