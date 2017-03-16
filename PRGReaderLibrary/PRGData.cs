using System;

namespace PRGReaderLibrary
{
    public class PRGData
    {
        public int TypeSize { get; set; }
        public int Size1 { get; set; }
        public bool IsEmpty => TypeSize == 0;

        public static PRGData FromBytes(byte[] data)
        {
            var prgData = new PRGData();
            var lenght = data.Length;

            var index = 0;
            if (index + 1 >= lenght)
            {
                return prgData;
            }

            var n1 = BitConverter.ToUInt16(data, index);
            prgData.Size1 = n1;
            index += n1 + 2 + 3;

            if (index + 1 >= lenght)
            {
                return prgData;
            }
            n1 = BitConverter.ToUInt16(data, index);
            index += 2;
            for (var j = 0; j < n1;)
            {
                prgData.TypeSize = 1;
                switch (data[index + j])
                {
                    case TypesConstants.FLOAT_TYPE:
                    case TypesConstants.LONG_TYPE:
                        prgData.TypeSize = 4;
                        break;
                    case TypesConstants.INTEGER_TYPE:
                        prgData.TypeSize = 2;
                        break;
                    default:
                    {
                        switch (data[j])
                        {
                            case TypesConstants.FLOAT_TYPE_ARRAY:
                            case TypesConstants.LONG_TYPE_ARRAY:
                                prgData.TypeSize = 4;
                                break;
                            case TypesConstants.INTEGER_TYPE_ARRAY:
                                prgData.TypeSize = 2;
                                break;
                        }
                        var l1 = data[j + 1] * 256 + data[j + 2];
                        var c1 = data[j + 3] * 256 + data[j + 4];
                        //prgData.TypeSize *= c1 * Math.Max(l1, 1);
                        j += 4;
                    }
                        break;
                }

                j++;
                //memset(&q[j], 0, typeSize);
                j += prgData.TypeSize;
                //j += 1 + strlen(&q[j]);
            }

            //size = reader.ReadUInt16();//time
            //reader.ReadBytes(size);
            //size = reader.ReadUInt16();//ind_remote_local_list

            return prgData;
        }

        public override string ToString()
        {
            return $@"PRGData:
{nameof(TypeSize)}: {TypeSize}
{nameof(Size1)}: {Size1}
{nameof(IsEmpty)}: {IsEmpty}";
        }
    }
}