using System;
//using System.Collections.Generic;
using System.Text;
using DataStructureCore;

namespace Test_Feb_24_YodAlef
{
    class Bonus
    {
        //מחבר שתי חוליות מימין ומשמאל
        public static void Join<T>(BinNode<T> a, BinNode<T> b)
        {
            a.SetRight(b);
            b.SetLeft(a);
        }

        //מחבר שתי שרשראות דו כווניות מעגליות
        public static BinNode<T> Append<T>(BinNode<T> a, BinNode<T> b)
        {
            // אם אחת ריקה מחזירים את השנייה
            if (a == null) return (b);
            if (b == null) return (a);

            // מוצאים את החוליה האחרונה בשרשרת - זו שמשמאל פשוט
            BinNode<T> aLast = a.GetLeft();
            BinNode<T> bLast = b.GetLeft();

            // נחבר את החוליה האחרונהבשרשרת הראשונה עם הראשןנה בשנייה
            Join(aLast, b);
            // נחבר את האחרונה בשרשרת השנייה עם הראשונה בשרשת הראשונה
            Join(bLast, a);

            return (a);
        }


        // ניצור ברקורסיה שלוש שרשראות מעגליות
        // אחת מעץ שמאל, אחת מהשורש ואחת מעץ ימין
        // ואז נחבר אותם וסיימנו
        public static BinNode<T> TreeToList<T>(BinNode<T> root)
        {
            // עץ ריק הופך לשרשרת ריקה
            if (root == null) return (null);

            // יוצרים את השרשראות מהתתי עצים מימין ומשמאל
            BinNode<T> aList = TreeToList(root.GetLeft());
            BinNode<T> bList = TreeToList(root.GetRight());

            // יוצרים שרשרת מהשורש
            root.SetLeft(root);
            root.SetRight(root);

            //נחבר את שלושת השרשראות ונחזיר הפניה לתחילת השרשרת הראשונה כנדרש
            aList = Append(aList, root);
            aList = Append(aList, bList);

            return (aList);
        }

        public static void Test()
        {
            BinNode<int> t = new BinNode<int>(2);
            t.SetLeft(new BinNode<int>(1));
            t.SetRight(new BinNode<int>(3));

            Console.WriteLine("Before changing:");
            Console.WriteLine(t);
            Console.WriteLine("After changing:");
            BinNode<int> start = TreeToList<int>(t), temp = start;
            while (temp.GetRight() != start)
            {
                Console.Write($"{temp.GetValue()} -> ");
                temp = temp.GetRight();
            }
            Console.Write(temp.GetValue());

        }
    }
}
