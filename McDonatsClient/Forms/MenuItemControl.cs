using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McDonatsClient
{
    public partial class FoodControl : UserControl
    {
        public int FoodId { get; set; }

        public Func<int, int, bool> OnCountChanged { get; set; }

        public FoodControl(Food food, int count = 0, bool immutable = false)
        {
            FoodId = food.FoodId;
            InitializeComponent();
            Title.Text = food.Title;
            Price.Text = "Цена: " + food.Price + " руб.";
            quantity.Text = $"Остаток: {food.Count}";
            OrderCount.Maximum = (decimal)food.Count;
            OrderCount.Value = count;
            if (immutable)
                OrderCount.Enabled = false;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        internal int Count() => (int)OrderCount.Value;



        private void OrderCount_ValueChanged(object sender, EventArgs e)
        {
            if (OnCountChanged != null)
                OnCountChanged(FoodId, Count());
        }
    }
}
