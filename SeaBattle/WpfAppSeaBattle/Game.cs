using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfSeaBattle
{
    public class Game
    {
        public static readonly int fieldSize = 10;

        static Random myRnd = new Random();

        public enum CellType { Empty, Dot, Damaged, Destroyed, Ship };

        public CellType[,] playerField;
        public CellType[,] computerField;

        public int x, y;

        public Game() 
        {
            playerField = new CellType[fieldSize, fieldSize];
            computerField = new CellType[fieldSize, fieldSize];

            SetAllCellsEmpty(playerField);
            SetAllCellsEmpty(computerField);

            PlaceRandomShips(playerField);
            PlaceRandomShips(computerField);

            x = -1;
            y = -1;
        }

        void PlaceRandomShips(CellType[,] field) 
        {
            bool [,] visited = new bool[fieldSize, fieldSize];

            int currentSize = 4;
            int currentQuantity = 1;

            int quantityEnumerator = currentQuantity;

            while (true)
            {
                int x = myRnd.Next(fieldSize);
                int y = myRnd.Next(fieldSize);

                bool isHorizontal = false;
                if (myRnd.Next(2) == 1)
                {
                    isHorizontal = true;
                }
               
                if (visited[x, y])
                    continue;

                int cnt;
                if (isHorizontal)
                {
                    TransposeMatrix(visited);
                    cnt = CountFirstNotVisitedDownCells(y, x, visited); // swapped x and y
                    TransposeMatrix(visited);
                }
                else
                    cnt = CountFirstNotVisitedDownCells(x, y, visited); // swapped x and y

                //int right = x + cnt - 1;
                if (cnt >= currentSize)
                {
                    if (isHorizontal) 
                    {
                        TransposeMatrix(field);
                        TransposeMatrix(visited);
                        PlaceShip(y, x, currentSize, field, visited);// swapped x and y, changed cnt to currSize
                        TransposeMatrix(field);
                        TransposeMatrix(visited);
                    }
                    else
                       PlaceShip(x, y, currentSize, field, visited); // swapped x and y, changed cnt to currSize

                }
                else
                    continue;
               
                quantityEnumerator--;
                if (quantityEnumerator == 0) 
                {
                    currentQuantity++;
                    currentSize--;
                    quantityEnumerator = currentQuantity;
                }
                if (currentSize == 0) 
                    break;
            }
        }

        void PlaceShip(int x, int y, int length, CellType [,] field, bool [,] visited)
        {
            for (int i = x; i < x + length; i++)
            {
                field[i, y] = CellType.Ship; // places down
            }
            for (int i = x - 1; i <= x + length; i++)
            {
                for (int j = y - 1; j <= y + 1; j++) //Ok
                {
                    if (IsInField(i, j)) // deleted && field[i, j] == CellType.Empty (or add visited[i, y] = true; in for)
                        visited[i, j] = true;
                }
            }
        }

        void SetAllCellsEmpty(CellType[,] field)
        {
            for (int i = 0; i < fieldSize; i++) 
            {
                for (int j = 0; j < fieldSize; j++) 
                {
                    field[i, j] = CellType.Empty;
                }
            }
        }

        int CountFirstNotVisitedDownCells(int x, int y, bool[,] visited)
        {
            int cnt = 1;
            int down = x + 1; // now - down, was - right
            for (; down < fieldSize; down++)
            {
                if (!visited[down, y])
                    cnt++;
                else
                    break;
            }
            return cnt;
        }

        T[,] TransposeMatrix<T> (T[,] matrix)
        {
            for (int i = 0; i < fieldSize; i++) 
            {
                for (int j = i; j < fieldSize; j++)
                {
                    T tmp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = tmp;
                }
            }
            return matrix;
        }

        bool IsInField(int x, int y)
        {
            if (x >= 0 && x < fieldSize
                && y >= 0 && y < fieldSize)
                return true;
            return false;
        }

        public bool CheckIfMoveIsTransmittedAndMarkTheCell(int x, int y, CellType[,] field) 
        {
            switch (field[x, y])
            {
                case Game.CellType.Empty:
                    {
                        field[x, y] = CellType.Dot;
                        return true;
                    }
                case Game.CellType.Ship:
                    {
                        field[x, y] = CellType.Damaged;
                        if (shipIsDestroyed(x, y, field)) MarkShipAsDestroyed(x, y, field);
                        return false;
                    }
                default: {
                        return false;
                    }
            }
        }

        bool shipIsDestroyed(int x, int y, CellType[,] field)
        {
            //right
            for (int j=y+1; j < fieldSize; j++)
            {
                if((field[x, j] == CellType.Empty) || (field[x, j] == CellType.Dot)) break;
                if ((field[x, j] == CellType.Ship)) return false;
            }
            //down
            for (int j = x + 1; j < fieldSize; j++)
            {
                if ((field[j, y] == CellType.Empty) || (field[j, y] == CellType.Dot)) break;
                if ((field[j, y] == CellType.Ship)) return false;
            }
            //left
            for (int j = y - 1; j >= 0; j--)
            {
                if ((field[x, j] == CellType.Empty) || (field[x, j] == CellType.Dot)) break;
                if ((field[x, j] == CellType.Ship)) return false;
            }
            //up
            for (int j = x - 1; j >= 0; j--)
            {
                if ((field[j, y] == CellType.Empty) || (field[j, y] == CellType.Dot)) break;
                if ((field[j, y] == CellType.Ship)) return false;
            }
            return true;
        }

        void MarkShipAsDestroyed(int x, int y, CellType[,] field) 
        {
            PlaceDotsAround( x, y, field);
            field[x, y] = CellType.Destroyed;
            if (IsInField(x + 1, y) && (field[x + 1, y] == CellType.Damaged)) 
                MarkShipAsDestroyed(x + 1, y, field);
            if (IsInField(x - 1, y) && (field[x - 1, y] == CellType.Damaged)) 
                MarkShipAsDestroyed(x - 1, y, field);
            if (IsInField(x, y + 1) && (field[x, y + 1] == CellType.Damaged)) 
                MarkShipAsDestroyed(x, y + 1, field);
            if (IsInField(x, y - 1) && (field[x, y - 1] == CellType.Damaged)) 
                MarkShipAsDestroyed(x, y - 1, field);
        }

        void PlaceDotsAround (int x, int y, CellType[,] field)
        {
            for (int i = x - 1; i <= x + 1; i++) 
            {
                for (int j = y - 1; j <= y + 1; j++) 
                {
                    if (IsInField(i, j) && (field[i, j] == CellType.Empty)) 
                        field[i, j] = CellType.Dot;
                }
            }
        }

        public void ComputersMove(CellType[,] field) 
        {
            //int x = -1, y = -1; 
            for (int i = 0; i < fieldSize; i++) 
                for (int j = 0; j < fieldSize; j++)
                    if (field[i, j] == CellType.Damaged) 
                    {
                        x = i;
                        y = j;
                        CheckFourSides(x, y, field); 
                        return;                       
                    }

            x = myRnd.Next(fieldSize);
            y = myRnd.Next(fieldSize);
            return;            
        }

        bool CheckIfCellCanBeChosen(int x, int y, CellType[,] field)
        {
            if (IsInField(x, y) && ((field[x, y] == CellType.Empty) || (field[x, y] == CellType.Ship)))
                return true;
            return false;
        }

        void CheckFourSides(int x, int y, CellType[,] field) //horisontal or not
        {
            if (IsHorisontal(x, y, field)) 
            {
                CheckRightLeft(x, y, field);
                return;
            }
            else 
            {
                CheckUpDown(x, y, field);
                return;
            }
        }

        bool IsHorisontal(int x, int y, CellType[,] field) 
        {
            if ((IsInField(x, y - 1)) &&
                (field[x, y - 1] == CellType.Damaged)
                || (IsInField(x, y + 1)) &&
                (field[x, y + 1] == CellType.Damaged))
                return true;
            else //if it's a dot or doesnt't exist
                if (!((!IsInField(x - 1, y) || field[x - 1, y] == CellType.Dot) &&
                    (!IsInField(x + 1, y) || field[x + 1, y] == CellType.Dot) ))
                    return false;
                else 
                    return true;
        }

        //bool IsVertical(int x, int y, CellType[,] field)
        //{
        //    if ((IsInField(x - 1, y)) && (field[x - 1, y] == CellType.Damaged)
        //        || (IsInField(x + 1, y)) && (field[x + 1, y] == CellType.Damaged))
        //        return true;
        //    return false;
        //}

        void CheckRightLeft(int x, int y, CellType[,] field) 
        {
            //right
            for (int j = y + 1; j < fieldSize; j++)
            {
                if (IsInField(x, j) && (field[x, j] == CellType.Dot)) break;
                if (IsInField(x, j) && CheckIfCellCanBeChosen(x, j, field))
                {
                    this.x = x;
                    this.y = j;
                    return;
                }
            }
            //left
            for (int j = y - 1; j >= 0; j--)
            {
                if (IsInField(x, j) && (field[x, j] == CellType.Dot)) break;
                if (IsInField(x, j) && CheckIfCellCanBeChosen(x, j, field))
                {
                    this.x = x;
                    this.y = j;
                    return;
                }
            }
        }

        void CheckUpDown(int x, int y, CellType[,] field) 
        {
            //up
            for (int j = x - 1; j >= 0; j--)
            {
                if (IsInField(j, y) && (field[j, y] == CellType.Dot)) break;
                if (IsInField(j, y) && CheckIfCellCanBeChosen(j, y, field))
                {
                    this.x = j;
                    this.y = y;
                    return;
                }
            }
            //down
            for (int j = x + 1; j < fieldSize; j++)
            {
                if (IsInField(j, y) && (field[j, y] == CellType.Dot)) break;
                if (IsInField(j, y) && CheckIfCellCanBeChosen(j, y, field))
                {
                    this.x = j;
                    this.y = y;
                    return;
                }
            }
        }

        public int CheckSmbdWonLost()
        {
            bool computerWon = true;
            bool playerWon = true;

            for (int i = 0; i < fieldSize; i++) 
            {
                for (int j = 0; j < fieldSize; j++) 
                {
                    if (playerField[i, j] == CellType.Ship) 
                        computerWon = false;
                    if (computerField[i, j] == CellType.Ship)
                        playerWon = false;
                }
            }

            if (computerWon) 
                return 0;
            else 
                if (playerWon) 
                    return 1;
                else 
                    return -1;
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="value"></param>
        void SetAllElements<T>(IList<T> collection, T value)
        {
            for (int i = 0; i < collection.Count; i++)
                collection[i] = value;
        }
    }
}