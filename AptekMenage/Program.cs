using AptekMenage.Controllers;
using Core.Constants;
using Core.Helpers;
using System;

namespace AptekMenage
{
    public class Program
    {
        static void Main(string[] args)
        {
            OwnerController ownerController = new OwnerController();
            AdminController admincontroller = new AdminController();
            var admin = admincontroller.Authenticade();

            if (admin != null)
            {
                Helper.WriteTextWithColor(ConsoleColor.Green, $"Welcome, {admin.Username}");
                Helper.WriteTextWithColor(ConsoleColor.White, "------");

                while (true)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Blue, "Main Menu:");
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, "Owner Menu - 1");
                    


                    Console.WriteLine("--------------------------------------------------");

                    Helper.WriteTextWithColor(ConsoleColor.Magenta, "Select Options:");
                    string number = Console.ReadLine();
                    int selectedNumber;
                    bool result = int.TryParse(number, out selectedNumber);


                    if (result)
                    {
                        if (selectedNumber == 1)
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Create Owner");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Owner");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "3 - GetAll Owner");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "4 - Delete Owner");
                            Helper.WriteTextWithColor(ConsoleColor.Magenta, "Select Options:");
                            number = Console.ReadLine();


                            result = int.TryParse(number, out selectedNumber);
                            if (selectedNumber >= 0 && selectedNumber <= 6)
                            {
                                switch (selectedNumber)
                                {

                                    case (int)OwnerOptions.OwnerCreat:
                                        ownerController.Creat();
                                        break;
                                    case (int)OwnerOptions.UpdateOwner:
                                        ownerController.Update();
                                        break;
                                    case (int)OwnerOptions.GetAllOwner:
                                        ownerController.GetAll();
                                        break;
                                    case (int)OwnerOptions.DeleteOwner:
                                        ownerController.Delete();
                                        break;
                                    case (int)OwnerOptions.Exit:
                                        ownerController.Exit();
                                        break;


                                }
                            }
                            else
                            {
                                Helper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");
                            }
                        }
                        else
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Red, "Please, Select Correct Options...");
                        }
                    }
                    else
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Red, "Please, Select Correct Options...");
                    }

                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Username or Password incorrect");
                
            }
        }
    }
}
