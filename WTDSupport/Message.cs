using System;
using System.Collections.Generic;
using System.Text;

namespace WTDSupport
{
    /// <summary>
    /// Message class.<br/>
    /// This class describes error, warning and notice messages.
    /// </summary>
    public class Message
    {
        public readonly MessageCategory type;

        public static readonly Dictionary<MessageType, MessageCategory> MessagePairs = new Dictionary<MessageType, MessageCategory>()
        {
            { MessageType.Unknown, MessageCategory.Unrecognized },
            { MessageType.UnknownNotice, MessageCategory.Notice },
            { MessageType.UnknownWarning, MessageCategory.Warning },
            { MessageType.UnknownError, MessageCategory.Error },
        };
        public Message(MessageCategory type)
        {
            this.type = type;
        }

        public override string ToString()
        {
            // TODO: implementation
            return base.ToString();
        }
    }

    public enum MessageCategory
    {
        Unrecognized,
        Notice,
        Warning,
        Error,
    }

    public enum MessageType
    {
        Unknown,
        UnknownNotice,
        UnknownWarning,
        UnknownError,
    }
}
