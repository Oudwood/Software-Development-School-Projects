using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FatPercentageCalculator
{
    enum Selections
    {
        Cal,
        Perc,
        SelectNone = -1,
    }

    class VM : INotifyPropertyChanged
    {
        #region Properties
        private bool checkLowFat = false;
        public bool CheckLowFat
        {
            get { return checkLowFat; }
            set { checkLowFat = value; propertyChanged(); }
        }

        private Selections index = Selections.SelectNone;
        public Selections Index
        {
            get { return index; }
            set { index = value; Calc(); }
        }

        private string result = "Click the options above!";
        public string Result
        {
            get { return result; }
            set { result = value; propertyChanged(); }
        }

        private string caloriesInput;
        public string CaloriesInput
        {
            get { return caloriesInput; }
            set { caloriesInput = value; propertyChanged(); }
        }

        private string fatInput;
        public string FatInput
        {
            get { return fatInput; }
            set { fatInput = value; propertyChanged(); }
        }
        #endregion

        public void Calc()
        {
            try 
            {
                float CalNum = float.Parse(CaloriesInput);
                float FatNum = float.Parse(FatInput);

                float CalFromFat = CalNum * 9;
                float TotalPerc = FatNum * 9 / CalNum;

                string LowFatComment = TotalPerc < 0.3 ? " (Low Fat)" : " (Not Low Fat)";

                switch (Index)
                {
                    case Selections.Cal:
                        Result = $"The number of carlories from fat is {CalFromFat.ToString()}.";
                        break;
                    case Selections.Perc:
                        Result = $"The percentage of calories that come from fat is {TotalPerc.ToString("P")}.";
                        break;
                    default:
                        Result = $"";
                        break;
                }
                Result += CheckLowFat ? LowFatComment : " :)";
            }
            catch
            {
                Result = "Put A Number Bruh :<";
            }
        }

        #region propertychanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void propertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }
        #endregion
    }

}
