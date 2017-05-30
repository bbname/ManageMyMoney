using MMM.Repository.Interfaces;

namespace MMM.Repository
{
    public class GenerateTestMessage : IGenerateTestMessage
    {
        public string GenerateMessage()
        {
            return "Message from Repository Pattern.";
        }
    }
}