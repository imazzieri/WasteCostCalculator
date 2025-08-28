namespace WasteCostCalculator {

    //TODO change the name of this class
    internal static class Initializer {

        public static void UpdateWastesListViewData(ListView listView) {
            var wastes = DBUtils.GetWastedByDate(Singleton.Istance.selectedDate);
            listView.Items.Clear();
            foreach(var waste in wastes)
                listView.Items.Add(waste.toListViewItem());
        }
        //There appears to be a bug if the first column is added with a width of -2
        public static void InitializeWastesListView(ListView listView) {
            listView.View = View.Details;
            listView.Columns.Add("Food Name");
            listView.Columns.Add("Quantity");
            listView.Columns.Add("Total cost");
            listView.Columns[1].TextAlign = HorizontalAlignment.Right;
            listView.Columns[2].Width += 5;
            listView.Columns[2].TextAlign = HorizontalAlignment.Right;
            listView.Columns[0].Width = listView.Width - (4 + listView.Columns[1].Width + listView.Columns[2].Width);//TODO hardcoded padding
            UpdateWastesListViewData(listView);
        }

        public static void InitializeAllFoodListView(ListView listView) {
            listView.View = View.Details;
            listView.Columns.Add("Food Name");
            listView.Columns.Add("Cost");
            listView.Columns.Add("Measurement unit");
            listView.Columns[0].Width = listView.Width - (4 + listView.Columns[1].Width + listView.Columns[2].Width);//TODO hardcoded padding
            UpdateAllFoodsListViewData(listView);
        }
        public static void UpdateAllFoodsListViewData(ListView listView) {
            listView.Items.Clear();
            var allFoods = DBUtils.getAllFoods();

            foreach ( var food in allFoods ) {
                listView.Items.Add(food.toListViewItem());
            }
        }

        public static void InitializeReportListView(ListView listView) {
            listView.View = View.Details;
            listView.Columns.Add("Date");
            listView.Columns.Add("Total");
            listView.Columns[0].Width = listView.Width - (4 + listView.Columns[1].Width);//TODO hardcoded padding
            if(listView.Name == "monthDetailsListview")//TODO hardcoded name
                UpdateMonthDetailsListview(listView);
            else
                UpdateMonthlyReportListView(listView);
        }
        public static void UpdateMonthDetailsListview(ListView listView) {
            listView.Items.Clear();
            var results = DBUtils.GetWastedByMonth(Singleton.Istance.selectedMonth);
            foreach(var result in results) {
                listView.Items.Add(result.toListViewItem());
            }
        }
        public static void UpdateMonthlyReportListView(ListView listView) {
            listView.Items.Clear();
            var results = DBUtils.GetMonthlyWaste();
            foreach(var result in results) {
                listView.Items.Add(result.toListViewItem());
            }
        }

        //Hides all the panels that are not the one selected
        public static void ShowSelectedPanel(Panel p) {
            p.Visible = true;
            for(int i = 0; i <Singleton.Istance.panels.Count; i++) {
                if(Singleton.Istance.panels[i] != p)
                    Singleton.Istance.panels[i].Visible = false;
            }
        }
    }
    /* For bigger projects it may be worth to add various pointer to the form's objects here
     * to automate various things in get/sets
     * TODO look how the DBContext class works, it may be worth putting
     * here a pointer to a context without creating a new one every time the program needs to connect to the DB
     * */
    public class Singleton {
        public string selectedDate;
        public string selectedMonth;
        public List<Panel> panels;

        private Singleton() {
            selectedDate = DateTime.Today.ToShortDateString();
            selectedMonth = selectedDate.Substring(3);
            panels = new List<Panel>();
        }

        private static Singleton? istance;

        public static Singleton Istance {
            get {
                if(istance == null)
                    istance = new Singleton();
                return istance;
            }
        }
    }
}
