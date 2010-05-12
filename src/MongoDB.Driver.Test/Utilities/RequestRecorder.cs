using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security;

namespace MongoDB.Driver.Test.Utilities
{
    /// <summary>
    /// A dummy implementation that just string encodes the generated message bytes of each request
    /// </summary>
    public class RequestRecorder : IDBConnection
    {
        public class Response<TDoc> : IDBResponse<TDoc> where TDoc : class, IDocument
        {
            public Response()
            {
                ExpectedDocument = null;
            }
            public void Read(WireProtocolReader reader)
            {
            }

            public IEnumerable<IDocument> Documents
            {
                get
                {
                    if (ExpectedDocument != null)
                    {
                        yield return ExpectedDocument;
                        ExpectedDocument = null;
                    }
                    else
                        yield return new Document(Oid.Empty, null);
                }
            }

            public IDocument ExpectedDocument { get; set; }

            public int MessageLength
            {
                get { return 0; }
            }

            public int RequestID
            {
                get { return 0; }
                set { }
            }

            public int ResponseTo
            {
                get { return 0; }
            }

            public Operation OpCode
            {
                get { return Operation.Reply; }
            }

            public IEnumerable<TDoc> DocumentsT
            {
                get { throw new NotImplementedException(); }
            }
        }

        public IDBResponse ExpectedResponse { get; private set; }

        public RequestRecorder()
        {
            ExpectedResponse = new Response<Document>();
        }
      

        public void SetExpectedDocument<TDoc>(TDoc document) where TDoc : class, IDocument
        {
            Response<TDoc> resp = new Response<TDoc>();
            resp.ExpectedDocument = document;
            ExpectedResponse = resp;
        }

        public IDBResponse<TDoc> Call<TDoc>(IDBRequest msg) where TDoc : class, IDocument
        {
            Say(msg);
            return ExpectedResponse as IDBResponse<TDoc>;
        }

        public void Say(IDBRequest msg)
        {
            msg.RequestID = 0; //
            using (MemoryStream buffer = new MemoryStream())
            using (WireProtocolWriter writer = new WireProtocolWriter(buffer))
            {
                msg.Write(writer);
                Message = BitConverter.ToString(buffer.GetBuffer().Take(Convert.ToInt32(buffer.Length)).ToArray());
            }
        }

        public string Message { get; private set; }

        public void Dispose()
        {
        }

        public bool CanRequest
        {
            get { return true; }
        }

        public bool TryAuthenticate(IDBCollection cmdCollection, string username, SecureString usrPassHash)
        {
            return true;
        }
    }
}
