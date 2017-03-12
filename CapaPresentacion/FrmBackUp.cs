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
    public partial class FrmBackUp : Form
    {
        

        public FrmBackUp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Up_Click(object sender, EventArgs e)
        {

           MessageBox.Show( NBackUP.Back_UP());
            
            
        }

        private void FrmBackUp_Load(object sender, EventArgs e)
        {
            this.Top = 100;
            this.Left = 50;
        }
    }
}
