// using System;
// using NUnit.Framework;
// using UnityEngine;
//
// namespace Source.Tests
// {
//     public class JsonSystemInitializerTests
//     {
//         private StubSystemInitializer _systemInitializer;
//         private JsonSystemInitializer _jsonSystemInitializer;
//
//         [SetUp]
//         public void Setup()
//         {
//             _systemInitializer = new StubSystemInitializer();
//             _jsonSystemInitializer = new JsonSystemInitializer(_systemInitializer);
//         }
//
//         [Test]
//         public void ParseAnalogDevice()
//         {
//             var json = Resources.Load<TextAsset>("Tests/SoloAnalogDevice").text;
//             _jsonSystemInitializer.AddDevices(json);
//             Assert.AreEqual(10, _systemInitializer.AnalogDeviceDto.DurationChange);
//         }
//
//         [Test]
//         public void ParseDiscreteDevice()
//         {
//             var json = Resources.Load<TextAsset>("Tests/SoloDiscreteDevice").text;
//             _jsonSystemInitializer.AddDevices(json);
//             Assert.AreEqual(1, _systemInitializer.DiscreteDeviceDto.Id);
//         }
//
//         [Test]
//         public void ParseEmptyJson()
//         {
//             var json = Resources.Load<TextAsset>("Tests/EmptyJson").text;
//             Assert.Throws<ArgumentNullException>(() => _jsonSystemInitializer.AddDevices(json));
//         }
//
//         [Test]
//         public void ParseJsonWithEmptyDtoType()
//         {
//             var json = Resources.Load<TextAsset>("Tests/JsonWithEmptyDtoType").text;
//             Assert.Throws<ArgumentException>(() => _jsonSystemInitializer.AddDevices(json));
//         }
//
//         [Test]
//         public void ParseJsonWithIncorrectStruct()
//         {
//             var json = Resources.Load<TextAsset>("Tests/JsonWithIncorrectStruct").text;
//             Assert.Throws<Newtonsoft.Json.JsonSerializationException>(() => _jsonSystemInitializer.AddDevices(json));
//         }
//     }
// }