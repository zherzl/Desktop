using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA_SA_CarHandling.ModelClass;

namespace GTA_SA_CarHandling.Text
{
    class StringParser
    {

        public StringParser()
        {
        }

        public List<string> StartParsing(string fileToParse)
        {
            List<string> fileRows = new List<string>();
            StreamReader sr = new StreamReader(fileToParse);
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                fileRows.Add(line);
            }

            sr.Close();
            return fileRows;
        }


        public static string LineStart(int RowId)
        {
            if (RowId >= 287 && RowId <= 299)
            {
                return "! ";
            }
            else if (RowId >= 300 && RowId <= 311)
            {
                return "% ";
            }
            else if (RowId >= 312 && RowId <= 335)
            {
                return "$ ";
            }

            return "";
        }

        internal List<Vehicle> ParseVehicleRows(List<string> fileRows)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            // 77 to 287 cars only..bike etc not explained in handling.cfg
            for (int i = 77; i <= 287; i++)
            {
                string lineStart = LineStart(i);

                //if (lineStart != "")
                //    fileRows[i] = fileRows[i].Replace(lineStart, "");

                // Take only car data
                if (lineStart == "")
                {
                    string[] row = fileRows[i].Replace('.', ',').Split(' ');
                    Vehicle v = new Vehicle();
                    
                    v.RowId = i;

                    v.AVehicleIdentifier = row[0];
                    v.GMass = double.Parse(row[1]);
                    v.GTurnMass = double.Parse(row[2]);
                    v.DragMultiplier = double.Parse(row[3]);
                    v.GCenterOfMassX = double.Parse(row[4]);
                    v.GCenterOfMassY = double.Parse(row[5]);
                    v.GCenterOfMassZ = double.Parse(row[6]);
                    v.GPercentSubmerged = (int)double.Parse(row[7]);
                    v.STractionMultiplier = double.Parse(row[8]);
                    v.STractionLoss = double.Parse(row[9]);
                    v.STractionBias = double.Parse(row[10]);
                    v.ENoGears = (int)double.Parse(row[11]);
                    v.EMaxVelocity = double.Parse(row[12]);
                    v.EEngineAcc = double.Parse(row[13]);
                    v.EEngineInertia = double.Parse(row[14]);
                    v.EDriveType = row[15];
                    v.EEngineType = row[16];
                    v.EDeceleration = double.Parse(row[17]);
                    v.EBrakeBias = double.Parse(row[18]);
                    v.EBrakeABS = int.Parse(row[19]);
                    v.ESteeringLock = double.Parse(row[20]);
                    v.SForceLevel = double.Parse(row[21]);
                    v.SDampingLevel = double.Parse(row[22]);
                    v.SHiSpeedComdamp = double.Parse(row[23]);
                    v.SUpperLimit = double.Parse(row[24]);
                    v.SLowerLimit = double.Parse(row[25]);
                    v.SBiasFrontRear = double.Parse(row[26]);
                    v.SAntiDriveMultiply = double.Parse(row[27]);
                    v.WSeatOffsetDist = double.Parse(row[28]);
                    v.GCollisionMultiplier = double.Parse(row[29]);
                    v.GMonetaryValue = int.Parse(row[30]);
                    v.GModelFlags = row[31];
                    v.GHandlingFlags = row[32];
                    v.WFrontLights = int.Parse(row[33]);
                    v.WRearLights = int.Parse(row[34]);
                    v.WVehicleAnimGroup = int.Parse(row[35]);

                    vehicles.Add(v);
                }
            }

            return vehicles;
        }
    }
}




//string COMET   LANDSTAL 	0	;(A) vehicle identifier[14 characters max]
//double	1	1400.0 	1700.0 	1	;(B) fMass[1.0 to 50000.0]
//double	1	2200.0 	5008.3 	2	;(C) fTurnMass             //was////Dimensions.x               [0.0 > x > 20.0]
//double	1	2.2 	2.5 	3	;(D) fDragMult             //was////Dimensions.y               [0.0 > x > 20.0]
//double	1	0.0 	0.0 	4	;(F) CentreOfMass.x[-10.0 > x > 10.0]
//double	1	0.1 	0.0 	5	;(G) CentreOfMass.y[-10.0 > x > 10.0]
//double	1	-0.2 	-0.3 	6	;(H) CentreOfMass.z[-10.0 > x > 10.0]
//int		    75 	    85 	    7	;(I) nPercentSubmerged[10 to 120]
//double	2	0.70 	0.75 	8	;(J) fTractionMultiplier[0.5 to 2.0]
//double	2	0.9 	0.85 	9	;(K) fTractionLoss[0.0 > x > 1.0]
//double	1	0.5 	0.5 	10	;(L) fTractionBias[0.0 > x > 1.0]
//int		    5 	    5 	    11	;(M) TransmissionData.nNumberOfGears[1 to 4]
//double	1	200.0 	160.0 	12	;(N) TransmissionData.fMaxVelocity[5.0 to 150.0]
//double	1	30.0 	25.0 	13	;(O) TransmissionData.fEngineAcceleration[0.1 to 10.0]
//double	1	10.0 	20.0 	14	;(P) TransmissionData.fEngineInertia[0.0 to 50.0]
//string		4 	    4 	    15	;(Q) TransmissionData.nDriveType[F / R / 4]
//string      P       D 	    16	;(R) TransmissionData.nEngineType[P / D / E]
//double	1	11.0 	6.2 	17	;(S) fBrakeDeceleration[0.1 to 10.0]
//double	2	0.45 	0.60 	18	;(T) fBrakeBias[0.0 > x > 1.0]
//double	1	0 	    0 	    19	;(U) bABS[0 / 1]
//double	1	30.0 	35.0 	20	;(V) fSteeringLock[10.0 to 40.0]
//double	1	1.4 	2.4 	21	;(a) fSuspensionForceLevel not[L / M / H]
//double	2	0.14 	0.08 	22	;(b) fSuspensionDampingLevel not[L / M / H]
//double	1	3.0 	0.0 	23	;(c) fSuspensionHighSpdComDamp often zero - 200.0 or more for bouncy vehicles
//double	2	0.28 	0.28 	24	;(d) suspension upper limit
//double	2	-0.15 	-0.14 	25	;(e) suspension lower limit
//double	1	0.5 	0.5 	26	;(f) suspension bias between front and rear
//double	2	0.3 	0.25 	27	;(g) suspension anti-dive multiplier
//double	2	0.25 	0.27 	28	;(aa) fSeatOffsetDistance          // ped seat position offset towards centre of car
//double	2	0.60 	0.23 	29	;(ab) fCollisionDamageMultiplier[0.2 to 5.0]
//int		    35000 	25000 	30	;(ac) nMonetaryValue[1 to 100000]
//string		40000800 	20 	31	;(af) modelFlags!!!  WARNING - Now written HEX for easier reading of flags
//int		        0 	500002 	32	handling flags 1
//int		        1 	    0 	33	fLight 2
//int		        1 	    1 	34	rLight 3
//int		        19 	    0 	35	vehicle anim group 4
