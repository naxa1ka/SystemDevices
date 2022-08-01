//я посчитал что будет удобно так сделать, чтобы был общий json для всех устройств, тип которых мы будем различать по enum
//тогда не придется на каждый список различных устройств, создавать отдельные списки конкретных устройств в json`е

using System;

namespace Source
{
    [Serializable]
    public class BaseDto
    {
        public DtoType Type;
    }

    public enum DtoType
    {
        DiscreteDevice = 1,
        AnalogDevice = 2
    }
}