﻿using Mocean.Voice;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoceanTests.Voice
{
    [TestFixture]
    public class McccBuilderTest
    {
        [Test]
        public void AddTest()
        {
            var play = new Play
            {
                File = "testing file"
            };

            var builder = new McccBuilder();
            builder.add(play);
            Assert.AreEqual(1, builder.build().Count);
            Assert.AreEqual(play.GetRequestData(), builder.build()[0]);

            play.File = "testing file2";
            builder.add(play);
            Assert.AreEqual(2, builder.build().Count);
            Assert.AreEqual(play.GetRequestData(), builder.build()[1]);
        }
    }
}