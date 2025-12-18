using System.Runtime.Serialization;

namespace wa_1235_jk_ecm_v4.Repository
{
    [Serializable]
    internal class ApiException : Exception
    {
        public ApiException()
        {
        }

        public ApiException(string? message) : base(message)
        {
        }

        public ApiException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public int StatusCode { get; internal set; }
        public string Content { get; internal set; }
    }
}