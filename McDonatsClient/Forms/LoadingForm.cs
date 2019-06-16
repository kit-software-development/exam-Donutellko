using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McDonatsClient
{
	/// <summary>
	/// Form that is shown during loading of data.
	/// </summary>
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
			InitializeComponent();
        }

		private void LoadingForm_Load(object sender, EventArgs e)
		{

		}
	}
}
