using System;
using System.Collections.Generic;
using System.Text;
using DataStructureCore;

namespace Test_Feb_24_YodAlef
{
    class QPrep
    {

        static Node<int> GetLast(Node<int> l)
        {
            if (l == null || !l.HasNext())
                return null;

            
            int counter = 1;
            Node<int> temp = l;
            while (temp.HasNext())
            {
                Node<int> next = temp.GetNext();
                int val = temp.GetValue(), nextVal = next.GetValue();

                if (val != nextVal)
                    return null;

                //נבדוק האם אני בסוף רצף
                //מצב ראשון - אם השרשרת מסתיימת והרצף גדול מ 3
                if (!next.HasNext() && counter >= 3)
                {
                    return temp;
                }
                else //מצב שני - אם השרשרת לא הסתיימה אבל הרצף הסתיים באורך מספק
                {
                    Node<int> nextnext = next.GetNext();
                    int nextnextVal = nextnext.GetValue();
                    if (nextVal != nextnextVal && counter >= 2)
                        return temp;
                    else
                    {
                        if (nextVal != nextnextVal)
                            return null;
                        else
                            counter++;
                    }
                }

                temp = temp.GetNext();
            }
            return null;
        }

        static void DeleteSequences(Node<int> l)
        {
            Node<int> temp = l;
            while (temp != null)
            {
                Node<int> preLast = GetLast(temp);
                if (preLast != null)
                {
                    temp.SetNext(preLast.GetNext());
                    preLast.SetNext(null);
                }
                temp = temp.GetNext();
            }
        }
    }
}
