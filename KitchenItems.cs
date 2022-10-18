using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_002___Object_Oriented_Programming
{
    //Items Class with functions
    public class KitchenItems: KitchenAppliance
    {

        public KitchenItems()
        {

        }

        public KitchenItems(string type, string brand):base(type,brand)
        {
            this.Type = type;
            this.Brand = brand;
        }

        public KitchenItems(string type, string brand, bool isbroken) : base(type, brand, isbroken)
        {
            this.Type = type;
            this.Brand = brand;
            this.isBroken = isbroken;
        }

        
        //Writes out the main menu and lets the user make a choice
        public override int mainMenuChoice()
        {
            bool parseSucess = false;
            int parseValue;
            Console.WriteLine("Välkommen till köket!\n" +
                              "1. Använd köksapparat\n" +
                              "2. Lägg till köksapparat\n" +
                              "3. Lista köksapparater\n" +
                              "4. Ta bort köksapparat\n" +
                              "5. Avsluta köksprogram\n" +
                              "\nGör ett val:");


            
            parseSucess = int.TryParse(Console.ReadLine(), out parseValue);

            if (parseSucess)
            {
                if (1 <= parseValue && parseValue <= 5)
                {
                    return parseValue;
                }
                else
                {
                    //Returns 0 and reruns the main menu choice in the Main Class
                    Console.WriteLine(parseValue + " är inte ett giltigt nummer för menyn\n");
                    return 0;
                }
            }
            //Returns 0 and reruns the main menu choice in the Main Class
            Console.WriteLine("\nAnge ett giltigt nummer\n");
            return 0;
        }
        


        //Lets you choose an item in a list and uses it
        public override void UseItem(List<KitchenItems> KitchenList)
        {
            bool validNumber = false;
            bool parseSuccess = false;
            int i = 1;
            int outPutNumber;
            Random randomizer = new Random();

            foreach (var item in KitchenList)
            {
                if (item.isBroken)
                {
                    Console.WriteLine($"{i}: {item.Type} av märket {item.Brand} (trasig)");
                    i++;
                }
                else
                {
                    Console.WriteLine($"{i}: {item.Type} av märket {item.Brand} (fungerar)");
                    i++;
                }
                
            }


            do
            {
                Console.WriteLine("\nVälj vilken du vill använda");
                parseSuccess = int.TryParse(Console.ReadLine(),out outPutNumber);
                outPutNumber--;
                if (parseSuccess && 0<= outPutNumber && outPutNumber < KitchenList.Count && KitchenList[outPutNumber].isBroken == false)
                {
                    Console.WriteLine($"Använder {KitchenList[outPutNumber].Type} av märket {KitchenList[outPutNumber].Brand}");

                    int broken = randomizer.Next(1,6);
                    if (broken ==1)
                    {
                        Console.WriteLine($"Din {KitchenList[outPutNumber].Type} av märket {KitchenList[outPutNumber].Brand} gick sönder\n");
                        KitchenList[outPutNumber].isBroken = true;
                    }
                    else
                    {
                        Console.WriteLine($"Din {KitchenList[outPutNumber].Type} av märket {KitchenList[outPutNumber].Brand} fungerar fortfarande som vanligt\n");
                    }
                    validNumber = true;
                }
                else if (KitchenList[outPutNumber].isBroken == true)
                {
                    Console.WriteLine($"Din {KitchenList[outPutNumber].Type} av märket {KitchenList[outPutNumber].Brand} är tyvärr sönder\n");
                    validNumber = true;
                }
                else
                {
                    Console.WriteLine("Välj ett giltigt nummer");
                }
            } while (validNumber==false);
        }

        //Lets you add a new item to the list
        public override KitchenItems AddItem(List<KitchenItems> KitchenList)
        {
            string newType = "";
            string newBrand = "";
            string yesOrNo;
            bool isBroken = false;
            Console.WriteLine("Lägg till ny köksapparat\n" +
                              "Ange köksapparatens typ: ");
            

            do
            {
                newType = Console.ReadLine();
                if (newType == "")
                {
                    Console.WriteLine("Vänligen ange en giltig typ");
                }
            } while (newType == "");

            Console.WriteLine("\nAnge nu köksapparatens märke: ");

            
            do
            {
                newBrand = Console.ReadLine();
                if (newBrand == "")
                {
                    Console.WriteLine("Vänligen ange ett giltigt märke");
                }
            } while (newBrand == "");

            Console.WriteLine("Fungerar produkten?\n" +
                              "Ange med y eller n");
            do
            {
                yesOrNo = Console.ReadLine();

                if (yesOrNo == "y")
                {
                    break;
                }
                else if (yesOrNo == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Vänligen ange y eller n");
                }
            } while (true);

            if (yesOrNo == "y")
            {
                Console.WriteLine($"Din fungerande {newType} av märket {newBrand} är nu tillagd\n");
                isBroken = false;
            }
            else if (yesOrNo == "n")
            {
                Console.WriteLine($"Din trasiga {newType} av märket {newBrand} är nu tillagd\n");
                isBroken=true;
            }

            

            return new KitchenItems(newType,newBrand,isBroken);
        }

        //Lists all items currentyl in the list
        public override void ListItems(List<KitchenItems> KitchenList)
        {
            int i = 1;
            Console.WriteLine("Skriver ut lista över köksapparater\n");
            foreach (var item in KitchenList)
            {
                if (item.isBroken == true)
                {
                    Console.WriteLine($"{i}: {item.Type} av märket {item.Brand} (trasig)");
                    i++;
                }
                else
                {
                    Console.WriteLine($"{i}: {item.Type} av märket {item.Brand} (fungerar)");
                    i++;
                }
                
            }
            Console.WriteLine(" ");
        }

        //Removes a selected item from the list
        public override List<KitchenItems> RemoveItem(List<KitchenItems> KitchenList)
        {
            bool validNumber = false;
            bool parseSuccess = false;
            int i = 1;
            int outPutNumber;
            foreach (var item in KitchenList)
            {
                if (item.isBroken)
                {
                    Console.WriteLine($"{i}: {item.Type} av märket {item.Brand} (trasig)");
                    i++;
                }
                else
                {
                    Console.WriteLine($"{i}: {item.Type} av märket {item.Brand} (fungerar)");
                    i++;
                }

            }

            do
            {
                Console.WriteLine("\nVälj vilken du vill ta bort");
                parseSuccess = int.TryParse(Console.ReadLine(), out outPutNumber);
                outPutNumber--;
                if (parseSuccess && 0 <= outPutNumber && outPutNumber < KitchenList.Count)
                {
                    Console.WriteLine($"tar bort {KitchenList[outPutNumber].Type} av märket {KitchenList[outPutNumber].Brand}\n");
                    KitchenList.RemoveAt(outPutNumber);
                    validNumber = true;
                }
                else
                {
                    Console.WriteLine("Välj ett giltigt nummer");
                }
            } while (validNumber == false);
            return KitchenList;
        }
    }
}
