using System;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Displays several properties of the neutral cultures.
            Console.WriteLine("CULTURE     ISO ISO WIN DISPLAYNAME                              ENGLISHNAME");
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                WriteCulture(ci);
            }

            Console.WriteLine(" {0}", "Currenc culture");
            WriteCulture(CultureInfo.CurrentCulture);

            Console.ReadLine();
        }

        private static void WriteCulture(CultureInfo ci)
        {
            Console.Write("{0,-12}", ci.Name);
            Console.Write(" {0,-3}", ci.TwoLetterISOLanguageName);
            Console.Write(" {0,-3}", ci.ThreeLetterISOLanguageName);
            Console.Write(" {0,-3}", ci.ThreeLetterWindowsLanguageName);
            Console.Write(" {0,-40}", ci.DisplayName);
            Console.Write(" {0,-40}", ci.EnglishName);
            try
            {
                Console.WriteLine(" {0,-6}", new RegionInfo(ci.LCID).ISOCurrencySymbol);
            }
            catch (Exception)
            {
                Console.WriteLine(" {0,-6}", "NOCURR");
            }

        }
    }
}
