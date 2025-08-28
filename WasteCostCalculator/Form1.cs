namespace WasteCostCalculator
{
    public partial class Form1: Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            DBUtils.CreateDBifNotExists();
            dateWasteLabel.Text = DateTime.Today.ToShortDateString();
            PopulateNewWasteFoodSelector();
            Initializer.InitializeWastesListView(WastesListView);
            Initializer.InitializeAllFoodListView(AllFoodListView);
            Initializer.InitializeReportListView(monthDetailsListview);
            Initializer.InitializeReportListView(monthlyReportListview);
            Singleton.Istance.panels.Add(WastePanel);
            Singleton.Istance.panels.Add(FoodPanel);
            Singleton.Istance.panels.Add(ReportPanel);
        }
        public void PopulateNewWasteFoodSelector() {
            NewWasteFoodSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            foodBindingSource.DataSource = DBUtils.getAllFoods().ToList();
            var initialFood = DBUtils.GetFoodByName(NewWasteFoodSelector.Text);
            newWasteQuantiryLabel.Text = initialFood.MeasurementUnit;
            if(initialFood.Cost != -1)
                newWasteFoodCostTextbox.Text = initialFood.Cost.ToString();
        }
        private void foodsToolStripMenuItem_Click(object sender, EventArgs e) {
            Initializer.ShowSelectedPanel(FoodPanel);
            errorProvider.Clear();
        }
        private void wasteToolStripMenuItem_Click(object sender, EventArgs e) {
            Initializer.ShowSelectedPanel(WastePanel);
            errorProvider.Clear();
        }
        private void reportsToolStripMenuItem_Click(object sender, EventArgs e) {
            Initializer.ShowSelectedPanel(ReportPanel);
            errorProvider.Clear();
        }

        /*
         * This does NOT force the focus on the textbox, as it would messes up with the edit/delete function
         * The "AddFoodButton" is delegated to handle it
         * It's probably better to use a different errorProvider with a different icon for this warning
         */
        private void newFoodNameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            if(DBUtils.DoesTheFoodAlreadyExsists(newFoodNameTextBox.Text)) {
                errorProvider.SetError(newFoodNameTextBox, "The food already exists");
            }
        }

        //TODO hardcoded error messages
        private void AddFoodButton_Click(object sender, EventArgs e) {
            if(newFoodCostTextbox.Text == "") {//trim() isn't needed because this texbox accept only digits and one dot
                errorProvider.SetError(newFoodCostTextbox, "The cost of the food is required!");
                newFoodCostTextbox.Focus();
            } else {
                Food food = new Food() { Name = newFoodNameTextBox.Text, Cost = float.Parse(newFoodCostTextbox.Text), MeasurementUnit = MeasurementUnitTextbox.Text };
                switch(DBUtils.AddFoodToDB(food)) {
                    case newFoodErrors.NoError:
                        Initializer.UpdateAllFoodsListViewData(AllFoodListView);
                        errorProvider.Clear();
                        break;
                    case newFoodErrors.NullFood:
                        //this case should never come up here
                        MessageBox.Show("Something went incredibly wrong, try restarting the program", "OH NO!!!!!!");
                        break;
                    case newFoodErrors.EmptyName:
                        errorProvider.SetError(newFoodNameTextBox, "The name is required!");
                        newFoodNameTextBox.Focus();
                        break;
                    case newFoodErrors.ExistingName:
                        errorProvider.SetError(newFoodNameTextBox, "Food already exists!");
                        newFoodNameTextBox.Focus();
                        break;
                    case newFoodErrors.EmptyMeasurementUnit:
                        errorProvider.SetError(MeasurementUnitTextbox, "The measurement unit is required!");
                        MeasurementUnitTextbox.Focus();
                        break;
                }
            }
        }

        private void EditFoodButton_Click(object sender, EventArgs e) {
            if(newFoodCostTextbox.Text == "") {//trim() isn't needed because this texbox accept only digits and one dot
                errorProvider.SetError(newFoodCostTextbox, "The cost of the food is required!");
                newFoodCostTextbox.Focus();
            } else {
                Food food = new Food() { Name = newFoodNameTextBox.Text, Cost = float.Parse(newFoodCostTextbox.Text), MeasurementUnit = MeasurementUnitTextbox.Text };
                switch(DBUtils.SaveEditedFoodToDB(food)) {
                    case newFoodErrors.NoError://food name not found?
                        errorProvider.SetError(newFoodNameTextBox, "The food doesn't exist");
                        break;
                    case newFoodErrors.EmptyName:
                        errorProvider.SetError(newFoodNameTextBox, "Please input the name of the food to edit");
                        break;
                    case newFoodErrors.ExistingName://everything went fine
                        Initializer.UpdateAllFoodsListViewData(AllFoodListView);
                        errorProvider.Clear();
                        break;
                    case newFoodErrors.EmptyMeasurementUnit:
                        errorProvider.SetError(MeasurementUnitTextbox, "The measurement unit is required!");
                        break;
                    case newFoodErrors.NullFood:
                        //this case should never come up here
                        MessageBox.Show("Something went incredibly wrong, try restarting the program", "OH NO!!!!!!");
                        break;
                }
            }

        }

        private void NewFoodNameTextBox_Validated(object sender, EventArgs e) {
            if(errorProvider.GetError(newFoodNameTextBox) != null && !DBUtils.DoesTheFoodAlreadyExsists(newFoodNameTextBox.Text))
                errorProvider.SetError(newFoodNameTextBox, "");
        }

        private void FoodCostTextbox_Validated(object sender, EventArgs e) {
            if(newFoodCostTextbox.Text != "" && newFoodCostTextbox.Text != ".")
                errorProvider.SetError(newFoodCostTextbox, "");
        }

        private void AllFoodListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if(e.Item != null) {
                newFoodNameTextBox.Text = e.Item.SubItems[0].Text;
                newFoodCostTextbox.Text = e.Item.SubItems[1].Text;
                MeasurementUnitTextbox.Text = e.Item.SubItems[2].Text;
            }
        }

        private void DeleteFoodButton_Click(object sender, EventArgs e) {
            DBUtils.DeleteFoodFromDB(new Food() { Name = newFoodNameTextBox.Text, Cost = float.Parse(newFoodCostTextbox.Text), MeasurementUnit = MeasurementUnitTextbox.Text });
            Initializer.UpdateAllFoodsListViewData(AllFoodListView);
        }

        private void AddWasteBtn_Click(object sender, EventArgs e) {
            var quantityWasted = 0.0f;
            if(newWasteQuantityTextBox.Text.Trim() == "") {
                errorProvider.SetError(newWasteQuantityTextBox, "Please input a quantity");
            } else {
                if(newWasteFoodCostTextbox.Text.Trim() == "")
                    errorProvider.SetError(newWasteQuantityTextBox, "Please input a quantity");
                else {
                    quantityWasted = float.Parse(newWasteQuantityTextBox.Text);
                    Waste wasteToAdd = new Waste() { Date = Singleton.Istance.selectedDate, QuantityWasted = quantityWasted, Reason = newWasteReasonTextBox.Text, FoodCostAtWasteDate = float.Parse(newWasteFoodCostTextbox.Text) };
                    DBUtils.AddWasteToDB(wasteToAdd, NewWasteFoodSelector.Text);
                    Initializer.UpdateWastesListViewData(WastesListView);
                    errorProvider.SetError(newWasteQuantityTextBox, "");
                }
            }
        }

        private void deleteWasteBtn_Click(object sender, EventArgs e) {
            if(WastesListView.SelectedIndices.Count == 1) {
                DBUtils.DeleteWasteFromDB(int.Parse(WastesListView.Items[WastesListView.SelectedIndices[0]].SubItems[3].Text));
                Initializer.UpdateWastesListViewData(WastesListView);
            } else
                MessageBox.Show("Plese select a waste to delete from the list");
        }

        private void FoodSelector_SelectedIndexChanged(object sender, EventArgs e) {
            var selectedFood = DBUtils.GetFoodByName(NewWasteFoodSelector.Text);
            if(selectedFood.Name != "") {
                newWasteQuantiryLabel.Text = selectedFood.MeasurementUnit;
                newWasteFoodCostTextbox.Text = selectedFood.Cost.ToString();
            }
        }

        private void newWasteDatePicker_CloseUp(object sender, EventArgs e) {
            string cleanedSelectedDate = DateTime.Parse(newWasteDatePicker.Text).ToShortDateString();//this convert the month from being spelled out to the dd/MM/yyyy format
            if(cleanedSelectedDate != Singleton.Istance.selectedDate) {
                Singleton.Istance.selectedDate = cleanedSelectedDate;
                dateWasteLabel.Text = Singleton.Istance.selectedDate;
                Initializer.UpdateWastesListViewData(WastesListView);
            }
        }

        //TODO as for now there is no way to edit the date
        private void editWasteBtn_Click(object sender, EventArgs e) {
            if(newWasteQuantityTextBox.Text.Trim() == "") {
                errorProvider.SetError(newWasteQuantityTextBox, "Please input a quantity");
            } else {
                if(newWasteFoodCostTextbox.Text.Trim() == "")
                    errorProvider.SetError(newWasteQuantityTextBox, "Please input a quantity");
                else {
                    if(WastesListView.SelectedIndices.Count == 1) {
                        var wasteID = int.Parse(WastesListView.Items[WastesListView.SelectedIndices[0]].SubItems[3].Text);
                        var associatedFoodID = DBUtils.GetFoodByName(NewWasteFoodSelector.Text).FoodId;
                        var waste = new Waste() { WasteId = wasteID, Date = Singleton.Istance.selectedDate, FoodCostAtWasteDate = float.Parse(newWasteFoodCostTextbox.Text), QuantityWasted = float.Parse(newWasteQuantityTextBox.Text), FoodId = associatedFoodID };
                        DBUtils.SaveEditedWasteToDB(waste);
                        Initializer.UpdateWastesListViewData(WastesListView);
                    } else
                        MessageBox.Show("Plese select a waste to edit from the list");
                }
            }
        }

        private void WastesListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if(e.Item != null) {//TODO HARDCODED INDEX >:(
                var wasteID = int.Parse(e.Item.SubItems[3].Text);//you have to trust me on the index for now
                var waste = DBUtils.GetWasteByID(wasteID);
                var food = DBUtils.GetFoodByName(e.Item.SubItems[0].Text);
                NewWasteFoodSelector.Text = food.Name;
                newWasteQuantityTextBox.Text = waste.QuantityWasted.ToString();
                newWasteFoodCostTextbox.Text = waste.FoodCostAtWasteDate.ToString();
                newWasteReasonTextBox.Text = waste.Reason;
            }
        }

        private void NewWasteQuantityTextBox_KeyDown(object sender, KeyEventArgs e) {

        }

        private void numericFieldHandler(object? sender, KeyPressEventArgs e) {
            //TODO '\b' is Del, replace it with something legible
            if(e != null && sender != null) {
                if(e.KeyChar != '\b' && !char.IsDigit(e.KeyChar) && ((e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.')) || e.KeyChar != '.')) {
                    e.Handled = true;
                }
            }
        }

        private void monthlyReportListview_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if(e.Item != null) {
                Singleton.Istance.selectedMonth = e.Item.Text;
                Initializer.UpdateMonthDetailsListview(monthDetailsListview);
            }
        }

        private void monthDetailsListview_MouseDoubleClick(object sender, MouseEventArgs e) {
            if(monthDetailsListview.SelectedItems != null) {
                Singleton.Istance.selectedDate = monthDetailsListview.SelectedItems[0].SubItems[0].Text;
                Initializer.ShowSelectedPanel(WastePanel);
            }
        }

        private void updateWastePanel(object sender, EventArgs e) {
            if(WastePanel.Visible) {
                PopulateNewWasteFoodSelector();
                newWasteDatePicker.Text = Singleton.Istance.selectedDate;
                dateWasteLabel.Text = Singleton.Istance.selectedDate;
                Initializer.UpdateWastesListViewData(WastesListView);
            }
        }
    }
}