using System.Collections.Generic;

namespace condofy_challenge_API.Shared.Models
{
    public class ObjectReturn
    {
        public ObjectReturn(int? code = null, string status = null)
        {
            Code = code ?? 100;
            Status = status ?? "Processado";
            _messages = new List<string>();
        }

        public int Code { get; private set; }
        public string Status { get; private set; }
        private List<string> _messages { get; set; }
        public IReadOnlyCollection<string> Messagens
        {
            get
            {
                return _messages;
            }
        }

        public void AddMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                return;
            _messages.Add(message);
        }
    }
}
