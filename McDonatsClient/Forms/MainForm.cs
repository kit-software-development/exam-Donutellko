using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net;

namespace McDonatsClient
{

	public partial class MainForm : Form
	{
		private String Url { get; set; } = "http://muffin-ti.me:8086";


		public Dictionary<int, Food> foods = new Dictionary<int, Food>();
		public Dictionary<int, int> counts = new Dictionary<int, int>();


		/// <summary>
		/// Main form that is used to select items for order, and confirm it.
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Initialisation of main form.
		/// It loads and shows whole menu, letting user to select counts of items, 
		/// then shows all selected items and lets confirm it.
		/// On order confirm send order to server, which returns cheque to be shown (and printed) to user.
		/// If error occured, show its text in a Message Box.
		/// </summary>
		private void Form1_Load(object sender, EventArgs e)
		{
			DataContractJsonSerializer FoodSerializer = new DataContractJsonSerializer(typeof(List<Food>));
			List<Food> foodList;
			var client = new WebClient();
			client.Encoding = Encoding.UTF8;
			try
			{
				var json = client.DownloadString(Url + "/customer/food");
				using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
				{
					foodList = (List<Food>)FoodSerializer.ReadObject(ms);
				}

				// var Foods = new FoodControl[];
				foreach (var food in foodList)
				{
					foods[food.FoodId] = food;
				}

				FillFlow();
			}
			catch (WebException ex)
			{
				MessageBox.Show("Ошибка подключения к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			};

		}

		/// <summary>
		/// Each time a count of items is changed, total sum of order should be recalculated.
		/// </summary>
		private void RecalcSum()
		{
			double sum = 0;
			foreach (var id in counts.Keys)
			{
				sum += foods[id].Price * counts[id];
			}
			Sum.Text = $"Сумма: {sum}";
		}

		/// <summary>
		/// On click show user all the items he selected and let him confirm order. 
		/// The button becomes hidden.
		/// </summary>
		private void Button1_Click(object sender, EventArgs e)
		{
			Back.Visible = true;
			Confirm.Visible = true;
			Order.Visible = false;

			FillFlow(false);
		}

		/// <summary>
		/// If user decided to add more items, on click the whole menu is displayed.
		/// The counts that were changed in state of confirming order remains.
		/// </summary>
		private void Back_Click(object sender, EventArgs e)
		{
			FillFlow();

			Back.Visible = false;
			Confirm.Visible = false;
			Order.Visible = true;
		}


		/// <summary>
		/// Show menu. If zero is true, the whole menu is shown. Only items that have positive counts 
		/// are shown otherwise. 
		/// </summary>
		/// <param name="zero">if need to show whole menu. Default is true.</param>
		private void FillFlow(bool zero = true)
		{
			flowLayoutPanel1.Controls.Clear();

			foreach (var food in foods.Values)
			{
				int count = 0;
				counts.TryGetValue(food.FoodId, out count);

				if (zero || count > 0)
				{
					FoodControl foodControl = new FoodControl(food, count);
					foodControl.OnCountChanged = (int id, int c) =>
					{
						counts[id] = c;
						RecalcSum();
						return true;
					};
					flowLayoutPanel1.Controls.Add(foodControl);
				}
			}
		}

		/// <summary>
		/// Send order to server and show cheque that server has returned, or
		/// MessageBox with an error description text, if some error occured.
		/// </summary>
		private void Confirm_Click(object sender, EventArgs e)
		{
			var k = new List<FoodCount>();
			foreach (var food in counts)
			{
				if (food.Value > 0)
				{
					k.Add(new FoodCount(food.Key, food.Value));
				}
			}
			DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<FoodCount>));

			var httpWebRequest = (HttpWebRequest)WebRequest.Create(Url + "/customer/order");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";


			jsonSerializer.WriteObject(httpWebRequest.GetRequestStream(), k);



			try
			{
				var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					string result = streamReader.ReadToEnd();
					Check check = new Check(result);
					check.Show();
				}
			}
			catch (WebException ex)
			{
				using (var streamReader = new StreamReader(ex.Response.GetResponseStream()))
				{
					string result = streamReader.ReadToEnd();
					MessageBox.Show(result, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
