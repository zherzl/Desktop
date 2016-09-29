using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTA_SA_CarHandling.ModelClass
{
    public class Vehicle
    {
        private string vehicleIdentifier;

        public int RowId { get; set; }

        public string VehicleType
        {
            get
            {
                if (RowId >= 287 && RowId <= 299)
                {
                    return "Bikes";
                }
                else if (RowId >= 300 && RowId <= 311)
                {
                    return "Water";
                }
                else if (RowId >= 312 && RowId <= 335)
                {
                    return "Aircrafts";
                }
                return "Land vehicles";
            }
        }

        public string AVehicleIdentifier
        {
            get { return vehicleIdentifier; }
            set
            {
                if (value.Length > 14)
                    throw new Exception("Vehicle length is more than 14 characters long");

                vehicleIdentifier = value;
            }
        }

        public double GMass { get; set; }
        public double GTurnMass { get; set; }
        public double DragMultiplier { get; set; }
        public double GCenterOfMassX { get; set; }
        public double GCenterOfMassY { get; set; }
        public double GCenterOfMassZ { get; set; }
        public int GPercentSubmerged { get; set; }
        public double GCollisionMultiplier { get; set; }
        public int GMonetaryValue { get; set; }
        public string GModelFlags { get; set; }
        public string GHandlingFlags { get; set; }
        public int ENoGears { get; set; }
        public double EMaxVelocity { get; set; }
        public double EEngineAcc { get; set; }
        public double EEngineInertia { get; set; }
        public string EDriveType { get; set; }
        public string EEngineType { get; set; }
        public double EDeceleration { get; set; }
        public double EBrakeBias { get; set; }
        public double ESteeringLock { get; set; }
        public double SForceLevel { get; set; }
        public double SDampingLevel { get; set; }
        public double SHiSpeedComdamp { get; set; }
        public double SUpperLimit { get; set; }
        public double SLowerLimit { get; set; }
        public double SBiasFrontRear { get; set; }
        public double SAntiDriveMultiply { get; set; }
        public double STractionMultiplier { get; set; }
        public double STractionLoss { get; set; }
        public double STractionBias { get; set; }
        public int WFrontLights { get; set; }
        public int WRearLights { get; set; }
        public int WVehicleAnimGroup { get; set; }

        

        public int EBrakeABS { get; internal set; }
        public double WSeatOffsetDist { get; internal set; }
    }


}


//string    COMET   LANDSTAL 	0	;(A) vehicle identifier[14 characters max]
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

