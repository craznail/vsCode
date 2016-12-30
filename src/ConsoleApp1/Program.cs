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

            ListItem topItem = new ListItem
            {
                Name = "111",
                Value = "1",
                ChildItems = new List<ListItem>{
                new ListItem{Name="111_111",Value="1_1",ChildItems = new List<ListItem>{
                    new ListItem{Name="all",Value="all"},
                    new ListItem{Name="111_111_111",Value="1_1_1"},
                    new ListItem{Name="111_111_222",Value="1_1_2"}
                }},
                new ListItem{Name="111_222",Value="1_2",ChildItems = new List<ListItem>{
                    new ListItem{Name="all",Value="all"},
                    new ListItem{Name="111_222_111",Value="1_2_1"},
                    new ListItem{Name="111_222_222",Value="1_2_2"}
                }},
                new ListItem{Name="111_333",Value="1_3",ChildItems = new List<ListItem>{
                    new ListItem{Name="all",Value="all"},
                    new ListItem{Name="111_333_111",Value="1_3_1"},
                    new ListItem{Name="111_333_222",Value="1_3_2"}
                }},
            }
            };

            bool isFlag = FlagSelectItem(topItem, "1_2_2");
            Console.WriteLine(isFlag);
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
