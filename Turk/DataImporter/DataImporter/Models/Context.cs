namespace DataImporter.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ImportDataContext : DbContext
    {
        public ImportDataContext()
            : base("name=TesttDataModel")
        {
        }

        public virtual DbSet<SIO2_Logs> SIO2_Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.Filetpye)
                .IsUnicode(false);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.Processmodul)
                .IsUnicode(false);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.Lotnumber)
                .IsUnicode(false);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.Slotnumber)
                .IsUnicode(false);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.ProcessID)
                .IsUnicode(false);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.HeaderWaferID)
                .IsUnicode(false);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.Recipe)
                .IsUnicode(false);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.Machine_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.PCName)
                .IsUnicode(false);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.ParameterProcessTime)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.ChuckDrivePositionCountActual)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.ChuckTempControlDCBiasActVoltage)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.ChuckTempControlSensor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.CurrentStepNumber)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.DCActualCurrent)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.DCActualPower)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.DCActualVoltage)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.DCHardArcPerRun)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.DCMicroArcPerRun)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.DCPowerCorrection)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.DCShieldLifeCounter)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.DCTargetLifeCounter)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.FlexiCathMagnetPositionSensor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.GasVacuumSystemGas1Sensor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.GasVacuumSystemGas3Sensor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.GasVacuumSystemPressureReaderManagerPressure)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.GasVacuumSystemPressureReaderManagerWiderangeGaugeSensor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.MatchingSeriesCapacitorPositionSensor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.MatchingShuntCapacitorPositionSensor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.ProcessTimerTimeCorrection)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.RFBiasDCVoltageSensor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.RFBiasLoadPowerCorrection)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.RFBiasLoadPowerSensor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.RFBiasReflectedPowerSensor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.WaferIDRead)
                .IsUnicode(false);

            modelBuilder.Entity<SIO2_Logs>()
                .Property(e => e.zzEvent)
                .HasPrecision(10, 2);
        }
    }
}
