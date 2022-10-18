using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_002___Object_Oriented_Programming
{   //Interface
    public interface IKitchenAppliance
    {

        string Type { get; set; }
        string Brand { get; set; }
        bool isBroken { get; set; }
        
        int mainMenuChoice();
        void UseItem(List<KitchenItems> KitchenItems);
        KitchenItems AddItem(List<KitchenItems> KitchenList);
        void ListItems(List<KitchenItems> KitchenList);
        List<KitchenItems> RemoveItem(List<KitchenItems> KitchenList);
    }
}
