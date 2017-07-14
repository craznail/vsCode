using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task<int> t = GetTotalLengthWrapper();
            Console.WriteLine("Before return result!");
            Console.WriteLine(t.Result);
        ALLDONE:
            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }

        public static async Task<int> GetTotalLengthWrapper()
        {
            Console.WriteLine("hello from GetTotalLengthWrapper");
            int length = await GetTotalLength();
            Console.WriteLine("hello end from GetTotalLengthWrapper");
            return length;
        }

        public static async Task<int> GetTotalLength()
        {
            Console.WriteLine("hello before from GetTotallength");
            int total = await GetGoogleIndexLength() + await GetWebSiteIndexLength();
            Console.WriteLine("hello end from GetTotallength");
            return total;
        }

        public static async Task<int> GetWebSiteIndexLength()
        {
            Console.WriteLine("hello from GetWebSiteIndexLength");
            HttpClient client = new HttpClient();
            string responseStr = await client.GetStringAsync("http://www.xiaomishu.com");
            Console.WriteLine("hello end GetWebSiteIndexLength");
            return responseStr.Length;
        }

        public static async Task<int> GetGoogleIndexLength()
        {
            Console.WriteLine("hello from GetGoogleIndexLength");
            HttpClient client = new HttpClient();
            string responseStr = await client.GetStringAsync("http://m.xiaomishu.com");
            Console.WriteLine("hello end GetGoogleIndexLength");
            return responseStr.Length;
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

        public static void GetWeekDateFormat(DateTime date)
        {
            string[] weeks = (new string[] { "周日", "周一", "周二", "周三", "周四", "周五", "周六" });
            string week = weeks[(int)date.DayOfWeek];
            Console.WriteLine(date.ToString("yyyy-MM-dd " + week + " HH:mm"));

            //Another way to get week format
            Console.WriteLine("周" + "日一二三四五六".Substring((int)date.DayOfWeek, 1));
        }
    }
}
