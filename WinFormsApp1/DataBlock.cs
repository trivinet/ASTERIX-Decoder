using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dashboard

{
    public class DataBlock
    {
        // ATTRIBUTES
        public int CAT { get; set; }  // In decimal
        public int LEN { get; set; }  // In decimal
        public string FSPEC { get; set; }  // Bits of FSPEC
        public string Data { get; set; }  // Bits of Data
        public List<int> FRNs { get; set; }  // List of decimal numbers with FRNs

        // METHODS
        static bool isDivisibleBy8(String str)
        {
            int n = str.Length;

            // Empty string
            if (n == 0)
                return false;

            // If there is single digit
            if (n == 1)
                return ((str[0] - '0') % 8 == 0);

            // If there is double digit
            if (n == 2)
                return (((str[n - 2] - '0') * 10 +
                (str[n - 1] - '0')) % 8 == 0);

            // If number formed by last three
            // digits is divisible by 8
            int last = str[n - 1] - '0';
            int second_last = str[n - 2] - '0';
            int third_last = str[n - 3] - '0';

            return ((third_last * 100 + second_last
                            * 10 + last) % 8 == 0);
        }

        public void getFRNs(string FSPEC)
        {
            int DataItemFRN = 1;
            int index = 1;
            FRNs = new List<int>();
            foreach (char bit in FSPEC)
            {
                // SKIPS THE FX BIT
                if (isDivisibleBy8(index.ToString()) && index != 0)
                {
                    // continue;
                }
                else
                {
                    if (bit.ToString() == "1")
                    {
                        // Save FRNs
                        FRNs.Add(DataItemFRN);
                    }
                    DataItemFRN++;
                }

                index++;
            }

            this.FRNs = FRNs;
        }

        // CONSTRUCTOR
        public DataBlock(int CAT, int LEN, string FSPEC, string Data)
        {
            this.CAT = CAT;
            this.LEN = LEN;
            this.FSPEC = FSPEC;
            this.Data = Data; 
        }
    }
}
