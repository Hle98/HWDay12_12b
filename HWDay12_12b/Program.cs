using System;
using System.Collections.Generic;

namespace HWDay12_12b
{
    class Program
    {
        static void Main(string[] args)
        {
            var ls = new List<string> { "A", "B", "C", "D" };
            GroupAssignments(ls,5);
        }
        static void GroupAssignments(List<string> ls,int k)
        {
            var groups = new List<List<string>>();
            GroupAssignments(ls, 0, groups,k);
        }
        static void GroupAssignments(List<string> ls, int idx, List<List<string>> groups,int k)
        {
            if (ls.Count == idx && groups.Count == k)
            {
                PrintGroups(groups);
                return;
            }
            if (ls.Count == idx && groups.Count < k && groups.Count>0)
            {
                int x = groups.Count;
                for (int j = 1; j <= k -x; j++)
                { 
                    groups.Add(new List<string>());
                }
                PrintGroups(groups);
                return;
            }
            if (ls.Count == idx)
            {
                return;
            }
            for (int i = 0; i < groups.Count; i++)
            {
                groups[i].Add(ls[idx]);
                GroupAssignments(ls, idx + 1, groups,k);
                groups[i].Remove(ls[idx]);
                int count = 0;
                foreach (List<string> gr in groups)
                {
                    if (gr.Count == 0)
                    {
                        count++;
                    }
                }
                groups.RemoveRange(groups.Count - count, count);
            }
            groups.Add(new List<string>());
            groups[groups.Count - 1].Add(ls[idx]);
            GroupAssignments(ls, idx + 1, groups,k);
            int count1 = 0;
            foreach (List<string> gr in groups)
            {
                if (gr.Count == 0)
                {
                    count1++;
                }
            }
            groups.RemoveRange(groups.Count - count1, count1);
            groups.RemoveAt(groups.Count - 1);
        }
        static void PrintGroups(List<List<string>> groups)
        {
            foreach (List<string> group in groups)
            {
                Console.Write("| ");
                foreach (string s in group)
                {
                    Console.Write(s + " ");
                }
            }
            Console.WriteLine("|");
        }
    }
}

            
           
