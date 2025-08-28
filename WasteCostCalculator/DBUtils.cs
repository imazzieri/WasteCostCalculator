using System.Data.SQLite;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace WasteCostCalculator {
     static internal class DBUtils {
        public static void CreateDBifNotExists() {
            if(!File.Exists(WCCContext.DbName)) {
                SQLiteConnection.CreateFile(WCCContext.DbName);
                try {
                    string connectionPath = String.Format("Data Source={0}", WCCContext.DbName);
                    using var connection = new SqliteConnection(connectionPath);
                    connection.Open();//for my understanding, this is needed to actually create the db
                    connection.Close();
                    WCCContext context = new WCCContext();
                    RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>();
                    databaseCreator.CreateTables();

                } catch(SqliteException) {
                }
            }
        }
        #region Food related utilities
        /// <summary>
        /// checks if the nullable proprieies not null
        /// there is also a special case for foods that are already on the DB
        /// </summary>
        /// <param name="foodToCheck"></param>
        /// <returns></returns>
        private static newFoodErrors IsFoodDBFriendly(Food foodToCheck) {
            if(foodToCheck == null)
                return newFoodErrors.NullFood;
            if(foodToCheck.Name.Trim() == "" || foodToCheck.Name == null)
                return newFoodErrors.EmptyName;
            if(foodToCheck.MeasurementUnit == null || foodToCheck.MeasurementUnit.Trim() == "")
                return newFoodErrors.EmptyMeasurementUnit;
            if(DoesTheFoodAlreadyExsists(foodToCheck.Name))
                return newFoodErrors.ExistingName;
            return newFoodErrors.NoError;
        }
        public static newFoodErrors AddFoodToDB(Food foodToAdd) {
            var isFoodDBFriendly = IsFoodDBFriendly(foodToAdd);
            if(isFoodDBFriendly == newFoodErrors.NoError) {
                try {
                    var context = new WCCContext();
                    context.Foods.Add(foodToAdd);
                    context.SaveChanges();
                } catch {
                    MessageBox.Show("It was not possible to save changes", "Something went wrong");
                }
            }
            return isFoodDBFriendly;
        }
        /// <summary>
        /// edit an EXISTING food
        /// </summary>
        /// <param name="editedFood"></param>
        /// <returns></returns>
        public static newFoodErrors SaveEditedFoodToDB(Food editedFood) {
            var isFoodDBFriendly = IsFoodDBFriendly(editedFood);
            if(isFoodDBFriendly == newFoodErrors.ExistingName) {
                try {
                    var context = new WCCContext();
                    var results = context.Foods.Where(f => f.Name == editedFood.Name);
                    if(results.Any()) {
                        var foodToEdit = results.First();
                        foodToEdit.Name = editedFood.Name;
                        foodToEdit.Cost = editedFood.Cost;
                        foodToEdit.MeasurementUnit = editedFood.MeasurementUnit;
                        context.Foods.Attach(foodToEdit);
                        context.Foods.Update(foodToEdit);
                        context.SaveChanges();
                    }
                } catch {
                    MessageBox.Show("It was not possible to save changes", "Something went wrong");
                }

            }
            return isFoodDBFriendly;
        }
        public static DbSet<Food> getAllFoods() {
            var context = new WCCContext();
            return context.Foods;
        }
        /// <summary>
        /// returns -1 if the food was not found
        /// </summary>
        /// <param name="foodName"></param>
        /// <returns></returns>
        public static int GetFoodIdByName(string foodName) {
            var context = new WCCContext();
            Food[] results = context.Foods.Where(f => f.Name == foodName).ToArray();
            if(results.Length > 0)
                return results[0].FoodId;//Food name is unique, so if the food is present there is only 1 entry on the array
            return -1;
        }
        /// <summary>
        /// returns a food with empty name and a cost of -1
        /// if it doesn't found the food
        /// </summary>
        /// <param name="foodName"></param>
        /// <returns></returns>
        public static Food GetFoodByName(string foodName) {
            var context = new WCCContext();
            var results = context.Foods.Where(f => f.Name == foodName);
            if(results.ToArray().Length > 0)
                return results.ToArray()[0];
            return new Food() { Name = "", MeasurementUnit = "", Cost = -1 };
        }
        public static bool DoesTheFoodAlreadyExsists(string foodName) {
            var foods = getAllFoods();
            foreach(var food in foods) {
                if(food.Name == foodName)
                    return true;
            }
            return false;
        }
        public static void DeleteFoodFromDB(Food foodToDelete) {
            try {
                var context = new WCCContext();
                context.Foods.Where(food => food.Name == foodToDelete.Name).ExecuteDelete();
            } catch {
                MessageBox.Show("It was not possible to delete the entry", "Something went wrong");
            }
        }
        #endregion
        #region waste related utilities
        public static DbSet<Waste> GetAllWastes() {
            var context = new WCCContext();
            return context.Waste;
        }
        public static List<WasteHelper> GetWastedByDate(string date) {
            var context = new WCCContext();
            var results = from food in context.Foods
                          join waste in context.Waste on food.FoodId equals waste.FoodId
                          where waste.Date == date
                          select new WasteHelper {
                              WasteID = waste.WasteId,
                              FoodName = food.Name,
                              QuantityWasted = waste.QuantityWasted,
                              TotalCost = waste.QuantityWasted * waste.FoodCostAtWasteDate
                          };
            return results.ToList();
        }
        /// <summary>
        /// checks if the nullable proprieties are not null
        /// </summary>
        /// <param name="wasteToCheck"></param>
        /// <param name="foodName"></param>
        /// <returns></returns>
        private static newWasteErrors IsWasteDBFriendly(Waste wasteToCheck, string foodName) {
            if((wasteToCheck.Date.Trim() == "" || wasteToCheck.Date == null))
                return newWasteErrors.EmptyDate;
            if(-1 == GetFoodIdByName(foodName))
                return newWasteErrors.NoFooodFound;
            return newWasteErrors.NoError;
        }
        public static newWasteErrors AddWasteToDB(Waste wasteToAdd, string foodName) {
            var results = IsWasteDBFriendly(wasteToAdd,foodName);
            wasteToAdd.FoodId = GetFoodIdByName(foodName);
            if(wasteToAdd.FoodId != -1 && wasteToAdd.FoodCostAtWasteDate != -1) {//if it founds the foodID then he founds the food cost, it's a bit rendoundant to check both
                try {
                    var context = new WCCContext();
                    context.Waste.Add(wasteToAdd);
                    context.SaveChanges();
                } catch {
                    MessageBox.Show("It was not possible to save changes", "Something went wrong");
                }
            }
            return results;
        }
        public static void DeleteWasteFromDB(int wasteId) {
            try {
                var context = new WCCContext();
                context.Waste.Where(w => w.WasteId == wasteId).ExecuteDelete();
            } catch {
                MessageBox.Show("It was not possible to delete the entry", "Something went wrong");

            }
        }
        /// <summary>
        /// if the waste isn't foud it returns a waste with an empty date
        /// and -1 in all numeric fields
        /// </summary>
        /// <param name="WasteId"></param>
        /// <returns></returns>
        public static Waste GetWasteByID(int WasteId) {
            var context = new WCCContext();
            var results = context.Waste.Where(w => w.WasteId == WasteId);
            if(results.ToArray().Count() > 0)//i'm not sure if toArray() is useless here, i guess so
                return results.ToArray()[0];
            return new Waste() {Date = "", FoodCostAtWasteDate = -1, FoodId = -1, QuantityWasted = -1};
        }
        /// <summary>
        /// edit an EXISTING waste
        /// </summary>
        /// <param name="editedWaste"></param>
        public static void SaveEditedWasteToDB(Waste editedWaste) {
            try {
                var context = new WCCContext();
                var results = context.Waste.Where(w => w.WasteId == editedWaste.WasteId);
                if(results.Any()) {
                    var wasteToEdit = results.First();
                    wasteToEdit.Date = editedWaste.Date;
                    wasteToEdit.FoodCostAtWasteDate = editedWaste.FoodCostAtWasteDate;
                    wasteToEdit.QuantityWasted = editedWaste.QuantityWasted;
                    wasteToEdit.Reason = editedWaste.Reason;
                    wasteToEdit.FoodId = editedWaste.FoodId;
                    context.Waste.Attach(wasteToEdit);
                    context.Waste.Update(wasteToEdit);
                    context.SaveChanges();
                }
            } catch {
                MessageBox.Show("It was not possible to save changes", "Something went wrong");
            }
        }
        /// <summary>
        /// return all wastes in a specific month with the total wastes cost for said month
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static List<ArrangedWastes> GetWastedByMonth(string month) {
            var context = new WCCContext();
            var results = context.Waste.Where(w => w.Date.Substring(3) == month).GroupBy(w => w.Date)
                .Select(group => new ArrangedWastes { Date = group.Key, TotalCost = group.Sum(w => w.FoodCostAtWasteDate * w.QuantityWasted) });
            return results.ToList();
        }
        //this can probably merged with getWastedByMonth
        /// <summary>
        /// return all wastes grouped by month with the total cost of wastes for each month
        /// </summary>
        /// <returns></returns>
        public static List<ArrangedWastes> GetMonthlyWaste() {
            var context = new WCCContext();
            var results = context.Waste.GroupBy(w => w.Date.Substring(3))
                .Select(group => new ArrangedWastes { Date = group.Key, TotalCost = group.Sum(w => w.FoodCostAtWasteDate * w.QuantityWasted) });
            return results.ToList();
        }
        #endregion
    }

    //TODO Extend this to make "IsFoodDBFriendly(Food foodToCheck)"
    //able to handle empty input strings for float and int values
    public enum newFoodErrors {
        NoError,
        EmptyName,
        ExistingName,
        EmptyMeasurementUnit,
        NullFood
    }

    //TODO Extend this to make "IsWasteDBFriendly(Waste wasteToCheck)"
    //able to handle empty input strings for float and int values
    public enum newWasteErrors {
        NoError,
        EmptyDate,
        NoFooodFound
    }
}