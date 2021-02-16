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
        const float FAT_TO_CAL_COEFFICIENT = 9;
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

        private string result;
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

                float CalFromFat = CalNum * FAT_TO_CAL_COEFFICIENT;
                float TotalPerc = FatNum * 9 / CalNum;

                string LowFatComment = TotalPerc < 0.3 ? " (Low Fat)" : " (Not Low Fat)";

                if (CalNum < FatNum *9 )
                {
                    Result = "Your math is Bad :<";
                }

                else 
                { 
                    switch (Index)
                    {
                        case Selections.Cal:
                            Result = $"{CalFromFat.ToString()}.";
                            break;
                        case Selections.Perc:
                            Result = $"{TotalPerc.ToString("P")}.";
                            break;
                        default:
                            Result = $"";
                            break;
                    }
                    Result += CheckLowFat ? LowFatComment : " :)";
                }
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
