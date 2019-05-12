using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{

    class Program
    {
        public static int player = 1;
        public static char XorO;
        private static bool ReplayAgain = true;
        public static bool AllBoxNotFilled = true;
        public static char[] game = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
        public static char[] newgame = new char[9];

        static void Main(string[] args)
        {

            while (ReplayAgain == true)
            {
                Array.Copy(game, newgame, 9);
                AllBoxNotFilled = true;
                player = 1;
                Console.Clear();
                do
                {
                    introduction FirstIntroInstant = new introduction();
                    FirstIntroInstant.intro();

                    introduction FirstGameboardInstant = new introduction();
                    FirstIntroInstant.gameboard();

                    //Console.WriteLine();
                    //Console.SetCursorPosition(50, Console.CursorTop - 50);
                    //Console.Write("{0}  |  {1}  |  {2}  ", newgame[0], newgame[1], newgame[2]);


                    //Console.SetCursorPosition(50, Console.CursorTop + 1);
                    //Console.Write(".............");


                    //Console.SetCursorPosition(50, Console.CursorTop + 1);
                    //Console.Write("   |     |      ");


                    //Console.SetCursorPosition(50, Console.CursorTop + 1);
                    //Console.Write("{0}  |  {1}  |  {2}  ", newgame[3], newgame[4], newgame[5]);


                    //Console.SetCursorPosition(50, Console.CursorTop + 1);
                    //Console.Write(".............");


                    //Console.SetCursorPosition(50, Console.CursorTop + 1);
                    //Console.Write("   |     |      ");


                    //Console.SetCursorPosition(50, Console.CursorTop);
                    //Console.Write("{0}  |  {1}  |  {2}  ", newgame[6], newgame[7], newgame[8]);


                    //Console.WriteLine();
                    //Console.WriteLine();
                    //Console.WriteLine();


                    InputChecker FirstInstantOfInputChecker = new InputChecker();
                    FirstInstantOfInputChecker.Input();


                    if (player == 1)
                    {
                        XorO = 'X';
                        newgame[InputChecker.decision] = XorO;

                        ClassWinnerChecker FirstInstantOfClassWinnerChecker = new ClassWinnerChecker();
                        FirstInstantOfClassWinnerChecker.WinnerChecker();

                        player = 2;

                    }
                    else
                    {
                        XorO = 'O';
                        newgame[InputChecker.decision] = XorO;

                        ClassWinnerChecker FirstInstantOfClassWinnerChecker = new ClassWinnerChecker();
                        FirstInstantOfClassWinnerChecker.WinnerChecker();

                        player = 1;
                    }

                } while (AllBoxNotFilled == true);


                Console.WriteLine("Do you want to play again Press <Y/N>");
                string RepititionChoice = Console.ReadLine();
                if (RepititionChoice == "y" || RepititionChoice == "Y")
                { ReplayAgain = true; }
                else
                { ReplayAgain = false; }
            }




        }
    }



    class introduction
    {

        public void gameboard()
        {
            string blankspaceof50 = "                                                  ";
            Console.WriteLine();
            Console.WriteLine(blankspaceof50 +"{0}  |  {1}  |  {2}  ", Program.newgame[0], Program.newgame[1], Program.newgame[2]);
            Console.WriteLine(blankspaceof50 +".............");
            Console.WriteLine(blankspaceof50 +"   |     |      ");
            Console.WriteLine(blankspaceof50 +"{0}  |  {1}  |  {2}  ", Program.newgame[3], Program.newgame[4], Program.newgame[5]);
            Console.WriteLine(blankspaceof50 +".............");
            Console.WriteLine(blankspaceof50 +"   |     |      ");
            Console.WriteLine(blankspaceof50 +"{0}  |  {1}  |  {2}  ", Program.newgame[6], Program.newgame[7], Program.newgame[8]);
        }

        public void intro()
        {
            Console.Clear();
            Console.SetCursorPosition(50, 0);
            Console.Write("Welcome to the newgame ");
            Console.WriteLine();
            Console.WriteLine();

            Console.Write(" Player 1 goes for:");
            Console.SetCursorPosition(100, Console.CursorTop);
            Console.Write("Player 2 goes for :");

            Console.SetCursorPosition(8, Console.CursorTop + 2);
            Console.Write('X');
            Console.SetCursorPosition(108, Console.CursorTop);
            Console.Write('O');

            Console.WriteLine();
            Console.WriteLine();
        }
    }


    class messeges
    {
        protected string blankspace = "                                                                                     ";

        public void OverwrittingMessege()
        {
            Console.SetCursorPosition(50, Console.CursorTop - 1);
            Console.Write("!!!Already Filled!!!");
            System.Threading.Thread.Sleep(500);
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write("{0}", blankspace);
            Console.SetCursorPosition(0, Console.CursorTop);
        }

        public void WrongSelectionOutput()
        {

            Console.SetCursorPosition(50, Console.CursorTop - 1);
            Console.Write("Wrong Selection");
            System.Threading.Thread.Sleep(500);
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write("{0}", blankspace);
            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }





    class InputChecker
    {
        public static int decision;
        private bool condition = true;

        public void Input()
        {
            while (condition == true)
            {
                Console.Write("Player {0} Make Your Selction :", Program.player);
                try
                {
                    decision = Convert.ToInt32(Console.ReadLine());
                    condition = false;
                    if (decision >= 0 && decision <= 8)
                    {
                        if (Program.newgame[decision] == 'X' || Program.newgame[decision] == 'O')
                        {
                            messeges SecondInstantOfMesseges = new messeges();
                            SecondInstantOfMesseges.OverwrittingMessege();
                            condition = true;
                        }
                    }
                    else
                    {
                        messeges FirstInstantOfMesseges = new messeges();
                        FirstInstantOfMesseges.WrongSelectionOutput();
                        condition = true;
                    }


                }
                catch
                {
                    messeges SecondInstantOfMesseges = new messeges();
                    SecondInstantOfMesseges.WrongSelectionOutput();
                    condition = true;
                }

            }

        }
    }

    class ClassWinnerChecker
    {

        public void WinnerChecker()
        {
            if (
                Program.newgame[0] == Program.XorO && Program.newgame[1] == Program.XorO && Program.newgame[2] == Program.XorO
                ||
                Program.newgame[3] == Program.XorO && Program.newgame[4] == Program.XorO && Program.newgame[5] == Program.XorO
                ||
                Program.newgame[6] == Program.XorO && Program.newgame[7] == Program.XorO && Program.newgame[8] == Program.XorO
                ||
                Program.newgame[0] == Program.XorO && Program.newgame[3] == Program.XorO && Program.newgame[6] == Program.XorO
                ||
                Program.newgame[1] == Program.XorO && Program.newgame[4] == Program.XorO && Program.newgame[7] == Program.XorO
                ||
                Program.newgame[2] == Program.XorO && Program.newgame[5] == Program.XorO && Program.newgame[8] == Program.XorO
                ||
                Program.newgame[0] == Program.XorO && Program.newgame[4] == Program.XorO && Program.newgame[8] == Program.XorO
                ||
                Program.newgame[2] == Program.XorO && Program.newgame[4] == Program.XorO && Program.newgame[6] == Program.XorO
               )
            {
                Console.SetCursorPosition(55, Console.CursorTop + 1);
                Console.Write("Player {0} won", Program.player);
                Program.AllBoxNotFilled = false;
                Console.ReadKey();
            }
            else if (Program.newgame[0] != '0' && Program.newgame[1] != '1' && Program.newgame[2] != '2' && Program.newgame[3] != '3' && Program.newgame[4] != '4' && Program.newgame[5] != '5' && Program.newgame[6] != '6' && Program.newgame[7] != '7' && Program.newgame[8] != '8')
            {
                Console.SetCursorPosition(55, Console.CursorTop + 1);
                Console.Write("game Drawn000000000000000000000000000000000000000000");
                Program.AllBoxNotFilled = false;
                Console.ReadKey();
            }
            else
            {
                Program.AllBoxNotFilled = true;
            }
        }

    }

}
