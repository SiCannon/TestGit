using System;
using System.Diagnostics;
using dotless.Core;
using dotless.Core.configuration;
using dotless.Core.Loggers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestGit.Tests
{
    [TestClass]
    public class dotlessTests
    {
        [TestMethod]
        public void Can_Parse_Simple()
        {
            string less = "div { width: 1 + 1 }";
            string css = Less.Parse(less);
            Debug.WriteLine(css);
        }

        [TestMethod]
        public void Can_Fail()
        {
            string less = "nonsense";
            string css = Less.Parse(less, getConfig());
            Debug.WriteLine(css);
        }

        [TestMethod]
        public void Can_Parse_Variable()
        {
            string less = @"
                @x: 10px;
                div {
                    font-size: @x;
                }
            ";
            string css = Less.Parse(less);
            Debug.WriteLine(css);
        }

        [TestMethod]
        public void Can_Parse_Divisor_FontSize()
        {
            string less = "@x: 10px; div { font-size: @x/1; }";
            string css = Less.Parse(less);
            Assert.IsFalse(string.IsNullOrEmpty(css));
            Debug.WriteLine(css);
        }

        [TestMethod]
        public void Can_Parse_Divisor_Font()
        {
            string less = "@x: 10px; div { font: @x/2 serif; }";
            string css = Less.Parse(less, getConfig());
            Assert.IsFalse(string.IsNullOrEmpty(css));
            string expected = @"div {
  font: 10px/2 serif;
}
".Replace("\r", "");
            Assert.AreEqual(expected, css);
            Debug.WriteLine(css);
        }

        DotlessConfiguration getConfig()
        {
            return new DotlessConfiguration
            {
                Logger = typeof(Logger)
            };
        }

        class Logger: ILogger
        {
            private void LogMessage(string message)
            {
                System.Diagnostics.Debug.WriteLine(message);
                Console.WriteLine(message);
            }

            public void Debug(string message, params object[] args)
            {
                throw new NotImplementedException();
            }

            public void Debug(string message)
            {
                LogMessage(message);
            }

            public void Error(string message, params object[] args)
            {
                throw new NotImplementedException();
            }

            public void Error(string message)
            {
                LogMessage(message);
            }

            public void Info(string message, params object[] args)
            {
                throw new NotImplementedException();
            }

            public void Info(string message)
            {
                throw new NotImplementedException();
            }

            public void Log(LogLevel level, string message)
            {
                throw new NotImplementedException();
            }

            public void Warn(string message, params object[] args)
            {
                throw new NotImplementedException();
            }

            public void Warn(string message)
            {
                throw new NotImplementedException();
            }
        }

    }
}
