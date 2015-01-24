using System;
using System.Collections.Generic;


class BitBall
{
    static void Main()
    {
        int[] rowsPlayerT = new int[8];
        int[] rowsPlayerB = new int[8];
        int goalsPlayerT = 0;
        int goalsPlayerB = 0;

        for (int i = 0; i < 8; i++)
        {
            rowsPlayerT[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < 8; i++)
        {
            rowsPlayerB[i] = int.Parse(Console.ReadLine());           
        }

        for (int row = 0; row < 8; row++)
        {
            for (int coll = 0; coll < 8; coll++)
            {
                if (((rowsPlayerT[row] & (1 << coll)) > 0) && ((rowsPlayerB[row] & (1 << coll)) >0 ))
                {
                    rowsPlayerB[row] = rowsPlayerB[row] & ~(1 << coll);
                    rowsPlayerT[row] = rowsPlayerT[row] & ~(1 << coll);
                }
            }
        }

        for (int row = 0; row < 8; row++)
        {
            for (int coll = 0; coll < 8; coll++)
            {
                if ((rowsPlayerT[row] & ( 1 << coll)) > 0)
                {
                    bool goal = CheckForGoal(rowsPlayerT,rowsPlayerB,row,coll,'T');
                    if (goal)
                    {
                        goalsPlayerT++;
                    }
                }

                if ((rowsPlayerB[row] & (1 << coll)) > 0)
                {
                    bool goal = CheckForGoal(rowsPlayerT, rowsPlayerB, row, coll,'B');
                    if (goal)
                    {
                        goalsPlayerB++;
                    }
                }               
            }
        }

        Console.WriteLine("{0}:{1}",goalsPlayerT,goalsPlayerB);


    }

    private static bool CheckForGoal(int[] rowsPlayerT, int[] rowsPlayerB, int row, int coll, char player)
    {
        bool goal = true;

        if (player == 'T')
        {
            while (true)
            {
                if (row == 7)
                {
                    break;
                }
                else
                {
                    if (((rowsPlayerB[row + 1] & (1 << coll)) > 0) || ((rowsPlayerT[row + 1] & (1 << coll)) > 0))
                    {
                        goal = false;
                        break;
                    }
                    else
                    {
                        row++;
                        continue;
                    }
                }
            }
        }
        else
        {
            while (true)
            {
                if (row == 0)
                {
                    break;
                }
                else
                {
                    if (((rowsPlayerB[row - 1] & (1 << coll)) > 0) || ((rowsPlayerT[row - 1] & (1 << coll)) > 0))
                    {
                        goal = false;
                        break;
                    }
                    else
                    {
                        row--;
                        continue;
                    }
                }
            }
        }

        

       return goal;
    }
}
