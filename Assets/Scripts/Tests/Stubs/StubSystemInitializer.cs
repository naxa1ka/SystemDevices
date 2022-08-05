// namespace Source.Tests
// {
//     public class StubSystemInitializer : ISystemInitializer
//     {
//         public DiscreteDeviceDto DiscreteDeviceDto;
//         public AnalogDeviceDto AnalogDeviceDto;
//
//         public void AddDevice(int id, Vector3 initPosition)
//         {
//             DiscreteDeviceDto = new DiscreteDeviceDto()
//             {
//                 Id = id,
//                 Position = initPosition,
//             };
//         }
//
//         public void AddDevice(int id, Vector3 initPosition, float durationChangingPosition)
//         {
//             AnalogDeviceDto = new AnalogDeviceDto()
//             {
//                 DurationChange = durationChangingPosition,
//                 Id = id,
//                 Position = initPosition
//             };
//         }
//     }
// }