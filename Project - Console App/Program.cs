using System;

namespace Console_App
{
    class Menu
    {
        public void Option()
        {
            CRUD crud = new CRUD();
            Console.Clear();
            Console.WriteLine("Video Rental Information System");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1. List of Movies & Shows");
            Console.WriteLine("2. Add new Film");
            Console.WriteLine("3. Edit film data");
            Console.WriteLine("4. Search film");
            //Console.WriteLine("5. Delete a film");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("5. Quit");
            //Console.WriteLine("-------------------------------");
            //Console.WriteLine("7. Clear database");
            Console.WriteLine();
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    crud.Read();
                    break;
                case "2":
                    crud.Write();
                    break;
                case "3":
                    crud.Update();
                    break;
                case "4":
                    crud.Search();
                    break;
                /*case "5":
                    crud.Delete();
                    break;*/
                case "5":
                    Environment.Exit(0);
                    break;
                /*case "7":
                    Console.Clear();
                    File.WriteAllText(Const.path, String.Empty);
                    Console.WriteLine("Database has been cleared");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Option();
                    break;*/
                default:
                    Console.WriteLine("Please choose from the available option");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Option();
                    break;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Menu menu = new Menu();
            menu.Option();
        }
    }
}
