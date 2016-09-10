using System.Globalization;

namespace TrainingProject.Models
{
    public class CalculateModel
    {
        public double A { get; set; }
        public string Operation { get; set; }
        public double B { get; set; }
        public string Calculate()
        {
            if (Operation != null )
            {
                switch (Operation)
                {
                    case "+":
                        return (A + B).ToString(CultureInfo.CurrentCulture);
                    case "-":
                        return (A - B).ToString(CultureInfo.CurrentCulture);
                    case "*":
                        return (A * B).ToString(CultureInfo.CurrentCulture);
                    case "/":
                        return (A / B).ToString(CultureInfo.CurrentCulture);
                    default:
                        return "Unknow operator";
                }
            }
            else
            {
                return "Value can't be null";
            }
        }
    }
}

