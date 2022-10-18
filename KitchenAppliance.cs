using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_002___Object_Oriented_Programming
{
    //Abstract Class
    public abstract class KitchenAppliance : IKitchenAppliance
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public bool isBroken { get; set; }
        

        public KitchenAppliance()
        {
            
        }

        public KitchenAppliance(string type, string brand)
        {
            Type = type;
            Brand = brand;
            isBroken = false;
        }
        public KitchenAppliance(string type, string brand, bool isbroken)
        {
            Type = type;
            Brand = brand;
            isBroken = isbroken;
        }

        public abstract int mainMenuChoice();

        public abstract void UseItem(List<KitchenItems> KitchenItems);

        public abstract KitchenItems AddItem(List<KitchenItems> KitchenList);

        public abstract void ListItems(List<KitchenItems> KitchenList);
        
        public abstract List<KitchenItems> RemoveItem(List<KitchenItems> KitchenList);
        

    }
}
