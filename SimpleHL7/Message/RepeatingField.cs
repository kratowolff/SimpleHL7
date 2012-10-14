using System;
using System.Linq;

namespace SimpleHL7.Message
{

	public class RepeatingField : BaseField, IField
	{
		public RepeatingField(String rawText, Context context)
		{
			this._Value = rawText;
			this._Fields = FieldFactory.GetRepeatingFields(rawText, context).ToArray();
		}
	}
}
