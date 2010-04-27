//Copyright

using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using MongoDB.Driver.Platform.Util;
using System.Text;
using System.Linq;
using System.Collections;
using MongoDB.Driver.Command;
using MongoDB.Driver.Command.Admin;
using MongoDB.Driver.Test.Utilities;
namespace MongoDB.Driver.Test
{
    [TestFixture]
    public class AdminCommandTests
    {
        IAdminOperations _Admin = null;
        IServer _Server = null;
        RequestRecorder _Recorder = new RequestRecorder();

        [SetUp]
        public void Setup()
        {
            _Server = Mongo.GetServer(Mongo.DefaultServerBinding);
            _Admin = _Server.Admin;
            _Admin.Binding.ConnectionOptions.ConnectionFactory = (ipEndpoint, options) => _Recorder;
        }

        [Test]
        public void BuildInfoWriteTest()
        {
            BuildInfo bi = _Admin.BuildInfo;
            Console.WriteLine(_Recorder.Message);
            Assert.That(_Recorder.Message, Is.EqualTo("3B-00-00-00-00-00-00-00-00-00-00-00-D4-07-00-00-00-00-00-00-61-64-6D-69-6E-2E-24-63-6D-64-00-00-00-00-00-FF-FF-FF-FF-14-00-00-00-10-62-75-69-6C-64-69-6E-66-6F-00-01-00-00-00-00"));
        }

        [Test]
        public void CloseAllDatabasesTest()
        {
            _Admin.CloseAllDatabases();
            Console.WriteLine(_Recorder.Message);
            Assert.That(_Recorder.Message, Is.EqualTo("43-00-00-00-00-00-00-00-00-00-00-00-D4-07-00-00-00-00-00-00-61-64-6D-69-6E-2E-24-63-6D-64-00-00-00-00-00-FF-FF-FF-FF-1C-00-00-00-10-63-6C-6F-73-65-41-6C-6C-44-61-74-61-62-61-73-65-73-00-01-00-00-00-00"));
        }

        [Test]
        public void CopyDatabaseTest()
        {
            _Admin.CopyDatabase(_Server.GetDatabase("a"), _Server.GetDatabase("b"));
            Console.WriteLine(_Recorder.Message);
            Assert.That(_Recorder.Message, Is.EqualTo("52-00-00-00-00-00-00-00-00-00-00-00-D4-07-00-00-00-00-00-00-61-64-6D-69-6E-2E-24-63-6D-64-00-00-00-00-00-FF-FF-FF-FF-2B-00-00-00-10-63-6F-70-79-64-62-00-01-00-00-00-02-66-72-6F-6D-64-62-00-02-00-00-00-61-00-02-74-6F-64-62-00-02-00-00-00-62-00-00"));
        }

        [Test]
        public void CopyDatabaseGetNonceTest()
        {
            _Admin.CopyDatabaseGetNonce(_Server.GetDatabase("a"));
            Console.WriteLine(_Recorder.Message);
            Assert.That(_Recorder.Message, Is.EqualTo("4E-00-00-00-00-00-00-00-00-00-00-00-D4-07-00-00-00-00-00-00-61-64-6D-69-6E-2E-24-63-6D-64-00-00-00-00-00-FF-FF-FF-FF-27-00-00-00-10-63-6F-70-79-64-62-67-65-74-6E-6F-6E-63-65-00-01-00-00-00-02-66-72-6F-6D-64-62-00-02-00-00-00-61-00-00"));
        }

        [Test]
        public void DiagLoggingTest()
        {
            _Recorder.SetExpectedDocument(new Document("yada", 1));
            _Admin.DiagnosticLoggingLevel = DiagnosticLoggingLevel.LogAllOperations;
            Console.WriteLine(_Recorder.Message);
            Assert.That(_Recorder.Message, Is.EqualTo("3D-00-00-00-00-00-00-00-00-00-00-00-D4-07-00-00-00-00-00-00-61-64-6D-69-6E-2E-24-63-6D-64-00-00-00-00-00-FF-FF-FF-FF-16-00-00-00-10-64-69-61-67-4C-6F-67-67-69-6E-67-00-FF-FF-FF-FF-00"));
        }

        [Test]
        public void FSyncTest()
        {
            _Recorder.SetExpectedDocument(new Document("numFiles", 1));
            _Admin.FSync(false, false);
            Console.WriteLine(_Recorder.Message);
            Assert.That(_Recorder.Message, Is.EqualTo("37-00-00-00-00-00-00-00-00-00-00-00-D4-07-00-00-00-00-00-00-61-64-6D-69-6E-2E-24-63-6D-64-00-00-00-00-00-FF-FF-FF-FF-10-00-00-00-10-66-73-79-6E-63-00-01-00-00-00-00"));
        }

        [Test]
        public void ListDatabasesTest()
        {
            _Recorder.SetExpectedDocument(new Document("databases", new DBObjectArray { new DBObject("name", "admin") }));
            var v = _Admin.Server.DatabaseNames.ToArray();
            Console.WriteLine(_Recorder.Message);
            Assert.That(_Recorder.Message, Is.EqualTo("3F-00-00-00-00-00-00-00-00-00-00-00-D4-07-00-00-00-00-00-00-61-64-6D-69-6E-2E-24-63-6D-64-00-00-00-00-00-FF-FF-FF-FF-18-00-00-00-10-6C-69-73-74-44-61-74-61-62-61-73-65-73-00-01-00-00-00-00"));
        }

        [Test]
        public void OpLoggingTest()
        {
            _Admin.OpLogging = true;
            Console.WriteLine(_Recorder.Message);
            Assert.That(_Recorder.Message, Is.EqualTo("3B-00-00-00-00-00-00-00-00-00-00-00-D4-07-00-00-00-00-00-00-61-64-6D-69-6E-2E-24-63-6D-64-00-00-00-00-00-FF-FF-FF-FF-14-00-00-00-10-6F-70-4C-6F-67-67-69-6E-67-00-01-00-00-00-00"));
        }

        [Test]
        public void QueryTraceLevelTest()
        {
            _Admin.QueryTraceLevel = 42;
            Console.WriteLine(_Recorder.Message);
            Assert.That(_Recorder.Message, Is.EqualTo("41-00-00-00-00-00-00-00-00-00-00-00-D4-07-00-00-00-00-00-00-61-64-6D-69-6E-2E-24-63-6D-64-00-00-00-00-00-FF-FF-FF-FF-1A-00-00-00-10-71-75-65-72-79-54-72-61-63-65-4C-65-76-65-6C-00-2A-00-00-00-00"));
        }

        [Test]
        public void ReplacePeerTest()
        {
            _Admin.ReplacePeer();
            Console.WriteLine(_Recorder.Message);
            Assert.That(_Recorder.Message, Is.EqualTo("3D-00-00-00-00-00-00-00-00-00-00-00-D4-07-00-00-00-00-00-00-61-64-6D-69-6E-2E-24-63-6D-64-00-00-00-00-00-FF-FF-FF-FF-16-00-00-00-10-72-65-70-6C-61-63-65-70-65-65-72-00-01-00-00-00-00"));
        }

        [Test]
        public void ShutdownTest()
        {
            _Admin.Shutdown();
            Console.WriteLine(_Recorder.Message);
            Assert.That(_Recorder.Message, Is.EqualTo("3A-00-00-00-00-00-00-00-00-00-00-00-D4-07-00-00-00-00-00-00-61-64-6D-69-6E-2E-24-63-6D-64-00-00-00-00-00-FF-FF-FF-FF-13-00-00-00-10-73-68-75-74-64-6F-77-6E-00-01-00-00-00-00"));
        }
    }
}