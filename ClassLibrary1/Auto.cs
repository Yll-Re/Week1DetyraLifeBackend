using ClassLibrary1.Enum;
using System.Reflection;

namespace ClassLibrary1
{
    public class Auto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public carColor Color { get; set; }
        public DateTime ProductionDate { get; set; }

        public bool DoorsAdded { get; set; } = false;
        public bool CarrosserieAdded { get; set; } = false;
        public bool WheelsAdded { get; set; } = false;
        public bool EnterierAdded { get; set; } = false;
        public bool EngineAdded { get; set; } = false;

        public Auto(string name, decimal price, int color)
        {
            Name = name;
            Price = price;
            setColor(color);
            ProductionDate = DateTime.Now; // Qikjo duhet default sipas detyer e bona qe veq me kan Now
        }

        // Qikjo spo di se ne detyr color niher o string tani ma vone thot qe me kan int? (e ne constructor e bona qe i vyn int)
        public void setColor(int color)
        {
            if(color >= 0 && color <= 2)
            {
                Color = (carColor)color;
            }
            else
            {
                throw new ArgumentException("Color does not exist");
            }
        }

        public void addDoors() => DoorsAdded = true;

        public void addCarrosserie() => CarrosserieAdded = true;

        public void addWheels() => WheelsAdded = true;

        public void addEnterier() => EnterierAdded = true;

        public void addEngine() => EngineAdded = true;

        public List<string> getMissingParts()
        {
            List<string> missingParts = new List<string>();

            PropertyInfo[] properties = GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(bool))
                {
                    bool value = (bool)property.GetValue(this);
                    if (!value)
                    {
                        string correctName = getPropertyName(property.Name);
                        missingParts.Add(correctName);
                    }
                }
            }

            return missingParts;
        }

        // overenginering se masi tu e marr property.name dilke missing "DoorsAdded"
        private string getPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "DoorsAdded":
                    return "Doors";
                case "CarrosserieAdded":
                    return "Carrosserie";
                case "WheelsAdded":
                    return "Wheels";
                case "EnterierAdded":
                    return "Enterier";
                case "EngineAdded":
                    return "Engine";
                default:
                    return propertyName;
            }
        }
    }
}
