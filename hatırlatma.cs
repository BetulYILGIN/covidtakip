using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace covid_takip
{
    public partial class hatırlatma : Form
    {
        public hatırlatma()
        {
            InitializeComponent();
        }
        public string hatırlat = "";
       
        
        private void hatırlatma_Load(object sender, EventArgs e)
        {
            label1.Text = hatırlat;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
