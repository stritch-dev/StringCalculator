using System;
using System.Text;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    
    
    public static class StringCalculator
    {
          public static int Add(string inputWithDelimiter )
          {
              switch (inputWithDelimiter)
              {
                  case null:
                      throw new ArgumentNullException(nameof(inputWithDelimiter));
                  case "":
                      { return 0;}
              }

                  var delimiter = GetDelimiter(inputWithDelimiter);
              
                  var numberString = Regex.Replace(@inputWithDelimiter, @"//", "");
                  numberString = Regex.Replace(numberString, "[\\[\\]]", "");
                  var a = numberString.ToCharArray();
                  var firstChar = numberString.ToCharArray()[0];
                  if (!char.IsDigit(firstChar) &&  firstChar != '-')
                  {
                      numberString = numberString.Substring(1);
                  }

                  var rx = new Regex(
                      delimiter); 
                  var numbers = rx.Split(numberString);

                  return GetSum(numbers);
          }
        
        
        public static int GetSum(string[] numberList)
        {
            var answer = 0;
            var error = new StringBuilder();

            foreach (var number in numberList)
            {
                var replace = Regex.Replace(number, "\n", "");
                replace = Regex.Replace(number, "\r", "");
                var value = int.Parse(replace);

                if (value < 0)
                {
                    error.Append($"{value} ");
                }
                else if (value < 1001)
                {
                    answer += value;
                    var a = 10;
                }
            }

            if (error.Length > 0) throw new ArgumentException("Negatives are not allowed: " + error);
            return answer;
        }

        public static string GetDelimiter(string input)
        {
            var delimiter = "[,\n\r]";
            if (input.IndexOf("//[", StringComparison.Ordinal) == 0)
            {
                var indexOfEnd = input.IndexOf("]\n");
                var index = "//[".Length;
                if (index >= 0 && input.Length > index)
                {
                    delimiter = input.Substring(index, indexOfEnd - index);
                }
            }
            else if (input.IndexOf("//") == 0)
            {
                delimiter = input.Substring(2, 1);
            }

            return delimiter;
        }
    }
}
