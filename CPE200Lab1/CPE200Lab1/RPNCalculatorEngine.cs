using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            //Console.WriteLine("@");
            string firstOp, secondOp;
            string[] strArray = str.Split(' ');
            if (strArray.Length == 1)
                return "E";
            Stack rpnStack = new Stack();

            foreach (string s in strArray)
            {
                // Console.WriteLine(s);
                if (isNumber(s))
                {
                    rpnStack.Push(s);

                }
                else if (isOperator(s))
                {
                    if (rpnStack.Count > 1)
                    {
                        secondOp = rpnStack.Pop().ToString();
                        firstOp = rpnStack.Pop().ToString();
                        rpnStack.Push(calculate(s, firstOp, secondOp));
                    }
                    else
                    {
                        return "E";
                    }

                }
                //rpnStack.Push(s);
            }

            if (rpnStack.Count == 1)
            {
                if (strArray[1] == "√" ||strArray[1] == "1/x")
                {
                    string firstnumber;
                    firstnumber = rpnStack.ToString();
                    rpnStack.Pop();
                    rpnStack.Push(unaryCalculate(strArray[1], firstnumber));
                }
                return rpnStack.Peek().ToString();
            }
            else
            {
                return "E";
            }
            // your code here
            //return "E";
        }
        public override string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(operand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return decimal.Parse(result.ToString("N" + remainLength)).ToString("G29");
                    }
                case "1/x":
                    if (operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;
                        result = (1.0 / Convert.ToDouble(operand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("G29");
                    }
               
                    break;
            }
            return "E";
        }
    }
}
