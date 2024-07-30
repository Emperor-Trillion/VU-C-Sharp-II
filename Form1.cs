using System.Windows.Forms;
using System;

namespace calc
{
    public partial class Form1 : Form
    {
        public string lastClick = "";
        public int firstInput = 0;
        public string _inputNumString = "";
        public string _2nd_inputNumString = "";
        public string _1st_inputNumString = "";
        public string _resultNumString = "";
        public double _inputNumInt1 = 0;
        public double _inputNumInt2 = 0;
        public double _calcResult = 0;
        bool decimalPresent = false;

        private void HandleInputOfNums(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            string value = clicked.Text;

            if (value == "DEL" || value == "+/-" || value == "%" || value == "C")
            {
                SpecialKeys(value);
            }
            else
            {
                HandleDecimal(value);
                bool checker = CovertNum(value);
                if (checker == true)
                {
                    _inputNumString += value;
                    _ResultDisplay.Text = _inputNumString;
                }
                else
                {
                    if (value != "." && value != "=")
                    {
                        if (firstInput == 0 && _inputNumString != "")
                        {
                            _1st_inputNumString = _inputNumString;
                            firstInput = 1;
                            _inputNumString = "";
                            DisplayAtTheTop(value, _1st_inputNumString);
                            decimalPresent = false;
                        }
                        else if (firstInput == 1)
                        {
                            _2nd_inputNumString = _inputNumString;
                            if (_2nd_inputNumString == "")
                            {
                                DisplayAtTheTop(value, _1st_inputNumString);
                            }
                            else
                            {
                                DisplayAtTheTop(value, _2nd_inputNumString);
                            }
                            decimalPresent = false;
                        }
                        else if (firstInput >= 2)
                        {
                            _1st_inputNumString = _resultNumString;
                            _2nd_inputNumString = _inputNumString;
                            decimalPresent = false;
                        }

                        if (_2nd_inputNumString != "")
                        {
                            firstInput++;
                            OperatorsFunction(lastClick, _1st_inputNumString, _2nd_inputNumString);
                            DisplayAtTheTop(value, _resultNumString);
                            _inputNumString = "";
                            _ResultDisplay.Text = _resultNumString;
                            _1st_inputNumString = _resultNumString;
                        }
                        lastClick = value;
                        DisplayAtTheTop(lastClick, _resultNumString);
                    }
                    else if (value != "." && value == "=")
                    {
                        _2nd_inputNumString = _inputNumString;
                        if (_2nd_inputNumString != "" && _1st_inputNumString != "")
                        {
                            OperatorsFunction(lastClick, _1st_inputNumString, _2nd_inputNumString);
                            _DisplayHolder.Text = _1st_inputNumString + lastClick + _2nd_inputNumString + "" + value;
                            _ResultDisplay.Text = _resultNumString;
                        }
                    }
                }

            }
        }

        private string HandleRepetition(string number, string buttonA, string buttonB)
        {
            return buttonB;
        }


        private void HandleDecimal(string value)
        {
            if (decimalPresent == false && value == ".")
            {
                if (_inputNumString.Length == 0)
                {
                    _inputNumString = "0.";
                }
                else
                {
                    _inputNumString += value;
                }
                decimalPresent = true;
                _ResultDisplay.Text = _inputNumString;
            }
        }

        public static bool CovertNum(string something)
        {
            double resultNum;
            if (double.TryParse(something, out resultNum))
            {
                return true;
            }
            return false;
        }

        public void DisplayAtTheTop(string value, string input)
        {
            if (CovertNum(input))
            {
                input = input + ' ' + value;
                _DisplayHolder.Text = input;
            }
        }

        public void AbortedCalc()
        {
            _calcResult = _inputNumInt1 = _inputNumInt2 = 0;
            _inputNumString = _1st_inputNumString = _2nd_inputNumString = _resultNumString = "";
            firstInput = 0;
            decimalPresent = false;
            _DisplayHolder.Text = "";
            _ResultDisplay.Text = "0";

        }
        public void SpecialKeys(string value)
        {

            if (value == "C")
            {
                AbortedCalc();
            }
            else if (value == "DEL")
            {
                if (_inputNumString.Length > 0)
                {
                    _inputNumString = _inputNumString.Remove(_inputNumString.Length - 1);
                    _ResultDisplay.Text = _inputNumString;
                }
            }
            else if (value == "+/-")
            {
                if (CovertNum(_inputNumString) == true)
                {
                    _inputNumInt1 = Convert.ToDouble(_inputNumString);
                    _calcResult = _inputNumInt1 * (-1);
                    _resultNumString = _calcResult.ToString();
                    _ResultDisplay.Text = _resultNumString;
                }

            }
            else if (value == "%")
            {

                if (CovertNum(_inputNumString) == true)
                {
                    _inputNumInt1 = Convert.ToDouble(_inputNumString);
                    _calcResult = _inputNumInt1 * (0.01);
                    _resultNumString = _calcResult.ToString();
                    _ResultDisplay.Text = _resultNumString;
                }
            }
        }

        private void PrepareSecondData(string a, string b)
        {
            bool checker1 = CovertNum(a);
            bool checker2 = CovertNum(b);
            if (checker1 == true && checker2 == true)
            {
                _inputNumInt1 = double.Parse(a);
                _inputNumInt2 = double.Parse(b);
            }
        }

        private void OperatorsFunction(string value, string a, string b)
        {
            PrepareSecondData(a, b);
            switch (value)
            {
                case "+":
                    _calcResult = _inputNumInt1 + _inputNumInt2;
                    _resultNumString = _calcResult.ToString();
                    break;
                case "-":
                    _calcResult = _inputNumInt1 - _inputNumInt2;
                    _resultNumString = _calcResult.ToString();
                    break;
                case "X":
                    _calcResult = _inputNumInt1 * _inputNumInt2;
                    _resultNumString = _calcResult.ToString();
                    break;
                case "÷":
                    if (_inputNumInt2 != 0)
                    {
                        _calcResult = _inputNumInt1 / _inputNumInt2;
                        _resultNumString = _calcResult.ToString();
                    }
                    else
                    {
                        _resultNumString = "Cannot divide by zero";
                    }
                    break;
                default:
                    break;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
    }
}

