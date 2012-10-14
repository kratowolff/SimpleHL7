using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleHL7
{
	public interface IField
	{
		String Value { get; }
		IField[] Fields { get; }
		IComponent[] Components { get; }
	}
}
