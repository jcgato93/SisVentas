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
            this.txtPrecio_Compra.Text=Convert.ToString(precio_compra);
            this.txtPrecio_Venta.Text = Convert.ToString(precio_venta);
            this.txtStock_actual.Text = Convert.ToString(stock);
            this.dtFecha_Vencimiento.Value = fecha_vencimiento;
           
        }

        public FrmVenta()
        {
            InitializeComponent();

            this.ttMensaje.SetToolTip(this.txtCliente,"Seleccione un Cliente");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese una Serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Ingrese un numero de comprobante");
            this.ttMensaje.SetToolTip(this.txtCantidad, "Ingrese la Cantidad del producto a vender");
            this.ttMensaje.SetToolTip(this.txtArticulo, "Seleccione un Artículo");

            this.txtIdcliente.Visible = false;
            this.txtIdarticulo.Visible = false;
            this.txtCliente.ReadOnly = true;
            this.txtArticulo.ReadOnly = true;
            this.dtFecha_Vencimiento.Enabled = false;
            this.txtPrecio_Compra.ReadOnly = true;
            this.txtStock_actual.ReadOnly = true;


        }

        //Mostrar mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtIdventa.Text = string.Empty;
            this.txtIdcliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtIgv.Text = string.Empty;
            this.lblTotal_Pagado.Text = "0.0";
            this.crearTabla();
            this.txtIgv.Text = "18";

        }

        private void limpiarDetalle()
        {
            this.txtIdarticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStock_actual.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            
            this.txtPrecio_Compra.Text = string.Empty;
            this.txtPrecio_Venta.Text = string.Empty;
        }

        //Habilitar controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdventa.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIgv.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cbTipo_Comprobante.Enabled = valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtPrecio_Compra.ReadOnly = !valor;
            this.txtPrecio_Venta.ReadOnly = !valor;
            this.txtStock_actual.Enabled = valor;
            this.dtFecha_Vencimiento.Enabled = valor;
            this.txtDescuento.Text = string.Empty;
            
            this.btnBuscarArticulo.Enabled = valor;
            this.btnBuscarCliente.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
        }


        //Hbilitar los botones
        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;

                this.btnCancelar.Enabled = true;

            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;

                this.btnCancelar.Enabled = false;
            }
        }

        //Ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;

        }

        //Metodo Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NVenta.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros : " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo BuscarFechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NVenta.BuscarFechas(this.dtFecha1.Value.ToString("dd/MM/yyyy"),
                this.dtFecha2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros : " + Convert.ToString(dataListado.Rows.Count);
        }


        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = NVenta.MostrarDetalle(this.txtIdventa.Text);

        }


        //llena el  DataGridView del FrmIngreso con los detalles del ingreso
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");

            this.dtDetalle.Columns.Add("iddetalle_Ingreso", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));

            //Relacionar DataGRidView con el DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;
        }



        private void FrmVenta_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value)) //evalua fila por fila si la cacilla del checkBox eliminar esta marcada
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NVenta.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Elimino Correctamente la Venta");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdventa.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idventa"].Value);
            this.txtCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cliente"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha"].Value);
            this.cbTipo_Comprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_comprobante"].Value);
            this.txtSerie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["serie"].Value);
            this.txtCorrelativo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["correlativo"].Value);
            this.lblTotal_Pagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["total"].Value);

            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;

            errorIcono.Clear();
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(true);
            this.txtSerie.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(false);
            this.txtSerie.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtIdcliente.Text == string.Empty || this.txtSerie.Text == string.Empty || this.txtCorrelativo.Text == string.Empty ||
                this.txtIgv.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtIdcliente, "Ingrese un Valor");
                    errorIcono.SetError(txtSerie, "Ingrese un Valor");
                    errorIcono.SetError(txtCorrelativo, "Ingrese un Valor");
                    errorIcono.SetError(txtIgv, "Ingrese un Valor");

                }
                else
                {

                    errorIcono.Clear();


                    if (this.IsNuevo == true)
                    {
                        rpta = NVenta.Insertar(Convert.ToInt32(this.txtIdcliente.Text), Idtrabajador,dtFecha.Value, cbTipo_Comprobante.Text, txtSerie.Text, txtCorrelativo.Text,
                            Convert.ToDecimal(txtIgv.Text), dtDetalle);
                    }


                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }

                    }

                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.limpiarDetalle();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtIdarticulo.Text == string.Empty || this.txtCantidad.Text == string.Empty || this.txtDescuento.Text == string.Empty ||
                this.txtPrecio_Venta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtIdarticulo, "Ingrese un Valor");
                    errorIcono.SetError(txtCantidad, "Ingrese un Valor");
                    errorIcono.SetError(txtDescuento, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecio_Venta, "Ingrese un Valor");

                }
                else
                {

                    bool registrar = true;

                    //bucle para verificar que los articulos agregados no esten repetidos
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["iddetalle_ingreso"]) == Convert.ToInt32(this.txtIdarticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("Ya se encuentra el artículo en el detalle");
                        }

                    }

                    if (registrar == true && Convert.ToInt32(txtCantidad.Text) <= Convert.ToInt32(txtStock_actual.Text))
                    {
                        decimal subTotal = Convert.ToInt32(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecio_Venta.Text) - Convert.ToDecimal(this.txtDescuento.Text);
                        totalPagado = totalPagado + subTotal;
                        this.lblTotal_Pagado.Text = totalPagado.ToString("#0.00#");

                        //Agregar ese detalle al datalistadoDetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["iddetalle_ingreso"] = Convert.ToInt32(this.txtIdarticulo.Text);
                        row["articulo"] = this.txtArticulo.Text;
                        row["cantidad"] = Convert.ToInt32(this.txtCantidad.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecio_Venta.Text);
                        row["descuento"] = Convert.ToDecimal(this.txtDescuento.Text);
                        row["subtotal"] = subTotal;


                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();

                    }
                    else {
                        MensajeError("No hay Stock Suficiente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];

                //Disminuir el totalPagado
                this.totalPagado = this.totalPagado - Convert.ToDecimal(row["subtotal"].ToString());

                this.lblTotal_Pagado.Text = totalPagado.ToString("#0.00#");

                //Se Remueve la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }


        //Envia el Idventa del dataListado al Idventa de la instancia de FrmReporteFactura para poder
        //asociarlos campos en el comprovante de venta
        private void btnComprobante_Click(object sender, EventArgs e)
        {
            FrmReporteFactura frm = new FrmReporteFactura();

            frm.Idventa = Convert.ToInt32(this.dataListado.CurrentRow.Cells["idventa"].Value);
            frm.ShowDialog();
          
           

        }
    }
}
