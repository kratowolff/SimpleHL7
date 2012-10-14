using System;
using SimpleHL7.Message;

namespace SimpleHL7.Parser
{
	public class DelimitedMessageParser : IHL7MessageParser
	{

		public IHL7Message ParseMessage(String rawText)
		{

			IHL7Message msg = new DelimitedMessage(rawText);

			return msg;
		}


		public IHL7Message ParseMessage(string rawText, ParserSettings settings)
		{
			throw new NotImplementedException();
		}


	}
}
