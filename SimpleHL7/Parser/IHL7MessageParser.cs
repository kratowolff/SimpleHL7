using System;
using SimpleHL7.Message;

namespace SimpleHL7.Parser
{
	interface IHL7MessageParser
	{
		IHL7Message ParseMessage(String rawText);
		IHL7Message ParseMessage(String rawText, ParserSettings settings);
	}
}
