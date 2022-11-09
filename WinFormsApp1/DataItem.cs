using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dashboard

{
    public class DataItem
    {
        // ATRIBUTES

        // I062/010 Data Source Identifier #1
        public string SIC { get; set; }
        public string SAC { get; set; }
        // I062/015 Service Identification #3
        public string ServiceID { get; set; }
        // I062/070 Time Of Track Information #4
        public string TimeOfTrackInfo { get; set; }
        public Double TimeSeconds { get; set; }
        // I062/105 Calculated Track Position (WGS-84) #5
        public string LatWGS84 { get; set; }
        public string LatWGS84str { get; set; }
        public string LonWGS84 { get; set; }
        public string LonWGS84str { get; set; }
        // I062/100 Calculated Track Position (Cartesian) #6
        public string X { get; set; }
        public string Y { get; set; }
        // I062/185 Calculated Track Velocity (Cartesian) #7
        public string Vx { get; set; }
        public string Vy { get; set; }
        // I062/210 Calculated Acceleration (Cartesian) #8
        public string Ax { get; set; }
        public string Ay { get; set; }
        // I062/060 Track Mode 3/A Code #9
        public string Validated { get; set; }
        public string Garbled { get; set; }
        public string ChangeInMode { get; set; }
        public string Mode3AReply { get; set; }
        // I062/245 Target Identification #10
        public string STI { get; set; }
        public string TargetID { get; set; }
        // I062/380 Aircraft Derived Data #11
        public string primary11 { get; set; }
        // Subfield 1
        public string ADR { get; set; } // Target Address
                                        // Subfield 2
        public string ID { get; set; }  // Target Identification
                                        // Subfield 3
        public string MHG { get; set; } // Magnetic Heading [°]
                                        // Subfield 4
        public string IM { get; set; } // IAS or MACH
        public string IAS { get; set; } // Indicated Airspeed [NM/s]
        public string MACH { get; set; } // Mach No.
                                         // Subfield 5
        public string TAS { get; set; } // True Airspeed [knots]
                                        // Subfield 6
        public string SAS { get; set; } // Source information provided or not provided
        public string Source { get; set; } // Source information
        public string SAL { get; set; } // Selected Altitude [ft] *Data
                                        // Subfield 7
        public string MV { get; set; } // Manage Vertical Mode
        public string AH { get; set; } // Altitude Hold
        public string AM { get; set; } // Approach Mode
        public string FSS { get; set; } // Final State Selected Altitude [25ft] *Data
                                        // Subfield 8
        public string NAV { get; set; } // Trayectory Intent Data Available
        public string NVB { get; set; } // Trayectory Intent Data Valid
                                        // Subfield 9
        public string REP { get; set; } // Repetition Factor
        public string TCA { get; set; } // TCP number availability
        public string NC { get; set; } // TCP compliance
        public string TCPNumber { get; set; } // Trajectory Change Point number
        public string Altitude { get; set; } // [ft]
        public string Latitude { get; set; } // [degree]
        public string Longitude { get; set; } // [degree]
        public string PointType { get; set; } // Point type
        public string TD { get; set; } // Turn
        public string TRA { get; set; } // Turn Radius Availability
        public string TOA { get; set; } // TOV availability
        public string TOV { get; set; } // Time Over Point [second]
        public string TTR { get; set; } // TCP Turn Radius [Nm]
                                        // Subfield 10
        public string COM { get; set; } // Communications capability of the transponder
        public string STAT { get; set; } // Flight Status
        public string SSC { get; set; } // Specific service capability
        public string ARC { get; set; } // Altitude reporting capability
        public string AIC { get; set; } // Aircraft identification capability
        public string B1A { get; set; } // BDS
        public string B1B { get; set; } // BDS
                                        // Subfield 11
        public string AC { get; set; } // ACAS  
        public string MN { get; set; } // Multiple navigational aids
        public string DC { get; set; } // Differential correction
        public string GBS { get; set; } // Transponder Ground Bit
        public string SAB { get; set; } // Status reported by ADS-B
                                        // Subfield 12
        public string ACS { get; set; } // ACAS Resolution Advisory Report (se salta)
                                        // Subfield 13
        public string BVR { get; set; } // Barometric Vertical Rate [feet/minute]
                                        // Subfield 14
        public string GVR { get; set; } // Geometric Vertical Rate [feet/minute]
                                        // Subfield 15
        public string RAN { get; set; } // Roll Angle [degree]
                                        // Subfield 16
        public string TI { get; set; } // Turn indicator
        public string TAR { get; set; } // Track angle rate (rate of turn) [°/s]
                                        // Subfield 17
        public string TAN { get; set; } // Track Angle [°]
                                        // Subfield 18
        public string GSP { get; set; } // Ground Speed [NM/s]
                                        // Subfield 19
        public string VUN { get; set; } // Velocity Uncertainty Category
                                        // Subfield 20
        public string WS { get; set; } // Valid wind speed
        public string WD { get; set; } // Valid wind direction
        public string TMP { get; set; } // Valid temperature
        public string TRB { get; set; } // Valide turbulence
        public string WindSpeed { get; set; } // [knots]
        public string WindDirection { get; set; } // [degree]
        public string Temperature { get; set; } // [°C]
        public string Turbulence { get; set; } // [integer]
                                               // Subfield 21
        public string EMC { get; set; } // Emmiter Category
                                        // Subfield 22
        public string POSLatWGS84 { get; set; } // [degree]
        public string POSLonWGS84 { get; set; } // [degree]
                                                // Subfield 23
        public string GAL { get; set; } // [ft]
                                        // Subfield 24
        public string PUN { get; set; } // Position Uncertainty
                                        // Subfield 25
        public string REP25 { get; set; } // REPETITION FACTOR
        public string MB { get; set; } // MODE S MB DATA
        public string BDS1 { get; set; } // BDS REGISTER
        public string BDS2 { get; set; } // BDS CODE
                                         // Subfield 26
        public string IAR { get; set; } // Indicated Airspeed [knots]
                                        // Subfield 27
        public string MAC { get; set; } // Mach Number []
                                        // Subfield 28
        public string BPS { get; set; } // Barometric Pressure Setting (derived from Mode S BDS 4,0) [mb]

        // I062/040 Track Number #12
        public string TrackNumber { get; set; }

        // I062/080 Track Status #13
        public string primary13 { get; set; }
        public string MON { get; set; }
        public string SPI { get; set; }
        public string MRH { get; set; }
        public string SRC { get; set; }
        public string CNF { get; set; }
        // First Extent
        public string SIM { get; set; }
        public string TSE { get; set; }
        public string TSB { get; set; }
        public string FPC { get; set; }
        public string AFF { get; set; }
        public string STP { get; set; }
        public string KOS { get; set; }
        // Second Extent
        public string AMA { get; set; }
        public string MD4 { get; set; }
        public string ME { get; set; }
        public string MI { get; set; }
        public string MD5 { get; set; }
        // Third Extent
        public string CST { get; set; }
        public string PSR { get; set; }
        public string SSR { get; set; }
        public string MDS { get; set; }
        public string ADS { get; set; }
        public string SUC { get; set; }
        public string AAC { get; set; }
        // Fourth Extent
        public string SDS { get; set; }
        public string EMS { get; set; }
        public string PFT { get; set; }
        public string FPLT { get; set; }
        // Fifth Extent
        public string DUPT { get; set; }
        public string DUPF { get; set; }
        public string DUPM { get; set; }
        public string SFC { get; set; }
        public string IDD { get; set; }
        public string IEC { get; set; }

        // I062/290 System Track Update Ages #14
        public string primary14 { get; set; }
        //Subfield 1
        public string TRK { get; set; }
        //Subfield 2
        public string PSR290 { get; set; }
        //Subfield 3
        public string SSR290 { get; set; }
        //Subfield 4
        public string MDS290 { get; set; }
        //Subfield 5
        public string ADS290 { get; set; }
        //Subfield 6
        public string ES { get; set; }
        //Subfield 7
        public string VDL { get; set; }
        //Subfield 8
        public string UAT { get; set; }
        //Subfield 9
        public string LOP { get; set; }
        //Subfield 10
        public string MLT { get; set; }

        // I062/200 Calculated Track Velocity (Cartesian) #15
        public string TRANS { get; set; }
        public string LONG { get; set; }
        public string VERT { get; set; }
        public string ADF { get; set; }
        // I062/295 Track Data Ages #16
        public string primary16 { get; set; }
        //Subfield 1
        public string MFL295 { get; set; }
        //Subfield 2
        public string MD1295 { get; set; }
        //Subfield 3
        public string MD2295 { get; set; }
        //Subfield 4
        public string MDA295 { get; set; }
        //Subfield 5
        public string MD4295 { get; set; }
        //Subfield 6
        public string MD5295 { get; set; }
        //Subfield 7
        public string MHG295 { get; set; }
        //Subfield 8
        public string IAS295 { get; set; }
        //Subfield 9
        public string TAS295 { get; set; }
        //Subfield 10
        public string SAL295 { get; set; }
        //Subfield 11
        public string FSS295 { get; set; }
        //Subfield 12
        public string TID295 { get; set; }
        //Subfield 13
        public string COM295 { get; set; }
        //Subfield 14
        public string SAB295 { get; set; }
        //Subfield 15
        public string ACS295 { get; set; }
        //Subfield 16
        public string BVR295 { get; set; }
        //Subfield 17
        public string GVR295 { get; set; }
        //Subfield 18
        public string RAN295 { get; set; }
        //Subfield 19
        public string TAR295 { get; set; }
        //Subfield 20
        public string TAN295 { get; set; }
        //Subfield 21
        public string GSP295 { get; set; }
        //Subfield 22
        public string VUN295 { get; set; }
        //Subfield 23
        public string MET295 { get; set; }
        //Subfield 24
        public string EMC295 { get; set; }
        //Subfield 25
        public string POS295 { get; set; }
        //Subfield 26
        public string GAL295 { get; set; }
        //Subfield 27
        public string PUN295 { get; set; }
        //Subfield 28
        public string MB295 { get; set; }
        //Subfield 29
        public string IAR295 { get; set; }
        //Subfield 30
        public string MAC295 { get; set; }
        //Subfield 31
        public string BPS295 { get; set; }



        // I062/136 Measured Flight Level #17
        public string MFL { get; set; } //MeasuredFlighLevel (100ft=FL)

        // I062/130 Calculated Track Geometric Altitude #18
        public string GeomAlt { get; set; } //Calculated Track Geometric Altitude (ft)
        // I062/135 Calculated Track Barometric Altitude #19
        public string QNH { get; set; } //QNH correction applied
        public string BaromAlt { get; set; } //Calculated Track Barometric Altitude (100ft=FL)
        // I062/220 Calculated Rate Of Climb/Descent #20
        public string RateClimb { get; set; } //Calculated rate of Climb/Descent (6.25ft/min)    
        // I062/390 Flight Plan Related Data #21
        public string primary21 { get; set; }
        // Subfield 1
        public string FPPSSIC { get; set; }
        public string FPPSSAC { get; set; }
        // Subfield 2
        public string Callsign { get; set; }
        // Subfield 3
        public string IFPS_TYP { get; set; }
        public string NBR { get; set; }
        // Subfield 4
        public string GAT_OAT { get; set; }
        public string FR1FR2 { get; set; }
        public string RVSM { get; set; }
        public string HPR { get; set; }
        // Subfield 5
        public string TypeOfAircraft { get; set; }
        // Subfield 6
        public string WakeTurbulenceCAT { get; set; }
        // Subfield 7
        public string DepartureAirport { get; set; }
        // Subfield 8
        public string DestinationAirport { get; set; }
        // Subfield 9
        public string RunwayDesignation { get; set; }
        // Subfield 10
        public string CFL { get; set; }
        // Subfield 11
        public string Centre { get; set; }
        public string Position { get; set; }
        // Subfield 12
        public string REP290 { get; set; }
        public string TOD_TYP { get; set; }
        public string DAY { get; set; }
        public string HOR { get; set; }
        public string MIN { get; set; }
        public string AVS { get; set; }
        public string SEC { get; set; }
        // Subfield 13
        public string AircraftStand { get; set; }
        // Subfield 14
        public string EMP { get; set; }
        public string AVL { get; set; }
        // Subfield 15
        public string StandardInstrumentDeparture { get; set; }
        // Subfield 16
        public string StandardInstrumentArrival { get; set; }
        // Subfield 17
        public string VA { get; set; }
        public string Mode3ARep { get; set; }
        // Subfield 18
        public string PreEmergencyCallsign { get; set; }
        //FRN22
        public string LEN22 { get; set; }
        // I062/300 Vehicle Fleet Identification #23
        public string VFI { get; set; }
        //FRN24
        public string LEN24 { get; set; }
        // I062/120 Track Mode 2 Code #25
        public string TrackMode2Code { get; set; }
        // I062/510 Composed Track Number #26
        public string SystemUnitID { get; set; }
        public string SystemTrackNumber { get; set; }
        //FRN27
        public string LEN27 { get; set; }
        // I062/340 Measured Information #28
        public string primary28 { get; set; }
        // Subfield 1
        public string SACSI { get; set; } // System Area Code 
        public string SICSI { get; set; } // System Identification Code
                                          // Subfield 2
        public string RHO { get; set; } // Measured distance [NM]
        public string THETA { get; set; } // Measured azimuth [°]
                                          // Subfield 3
        public string HEI { get; set; } // Measured 3-D Height [feet]
                                        // Subfield 4
        public string V { get; set; } // Validation
        public string G { get; set; } // Default or garbled
        public string MDC { get; set; } // Last Measured Mode C Code [FL]
                                        // Subfield 5
        public string V2 { get; set; } // Validation
        public string G2 { get; set; } // Garbled
        public string L { get; set; } // Default or garbled
        public string MDA { get; set; } // Last Measured Mode 3/A Code
                                        // Subfield 6
        public string TYP { get; set; } // Report type
        public string SIMrep { get; set; } // Actual or simulated target report
        public string RAB { get; set; } // Report from target or field monitor
        public string TST { get; set; } // Real or test target report

        //RE (FRN34)
        public string LENRE { get; set; }
        public string CSTRE { get; set; }
        public string CSN { get; set; }
        public string TVS { get; set; }
        public string STS { get; set; }
        public string primary34 { get; set; }
        // Subfield 1 (CST)
        public string REPW { get; set; }//Repetition Factor
        public string SACW { get; set; }//SAC
        public string SICW { get; set; }//SIC
        public string TYPW { get; set; }
        public string LTNW { get; set; } //LocalTrackNumber
                                         // Subfield 2 (CSN)
        public string REPNO { get; set; }//Repetition Factor
        public string SACNO { get; set; }//SAC
        public string SICNO { get; set; }//SIC
        public string TYPNO { get; set; }
        // Subfield 3 (TVS)
        public string VxRE { get; set; } //m/s
        public string VyRE { get; set; } //m/s
                                         // Subfield 4 (STS)
        public string FDR { get; set; }
        //FRN35
        public string LEN35 { get; set; }


        // METHODS
        public string getDecimal(string Bits)
        {
            string dec = Convert.ToString(Convert.ToInt32(Bits, 2));
            return dec;
        }

        public static string findTwoscomplement(StringBuilder str)
        {
            int n = str.Length;

            // Traverse the string to get
            // first '1' from the last of string
            int i;
            for (i = n - 1; i >= 0; i--)
            {
                if (str[i] == '1')
                {
                    break;
                }
            }

            // If there exists no '1' concat 1
            // at the starting of string
            if (i == -1)
            {
                return "1" + str;
            }

            // Continue traversal after the
            // position of first '1'
            for (int k = i - 1; k >= 0; k--)
            {
                // Just flip the values
                if (str[k] == '1')
                {
                    str.Remove(k, k + 1 - k).Insert(k, "0");
                }
                else
                {
                    str.Remove(k, k + 1 - k).Insert(k, "1");
                }
            }

            // return the modified string
            return str.ToString();
        }

        public static string findTwoscomplement2(string strStr)
        {
            if (strStr[0].ToString() == "1")
            {
                StringBuilder str = new StringBuilder(strStr);
                int n = str.Length;

                // Traverse the string to get
                // first '1' from the last of string
                int i;
                for (i = n - 1; i >= 0; i--)
                {
                    if (str[i] == '1')
                    {
                        break;
                    }
                }

                // If there exists no '1' concat 1
                // at the starting of string
                if (i == -1)
                {
                    return "1" + str;
                }

                // Continue traversal after the
                // position of first '1'
                for (int k = i - 1; k >= 0; k--)
                {
                    // Just flip the values
                    if (str[k] == '1')
                    {
                        str.Remove(k, k + 1 - k).Insert(k, "0");
                    }
                    else
                    {
                        str.Remove(k, k + 1 - k).Insert(k, "1");
                    }
                }

                // return the modified string
                return str.ToString();
            }
            else
            {
                string str = strStr;
                return str;
            }

        }

        public int getVariableSize(string stringData)
        {
            int size = 8;
            bool addOctet = true;
            int FX = 7;
            while (addOctet)
            {
                if (stringData[FX].ToString() == "1")
                {
                    size += 8;
                    FX += 8;
                }
                else
                {
                    addOctet = false;
                }
            }
            return size;
        }

        public int getVariableSizeThreeOctets(string stringData)
        {
            int size = 3 * 8;
            bool addOctet = true;
            int FX = (3 * 8) - 1;
            while (addOctet)
            {
                if (stringData[FX].ToString() == "1")
                {
                    size += 3 * 8;
                    FX += (3 * 8);
                }
                else
                {
                    addOctet = false;
                }
            }
            return size;
        }

        public int getVariableSizeMaxSize(string stringData, int maxOctets)
        {
            int maxBits = maxOctets * 8;
            int size = 8;
            bool addOctet = true;
            int FX = 7;
            while (addOctet)
            {
                if (stringData[FX].ToString() == "1")
                {
                    if (size == maxBits)
                    {
                        addOctet = false;
                    }
                    else
                    {
                        size += 8;
                        FX += 8;
                    }

                }
                else
                {
                    addOctet = false;
                }
            }
            return size;
        }

        public string getTargetIdentificationCharacter(string str6Bits)
        {
            // Rows in columns: 16
            string col1 = " ABCDEFGHIJKLMNO";
            string col2 = "PQRSTUVWXYZ     ";


            string character;

            // FIRST COLUM
            if (str6Bits.Substring(0, 2) == "00")
            {
                if (str6Bits[2..] == "0000")
                {
                    character = "";
                    //character = col1[0].ToString();
                }
                else if (str6Bits[2..] == "0001")
                {
                    character = col1[1].ToString();
                }
                else if (str6Bits[2..] == "0010")
                {
                    character = col1[2].ToString();
                }
                else if (str6Bits[2..] == "0011")
                {
                    character = col1[3].ToString();
                }
                else if (str6Bits[2..] == "0100")
                {
                    character = col1[4].ToString();
                }
                else if (str6Bits[2..] == "0101")
                {
                    character = col1[5].ToString();
                }
                else if (str6Bits[2..] == "0110")
                {
                    character = col1[6].ToString();
                }
                else if (str6Bits[2..] == "0111")
                {
                    character = col1[7].ToString();
                }
                else if (str6Bits[2..] == "1000")
                {
                    character = col1[8].ToString();
                }
                else if (str6Bits[2..] == "1001")
                {
                    character = col1[9].ToString();
                }
                else if (str6Bits[2..] == "1010")
                {
                    character = col1[10].ToString();
                }
                else if (str6Bits[2..] == "1011")
                {
                    character = col1[11].ToString();
                }
                else if (str6Bits[2..] == "1100")
                {
                    character = col1[12].ToString();
                }
                else if (str6Bits[2..] == "1101")
                {
                    character = col1[13].ToString();
                }
                else if (str6Bits[2..] == "1110")
                {
                    character = col1[14].ToString();
                }
                else if (str6Bits[2..] == "1111")
                {
                    character = col1[15].ToString();
                }
                else
                {
                    character = "ErrorCol1";
                }
            }

            // SECOND COLUM
            else if (str6Bits.Substring(0, 2) == "01")
            {
                if (str6Bits[2..] == "0000")
                {
                    character = col2[0].ToString();
                }
                else if (str6Bits[2..] == "0001")
                {
                    character = col2[1].ToString();
                }
                else if (str6Bits[2..] == "0010")
                {
                    character = col2[2].ToString();
                }
                else if (str6Bits[2..] == "0011")
                {
                    character = col2[3].ToString();
                }
                else if (str6Bits[2..] == "0100")
                {
                    character = col2[4].ToString();
                }
                else if (str6Bits[2..] == "0101")
                {
                    character = col2[5].ToString();
                }
                else if (str6Bits[2..] == "0110")
                {
                    character = col2[6].ToString();
                }
                else if (str6Bits[2..] == "0111")
                {
                    character = col2[7].ToString();
                }
                else if (str6Bits[2..] == "1000")
                {
                    character = col2[8].ToString();
                }
                else if (str6Bits[2..] == "1001")
                {
                    character = col2[9].ToString();
                }
                else if (str6Bits[2..] == "1010")
                {
                    character = col2[10].ToString();
                }
                else if (str6Bits[2..] == "1011")
                {
                    character = "";
                    //character = col2[11].ToString();
                }
                else if (str6Bits[2..] == "1100")
                {
                    character = "";
                    //character = col2[12].ToString();
                }
                else if (str6Bits[2..] == "1101")
                {
                    character = "";
                    //character = col2[13].ToString();
                }
                else if (str6Bits[2..] == "1110")
                {
                    character = "";
                    //character = col2[14].ToString();
                }
                else if (str6Bits[2..] == "1111")
                {
                    character = "";
                    //character = col2[15].ToString();
                }
                else
                {
                    character = "ErrorCol2";
                }
            }
            // THIRD COLUM
            else if (str6Bits.Substring(0, 2) == "10")
            {
                character = "";
            }

            // FOURTH COLUM
            else if (str6Bits.Substring(0, 2) == "11")
            {
                character = getDecimal(str6Bits[2..]);
            }

            else
            {
                character = "ErrorFirst2Bits";
            }

            return character;
        }

        public string GetBytesFromBinaryString(string binary)
        {
            var list = new List<Byte>();

            for (int i = 0; i < binary.Length; i += 8)
            {
                String t = binary.Substring(i, 8);

                list.Add(Convert.ToByte(t, 2));
            }

            return Encoding.ASCII.GetString(list.ToArray());
        }
        public string TwoCToString(string binary)
        {
            string res;
            StringBuilder str = new StringBuilder(binary);
            if (str[0].ToString() == "0")
            {
                res = Convert.ToString(Convert.ToInt32(str.ToString(), 2));
            }
            else
            {
                for (int i = 0; i < binary.Length; i++)
                {
                    if (str[i].ToString() == "1")
                    {
                        str.Remove(i, 1).Insert(i, "0");
                    }
                    else
                    {
                        str.Remove(i, 1).Insert(i, "1");
                    }
                }

                int j = binary.Length - 1;
                bool Flag = true;
                while ((j >= 0) && (Flag == true))
                {
                    if (str[j].ToString() == "1")
                    {
                        str.Remove(j, 1).Insert(j, "0");
                    }
                    else
                    {
                        str.Remove(j, 1).Insert(j, "1");
                        Flag = false;
                    }
                    j--;
                }

                res = Convert.ToString(-Convert.ToInt32(str.ToString(), 2));
            }
            return res;
        }



        // CONSTRUCTOR
        public DataItem(string data, List<int> FRNs)
        {
            this.TargetID = "";
            this.ID = "";
            this.Callsign = "";
            this.TrackNumber = "";
            this.DestinationAirport = "";
            this.DepartureAirport = "";
            this.LatWGS84 = "";
            this.LonWGS84 = "";
            this.LatWGS84str = "";
            this.LonWGS84str = "";
            this.ADR = "";
            this.Mode3AReply = "";
            this.MFL = "";
            this.MHG = "";

            if ((data == "") && (FRNs.Count == 0))
            {

            }
            else
            {
                int octet = 8;
                int count = 0;
                int size;

                foreach (int FRN in FRNs)
                {
                    if (FRN == 1)
                    {
                        size = 2 * octet;
                        this.SAC = data.Substring(count, octet);
                        this.SIC = data.Substring(count + octet, octet);

                        count += size;
                    }

                    else if (FRN == 2)
                    {
                        // No info
                    }

                    else if (FRN == 3)
                    {
                        size = 1 * octet;
                        this.ServiceID = getDecimal(data.Substring(count, octet));

                        count += size;
                    }

                    else if (FRN == 4)
                    {
                        size = 3 * octet;
                        // Get time
                        string seconds = getDecimal(data.Substring(count, size));
                        this.TimeSeconds = Convert.ToDouble(seconds) / 128;
                        TimeSpan time = TimeSpan.FromSeconds(Convert.ToDouble(seconds) / 128);
                        string timeOfTrack = time.ToString(@"hh\:mm\:ss\.fff");
                        this.TimeOfTrackInfo = timeOfTrack;

                        count += size;
                    }

                    else if (FRN == 5)
                    {
                        size = 8 * octet;
                        this.LatWGS84 = (Convert.ToDouble(TwoCToString(data.Substring(count, 4 * octet))) * (0.00000536441802978515625)).ToString();
                        this.LonWGS84 = (Convert.ToDouble(TwoCToString(data.Substring(count + 4 * octet, 4 * octet))) * (0.00000536441802978515625)).ToString();
                        this.LatWGS84str = LatWGS84.Substring(0, 7);
                        this.LonWGS84str = LonWGS84.Substring(0, 7);
                        count += size;
                    }

                    else if (FRN == 6)
                    {
                        size = 6 * octet;
                        this.X = (Convert.ToDouble(TwoCToString(data.Substring(count, 3 * octet))) * 0.5).ToString();
                        this.Y = (Convert.ToDouble(TwoCToString(data.Substring(count + 3 * octet, 3 * octet))) * 0.5).ToString();

                        count += size;
                    }

                    else if (FRN == 7)
                    {
                        size = 4 * octet;
                        this.Vx = (Convert.ToDouble(TwoCToString(data.Substring(count, 2 * octet))) * 0.25).ToString();
                        this.Vy = (Convert.ToDouble(TwoCToString(data.Substring(count + 2 * octet, 2 * octet))) * 0.25).ToString();

                        count += size;
                    }

                    else if (FRN == 8)
                    {
                        size = 2 * octet;
                        this.Ax = (Convert.ToDouble(TwoCToString(data.Substring(count, octet))) * 0.25).ToString();
                        this.Ay = (Convert.ToDouble(TwoCToString(data.Substring(count + octet, octet))) * 0.25).ToString();

                        count += size;
                    }

                    else if (FRN == 9)
                    {
                        size = 2 * octet;
                        int sizeNums = 3;
                        string validated = data.Substring(count, 1);
                        string garbled = data.Substring(count + 1, 1);
                        string change = data.Substring(count + 2, 1);
                        string spareBit = data.Substring(count + 3, 1);
                        string firstNum = getDecimal(data.Substring(count + 4, sizeNums));
                        string secondNum = getDecimal(data.Substring(count + 4 + sizeNums, sizeNums));
                        string thirdNum = getDecimal(data.Substring(count + 4 + 2 * sizeNums, sizeNums));
                        string fourthNum = getDecimal(data.Substring(count + 4 + 3 * sizeNums, sizeNums));

                        if (validated == "1")
                        {
                            this.Validated = "1 Code not validated";
                        }
                        else
                        {
                            this.Validated = "0 Code validated";
                        }

                        if (garbled == "1")
                        {
                            this.Garbled = "1 Garbled Code";
                        }
                        else
                        {
                            this.Garbled = "0 Default";
                        }

                        if (change == "1")
                        {
                            this.ChangeInMode = "1 Mode 3/A has changed";
                        }
                        else
                        {
                            this.ChangeInMode = "0 No Change";
                        }

                        this.Mode3AReply = firstNum + secondNum + thirdNum + fourthNum;

                        count += size;
                    }

                    else if (FRN == 10)
                    {
                        size = 7 * octet;
                        int sizeChars = 6;
                        string STI = data.Substring(count, 2);

                        string char1 = getTargetIdentificationCharacter(data.Substring(count + octet, sizeChars));
                        string char2 = getTargetIdentificationCharacter(data.Substring(count + octet + sizeChars, sizeChars));
                        string char3 = getTargetIdentificationCharacter(data.Substring(count + octet + 2 * sizeChars, sizeChars));
                        string char4 = getTargetIdentificationCharacter(data.Substring(count + octet + 3 * sizeChars, sizeChars));
                        string char5 = getTargetIdentificationCharacter(data.Substring(count + octet + 4 * sizeChars, sizeChars));
                        string char6 = getTargetIdentificationCharacter(data.Substring(count + octet + 5 * sizeChars, sizeChars));
                        string char7 = getTargetIdentificationCharacter(data.Substring(count + octet + 6 * sizeChars, sizeChars));
                        string char8 = getTargetIdentificationCharacter(data.Substring(count + octet + 7 * sizeChars, sizeChars));

                        if (STI == "00")
                        {
                            this.STI = "00 Callsign or registration downlinked from target";
                        }
                        else if (STI == "01")
                        {
                            this.STI = "01 Callsign not downlinked from target";
                        }
                        else if (STI == "10")
                        {
                            this.STI = "10 Registration not downlinked from target";
                        }
                        else if (STI == "11")
                        {
                            this.STI = "11 Invalid";
                        }

                        this.TargetID = (char1) + (char2) + (char3) + (char4) + (char5) + char6 + char7 + char8;

                        count += size;
                    }

                    else if (FRN == 11)
                    {
                        string stringBits = data[count..];  // Gets all data from count till finish
                        int nOctL = 1;
                        while (data.Substring(count + 7 + octet * (nOctL - 1), 1) == "1")
                        {
                            nOctL += 1;
                        }
                        int lenPrimarySubfield = nOctL * octet;
                        string primarySubfield = data.Substring(count, lenPrimarySubfield);  // String uptaded to what we need
                        int countSecondarySubfield = 0;
                        int sizeSubfield;
                        int startSubstring = count + lenPrimarySubfield;
                        int numSubfield = 1;
                        this.primary11 = primarySubfield;
                        foreach (char Bit in primarySubfield)
                        {
                            if (Bit.ToString() == "1")
                            {
                                if (numSubfield == 1) // Presence of subfield 1
                                {
                                    sizeSubfield = 3 * octet;

                                    this.ADR = getDecimal(data.Substring(startSubstring, sizeSubfield));

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 2) // Presence of subfield 2
                                {
                                    sizeSubfield = 6 * octet;
                                    int sizeChars = 6;

                                    string char1 = getTargetIdentificationCharacter(data.Substring(startSubstring, sizeChars));
                                    string char2 = getTargetIdentificationCharacter(data.Substring(startSubstring + sizeChars, sizeChars));
                                    string char3 = getTargetIdentificationCharacter(data.Substring(startSubstring + 2 * sizeChars, sizeChars));
                                    string char4 = getTargetIdentificationCharacter(data.Substring(startSubstring + 3 * sizeChars, sizeChars));
                                    string char5 = getTargetIdentificationCharacter(data.Substring(startSubstring + 4 * sizeChars, sizeChars));
                                    string char6 = getTargetIdentificationCharacter(data.Substring(startSubstring + 5 * sizeChars, sizeChars));
                                    string char7 = getTargetIdentificationCharacter(data.Substring(startSubstring + 6 * sizeChars, sizeChars));
                                    string char8 = getTargetIdentificationCharacter(data.Substring(startSubstring + 7 * sizeChars, sizeChars));

                                    this.ID = (char1) + (char2) + (char3) + (char4) + (char5) + char6 + char7 + char8;

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 3) // Presence of subfield 3
                                {
                                    sizeSubfield = 2 * octet;
                                    double mhg = Convert.ToDouble(Convert.ToInt32(data.Substring(startSubstring, sizeSubfield), 2));
                                    this.MHG = (mhg * 360 / (Math.Pow(2, 16))).ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 4) // Presence of subfield 4
                                {
                                    sizeSubfield = 2 * octet;
                                    double airspeed = Convert.ToDouble(getDecimal(data.Substring(startSubstring + 1, sizeSubfield - 1)));
                                    // IAS or Mach No
                                    this.IM = data.Substring(startSubstring, 1);
                                    if (data.Substring(startSubstring, 1) == "0")
                                    {
                                        this.IAS = (airspeed * (Math.Pow(2, -14))).ToString();
                                    }
                                    else if (data.Substring(startSubstring, 1) == "1")
                                    {
                                        this.MACH = (airspeed * 0.001).ToString();
                                    }

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 5) // Presence of subfield 5
                                {
                                    sizeSubfield = 2 * octet;

                                    this.TAS = getDecimal(data.Substring(startSubstring, sizeSubfield));

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 6) // Presence of subfield 6
                                {
                                    sizeSubfield = 2 * octet;

                                    string strSelectedAltitude = data.Substring(startSubstring, sizeSubfield);

                                    // First bit
                                    if (strSelectedAltitude[0].ToString() == "0")
                                    {
                                        this.SAS = "0 No source information provided";
                                    }
                                    else if (strSelectedAltitude[0].ToString() == "1")
                                    {
                                        this.SAS = "1 Source information provided";
                                    }

                                    // 2nd and 3rd bit
                                    if (strSelectedAltitude.Substring(1, 2) == "00")
                                    {
                                        this.Source = "00 Unknown";
                                    }
                                    else if (strSelectedAltitude.Substring(1, 2) == "01")
                                    {
                                        this.Source = "01 Aircraft Altitude";
                                    }
                                    else if (strSelectedAltitude.Substring(1, 2) == "10")
                                    {
                                        this.Source = "10 FCU/MCP Selected Altitude";
                                    }
                                    else if (strSelectedAltitude.Substring(1, 2) == "11")
                                    {
                                        this.Source = "11 FMS Selected Altitude";
                                    }

                                    this.SAL = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring + 3, sizeSubfield - 3))) * 25).ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 7) // Presence of subfield 7
                                {
                                    sizeSubfield = 2 * octet;

                                    string strFinalStateSelectedAltitude = data.Substring(startSubstring, sizeSubfield);

                                    // First bit
                                    if (strFinalStateSelectedAltitude[0].ToString() == "0")
                                    {
                                        this.MV = "0 Not active";
                                    }
                                    else if (strFinalStateSelectedAltitude[0].ToString() == "1")
                                    {
                                        this.MV = "1 Active";
                                    }
                                    // Second bit
                                    if (strFinalStateSelectedAltitude[0].ToString() == "0")
                                    {
                                        this.AH = "0 Not active";
                                    }
                                    else if (strFinalStateSelectedAltitude[0].ToString() == "1")
                                    {
                                        this.AH = "1 Active";
                                    }
                                    // Third bit
                                    if (strFinalStateSelectedAltitude[0].ToString() == "0")
                                    {
                                        this.AM = "0 Not active";
                                    }
                                    else if (strFinalStateSelectedAltitude[0].ToString() == "1")
                                    {
                                        this.AM = "1 Active";
                                    }

                                    this.FSS = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring + 3, sizeSubfield - 3))) * 25).ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 9) // Presence of subfield 8
                                {
                                    int nOct = 1;
                                    while (data.Substring(startSubstring + 7 + octet * (nOct - 1), 1) == "1")
                                    {
                                        nOct += 1;
                                    }
                                    sizeSubfield = nOct * octet;
                                    string strTIS = data.Substring(startSubstring, sizeSubfield);

                                    // Available
                                    if (strTIS[0].ToString() == "0")
                                    {
                                        this.NAV = "0 Trajectory Intent Data is available for this aircraft";
                                    }
                                    else if (strTIS[0].ToString() == "1")
                                    {
                                        this.NAV = "1 Trajectory Intent Data is not available for this aircraft";
                                    }
                                    // Valid
                                    if (strTIS[1].ToString() == "0")
                                    {
                                        this.NVB = "0 Trajectory Intent Data is valid";
                                    }
                                    else if (strTIS[1].ToString() == "1")
                                    {
                                        this.NVB = "1 Trajectory Intent Data is not valid";
                                    }

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 10) // Presence of subfield 9
                                {
                                    sizeSubfield = 16 * octet;

                                    // REP
                                    this.REP = getDecimal(data.Substring(startSubstring, octet));

                                    // TCA
                                    if (data.Substring(startSubstring + octet, 1) == "0")
                                    {
                                        this.TCA = "0 TCP number available";
                                    }
                                    else if (data.Substring(startSubstring + octet, 1) == "1")
                                    {
                                        this.TCA = "1 TCP number not available";
                                    }

                                    // NC
                                    if (data.Substring(startSubstring + octet + 1, 1) == "0")
                                    {
                                        this.NC = "0 TCP compliance";
                                    }
                                    else if (data.Substring(startSubstring + octet + 1, 1) == "1")
                                    {
                                        this.NC = "1 TCP non-compliance";
                                    }

                                    // TCP Number
                                    this.TCPNumber = getDecimal(data.Substring(startSubstring + octet + 2, octet - 2));

                                    // Altitude
                                    this.Altitude = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring + 2 * octet, 2 * octet))) * 10).ToString();

                                    // Latitude
                                    this.Latitude = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring + 4 * octet, 3 * octet))) * (180 / Math.Pow(2, 23))).ToString();

                                    // Longitude
                                    this.Longitude = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring + 7 * octet, 3 * octet))) * (180 / Math.Pow(2, 23))).ToString();

                                    // Point Type
                                    string strPointType = getDecimal(data.Substring(startSubstring + 10 * octet, 4));
                                    if (strPointType == "0")
                                    {
                                        this.PointType = "0000 Unknown";
                                    }
                                    else if (strPointType == "1")
                                    {
                                        this.PointType = "0001 Fly by waypoint (LT)";
                                    }
                                    else if (strPointType == "2")
                                    {
                                        this.PointType = "0010 Fly over waypoint (LT)";
                                    }
                                    else if (strPointType == "3")
                                    {
                                        this.PointType = "0011 Hold pattern (LT)";
                                    }
                                    else if (strPointType == "4")
                                    {
                                        this.PointType = "0100 Procedure hold (LT)";
                                    }
                                    else if (strPointType == "5")
                                    {
                                        this.PointType = "0101 Procedure turn (LT)";
                                    }
                                    else if (strPointType == "6")
                                    {
                                        this.PointType = "0110 RF leg (LT)";
                                    }
                                    else if (strPointType == "7")
                                    {
                                        this.PointType = "0111 Top of climb (VT)";
                                    }
                                    else if (strPointType == "8")
                                    {
                                        this.PointType = "1000 Top of descent (VT)";
                                    }
                                    else if (strPointType == "9")
                                    {
                                        this.PointType = "1001 Start of level (VT)";
                                    }
                                    else if (strPointType == "10")
                                    {
                                        this.PointType = "1010 Cross-over altitude (VT)";
                                    }
                                    else if (strPointType == "11")
                                    {
                                        this.PointType = "1011 Transition altitude (VT)";
                                    }

                                    // TD
                                    string strTD = data.Substring(startSubstring + (10 * octet) + 4, 2);
                                    if (strTD == "00")
                                    {
                                        this.TD = "00 N/A";
                                    }
                                    else if (strTD == "01")
                                    {
                                        this.TD = "01 Turn ight";
                                    }
                                    else if (strTD == "10")
                                    {
                                        this.TD = "10 Turn left";
                                    }
                                    else if (strTD == "11")
                                    {
                                        this.TD = "11 No turn";
                                    }

                                    // TRA
                                    string strTRA = data.Substring(startSubstring + (10 * octet) + 6, 1);
                                    if (strTRA == "0")
                                    {
                                        this.TRA = "0 TTR not available";
                                    }
                                    else if (strTRA == "1")
                                    {
                                        this.TRA = "1 TTR available";
                                    }

                                    // TOA
                                    string strTOA = data.Substring(startSubstring + (10 * octet) + 7, 1);
                                    if (strTOA == "0")
                                    {
                                        this.TOA = "0 TOV available";
                                    }
                                    else if (strTOA == "1")
                                    {
                                        this.TOA = "1 TOV not available";
                                    }

                                    // TOV
                                    this.TOV = getDecimal(data.Substring(startSubstring + 11 * octet, 3 * octet));

                                    // TTR
                                    this.TTR = ((Convert.ToInt32(getDecimal(data.Substring(startSubstring + 14 * octet, 2 * octet)))) * 0.01).ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 11) // Presence of subfield 10
                                {
                                    sizeSubfield = 2 * octet;

                                    string strCOM = data.Substring(startSubstring, sizeSubfield);

                                    // Communications capability of the transponder
                                    if (getDecimal(strCOM.Substring(0, 3)) == "0")
                                    {
                                        this.COM = "000 No communications capability (surveillance only)";
                                    }
                                    else if (getDecimal(strCOM.Substring(0, 3)) == "1")
                                    {
                                        this.COM = "001 Comm. A and Comm. B capability";
                                    }
                                    else if (getDecimal(strCOM.Substring(0, 3)) == "2")
                                    {
                                        this.COM = "010 Comm. A, Comm. B and Uplink ELM";
                                    }
                                    else if (getDecimal(strCOM.Substring(0, 3)) == "3")
                                    {
                                        this.COM = "011 Comm. A, Comm. B, Uplink ELM and Downlink ELM";
                                    }
                                    else if (getDecimal(strCOM.Substring(0, 3)) == "4")
                                    {
                                        this.COM = "100 Level 5 Transponder capability";
                                    }

                                    // Flight Status
                                    if (getDecimal(strCOM.Substring(3, 3)) == "0")
                                    {
                                        this.STAT = "000 No alert, no SPI, aircraft airborne";
                                    }
                                    else if (getDecimal(strCOM.Substring(3, 3)) == "1")
                                    {
                                        this.STAT = "001 No alert, no SPI, aircraft on ground";
                                    }
                                    else if (getDecimal(strCOM.Substring(3, 3)) == "2")
                                    {
                                        this.STAT = "010 Alert, no SPI, aircraft airborne";
                                    }
                                    else if (getDecimal(strCOM.Substring(3, 3)) == "3")
                                    {
                                        this.STAT = "011 Alert, no SPI, aircraft on ground";
                                    }
                                    else if (getDecimal(strCOM.Substring(3, 3)) == "4")
                                    {
                                        this.STAT = "100 Alert, SPI, aircraft airborne or on ground";
                                    }
                                    else if (getDecimal(strCOM.Substring(3, 3)) == "5")
                                    {
                                        this.STAT = "101 No alert, SPI, aircraft airborne or on ground";
                                    }
                                    else if (getDecimal(strCOM.Substring(3, 3)) == "6")
                                    {
                                        this.STAT = "110 Not defined";
                                    }
                                    else if (getDecimal(strCOM.Substring(3, 3)) == "7")
                                    {
                                        this.STAT = "111 Unknown or not yet extracted";
                                    }


                                    // SSC - Specific service capability
                                    if (strCOM[8].ToString() == "0")
                                    {
                                        this.SSC = "0 No";
                                    }
                                    else if (strCOM[8].ToString() == "1")
                                    {
                                        this.SSC = "1 Yes";
                                    }

                                    // ARC - Altitude reporting capability
                                    if (strCOM[9].ToString() == "0")
                                    {
                                        this.ARC = "(0) 100 ft resolution";
                                    }
                                    else if (strCOM[8].ToString() == "1")
                                    {
                                        this.ARC = "(1) 25 ft resolution";
                                    }

                                    // AIC - Aircraft identification capability
                                    if (strCOM[10].ToString() == "0")
                                    {
                                        this.AIC = "0 No";
                                    }
                                    else if (strCOM[10].ToString() == "1")
                                    {
                                        this.AIC = "1 Yes";
                                    }

                                    // B1A
                                    this.B1A = strCOM[11].ToString();

                                    // B1B
                                    this.B1B = getDecimal(strCOM[12..]);


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 12) // Presence of subfield 11
                                {
                                    sizeSubfield = 2 * octet;

                                    string strADS = data.Substring(startSubstring, sizeSubfield);

                                    // AC
                                    if (strADS.Substring(0, 2) == "00")
                                    {
                                        this.AC = "00 unknown";
                                    }
                                    else if (strADS.Substring(0, 2) == "01")
                                    {
                                        this.AC = "01 ACAS not operational";
                                    }
                                    else if (strADS.Substring(0, 2) == "10")
                                    {
                                        this.AC = "10 ACAS operational";
                                    }
                                    else if (strADS.Substring(0, 2) == "11")
                                    {
                                        this.AC = "11 invalid";
                                    }

                                    // MN
                                    if (strADS.Substring(2, 2) == "00")
                                    {
                                        this.MN = "00 unknown";
                                    }
                                    else if (strADS.Substring(2, 2) == "01")
                                    {
                                        this.MN = "01 Multiple navigational aids not operating";
                                    }
                                    else if (strADS.Substring(2, 2) == "10")
                                    {
                                        this.MN = "10 Multiple navigational aids operating";
                                    }
                                    else if (strADS.Substring(2, 2) == "11")
                                    {
                                        this.MN = "11 invalid";
                                    }

                                    // DC
                                    if (strADS.Substring(4, 2) == "00")
                                    {
                                        this.DC = "00 unknown";
                                    }
                                    else if (strADS.Substring(4, 2) == "01")
                                    {
                                        this.DC = "01 Differential correction";
                                    }
                                    else if (strADS.Substring(4, 2) == "10")
                                    {
                                        this.DC = "10 No differential correction";
                                    }
                                    else if (strADS.Substring(4, 2) == "11")
                                    {
                                        this.DC = "11 invalid";
                                    }

                                    // GBS
                                    if (strADS.Substring(6, 1) == "0")
                                    {
                                        this.GBS = "0 Transponder Ground Bit not set or unknown";
                                    }
                                    else if (strADS.Substring(6, 2) == "1")
                                    {
                                        this.GBS = "1 Transponder Ground Bit set";
                                    }

                                    // STAT
                                    if (getDecimal(strADS.Substring(13, 3)) == "0")
                                    {
                                        this.SAB = "000 No emergency";
                                    }
                                    else if (getDecimal(strADS.Substring(13, 3)) == "1")
                                    {
                                        this.SAB = "001 General emergency";
                                    }
                                    else if (getDecimal(strADS.Substring(13, 3)) == "2")
                                    {
                                        this.SAB = "010Lifeguard / medical";
                                    }
                                    else if (getDecimal(strADS.Substring(13, 3)) == "3")
                                    {
                                        this.SAB = "011 Minimum fuel";
                                    }
                                    else if (getDecimal(strADS.Substring(13, 3)) == "4")
                                    {
                                        this.SAB = "100 No communications";
                                    }
                                    else if (getDecimal(strADS.Substring(13, 3)) == "5")
                                    {
                                        this.SAB = "101 Unlawful interference";
                                    }
                                    else if (getDecimal(strADS.Substring(13, 3)) == "6")
                                    {
                                        this.SAB = "110 'Downed' Aircraft";
                                    }
                                    else if (getDecimal(strADS.Substring(13, 3)) == "7")
                                    {
                                        this.SAB = "111 Unknown";
                                    }

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 13) // Presence of subfield 12
                                {
                                    sizeSubfield = 7 * octet;

                                    // Se salta

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 14) // Presence of subfield 13
                                {
                                    sizeSubfield = 2 * octet;
                                    this.BVR = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring, 2 * octet))) * 6.25).ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 15) // Presence of subfield 14
                                {
                                    sizeSubfield = 2 * octet;

                                    this.GVR = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring, sizeSubfield))) * 6.25).ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 17) // Presence of subfield 15
                                {
                                    sizeSubfield = 2 * octet;

                                    this.RAN = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring, 2 * octet))) * 0.01).ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;

                                }
                                else if (numSubfield == 18) // Presence of subfield 16
                                {
                                    sizeSubfield = 2 * octet;

                                    string strTAR = data.Substring(startSubstring, 2 * octet);

                                    // TI
                                    if (strTAR.Substring(0, 2) == "00")
                                    {
                                        this.TI = "00 Not available";
                                    }
                                    else if (strTAR.Substring(0, 2) == "01")
                                    {
                                        this.TI = "01 Left";
                                    }
                                    else if (strTAR.Substring(0, 2) == "10")
                                    {
                                        this.TI = "10 Right";
                                    }
                                    else if (strTAR.Substring(0, 2) == "11")
                                    {
                                        this.TI = "11 Straight";
                                    }

                                    // TAR
                                    this.TAR = (Convert.ToDouble(TwoCToString(strTAR.Substring(8, 7))) * 0.25).ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 19) // Presence of subfield 17
                                {
                                    sizeSubfield = 2 * octet;

                                    this.TAN = ((Convert.ToInt32(getDecimal(data.Substring(startSubstring, sizeSubfield)))) * (360 / (Math.Pow(2, 16)))).ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 20) // Presence of subfield 18
                                {
                                    sizeSubfield = 2 * octet;

                                    this.GSP = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring, sizeSubfield))) * (Math.Pow(2, -14))).ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 21) // Presence of subfield 19
                                {
                                    sizeSubfield = 1 * octet;

                                    this.VUN = getDecimal(data.Substring(startSubstring, sizeSubfield));

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 22) // Presence of subfield 20
                                {
                                    sizeSubfield = 8 * octet;

                                    string strMET = data.Substring(startSubstring, sizeSubfield);

                                    // Validity of Wind Speed
                                    if (strMET.Substring(0, 1) == "0")
                                    {
                                        this.WS = "0 Not valid Wind Speed";
                                    }
                                    else if (strMET.Substring(0, 1) == "1")
                                    {
                                        this.WS = "1 Valid Wind Speed";
                                    }

                                    // Validity of wind direction
                                    if (strMET.Substring(1, 1) == "0")
                                    {
                                        this.WD = "0 Not valid Wind Direction";
                                    }
                                    else if (strMET.Substring(1, 1) == "1")
                                    {
                                        this.WD = "1 Valid Wind Direction";
                                    }

                                    // Validity of temperature
                                    if (strMET.Substring(2, 1) == "0")
                                    {
                                        this.TMP = "0 Not valid Temperature";
                                    }
                                    else if (strMET.Substring(2, 1) == "1")
                                    {
                                        this.TMP = "1 Valid Temperature";
                                    }

                                    // Validity of turbulence
                                    if (strMET.Substring(3, 1) == "0")
                                    {
                                        this.TRB = "0 Not valid Turbulence";
                                    }
                                    else if (strMET.Substring(3, 1) == "1")
                                    {
                                        this.TRB = "1 Valid Turbulence";
                                    }

                                    // Wind speed
                                    this.WindSpeed = getDecimal(strMET.Substring(octet, 2 * octet));

                                    // Wind direction
                                    this.WindDirection = getDecimal(strMET.Substring(3 * octet, 2 * octet));

                                    // Temperature
                                    this.Temperature = ((Convert.ToInt32(getDecimal(strMET.Substring(5 * octet, 2 * octet)))) * 0.25).ToString();

                                    // Turbulence
                                    this.Turbulence = getDecimal(strMET.Substring(7 * octet, octet));

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 23) // Presence of subfield 21
                                {
                                    sizeSubfield = 1 * octet;

                                    string strEMC = getDecimal(data.Substring(startSubstring, sizeSubfield));

                                    if (strEMC == "1")
                                    {
                                        this.EMC = "light aircraft ≤ 7000 kg";
                                    }
                                    else if (strEMC == "2")
                                    {
                                        this.EMC = "reserved";
                                    }
                                    else if (strEMC == "3")
                                    {
                                        this.EMC = "7000 kg < medium aircraft < 136000 kg";
                                    }
                                    else if (strEMC == "4")
                                    {
                                        this.EMC = "reserved";
                                    }
                                    else if (strEMC == "5")
                                    {
                                        this.EMC = "136000 kg ≤ heavy aircraft";
                                    }
                                    else if (strEMC == "6")
                                    {
                                        this.EMC = "highly manoeuvrable (5g acceleration capability) and high speed (>400 knots cruise)";
                                    }
                                    else if (strEMC == "7")
                                    {
                                        this.EMC = "reserved";
                                    }
                                    else if (strEMC == "8")
                                    {
                                        this.EMC = "reserved";
                                    }
                                    else if (strEMC == "9")
                                    {
                                        this.EMC = "reserved";
                                    }
                                    else if (strEMC == "10")
                                    {
                                        this.EMC = "rotocraft";
                                    }
                                    else if (strEMC == "11")
                                    {
                                        this.EMC = "glider / sailplane";
                                    }
                                    else if (strEMC == "12")
                                    {
                                        this.EMC = "lighter-than-air";
                                    }
                                    else if (strEMC == "13")
                                    {
                                        this.EMC = "unmanned aerial vehicle";
                                    }
                                    else if (strEMC == "14")
                                    {
                                        this.EMC = "space / transatmospheric vehicle";
                                    }
                                    else if (strEMC == "15")
                                    {
                                        this.EMC = "ultralight / handglider / paraglider";
                                    }
                                    else if (strEMC == "16")
                                    {
                                        this.EMC = "parachutist / skydiver";
                                    }
                                    else if (strEMC == "17")
                                    {
                                        this.EMC = "reserved";
                                    }
                                    else if (strEMC == "18")
                                    {
                                        this.EMC = "reserved";
                                    }
                                    else if (strEMC == "19")
                                    {
                                        this.EMC = "reserved";
                                    }
                                    else if (strEMC == "20")
                                    {
                                        this.EMC = "surface emergency vehicle";
                                    }
                                    else if (strEMC == "21")
                                    {
                                        this.EMC = "surface service vehicle";
                                    }
                                    else if (strEMC == "22")
                                    {
                                        this.EMC = "fixed ground or tethered obstruction";
                                    }
                                    else if (strEMC == "23")
                                    {
                                        this.EMC = "reserved";
                                    }
                                    else if (strEMC == "24")
                                    {
                                        this.EMC = "reserved";
                                    }

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 25) // Presence of subfield 22
                                {
                                    sizeSubfield = 6 * octet;

                                    // Latitude
                                    this.POSLatWGS84 = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring, 3 * octet))) * (180 / Math.Pow(2, 23))).ToString();

                                    // Longitude
                                    this.POSLonWGS84 = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring + 3 * octet, 3 * octet))) * (180 / Math.Pow(2, 23))).ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 26) // Presence of subfield 23
                                {
                                    sizeSubfield = 2 * octet;

                                    this.GAL = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring, 2 * octet))) * 6.25).ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 27) // Presence of subfield 24
                                {
                                    sizeSubfield = 1 * octet;

                                    this.PUN = getDecimal(data.Substring(startSubstring + 4, 4));

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 28) // Presence of subfield 25 --------------------------------------------------???????????
                                {
                                    sizeSubfield = 9 * octet;

                                    this.REP25 = data.Substring(startSubstring, octet);

                                    this.MB = data.Substring(startSubstring + octet, octet * 7);

                                    this.BDS1 = data.Substring(startSubstring + 8 * octet, 4);

                                    this.BDS2 = data.Substring(startSubstring + 8 * octet + 4, 4);

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 29) // Presence of subfield 26
                                {
                                    sizeSubfield = 2 * octet;

                                    this.IAR = getDecimal(data.Substring(startSubstring, sizeSubfield));

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 30) // Presence of subfield 27
                                {
                                    sizeSubfield = 2 * octet;

                                    this.MAC = ((Convert.ToInt32(getDecimal(data.Substring(startSubstring, sizeSubfield)))) * 0.008).ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 31) // Presence of subfield 28
                                {
                                    sizeSubfield = 2 * octet;

                                    this.BPS = ((Convert.ToInt32(getDecimal(data.Substring(startSubstring + 4, 12)))) * 0.1).ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                            }

                            numSubfield++;
                        }

                        size = lenPrimarySubfield + countSecondarySubfield;
                        count += size;
                    }

                    else if (FRN == 12)
                    {
                        size = 2 * octet;
                        this.TrackNumber = getDecimal(data.Substring(count, size));

                        count += size;
                    }
                    else if (FRN == 13)
                    {
                        int nOct = 1;
                        while (data.Substring(count + 7 + octet * (nOct - 1), 1) == "1")
                        {
                            nOct += 1;
                        }

                        size = nOct * octet;
                        primary13 = data.Substring(count, size);

                        string sMON = data.Substring(count, 1);
                        if (sMON == "0") { this.MON = "0 Multisensor track"; }
                        if (sMON == "1") { this.MON = "1 Monosensor track"; }
                        string sSPI = data.Substring(count + 1, 1);
                        if (sSPI == "0") { this.SPI = "0 Default value"; }
                        if (sSPI == "1") { this.SPI = "1 SPI present in the last report received from asensor capable of decoding this data"; }
                        string sMRH = data.Substring(count + 2, 1);
                        if (sMRH == "0") { this.MRH = "0 Barometric altitude (Mode C) more reliable"; }
                        if (sMRH == "1") { this.MRH = "1 Geometric altitude more reliable"; }
                        string sSRC = data.Substring(count + 3, 3);
                        if (sSRC == "000")
                        { this.SRC = "000 No source"; }
                        else if (sSRC == "001")
                        { this.SRC = "001 GNSS"; }
                        else if (sSRC == "010")
                        { this.SRC = "010 3D radar"; }
                        else if (sSRC == "011")
                        { this.SRC = "011 Triangulation"; }
                        else if (sSRC == "100")
                        { this.SRC = "100 Height from coverage"; }
                        else if (sSRC == "101")
                        { this.SRC = "101 Speed look-up table"; }
                        else if (sSRC == "110")
                        { this.SRC = "110 Default height"; }
                        else if (sSRC == "111")
                        { this.SRC = "111 Multilateration"; }
                        string sCNF = data.Substring(count + 6, 1);
                        if (sCNF == "0") { this.CNF = "0 Confirmed track"; }
                        if (sCNF == "1") { this.CNF = "1 Tentative track"; }
                        if (nOct >= 1) //First Extent
                        {
                            string sSIM = data.Substring(count + octet, 1);
                            if (sSIM == "0") { this.SIM = "0 Actual track"; }
                            if (sSIM == "1") { this.SIM = "1 Simulated track"; }
                            string sTSE = data.Substring(count + octet + 1, 1);
                            if (sTSE == "0") { this.TSE = "0 Default value"; }
                            if (sTSE == "1") { this.TSE = "1 last message transmitted to the user for the track"; }
                            string sTSB = data.Substring(count + octet + 2, 1);
                            if (sTSB == "0") { this.TSB = "0 Default value"; }
                            if (sTSB == "1") { this.TSB = "1 first message transmitted to the user for the track"; }
                            string sFPC = data.Substring(count + octet + 3, 1);
                            if (sFPC == "0") { this.FPC = "0 Not flight-plan correlated"; }
                            if (sFPC == "1") { this.FPC = "1 Flight plan correlated"; }
                            string sAFF = data.Substring(count + octet + 4, 1);
                            if (sAFF == "0") { this.AFF = "0 Default value"; }
                            if (sAFF == "1") { this.AFF = "1 ADS-B data inconsistent with other surveillance information"; }
                            string sSTP = data.Substring(count + octet + 5, 1);
                            if (sSTP == "0") { this.STP = "0 Default value"; }
                            if (sSTP == "1") { this.STP = "1 Slave Track Promotion"; }
                            string sKOS = data.Substring(count + octet + 6, 1);
                            if (sKOS == "0") { this.KOS = "0 Complementary service used"; }
                            if (sKOS == "1") { this.KOS = "1 Background service used"; }
                        }
                        if (nOct >= 2) //Second Extent
                        {
                            string sAMA = data.Substring(count + 2 * octet, 1);
                            if (sAMA == "0") { this.AMA = "0 track not resulting from amalgamation process"; }
                            if (sAMA == "1") { this.AMA = "1 track resulting from amalgamation process"; }
                            string sMD4 = data.Substring(count + 2 * octet + 1, 2);
                            if (sMD4 == "00") { this.MD4 = "00 No Mode 4 interrogation"; }
                            else if (sMD4 == "01") { this.MD4 = "01Friendly target"; }
                            else if (sMD4 == "10") { this.MD4 = "10 Unknown target"; }
                            else if (sMD4 == "11") { this.MD4 = "11No reply"; }
                            string sME = data.Substring(count + 2 * octet + 3, 1);
                            if (sME == "0") { this.ME = "0 Default value"; }
                            if (sME == "1") { this.ME = "1 Military Emergency present in the last report received from a sensor capable of decoding this data"; }
                            string sMI = data.Substring(count + 2 * octet + 4, 1);
                            if (sMI == "0") { this.MI = "0 Default value"; }
                            if (sMI == "1") { this.MI = "1 Military Identification present in the last report received from a sensor capable of decoding this data"; }
                            string sMD5 = data.Substring(count + 2 * octet + 5, 2);
                            if (sMD5 == "00") { this.MD5 = "00 No Mode 5 interrogation"; }
                            else if (sMD5 == "01") { this.MD5 = "01 Friendly target"; }
                            else if (sMD5 == "10") { this.MD5 = "10 Unknown target"; }
                            else if (sMD5 == "11") { this.MD5 = "11 No reply"; }

                        }
                        if (nOct >= 3) //Third Extent
                        {
                            string sCST = data.Substring(count + 3 * octet, 1);
                            if (sCST == "0") { this.CST = "0 Default value"; }
                            if (sCST == "1") { this.CST = "1Age of the last received track update is higher than system dependent threshold(coasting)"; }
                            string sPSR = data.Substring(count + 3 * octet + 1, 1);
                            if (sPSR == "0") { this.PSR = "0 Default value"; }
                            if (sPSR == "1") { this.PSR = "1 Age of the last received PSR track update is higher than system dependent threshold"; }
                            string sSSR = data.Substring(count + 3 * octet + 2, 1);
                            if (sSSR == "0") { this.SSR = "0 Default value"; }
                            if (sSSR == "1") { this.SSR = "1 Age of the last received SSR track update is higher than system dependent threshold"; }
                            string sMDS = data.Substring(count + 3 * octet + 3, 1);
                            if (sMDS == "0") { this.MDS = "0 Default value"; }
                            if (sMDS == "1") { this.MDS = "1 Age of the last received Mode S track update is higher than system dependent threshold"; }
                            string sADS = data.Substring(count + 3 * octet + 4, 1);
                            if (sADS == "0") { this.ADS = "0 Default value"; }
                            if (sADS == "1") { this.ADS = "1 Age of the last received ADS-B track update is higher than system dependent threshold"; }
                            string sSUC = data.Substring(count + 3 * octet + 5, 1);
                            if (sSUC == "0") { this.SUC = "0 Default value"; }
                            if (sSUC == "1") { this.SUC = "1 Special Used Code (Mode A codes to be defined in the system to mark a track with special interest)"; }
                            string sAAC = data.Substring(count + 3 * octet + 6, 1);
                            if (sAAC == "0") { this.AAC = "0 Default value"; }
                            if (sAAC == "1") { this.AAC = "1 Assigned Mode A Code Conflict (same discrete Mode A Code assigned to another track)"; }

                        }
                        if (nOct >= 4) //Fourth Extent
                        {
                            string sSDS = data.Substring(count + 4 * octet, 2);
                            if (sSDS == "00") { this.SDS = "00 Combined"; }
                            else if (sSDS == "01") { this.SDS = "01 Co-operative only"; }
                            else if (sSDS == "10") { this.SDS = "10 Non-Cooperative only"; }
                            else if (sSDS == "11") { this.SDS = "11 Not defined"; }
                            string sEMS = data.Substring(count + 4 * octet + 2, 3);
                            if (sEMS == "000")
                            { this.EMS = "000 No emergency"; }
                            else if (sEMS == "001")
                            { this.EMS = "001 General emergency"; }
                            else if (sEMS == "010")
                            { this.EMS = "010 Lifeguard/medical"; }
                            else if (sEMS == "011")
                            { this.EMS = "011 Minimum fuel"; }
                            else if (sEMS == "100")
                            { this.EMS = "100 No communications"; }
                            else if (sEMS == "101")
                            { this.EMS = "101 Unlawful interference"; }
                            else if (sEMS == "110")
                            { this.EMS = "110 'Downed' Aircraft"; }
                            else if (sEMS == "111")
                            { this.EMS = "111 Undefined"; }
                            string sPFT = data.Substring(count + 4 * octet + 5, 1);
                            if (sPFT == "0") { this.PFT = "No indication"; }
                            if (sPFT == "1") { this.PFT = "Potential False Track Indication"; }
                            string sFPLT = data.Substring(count + 4 * octet + 6, 1);
                            if (sFPLT == "0") { this.FPLT = "Default value"; }
                            if (sFPLT == "1") { this.FPLT = "Track created / updated with FPL data"; }

                        }
                        if (nOct >= 5)    //Fifth Extent
                        {
                            string sDUPT = data.Substring(count + 5 * octet, 1);
                            if (sDUPT == "0") { this.DUPT = "0 Default Value"; }
                            if (sDUPT == "1") { this.DUPT = "1 Duplicate Mode 3/A Code"; }
                            string sDUPF = data.Substring(count + 5 * octet + 1, 1);
                            if (sDUPF == "0") { this.DUPF = "0 Default Value"; }
                            if (sDUPF == "1") { this.DUPF = "1 Duplicate Flight Plan"; }
                            string sDUPM = data.Substring(count + 5 * octet + 2, 1);
                            if (sDUPM == "0") { this.DUPM = "0 Default Value"; }
                            if (sDUPM == "1") { this.DUPM = "1 Duplicate Flight Plan due to manual correlation"; }
                            string sSFC = data.Substring(count + 5 * octet + 3, 1);
                            if (sSFC == "0") { this.SFC = "0 Default Value"; }
                            if (sSFC == "1") { this.SFC = "1 Surface target"; }
                            string sIDD = data.Substring(count + 5 * octet + 4, 1);
                            if (sIDD == "0") { this.IDD = "0 Default Value"; }
                            if (sIDD == "1") { this.IDD = "1 Duplicate Flight-ID"; }
                            string sIEC = data.Substring(count + 5 * octet + 5, 1);
                            if (sIEC == "0") { this.IEC = "0 Default Value"; }
                            if (sIEC == "1") { this.IEC = "1 Inconsistent Emergency Code"; }
                        }
                        count += size;
                    }
                    else if (FRN == 14)
                    {
                        string stringBits = data[count..];  // Gets all data from count till finish
                        int lenPrimarySubfield = getVariableSizeMaxSize(stringBits, 4);
                        string primarySubfield = data.Substring(count, lenPrimarySubfield);  // String uptaded to what we need
                        int countSecondarySubfield = 0;
                        int sizeSubfield;
                        int startSubstring = count + lenPrimarySubfield;
                        int numSubfield = 1;
                        this.primary14 = primarySubfield;
                        foreach (char Bit in primarySubfield)
                        {
                            if (Bit.ToString() == "1")
                            {
                                if (numSubfield == 1) // Presence of subfield 1
                                {
                                    sizeSubfield = 1 * octet;

                                    string sTRK = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dTRK = Convert.ToDouble(sTRK) * 0.25;
                                    this.TRK = dTRK.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 2) // Presence of subfield 2
                                {
                                    sizeSubfield = 1 * octet;

                                    string sPSR = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dPSR = Convert.ToDouble(sPSR) * 0.25;
                                    this.PSR290 = dPSR.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 3) // Presence of subfield 3
                                {
                                    sizeSubfield = 1 * octet;

                                    string sSSR = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dSSR = Convert.ToDouble(sSSR) * 0.25;
                                    this.SSR290 = dSSR.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 4) // Presence of subfield 4
                                {
                                    sizeSubfield = 1 * octet;

                                    string sMDS = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dMDS = Convert.ToDouble(sMDS) * 0.25;
                                    this.MDS290 = dMDS.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 5) // Presence of subfield 5
                                {
                                    sizeSubfield = 2 * octet;

                                    string sADS = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dADS = Convert.ToDouble(sADS) * 0.25;
                                    this.ADS290 = dADS.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 6) // Presence of subfield 6
                                {
                                    sizeSubfield = 1 * octet;

                                    string sES = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dES = Convert.ToDouble(sES) * 0.25;
                                    this.ES = dES.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 7) // Presence of subfield 7
                                {
                                    sizeSubfield = 1 * octet;

                                    string sVDL = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dVDL = Convert.ToDouble(sVDL) * 0.25;
                                    this.VDL = dVDL.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 9) // Presence of subfield 8
                                {
                                    sizeSubfield = 1 * octet;

                                    string sUAT = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dUAT = Convert.ToDouble(sUAT) * 0.25;
                                    this.UAT = dUAT.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 10) // Presence of subfield 9
                                {
                                    sizeSubfield = 1 * octet;

                                    string sLOP = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dLOP = Convert.ToDouble(sLOP) * 0.25;
                                    this.LOP = dLOP.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 11) // Presence of subfield 10
                                {
                                    sizeSubfield = 1 * octet;

                                    string sMLT = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dMLT = Convert.ToDouble(sMLT) * 0.25;
                                    this.MLT = dMLT.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                            }

                            numSubfield++;
                        }

                        size = lenPrimarySubfield + countSecondarySubfield;
                        count += size;
                    }
                    else if (FRN == 15)
                    {
                        size = 1 * octet;
                        string TRANS = data.Substring(count, 2);
                        string LONG = data.Substring(count + 2, 2);
                        string VERT = data.Substring(count + 4, 2);
                        string ADF = data.Substring(count + 6, 1);

                        if (TRANS == "00")
                        {
                            this.TRANS = "00 Constant Course";
                        }
                        else if (TRANS == "01")
                        {
                            this.TRANS = "01 Right Turn";
                        }
                        else if (TRANS == "10")
                        {
                            this.TRANS = "10 Left Turn";
                        }
                        else if (TRANS == "11")
                        {
                            this.TRANS = "11 Undetermined";
                        }
                        //////////
                        if (LONG == "00")
                        {
                            this.LONG = "00 Constant Groundspeed";
                        }
                        else if (LONG == "01")
                        {
                            this.LONG = "01 Increasing Groundspeed";
                        }
                        else if (LONG == "10")
                        {
                            this.LONG = "10 Decreasing Groundspeed";
                        }
                        else if (LONG == "11")
                        {
                            this.LONG = "11 Undetermined";
                        }
                        //////////
                        if (VERT == "00")
                        {
                            this.VERT = "00 Level";
                        }
                        else if (VERT == "01")
                        {
                            this.VERT = "01 Climb";
                        }
                        else if (VERT == "10")
                        {
                            this.VERT = "10 Descent";
                        }
                        else if (VERT == "11")
                        {
                            this.VERT = "11 Undetermined";
                        }
                        ////////////
                        if (ADF == "0")
                        {
                            this.ADF = "0 No altitude discrepancy";
                        }
                        else if (ADF == "1")
                        {
                            this.ADF = "1 Altitude discrepancy";
                        }

                        count += size;
                    }
                    else if (FRN == 16)
                    {
                        string stringBits = data[count..];  // Gets all data from count till finish
                        int nOctP = 1;
                        while (data.Substring(count + 7 + octet * (nOctP - 1), 1) == "1")
                        {
                            nOctP += 1;
                        }
                        int lenPrimarySubfield = nOctP * octet;
                        string primarySubfield = data.Substring(count, lenPrimarySubfield);  // String uptaded to what we need
                        int countSecondarySubfield = 0;
                        int sizeSubfield;
                        int startSubstring = count + lenPrimarySubfield;
                        int numSubfield = 1;
                        this.primary16 = primarySubfield;
                        foreach (char Bit in primarySubfield)
                        {
                            if (Bit.ToString() == "1")
                            {
                                if (numSubfield == 1) // Presence of subfield 1
                                {
                                    sizeSubfield = 1 * octet;

                                    string sMFL = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dMFL = Convert.ToDouble(sMFL) * 0.25;
                                    this.MFL295 = dMFL.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 2) // Presence of subfield 2
                                {
                                    sizeSubfield = 1 * octet;

                                    string sMD1 = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dMD1 = Convert.ToDouble(sMD1) * 0.25;
                                    this.MD1295 = dMD1.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 3) // Presence of subfield 3
                                {
                                    sizeSubfield = 1 * octet;

                                    string sMD2 = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dMD2 = Convert.ToDouble(sMD2) * 0.25;
                                    this.MD2295 = dMD2.ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 4) // Presence of subfield 4
                                {
                                    sizeSubfield = 1 * octet;

                                    string sMDA = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dMDA = Convert.ToDouble(sMDA) * 0.25;
                                    this.MDA295 = dMDA.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 5) // Presence of subfield 5
                                {
                                    sizeSubfield = 2 * octet;

                                    string sMD4 = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dMD4 = Convert.ToDouble(sMD4) * 0.25;
                                    this.MD4295 = dMD4.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 6) // Presence of subfield 6
                                {
                                    sizeSubfield = 1 * octet;

                                    string sMD5 = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dMD5 = Convert.ToDouble(sMD5) * 0.25;
                                    this.MD5295 = dMD5.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 7) // Presence of subfield 7
                                {
                                    sizeSubfield = 1 * octet;

                                    string sMHG = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dMHG = Convert.ToDouble(sMHG) * 0.25;
                                    this.MHG295 = dMHG.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 9) // Presence of subfield 8
                                {
                                    sizeSubfield = 1 * octet;

                                    string sIAS = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dIAS = Convert.ToDouble(sIAS) * 0.25;
                                    this.IAS295 = dIAS.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 10) // Presence of subfield 9
                                {
                                    sizeSubfield = 1 * octet;

                                    string sTAS = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dTAS = Convert.ToDouble(sTAS) * 0.25;
                                    this.TAS295 = dTAS.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 11) // Presence of subfield 10
                                {
                                    sizeSubfield = 1 * octet;

                                    string sSAL = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dSAL = Convert.ToDouble(sSAL) * 0.25;
                                    this.SAL295 = dSAL.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 12) // Presence of subfield 11
                                {
                                    sizeSubfield = 1 * octet;

                                    string sFSS = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dFSS = Convert.ToDouble(sFSS) * 0.25;
                                    this.FSS295 = dFSS.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 13) // Presence of subfield 12
                                {
                                    sizeSubfield = 1 * octet;

                                    string sTID = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dTID = Convert.ToDouble(sTID) * 0.25;
                                    this.TID295 = dTID.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 14) // Presence of subfield 13
                                {
                                    sizeSubfield = 1 * octet;

                                    string sCOM = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dCOM = Convert.ToDouble(sCOM) * 0.25;
                                    this.COM295 = dCOM.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 15) // Presence of subfield 14
                                {
                                    sizeSubfield = 1 * octet;

                                    string sSAB = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dSAB = Convert.ToDouble(sSAB) * 0.25;
                                    this.SAB295 = dSAB.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 17) // Presence of subfield 15
                                {
                                    sizeSubfield = 1 * octet;

                                    string sACS = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dACS = Convert.ToDouble(sACS) * 0.25;
                                    this.ACS295 = dACS.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 18) // Presence of subfield 16
                                {
                                    sizeSubfield = 1 * octet;

                                    string sBVR = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dBVR = Convert.ToDouble(sBVR) * 0.25;
                                    this.BVR295 = dBVR.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 19) // Presence of subfield 17
                                {
                                    sizeSubfield = 1 * octet;

                                    string sGVR = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dGVR = Convert.ToDouble(sGVR) * 0.25;
                                    this.GVR295 = dGVR.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 20) // Presence of subfield 18
                                {
                                    sizeSubfield = 1 * octet;

                                    string sRAN = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dRAN = Convert.ToDouble(sRAN) * 0.25;
                                    this.RAN295 = dRAN.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 21) // Presence of subfield 19
                                {
                                    sizeSubfield = 1 * octet;

                                    string sTAR = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dTAR = Convert.ToDouble(sTAR) * 0.25;
                                    this.TAR295 = dTAR.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 22) // Presence of subfield 20
                                {
                                    sizeSubfield = 1 * octet;

                                    string sTAN = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dTAN = Convert.ToDouble(sTAN) * 0.25;
                                    this.TAN295 = dTAN.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 23) // Presence of subfield 21
                                {
                                    sizeSubfield = 1 * octet;

                                    string sGSP = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dGSP = Convert.ToDouble(sGSP) * 0.25;
                                    this.GSP295 = dGSP.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 25) // Presence of subfield 22
                                {
                                    sizeSubfield = 1 * octet;

                                    string sVUN = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dVUN = Convert.ToDouble(sVUN) * 0.25;
                                    this.VUN295 = dVUN.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 26) // Presence of subfield 23
                                {
                                    sizeSubfield = 1 * octet;

                                    string sMET = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dMET = Convert.ToDouble(sMET) * 0.25;
                                    this.MET295 = dMET.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 27) // Presence of subfield 24
                                {
                                    sizeSubfield = 1 * octet;

                                    string sEMC = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dEMC = Convert.ToDouble(sEMC) * 0.25;
                                    this.EMC295 = dEMC.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 28) // Presence of subfield 25
                                {
                                    sizeSubfield = 1 * octet;

                                    string sPOS = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dPOS = Convert.ToDouble(sPOS) * 0.25;
                                    this.POS295 = dPOS.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 29) // Presence of subfield 26
                                {
                                    sizeSubfield = 1 * octet;

                                    string sGAL = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dGAL = Convert.ToDouble(sGAL) * 0.25;
                                    this.GAL295 = dGAL.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 30) // Presence of subfield 27
                                {
                                    sizeSubfield = 1 * octet;

                                    string sPUN = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dPUN = Convert.ToDouble(sPUN) * 0.25;
                                    this.PUN295 = dPUN.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 31) // Presence of subfield 28
                                {
                                    sizeSubfield = 1 * octet;

                                    string sMB = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dMB = Convert.ToDouble(sMB) * 0.25;
                                    this.MB295 = dMB.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 33) // Presence of subfield 29
                                {
                                    sizeSubfield = 1 * octet;

                                    string sIAR = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dIAR = Convert.ToDouble(sIAR) * 0.25;
                                    this.IAR295 = dIAR.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 34) // Presence of subfield 30
                                {
                                    sizeSubfield = 1 * octet;

                                    string sMAC = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dMAC = Convert.ToDouble(sMAC) * 0.25;
                                    this.MAC295 = dMAC.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 35) // Presence of subfield 31
                                {
                                    sizeSubfield = 1 * octet;

                                    string sBPS = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                    double dBPS = Convert.ToDouble(sBPS) * 0.25;
                                    this.BPS295 = dBPS.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                            }

                            numSubfield++;
                        }

                        size = lenPrimarySubfield + countSecondarySubfield;
                        count += size;
                    }
                    else if (FRN == 17)
                    {
                        size = 2 * octet;
                        this.MFL = (Convert.ToDouble(TwoCToString(data.Substring(count, 2 * octet))) * 0.25).ToString();
                        count += size;
                    }
                    else if (FRN == 18)
                    {
                        size = 2 * octet;
                        this.GeomAlt = (Convert.ToDouble(TwoCToString(data.Substring(count, 2 * octet))) * 6.25).ToString();
                        count += size;
                    }
                    else if (FRN == 19)
                    {
                        size = 2 * octet;
                        if (getDecimal(data.Substring(count, 1)) == "0") { this.QNH = "0 No QNH correction applied"; }
                        if (getDecimal(data.Substring(count, 1)) == "1") { this.QNH = "1 QNH correction applied"; }
                        count += 1;
                        this.BaromAlt = (Convert.ToDouble(TwoCToString(data.Substring(count, 2 * octet - 1))) * 0.25).ToString();
                        count += size - 1;
                    }
                    else if (FRN == 20)
                    {
                        size = 2 * octet;
                        this.RateClimb = (Convert.ToDouble(TwoCToString(data.Substring(count, 2 * octet))) * 6.25).ToString();
                        count += size;
                    }
                    else if (FRN == 21)
                    {
                        string stringBits = data[count..];  // Gets all data from count till finish
                        int lenPrimarySubfield = getVariableSizeMaxSize(stringBits, 3);
                        string primarySubfield = data.Substring(count, lenPrimarySubfield);  // String uptaded to what we need
                        int countSecondarySubfield = 0;
                        int sizeSubfield;
                        int startSubstring = count + lenPrimarySubfield;
                        int numSubfield = 1;
                        this.primary21 = primarySubfield;
                        foreach (char Bit in primarySubfield)
                        {
                            if (Bit.ToString() == "1")
                            {
                                if (numSubfield == 1) // Presence of subfield 1
                                {
                                    sizeSubfield = 2 * octet;

                                    this.FPPSSAC = data.Substring(startSubstring, octet);
                                    this.FPPSSIC = data.Substring(startSubstring + octet, octet);

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 2) // Presence of subfield 2
                                {
                                    sizeSubfield = 7 * octet;

                                    string strCallsign = data.Substring(startSubstring, sizeSubfield);

                                    this.Callsign = GetBytesFromBinaryString(strCallsign);

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 3) // Presence of subfield 3
                                {
                                    sizeSubfield = 4 * octet;

                                    string FPS_FLIGHT_ID = data.Substring(startSubstring, sizeSubfield);

                                    // TYP
                                    string strTYP = FPS_FLIGHT_ID.Substring(0, 2);
                                    if (strTYP == "00")
                                    {
                                        this.IFPS_TYP = "00 Plan Number";
                                    }
                                    else if (strTYP == "01")
                                    {
                                        this.IFPS_TYP = "01 Unit 1 internal flight number";
                                    }
                                    else if (strTYP == "10")
                                    {
                                        this.IFPS_TYP = "10 Unit 2 internal flight number";
                                    }
                                    else if (strTYP == "11")
                                    {
                                        this.IFPS_TYP = "11 Unit 3 internal flight number";
                                    }

                                    // NBR
                                    this.NBR = getDecimal(FPS_FLIGHT_ID[5..]);

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 4) // Presence of subfield 4
                                {
                                    sizeSubfield = 1 * octet;

                                    string strFLightCAT = data.Substring(startSubstring, sizeSubfield);

                                    // GAT/OAT
                                    if (strFLightCAT.Substring(0, 2) == "00")
                                    {
                                        this.GAT_OAT = "00 Unknown";
                                    }
                                    else if (strFLightCAT.Substring(0, 2) == "01")
                                    {
                                        this.GAT_OAT = "01 General Air Traffic";
                                    }
                                    else if (strFLightCAT.Substring(0, 2) == "10")
                                    {
                                        this.GAT_OAT = "10 Operational Air Traffic";
                                    }
                                    else if (strFLightCAT.Substring(0, 2) == "11")
                                    {
                                        this.GAT_OAT = "11 Not applicable";
                                    }

                                    // FR1/FR2
                                    if (strFLightCAT.Substring(2, 2) == "00")
                                    {
                                        this.FR1FR2 = "00 Instrument Flight Rules";
                                    }
                                    else if (strFLightCAT.Substring(2, 2) == "01")
                                    {
                                        this.FR1FR2 = "01 Visual Flight rules";
                                    }
                                    else if (strFLightCAT.Substring(2, 2) == "10")
                                    {
                                        this.FR1FR2 = "10 Not applicable";
                                    }
                                    else if (strFLightCAT.Substring(2, 2) == "11")
                                    {
                                        this.FR1FR2 = "11 Controlled Visual Flight Rules";
                                    }

                                    // RVSM
                                    if (strFLightCAT.Substring(4, 2) == "00")
                                    {
                                        this.RVSM = "00 Unknown";
                                    }
                                    else if (strFLightCAT.Substring(4, 2) == "01")
                                    {
                                        this.RVSM = "01 Approved";
                                    }
                                    else if (strFLightCAT.Substring(4, 2) == "10")
                                    {
                                        this.RVSM = "10 Exempt";
                                    }
                                    else if (strFLightCAT.Substring(4, 2) == "11")
                                    {
                                        this.RVSM = "11 Not Approved";
                                    }

                                    // HPR
                                    if (strFLightCAT.Substring(6, 1) == "0")
                                    {
                                        this.HPR = "0 Normal Priority Flight";
                                    }
                                    else if (strFLightCAT.Substring(6, 1) == "1")
                                    {
                                        this.HPR = "1 High Priority Flight";
                                    }

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 5) // Presence of subfield 5
                                {
                                    sizeSubfield = 4 * octet;

                                    string strType = data.Substring(startSubstring, sizeSubfield);
                                    this.TypeOfAircraft = GetBytesFromBinaryString(strType);

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 6) // Presence of subfield 6
                                {
                                    sizeSubfield = 1 * octet;

                                    string strWakeTurbulenceCAT = data.Substring(startSubstring, sizeSubfield);

                                    this.WakeTurbulenceCAT = GetBytesFromBinaryString(strWakeTurbulenceCAT);

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 7) // Presence of subfield 7
                                {
                                    sizeSubfield = 4 * octet;

                                    string strDepartureAirport = data.Substring(startSubstring, sizeSubfield);

                                    this.DepartureAirport = GetBytesFromBinaryString(strDepartureAirport);

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 9) // Presence of subfield 8
                                {
                                    sizeSubfield = 4 * octet;

                                    string strDestinationAirport = data.Substring(startSubstring, sizeSubfield);

                                    this.DestinationAirport = GetBytesFromBinaryString(strDestinationAirport);

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 10) // Presence of subfield 9
                                {
                                    sizeSubfield = 3 * octet;

                                    string strRunway = data.Substring(startSubstring + 2 * octet, octet);
                                    string numbers = getDecimal(data.Substring(startSubstring, octet))
                                        + getDecimal(data.Substring(startSubstring + octet, octet));
                                    this.RunwayDesignation = numbers + GetBytesFromBinaryString(strRunway);

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 11) // Presence of subfield 10
                                {
                                    sizeSubfield = 2 * octet;

                                    this.CFL = (Convert.ToDouble(getDecimal(data.Substring(startSubstring, sizeSubfield))) / 4).ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 12) // Presence of subfield 11
                                {
                                    sizeSubfield = 2 * octet;

                                    this.Centre = getDecimal(data.Substring(startSubstring, octet));

                                    this.Position = getDecimal(data.Substring(startSubstring + octet, octet));

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 13) // Presence of subfield 12
                                {
                                    sizeSubfield = 5 * octet;

                                    string strTOD_TOR = data.Substring(startSubstring + octet, 4 * octet);
                                    this.REP290 = getDecimal(data.Substring(startSubstring, octet));
                                    // TYP
                                    string strTYP = getDecimal(strTOD_TOR.Substring(octet, 5));
                                    if (strTYP == "0")
                                    {
                                        this.TOD_TYP = "Scheduled off-block time";
                                    }
                                    else if (strTYP == "1")
                                    {
                                        this.TOD_TYP = "Estimated off-block time";
                                    }
                                    else if (strTYP == "2")
                                    {
                                        this.TOD_TYP = "Estimated take-off time";
                                    }
                                    else if (strTYP == "3")
                                    {
                                        this.TOD_TYP = "Actual off-block time";
                                    }
                                    else if (strTYP == "4")
                                    {
                                        this.TOD_TYP = "Predicted time at runway hold";
                                    }
                                    else if (strTYP == "5")
                                    {
                                        this.TOD_TYP = "Actual time at runway hold";
                                    }
                                    else if (strTYP == "6")
                                    {
                                        this.TOD_TYP = "Actual line-up time";
                                    }
                                    else if (strTYP == "7")
                                    {
                                        this.TOD_TYP = "Actual take-off time";
                                    }
                                    else if (strTYP == "8")
                                    {
                                        this.TOD_TYP = "Estimated time of arrival";
                                    }
                                    else if (strTYP == "9")
                                    {
                                        this.TOD_TYP = "Predicted landing time";
                                    }
                                    else if (strTYP == "10")
                                    {
                                        this.TOD_TYP = "Actual landing time";
                                    }
                                    else if (strTYP == "11")
                                    {
                                        this.TOD_TYP = "Actual time off runway";
                                    }
                                    else if (strTYP == "12")
                                    {
                                        this.TOD_TYP = "Predicted time to gate";
                                    }
                                    else if (strTYP == "13")
                                    {
                                        this.TOD_TYP = "Actual on-block time";
                                    }

                                    // DAY
                                    string strDAY = strTOD_TOR.Substring(octet + 5, 2);
                                    if (strDAY == "00")
                                    {
                                        this.DAY = "00 Today";
                                    }
                                    else if (strDAY == "01")
                                    {
                                        this.DAY = "01 Yesterday";
                                    }
                                    else if (strDAY == "10")
                                    {
                                        this.DAY = "10 Tomorrow";
                                    }
                                    else if (strDAY == "11")
                                    {
                                        this.DAY = "11 Invalid";
                                    }

                                    // HOR
                                    this.HOR = getDecimal(strTOD_TOR.Substring(2 * octet + 3, 5));

                                    // MIN
                                    this.MIN = getDecimal(strTOD_TOR.Substring(3 * octet + 2, 6));

                                    // AVS
                                    if (getDecimal(strTOD_TOR.Substring(4 * octet, 1)) == "0")
                                    {
                                        this.AVS = "0 Seconds available";
                                    }
                                    else
                                    {
                                        this.AVS = "1 Seconds not available";
                                    }

                                    // SEC
                                    this.SEC = getDecimal(strTOD_TOR.Substring(4 * octet + 2, 6));

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 14) // Presence of subfield 13
                                {
                                    sizeSubfield = 6 * octet;

                                    this.AircraftStand = GetBytesFromBinaryString(data.Substring(startSubstring, sizeSubfield));

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 15) // Presence of subfield 14
                                {
                                    sizeSubfield = octet;

                                    string strDAY = data.Substring(startSubstring, 2);
                                    if (strDAY == "00")
                                    {
                                        this.EMP = "00 Empty";
                                    }
                                    else if (strDAY == "01")
                                    {
                                        this.EMP = "01 Occupied";
                                    }
                                    else if (strDAY == "10")
                                    {
                                        this.EMP = "10 Unknown";
                                    }
                                    else if (strDAY == "11")
                                    {
                                        this.EMP = "11 Invalid";
                                    }
                                    strDAY = data.Substring(startSubstring + 2, 2);
                                    if (strDAY == "00")
                                    {
                                        this.AVL = "00 Available";
                                    }
                                    else if (strDAY == "01")
                                    {
                                        this.AVL = "01 Not Available";
                                    }
                                    else if (strDAY == "10")
                                    {
                                        this.AVL = "10 Unknown";
                                    }
                                    else if (strDAY == "11")
                                    {
                                        this.AVL = "11 Invalid";
                                    }
                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 17) // Presence of subfield 15
                                {
                                    sizeSubfield = 7 * octet;

                                    this.StandardInstrumentDeparture = GetBytesFromBinaryString(data.Substring(startSubstring, sizeSubfield));

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 18) // Presence of subfield 16
                                {
                                    sizeSubfield = 7 * octet;

                                    this.StandardInstrumentArrival = GetBytesFromBinaryString(data.Substring(startSubstring, sizeSubfield));

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 19) // Presence of subfield 17
                                {
                                    sizeSubfield = 2 * octet;

                                    this.VA = data.Substring(startSubstring + 3, 1);
                                    int sizeNums = 3;
                                    string firstNum = getDecimal(data.Substring(count + 4, sizeNums));
                                    string secondNum = getDecimal(data.Substring(count + 4 + sizeNums, sizeNums));
                                    string thirdNum = getDecimal(data.Substring(count + 4 + 2 * sizeNums, sizeNums));
                                    string fourthNum = getDecimal(data.Substring(count + 4 + 3 * sizeNums, sizeNums));
                                    this.Mode3ARep = firstNum + secondNum + thirdNum + fourthNum;

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                                else if (numSubfield == 20) // Presence of subfield 18
                                {
                                    sizeSubfield = 7 * octet;

                                    this.PreEmergencyCallsign = GetBytesFromBinaryString(data.Substring(startSubstring, sizeSubfield));

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                            }

                            numSubfield++;
                        }

                        size = lenPrimarySubfield + countSecondarySubfield;
                        count += size;
                    }

                    else if (FRN == 22)
                    {
                        int nOct = 1;
                        while (data.Substring(count + 7 + octet * (nOct - 1), 1) == "1")
                        {
                            nOct += 1;
                        }
                        this.LEN22 = nOct.ToString();
                        size = nOct * octet;
                        count += size;
                    }

                    else if (FRN == 23)
                    {
                        size = 1 * octet;

                        string STRVFI = getDecimal(data.Substring(count, size));

                        if (STRVFI == "0")
                        {
                            this.VFI = "Unknown";
                        }
                        else if (STRVFI == "1")
                        {
                            this.VFI = "ATC equipment maintenance";
                        }
                        else if (STRVFI == "2")
                        {
                            this.VFI = "Airport maintenance";
                        }
                        else if (STRVFI == "3")
                        {
                            this.VFI = "Fire";
                        }
                        else if (STRVFI == "4")
                        {
                            this.VFI = "Bird scarer";
                        }
                        else if (STRVFI == "5")
                        {
                            this.VFI = "Snow plough";
                        }
                        else if (STRVFI == "6")
                        {
                            this.VFI = "Runway sweeper";
                        }
                        else if (STRVFI == "7")
                        {
                            this.VFI = "Emergency";
                        }
                        else if (STRVFI == "8")
                        {
                            this.VFI = "Police";
                        }
                        else if (STRVFI == "9")
                        {
                            this.VFI = "Bus";
                        }
                        else if (STRVFI == "10")
                        {
                            this.VFI = "Tug (push/tow)";
                        }
                        else if (STRVFI == "11")
                        {
                            this.VFI = "Grass cutter";
                        }
                        else if (STRVFI == "12")
                        {
                            this.VFI = "Fuel";
                        }
                        else if (STRVFI == "13")
                        {
                            this.VFI = "Baggage";
                        }
                        else if (STRVFI == "14")
                        {
                            this.VFI = "Catering";
                        }
                        else if (STRVFI == "15")
                        {
                            this.VFI = "Aircraftmaintenance";
                        }
                        else if (STRVFI == "16")
                        {
                            this.VFI = "Flyco (follow me)";
                        }

                        count += size;
                    }

                    else if (FRN == 24)
                    {
                        int nOct = 1;
                        while (data.Substring(count + 7 + octet * (nOct - 1), 1) == "1")
                        {
                            nOct += 1;
                        }
                        this.LEN24 = nOct.ToString();
                        size = nOct * octet;
                        count += size;
                    }

                    else if (FRN == 25)
                    {
                        size = 2 * octet;
                        int sizeNums = 3;

                        string A = getDecimal(data.Substring(count + 4, sizeNums));
                        string B = getDecimal(data.Substring(count + 4 + sizeNums, sizeNums));
                        string C = getDecimal(data.Substring(count + 4 + 2 * sizeNums, sizeNums));
                        string D = getDecimal(data.Substring(count + 4 + 3 * sizeNums, sizeNums));

                        this.TrackMode2Code = A + B + C + D;

                        count += size;
                    }

                    else if (FRN == 26)  // --------------------------------------------------------------
                    {
                        string stringBits = data[count..];
                        size = getVariableSizeThreeOctets(stringBits);
                        string ComposedTrackNumber = data.Substring(count, size);

                        this.SystemUnitID = getDecimal(ComposedTrackNumber.Substring(0, octet));
                        this.SystemTrackNumber = getDecimal(ComposedTrackNumber.Substring(octet, (2 * octet) - 1));


                        count += size;
                    }

                    else if (FRN == 27)
                    {
                        int nOct = 1;
                        while (data.Substring(count + 7 + octet * (nOct - 1), 1) == "1")
                        {
                            nOct += 1;
                        }
                        this.LEN27 = nOct.ToString();
                        size = nOct * octet;
                        count += size;
                    }

                    else if (FRN == 28) // 
                    {
                        string stringBits = data[count..];  // Gets all data from count till finish
                        int nOct = 1;
                        while (data.Substring(count + 7 + octet * (nOct - 1), 1) == "1")
                        {
                            nOct += 1;
                        }
                        int lenPrimarySubfield = nOct * octet;
                        string primarySubfield = data.Substring(count, lenPrimarySubfield);  // String uptaded to what we need
                        int countSecondarySubfield = 0;
                        int sizeSubfield;
                        int startSubstring = count + lenPrimarySubfield;
                        int numSubfield = 1;
                        this.primary28 = primarySubfield;
                        foreach (char Bit in primarySubfield)
                        {
                            if (Bit.ToString() == "1")
                            {
                                if (numSubfield == 1) // Presence of subfield 1
                                {
                                    sizeSubfield = 2 * octet;

                                    this.SACSI = getDecimal(data.Substring(startSubstring, octet));

                                    this.SICSI = getDecimal(data.Substring(startSubstring + octet, octet));

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 2) // Presence of subfield 2
                                {
                                    sizeSubfield = 4 * octet;

                                    this.RHO = (Convert.ToDouble(getDecimal(data.Substring(startSubstring, 2 * octet))) / 256).ToString();

                                    this.THETA = (Convert.ToDouble(getDecimal(data.Substring(startSubstring + 2 * octet, 2 * octet))) * (360 / (Math.Pow(2, 16)))).ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 3) // Presence of subfield 3
                                {
                                    sizeSubfield = 2 * octet;

                                    this.HEI = ((Convert.ToDouble(getDecimal(data.Substring(startSubstring, sizeSubfield))) * 25)).ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 4) // Presence of subfield 4
                                {

                                    sizeSubfield = 2 * octet;
                                    if (startSubstring + sizeSubfield < data.Length)
                                    {

                                        string strMDC = data.Substring(startSubstring, sizeSubfield);

                                        // Validation
                                        if (strMDC[0].ToString() == "0")
                                        {
                                            this.V = "0 Code validated";
                                        }
                                        else if (strMDC[0].ToString() == "1")
                                        {
                                            this.V = "1 Code not validated";
                                        }

                                        // Default or garbled
                                        if (strMDC[1].ToString() == "0")
                                        {
                                            this.G = "0 Default";
                                        }
                                        else if (strMDC[1].ToString() == "1")
                                        {
                                            this.G = "1 Garbled";
                                        }

                                        // Last measured mode c code
                                        this.MDC = ((Convert.ToDouble(getDecimal(findTwoscomplement2(strMDC.Substring(2, 14)))) / 4)).ToString();

                                        countSecondarySubfield += sizeSubfield;
                                        startSubstring += sizeSubfield;
                                    }
                                }
                                else if (numSubfield == 5) // Presence of subfield 5
                                {
                                    sizeSubfield = 2 * octet;

                                    int sizeNums = 3;
                                    string validated = data.Substring(count, 1);
                                    string garbled = data.Substring(count + 1, 1);
                                    string L = data.Substring(count + 2, 1);
                                    string spareBit = data.Substring(count + 3, 1);
                                    string firstNum = getDecimal(data.Substring(count + 4, sizeNums));
                                    string secondNum = getDecimal(data.Substring(count + 4 + sizeNums, sizeNums));
                                    string thirdNum = getDecimal(data.Substring(count + 4 + 2 * sizeNums, sizeNums));
                                    string fourthNum = getDecimal(data.Substring(count + 4 + 3 * sizeNums, sizeNums));

                                    if (validated == "1")
                                    {
                                        this.V2 = "1 Code not Validated";
                                    }
                                    else
                                    {
                                        this.V2 = "0 Code Validated";
                                    }

                                    if (garbled == "1")
                                    {
                                        this.G2 = "1 Garbled Code";
                                    }
                                    else
                                    {
                                        this.G2 = "0 Default";
                                    }

                                    if (L == "0")
                                    {
                                        this.L = "0 MODE 3/A code as derived from the reply of the transponder,";
                                    }
                                    else
                                    {
                                        this.L = "1 Smoothed MODE 3/A code as provided by a sensor local tracker.";
                                    }

                                    this.MDA = firstNum + secondNum + thirdNum + fourthNum;
                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 6) // Presence of subfield 6
                                {
                                    sizeSubfield = 1 * octet;
                                    if (startSubstring < data.Length)
                                    {
                                        string strTYP = data.Substring(startSubstring, sizeSubfield);

                                        // TYP
                                        if (strTYP.Substring(0, 3) == "000")
                                        {
                                            this.TYP = "000 No detection";
                                        }
                                        else if (strTYP.Substring(0, 3) == "001")
                                        {
                                            this.TYP = "001 Single PSR detection";
                                        }
                                        else if (strTYP.Substring(0, 3) == "010")
                                        {
                                            this.TYP = "010 Single SSR detection";
                                        }
                                        else if (strTYP.Substring(0, 3) == "011")
                                        {
                                            this.TYP = "011 SSR + PSR detection";
                                        }
                                        else if (strTYP.Substring(0, 3) == "100")
                                        {
                                            this.TYP = "100 Single ModeS All-Call";
                                        }
                                        else if (strTYP.Substring(0, 3) == "101")
                                        {
                                            this.TYP = "101 Single ModeS Roll-Call";
                                        }
                                        else if (strTYP.Substring(0, 3) == "110")
                                        {
                                            this.TYP = "110 ModeS All-Call + PSR";
                                        }
                                        else if (strTYP.Substring(0, 3) == "111")
                                        {
                                            this.TYP = "111 ModeS Roll-Call +PSR";
                                        }

                                        // SIM
                                        if (strTYP.Substring(3, 1) == "0")
                                        {
                                            this.SIMrep = "0 Actual target report";
                                        }
                                        else if (strTYP.Substring(3, 1) == "1")
                                        {
                                            this.SIMrep = "1 Simulated target report";
                                        }

                                        // RAB
                                        if (strTYP.Substring(4, 1) == "0")
                                        {
                                            this.RAB = "0 Report from target transponder";
                                        }
                                        else if (strTYP.Substring(4, 1) == "1")
                                        {
                                            this.RAB = "1 Report from field monitor (fixed transponder)";
                                        }

                                        // TST
                                        if (strTYP.Substring(5, 1) == "0")
                                        {
                                            this.TST = "0 Real target report";
                                        }
                                        else if (strTYP.Substring(5, 1) == "1")
                                        {
                                            this.TST = "1 Test target report";
                                        }

                                        countSecondarySubfield += sizeSubfield;
                                        startSubstring += sizeSubfield;
                                    }
                                }
                            }

                            numSubfield++;
                        }


                        size = lenPrimarySubfield + countSecondarySubfield;
                        count += size;

                    }
                    else if (FRN == 34)
                    {
                        string sLENRE = getDecimal(data.Substring(count, octet));
                        this.LENRE = sLENRE;
                        int iLENRE = Convert.ToInt32(sLENRE);
                        //size = iLENRE * octet;

                        this.CSTRE = data.Substring(count + octet, 1);
                        this.CSN = data.Substring(count + octet + 1, 1);
                        this.TVS = data.Substring(count + octet + 2, 1);
                        this.STS = data.Substring(count + octet + 3, 1);
                        count += octet;

                        string stringBits = data[count..];  // Gets all data from count till finish
                        int lenPrimarySubfield = octet;
                        string primarySubfield = data.Substring(count, lenPrimarySubfield);  // String uptaded to what we need
                        int countSecondarySubfield = 0;
                        int sizeSubfield;
                        int startSubstring = count + lenPrimarySubfield;
                        int numSubfield = 1;
                        this.primary34 = primarySubfield;
                        foreach (char Bit in primarySubfield)
                        {
                            if (Bit.ToString() == "1")
                            {
                                if (numSubfield == 1) // Presence of subfield 1
                                {
                                    sizeSubfield = 6 * octet;

                                    string sREP = getDecimal(data.Substring(startSubstring, octet));
                                    double dREP = Convert.ToDouble(sREP);
                                    this.REPW = dREP.ToString();
                                    string sSAC = getDecimal(data.Substring(startSubstring + octet, octet));
                                    double dSAC = Convert.ToDouble(sSAC);
                                    this.SACW = dREP.ToString();
                                    string sSIC = getDecimal(data.Substring(startSubstring + 2 * octet, octet));
                                    double dSIC = Convert.ToDouble(sSIC);
                                    this.SICW = dSIC.ToString();

                                    string sTYP = data.Substring(startSubstring + 3 * octet + 4, 4);
                                    if (sTYP == "0000")
                                    { this.TYPW = "No detection"; }
                                    else if (sTYP == "0001")
                                    { this.TYPW = "Single PSR detection"; }
                                    else if (sTYP == "0010")
                                    { this.TYPW = "Single SSR detection"; }
                                    else if (sTYP == "0011")
                                    { this.TYPW = "SSR+PSR detection"; }
                                    else if (sTYP == "0100")
                                    { this.TYPW = "Single Mode S All-Call"; }
                                    else if (sTYP == "0101")
                                    { this.TYPW = "Single Mode S Roll-Call"; }
                                    else if (sTYP == "0110")
                                    { this.TYPW = "Mode S All-Call + PSR"; }
                                    else if (sTYP == "0111")
                                    { this.TYPW = "Mode S Roll-Call + PSR"; }
                                    else if (sTYP == "1000")
                                    { this.TYPW = "ADS-B"; }
                                    else if (sTYP == "1001")
                                    { this.TYPW = "WAM"; }
                                    else if (sTYP == "1010")
                                    { this.TYPW = "Reserved for future use"; }
                                    else if (sTYP == "1011")
                                    { this.TYPW = "Reserved for future use"; }
                                    else if (sTYP == "1100")
                                    { this.TYPW = "Reserved for future use"; }
                                    else if (sTYP == "1101")
                                    { this.TYPW = "Reserved for future use"; }
                                    else if (sTYP == "1110")
                                    { this.TYPW = "Reserved for future use"; }
                                    else if (sTYP == "1111")
                                    { this.TYPW = "Reserved for future use"; }

                                    string sLTN = getDecimal(data.Substring(startSubstring + 4 * octet, 2 * octet));
                                    double dLTN = Convert.ToDouble(sLTN);
                                    this.LTNW = dLTN.ToString();


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 2) // Presence of subfield 2
                                {
                                    sizeSubfield = 4 * octet;

                                    string sREP = getDecimal(data.Substring(startSubstring, octet));
                                    double dREP = Convert.ToDouble(sREP);
                                    this.REPNO = dREP.ToString();
                                    string sSAC = getDecimal(data.Substring(startSubstring + octet, octet));
                                    double dSAC = Convert.ToDouble(sSAC);
                                    this.SACNO = dREP.ToString();
                                    string sSIC = getDecimal(data.Substring(startSubstring + 2 * octet, octet));
                                    double dSIC = Convert.ToDouble(sSIC);
                                    this.SICNO = dSIC.ToString();

                                    string sTYP = data.Substring(startSubstring + 3 * octet + 4, 4);
                                    if (sTYP == "0000")
                                    { this.TYPNO = "No detection"; }
                                    else if (sTYP == "0001")
                                    { this.TYPNO = "Single PSR detection"; }
                                    else if (sTYP == "0010")
                                    { this.TYPNO = "Single SSR detection"; }
                                    else if (sTYP == "0011")
                                    { this.TYPNO = "SSR+PSR detection"; }
                                    else if (sTYP == "0100")
                                    { this.TYPNO = "Single Mode S All-Call"; }
                                    else if (sTYP == "0101")
                                    { this.TYPNO = "Single Mode S Roll-Call"; }
                                    else if (sTYP == "0110")
                                    { this.TYPNO = "Mode S All-Call + PSR"; }
                                    else if (sTYP == "0111")
                                    { this.TYPNO = "Mode S Roll-Call + PSR"; }
                                    else if (sTYP == "1000")
                                    { this.TYPNO = "ADS-B"; }
                                    else if (sTYP == "1001")
                                    { this.TYPNO = "WAM"; }
                                    else if (sTYP == "1010")
                                    { this.TYPNO = "Reserved for future use"; }
                                    else if (sTYP == "1011")
                                    { this.TYPNO = "Reserved for future use"; }
                                    else if (sTYP == "1100")
                                    { this.TYPNO = "Reserved for future use"; }
                                    else if (sTYP == "1101")
                                    { this.TYPNO = "Reserved for future use"; }
                                    else if (sTYP == "1110")
                                    { this.TYPNO = "Reserved for future use"; }
                                    else if (sTYP == "1111")
                                    { this.TYPNO = "Reserved for future use"; }


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 3) // Presence of subfield 3
                                {
                                    sizeSubfield = 4 * octet;

                                    string sVx = getDecimal(data.Substring(startSubstring, 2 * octet));
                                    double dVx = Convert.ToDouble(sVx) * 0.25;
                                    this.VxRE = dVx.ToString();
                                    string sVy = getDecimal(data.Substring(startSubstring + 2 * octet, 2 * octet));
                                    double dVy = Convert.ToDouble(sVy) * 0.25;
                                    this.VyRE = dVy.ToString();

                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }
                                else if (numSubfield == 4) // Presence of subfield 4
                                {
                                    sizeSubfield = 1 * octet;

                                    string sFDR = getDecimal(data.Substring(startSubstring, 1));
                                    if (sFDR == "0") { this.FDR = "0 Flight plan data from active FDPS"; }
                                    if (sFDR == "1") { this.FDR = "1 Flight plan data retained from no longer active FDPS"; }


                                    countSecondarySubfield += sizeSubfield;
                                    startSubstring += sizeSubfield;
                                }

                            }

                            numSubfield++;
                        }

                        size = lenPrimarySubfield + countSecondarySubfield;
                        count += size;




                    }
                    else if (FRN == 35)
                    {
                        int nOct = 1;
                        while ((count + 7 + octet * (nOct - 1) <= data.Length) && (data.Substring(count + 7 + octet * (nOct - 1), 1) == "1"))
                        {
                            nOct += 1;
                        }
                        size = nOct * octet;
                        this.LEN35 = size.ToString();
                        count += size;
                    }
                }
            }
        }
        public DataItem(string data, string list)
        {
            this.TargetID = "";
            this.ID = "";
            this.Callsign = "";
            this.TrackNumber = "";
            this.DestinationAirport = "";
            this.DepartureAirport = "";
            this.LatWGS84 = "";
            this.LonWGS84 = "";
            this.LatWGS84str = "";
            this.LonWGS84str = "";
            this.ADR = "";
            this.Mode3AReply = "";
            this.MFL = "";
            this.MHG = "";
        }
        public DataItem(string data, List<int> FRNs, string list)
        {
            int octet = 8;
            int count = 0;
            int size;
            this.TargetID = "";
            this.ID = "";
            this.Callsign = "";
            this.TrackNumber = "";
            this.DestinationAirport = "";
            this.DepartureAirport = "";
            this.LatWGS84 = "";
            this.LonWGS84 = "";
            this.LatWGS84str = "";
            this.LonWGS84str = "";
            this.ADR = "";
            this.Mode3AReply = "";
            this.MFL = "";
            this.MHG = "";

            foreach (int FRN in FRNs)
            {
                if (FRN == 1)
                {
                    size = 2 * octet;
                    count += size;
                }
                else if (FRN == 2)
                {
                    // No info
                }

                else if (FRN == 3)
                {
                    size = 1 * octet;
                    count += size;
                }

                else if (FRN == 4)
                {
                    size = 3 * octet;
                    // Get time
                    string seconds = getDecimal(data.Substring(count, size));
                    this.TimeSeconds = Convert.ToDouble(seconds) / 128;
                    TimeSpan time = TimeSpan.FromSeconds(Convert.ToDouble(seconds) / 128);
                    string timeOfTrack = time.ToString(@"hh\:mm\:ss\.fff");
                    this.TimeOfTrackInfo = timeOfTrack;

                    count += size;
                }

                else if (FRN == 5)
                {
                    size = 8 * octet;
                    this.LatWGS84 = (Convert.ToDouble(TwoCToString(data.Substring(count, 4 * octet))) * (0.00000536441802978515625)).ToString();//536441802978515625
                    this.LonWGS84 = (Convert.ToDouble(TwoCToString(data.Substring(count + 4 * octet, 4 * octet))) * (0.00000536441802978515625)).ToString();
                    if (LatWGS84.Length >= 7)
                    {
                        this.LatWGS84str = LatWGS84.Substring(0,7);
                    }
                    else
                    {
                        this.LatWGS84str = LatWGS84;
                    }
                    if (LonWGS84.Length >= 7)
                    {
                        this.LonWGS84str = LonWGS84.Substring(0,7);
                    }
                    else
                    {
                        this.LonWGS84str = LonWGS84;
                    }
                    

                    count += size;
                }

                else if (FRN == 6)
                {
                    size = 6 * octet;
                    this.X = (Convert.ToDouble(TwoCToString(data.Substring(count, 3 * octet))) * 0.5).ToString();
                    this.Y = (Convert.ToDouble(TwoCToString(data.Substring(count + 3 * octet, 3 * octet))) * 0.5).ToString();

                    count += size;
                }

                else if (FRN == 7)
                {
                    size = 4 * octet;
                    this.Vx = (Convert.ToDouble(TwoCToString(data.Substring(count, 2 * octet))) * 0.25).ToString();
                    this.Vy = (Convert.ToDouble(TwoCToString(data.Substring(count + 2 * octet, 2 * octet))) * 0.25).ToString();

                    count += size;
                }

                else if (FRN == 8)
                {
                    size = 2 * octet;
                    count += size;
                }

                else if (FRN == 9)
                {
                    size = 2 * octet;

                    int sizeNums = 3;
                    string validated = data.Substring(count, 1);
                    string garbled = data.Substring(count + 1, 1);
                    string change = data.Substring(count + 2, 1);
                    string spareBit = data.Substring(count + 3, 1);
                    string firstNum = getDecimal(data.Substring(count + 4, sizeNums));
                    string secondNum = getDecimal(data.Substring(count + 4 + sizeNums, sizeNums));
                    string thirdNum = getDecimal(data.Substring(count + 4 + 2 * sizeNums, sizeNums));
                    string fourthNum = getDecimal(data.Substring(count + 4 + 3 * sizeNums, sizeNums));

                    if (validated == "1")
                    {
                        this.Validated = "1 Code not validated";
                    }
                    else
                    {
                        this.Validated = "0 Code validated";
                    }

                    if (garbled == "1")
                    {
                        this.Garbled = "1 Garbled Code";
                    }
                    else
                    {
                        this.Garbled = "0 Default";
                    }

                    if (change == "1")
                    {
                        this.ChangeInMode = "1 Mode 3/A has changed";
                    }
                    else
                    {
                        this.ChangeInMode = "0 No Change";
                    }

                    this.Mode3AReply = firstNum + secondNum + thirdNum + fourthNum;

                    count += size;
                }

                else if (FRN == 10)
                {
                    size = 7 * octet;
                    int sizeChars = 6;
                    string STI = data.Substring(count, 2);

                    string char1 = getTargetIdentificationCharacter(data.Substring(count + octet, sizeChars));
                    string char2 = getTargetIdentificationCharacter(data.Substring(count + octet + sizeChars, sizeChars));
                    string char3 = getTargetIdentificationCharacter(data.Substring(count + octet + 2 * sizeChars, sizeChars));
                    string char4 = getTargetIdentificationCharacter(data.Substring(count + octet + 3 * sizeChars, sizeChars));
                    string char5 = getTargetIdentificationCharacter(data.Substring(count + octet + 4 * sizeChars, sizeChars));
                    string char6 = getTargetIdentificationCharacter(data.Substring(count + octet + 5 * sizeChars, sizeChars));
                    string char7 = getTargetIdentificationCharacter(data.Substring(count + octet + 6 * sizeChars, sizeChars));
                    string char8 = getTargetIdentificationCharacter(data.Substring(count + octet + 7 * sizeChars, sizeChars));

                    //if (STI == "00")
                    //{
                    //    this.STI = "00 Callsign or registration downlinked from target";
                    //}
                    //else if (STI == "01")
                    //{
                    //    this.STI = "01 Callsign not downlinked from target";
                    //}
                    //else if (STI == "10")
                    //{
                    //    this.STI = "10 Registration not downlinked from target";
                    //}
                    //else if (STI == "11")
                    //{
                    //    this.STI = "11 Invalid";
                    //}

                    this.TargetID = (char1) + (char2) + (char3) + (char4) + (char5) + char6 + char7 + char8;

                    count += size;
                }

                else if (FRN == 11)
                {
                    string stringBits = data[count..];  // Gets all data from count till finish
                    int nOctL = 1;
                    while (data.Substring(count + 7 + octet * (nOctL - 1), 1) == "1")
                    {
                        nOctL += 1;
                    }
                    int lenPrimarySubfield = nOctL * octet;
                    string primarySubfield = data.Substring(count, lenPrimarySubfield);  // String uptaded to what we need
                    int countSecondarySubfield = 0;
                    int sizeSubfield;
                    int startSubstring = count + lenPrimarySubfield;
                    int numSubfield = 1;
                    this.primary11 = primarySubfield;
                    foreach (char Bit in primarySubfield)
                    {
                        if (Bit.ToString() == "1")
                        {
                            if (numSubfield == 1) // Presence of subfield 1
                            {
                                sizeSubfield = 3 * octet;

                                this.ADR = getDecimal(data.Substring(startSubstring, sizeSubfield));

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 2) // Presence of subfield 2
                            {
                                sizeSubfield = 6 * octet;
                                int sizeChars = 6;

                                string char1 = getTargetIdentificationCharacter(data.Substring(startSubstring, sizeChars));
                                string char2 = getTargetIdentificationCharacter(data.Substring(startSubstring + sizeChars, sizeChars));
                                string char3 = getTargetIdentificationCharacter(data.Substring(startSubstring + 2 * sizeChars, sizeChars));
                                string char4 = getTargetIdentificationCharacter(data.Substring(startSubstring + 3 * sizeChars, sizeChars));
                                string char5 = getTargetIdentificationCharacter(data.Substring(startSubstring + 4 * sizeChars, sizeChars));
                                string char6 = getTargetIdentificationCharacter(data.Substring(startSubstring + 5 * sizeChars, sizeChars));
                                string char7 = getTargetIdentificationCharacter(data.Substring(startSubstring + 6 * sizeChars, sizeChars));
                                string char8 = getTargetIdentificationCharacter(data.Substring(startSubstring + 7 * sizeChars, sizeChars));

                                this.ID = (char1) + (char2) + (char3) + (char4) + (char5) + char6 + char7 + char8;

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 3) // Presence of subfield 3
                            {
                                sizeSubfield = 2 * octet;
                                double mhg = Convert.ToDouble(Convert.ToInt32(data.Substring(startSubstring, sizeSubfield), 2));
                                this.MHG = (mhg * 360 / (Math.Pow(2, 16))).ToString();

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 4) // Presence of subfield 4
                            {
                                sizeSubfield = 2 * octet;
                                double airspeed = Convert.ToDouble(getDecimal(data.Substring(startSubstring + 1, sizeSubfield - 1)));
                                // IAS or Mach No
                                this.IM = data.Substring(startSubstring, 1);
                                if (data.Substring(startSubstring, 1) == "0")
                                {
                                    this.IAS = (airspeed * (Math.Pow(2, -14))).ToString();
                                }
                                else if (data.Substring(startSubstring, 1) == "1")
                                {
                                    this.MACH = (airspeed * 0.001).ToString();
                                }

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 5) // Presence of subfield 5
                            {
                                sizeSubfield = 2 * octet;

                                //this.TAS = getDecimal(data.Substring(startSubstring, sizeSubfield));

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 6) // Presence of subfield 6
                            {
                                sizeSubfield = 2 * octet;

                                //string strSelectedAltitude = data.Substring(startSubstring, sizeSubfield);

                                //// First bit
                                //if (strSelectedAltitude[0].ToString() == "0")
                                //{
                                //    this.SAS = "0 No source information provided";
                                //}
                                //else if (strSelectedAltitude[0].ToString() == "1")
                                //{
                                //    this.SAS = "1 Source information provided";
                                //}

                                //// 2nd and 3rd bit
                                //if (strSelectedAltitude.Substring(1, 2) == "00")
                                //{
                                //    this.Source = "00 Unknown";
                                //}
                                //else if (strSelectedAltitude.Substring(1, 2) == "01")
                                //{
                                //    this.Source = "01 Aircraft Altitude";
                                //}
                                //else if (strSelectedAltitude.Substring(1, 2) == "10")
                                //{
                                //    this.Source = "10 FCU/MCP Selected Altitude";
                                //}
                                //else if (strSelectedAltitude.Substring(1, 2) == "11")
                                //{
                                //    this.Source = "11 FMS Selected Altitude";
                                //}

                                //this.SAL = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring + 3, sizeSubfield - 3))) * 25).ToString();

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 7) // Presence of subfield 7
                            {
                                sizeSubfield = 2 * octet;

                                //string strFinalStateSelectedAltitude = data.Substring(startSubstring, sizeSubfield);

                                //// First bit
                                //if (strFinalStateSelectedAltitude[0].ToString() == "0")
                                //{
                                //    this.MV = "0 Not active";
                                //}
                                //else if (strFinalStateSelectedAltitude[0].ToString() == "1")
                                //{
                                //    this.MV = "1 Active";
                                //}
                                //// Second bit
                                //if (strFinalStateSelectedAltitude[0].ToString() == "0")
                                //{
                                //    this.AH = "0 Not active";
                                //}
                                //else if (strFinalStateSelectedAltitude[0].ToString() == "1")
                                //{
                                //    this.AH = "1 Active";
                                //}
                                //// Third bit
                                //if (strFinalStateSelectedAltitude[0].ToString() == "0")
                                //{
                                //    this.AM = "0 Not active";
                                //}
                                //else if (strFinalStateSelectedAltitude[0].ToString() == "1")
                                //{
                                //    this.AM = "1 Active";
                                //}

                                //this.FSS = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring + 3, sizeSubfield - 3))) * 25).ToString();

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 9) // Presence of subfield 8
                            {
                                int nOct = 1;
                                while (data.Substring(startSubstring + 7 + octet * (nOct - 1), 1) == "1")
                                {
                                    nOct += 1;
                                }
                                sizeSubfield = nOct * octet;
                                //string strTIS = data.Substring(startSubstring, sizeSubfield);

                                //// Available
                                //if (strTIS[0].ToString() == "0")
                                //{
                                //    this.NAV = "0 Trajectory Intent Data is available for this aircraft";
                                //}
                                //else if (strTIS[0].ToString() == "1")
                                //{
                                //    this.NAV = "1 Trajectory Intent Data is not available for this aircraft";
                                //}
                                //// Valid
                                //if (strTIS[1].ToString() == "0")
                                //{
                                //    this.NVB = "0 Trajectory Intent Data is valid";
                                //}
                                //else if (strTIS[1].ToString() == "1")
                                //{
                                //    this.NVB = "1 Trajectory Intent Data is not valid";
                                //}

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 10) // Presence of subfield 9
                            {
                                sizeSubfield = 16 * octet;

                                //// REP
                                //this.REP = getDecimal(data.Substring(startSubstring, octet));

                                //// TCA
                                //if (data.Substring(startSubstring + octet, 1) == "0")
                                //{
                                //    this.TCA = "0 TCP number available";
                                //}
                                //else if (data.Substring(startSubstring + octet, 1) == "1")
                                //{
                                //    this.TCA = "1 TCP number not available";
                                //}

                                //// NC
                                //if (data.Substring(startSubstring + octet + 1, 1) == "0")
                                //{
                                //    this.NC = "0 TCP compliance";
                                //}
                                //else if (data.Substring(startSubstring + octet + 1, 1) == "1")
                                //{
                                //    this.NC = "1 TCP non-compliance";
                                //}

                                //// TCP Number
                                //this.TCPNumber = getDecimal(data.Substring(startSubstring + octet + 2, octet - 2));

                                //// Altitude
                                //this.Altitude = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring + 2 * octet, 2 * octet))) * 10).ToString();

                                //// Latitude
                                //this.Latitude = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring + 4 * octet, 3 * octet))) * (180 / Math.Pow(2, 23))).ToString();

                                //// Longitude
                                //this.Longitude = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring + 7 * octet, 3 * octet))) * (180 / Math.Pow(2, 23))).ToString();

                                //// Point Type
                                //string strPointType = getDecimal(data.Substring(startSubstring + 10 * octet, 4));
                                //if (strPointType == "0")
                                //{
                                //    this.PointType = "0000 Unknown";
                                //}
                                //else if (strPointType == "1")
                                //{
                                //    this.PointType = "0001 Fly by waypoint (LT)";
                                //}
                                //else if (strPointType == "2")
                                //{
                                //    this.PointType = "0010 Fly over waypoint (LT)";
                                //}
                                //else if (strPointType == "3")
                                //{
                                //    this.PointType = "0011 Hold pattern (LT)";
                                //}
                                //else if (strPointType == "4")
                                //{
                                //    this.PointType = "0100 Procedure hold (LT)";
                                //}
                                //else if (strPointType == "5")
                                //{
                                //    this.PointType = "0101 Procedure turn (LT)";
                                //}
                                //else if (strPointType == "6")
                                //{
                                //    this.PointType = "0110 RF leg (LT)";
                                //}
                                //else if (strPointType == "7")
                                //{
                                //    this.PointType = "0111 Top of climb (VT)";
                                //}
                                //else if (strPointType == "8")
                                //{
                                //    this.PointType = "1000 Top of descent (VT)";
                                //}
                                //else if (strPointType == "9")
                                //{
                                //    this.PointType = "1001 Start of level (VT)";
                                //}
                                //else if (strPointType == "10")
                                //{
                                //    this.PointType = "1010 Cross-over altitude (VT)";
                                //}
                                //else if (strPointType == "11")
                                //{
                                //    this.PointType = "1011 Transition altitude (VT)";
                                //}

                                //// TD
                                //string strTD = data.Substring(startSubstring + (10 * octet) + 4, 2);
                                //if (strTD == "00")
                                //{
                                //    this.TD = "00 N/A";
                                //}
                                //else if (strTD == "01")
                                //{
                                //    this.TD = "01 Turn ight";
                                //}
                                //else if (strTD == "10")
                                //{
                                //    this.TD = "10 Turn left";
                                //}
                                //else if (strTD == "11")
                                //{
                                //    this.TD = "11 No turn";
                                //}

                                //// TRA
                                //string strTRA = data.Substring(startSubstring + (10 * octet) + 6, 1);
                                //if (strTRA == "0")
                                //{
                                //    this.TRA = "0 TTR not available";
                                //}
                                //else if (strTRA == "1")
                                //{
                                //    this.TRA = "1 TTR available";
                                //}

                                //// TOA
                                //string strTOA = data.Substring(startSubstring + (10 * octet) + 7, 1);
                                //if (strTOA == "0")
                                //{
                                //    this.TOA = "0 TOV available";
                                //}
                                //else if (strTOA == "1")
                                //{
                                //    this.TOA = "1 TOV not available";
                                //}

                                //// TOV
                                //this.TOV = getDecimal(data.Substring(startSubstring + 11 * octet, 3 * octet));

                                //// TTR
                                //this.TTR = ((Convert.ToInt32(getDecimal(data.Substring(startSubstring + 14 * octet, 2 * octet)))) * 0.01).ToString();

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 11) // Presence of subfield 10
                            {
                                sizeSubfield = 2 * octet;

                                //string strCOM = data.Substring(startSubstring, sizeSubfield);

                                //// Communications capability of the transponder
                                //if (getDecimal(strCOM.Substring(0, 3)) == "0")
                                //{
                                //    this.COM = "000 No communications capability (surveillance only)";
                                //}
                                //else if (getDecimal(strCOM.Substring(0, 3)) == "1")
                                //{
                                //    this.COM = "001 Comm. A and Comm. B capability";
                                //}
                                //else if (getDecimal(strCOM.Substring(0, 3)) == "2")
                                //{
                                //    this.COM = "010 Comm. A, Comm. B and Uplink ELM";
                                //}
                                //else if (getDecimal(strCOM.Substring(0, 3)) == "3")
                                //{
                                //    this.COM = "011 Comm. A, Comm. B, Uplink ELM and Downlink ELM";
                                //}
                                //else if (getDecimal(strCOM.Substring(0, 3)) == "4")
                                //{
                                //    this.COM = "100 Level 5 Transponder capability";
                                //}

                                //// Flight Status
                                //if (getDecimal(strCOM.Substring(3, 3)) == "0")
                                //{
                                //    this.STAT = "000 No alert, no SPI, aircraft airborne";
                                //}
                                //else if (getDecimal(strCOM.Substring(3, 3)) == "1")
                                //{
                                //    this.STAT = "001 No alert, no SPI, aircraft on ground";
                                //}
                                //else if (getDecimal(strCOM.Substring(3, 3)) == "2")
                                //{
                                //    this.STAT = "010 Alert, no SPI, aircraft airborne";
                                //}
                                //else if (getDecimal(strCOM.Substring(3, 3)) == "3")
                                //{
                                //    this.STAT = "011 Alert, no SPI, aircraft on ground";
                                //}
                                //else if (getDecimal(strCOM.Substring(3, 3)) == "4")
                                //{
                                //    this.STAT = "100 Alert, SPI, aircraft airborne or on ground";
                                //}
                                //else if (getDecimal(strCOM.Substring(3, 3)) == "5")
                                //{
                                //    this.STAT = "101 No alert, SPI, aircraft airborne or on ground";
                                //}
                                //else if (getDecimal(strCOM.Substring(3, 3)) == "6")
                                //{
                                //    this.STAT = "110 Not defined";
                                //}
                                //else if (getDecimal(strCOM.Substring(3, 3)) == "7")
                                //{
                                //    this.STAT = "111 Unknown or not yet extracted";
                                //}


                                //// SSC - Specific service capability
                                //if (strCOM[8].ToString() == "0")
                                //{
                                //    this.SSC = "0 No";
                                //}
                                //else if (strCOM[8].ToString() == "1")
                                //{
                                //    this.SSC = "1 Yes";
                                //}

                                //// ARC - Altitude reporting capability
                                //if (strCOM[9].ToString() == "0")
                                //{
                                //    this.ARC = "(0) 100 ft resolution";
                                //}
                                //else if (strCOM[8].ToString() == "1")
                                //{
                                //    this.ARC = "(1) 25 ft resolution";
                                //}

                                //// AIC - Aircraft identification capability
                                //if (strCOM[10].ToString() == "0")
                                //{
                                //    this.AIC = "0 No";
                                //}
                                //else if (strCOM[10].ToString() == "1")
                                //{
                                //    this.AIC = "1 Yes";
                                //}

                                //// B1A
                                //this.B1A = strCOM[11].ToString();

                                //// B1B
                                //this.B1B = getDecimal(strCOM[12..]);


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 12) // Presence of subfield 11
                            {
                                sizeSubfield = 2 * octet;

                                //string strADS = data.Substring(startSubstring, sizeSubfield);

                                //// AC
                                //if (strADS.Substring(0, 2) == "00")
                                //{
                                //    this.AC = "00 unknown";
                                //}
                                //else if (strADS.Substring(0, 2) == "01")
                                //{
                                //    this.AC = "01 ACAS not operational";
                                //}
                                //else if (strADS.Substring(0, 2) == "10")
                                //{
                                //    this.AC = "10 ACAS operational";
                                //}
                                //else if (strADS.Substring(0, 2) == "11")
                                //{
                                //    this.AC = "11 invalid";
                                //}

                                //// MN
                                //if (strADS.Substring(2, 2) == "00")
                                //{
                                //    this.MN = "00 unknown";
                                //}
                                //else if (strADS.Substring(2, 2) == "01")
                                //{
                                //    this.MN = "01 Multiple navigational aids not operating";
                                //}
                                //else if (strADS.Substring(2, 2) == "10")
                                //{
                                //    this.MN = "10 Multiple navigational aids operating";
                                //}
                                //else if (strADS.Substring(2, 2) == "11")
                                //{
                                //    this.MN = "11 invalid";
                                //}

                                //// DC
                                //if (strADS.Substring(4, 2) == "00")
                                //{
                                //    this.DC = "00 unknown";
                                //}
                                //else if (strADS.Substring(4, 2) == "01")
                                //{
                                //    this.DC = "01 Differential correction";
                                //}
                                //else if (strADS.Substring(4, 2) == "10")
                                //{
                                //    this.DC = "10 No differential correction";
                                //}
                                //else if (strADS.Substring(4, 2) == "11")
                                //{
                                //    this.DC = "11 invalid";
                                //}

                                //// GBS
                                //if (strADS.Substring(6, 1) == "0")
                                //{
                                //    this.GBS = "0 Transponder Ground Bit not set or unknown";
                                //}
                                //else if (strADS.Substring(6, 2) == "1")
                                //{
                                //    this.GBS = "1 Transponder Ground Bit set";
                                //}

                                //// STAT
                                //if (getDecimal(strADS.Substring(13, 3)) == "0")
                                //{
                                //    this.SAB = "000 No emergency";
                                //}
                                //else if (getDecimal(strADS.Substring(13, 3)) == "1")
                                //{
                                //    this.SAB = "001 General emergency";
                                //}
                                //else if (getDecimal(strADS.Substring(13, 3)) == "2")
                                //{
                                //    this.SAB = "010Lifeguard / medical";
                                //}
                                //else if (getDecimal(strADS.Substring(13, 3)) == "3")
                                //{
                                //    this.SAB = "011 Minimum fuel";
                                //}
                                //else if (getDecimal(strADS.Substring(13, 3)) == "4")
                                //{
                                //    this.SAB = "100 No communications";
                                //}
                                //else if (getDecimal(strADS.Substring(13, 3)) == "5")
                                //{
                                //    this.SAB = "101 Unlawful interference";
                                //}
                                //else if (getDecimal(strADS.Substring(13, 3)) == "6")
                                //{
                                //    this.SAB = "110 'Downed' Aircraft";
                                //}
                                //else if (getDecimal(strADS.Substring(13, 3)) == "7")
                                //{
                                //    this.SAB = "111 Unknown";
                                //}

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 13) // Presence of subfield 12
                            {
                                sizeSubfield = 7 * octet;

                                // Se salta

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 14) // Presence of subfield 13
                            {
                                sizeSubfield = 2 * octet;
                                //this.BVR = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring, 2 * octet))) * 6.25).ToString();

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 15) // Presence of subfield 14
                            {
                                sizeSubfield = 2 * octet;

                                //this.GVR = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring, sizeSubfield))) * 6.25).ToString();

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 17) // Presence of subfield 15
                            {
                                sizeSubfield = 2 * octet;

                                //this.RAN = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring, 2 * octet))) * 0.01).ToString();

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;

                            }
                            else if (numSubfield == 18) // Presence of subfield 16
                            {
                                sizeSubfield = 2 * octet;

                                //string strTAR = data.Substring(startSubstring, 2 * octet);

                                //// TI
                                //if (strTAR.Substring(0, 2) == "00")
                                //{
                                //    this.TI = "00 Not available";
                                //}
                                //else if (strTAR.Substring(0, 2) == "01")
                                //{
                                //    this.TI = "01 Left";
                                //}
                                //else if (strTAR.Substring(0, 2) == "10")
                                //{
                                //    this.TI = "10 Right";
                                //}
                                //else if (strTAR.Substring(0, 2) == "11")
                                //{
                                //    this.TI = "11 Straight";
                                //}

                                // TAR
                                //this.TAR = (Convert.ToDouble(TwoCToString(strTAR.Substring(8, 7))) * 0.25).ToString();

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 19) // Presence of subfield 17
                            {
                                sizeSubfield = 2 * octet;

                                //this.TAN = ((Convert.ToInt32(getDecimal(data.Substring(startSubstring, sizeSubfield)))) * (360 / (Math.Pow(2, 16)))).ToString();

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 20) // Presence of subfield 18
                            {
                                sizeSubfield = 2 * octet;

                                //this.GSP = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring, sizeSubfield))) * (Math.Pow(2, -14))).ToString();

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 21) // Presence of subfield 19
                            {
                                sizeSubfield = 1 * octet;

                                //this.VUN = getDecimal(data.Substring(startSubstring, sizeSubfield));

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 22) // Presence of subfield 20
                            {
                                sizeSubfield = 8 * octet;

                                //string strMET = data.Substring(startSubstring, sizeSubfield);

                                //// Validity of Wind Speed
                                //if (strMET.Substring(0, 1) == "0")
                                //{
                                //    this.WS = "0 Not valid Wind Speed";
                                //}
                                //else if (strMET.Substring(0, 1) == "1")
                                //{
                                //    this.WS = "1 Valid Wind Speed";
                                //}

                                //// Validity of wind direction
                                //if (strMET.Substring(1, 1) == "0")
                                //{
                                //    this.WD = "0 Not valid Wind Direction";
                                //}
                                //else if (strMET.Substring(1, 1) == "1")
                                //{
                                //    this.WD = "1 Valid Wind Direction";
                                //}

                                //// Validity of temperature
                                //if (strMET.Substring(2, 1) == "0")
                                //{
                                //    this.TMP = "0 Not valid Temperature";
                                //}
                                //else if (strMET.Substring(2, 1) == "1")
                                //{
                                //    this.TMP = "1 Valid Temperature";
                                //}

                                //// Validity of turbulence
                                //if (strMET.Substring(3, 1) == "0")
                                //{
                                //    this.TRB = "0 Not valid Turbulence";
                                //}
                                //else if (strMET.Substring(3, 1) == "1")
                                //{
                                //    this.TRB = "1 Valid Turbulence";
                                //}

                                //// Wind speed
                                //this.WindSpeed = getDecimal(strMET.Substring(octet, 2 * octet));

                                //// Wind direction
                                //this.WindDirection = getDecimal(strMET.Substring(3 * octet, 2 * octet));

                                //// Temperature
                                //this.Temperature = ((Convert.ToInt32(getDecimal(strMET.Substring(5 * octet, 2 * octet)))) * 0.25).ToString();

                                //// Turbulence
                                //this.Turbulence = getDecimal(strMET.Substring(7 * octet, octet));

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 23) // Presence of subfield 21
                            {
                                sizeSubfield = 1 * octet;

                                //string strEMC = getDecimal(data.Substring(startSubstring, sizeSubfield));

                                //if (strEMC == "1")
                                //{
                                //    this.EMC = "light aircraft ≤ 7000 kg";
                                //}
                                //else if (strEMC == "2")
                                //{
                                //    this.EMC = "reserved";
                                //}
                                //else if (strEMC == "3")
                                //{
                                //    this.EMC = "7000 kg < medium aircraft < 136000 kg";
                                //}
                                //else if (strEMC == "4")
                                //{
                                //    this.EMC = "reserved";
                                //}
                                //else if (strEMC == "5")
                                //{
                                //    this.EMC = "136000 kg ≤ heavy aircraft";
                                //}
                                //else if (strEMC == "6")
                                //{
                                //    this.EMC = "highly manoeuvrable (5g acceleration capability) and high speed (>400 knots cruise)";
                                //}
                                //else if (strEMC == "7")
                                //{
                                //    this.EMC = "reserved";
                                //}
                                //else if (strEMC == "8")
                                //{
                                //    this.EMC = "reserved";
                                //}
                                //else if (strEMC == "9")
                                //{
                                //    this.EMC = "reserved";
                                //}
                                //else if (strEMC == "10")
                                //{
                                //    this.EMC = "rotocraft";
                                //}
                                //else if (strEMC == "11")
                                //{
                                //    this.EMC = "glider / sailplane";
                                //}
                                //else if (strEMC == "12")
                                //{
                                //    this.EMC = "lighter-than-air";
                                //}
                                //else if (strEMC == "13")
                                //{
                                //    this.EMC = "unmanned aerial vehicle";
                                //}
                                //else if (strEMC == "14")
                                //{
                                //    this.EMC = "space / transatmospheric vehicle";
                                //}
                                //else if (strEMC == "15")
                                //{
                                //    this.EMC = "ultralight / handglider / paraglider";
                                //}
                                //else if (strEMC == "16")
                                //{
                                //    this.EMC = "parachutist / skydiver";
                                //}
                                //else if (strEMC == "17")
                                //{
                                //    this.EMC = "reserved";
                                //}
                                //else if (strEMC == "18")
                                //{
                                //    this.EMC = "reserved";
                                //}
                                //else if (strEMC == "19")
                                //{
                                //    this.EMC = "reserved";
                                //}
                                //else if (strEMC == "20")
                                //{
                                //    this.EMC = "surface emergency vehicle";
                                //}
                                //else if (strEMC == "21")
                                //{
                                //    this.EMC = "surface service vehicle";
                                //}
                                //else if (strEMC == "22")
                                //{
                                //    this.EMC = "fixed ground or tethered obstruction";
                                //}
                                //else if (strEMC == "23")
                                //{
                                //    this.EMC = "reserved";
                                //}
                                //else if (strEMC == "24")
                                //{
                                //    this.EMC = "reserved";
                                //}

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 25) // Presence of subfield 22
                            {
                                sizeSubfield = 6 * octet;

                                // Latitude
                                //this.POSLatWGS84 = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring, 3 * octet))) * (180 / Math.Pow(2, 23))).ToString();

                                // Longitude
                                //this.POSLonWGS84 = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring + 3 * octet, 3 * octet))) * (180 / Math.Pow(2, 23))).ToString();

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 26) // Presence of subfield 23
                            {
                                sizeSubfield = 2 * octet;

                                //this.GAL = (Convert.ToDouble(TwoCToString(data.Substring(startSubstring, 2 * octet))) * 6.25).ToString();

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 27) // Presence of subfield 24
                            {
                                sizeSubfield = 1 * octet;

                                //this.PUN = getDecimal(data.Substring(startSubstring + 4, 4));

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 28) // Presence of subfield 25 --------------------------------------------------???????????
                            {
                                sizeSubfield = 9 * octet;

                                //this.REP25 = data.Substring(startSubstring, octet);

                                //this.MB = data.Substring(startSubstring + octet, octet * 7);

                                //this.BDS1 = data.Substring(startSubstring + 8 * octet, 4);

                                //this.BDS2 = data.Substring(startSubstring + 8 * octet + 4, 4);

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 29) // Presence of subfield 26
                            {
                                sizeSubfield = 2 * octet;

                                //this.IAR = getDecimal(data.Substring(startSubstring, sizeSubfield));

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 30) // Presence of subfield 27
                            {
                                sizeSubfield = 2 * octet;

                                //this.MAC = ((Convert.ToInt32(getDecimal(data.Substring(startSubstring, sizeSubfield)))) * 0.008).ToString();

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 31) // Presence of subfield 28
                            {
                                sizeSubfield = 2 * octet;

                                //this.BPS = ((Convert.ToInt32(getDecimal(data.Substring(startSubstring + 4, 12)))) * 0.1).ToString();

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                        }

                        numSubfield++;
                    }

                    size = lenPrimarySubfield + countSecondarySubfield;
                    count += size;
                }

                else if (FRN == 12)
                {
                    size = 2 * octet;
                    this.TrackNumber = getDecimal(data.Substring(count, size));

                    count += size;
                }

                else if (FRN == 13)
                {
                    int nOct = 1;
                    while (data.Substring(count + 7 + octet * (nOct - 1), 1) == "1")
                    {
                        nOct += 1;
                    }

                    size = nOct * octet;
                    //primary13 = data.Substring(count, size);

                    //string sMON = data.Substring(count, 1);
                    //if (sMON == "0") { this.MON = "0 Multisensor track"; }
                    //if (sMON == "1") { this.MON = "1 Monosensor track"; }
                    //string sSPI = data.Substring(count + 1, 1);
                    //if (sSPI == "0") { this.SPI = "0 Default value"; }
                    //if (sSPI == "1") { this.SPI = "1 SPI present in the last report received from asensor capable of decoding this data"; }
                    //string sMRH = data.Substring(count + 2, 1);
                    //if (sMRH == "0") { this.MRH = "0 Barometric altitude (Mode C) more reliable"; }
                    //if (sMRH == "1") { this.MRH = "1 Geometric altitude more reliable"; }
                    //string sSRC = data.Substring(count + 3, 3);
                    //if (sSRC == "000")
                    //{ this.SRC = "000 No source"; }
                    //else if (sSRC == "001")
                    //{ this.SRC = "001 GNSS"; }
                    //else if (sSRC == "010")
                    //{ this.SRC = "010 3D radar"; }
                    //else if (sSRC == "011")
                    //{ this.SRC = "011 Triangulation"; }
                    //else if (sSRC == "100")
                    //{ this.SRC = "100 Height from coverage"; }
                    //else if (sSRC == "101")
                    //{ this.SRC = "101 Speed look-up table"; }
                    //else if (sSRC == "110")
                    //{ this.SRC = "110 Default height"; }
                    //else if (sSRC == "111")
                    //{ this.SRC = "111 Multilateration"; }
                    //string sCNF = data.Substring(count + 6, 1);
                    //if (sCNF == "0") { this.CNF = "0 Confirmed track"; }
                    //if (sCNF == "1") { this.CNF = "1 Tentative track"; }
                    //if (nOct >= 1) //First Extent
                    //{
                    //    string sSIM = data.Substring(count + octet, 1);
                    //    if (sSIM == "0") { this.SIM = "0 Actual track"; }
                    //    if (sSIM == "1") { this.SIM = "1 Simulated track"; }
                    //    string sTSE = data.Substring(count + octet + 1, 1);
                    //    if (sTSE == "0") { this.TSE = "0 Default value"; }
                    //    if (sTSE == "1") { this.TSE = "1 last message transmitted to the user for the track"; }
                    //    string sTSB = data.Substring(count + octet + 2, 1);
                    //    if (sTSB == "0") { this.TSB = "0 Default value"; }
                    //    if (sTSB == "1") { this.TSB = "1 first message transmitted to the user for the track"; }
                    //    string sFPC = data.Substring(count + octet + 3, 1);
                    //    if (sFPC == "0") { this.FPC = "0 Not flight-plan correlated"; }
                    //    if (sFPC == "1") { this.FPC = "1 Flight plan correlated"; }
                    //    string sAFF = data.Substring(count + octet + 4, 1);
                    //    if (sAFF == "0") { this.AFF = "0 Default value"; }
                    //    if (sAFF == "1") { this.AFF = "1 ADS-B data inconsistent with other surveillance information"; }
                    //    string sSTP = data.Substring(count + octet + 5, 1);
                    //    if (sSTP == "0") { this.STP = "0 Default value"; }
                    //    if (sSTP == "1") { this.STP = "1 Slave Track Promotion"; }
                    //    string sKOS = data.Substring(count + octet + 6, 1);
                    //    if (sKOS == "0") { this.KOS = "0 Complementary service used"; }
                    //    if (sKOS == "1") { this.KOS = "1 Background service used"; }
                    //}
                    //if (nOct >= 2) //Second Extent
                    //{
                    //    string sAMA = data.Substring(count + 2 * octet, 1);
                    //    if (sAMA == "0") { this.AMA = "0 track not resulting from amalgamation process"; }
                    //    if (sAMA == "1") { this.AMA = "1 track resulting from amalgamation process"; }
                    //    string sMD4 = data.Substring(count + 2 * octet + 1, 2);
                    //    if (sMD4 == "00") { this.MD4 = "00 No Mode 4 interrogation"; }
                    //    else if (sMD4 == "01") { this.MD4 = "01Friendly target"; }
                    //    else if (sMD4 == "10") { this.MD4 = "10 Unknown target"; }
                    //    else if (sMD4 == "11") { this.MD4 = "11No reply"; }
                    //    string sME = data.Substring(count + 2 * octet + 3, 1);
                    //    if (sME == "0") { this.ME = "0 Default value"; }
                    //    if (sME == "1") { this.ME = "1 Military Emergency present in the last report received from a sensor capable of decoding this data"; }
                    //    string sMI = data.Substring(count + 2 * octet + 4, 1);
                    //    if (sMI == "0") { this.MI = "0 Default value"; }
                    //    if (sMI == "1") { this.MI = "1 Military Identification present in the last report received from a sensor capable of decoding this data"; }
                    //    string sMD5 = data.Substring(count + 2 * octet + 5, 2);
                    //    if (sMD5 == "00") { this.MD5 = "00 No Mode 5 interrogation"; }
                    //    else if (sMD5 == "01") { this.MD5 = "01 Friendly target"; }
                    //    else if (sMD5 == "10") { this.MD5 = "10 Unknown target"; }
                    //    else if (sMD5 == "11") { this.MD5 = "11 No reply"; }

                    //}
                    //if (nOct >= 3) //Third Extent
                    //{
                    //    string sCST = data.Substring(count + 3 * octet, 1);
                    //    if (sCST == "0") { this.CST = "0 Default value"; }
                    //    if (sCST == "1") { this.CST = "1Age of the last received track update is higher than system dependent threshold(coasting)"; }
                    //    string sPSR = data.Substring(count + 3 * octet + 1, 1);
                    //    if (sPSR == "0") { this.PSR = "0 Default value"; }
                    //    if (sPSR == "1") { this.PSR = "1 Age of the last received PSR track update is higher than system dependent threshold"; }
                    //    string sSSR = data.Substring(count + 3 * octet + 2, 1);
                    //    if (sSSR == "0") { this.SSR = "0 Default value"; }
                    //    if (sSSR == "1") { this.SSR = "1 Age of the last received SSR track update is higher than system dependent threshold"; }
                    //    string sMDS = data.Substring(count + 3 * octet + 3, 1);
                    //    if (sMDS == "0") { this.MDS = "0 Default value"; }
                    //    if (sMDS == "1") { this.MDS = "1 Age of the last received Mode S track update is higher than system dependent threshold"; }
                    //    string sADS = data.Substring(count + 3 * octet + 4, 1);
                    //    if (sADS == "0") { this.ADS = "0 Default value"; }
                    //    if (sADS == "1") { this.ADS = "1 Age of the last received ADS-B track update is higher than system dependent threshold"; }
                    //    string sSUC = data.Substring(count + 3 * octet + 5, 1);
                    //    if (sSUC == "0") { this.SUC = "0 Default value"; }
                    //    if (sSUC == "1") { this.SUC = "1 Special Used Code (Mode A codes to be defined in the system to mark a track with special interest)"; }
                    //    string sAAC = data.Substring(count + 3 * octet + 6, 1);
                    //    if (sAAC == "0") { this.AAC = "0 Default value"; }
                    //    if (sAAC == "1") { this.AAC = "1 Assigned Mode A Code Conflict (same discrete Mode A Code assigned to another track)"; }

                    //}
                    //if (nOct >= 4) //Fourth Extent
                    //{
                    //    string sSDS = data.Substring(count + 4 * octet, 2);
                    //    if (sSDS == "00") { this.SDS = "00 Combined"; }
                    //    else if (sSDS == "01") { this.SDS = "01 Co-operative only"; }
                    //    else if (sSDS == "10") { this.SDS = "10 Non-Cooperative only"; }
                    //    else if (sSDS == "11") { this.SDS = "11 Not defined"; }
                    //    string sEMS = data.Substring(count + 4 * octet + 2, 3);
                    //    if (sEMS == "000")
                    //    { this.EMS = "000 No emergency"; }
                    //    else if (sEMS == "001")
                    //    { this.EMS = "001 General emergency"; }
                    //    else if (sEMS == "010")
                    //    { this.EMS = "010 Lifeguard/medical"; }
                    //    else if (sEMS == "011")
                    //    { this.EMS = "011 Minimum fuel"; }
                    //    else if (sEMS == "100")
                    //    { this.EMS = "100 No communications"; }
                    //    else if (sEMS == "101")
                    //    { this.EMS = "101 Unlawful interference"; }
                    //    else if (sEMS == "110")
                    //    { this.EMS = "110 'Downed' Aircraft"; }
                    //    else if (sEMS == "111")
                    //    { this.EMS = "111 Undefined"; }
                    //    string sPFT = data.Substring(count + 4 * octet + 5, 1);
                    //    if (sPFT == "0") { this.PFT = "No indication"; }
                    //    if (sPFT == "1") { this.PFT = "Potential False Track Indication"; }
                    //    string sFPLT = data.Substring(count + 4 * octet + 6, 1);
                    //    if (sFPLT == "0") { this.FPLT = "Default value"; }
                    //    if (sFPLT == "1") { this.FPLT = "Track created / updated with FPL data"; }

                    //}
                    //if (nOct >= 5)    //Fifth Extent
                    //{
                    //    string sDUPT = data.Substring(count + 5 * octet, 1);
                    //    if (sDUPT == "0") { this.DUPT = "0 Default Value"; }
                    //    if (sDUPT == "1") { this.DUPT = "1 Duplicate Mode 3/A Code"; }
                    //    string sDUPF = data.Substring(count + 5 * octet + 1, 1);
                    //    if (sDUPF == "0") { this.DUPF = "0 Default Value"; }
                    //    if (sDUPF == "1") { this.DUPF = "1 Duplicate Flight Plan"; }
                    //    string sDUPM = data.Substring(count + 5 * octet + 2, 1);
                    //    if (sDUPM == "0") { this.DUPM = "0 Default Value"; }
                    //    if (sDUPM == "1") { this.DUPM = "1 Duplicate Flight Plan due to manual correlation"; }
                    //    string sSFC = data.Substring(count + 5 * octet + 3, 1);
                    //    if (sSFC == "0") { this.SFC = "0 Default Value"; }
                    //    if (sSFC == "1") { this.SFC = "1 Surface target"; }
                    //    string sIDD = data.Substring(count + 5 * octet + 4, 1);
                    //    if (sIDD == "0") { this.IDD = "0 Default Value"; }
                    //    if (sIDD == "1") { this.IDD = "1 Duplicate Flight-ID"; }
                    //    string sIEC = data.Substring(count + 5 * octet + 5, 1);
                    //    if (sIEC == "0") { this.IEC = "0 Default Value"; }
                    //    if (sIEC == "1") { this.IEC = "1 Inconsistent Emergency Code"; }
                    //}
                    count += size;
                }

                else if (FRN == 14)
                {
                    string stringBits = data[count..];  // Gets all data from count till finish
                    int lenPrimarySubfield = getVariableSizeMaxSize(stringBits, 4);
                    string primarySubfield = data.Substring(count, lenPrimarySubfield);  // String uptaded to what we need
                    int countSecondarySubfield = 0;
                    int sizeSubfield;
                    int startSubstring = count + lenPrimarySubfield;
                    int numSubfield = 1;
                    this.primary14 = primarySubfield;
                    foreach (char Bit in primarySubfield)
                    {
                        if (Bit.ToString() == "1")
                        {
                            if (numSubfield == 1) // Presence of subfield 1
                            {
                                sizeSubfield = 1 * octet;

                                //string sTRK = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dTRK = Convert.ToDouble(sTRK) * 0.25;
                                //this.TRK = dTRK.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 2) // Presence of subfield 2
                            {
                                sizeSubfield = 1 * octet;

                                //string sPSR = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dPSR = Convert.ToDouble(sPSR) * 0.25;
                                //this.PSR290 = dPSR.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 3) // Presence of subfield 3
                            {
                                sizeSubfield = 1 * octet;

                                //string sSSR = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dSSR = Convert.ToDouble(sSSR) * 0.25;
                                //this.SSR290 = dSSR.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 4) // Presence of subfield 4
                            {
                                sizeSubfield = 1 * octet;

                                //string sMDS = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dMDS = Convert.ToDouble(sMDS) * 0.25;
                                //this.MDS290 = dMDS.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 5) // Presence of subfield 5
                            {
                                sizeSubfield = 2 * octet;

                                //string sADS = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dADS = Convert.ToDouble(sADS) * 0.25;
                                //this.ADS290 = dADS.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 6) // Presence of subfield 6
                            {
                                sizeSubfield = 1 * octet;

                                //string sES = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dES = Convert.ToDouble(sES) * 0.25;
                                //this.ES = dES.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 7) // Presence of subfield 7
                            {
                                sizeSubfield = 1 * octet;

                                //string sVDL = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dVDL = Convert.ToDouble(sVDL) * 0.25;
                                //this.VDL = dVDL.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 9) // Presence of subfield 8
                            {
                                sizeSubfield = 1 * octet;

                                //string sUAT = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dUAT = Convert.ToDouble(sUAT) * 0.25;
                                //this.UAT = dUAT.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 10) // Presence of subfield 9
                            {
                                sizeSubfield = 1 * octet;

                                //string sLOP = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dLOP = Convert.ToDouble(sLOP) * 0.25;
                                //this.LOP = dLOP.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 11) // Presence of subfield 10
                            {
                                sizeSubfield = 1 * octet;

                                //string sMLT = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dMLT = Convert.ToDouble(sMLT) * 0.25;
                                //this.MLT = dMLT.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                        }

                        numSubfield++;
                    }

                    size = lenPrimarySubfield + countSecondarySubfield;
                    count += size;
                }

                else if (FRN == 15)
                {
                    size = 1 * octet;
                    //string TRANS = data.Substring(count, 2);
                    //string LONG = data.Substring(count + 2, 2);
                    //string VERT = data.Substring(count + 4, 2);
                    //string ADF = data.Substring(count + 6, 1);

                    //if (TRANS == "00")
                    //{
                    //    this.TRANS = "00 Constant Course";
                    //}
                    //else if (TRANS == "01")
                    //{
                    //    this.TRANS = "01 Right Turn";
                    //}
                    //else if (TRANS == "10")
                    //{
                    //    this.TRANS = "10 Left Turn";
                    //}
                    //else if (TRANS == "11")
                    //{
                    //    this.TRANS = "11 Undetermined";
                    //}
                    ////////////
                    //if (LONG == "00")
                    //{
                    //    this.LONG = "00 Constant Groundspeed";
                    //}
                    //else if (LONG == "01")
                    //{
                    //    this.LONG = "01 Increasing Groundspeed";
                    //}
                    //else if (LONG == "10")
                    //{
                    //    this.LONG = "10 Decreasing Groundspeed";
                    //}
                    //else if (LONG == "11")
                    //{
                    //    this.LONG = "11 Undetermined";
                    //}
                    ////////////
                    //if (VERT == "00")
                    //{
                    //    this.VERT = "00 Level";
                    //}
                    //else if (VERT == "01")
                    //{
                    //    this.VERT = "01 Climb";
                    //}
                    //else if (VERT == "10")
                    //{
                    //    this.VERT = "10 Descent";
                    //}
                    //else if (VERT == "11")
                    //{
                    //    this.VERT = "11 Undetermined";
                    //}
                    //////////////
                    //if (ADF == "0")
                    //{
                    //    this.ADF = "0 No altitude discrepancy";
                    //}
                    //else if (ADF == "1")
                    //{
                    //    this.ADF = "1 Altitude discrepancy";
                    //}

                    count += size;
                }

                else if (FRN == 16)
                {
                    string stringBits = data[count..];  // Gets all data from count till finish
                    int nOctP = 1;
                    while (data.Substring(count + 7 + octet * (nOctP - 1), 1) == "1")
                    {
                        nOctP += 1;
                    }
                    int lenPrimarySubfield = nOctP * octet;
                    string primarySubfield = data.Substring(count, lenPrimarySubfield);  // String uptaded to what we need
                    int countSecondarySubfield = 0;
                    int sizeSubfield;
                    int startSubstring = count + lenPrimarySubfield;
                    int numSubfield = 1;
                    this.primary16 = primarySubfield;
                    foreach (char Bit in primarySubfield)
                    {
                        if (Bit.ToString() == "1")
                        {
                            if (numSubfield == 1) // Presence of subfield 1
                            {
                                sizeSubfield = 1 * octet;

                                //string sMFL = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dMFL = Convert.ToDouble(sMFL) * 0.25;
                                //this.MFL295 = dMFL.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 2) // Presence of subfield 2
                            {
                                sizeSubfield = 1 * octet;

                                //string sMD1 = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dMD1 = Convert.ToDouble(sMD1) * 0.25;
                                //this.MD1295 = dMD1.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 3) // Presence of subfield 3
                            {
                                sizeSubfield = 1 * octet;

                                //string sMD2 = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dMD2 = Convert.ToDouble(sMD2) * 0.25;
                                //this.MD2295 = dMD2.ToString();

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 4) // Presence of subfield 4
                            {
                                sizeSubfield = 1 * octet;

                                //string sMDA = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dMDA = Convert.ToDouble(sMDA) * 0.25;
                                //this.MDA295 = dMDA.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 5) // Presence of subfield 5
                            {
                                sizeSubfield = 2 * octet;

                                //string sMD4 = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dMD4 = Convert.ToDouble(sMD4) * 0.25;
                                //this.MD4295 = dMD4.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 6) // Presence of subfield 6
                            {
                                sizeSubfield = 1 * octet;

                                //string sMD5 = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dMD5 = Convert.ToDouble(sMD5) * 0.25;
                                //this.MD5295 = dMD5.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 7) // Presence of subfield 7
                            {
                                sizeSubfield = 1 * octet;

                                //string sMHG = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dMHG = Convert.ToDouble(sMHG) * 0.25;
                                //this.MHG295 = dMHG.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 9) // Presence of subfield 8
                            {
                                sizeSubfield = 1 * octet;

                                //string sIAS = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dIAS = Convert.ToDouble(sIAS) * 0.25;
                                //this.IAS295 = dIAS.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 10) // Presence of subfield 9
                            {
                                sizeSubfield = 1 * octet;

                                //string sTAS = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dTAS = Convert.ToDouble(sTAS) * 0.25;
                                //this.TAS295 = dTAS.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 11) // Presence of subfield 10
                            {
                                sizeSubfield = 1 * octet;

                                //string sSAL = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dSAL = Convert.ToDouble(sSAL) * 0.25;
                                //this.SAL295 = dSAL.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 12) // Presence of subfield 11
                            {
                                sizeSubfield = 1 * octet;

                                //string sFSS = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dFSS = Convert.ToDouble(sFSS) * 0.25;
                                //this.FSS295 = dFSS.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 13) // Presence of subfield 12
                            {
                                sizeSubfield = 1 * octet;

                                //string sTID = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dTID = Convert.ToDouble(sTID) * 0.25;
                                //this.TID295 = dTID.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 14) // Presence of subfield 13
                            {
                                sizeSubfield = 1 * octet;

                                //string sCOM = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dCOM = Convert.ToDouble(sCOM) * 0.25;
                                //this.COM295 = dCOM.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 15) // Presence of subfield 14
                            {
                                sizeSubfield = 1 * octet;

                                //string sSAB = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dSAB = Convert.ToDouble(sSAB) * 0.25;
                                //this.SAB295 = dSAB.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 17) // Presence of subfield 15
                            {
                                sizeSubfield = 1 * octet;

                                //string sACS = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dACS = Convert.ToDouble(sACS) * 0.25;
                                //this.ACS295 = dACS.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 18) // Presence of subfield 16
                            {
                                sizeSubfield = 1 * octet;

                                //string sBVR = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dBVR = Convert.ToDouble(sBVR) * 0.25;
                                //this.BVR295 = dBVR.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 19) // Presence of subfield 17
                            {
                                sizeSubfield = 1 * octet;

                                //string sGVR = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dGVR = Convert.ToDouble(sGVR) * 0.25;
                                //this.GVR295 = dGVR.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 20) // Presence of subfield 18
                            {
                                sizeSubfield = 1 * octet;

                                //string sRAN = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dRAN = Convert.ToDouble(sRAN) * 0.25;
                                //this.RAN295 = dRAN.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 21) // Presence of subfield 19
                            {
                                sizeSubfield = 1 * octet;

                                //string sTAR = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dTAR = Convert.ToDouble(sTAR) * 0.25;
                                //this.TAR295 = dTAR.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 22) // Presence of subfield 20
                            {
                                sizeSubfield = 1 * octet;

                                //string sTAN = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dTAN = Convert.ToDouble(sTAN) * 0.25;
                                //this.TAN295 = dTAN.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 23) // Presence of subfield 21
                            {
                                sizeSubfield = 1 * octet;

                                //string sGSP = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dGSP = Convert.ToDouble(sGSP) * 0.25;
                                //this.GSP295 = dGSP.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 25) // Presence of subfield 22
                            {
                                sizeSubfield = 1 * octet;

                                //string sVUN = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dVUN = Convert.ToDouble(sVUN) * 0.25;
                                //this.VUN295 = dVUN.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 26) // Presence of subfield 23
                            {
                                sizeSubfield = 1 * octet;

                                //string sMET = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dMET = Convert.ToDouble(sMET) * 0.25;
                                //this.MET295 = dMET.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 27) // Presence of subfield 24
                            {
                                sizeSubfield = 1 * octet;

                                //string sEMC = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dEMC = Convert.ToDouble(sEMC) * 0.25;
                                //this.EMC295 = dEMC.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 28) // Presence of subfield 25
                            {
                                sizeSubfield = 1 * octet;

                                //string sPOS = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dPOS = Convert.ToDouble(sPOS) * 0.25;
                                //this.POS295 = dPOS.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 29) // Presence of subfield 26
                            {
                                sizeSubfield = 1 * octet;

                                //string sGAL = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dGAL = Convert.ToDouble(sGAL) * 0.25;
                                //this.GAL295 = dGAL.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 30) // Presence of subfield 27
                            {
                                sizeSubfield = 1 * octet;

                                //string sPUN = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dPUN = Convert.ToDouble(sPUN) * 0.25;
                                //this.PUN295 = dPUN.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 31) // Presence of subfield 28
                            {
                                sizeSubfield = 1 * octet;

                                //string sMB = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dMB = Convert.ToDouble(sMB) * 0.25;
                                //this.MB295 = dMB.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 33) // Presence of subfield 29
                            {
                                sizeSubfield = 1 * octet;

                                //string sIAR = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dIAR = Convert.ToDouble(sIAR) * 0.25;
                                //this.IAR295 = dIAR.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 34) // Presence of subfield 30
                            {
                                sizeSubfield = 1 * octet;

                                //string sMAC = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dMAC = Convert.ToDouble(sMAC) * 0.25;
                                //this.MAC295 = dMAC.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                            else if (numSubfield == 35) // Presence of subfield 31
                            {
                                sizeSubfield = 1 * octet;

                                //string sBPS = getDecimal(data.Substring(startSubstring, sizeSubfield));
                                //double dBPS = Convert.ToDouble(sBPS) * 0.25;
                                //this.BPS295 = dBPS.ToString();


                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                        }

                        numSubfield++;
                    }

                    size = lenPrimarySubfield + countSecondarySubfield;
                    count += size;
                }

                else if (FRN == 17)
                {
                    size = 2 * octet;
                    this.MFL = (Convert.ToDouble(TwoCToString(data.Substring(count, 2 * octet))) * 0.25).ToString();
                    count += size;
                }

                else if (FRN == 18)
                {
                    size = 2 * octet;
                    this.GeomAlt = (Convert.ToDouble(TwoCToString(data.Substring(count, 2 * octet))) * 6.25).ToString();
                    count += size;
                }

                else if (FRN == 19)
                {
                    size = 2 * octet;
                    if (getDecimal(data.Substring(count, 1)) == "0") { this.QNH = "0 No QNH correction applied"; }
                    if (getDecimal(data.Substring(count, 1)) == "1") { this.QNH = "1 QNH correction applied"; }
                    count += 1;
                    this.BaromAlt = (Convert.ToDouble(TwoCToString(data.Substring(count, 2 * octet - 1))) * 0.25).ToString();
                    count += size - 1;
                }

                else if (FRN == 20)
                {
                    size = 2 * octet;
                    this.RateClimb = (Convert.ToDouble(TwoCToString(data.Substring(count, 2 * octet))) * 6.25).ToString();
                    count += size;
                }

                else if (FRN == 21)
                {
                    string stringBits = data[count..];  // Gets all data from count till finish
                    int lenPrimarySubfield = getVariableSizeMaxSize(stringBits, 3);
                    string primarySubfield = data.Substring(count, lenPrimarySubfield);  // String uptaded to what we need
                    int countSecondarySubfield = 0;
                    int sizeSubfield;
                    int startSubstring = count + lenPrimarySubfield;
                    int numSubfield = 1;
                    this.primary21 = primarySubfield;
                    foreach (char Bit in primarySubfield)
                    {
                        if (Bit.ToString() == "1")
                        {
                            if (numSubfield == 1) // Presence of subfield 1
                            {
                                sizeSubfield = 2 * octet;

                                this.FPPSSAC = data.Substring(startSubstring, octet);
                                this.FPPSSIC = data.Substring(startSubstring + octet, octet);

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 2) // Presence of subfield 2
                            {
                                sizeSubfield = 7 * octet;

                                string strCallsign = data.Substring(startSubstring, sizeSubfield);

                                this.Callsign = GetBytesFromBinaryString(strCallsign);

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 3) // Presence of subfield 3
                            {
                                sizeSubfield = 4 * octet;

                                string FPS_FLIGHT_ID = data.Substring(startSubstring, sizeSubfield);

                                // TYP
                                string strTYP = FPS_FLIGHT_ID.Substring(0, 2);
                                if (strTYP == "00")
                                {
                                    this.IFPS_TYP = "00 Plan Number";
                                }
                                else if (strTYP == "01")
                                {
                                    this.IFPS_TYP = "01 Unit 1 internal flight number";
                                }
                                else if (strTYP == "10")
                                {
                                    this.IFPS_TYP = "10 Unit 2 internal flight number";
                                }
                                else if (strTYP == "11")
                                {
                                    this.IFPS_TYP = "11 Unit 3 internal flight number";
                                }

                                // NBR
                                this.NBR = getDecimal(FPS_FLIGHT_ID[5..]);

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 4) // Presence of subfield 4
                            {
                                sizeSubfield = 1 * octet;

                                string strFLightCAT = data.Substring(startSubstring, sizeSubfield);

                                //// GAT/OAT
                                //if (strFLightCAT.Substring(0, 2) == "00")
                                //{
                                //    this.GAT_OAT = "00 Unknown";
                                //}
                                //else if (strFLightCAT.Substring(0, 2) == "01")
                                //{
                                //    this.GAT_OAT = "01 General Air Traffic";
                                //}
                                //else if (strFLightCAT.Substring(0, 2) == "10")
                                //{
                                //    this.GAT_OAT = "10 Operational Air Traffic";
                                //}
                                //else if (strFLightCAT.Substring(0, 2) == "11")
                                //{
                                //    this.GAT_OAT = "11 Not applicable";
                                //}

                                // FR1/FR2
                                //if (strFLightCAT.Substring(2, 2) == "00")
                                //{
                                //    this.FR1FR2 = "00 Instrument Flight Rules";
                                //}
                                //else if (strFLightCAT.Substring(2, 2) == "01")
                                //{
                                //    this.FR1FR2 = "01 Visual Flight rules";
                                //}
                                //else if (strFLightCAT.Substring(2, 2) == "10")
                                //{
                                //    this.FR1FR2 = "10 Not applicable";
                                //}
                                //else if (strFLightCAT.Substring(2, 2) == "11")
                                //{
                                //    this.FR1FR2 = "11 Controlled Visual Flight Rules";
                                //}

                                //// RVSM
                                //if (strFLightCAT.Substring(4, 2) == "00")
                                //{
                                //    this.RVSM = "00 Unknown";
                                //}
                                //else if (strFLightCAT.Substring(4, 2) == "01")
                                //{
                                //    this.RVSM = "01 Approved";
                                //}
                                //else if (strFLightCAT.Substring(4, 2) == "10")
                                //{
                                //    this.RVSM = "10 Exempt";
                                //}
                                //else if (strFLightCAT.Substring(4, 2) == "11")
                                //{
                                //    this.RVSM = "11 Not Approved";
                                //}

                                //// HPR
                                //if (strFLightCAT.Substring(6, 1) == "0")
                                //{
                                //    this.HPR = "0 Normal Priority Flight";
                                //}
                                //else if (strFLightCAT.Substring(6, 1) == "1")
                                //{
                                //    this.HPR = "1 High Priority Flight";
                                //}

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 5) // Presence of subfield 5
                            {
                                sizeSubfield = 4 * octet;

                                //string strType = data.Substring(startSubstring, sizeSubfield);
                                //this.TypeOfAircraft = GetBytesFromBinaryString(strType);

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 6) // Presence of subfield 6
                            {
                                sizeSubfield = 1 * octet;

                                //string strWakeTurbulenceCAT = data.Substring(startSubstring, sizeSubfield);

                                //this.WakeTurbulenceCAT = GetBytesFromBinaryString(strWakeTurbulenceCAT);

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 7) // Presence of subfield 7
                            {
                                sizeSubfield = 4 * octet;

                                string strDepartureAirport = data.Substring(startSubstring, sizeSubfield);

                                this.DepartureAirport = GetBytesFromBinaryString(strDepartureAirport);

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 9) // Presence of subfield 8
                            {
                                sizeSubfield = 4 * octet;

                                string strDestinationAirport = data.Substring(startSubstring, sizeSubfield);

                                this.DestinationAirport = GetBytesFromBinaryString(strDestinationAirport);

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 10) // Presence of subfield 9
                            {
                                sizeSubfield = 3 * octet;

                                string strRunway = data.Substring(startSubstring + 2 * octet, octet);
                                string numbers = getDecimal(data.Substring(startSubstring, octet))
                                    + getDecimal(data.Substring(startSubstring + octet, octet));
                                this.RunwayDesignation = numbers + GetBytesFromBinaryString(strRunway);

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 11) // Presence of subfield 10
                            {
                                sizeSubfield = 2 * octet;

                                //this.CFL = (Convert.ToDouble(getDecimal(data.Substring(startSubstring, sizeSubfield))) / 4).ToString();

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 12) // Presence of subfield 11
                            {
                                sizeSubfield = 2 * octet;

                                //this.Centre = getDecimal(data.Substring(startSubstring, octet));

                                //this.Position = getDecimal(data.Substring(startSubstring + octet, octet));

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 13) // Presence of subfield 12
                            {
                                sizeSubfield = 5 * octet;

                                //string strTOD_TOR = data.Substring(startSubstring + octet, 4 * octet);
                                //this.REP290 = getDecimal(data.Substring(startSubstring, octet));
                                //// TYP
                                //string strTYP = getDecimal(strTOD_TOR.Substring(octet, 5));
                                //if (strTYP == "0")
                                //{
                                //    this.TOD_TYP = "Scheduled off-block time";
                                //}
                                //else if (strTYP == "1")
                                //{
                                //    this.TOD_TYP = "Estimated off-block time";
                                //}
                                //else if (strTYP == "2")
                                //{
                                //    this.TOD_TYP = "Estimated take-off time";
                                //}
                                //else if (strTYP == "3")
                                //{
                                //    this.TOD_TYP = "Actual off-block time";
                                //}
                                //else if (strTYP == "4")
                                //{
                                //    this.TOD_TYP = "Predicted time at runway hold";
                                //}
                                //else if (strTYP == "5")
                                //{
                                //    this.TOD_TYP = "Actual time at runway hold";
                                //}
                                //else if (strTYP == "6")
                                //{
                                //    this.TOD_TYP = "Actual line-up time";
                                //}
                                //else if (strTYP == "7")
                                //{
                                //    this.TOD_TYP = "Actual take-off time";
                                //}
                                //else if (strTYP == "8")
                                //{
                                //    this.TOD_TYP = "Estimated time of arrival";
                                //}
                                //else if (strTYP == "9")
                                //{
                                //    this.TOD_TYP = "Predicted landing time";
                                //}
                                //else if (strTYP == "10")
                                //{
                                //    this.TOD_TYP = "Actual landing time";
                                //}
                                //else if (strTYP == "11")
                                //{
                                //    this.TOD_TYP = "Actual time off runway";
                                //}
                                //else if (strTYP == "12")
                                //{
                                //    this.TOD_TYP = "Predicted time to gate";
                                //}
                                //else if (strTYP == "13")
                                //{
                                //    this.TOD_TYP = "Actual on-block time";
                                //}

                                //// DAY
                                //string strDAY = strTOD_TOR.Substring(octet + 5, 2);
                                //if (strDAY == "00")
                                //{
                                //    this.DAY = "00 Today";
                                //}
                                //else if (strDAY == "01")
                                //{
                                //    this.DAY = "01 Yesterday";
                                //}
                                //else if (strDAY == "10")
                                //{
                                //    this.DAY = "10 Tomorrow";
                                //}
                                //else if (strDAY == "11")
                                //{
                                //    this.DAY = "11 Invalid";
                                //}

                                //// HOR
                                //this.HOR = getDecimal(strTOD_TOR.Substring(2 * octet + 3, 5));

                                //// MIN
                                //this.MIN = getDecimal(strTOD_TOR.Substring(3 * octet + 2, 6));

                                //// AVS
                                //if (getDecimal(strTOD_TOR.Substring(4 * octet, 1)) == "0")
                                //{
                                //    this.AVS = "0 Seconds available";
                                //}
                                //else
                                //{
                                //    this.AVS = "1 Seconds not available";
                                //}

                                //// SEC
                                //this.SEC = getDecimal(strTOD_TOR.Substring(4 * octet + 2, 6));

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 14) // Presence of subfield 13
                            {
                                sizeSubfield = 6 * octet;

                                //this.AircraftStand = GetBytesFromBinaryString(data.Substring(startSubstring, sizeSubfield));

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 15) // Presence of subfield 14
                            {
                                sizeSubfield = octet;

                                //string strDAY = data.Substring(startSubstring, 2);
                                //if (strDAY == "00")
                                //{
                                //    this.EMP = "00 Empty";
                                //}
                                //else if (strDAY == "01")
                                //{
                                //    this.EMP = "01 Occupied";
                                //}
                                //else if (strDAY == "10")
                                //{
                                //    this.EMP = "10 Unknown";
                                //}
                                //else if (strDAY == "11")
                                //{
                                //    this.EMP = "11 Invalid";
                                //}
                                //strDAY = data.Substring(startSubstring + 2, 2);
                                //if (strDAY == "00")
                                //{
                                //    this.AVL = "00 Available";
                                //}
                                //else if (strDAY == "01")
                                //{
                                //    this.AVL = "01 Not Available";
                                //}
                                //else if (strDAY == "10")
                                //{
                                //    this.AVL = "10 Unknown";
                                //}
                                //else if (strDAY == "11")
                                //{
                                //    this.AVL = "11 Invalid";
                                //}
                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 17) // Presence of subfield 15
                            {
                                sizeSubfield = 7 * octet;

                                //this.StandardInstrumentDeparture = GetBytesFromBinaryString(data.Substring(startSubstring, sizeSubfield));

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 18) // Presence of subfield 16
                            {
                                sizeSubfield = 7 * octet;

                                //this.StandardInstrumentArrival = GetBytesFromBinaryString(data.Substring(startSubstring, sizeSubfield));

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 19) // Presence of subfield 17
                            {
                                sizeSubfield = 2 * octet;

                                //this.VA = data.Substring(startSubstring + 3, 1);
                                //int sizeNums = 3;
                                //string firstNum = getDecimal(data.Substring(count + 4, sizeNums));
                                //string secondNum = getDecimal(data.Substring(count + 4 + sizeNums, sizeNums));
                                //string thirdNum = getDecimal(data.Substring(count + 4 + 2 * sizeNums, sizeNums));
                                //string fourthNum = getDecimal(data.Substring(count + 4 + 3 * sizeNums, sizeNums));
                                //this.Mode3ARep = firstNum + secondNum + thirdNum + fourthNum;

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }

                            else if (numSubfield == 20) // Presence of subfield 18
                            {
                                sizeSubfield = 7 * octet;

                                //this.PreEmergencyCallsign = GetBytesFromBinaryString(data.Substring(startSubstring, sizeSubfield));

                                countSecondarySubfield += sizeSubfield;
                                startSubstring += sizeSubfield;
                            }
                        }

                        numSubfield++;
                    }

                    size = lenPrimarySubfield + countSecondarySubfield;
                    count += size;
                }
            }
        }
    }
}
