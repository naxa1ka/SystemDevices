using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Source
{
    public sealed class JsonSystemInitializer
    {
        private readonly IMutableSystemDevices _mutableSystemDevices;
        private readonly DeviceBuilderFactory _deviceBuilderFactory;
        private IDeviceBuilder _deviceBuilder;

        public JsonSystemInitializer(IMutableSystemDevices mutableSystemDevices, DeviceBuilderFactory deviceBuilderFactory)
        {
            _mutableSystemDevices = mutableSystemDevices;
            _deviceBuilderFactory = deviceBuilderFactory;
        }

        public void AddDevices(string json)
        {
            if (string.IsNullOrWhiteSpace(json)) throw new ArgumentNullException("Json is empty!");

            var items = JsonConvert.DeserializeObject<List<object>>(json);
            foreach (var item in items)
            {
                _deviceBuilder = _deviceBuilderFactory.Create();
                
                var jsonItem = JsonConvert.SerializeObject(item);
                var baseDeviceDto = JsonConvert.DeserializeObject<BaseDeviceDto>(jsonItem);
                var itemType = baseDeviceDto.Type;

                _deviceBuilder.SetCollisionResolverType(baseDeviceDto.ResolverType);
                
                ParseMoveStrategy(itemType, jsonItem);
                ParseDeviceActions(baseDeviceDto);
              
                _mutableSystemDevices.AddDevice(_deviceBuilder.Build());
            }
        }

        private void ParseMoveStrategy(DeviceDtoType itemType, string jsonItem)
        {
            switch (itemType)
            {
                case DeviceDtoType.AnalogDevice:
                    var analogDeviceDto = GetDeserializeObject<AnalogDeviceDto>(jsonItem);
                    _deviceBuilder.SetMoveStrategy(analogDeviceDto);
                    break;
                case DeviceDtoType.DiscreteDevice:
                    var discreteDeviceDto = GetDeserializeObject<DiscreteDeviceDto>(jsonItem);
                    _deviceBuilder.SetMoveStrategy(discreteDeviceDto);
                    break;
                default:
                    throw new ArgumentException($"Unknown type of dto {itemType}!");
            }
        }

        private void ParseDeviceActions(BaseDeviceDto baseDeviceDto)
        {
            if (baseDeviceDto.DeviceActions != null)
            {
                foreach (var actionItem in baseDeviceDto.DeviceActions)
                {
                    var actionJsonItem = JsonConvert.SerializeObject(actionItem);
                    var actionBaseDeviceDto = JsonConvert.DeserializeObject<BaseDeviceActionDto>(actionJsonItem);
                    var actionItemType = actionBaseDeviceDto.Type;
                    switch (actionItemType)
                    {
                        case DeviceActionDtoType.Rotation:
                            var rotationDeviceDto = GetDeserializeObject<RotationDeviceActionDto>(actionJsonItem);
                            _deviceBuilder.AddRotationToDevice(rotationDeviceDto);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        private T GetDeserializeObject<T>(string jsonItem)
        {
            return JsonConvert.DeserializeObject<T>(jsonItem);
        }
    }
}