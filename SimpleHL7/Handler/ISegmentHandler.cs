using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleHL7.Message;

namespace SimpleHL7.Handler
{
	interface ISegmentHandler
	{
		void HandleSegment(Segment segment);

	}
}