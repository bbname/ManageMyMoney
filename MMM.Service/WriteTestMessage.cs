using MMM.Repository.Interfaces;
using MMM.Service.Interfaces;

namespace MMM.Service
{
    public class WriteTestMessage : IWriteTestMessage
    {
        private IGenerateTestMessage _generateTestMessage;
        public WriteTestMessage(IGenerateTestMessage generateTestMessage)
        {
            this._generateTestMessage = generateTestMessage;
        }
        public string GetTestMessage()
        {
            return this._generateTestMessage.GenerateMessage();
        }
    }
}