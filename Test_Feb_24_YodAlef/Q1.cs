using System;
//using System.Collections.Generic;
using System.Text;
using DataStructureCore;

namespace Test_Feb_24_YodAlef
{
    public class Q1
    {
        #region Question1 Ezer
        public static Stack<T> CopyStack<T>(Stack<T> stack)
        {
            Stack<T> copy = new Stack<T>();
            Stack<T> temp = new Stack<T>();
            while (!stack.IsEmpty())
            {
                temp.Push(stack.Pop());
            }
            while (!temp.IsEmpty())
            {
                stack.Push(temp.Top());
                copy.Push(temp.Pop());
            }
            return copy;
        }

        public static T GetLastInStack<T>(Stack<T> st)
        {
            Stack<T> backUp = CopyStack(st);
            if (backUp == null || backUp.IsEmpty())
                return default(T);
            T last = backUp.Pop();
            while (!backUp.IsEmpty())
            {
                last = backUp.Pop();
            }
            return last;
        }
        #endregion
        #region Question 1 A
        public static bool IsLimitedStack(Stack<int> st)
        {

            Stack<int> backUp = CopyStack(st);
            if (backUp == null || backUp.IsEmpty())
                return true;
            int first = backUp.Pop();
            int last = GetLastInStack(st);
            if (first > last)
                return false;
            while (backUp.Top() != last)
            {
                if (backUp.Top() < first || backUp.Top() > last)
                    return false;
                backUp.Pop();
            }
            return true;

        }
        public static Queue<Item> Question1b(Queue<Stack<int>> q)
        {
            Queue<Item> retQ = new Queue<Item>();
            int pos = 1;
            while (!q.IsEmpty())
            {
                Stack<int> st = q.Remove();
                if (IsLimitedStack(st))
                {
                    Item item = new Item(st.Top(), GetLastInStack(st), pos);
                    retQ.Insert(item);
                }
                pos++;
            }
            return retQ;
        }
        #endregion
    }

    public class Item
    {
        private int v1;
        private int v2;
        private int pos;

        public Item(int v1, int v2, int pos)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.pos = pos;
        }
        public override string ToString()
        {
            return ($"first={v1}-last={v2}-pos={pos}");
        }
    }
}
