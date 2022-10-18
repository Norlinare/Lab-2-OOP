using Lab_002___Object_Oriented_Programming;

//Declaring an object of the class for function usage
var useKitchen = new KitchenItems();

//Declaring a list of objects of the class for use in the program
var kitchenList = new List<KitchenItems>
{
            new KitchenItems("Elvisp", "Bosch"),
            new KitchenItems("Brödrost", "Philips"),
            new KitchenItems("Fritös", "Electrolux"),
            new KitchenItems("Hushållsmixer", "Wilfa"),
            new KitchenItems("Riskokare", "Menuett"),
            new KitchenItems("Vattenkokare", "SMEG"),
            new KitchenItems("Äggkokare", "Champion")
};


//Unending loop for continous usage
while (true)
{
    //Prints the main menu and saves the users choice (returns 0 as invalid or 1-5 if valid input)
    int mainMenuInt = useKitchen.mainMenuChoice();
    //---02
    //Checks if the returned value is valid
    if (mainMenuInt != 0)
    {
        //Runs different functions based on the user choice
        switch (mainMenuInt)
        {
            case 1:
                if (kitchenList.Count >0)
                {
                    useKitchen.UseItem(kitchenList);
                }
                else
                {
                    Console.WriteLine("Listan innehåller inga köksapparater\n" +
                                      "Lägg till köksapparater först\n");
                }
                break;
            case 2:
                var newItem = useKitchen.AddItem(kitchenList);
                kitchenList.Add(newItem);
                break;
            case 3:
                if (kitchenList.Count > 0)
                {
                useKitchen.ListItems(kitchenList);
                }
                else
                {
                    Console.WriteLine("Listan innehåller inga köksapparater\n" +
                                      "Lägg till köksapparater först\n");
                }
                break;
            case 4:
                if (kitchenList.Count > 0)
                {
                kitchenList = useKitchen.RemoveItem(kitchenList);
                }
                else
                {
                    Console.WriteLine("Listan innehåller inga köksapparater\n" +
                                      "Lägg till köksapparater först\n");
                }
                break;
            case 5:
                Console.WriteLine("\nAvslutar köket!");
                Environment.Exit(0);
                break;
            default:
                break;
        }
    }
}


