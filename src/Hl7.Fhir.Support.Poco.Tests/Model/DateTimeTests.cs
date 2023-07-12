﻿/* 
 * Copyright (c) 2014, Firely (info@fire.ly) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/firely-net-sdk/master/LICENSE
 */

using FluentAssertions;
using Hl7.Fhir.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Hl7.Fhir.Tests.Model
{
    [TestClass]
    public class DateTimeTests
    {
        [TestMethod]
        public void DateTimeHandling()
        {
            FhirDateTime dt = new FhirDateTime("2010-01-01");
            Assert.AreEqual("2010-01-01", dt.Value);

            FhirDateTime dt2 = new FhirDateTime(1972, 11, 30, 15, 10, 0, TimeSpan.Zero);
            Assert.IsTrue(dt2.Value.StartsWith("1972-11-30T15:10"));
            Assert.AreNotEqual(dt2.Value, "1972-11-30T15:10");


            FhirDateTime dtNoMs = new FhirDateTime("2014-12-11T00:00:00+11:00");
            Assert.AreEqual("2014-12-11T00:00:00+11:00", dtNoMs.Value);

            FhirDateTime dtWithMs = new FhirDateTime("2014-12-11T00:00:00.000+11:00");
            Assert.AreEqual("2014-12-11T00:00:00.000+11:00", dtWithMs.Value);

            var stamp = new DateTimeOffset(1972, 11, 30, 15, 10, 0, TimeSpan.Zero);
            dt = new FhirDateTime(stamp);
            Assert.IsTrue(dt.Value.EndsWith("+00:00"));
        }

        //Added for issue #1498
        [TestMethod]
        public void TestTryToDateTimeOffset()
        {
            var fdt = new FhirDateTime(new DateTimeOffset(2021, 3, 18, 12, 22, 35, 999, new TimeSpan(-4, 0, 0)));
            Assert.AreEqual("2021-03-18T12:22:35.999-04:00", fdt.Value);

            Assert.IsTrue(fdt.TryToDateTimeOffset(out var dto1));
            Assert.AreEqual("2021-03-18T12:22:35.9990000-04:00", dto1.ToString("o"));

            fdt = new FhirDateTime(new DateTimeOffset(2021, 3, 18, 12, 22, 35, 999, new TimeSpan(4, 0, 0)));
            Assert.AreEqual("2021-03-18T12:22:35.999+04:00", fdt.Value);

            Assert.IsTrue(fdt.TryToDateTimeOffset(out var dto2));
            Assert.AreEqual("2021-03-18T12:22:35.9990000+04:00", dto2.ToString("o"));

            fdt = new FhirDateTime("2021-03-18T12:22:35.999Z");
            Assert.IsTrue(fdt.TryToDateTimeOffset(out var dto3));
            Assert.AreEqual("2021-03-18T12:22:35.9990000+00:00", dto3.ToString("o"));

            fdt = new FhirDateTime("2021-03-18T12:22:35.1234+04:00");
            Assert.IsTrue(fdt.TryToDateTimeOffset(out var dto4));
            Assert.AreEqual("2021-03-18T12:22:35.1234000+04:00", dto4.ToString("o"));

            fdt = new FhirDateTime("2021-03-18T12:22:35.999");
            Assert.AreEqual("2021-03-18T12:22:35.999", fdt.Value);
            Assert.IsFalse(fdt.TryToDateTimeOffset(out var dto5));
        }

        [TestMethod]
        public void TodayTests()
        {
            var todayLocal = Date.Today();
            Assert.AreEqual(DateTimeOffset.Now.ToString("yyy-MM-dd"), todayLocal.Value);

            var todayUtc = Date.UtcToday();
            Assert.AreEqual(DateTimeOffset.UtcNow.ToString("yyy-MM-dd"), todayUtc.Value);
        }

        [TestMethod]
        public void TestInstantFromUtc()
        {
            Instant ins5 = Instant.FromDateTimeUtc(2011, 3, 4, 16, 45, 33);
            Assert.AreEqual(new DateTimeOffset(2011, 3, 4, 16, 45, 33, TimeSpan.Zero), ins5.Value);
        }

        [TestMethod]
        public void UpdatesCachedValue()
        {
            var dft = new FhirDateTime(2023, 07, 11, 13, 0, 0, TimeSpan.Zero);
            dft.TryToDateTimeOffset(out var dto).Should().BeTrue();
            dft.TryToDateTimeOffset(out var dto2).Should().BeTrue();
            dto.Equals(dto2).Should().BeTrue();

            dft.Value = "2023-07-11T14:00:00Z";
            dft.TryToDateTimeOffset(out dto).Should().BeTrue();
            dto.Hour.Should().Be(14);
            dft.TryToDateTimeOffset(out dto2).Should().BeTrue();
            dto.Equals(dto2).Should().BeTrue();

            dft.ObjectValue = "2023-07-11T15:00:00Z";
            dft.TryToDateTimeOffset(out dto).Should().BeTrue();
            dto.Hour.Should().Be(15);
            dft.TryToDateTimeOffset(out dto2).Should().BeTrue();
            dto.Equals(dto2).Should().BeTrue();

            dft.Value = null;
            dft.TryToDateTimeOffset(out _).Should().BeFalse();
            Assert.ThrowsException<InvalidOperationException>(() => dft.ToDateTimeOffset(TimeSpan.Zero));
        }

        [TestMethod]
        public void ToDateTimeOffsetThrowsInvalidFormat()
        {
            var dft = new FhirDateTime("T45:45:56");

            Assert.ThrowsException<FormatException>(() => dft.ToDateTimeOffset(TimeSpan.Zero));

            dft.TryToDateTimeOffset(out var _).Should().BeFalse();
        }

        [TestMethod]
        public void TimeZoneHandlingWithTZ()
        {
            var dft = new FhirDateTime(2023, 07, 11, 13, 0, 0, TimeSpan.FromHours(1));

            dft.ToDateTimeOffset(TimeSpan.FromHours(2)).Hour.Should().Be(14);

            dft.TryToDateTimeOffset(out var dto).Should().BeTrue();
            dto.Hour.Should().Be(13);  // unchanged

            dft.TryToDateTimeOffset(TimeSpan.FromHours(8), out dto).Should().BeTrue();
            dto.Hour.Should().Be(13);  // unchanged - +8 is a default, but there is a timezone
        }

        [TestMethod]
        public void TimeZoneHandlingNoTZ()
        {
            var dft = new FhirDateTime("2023-07-11T13:00:00");

            // Assume UTC, so +2 is 15:00
            dft.ToDateTimeOffset(TimeSpan.FromHours(2)).Hour.Should().Be(15);
            dft.TryToDateTimeOffset(out _).Should().BeFalse();  // only works with a TZ present.

            dft.TryToDateTimeOffset(TimeSpan.FromHours(1), out var dto).Should().BeTrue();
            dto.Hour.Should().Be(13);  // unchanged
            dto.Offset.Hours.Should().Be(1);
        }

        [TestMethod]
        public void CachesValue()
        {
            var sw = Stopwatch.StartNew();
            var dts = "2023-07-11T13:00:00";
            var dt = new FhirDateTime(dts);

            for (var i = 0; i < 1000; i++)
            {
                // Clear the cache each invocation
                dt.Value = dts;
                _ = dt.TryToDateTimeOffset(TimeSpan.Zero, out var _);
            }

            sw.Stop();
            Console.WriteLine(sw.Elapsed.ToString());

            dt = new FhirDateTime(dts);

            var sw2 = Stopwatch.StartNew();
            for (var i = 0; i < 1000; i++)
            {
                _ = dt.TryToDateTimeOffset(TimeSpan.Zero, out var _);
            }
            sw2.Stop();

            Console.WriteLine(sw2.Elapsed.ToString());

            // On my machine this is actually 200 times faster, but we'll keep a factor 10
            // to ensure caching, but be less sensitive to variations in processor speed.
            (sw2.ElapsedMilliseconds * 10).Should().BeLessThan(sw.ElapsedMilliseconds);
        }
    }
}
