using System;
//using System.Collections.Generic;
using System.Text;
using DataStructureCore;

namespace Test_Feb_24_YodAlef
{
    class Q3
    {
        //Complexity - O(n) where n is the number of nodes in t
        static bool IsMeforak(BinNode<int> t)
        {
            if (t == null)
                return false;

            if (!t.HasLeft() && !t.HasRight())
                return (t.GetValue() == 1);

            if (!t.HasLeft() || !t.HasRight())
                return false;

            if (t.GetLeft().GetValue() + t.GetRight().GetValue() != t.GetValue())
                return false;

            return IsMeforak(t.GetLeft()) && IsMeforak(t.GetRight());
        }
    }
}
