using System;

class FormulaBit1
{
    static void Main()
    {
        int[] lines = new int[8];
        for (int i = 0; i < 8; i++)
        {
            lines[i] = int.Parse(Console.ReadLine());
        }

        int direction = 1; //1(South-down) -1(North-up) 0(West-left)
        int positionX = 0;
        int positionY = 0;
        int movesCount = 0;
        int turnsCount = 0;
        bool endOfGame = false;
        int fullCycle = 0;


        if ((lines[positionY] & (1 << positionX)) == 0)
        {
            movesCount++;
            while (true)
            {
                if (positionY == 7 && positionX == 7)
                {
                    break;
                }
                if (endOfGame)
                {
                    break;
                }
                else
                {
                    if (movesCount==1)
                    {
                        if ((lines[positionY+1] & (1 << positionX)) == 0)
                        {
                            positionY++;
                            movesCount++;
                            continue;
                        }
                        else
                        {
                            endOfGame = true;
                            break;
                        }
                    }
                    else
                    {
                        if (direction == 1)
                        {
                            if (positionY+1<=7)
                            {
                                if ((lines[positionY + 1] & (1 << positionX)) == 0)
                                {
                                    positionY++;
                                    movesCount++;
                                    continue;
                                }
                                else if ((lines[positionY] & (1 << (positionX + 1))) == 0 && (positionX+1<=7))
                                {
                                    positionX++;
                                    direction = 0;
                                    fullCycle++;
                                    movesCount++;
                                    turnsCount++;
                                    continue;
                                }
                                else
                                {
                                    endOfGame = true;
                                    break;
                                }
                            }
                            else
                            {
                                if ((lines[positionY] & (1 << (positionX + 1))) == 0 && (positionX + 1 <= 7))
                                {
                                    positionX++;
                                    direction = 0;
                                    fullCycle++;
                                    movesCount++;
                                    turnsCount++;
                                    continue;
                                }
                                else
                                {
                                    endOfGame = true;
                                    break;
                                }
                            }
                        }
                     

                        if (direction == 0)
                        {
                            if (positionX+1<=7)
                            {
                                if ((lines[positionY] & (1 << positionX + 1)) == 0)
                                {
                                    positionX++;
                                    movesCount++;
                                    continue;
                                }
                                else if (fullCycle != 2 && ((lines[positionY - 1] & (1 << positionX)) == 0) && (positionY - 1 >= 0))
                                {
                                    positionY--;
                                    direction = -1;
                                    movesCount++;
                                    turnsCount++;
                                    continue;
                                }
                                else if (fullCycle == 2 && ((lines[positionY + 1] & (1 << positionX)) == 0) && (positionY + 1 <= 7))
                                {
                                    positionY++;
                                    direction = 1;
                                    movesCount++;
                                    turnsCount++;
                                    fullCycle = 0;
                                    continue;
                                }
                                else
                                {
                                    endOfGame = true;
                                    break;
                                }
                            }
                            else
                            {
                                if (fullCycle != 2 && ((lines[positionY - 1] & (1 << positionX)) == 0) && (positionY - 1 >= 0))
                                {
                                    positionY--;
                                    direction = -1;
                                    movesCount++;
                                    turnsCount++;
                                    continue;
                                }
                                else if (fullCycle == 2 && ((lines[positionY + 1] & (1 << positionX)) == 0) && (positionY + 1 <= 7))
                                {
                                    positionY++;
                                    direction = 1;
                                    movesCount++;
                                    turnsCount++;
                                    fullCycle = 0;
                                    continue;
                                }
                                else
                                {
                                    endOfGame = true;
                                    break;
                                }
                            }
                                                                
                        }

                        if (direction == -1)
                        {
                            if (positionY-1>=0)
                            {
                                if ((lines[positionY - 1] & (1 << positionX)) == 0)
                                {
                                    positionY--;
                                    movesCount++;
                                    continue;
                                }
                                else if (((lines[positionY] & (1 << positionX + 1)) == 0) && (positionX+1<=7))
                                {
                                    positionX++;
                                    direction = 0;
                                    fullCycle++;
                                    movesCount++;
                                    turnsCount++;
                                    continue;
                                }
                                else
                                {
                                    endOfGame = true;
                                    break;
                                }
                            }
                            else
                            {
                                if (((lines[positionY] & (1 << positionX + 1)) == 0) && (positionX + 1 <= 7))
                                {
                                    positionX++;
                                    direction = 0;
                                    fullCycle++;
                                    movesCount++;
                                    turnsCount++;
                                    continue;
                                }
                                else
                                {
                                    endOfGame = true;
                                    break;
                                }
                            }
                            
                        }
                    }
                                      
                }
            }

        }

        if (endOfGame)
        {
            Console.WriteLine("No {0}", movesCount);

        }
        else if (endOfGame==false && positionY != 7 && positionX != 7)
        {
            Console.WriteLine("No {0}", movesCount);

        }
        else if (endOfGame==false && positionY == 7 && positionX == 7)
        {
            Console.WriteLine("{0} {1}", movesCount,turnsCount);         
        }

        

    }
}
