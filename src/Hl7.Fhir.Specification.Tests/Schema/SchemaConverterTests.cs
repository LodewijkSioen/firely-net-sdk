﻿using Hl7.Fhir.ElementModel;
using Hl7.Fhir.FhirPath;
using Hl7.Fhir.Model;
using Hl7.Fhir.Specification.Source;
using Hl7.Fhir.Specification.Specification.Source;
using Hl7.Fhir.Specification.Specification.Terminology;
using Hl7.Fhir.Specification.Terminology;
using Hl7.Fhir.Validation.Schema;
using Hl7.FhirPath;
using Hl7.FhirPath.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T = System.Threading.Tasks;

namespace Hl7.Fhir.Specification.Tests.Schema
{
    [TestClass]
    public class SchemaConverterTests
    {
        private readonly ISchemaResolver _resolver;
        private readonly FhirPathCompiler _fpCompiler;
        private readonly ITerminologyServiceNEW _terminologyService;

        public SchemaConverterTests()
        {
            var localResolver = new CachedResolver(ZipSource.CreateValidationSource());
            _resolver = new ElementSchemaResolver(localResolver);
            _terminologyService = new TerminologyServiceAdapter(new LocalTerminologyService(localResolver));

            var symbolTable = new SymbolTable();
            symbolTable.AddStandardFP();
            symbolTable.AddFhirExtensions();
            _fpCompiler = new FhirPathCompiler(symbolTable);
        }

        private string BigString()
        {
            var sb = new StringBuilder(1024 * 1024);
            for (int i = 0; i < 1024; i++)
            {
                sb.Append("x");
            }

            var sub = sb.ToString();

            sb = new StringBuilder(1024 * 1024);
            for (int i = 0; i < 1024; i++)
            {
                sb.Append(sub);
            }
            sb.Append("more");
            return sb.ToString();
        }


        [TestMethod]
        public async T.Task MyTestMethod()
        {

            var poco = new Patient() { Name = new List<HumanName>() { new HumanName() { Family = BigString() } } };
            var patient = poco.ToTypedElement();

            var schemaElement = await _resolver.GetSchema(new Uri("http://hl7.org/fhir/StructureDefinition/Patient", UriKind.Absolute));
            var json = schemaElement.ToJson().ToString();
            //Debug.WriteLine(json);


            var results = await schemaElement.Validate(new[] { patient }, new ValidationContext() { FhirPathCompiler = _fpCompiler });
            Assert.IsNotNull(results);
            var r = _resolver as ElementSchemaResolver;
            r.DumpCache();
            //Assert.AreEqual(1, results.Count);
            //Assert.AreEqual(0, results[0].Item1.Count);
            //json.ToString(); 

        }

        private string TypedElementAsString(ITypedElement element)
        {
            var json = BuildNode(element);
            return json.ToString();

            JToken BuildNode(ITypedElement elt)
            {
                var result = new JObject
                {
                    { "name", elt.Name },
                    { "type", elt.InstanceType },
                    { "location", elt.Location},
                    { "value", elt.Value?.ToString()},
                    { "definition", elt.Definition == null ? "" : DefintionNode(elt.Definition) }
                };
                result.Add(new JProperty("children", new JArray(elt.Children().Select(c =>
                  BuildNode(c).MakeNestedProp()))));


                return result;
            }

            JToken DefintionNode(IElementDefinitionSummary def)
            {
                var result = new JObject
                {
                    { "elementName", def.ElementName },
                    { "inSummary", def.InSummary },
                    { "isChoiceElement", def.IsChoiceElement },
                    { "isCollection", def.IsCollection },
                    { "isRequired", def.IsRequired },
                    { "isResource", def.IsResource },
                    { "nonDefaultNamespace", def.NonDefaultNamespace },
                    { "order", def.Order }
                };
                return result;
            }

        }

        [TestMethod]
        public async T.Task HumanNameCorrect()
        {
            var poco = HumanName.ForFamily("Visser")
                .WithGiven("Marco")
                .WithGiven("Lourentius");
            poco.Use = HumanName.NameUse.Usual;
            var element = poco.ToTypedElement();

            var schemaElement = await _resolver.GetSchema(new Uri("http://hl7.org/fhir/StructureDefinition/HumanName", UriKind.Absolute));

            var results = await schemaElement.Validate(new[] { element }, new ValidationContext() { TerminologyService = _terminologyService });
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Result.IsSuccessful, "HumanName is valid");
        }

        [TestMethod]
        public async T.Task HumanNameTooLong()
        {
            var poco = HumanName.ForFamily(BigString())
                .WithGiven(BigString())
                .WithGiven("Maria");
            poco.Use = HumanName.NameUse.Usual;
            var element = poco.ToTypedElement();

            var schemaElement = await _resolver.GetSchema(new Uri("http://hl7.org/fhir/StructureDefinition/HumanName", UriKind.Absolute));

            var results = await schemaElement.Validate(new[] { element }, new ValidationContext() { TerminologyService = _terminologyService });
            Assert.IsNotNull(results);
            Assert.IsFalse(results.Result.IsSuccessful, "HumanName is invalid: name too long");
        }

        [TestMethod]
        public async T.Task TestEmptyHuman()
        {
            var poco = new HumanName();
            var element = poco.ToTypedElement();

            var schemaElement = await _resolver.GetSchema(new Uri("http://hl7.org/fhir/StructureDefinition/HumanName", UriKind.Absolute));
            var results = await schemaElement.Validate(new[] { element }, new ValidationContext() { TerminologyService = _terminologyService });
            Assert.IsNotNull(results);
            Assert.IsFalse(results.Result.IsSuccessful, "HumanName is valid, cannot be empty");
        }

        [TestMethod]
        public async T.Task TestInstance()
        {
            var instantSchema = await _resolver.GetSchema(new Uri("http://hl7.org/fhir/StructureDefinition/instant", UriKind.Absolute));

            var instantPoco = new Instant(DateTimeOffset.Now);

            var element = instantPoco.ToTypedElement();

            var result = await instantSchema.Validate(new[] { element }, new ValidationContext() { FhirPathCompiler = _fpCompiler });

            Assert.IsTrue(result.Result.IsSuccessful);
        }

        [TestMethod]
        public async T.Task ValidateMaxStringonFhirString()
        {
            var fhirString = new FhirString(BigString()).ToTypedElement();

            var stringSchema = await _resolver.GetSchema(new Uri("http://hl7.org/fhir/StructureDefinition/string", UriKind.Absolute));

            var results = await stringSchema.Validate(new[] { fhirString }, new ValidationContext() { FhirPathCompiler = _fpCompiler });

            Assert.IsNotNull(results);
            Assert.IsFalse(results.Result.IsSuccessful, "fhirString is not valid");
        }
    }
}
