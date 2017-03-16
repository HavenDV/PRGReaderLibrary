namespace PRGReaderLibrary
{
    using System.Collections.Generic;

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
        public IList<char[]> Infos { get; set; } = new List<char[]>();
        public IList<PRGData> PrgData { get; set; } = new List<PRGData>();
        public byte[] WrTimes { get; set; }
        public byte[] ArDates { get; set; }
        public IList<byte[]> GrpData { get; set; } = new List<byte[]>();

        public byte[] IconNameTable { get; set; }

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
{nameof(Infos)}: Count: {Infos.Count} - {Infos}
{nameof(PrgData)}: Count: {PrgData.Count} - {PrgData}
{nameof(WrTimes)}: {WrTimes}
{nameof(ArDates)}: {ArDates}
{nameof(GrpData)}: Count: {GrpData.Count} - {GrpData}
{nameof(IconNameTable)}: {IconNameTable}";

        public static PRG Load(string path) => PRGReader.Read(path);
    }
}