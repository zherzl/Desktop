using GTA_SA_CarHandling.ModelClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTA_SA_CarHandling.Model
{
    public class VehicleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Vehicle vehicle;
        public int RowId
        {
            get { return this.vehicle.RowId; }
            set { this.vehicle.RowId = value; }
        }
        public VehicleViewModel(Vehicle vehicle)
        {
            this.vehicle = vehicle;
        }

        public string AVehicleIdentifier
        {
            get { return this.vehicle.AVehicleIdentifier; }
            set
            {
                this.vehicle.AVehicleIdentifier = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("VehicleIdentifier"));
                }
            }
        }

        public double GMass
        {
            get { return this.vehicle.GMass; }
            set
            {
                this.vehicle.GMass = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("GMass"));
                }
            }
        }


        public double GTurnMass
        {
            get { return this.vehicle.GTurnMass; }
            set
            {
                this.vehicle.GTurnMass = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("GTurnMass"));
                }
            }
        }

        
        public double DragMultiplier
        {
            get { return this.vehicle.DragMultiplier; }
            set
            {
                this.vehicle.DragMultiplier = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("DragMultiplier"));
                }
            }
        }

        public double GCenterOfMassX
        {
            get { return this.vehicle.GCenterOfMassX; }
            set
            {
                this.vehicle.GCenterOfMassX = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("GCenterOfMassX"));
                }
            }
        }

        public double GCenterOfMassY
        {
            get { return this.vehicle.GCenterOfMassY; }
            set
            {
                this.vehicle.GCenterOfMassY = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("GCenterOfMassY"));
                }
            }
        }

        public double GCenterOfMassZ
        {
            get { return this.vehicle.GCenterOfMassZ; }
            set
            {
                this.vehicle.GCenterOfMassZ = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("GCenterOfMassZ"));
                }
            }
        }

        public int GPercentSubmerged
        {
            get { return this.vehicle.GPercentSubmerged; }
            set
            {
                this.vehicle.GPercentSubmerged = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("GPercentSubmerged"));
                }
            }
        }

        public double GCollisionMultiplier
        {
            get { return this.vehicle.GCollisionMultiplier; }
            set
            {
                this.vehicle.GCollisionMultiplier = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("GCollisionMultiplier"));
                }
            }
        }

        public int GMonetaryValue
        {
            get { return this.vehicle.GMonetaryValue; }
            set
            {
                this.vehicle.GMonetaryValue = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("GMonetaryValue"));
                }
            }
        }

        public string GModelFlags
        {
            get { return this.vehicle.GModelFlags; }
            set
            {
                this.vehicle.GModelFlags = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("GModelFlags"));
                }
            }
        }

        public string GHandlingFlags
        {
            get { return this.vehicle.GHandlingFlags; }
            set
            {
                this.vehicle.GHandlingFlags = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("GHandlingFlags"));
                }
            }
        }

        public int ENoGears
        {
            get { return this.vehicle.ENoGears; }
            set
            {
                this.vehicle.ENoGears = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("ENoGears"));
                }
            }
        }

        public double EMaxVelocity
        {
            get { return this.vehicle.EMaxVelocity; }
            set
            {
                this.vehicle.EMaxVelocity = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("EMaxVelocity"));
                }
            }
        }

        public double EEngineAcc
        {
            get { return this.vehicle.EEngineAcc; }
            set
            {
                this.vehicle.EEngineAcc = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("EEngineAcc"));
                }
            }
        }

        public double EEngineInertia
        {
            get { return this.vehicle.EEngineInertia; }
            set
            {
                this.vehicle.EEngineInertia = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("EEngineInertia"));
                }
            }
        }

        public string EDriveType
        {
            get { return this.vehicle.EDriveType; }
            set
            {
                this.vehicle.EDriveType = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("EDriveType"));
                }
            }
        }

        public string EEngineType
        {
            get { return this.vehicle.EEngineType; }
            set
            {
                this.vehicle.EEngineType = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("EEngineType"));
                }
            }
        }

        public double EDeceleration
        {
            get { return this.vehicle.EDeceleration; }
            set
            {
                this.vehicle.EDeceleration = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("EDeceleration"));
                }
            }
        }

        public double EBrakeBias
        {
            get { return this.vehicle.EBrakeBias; }
            set
            {
                this.vehicle.EBrakeBias = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("EBrakeBias"));
                }
            }
        }

        public double ESteeringLock
        {
            get { return this.vehicle.ESteeringLock; }
            set
            {
                this.vehicle.ESteeringLock = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("ESteeringLock"));
                }
            }
        }

        public double SForceLevel
        {
            get { return this.vehicle.SForceLevel; }
            set
            {
                this.vehicle.SForceLevel = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("SForceLevel"));
                }
            }
        }

        public double SDampingLevel
        {
            get { return this.vehicle.SDampingLevel; }
            set
            {
                this.vehicle.SDampingLevel = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("SDampingLevel"));
                }
            }
        }

        public double SHiSpeedComdamp
        {
            get { return this.vehicle.SHiSpeedComdamp; }
            set
            {
                this.vehicle.SHiSpeedComdamp = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("SHiSpeedComdamp"));
                }
            }
        }

        public double SUpperLimit
        {
            get { return this.vehicle.SUpperLimit; }
            set
            {
                this.vehicle.SUpperLimit = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("SUpperLimit"));
                }
            }
        }

        public double SLowerLimit
        {
            get { return this.vehicle.GPercentSubmerged; }
            set
            {
                this.vehicle.SLowerLimit = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("SLowerLimit"));
                }
            }
        }

        public double SBiasFrontRear
        {
            get { return this.vehicle.SBiasFrontRear; }
            set
            {
                this.vehicle.SBiasFrontRear = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("SBiasFrontRear"));
                }
            }
        }

        public double SAntiDriveMultiply
        {
            get { return this.vehicle.SAntiDriveMultiply; }
            set
            {
                this.vehicle.SAntiDriveMultiply = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("SAntiDriveMultiply"));
                }
            }
        }

        public double STractionMultiplier
        {
            get { return this.vehicle.STractionMultiplier; }
            set
            {
                this.vehicle.STractionMultiplier = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("STractionMultiplier"));
                }
            }
        }

        public double STractionLoss
        {
            get { return this.vehicle.STractionLoss; }
            set
            {
                this.vehicle.STractionLoss = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("STractionLoss"));
                }
            }
        }

        public double STractionBias
        {
            get { return this.vehicle.STractionBias; }
            set
            {
                this.vehicle.STractionBias = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("STractionBias"));
                }
            }
        }

        public int WFrontLights
        {
            get { return this.vehicle.WFrontLights; }
            set
            {
                this.vehicle.WFrontLights = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("WFrontLights"));
                }
            }
        }

        public int WRearLights
        {
            get { return this.vehicle.WRearLights; }
            set
            {
                this.vehicle.WRearLights = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("WRearLights"));
                }
            }
        }

        public int WVehicleAnimGroup
        {
            get { return this.vehicle.WVehicleAnimGroup; }
            set
            {
                this.vehicle.WVehicleAnimGroup = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("WVehicleAnimGroup"));
                }
            }
        }

        public int EBrakeABS
        {
            get { return this.vehicle.EBrakeABS; }
            set
            {
                this.vehicle.EBrakeABS = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("EBrakeABS"));
                }
            }
        }

        public double WSeatOffsetDist
        {
            get { return this.vehicle.WSeatOffsetDist; }
            internal set
            {
                this.vehicle.WSeatOffsetDist = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("WSeatOffsetDist"));
                }
            }
        }

        public string VehicleRowForSave
        {
            get
            {
                // 0 means mandatory, # optional
                return string.Format
                ("{0} {1:0.0} {2:0.0#} {3:0.0#} {4:0.0#} {5:0.0#} {6:0.0#} {7} {8:0.0#} {9:0.0#} {10:0.0#} " +
                "{11} {12:0.0#} {13:0.0#} {14:0.0#} {15} {16} {17:0.0#} {18:0.0#} {19} {20:0.0#} {21:0.0#} " + 
                "{22:0.0#} {23:0.0#} {24:0.0#} {25:0.0#} {26:0.0#} {27:0.0#} {28:0.0#} {29:0.0#} {30} " + 
                "{31} {32} {33} {34} {35}",
                    AVehicleIdentifier, GMass, GTurnMass, DragMultiplier, GCenterOfMassX, GCenterOfMassY, GCenterOfMassZ, GPercentSubmerged, STractionMultiplier, STractionLoss, STractionBias, 
                    ENoGears, EMaxVelocity, EEngineAcc, EEngineInertia, EDriveType, EEngineType, EDeceleration, EBrakeBias, EBrakeABS, ESteeringLock, 
                    SForceLevel, SDampingLevel, SHiSpeedComdamp, SUpperLimit, SLowerLimit, SBiasFrontRear, SAntiDriveMultiply, WSeatOffsetDist, GCollisionMultiplier, GMonetaryValue, 
                    GModelFlags, GHandlingFlags, WFrontLights, WRearLights, WVehicleAnimGroup + Environment.NewLine
                    );
            }
        }
        
    }


    


    public static class VehiclesViewModel
    {
        static List<Vehicle> Vehicles { get; set; }

        
        public static List<VehicleViewModel> GetVehicles(List<Vehicle> vehicles)
        {
            Vehicles = new List<Vehicle>();

            List<VehicleViewModel> vehiclesVM = new List<VehicleViewModel>();

            vehicles.ForEach(o => vehiclesVM.Add(new VehicleViewModel(o)));

            return vehiclesVM;
        }
    }
}
