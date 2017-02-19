using System;
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
    public partial class FrmVenta : Form
    {
        private bool IsNuevo = false;
        public int Idtrabajador;
        private DataTable dtDetalle;

        

        private decimal totalPagado = 0;

        private static FrmVenta _instancia;

        public static FrmVenta GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmVenta();
            }
            
                return _instancia;
       }


        public void setCliente(string idcliente, string nombre)
        {
            this.txtIdcliente.Text = idcliente;
            this.txtCliente.Text = nombre;
        }


        public void setArticulo(string iddetalle_ingreso, string nombre,
          decimal precio_compra, decimal precio_venta, int stock, DateTime fecha_vencimiento)
        {
            this.txtIdarticulo.Text = iddetalle_ingreso;
            this.txtArticulo.Text = nombre;
            this.txtPrecioCompra.Text=Convert.ToString(precio_compra);
            this.txtPrecio_Venta.Text = Convert.ToString(precio_venta);
            this.txtStock_actual.Text = Convert.ToString(stock);
            this.dtFecha_Vencimiento.Value = fecha_vencimiento;
           
        }

        public FrmVenta()
        {
            InitializeComponent();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            
        }


        //Cuando se Cierre el formulario elemina la instancia del mismo
        private void FrmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmVistaCliente_Venta Vista = new FrmVistaCliente_Venta();
            Vista.ShowDialog();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            FrmVistaArticulo_Venta Vista = new FrmVistaArticulo_Venta();
            Vista.ShowDialog();
        }
    }
}
