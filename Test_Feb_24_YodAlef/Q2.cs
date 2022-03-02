using System;
//using System.Collections.Generic;
using System.Text;
using DataStructureCore;

namespace Test_Feb_24_YodAlef
{
    class IsraeliPerson
    {
        public bool IsFriendOf(IsraeliPerson p)
        {
            return false;
        }
    }

    class Q2
    {

        //Insert into an israeli queue
        //Complexity - Given that k is the number of people in the queue and 
        // m is the total number of friends per person in queue, and n = max(k,m)
        // the complexity is O(n^2)

        static void InsertIsraeliPerson(Queue<IsraeliPerson> q, IsraeliPerson p)
        {
            //Define a temporary queue for scanning
            Queue<IsraeliPerson> temp = new Queue<IsraeliPerson>();
            //a bollean to indicate if the peerson was inserted!
            bool inserted = false;
            while (!q.IsEmpty())
            {
                //Extract the person first in queue
                IsraeliPerson current = q.Remove();
                //check if current is a friend of p
                //if so, insert it to temp and then continue scanning 
                //curent's friends before inserting p!
                if (current.IsFriendOf(p))
                {
                    temp.Insert(current);
                    while (!q.IsEmpty() && current.IsFriendOf(q.Head()))
                        temp.Insert(q.Remove());
                    temp.Insert(p);
                    inserted = true;
                }
                else
                {
                    temp.Insert(current);
                }
            }
            //if p was not inserted, insert it
            if (!inserted)
                temp.Insert(p);
            //move back all Israeli persons back to q
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
        }


        //This helper method calculate the number of friends of person in the begining of q!
        //Complexity O(n), where n is the size of the q.
        static int HamulaSize(Queue<IsraeliPerson> q, IsraeliPerson person)
        {
            int counter = 0;
            Queue<IsraeliPerson> temp = new Queue<IsraeliPerson>();
            //count all friends of person
            while (!q.IsEmpty() && person.IsFriendOf(q.Head()))
            {
                counter++;
                temp.Insert(q.Remove());
            }
            //continue rolling the queue to the end
            while (!q.IsEmpty())
                temp.Insert(q.Remove());
            //move back all Israeli persons back to q
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());

            return counter;
        }

        //Scan the queue and find the largest Hamula
        //Complexity - Given that k is the number of people in the queue and 
        // m is the total number of friends per person in queue, and p is the number
        // of firends of a person and n = max(k, m, p)
        // the complexity is O(n^3)
        static int LargestHamula(Queue<IsraeliPerson> q)
        {
            int max = 0, counter = 0;
            Queue<IsraeliPerson> temp = new Queue<IsraeliPerson>();
            while (!q.IsEmpty())
            {
                IsraeliPerson current = q.Remove();
                counter = HamulaSize(q, current) + 1;
                if (counter > max)
                    max = counter;
                temp.Insert(current);
            }
            //move back all Israeli persons back to q
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
            return max;
        }
    }


}
