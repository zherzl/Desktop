namespace DataImporter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sputtern.SIO2_Logs")]
    public partial class SIO2_Logs
    {
        [SkipProperty]
        public int ID { get; set; }
        [SkipProperty]
        public DateTime ImportDate { get; set; }

        [SkipProperty]
        [Required]
        public string FileName { get; set; }

        [SkipProperty]
        [Required]
        [StringLength(10)]
        public string Filetpye { get; set; }

        [SkipProperty]
        [Required]
        [StringLength(10)]
        public string Processmodul { get; set; }

        [SkipProperty]
        [Required]
        [StringLength(10)]
        public string Lotnumber { get; set; }

        [SkipProperty]
        [Required]
        [StringLength(2)]
        public string Slotnumber { get; set; }

        [SkipProperty]
        [Required]
        [StringLength(2)]
        public string ProcessID { get; set; }

        [SkipProperty]
        public DateTime DateAndTime { get; set; }

        [SkipProperty]
        [StringLength(15)]
        public string HeaderWaferID { get; set; }

        [SkipProperty]
        [Required]
        public string Recipe { get; set; }

        [SkipProperty]
        [Required]
        [StringLength(10)]
        public string Machine_ID { get; set; }

        [SkipProperty]
        [Required]
        [StringLength(20)]
        public string PCName { get; set; }

        [SkipProperty]
        [Column(TypeName = "numeric")]
        public decimal ParameterProcessTime { get; set; }

        [StringLength(15)]
        [SkipProperty]
        public string WaferIDRead { get; set; }


        #region Calculated values
        [Column(TypeName = "numeric")]
        public decimal ChuckDrivePositionCountActual { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ChuckTempControlDCBiasActVoltage { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ChuckTempControlSensor { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CurrentStepNumber { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DCActualCurrent { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DCActualPower { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DCActualVoltage { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DCHardArcPerRun { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DCMicroArcPerRun { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DCPowerCorrection { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DCShieldLifeCounter { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DCTargetLifeCounter { get; set; }

        [Column(TypeName = "numeric")]
        public decimal FlexiCathMagnetPositionSensor { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GasVacuumSystemGas1Sensor { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GasVacuumSystemGas3Sensor { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GasVacuumSystemPressureReaderManagerPressure { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GasVacuumSystemPressureReaderManagerWiderangeGaugeSensor { get; set; }

        [Column(TypeName = "numeric")]
        public decimal MatchingSeriesCapacitorPositionSensor { get; set; }

        [Column(TypeName = "numeric")]
        public decimal MatchingShuntCapacitorPositionSensor { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ProcessTimerTimeCorrection { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RFBiasDCVoltageSensor { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RFBiasLoadPowerCorrection { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RFBiasLoadPowerSensor { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RFBiasReflectedPowerSensor { get; set; }

        [Column(TypeName = "numeric")]
        public decimal zzEvent { get; set; }
        #endregion


        [SkipProperty]
        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}\t{15}\t{16}\t{17}\t{18}\t{19}\t{20}\t{21}\t{22}\t{23}\t{24}\t{25}\t{26}\t" +
                "{27}\t{28}\t{29}\t{30}\t{31}\t{32}\t{33}\t{34}\t{35}\t{36}\t{37}\t",
                FileName, Filetpye, Processmodul, Lotnumber, Slotnumber, ProcessID, DateAndTime, HeaderWaferID, Recipe, Machine_ID, PCName, ParameterProcessTime, ChuckDrivePositionCountActual, ChuckTempControlDCBiasActVoltage, ChuckTempControlSensor, CurrentStepNumber, DCActualCurrent, DCActualPower, DCActualVoltage, DCHardArcPerRun, DCMicroArcPerRun, DCPowerCorrection, DCShieldLifeCounter, DCTargetLifeCounter, FlexiCathMagnetPositionSensor, GasVacuumSystemGas1Sensor, GasVacuumSystemGas3Sensor, GasVacuumSystemPressureReaderManagerPressure, GasVacuumSystemPressureReaderManagerWiderangeGaugeSensor, MatchingSeriesCapacitorPositionSensor, MatchingShuntCapacitorPositionSensor, ProcessTimerTimeCorrection, RFBiasDCVoltageSensor, RFBiasLoadPowerCorrection, RFBiasLoadPowerSensor, RFBiasReflectedPowerSensor, WaferIDRead, zzEvent);
        }

        [SkipProperty]
        public string HeadersForTxtExport()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}\t{15}\t{16}\t{17}\t{18}\t{19}\t{20}\t{21}\t{22}\t{23}\t{24}\t{25}\t{26}\t" +
                "{27}\t{28}\t{29}\t{30}\t{31}\t{32}\t{33}\t{34}\t{35}\t{36}\t{37}\t",
                "FileName", "Filetpye", "Processmodul", "Lotnumber", "Slotnumber", "ProcessID", "DateAndTime", "HeaderWaferID", "Recipe", "Machine_ID", "PCName", "ParameterProcessTime", "ChuckDrivePositionCountActual", "ChuckTempControlDCBiasActVoltage", "ChuckTempControlSensor", "CurrentStepNumber", "DCActualCurrent", "DCActualPower", "DCActualVoltage", "DCHardArcPerRun", "DCMicroArcPerRun", "DCPowerCorrection", "DCShieldLifeCounter", "DCTargetLifeCounter", "FlexiCathMagnetPositionSensor", "GasVacuumSystemGas1Sensor", "GasVacuumSystemGas3Sensor", "GasVacuumSystemPressureReaderManagerPressure", "GasVacuumSystemPressureReaderManagerWiderangeGaugeSensor", "MatchingSeriesCapacitorPositionSensor", "MatchingShuntCapacitorPositionSensor", "ProcessTimerTimeCorrection", "RFBiasDCVoltageSensor", "RFBiasLoadPowerCorrection", "RFBiasLoadPowerSensor", "RFBiasReflectedPowerSensor", "WaferIDRead", "zzEvent");
        }
    }


    public class SkipPropertyAttribute : Attribute
    {
    }
}
