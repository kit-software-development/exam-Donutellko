namespace McDonatsClient
{
    partial class FoodControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Title = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.OrderCount = new System.Windows.Forms.NumericUpDown();
            this.quantity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OrderCount)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Title.Location = new System.Drawing.Point(5, 11);
            this.Title.MaximumSize = new System.Drawing.Size(160, 50);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(158, 50);
            this.Title.TabIndex = 0;
            this.Title.Text = "Ьургер с глютаматом";
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Price.Location = new System.Drawing.Point(14, 73);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(52, 18);
            this.Price.TabIndex = 1;
            this.Price.Text = "123.45";
            // 
            // OrderCount
            // 
            this.OrderCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrderCount.Location = new System.Drawing.Point(12, 127);
            this.OrderCount.Name = "OrderCount";
            this.OrderCount.Size = new System.Drawing.Size(120, 24);
            this.OrderCount.TabIndex = 2;
            this.OrderCount.ValueChanged += new System.EventHandler(this.OrderCount_ValueChanged);
            // 
            // quantity
            // 
            this.quantity.AutoSize = true;
            this.quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quantity.Location = new System.Drawing.Point(14, 99);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(71, 18);
            this.quantity.TabIndex = 3;
            this.quantity.Text = "Остаток:";
            // 
            // FoodControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.quantity);
            this.Controls.Add(this.OrderCount);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.Title);
            this.Name = "FoodControl";
            this.Size = new System.Drawing.Size(166, 166);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrderCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Price;
        internal System.Windows.Forms.NumericUpDown OrderCount;
        private System.Windows.Forms.Label quantity;
    }
}
