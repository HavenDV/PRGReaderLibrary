namespace PRGReaderLibrary
{
    using System;
    using System.IO;
    using System.Text;

    public static class PRGReader
    {
        public static PRG Read(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException($"File not exists: {path}", nameof(path));
            }

            using (var stream = File.OpenRead(path))
            {
                using (var reader = new BinaryReader(stream, Encoding.ASCII))
                {
                    var prg = new PRG();
                    prg.DateTime = new string(reader.ReadChars(26));
                    prg.Signature = new string(reader.ReadChars(4));
                    if (!prg.Signature.Equals(Constants.Signature, StringComparison.Ordinal))
                    {
                        throw new Exception($"File corrupted. {prg.GetInfoString()}");
                    }

                    prg.PanelNumber = reader.ReadUInt16();
                    prg.NetworkNumber = reader.ReadUInt16();
                    prg.Version = reader.ReadUInt16();
                    prg.MiniVersion = reader.ReadUInt16();
                    reader.ReadBytes(32); // reserved bytes

                    if (prg.Version < 210 || prg.Version == 0x2020)
                    {
                        throw new Exception($"File not loaded. File version less than 2.10. {prg.GetInfoString()}");
                    }

                    prg.Lenght = stream.Length;
                    prg.Coef = ((prg.Lenght * 1000L) / 20000L) * 1000L +
                        (((prg.Lenght * 1000L) % 20000L) * 1000L) / 20000L;
                    //float coef = (float)length/20.;

                    var ltot = 0L;
                    var max_prg = 0;
                    var max_grp = 0;

                    for (var i = Constants.OUT; i <= Constants.UNIT; ++i)
                    {
                        if (i == Constants.DMON)
                        {
                            continue;
                        }

                        if (i == Constants.AMON)
                        {
                            if (prg.Version < 230 && prg.MiniVersion >= 230)
                            {
                                throw new Exception($"Versions conflict! {prg.GetInfoString()}");
                            }
                            if (prg.Version >= 230 && prg.MiniVersion > 0)
                                continue;
                        }

                        if (i == Constants.ALARMM)
                        {
                            if (prg.Version < 216)
                            {
                                prg.AlarmSize = reader.ReadUInt16();
                                prg.AlarmCount = reader.ReadUInt16();
                                for (var j = 0; j < prg.AlarmCount; ++j)
                                {
                                    prg.AlarmData[j] = reader.ReadChars(prg.AlarmSize);
                                }
                                continue;
                            }
                        }
                        else
                        {
                            var size = reader.ReadUInt16();
                            var count = reader.ReadUInt16();
                            if (i == Constants.PRG || i == Constants.GRP)
                            {
                                max_prg = size;
                            }
                            //if (count == info[i].str_size)
                            {
                               // fread(info[i].address, nitem, l, h);
                            }

                            ltot += size * count + 2;
                        }
                    }

                    return prg;
                }
            }
        }
    }
}
