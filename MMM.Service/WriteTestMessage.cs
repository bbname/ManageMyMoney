using MMM.Service.Interfaces;

namespace MMM.Service
{
    public class WriteTestMessage : IWriteTestMessage
    {
        public string GetTestMessage()
        {
            return "Sprawdzamy działanie Autofaca";
        }
    }
}