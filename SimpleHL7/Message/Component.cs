using System;
using SimpleHL7.Parser;

namespace SimpleHL7.Message
{

	public class Component : IComponent
	{
		protected String _Value;

		public virtual String Value
		{
			get { return _Value; }
		}

		public Component(String rawText, Context context)
		{
			this._Value = rawText;
		}

		public override string ToString()
		{
			return _Value;
		}
	}

}
