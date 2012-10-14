using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleHL7
{
	/// <summary>
	/// Represents a segment or a group of segments 
	/// </summary>
	public interface IElement
	{

		String Name { get; }

		IElement[] Items { get; set;  }
		

	}
}
