﻿using NUnit.Framework;
using System.IO;
using System.Text;

namespace MoceanTests
{
    public class TestingUtils
    {
        public static string ReadFile(string fileName)
        {
            string text;
            var fileStream = new FileStream(TestContext.CurrentContext.TestDirectory + "/Resources/" + fileName, FileMode.Open, FileAccess.Read);

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }

            return text;
        }
    }
}