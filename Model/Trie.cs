
using System;
using System.Collections.Generic;
using System.Linq;

namespace RateLimit.Model
{
    public class Trie
    {
        public char nodeValue;
        public List<Trie> children = new List<Trie>();
        public DateTime? max;

        public DateTime? value;

        public Trie(char nodeValue)
        {
            this.nodeValue = nodeValue;
        }

        internal bool AddNode(string token, Trie node, long seconds )
        {
            int len = token.Length;
            int position = 1;
            Trie previous = null;
            Trie current = node;
            // derive structure of tree
            while (position < len)
            {
                
                //check if any children already exit
                Trie nextNode = current.children.FirstOrDefault(n => n.nodeValue == token[position]);

                // No Node  exist
                if (nextNode == null)
                {
                    // Console.WriteLine($"No Node found.Creating Node:{token[position]}");
                    nextNode = new Trie(token[position]);
                    current.children.Add(nextNode);

                }
                // else{
                //     Console.WriteLine($"Node found({token[position]})");
                // }

                previous = current;
                current = nextNode;
                position++;
            }
            // set value of last node of tree
            if (current.nodeValue == token[position - 1])
            {
                if (current.value == null ||current.value?.CompareTo(DateTime.Now) < 0)
                {
                    current.value = DateTime.Now.AddSeconds(seconds);
                    return true;
                }
              
            }
            return false;
        }
        // internal void PrintTrie(Trie root)
        // {
        //     Console.WriteLine("Value:" + root.nodeValue);
        //     if (root.children.Count() == 0)
        //     {
        //         return;
        //     }
        //     Console.Write("Childrens:");

        //     for (int i = 0; i < root.children.Count(); i++)
        //     {
        //         Console.Write(root.children[i].nodeValue + ",");
        //     }
        //     Console.WriteLine("");
        //      for (int i = 0; i < root.children.Count(); i++)
        //     {
        //     PrintTrie(root.children[i]);
        //     }
        // }

    }


   
}