using System.Collections.Generic;

namespace SimpleHL7.Message
{
	public interface IHL7Message : IElement
	{
		Context Context { get; }
		string MessageEvent { get; set; }
		string MessageType { get; set; }
		string RawText { get; }
		IEnumerable<Segment> AllSegments { get; }
	}
}
