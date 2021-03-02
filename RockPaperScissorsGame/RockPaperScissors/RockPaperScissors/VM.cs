using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    enum Selections
    {
        rock,
        paper,
        scissors,
        SelectNone = -1
    }

    class VM : INotifyPropertyChanged
    {
        const string ROCKSRC = "Imgs/Rock.bmp";
        const string PAPERSRC = "Imgs/Paper.bmp";
        const string SCISSORSSRC = "Imgs/Scissors.bmp";
        const string EMPTYSRC = "";
        const string WELCOME = "Rock, Paper, Scissors - Choose to win!";
        const string YOU_WIN = "You Win!";
        const string COMPUTER_WIN = "Computer Win!";
        const string TIE = "It's a tie! Try Agin!";
        const int ROCK = 1;
        const int PAPER = 2;
        const int SCISSORS = 3;
        int CompuRandom;

        private int RandomNumber()
        {
            Random GametoNum = new Random();
            return GametoNum.Next(1, 4);
        }

        private string topView = WELCOME;
        public string TopView
        {
            get { return topView; }
            set { topView = value; notifyChange(); }
        }

        private string youImg;
        public string YouImg
        {
            get { return youImg; }
            set { youImg = value; notifyChange(); }
        }
        private string computerImg;
        public string ComputerImg
        {
            get { return computerImg; }
            set { computerImg = value; notifyChange(); }
        }

        private Selections index = Selections.SelectNone;
        public Selections Index
        {
            get { return index; }
            set { index = value; RevealImg(); }
        }

        private void ComputerChoice()
        {
            CompuRandom = RandomNumber();
        }

        private void RevealImg()
        {
            ComputerChoice();
            ShowComputerChoice();
            CompareAndShow();
        }

        private void ShowComputerChoice()
        {
            switch (CompuRandom)
            {
                case 1:
                    ComputerImg = ROCKSRC;
                    break;
                case 2:
                    ComputerImg = PAPERSRC;
                    break;
                case 3:
                    ComputerImg = SCISSORSSRC;
                    break;
                default:
                    ComputerImg = "";
                    break;
            }
        }

        private void CompareAndShow()
        {
            switch(Index)
            {
                case Selections.rock:
                    YouImg = ROCKSRC;
                    switch (CompuRandom)
                    {
                        case ROCK:
                            TopView = TIE;
                            break;
                        case PAPER:
                            TopView = COMPUTER_WIN;
                            break;
                        case SCISSORS:
                            TopView = YOU_WIN;
                            break;                            
                    }
                    break;

                case Selections.paper:
                    YouImg = PAPERSRC;
                    switch (CompuRandom)
                    {
                        case ROCK:
                            TopView = YOU_WIN;
                            break;
                        case PAPER:
                            TopView = TIE;
                            break;
                        case SCISSORS:
                            TopView = COMPUTER_WIN;
                            break;
                    }
                    break;

                case Selections.scissors:
                    YouImg = SCISSORSSRC;
                    switch (CompuRandom)
                    {
                        case ROCK:
                            TopView = COMPUTER_WIN;
                            break;
                        case PAPER:
                            TopView = YOU_WIN;
                            break;
                        case SCISSORS:
                            TopView = TIE;
                            break;
                    }
                    break;

                default:
                    YouImg = "";
                    break;
            }

        }
        
        public void Clear()
        {
            TopView = WELCOME;
            YouImg = EMPTYSRC;
            ComputerImg = EMPTYSRC;
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void notifyChange([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
