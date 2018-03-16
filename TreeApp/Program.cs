using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeApp
{
    public class NavigationItem
    {
        public string ItemName { get; set; }
        public List<NavigationItem> SubItems { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Generate Test Object
            var testSubList = new List<NavigationItem>
            {
                new NavigationItem
                {
                    ItemName = "sub1"
                }
            };
            var testSubSubList = new List<NavigationItem>
            {
                new NavigationItem
                {
                    ItemName = "sub2sub1"
                }
            };
            testSubList.Add(new NavigationItem
            {
                ItemName = "sub2",
                SubItems = testSubSubList
            });
            var newItem = new NavigationItem
            {
                ItemName = "top",
                SubItems = testSubList
            };
            newItem.SubItems.Add(new NavigationItem
            {
                ItemName = "sub3"
            });

            //run the function with the test object
            var treeList = new StringBuilder();

            var level = 0;
            PrintItemsList(ref level, newItem, treeList);

            Console.WriteLine(treeList.ToString());

            Console.ReadKey();
        }

        private static void PrintItemsList(ref int levelCount, NavigationItem nItem, StringBuilder tList)
        {
            var currentItem = new StringBuilder();

            for (var x = 0; x < levelCount; x++)
            {
                currentItem.Append("\t");
            }

            currentItem.Append(nItem.ItemName);

            tList.Append(currentItem.ToString());
            tList.AppendLine("");
            if (nItem.SubItems == null || !nItem.SubItems.Any()) return;
            levelCount++;
            foreach (var sItem in nItem.SubItems)
            {
                PrintItemsList(ref levelCount, sItem, tList);
            }

            levelCount = 0;
        }
    }
}