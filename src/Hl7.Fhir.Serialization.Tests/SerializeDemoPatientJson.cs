﻿using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization.Poco;
//using Hl7.Fhir.Serialization.Poco;
using Hl7.Fhir.Specification;
using Hl7.Fhir.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Hl7.Fhir.Serialization.Tests
{
    [TestClass]
    public class SerializeDemoPatientJson
    {
        public ITypedElement getJsonElement(string json, FhirJsonParsingSettings s = null) =>
            JsonParsingHelpers.ParseToTypedElement(json, new PocoStructureDefinitionSummaryProvider(), settings: s);

        [TestMethod]
        public void CanSerializeThroughNavigatorAndCompare()
        {
            var json = File.ReadAllText(Path.Combine("TestData", "fp-test-patient.json"));

            var nav = getJsonElement(json);
            var output = nav.ToJson();

            List<string> errors = new List<string>();
            JsonAssert.AreSame(@"TestData\fp-test-patient.json", json, output, errors);
            Console.WriteLine(String.Join("\r\n", errors));
            Assert.AreEqual(0, errors.Count, "Errors were encountered comparing converted content");
        }

        [TestMethod]
        public void UseGeneratedSerializer()
        {
            // practitionerrole-example.json: Number of elements are not the same in container 
            var filename = Path.Combine("TestData", "practitionerrole-example.json");

            var expected = File.ReadAllText(filename);
            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStreamResourceConverter());

            var resource = JsonSerializer.Deserialize<Resource>(expected, options);
            //var resource = JsonSerializer.Deserialize<PractitionerRole>(jsonR, options);

            var actual = JsonSerializer.Serialize(resource, options);

            var errors = new List<string>();
            JsonAssert.AreSame(filename, expected, actual, errors);
            Console.WriteLine(String.Join("\r\n", errors));
            Assert.AreEqual(0, errors.Count, "Errors were encountered comparing converted content");
        }

        [TestMethod]
        public void UseDynamicSerializer()
        {
            // practitionerrole-example.json: Number of elements are not the same in container 
            var filename = Path.Combine("TestData", "json-edge-cases.json");
            var expected = File.ReadAllText(filename);

            var fhirConverter = new JsonFhirConverter(typeof(Patient).Assembly);
            var options = new JsonSerializerOptions();
            options.Converters.Add(fhirConverter);
            Resource poco = JsonSerializer.Deserialize<Resource>(expected, options);
            string actual = JsonSerializer.Serialize(poco, options);

            var errors = new List<string>();
            JsonAssert.AreSame(filename, expected, actual, errors);
            Console.WriteLine(String.Join("\r\n", errors));
            Assert.AreEqual(0, errors.Count, "Errors were encountered comparing converted content");
        }

        [TestMethod]
        public void TestPruneEmptyNodes()
        {
            var tp = File.ReadAllText(Path.Combine("TestData", "test-empty-nodes.json"));

            // Make sure permissive parsing is on - otherwise the parser will complain about all those empty nodes
            var nav = getJsonElement(tp, new FhirJsonParsingSettings { PermissiveParsing = true });

            var output = nav.ToJson();
            var doc = JObject.Parse(output);
            Assert.AreEqual(17, doc.DescendantsAndSelf().Count());
        }


        [TestMethod]
        public void CanSerializeFromPoco()
        {
            var tp = File.ReadAllText(Path.Combine("TestData", "fp-test-patient.json"));
            var pser = new FhirJsonParser(new ParserSettings { DisallowXsiAttributesOnRoot = false });
            var pat = pser.Parse<Patient>(tp);

            var output = pat.ToJson();

            List<string> errors = new List<string>();
            JsonAssert.AreSame(@"TestData\fp-test-patient.json", tp, output, errors);
            Console.WriteLine(String.Join("\r\n", errors));
            Assert.AreEqual(0, errors.Count, "Errors were encountered comparing converted content");
        }

        [TestMethod]
        public void DoesPretty()
        {
            var json = File.ReadAllText(Path.Combine("TestData", "fp-test-patient.json"));

            var nav = getJsonElement(json);
            var output = nav.ToJson();
            Assert.IsFalse(output.Substring(0, 20).Contains('\n'));
            var pretty = nav.ToJson(new FhirJsonSerializationSettings { Pretty = true });
            Assert.IsTrue(pretty.Substring(0, 20).Contains('\n'));

            var p = (new FhirJsonParser()).Parse<Patient>(json);
            output = (new FhirJsonSerializer(new SerializerSettings { Pretty = false })).SerializeToString(p);
            Assert.IsFalse(output.Substring(0, 20).Contains('\n'));
            pretty = (new FhirJsonSerializer(new SerializerSettings { Pretty = true, AppendNewLine = true })).SerializeToString(p);
            Assert.IsTrue(pretty.Substring(0, 20).Contains('\n'));
        }

        [TestMethod]
        public void TestAppendNewLine()
        {
            var json = File.ReadAllText(Path.Combine("TestData", "fp-test-patient.json"));

            var nav = getJsonElement(json);
            var output = nav.ToJson();
            Assert.IsFalse(output.Contains('\n'));
            var pretty = nav.ToJson(new FhirJsonSerializationSettings { Pretty = true });
            Assert.IsTrue(pretty.Contains('\n'));
            var lastLine = pretty.Split('\n').Last();
            Assert.IsFalse(string.IsNullOrEmpty(lastLine));

            var p = (new FhirJsonParser()).Parse<Patient>(json);
            output = (new FhirJsonSerializer(new SerializerSettings { Pretty = false, AppendNewLine = true })).SerializeToString(p);
            lastLine = output.Split('\n').Last();
            Assert.IsTrue(string.IsNullOrEmpty(lastLine));
            pretty = (new FhirJsonSerializer(new SerializerSettings { Pretty = true, AppendNewLine = true })).SerializeToString(p);
            lastLine = pretty.Split('\n').Last();
            Assert.IsTrue(string.IsNullOrEmpty(lastLine));
        }
    }
}