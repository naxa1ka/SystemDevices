using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Source
{
    public sealed class JsonSystemInitializer
    {
        private readonly ISystemInitializer _systemInitializer;

        public JsonSystemInitializer(ISystemInitializer systemInitializer)
        {
            _systemInitializer = systemInitializer;
        }

        public void AddDevices(string json)
        {
            if (string.IsNullOrWhiteSpace(json)) throw new ArgumentNullException("Json is empty!");

            var items = JsonConvert.DeserializeObject<List<object>>(json);
            foreach (var item in items)
            {
                var jsonItem = JsonConvert.SerializeObject(item);
                var itemType = JsonConvert.DeserializeObject<BaseDto>(jsonItem).Type;
                switch (itemType)
                {
                    case DtoType.AnalogDevice:
                        AddDevice(GetDeserializeObject<AnalogDeviceDto>(jsonItem));
                        break;
                    case DtoType.DiscreteDevice:
                        AddDevice(GetDeserializeObject<DiscreteDeviceDto>(jsonItem));
                        break;
                    default:
                        throw new ArgumentException($"Unknown type of dto {itemType}!");
                }
            }
        }

        private T GetDeserializeObject<T>(string jsonItem)
        {
            return JsonConvert.DeserializeObject<T>(jsonItem);
        }

        private void AddDevice(AnalogDeviceDto deviceDto)
        {
            _systemInitializer.AddDevice(deviceDto.Id, deviceDto.Position, deviceDto.DurationChange);
        }

        private void AddDevice(DiscreteDeviceDto deviceDto)
        {
            _systemInitializer.AddDevice(deviceDto.Id, deviceDto.Position);
        }
    }
}