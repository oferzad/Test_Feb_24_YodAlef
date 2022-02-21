using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureCore
{
    /* The class IntNode **/
    public class IntNode
    {
        private int value;                           // Node value
        private IntNode next;               // next Node

        /* Constructor  - returns a Node with "value" as value and without successesor Node **/
        public IntNode(int value)
        {
            this.value = value;
            this.next = null;
        }

        /* Constructor  - returns a Node with "value" as value and its successesor is "next" **/
        public IntNode(int value, IntNode next)
        {
            this.value = value;
            this.next = next;
        }

        /* Returns the Node "value" **/
        public int GetValue()
        {
            return this.value;
        }

        /* Returns the Node "next" Node **/
        public IntNode GetNext()
        {
            return this.next;
        }

        /* Return if the current Node Has successor **/
        public bool HasNext()
        {
            return (this.next != null);
        }

        /* Set the value attribute to be "value" **/
        public void SetValue(int value)
        {
            this.value = value;
        }

        /* Set the next attribute to be "next" **/
        public void SetNext(IntNode next)
        {
            this.next = next;
        }

        /* Returns a string that describes  the Node (and its' successesors **/
        public override string ToString()
        {
            if (next == null)
                return value.ToString() + " --> null";
            return value.ToString() + " --> " + next;
        }
    }
    
}
