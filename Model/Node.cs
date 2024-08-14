using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateLimit.Model
{
    public class Node
    {

        public Node(long time=10){
            this.time=time;
        }
        public long time;
        public List<Trie>  children=new List<Trie>();

        public bool AddRequest(string token){
            var trie=children.FirstOrDefault(x=>x.nodeValue==token[0]);
            if(trie==null){
                // Console.WriteLine($"Creating new Node of Node with value {token[0]}...");
                trie=new Trie(token[0]);
                this.children.Add(trie);    
            }
            // else{
            //     Console.WriteLine("Node Found ");
            // }
            return trie.AddNode(token,trie,this.time);
        }

        

    }
}