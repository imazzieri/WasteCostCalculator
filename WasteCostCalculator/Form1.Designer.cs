namespace WasteCostCalculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            foodsToolStripMenuItem = new ToolStripMenuItem();
            wasteToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            WastePanel = new Panel();
            label10 = new Label();
            label9 = new Label();
            newWasteFoodCostTextbox = new TextBox();
            dateWasteLabel = new Label();
            deleteWasteBtn = new Button();
            WastesListView = new ListView();
            editWasteBtn = new Button();
            addWasteBtn = new Button();
            newWasteQuantiryLabel = new Label();
            newWasteQuantityTextBox = new TextBox();
            label4 = new Label();
            newWasteReasonTextBox = new TextBox();
            label3 = new Label();
            NewWasteFoodSelector = new ComboBox();
            foodBindingSource = new BindingSource(components);
            label2 = new Label();
            label1 = new Label();
            newWasteDatePicker = new DateTimePicker();
            FoodPanel = new Panel();
            MeasurementUnitTextbox = new TextBox();
            CurrencyLabel = new Label();
            DeleteFoodButton = new Button();
            EditFoodButton = new Button();
            AddFoodButton = new Button();
            label7 = new Label();
            label6 = new Label();
            newFoodCostTextbox = new TextBox();
            label5 = new Label();
            newFoodNameTextBox = new TextBox();
            AllFoodLabel = new Label();
            AllFoodListView = new ListView();
            wasteBindingSource = new BindingSource(components);
            errorProvider = new ErrorProvider(components);
            ReportPanel = new Panel();
            monthDetailsListview = new ListView();
            label11 = new Label();
            monthlyReportListview = new ListView();
            label8 = new Label();
            menuStrip1.SuspendLayout();
            WastePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)foodBindingSource).BeginInit();
            FoodPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wasteBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ReportPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { foodsToolStripMenuItem, wasteToolStripMenuItem, reportsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // foodsToolStripMenuItem
            // 
            foodsToolStripMenuItem.Name = "foodsToolStripMenuItem";
            foodsToolStripMenuItem.Size = new Size(51, 20);
            foodsToolStripMenuItem.Text = "Foods";
            foodsToolStripMenuItem.Click += foodsToolStripMenuItem_Click;
            // 
            // wasteToolStripMenuItem
            // 
            wasteToolStripMenuItem.Name = "wasteToolStripMenuItem";
            wasteToolStripMenuItem.Size = new Size(51, 20);
            wasteToolStripMenuItem.Text = "Waste";
            wasteToolStripMenuItem.Click += wasteToolStripMenuItem_Click;
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(59, 20);
            reportsToolStripMenuItem.Text = "Reports";
            reportsToolStripMenuItem.Click += reportsToolStripMenuItem_Click;
            // 
            // WastePanel
            // 
            WastePanel.Controls.Add(label10);
            WastePanel.Controls.Add(label9);
            WastePanel.Controls.Add(newWasteFoodCostTextbox);
            WastePanel.Controls.Add(dateWasteLabel);
            WastePanel.Controls.Add(deleteWasteBtn);
            WastePanel.Controls.Add(WastesListView);
            WastePanel.Controls.Add(editWasteBtn);
            WastePanel.Controls.Add(addWasteBtn);
            WastePanel.Controls.Add(newWasteQuantiryLabel);
            WastePanel.Controls.Add(newWasteQuantityTextBox);
            WastePanel.Controls.Add(label4);
            WastePanel.Controls.Add(newWasteReasonTextBox);
            WastePanel.Controls.Add(label3);
            WastePanel.Controls.Add(NewWasteFoodSelector);
            WastePanel.Controls.Add(label2);
            WastePanel.Controls.Add(label1);
            WastePanel.Controls.Add(newWasteDatePicker);
            WastePanel.Dock = DockStyle.Fill;
            WastePanel.Location = new Point(0, 24);
            WastePanel.Name = "WastePanel";
            WastePanel.Size = new Size(800, 426);
            WastePanel.TabIndex = 1;
            WastePanel.Visible = false;
            WastePanel.VisibleChanged += updateWastePanel;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(234, 245);
            label10.Name = "label10";
            label10.Size = new Size(18, 15);
            label10.TabIndex = 17;
            label10.Text = "Kr";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 219);
            label9.Name = "label9";
            label9.Size = new Size(59, 15);
            label9.TabIndex = 16;
            label9.Text = "Food cost";
            // 
            // newWasteFoodCostTextbox
            // 
            newWasteFoodCostTextbox.Location = new Point(7, 237);
            newWasteFoodCostTextbox.Name = "newWasteFoodCostTextbox";
            newWasteFoodCostTextbox.Size = new Size(221, 23);
            newWasteFoodCostTextbox.TabIndex = 15;
            newWasteFoodCostTextbox.KeyPress += numericFieldHandler;
            // 
            // dateWasteLabel
            // 
            dateWasteLabel.AutoSize = true;
            dateWasteLabel.Location = new Point(359, 32);
            dateWasteLabel.Name = "dateWasteLabel";
            dateWasteLabel.Size = new Size(103, 15);
            dateWasteLabel.TabIndex = 14;
            dateWasteLabel.Text = "01/01/1991 wastes";
            // 
            // deleteWasteBtn
            // 
            deleteWasteBtn.Location = new Point(440, 353);
            deleteWasteBtn.Name = "deleteWasteBtn";
            deleteWasteBtn.Size = new Size(86, 23);
            deleteWasteBtn.TabIndex = 13;
            deleteWasteBtn.Text = "Delete Waste";
            deleteWasteBtn.UseVisualStyleBackColor = true;
            deleteWasteBtn.Click += deleteWasteBtn_Click;
            // 
            // WastesListView
            // 
            WastesListView.Location = new Point(359, 50);
            WastesListView.Name = "WastesListView";
            WastesListView.Size = new Size(429, 268);
            WastesListView.TabIndex = 12;
            WastesListView.UseCompatibleStateImageBehavior = false;
            WastesListView.ItemSelectionChanged += WastesListView_ItemSelectionChanged;
            // 
            // editWasteBtn
            // 
            editWasteBtn.Location = new Point(359, 353);
            editWasteBtn.Name = "editWasteBtn";
            editWasteBtn.Size = new Size(75, 23);
            editWasteBtn.TabIndex = 11;
            editWasteBtn.Text = "Edit Waste";
            editWasteBtn.UseVisualStyleBackColor = true;
            editWasteBtn.Click += editWasteBtn_Click;
            // 
            // addWasteBtn
            // 
            addWasteBtn.Location = new Point(10, 391);
            addWasteBtn.Name = "addWasteBtn";
            addWasteBtn.Size = new Size(75, 23);
            addWasteBtn.TabIndex = 10;
            addWasteBtn.Text = "Add Waste";
            addWasteBtn.UseVisualStyleBackColor = true;
            addWasteBtn.Click += AddWasteBtn_Click;
            // 
            // newWasteQuantiryLabel
            // 
            newWasteQuantiryLabel.AutoSize = true;
            newWasteQuantiryLabel.Location = new Point(234, 178);
            newWasteQuantiryLabel.Name = "newWasteQuantiryLabel";
            newWasteQuantiryLabel.Size = new Size(21, 15);
            newWasteQuantiryLabel.TabIndex = 9;
            newWasteQuantiryLabel.Text = "Kg";
            // 
            // newWasteQuantityTextBox
            // 
            newWasteQuantityTextBox.Location = new Point(7, 175);
            newWasteQuantityTextBox.Name = "newWasteQuantityTextBox";
            newWasteQuantityTextBox.Size = new Size(221, 23);
            newWasteQuantityTextBox.TabIndex = 8;
            newWasteQuantityTextBox.KeyPress += numericFieldHandler;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 277);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 7;
            label4.Text = "Waste reason";
            // 
            // newWasteReasonTextBox
            // 
            newWasteReasonTextBox.Location = new Point(8, 295);
            newWasteReasonTextBox.Name = "newWasteReasonTextBox";
            newWasteReasonTextBox.Size = new Size(220, 23);
            newWasteReasonTextBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 157);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 5;
            label3.Text = "Quantity wasted";
            // 
            // NewWasteFoodSelector
            // 
            NewWasteFoodSelector.DataBindings.Add(new Binding("DataContext", foodBindingSource, "Name", true));
            NewWasteFoodSelector.DataSource = foodBindingSource;
            NewWasteFoodSelector.DisplayMember = "Name";
            NewWasteFoodSelector.FormattingEnabled = true;
            NewWasteFoodSelector.Location = new Point(8, 122);
            NewWasteFoodSelector.Name = "NewWasteFoodSelector";
            NewWasteFoodSelector.Size = new Size(220, 23);
            NewWasteFoodSelector.TabIndex = 3;
            NewWasteFoodSelector.SelectedIndexChanged += FoodSelector_SelectedIndexChanged;
            // 
            // foodBindingSource
            // 
            foodBindingSource.DataSource = typeof(Food);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 104);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 2;
            label2.Text = "Food Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 32);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 1;
            label1.Text = "Date of waste";
            // 
            // newWasteDatePicker
            // 
            newWasteDatePicker.Location = new Point(12, 50);
            newWasteDatePicker.Name = "newWasteDatePicker";
            newWasteDatePicker.Size = new Size(221, 23);
            newWasteDatePicker.TabIndex = 0;
            newWasteDatePicker.CloseUp += newWasteDatePicker_CloseUp;
            // 
            // FoodPanel
            // 
            FoodPanel.Controls.Add(MeasurementUnitTextbox);
            FoodPanel.Controls.Add(CurrencyLabel);
            FoodPanel.Controls.Add(DeleteFoodButton);
            FoodPanel.Controls.Add(EditFoodButton);
            FoodPanel.Controls.Add(AddFoodButton);
            FoodPanel.Controls.Add(label7);
            FoodPanel.Controls.Add(label6);
            FoodPanel.Controls.Add(newFoodCostTextbox);
            FoodPanel.Controls.Add(label5);
            FoodPanel.Controls.Add(newFoodNameTextBox);
            FoodPanel.Controls.Add(AllFoodLabel);
            FoodPanel.Controls.Add(AllFoodListView);
            FoodPanel.Dock = DockStyle.Fill;
            FoodPanel.Location = new Point(0, 24);
            FoodPanel.Name = "FoodPanel";
            FoodPanel.Size = new Size(800, 426);
            FoodPanel.TabIndex = 15;
            // 
            // MeasurementUnitTextbox
            // 
            MeasurementUnitTextbox.Location = new Point(13, 196);
            MeasurementUnitTextbox.Name = "MeasurementUnitTextbox";
            MeasurementUnitTextbox.Size = new Size(121, 23);
            MeasurementUnitTextbox.TabIndex = 19;
            // 
            // CurrencyLabel
            // 
            CurrencyLabel.AutoSize = true;
            CurrencyLabel.Location = new Point(139, 125);
            CurrencyLabel.Name = "CurrencyLabel";
            CurrencyLabel.Size = new Size(17, 15);
            CurrencyLabel.TabIndex = 17;
            CurrencyLabel.Text = "kr";
            // 
            // DeleteFoodButton
            // 
            DeleteFoodButton.Location = new Point(174, 287);
            DeleteFoodButton.Name = "DeleteFoodButton";
            DeleteFoodButton.Size = new Size(86, 23);
            DeleteFoodButton.TabIndex = 16;
            DeleteFoodButton.Text = "Delete Food";
            DeleteFoodButton.UseVisualStyleBackColor = true;
            DeleteFoodButton.Click += DeleteFoodButton_Click;
            // 
            // EditFoodButton
            // 
            EditFoodButton.Location = new Point(93, 287);
            EditFoodButton.Name = "EditFoodButton";
            EditFoodButton.Size = new Size(75, 23);
            EditFoodButton.TabIndex = 15;
            EditFoodButton.Text = "Edit Food";
            EditFoodButton.UseVisualStyleBackColor = true;
            EditFoodButton.Click += EditFoodButton_Click;
            // 
            // AddFoodButton
            // 
            AddFoodButton.Location = new Point(12, 287);
            AddFoodButton.Name = "AddFoodButton";
            AddFoodButton.Size = new Size(75, 23);
            AddFoodButton.TabIndex = 14;
            AddFoodButton.Text = "Add Food";
            AddFoodButton.UseVisualStyleBackColor = true;
            AddFoodButton.Click += AddFoodButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 178);
            label7.Name = "label7";
            label7.Size = new Size(104, 15);
            label7.TabIndex = 7;
            label7.Text = "Measurement unit";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 104);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 5;
            label6.Text = "Food cost";
            // 
            // newFoodCostTextbox
            // 
            newFoodCostTextbox.Location = new Point(12, 122);
            newFoodCostTextbox.Name = "newFoodCostTextbox";
            newFoodCostTextbox.Size = new Size(121, 23);
            newFoodCostTextbox.TabIndex = 4;
            newFoodCostTextbox.KeyPress += numericFieldHandler;
            newFoodCostTextbox.Validated += FoodCostTextbox_Validated;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 32);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 3;
            label5.Text = "Food name";
            // 
            // newFoodNameTextBox
            // 
            newFoodNameTextBox.Location = new Point(13, 53);
            newFoodNameTextBox.Name = "newFoodNameTextBox";
            newFoodNameTextBox.Size = new Size(120, 23);
            newFoodNameTextBox.TabIndex = 2;
            newFoodNameTextBox.Validating += newFoodNameTextBox_Validating;
            newFoodNameTextBox.Validated += NewFoodNameTextBox_Validated;
            // 
            // AllFoodLabel
            // 
            AllFoodLabel.AutoSize = true;
            AllFoodLabel.Location = new Point(474, 32);
            AllFoodLabel.Name = "AllFoodLabel";
            AllFoodLabel.Size = new Size(98, 15);
            AllFoodLabel.TabIndex = 1;
            AllFoodLabel.Text = "All existing foods";
            // 
            // AllFoodListView
            // 
            AllFoodListView.Location = new Point(474, 50);
            AllFoodListView.Name = "AllFoodListView";
            AllFoodListView.Size = new Size(273, 260);
            AllFoodListView.TabIndex = 0;
            AllFoodListView.UseCompatibleStateImageBehavior = false;
            AllFoodListView.ItemSelectionChanged += AllFoodListView_ItemSelectionChanged;
            // 
            // wasteBindingSource
            // 
            wasteBindingSource.DataSource = typeof(Waste);
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // ReportPanel
            // 
            ReportPanel.Controls.Add(monthDetailsListview);
            ReportPanel.Controls.Add(label11);
            ReportPanel.Controls.Add(monthlyReportListview);
            ReportPanel.Controls.Add(label8);
            ReportPanel.Dock = DockStyle.Fill;
            ReportPanel.Location = new Point(0, 24);
            ReportPanel.Name = "ReportPanel";
            ReportPanel.Size = new Size(800, 426);
            ReportPanel.TabIndex = 15;
            ReportPanel.Visible = false;
            // 
            // monthDetailsListview
            // 
            monthDetailsListview.Location = new Point(339, 47);
            monthDetailsListview.Name = "monthDetailsListview";
            monthDetailsListview.Size = new Size(395, 367);
            monthDetailsListview.TabIndex = 19;
            monthDetailsListview.UseCompatibleStateImageBehavior = false;
            monthDetailsListview.MouseDoubleClick += monthDetailsListview_MouseDoubleClick;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(339, 29);
            label11.Name = "label11";
            label11.Size = new Size(80, 15);
            label11.TabIndex = 18;
            label11.Text = "Month details";
            // 
            // monthlyReportListview
            // 
            monthlyReportListview.Location = new Point(12, 47);
            monthlyReportListview.Name = "monthlyReportListview";
            monthlyReportListview.Size = new Size(216, 367);
            monthlyReportListview.TabIndex = 17;
            monthlyReportListview.UseCompatibleStateImageBehavior = false;
            monthlyReportListview.ItemSelectionChanged += monthlyReportListview_ItemSelectionChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 29);
            label8.Name = "label8";
            label8.Size = new Size(87, 15);
            label8.TabIndex = 16;
            label8.Text = "Monthly report";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ReportPanel);
            Controls.Add(FoodPanel);
            Controls.Add(WastePanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Waste cost calculator";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            WastePanel.ResumeLayout(false);
            WastePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)foodBindingSource).EndInit();
            FoodPanel.ResumeLayout(false);
            FoodPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)wasteBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ReportPanel.ResumeLayout(false);
            ReportPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem wasteToolStripMenuItem;
        private ToolStripMenuItem foodsToolStripMenuItem;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private Panel WastePanel;
        private DateTimePicker newWasteDatePicker;
        private Label label1;
        private Label label2;
        private ComboBox NewWasteFoodSelector;
        private TextBox newWasteReasonTextBox;
        private Label label3;
        private Label label4;
        private TextBox newWasteQuantityTextBox;
        private Label newWasteQuantiryLabel;
        private Button editWasteBtn;
        private Button addWasteBtn;
        private ListView WastesListView;
        private Button deleteWasteBtn;
        private Label dateWasteLabel;
        private BindingSource foodBindingSource;
        private BindingSource wasteBindingSource;
        private Panel FoodPanel;
        private Label label5;
        private TextBox newFoodNameTextBox;
        private Label AllFoodLabel;
        private ListView AllFoodListView;
        private Button DeleteFoodButton;
        private Button EditFoodButton;
        private Button AddFoodButton;
        private Label label7;
        private Label label6;
        private TextBox newFoodCostTextbox;
        private Label CurrencyLabel;
        private ErrorProvider errorProvider;
        private TextBox MeasurementUnitTextbox;
        private Panel ReportPanel;
        private Label label8;
        private Label label9;
        private TextBox newWasteFoodCostTextbox;
        private Label label10;
        private ListView monthDetailsListview;
        private Label label11;
        private ListView monthlyReportListview;
    }
}
