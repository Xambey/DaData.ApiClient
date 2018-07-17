using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DaData.Http
{
    public class Uri : System.Uri
    {
        public Uri(string uriString, IEnumerable<KeyValuePair<string, object>> queryParameters) : base(uriString.AddQueryParameters(queryParameters))
        {
        }

        public Uri(System.Uri baseUri, string relativeUri, IEnumerable<KeyValuePair<string, object>> queryParameters) : base(baseUri, relativeUri.AddQueryParameters(queryParameters))
        {
            
        }
        
        public Uri(System.Uri baseUri, System.Uri relativeUri, IEnumerable<KeyValuePair<string, object>> queryParameters) : base(baseUri.AddQueryParameters(queryParameters), relativeUri)
        {
        }
        
        //*******************************************************************************************************************************************************************************
        
        protected Uri(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }

        public Uri(string uriString) : base(uriString)
        {
        }

        public Uri(string uriString, UriKind uriKind) : base(uriString, uriKind)
        {
        }

        public Uri(System.Uri baseUri, string relativeUri) : base(baseUri, relativeUri)
        {
        }

        public Uri(System.Uri baseUri, System.Uri relativeUri) : base(baseUri, relativeUri)
        {
        }
    }
}