
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    class Program
    {
        const int nRow = 4;
        const int nCol = 4;
        static char[,] showBoard;
        static char[,] hideBoard;
        static int nRound;
        static char enteredPosition1=' ', enteredPosition2=' ';
        static void swap( ref int x, ref int y, ref int x1, ref int y1)
        {  
                char temp = hideBoard[x, y];
                hideBoard[x, y] =hideBoard[x1, y1];
                hideBoard[x1, y1] = temp;
           
        }
        static void InitGame()
        {
            showBoard= new char[nRow,nCol] { {'a','b','c','d'},{'e','f','g','h'},{'i','j','k','l'},{'m','n','o','p'}};
            hideBoard = new char[nRow, nCol] { { '1', '2', '3', '4' }, { '5', '6', '7', '8' }, { '1', '2', '3', '4' }, { '5', '6', '7', '8' } };
            
            Random rnd = new Random();
            int i = 0;
            while (i<=5)
                {
                int x = rnd.Next(0, 4);
                int y = rnd.Next(0, 4);

                int x1 = rnd.Next(0, 4);
                int y1 = rnd.Next(0, 4);
                swap(ref x, ref y, ref x1, ref y1);
                ++i;
            }
        }
        static void DisplayBoard(char[,] showBoard)
        {
            for (int r = 0; r < nRow; ++r)
            {
                for (int c = 0; c < nCol; ++c)
                {
                    Console.Write("{0,3}", showBoard[r, c]);
                }
                Console.WriteLine();
            }
        }
        static void MatchNumbers(int pos1Row, int pos1Col, int pos2Row,int pos2Col)
        {
            if (hideBoard[pos1Row, pos1Col] == hideBoard[pos2Row, pos2Col])
            {
                showBoard[pos1Row, pos1Col] = hideBoard[pos1Row, pos1Col];
                showBoard[pos2Row, pos2Col] = hideBoard[pos2Row, pos2Col];   
            }
        }
        static void PlayRound()
        {
            int r, c;
            int pos1Row = 0, pos1Col = 0;
            int pos2Row = 0, pos2Col = 0;
                Console.Write("Enter First Position (a...p):");
                enteredPosition1 = Convert.ToChar(Console.ReadLine());
            
            for(r=0;r<nRow;++r)
            {
                for(c=0;c<nCol;++c)
                {
                    if (enteredPosition1 == showBoard[r, c])
                    {
                        pos1Row = r;
                        pos1Col = c;
                        Console.WriteLine("Number at position {0} is {1}", enteredPosition1, hideBoard[pos1Row, pos1Col]);
                    }
                }
            }

            Console.Write("Enter First Position (a...p):");
            enteredPosition2 = Convert.ToChar(Console.ReadLine());
            for ( r=0; r<nRow;++r)
            {
                for(c=0;c<nCol;++c)
                {   
                    if(enteredPosition2==showBoard[r,c])
                    {
                        pos2Row = r;
                        pos2Col = c;
                        Console.WriteLine("Number at position {0} is {1}", enteredPosition2, hideBoard[pos2Row, pos2Col]);
                    }
                }
            }
            MatchNumbers(pos1Row, pos1Col, pos2Row, pos2Col);
            nRound++;
        }
        static bool AllRevealed()
        {
            for (int r = 0; r < nRow; ++r)
            {
                for (int c = 0; c < nCol; ++c)
                {
                    if (showBoard[r,c] != hideBoard[r,c])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static void ShowScore()
        {
            Console.WriteLine("Congratulations! You solved the Puzzle in {0} rounds.", nRound);
        }
        static void Main(string[] args)
        {
            InitGame();
            while (true)
            {
                DisplayBoard(showBoard);
                PlayRound();
                if (AllRevealed()) break; 
            }
            DisplayBoard(showBoard);
            ShowScore();
            Console.ReadLine();
        }
    }
}
