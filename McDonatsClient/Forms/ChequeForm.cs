using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McDonatsClient
{
	/// <summary>
	/// Form that shows cheque of a placed order.
	/// </summary>
    public partial class Check : Form
    {

        public Check(string result) { 
            InitializeComponent();
            label1.Text = result;
        }

        private void Check_Load(object sender, EventArgs e)
        {
            
        }
    }
}
