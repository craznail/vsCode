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

        string titleTemplate = "{0}{1}{2}餐厅推荐_吃货最喜欢{1}{2}餐厅推荐点评_订餐小秘书吃货荐店";
        string keywordsTemplage = "{0}{1}{2}餐厅推荐,{1}{2}餐厅点评,吃货荐店";
        string descriTemplate = "吃货在订餐小秘书不仅可以在线预订{0}{1}{2}餐厅，还可以参与{1}{2}餐厅点评，自主推荐最喜欢的{1}{2}餐厅，用图片、美文推荐餐厅相关信息，让更多吃货一起参与吃货荐店吧。";

        Console.WriteLine(string.Format(titleTemplate, "a", "a", "a")) ;
        Console.WriteLine(string.Format(keywordsTemplage, "a", "a", "a"));
        Console.WriteLine(string.Format(descriTemplate, "a", "a", "a"));
            goto ALLDONE;

        #region 32bit md5
        MD5:
            Console.WriteLine(MD5Encrypt2("Hello World!"));
        #endregion



        ALLDONE:
            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }

        private static bool FlagSelectItem(ListItem item, string selectStr)
        {
            Console.WriteLine(item.Name);
            if (item != null && item.Value == selectStr)
            {
                item.Selected = true;
                return true;
            }

            if (item.ChildItems != null && item.ChildItems.Count > 0)
            {
                foreach (var itm in item.ChildItems)
                {
                    bool isChildFind = FlagSelectItem(itm, selectStr);
                    if (isChildFind)
                    {
                        itm.Selected = true;
                        item.Selected = true;//父元素标记为true
                        return true;
                    }
                }
            }
            return false;
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
    public class ListItem
    {
        public bool Selected { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Url { get; set; }
        public List<ListItem> ChildItems { get; set; }
        public bool IsHignlight { get; set; }
    }
}
