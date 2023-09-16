using System;
using System.Linq;

namespace Arch_IS_Lab1
{
    public class FoolCheck
    {
        public static string StringCheck()
        {
            string varstr = "";
            bool exit = false;
            while (!exit)
            {
                varstr = Console.ReadLine();
                try
                {
                    varstr.All(char.IsLetter);
                    exit = true;
                }
                catch
                {
                    Console.WriteLine("Данное поле должно состоять только из букв. Повторите ввод.");
                }
            }
            return varstr;
        }

        public static bool BoolCheck()
        {
            int varbool = 0;
            bool exit = false;
            while (!exit)
            {
                varbool = Convert.ToInt32(IntCheck());
                if (varbool == 1 || varbool == 2)
                {
                    exit = true;
                }
                else Console.WriteLine("Ошибка ввода: допускается ввод только двух символов - 1 и 2. Попробуйте еще раз.");
            }
            if (varbool == 1) return true;
            return false;
        }

        public static uint IntCheck()
        {
            uint varint = 0;
            bool exit = false;
            while (!exit)
            {
                try
                {
                    varint = uint.Parse(Console.ReadLine());
                    exit = true;
                }
                catch
                {
                    Console.WriteLine("Ошибка ввода: вы должны вводить целое положительное число. Попробуйте еще раз.");
                }
                finally
                {
                    // =)
                }
            }
            return varint;
        }
    }
}
