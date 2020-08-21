using System;

namespace Datastructure
{
    public class Message
    {
        private string _messageText;

        public string MessageText
        {
            get
            {
                if (_messageText == "")
                {
                    _messageText = "Value input null";
                }
                return _messageText;
            }
            set
            {
                _messageText = value;
            }
        }
        public Message(string s)  
        {  
            MessageText = s;  
        }
        
        public override string ToString()  
        {  
            return MessageText;  
        }  
    }
}