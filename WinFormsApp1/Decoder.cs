/*
Clase para obtener datos sobre un archivo binario
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Dashboard
{
    public class Decoder
    {
        // ATTRIBUTES
        public string messageString { get; set; }
        public int numDataBlocks { get; set; }
        public int numBits { get; set; }
        public int numBytes { get; set; }

        // METHODS
        public List<DataBlock> getDataBlocks(string messageString, int numBytes)
        {
            var dataBlocks = new List<DataBlock>();

            int countBytes = 0;
            int countBits = 0;
            string firstChar;
            string lengthCad;
            int CAT;
            int LEN;
            string FSPEC;
            int lenFSPEC;
            string Data;

            while (countBytes < numBytes)
            {
                firstChar = messageString.Substring(countBits, 8 * 1);
                lengthCad = messageString.Substring(8 + countBits, 2 * 8);

                // Get CAT and LEN of each item
                CAT = Convert.ToInt32(firstChar, 2);
                LEN = Convert.ToInt32(lengthCad, 2);

                // Get FSPEC of each item
                lenFSPEC = 1;
                while (messageString.Substring(23 + 8 * lenFSPEC + countBits, 1) == "1")
                {
                    lenFSPEC += 1;
                }

                Data = messageString.Substring(countBits + 24 + 8 * lenFSPEC, (LEN - 3 - lenFSPEC) * 8);
                FSPEC = messageString.Substring(24 + countBits, lenFSPEC * 8);

                // Add DataBlock to List
                dataBlocks.Add(new DataBlock(CAT, LEN, FSPEC, Data));

                countBits += LEN * 8;
                countBytes += LEN;

            }

            return dataBlocks;
        }

        // CONSTRUCTOR
        public Decoder(string fileName)
        {
            // First get the string with all the bits
            byte[] fileBytes = File.ReadAllBytes(fileName);
            StringBuilder msg = new StringBuilder();

            foreach (byte b in fileBytes)
            {
                msg.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }

            string messageString = msg.ToString();
            this.messageString = messageString;

            // Get number of Data Blocks, Bits and Bytes in message
            int numBits = messageString.Length;
            int countBytes = 0;
            int countBits = 0;
            int numDataBlocks = 0;
            int numBytes = numBits / 8;
            string lengthCad;
            int LEN;

            this.numBits = numBits;
            this.numBytes = numBytes;

            while (countBytes < numBytes)
            {
                lengthCad = messageString.Substring(8 + countBits, 2 * 8);
                LEN = Convert.ToInt32(lengthCad, 2);
                countBytes += LEN;
                countBits += LEN * 8;
                numDataBlocks += 1;
            }

            this.numDataBlocks = numDataBlocks;

        }
    }
}
