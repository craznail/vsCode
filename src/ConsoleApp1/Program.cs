using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            #region 32bit md5
            MD5:
            Console.WriteLine(MD5Encrypt2("Hello World!"));    
            #endregion
            


            ALLDONE:
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static int BinarySearch(int[] array, int high, int low, int key)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (high < low)
                throw new ArgumentException("argument \"high\" must high than \"low\"!");

            int middle = (low + high) / 2;
            if (key > array[middle])
                return BinarySearch(array, high, middle + 1, key);
            else if (key < array[middle])
            {
                return BinarySearch(array, middle - 1, low, key);
            }
            else
                return middle;
        }

        public static string MD5Encrypt2(string encryptStr)
        {
            var md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(encryptStr));
            var sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("x2"));
            }
            //所有字符转为大写
            return sb.ToString();
        }

        public static GetWeekDateFormat(DateTime date )
        {
            string[] weeks = (new string[] { "周日", "周一", "周二", "周三", "周四", "周五", "周六" });
            string week = weeks[(int)date.DayOfWeek];
            Console.WriteLine(date.ToString("yyyy-MM-dd " + week + " HH:mm"));

            //Another way to get week format
            Console.WriteLine("周" + "日一二三四五六".Substring((int)date.DayOfWeek, 1));
        }
    }
}
