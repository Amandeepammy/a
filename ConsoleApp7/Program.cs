 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program

    {
        public static int Menu_Selection_Validation()
        {
            string user_input = string.Empty;
            bool loop_flag = false;

            while (loop_flag == false)
            {
                Console.WriteLine("1 = Get Rectangle Length");
                Console.WriteLine("2 = Change Rectangle Length");
                Console.WriteLine("3 = Get Rectangle Width");
                Console.WriteLine("4 = Change Rectangle Width");
                Console.WriteLine("5 = Get Rectangle Perimeter");
                Console.WriteLine("6 = Get Rectangle Area");
                Console.WriteLine("7 = Exit\n");

                Console.WriteLine("Please select an option from 1 to 7, by entering a number:\n");
                user_input = Console.ReadLine();

                if (user_input != "1" &&
                    user_input != "2" &&
                    user_input != "3" &&
                    user_input != "4" &&
                    user_input != "5" &&
                    user_input != "6" &&
                    user_input != "7")
                {
                    Console.WriteLine("That's not a valid menu option, please try again:\n");
                }
                else
                {
                    loop_flag = true;
                }
            }

            Console.WriteLine();
            return int.Parse(user_input);
        }

        public static int User_Input_Validation(string selected_option)
        {
            int aNumber = 1;
            bool isValid = false;

            while (isValid == false)
            {
                Console.WriteLine($"Please enter the {selected_option}:");
                string user_input = Console.ReadLine();
                Console.WriteLine();

                bool result = int.TryParse(user_input, out aNumber);

                if (result == false)
                {
                    Console.WriteLine("That's not a valid input please, please try again.\n");
                }

                else
                {
                    isValid = true;
                    Console.WriteLine($"Your {selected_option} has been changed to: {aNumber}.\n");
                }
            }

            return aNumber;
        }


        static void Main(string[] args)
        {
            Rectangle r = new Rectangle();
            bool valid_initial_Selection = false;
            string initial_Selection;
            int selection;

            while (valid_initial_Selection == false)
            {
                Console.WriteLine("1 = Start with Default values of Length = 1 and Width = 1\n");
                Console.WriteLine("2 = Provide your own numbers\n");
                Console.WriteLine("Choose a menu item to begin:");
                initial_Selection = Console.ReadLine();
                Console.WriteLine();

                if (initial_Selection != "1" && initial_Selection != "2")
                {
                    Console.WriteLine("That's not a valid selection, please try again.\n");
                }
                else if (int.Parse(initial_Selection) == 1)
                {
                    valid_initial_Selection = true;
                    int length = 1;
                    int width = 1;

                    Console.WriteLine($"You are selected length = {length} and width = {width}.\n");
                    Rectangle default_inputs = new Rectangle(length, width);
                    r = default_inputs;

                }
                else if (int.Parse(initial_Selection) == 2)
                {
                    valid_initial_Selection = true;

                    int length;
                    int width;

                    length = User_Input_Validation("length");
                    width = User_Input_Validation("width");

                    Console.WriteLine("You provided Length = {length} and Width = {width}.\n");
                    Rectangle default_inputs = new Rectangle(length, width);
                    r = default_inputs;
                }
            }


            selection = Menu_Selection_Validation();

            while (selection != 7)
            {
                int result;

                switch (selection)
                {
                    case 1:
                        Console.WriteLine($"Length of Rectangle is: {r.GetLength()}\n");
                        break;
                    case 2:
                        result = User_Input_Validation("length");
                        r.SetLength(result);
                        break;
                    case 3:
                        Console.WriteLine($"width of Rectangle is: {r.GetWidth()}\n");
                        break;
                    case 4:
                        result = User_Input_Validation("width");
                        r.SetWidth(result);
                        break;
                    case 5:
                        Console.WriteLine($"Perimeter of Rectangle of Lenght: {r.GetLength()} and width: {r.GetWidth()} is: {r.GetPerimeter()}\n");
                        break;
                    case 6:
                        Console.WriteLine($"Area of Rectangle of Lenght: {r.GetLength()} and width: {r.GetWidth()} is: {r.GetArea()}\n");
                        break;
                    default:
                        break;
                }

                selection = Menu_Selection_Validation();

            }

        }
    }
}
