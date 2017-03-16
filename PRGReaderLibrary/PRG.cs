namespace PRGReaderLibrary
{
    public class PRG
    {
        public string DateTime { get; set; }
        public string Signature { get; set; }
        public ushort PanelNumber { get; set; }
        public ushort NetworkNumber { get; set; }
        public ushort Version { get; set; }
        public ushort MiniVersion { get; set; }
        public long Lenght { get; set; }
        public long Coef { get; set; }
        public ushort AlarmSize { get; set; }
        public ushort AlarmCount { get; set; }
        public char[][] AlarmData { get; set; }

        public string GetInfoString() 
            => $@"Prg File Info:
{nameof(DateTime)}: {DateTime}
{nameof(Signature)}: {Signature}
{nameof(PanelNumber)}: {PanelNumber}
{nameof(NetworkNumber)}: {NetworkNumber}
{nameof(Version)}: {Version}
{nameof(MiniVersion)}: {MiniVersion}
{nameof(Lenght)}: {Lenght}
{nameof(Coef)}: {Coef}
{nameof(AlarmSize)}: {AlarmSize}
{nameof(AlarmCount)}: {AlarmCount}
{nameof(AlarmData)}: {AlarmData}";

    }
}