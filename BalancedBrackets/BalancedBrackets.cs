using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes {
    /* Balanced brackets
     * 
     * brackets { } [ ] ( )
     * check if given expression has balanced brackets
     * if any opening bracket has its matching closing bracket
     * 
     */
    class Bracket {
        // char that represents the class
        public char myTipe { get; set; }
        // class opening bracket, so just add to the stack
        public virtual bool Process(Stack<Bracket> stack) {
            stack.Push(this);
            return true;
        }
    }
    
    class BracketClose : Bracket {
        // opening char
        public char myOpening { get; set; }
        
        public override bool Process(Stack<Bracket> stack) {
            //can't close an empty stack (no opening)
            if (stack.Count == 0)
                return false;            
            return type(stack.Pop());
        }

        //check type of the bracket on the top of the stack
        public bool type(Bracket a) {
            if (myOpening == a.myTipe)
                return true;
            else
                return false;
        }
    }
    
    class BracketBalance {
        // stack of brackets
        private Stack<Bracket> stack = new Stack<Bracket>();
        // list of types of brackets
        private Dictionary<char, Bracket> dicionary = new Dictionary<char, Bracket>();
        
        //populate list
        public BracketBalance() {
            dicionary.Add('(', new Bracket() { myTipe = '(' });
            dicionary.Add(')', new BracketClose() { myOpening = '(' });
            dicionary.Add('[', new Bracket() { myTipe = '[' });
            dicionary.Add(']', new BracketClose() { myOpening = '[' });
            dicionary.Add('{', new Bracket() { myTipe = '{' });
            dicionary.Add('}', new BracketClose() { myOpening = '{' });
        }
        
        // string received
        public char[] Expression { get; set; }
        
        public string Verify() {
            foreach (char c in Expression) {
                // element not listed
                if (!dicionary.ContainsKey(c)) {
                    //return "NO";
                    continue;
                }
                //if any error
                if (!dicionary[c].Process(stack))
                    return "NO";
            }
            // finished iteration, but still items left
            if (stack.Count != 0)
                return "NO";
            return "YES";
        }        
    }

    class Solution {
        static void Main(String[] args) {
            int t = Convert.ToInt32(Console.ReadLine()); // how many expressions
            for (int a0 = 0; a0 < t; a0++) {
                // each expression
                BracketBalance b = new BracketBalance() { Expression = Console.ReadLine().ToArray() };
                Console.WriteLine(b.Verify());    
            }
        }
    }
}
