using GTA_SA_CarHandling.CustomControls;
using GTA_SA_CarHandling.Interfaces;
using GTA_SA_CarHandling.Model;
using GTA_SA_CarHandling.ModelClass;
using GTA_SA_CarHandling.Text;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GTA_SA_CarHandling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        StringParser sp;
        ResourceBuilder resourceRdr;
        private string HandlingCfgPath { get; set; }
        private List<string> FileRows { get; set; }
        public List<VehicleViewModel> vm { get; set; }
        public List<VehicleViewModel> vmOrig { get; set; }
        MainContentControl_Copy vehicleControl;

        public MainWindow()
        {
            InitializeComponent();
            sp = new StringParser();

            vm = new List<VehicleViewModel>();
            vmOrig = new List<VehicleViewModel>();

            FileRows = new List<string>();
            resourceRdr = new ResourceBuilder(this);
            HandlingCfgPath = resourceRdr.LoadConfig();
            LoadFileRows();
        }

        // The procedure is:
        // 1. Load file and split every row into array - which is used for creating model and later for saving
        // 2. Send file rows into CreateViewModel method and you get view model for binding (this can be loaded file or original)
        // 3. Original file rows are loaded only by calling GetOriginalFileRows method on string parser class - this should be read only
        private void LoadFileRows()
        {
            try
            {
                // Original file rows not required for so saving, so we'll retreive only view model
                FileRows = sp.StartParsing(HandlingCfgPath);
                vm = sp.CreateViewModelFromArray(FileRows);
                vmOrig = sp.CreateViewModelFromArray(sp.GetOriginalFileRows());

                // Instantiate and add new control into main window
                CreateCustomControl();
            }
            catch (Exception ex)
            {
                SetInfo(ex.Message);
            }
        }

        private void CreateCustomControl()
        {
            vehicleControl = new MainContentControl_Copy(this, vm, vmOrig);

            Grid.SetRow(vehicleControl, 0);
            Grid.SetColumnSpan(vehicleControl, 3);

            MainGrid.Children.Add(vehicleControl);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetInfo(null);
                HandlingCfgPath = resourceRdr.GetFileName(null);
                LoadFileRows();
            }
            catch (Exception ex)
            {
                SetInfo(ex.Message);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetInfo(null);
                sp.WriteHandlingCfg(vm, FileRows, HandlingCfgPath);
            }
            catch (Exception ex)
            {
                SetInfo("Save failed: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            VehicleViewModel car = vehicleControl.GetSelectedCar();
            if (car == null)
            {
                SetInfo("Please select a car before reset !");
                return;
            }
            foreach (var item in vmOrig)
            {
                #region set defaults
                if (item.AVehicleIdentifier.Equals(car.AVehicleIdentifier))
                {
                    car.DragMultiplier = item.DragMultiplier;
                    car.GMass = item.GMass;
                    car.EBrakeBias = item.EBrakeBias;
                    car.EDeceleration = item.EDeceleration;
                    car.EDriveType = item.EDriveType;
                    car.EEngineAcc = item.EEngineAcc;
                    car.EEngineInertia = item.EEngineInertia;
                    car.EEngineType = item.EEngineType;
                    car.EMaxVelocity = item.EMaxVelocity;
                    car.ENoGears = item.ENoGears;
                    car.ESteeringLock = item.ESteeringLock;
                    car.GCenterOfMassX = item.GCenterOfMassX;
                    car.GCenterOfMassY = item.GCenterOfMassY;
                    car.GCenterOfMassZ = item.GCenterOfMassZ;
                    car.GCollisionMultiplier = item.GCollisionMultiplier;
                    car.GHandlingFlags = item.GHandlingFlags;
                    car.GModelFlags = item.GModelFlags;
                    car.GMonetaryValue = item.GMonetaryValue;
                    car.GPercentSubmerged = item.GPercentSubmerged;
                    car.GTurnMass = item.GTurnMass;
                    car.SAntiDriveMultiply = item.SAntiDriveMultiply;
                    car.SBiasFrontRear = item.SBiasFrontRear;
                    car.SDampingLevel = item.SDampingLevel;
                    car.SForceLevel = item.SForceLevel;
                    car.SHiSpeedComdamp = item.SHiSpeedComdamp;
                    car.SLowerLimit = item.SLowerLimit;
                    car.STractionBias = item.STractionBias;
                    car.STractionLoss = item.STractionLoss;
                    car.STractionMultiplier = item.STractionMultiplier;
                    car.SUpperLimit = item.SUpperLimit;
                    car.WFrontLights = item.WFrontLights;
                    car.WRearLights = item.WRearLights;
                    car.WVehicleAnimGroup = item.WVehicleAnimGroup;
                }
                #endregion
            }
        }

        public void SetInfo(string message)
        {
            lblInfo.Text = message;
        }

        

     

        
    }
}
