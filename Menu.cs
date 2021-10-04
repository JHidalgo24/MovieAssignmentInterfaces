using System;

namespace AbstractMovieAssignment
{
    public class Menu
    {
        public int ValueGetter()
        {
            string option = Console.ReadLine();
            int number;
            bool success = Int32.TryParse(option, out number);

            while (!success)
            {
                Console.WriteLine("That isn't a number sorry!");
                option = Console.ReadLine();
                success = Int32.TryParse(option, out number);
            }

            return number;
        }
        public void Display()
        {
            Console.WriteLine("What Type of media do you want to display?\n1.)Movies\n2.)Shows\n3.)Videos\n4.)Exit");
        }
    }
}