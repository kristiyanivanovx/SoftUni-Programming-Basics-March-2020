using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private ICollection<IBakedFood> bakedFoods;
        private ICollection<IDrink> drinks;
        private ICollection<ITable> tables;
        private decimal totalBills;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            if (type == nameof(Bread))
            {
                food = new Bread(name, price);
            }
            if (type == nameof(Cake))
            {
                food = new Cake(name, price);
            }

            this.bakedFoods.Add(food);
            return $"Added {name} ({type}) to the menu";
        }

        // successful?
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if (type == nameof(Tea))
            {
                drink = new Tea(name, portion, brand);
            }
            if (type == nameof(Water))
            {
                drink = new Water(name, portion, brand);
            }

            this.drinks.Add(drink);
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == nameof(OutsideTable))
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            if (type == nameof(InsideTable))
            {
                table = new InsideTable(tableNumber, capacity);
            }

            this.tables.Add(table);
            return $"Added table number {tableNumber} in the bakery";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable freeTable = tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);

            if (freeTable == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            freeTable.Reserve(numberOfPeople);
            return $"Table {freeTable.TableNumber} has been reserved for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IBakedFood food = bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IDrink drink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var bill = table.GetBill();

            totalBills += bill;

            var sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");

            table.Clear();

            return sb.ToString().Trim();
        }

        public string GetFreeTablesInfo()
        {
            var tables = this.tables.Where(x => x.IsReserved == false);
            var sb = new StringBuilder();

            foreach (var table in tables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalBills:f2}lv";
        }
    }
}
