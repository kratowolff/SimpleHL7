using System;
using System.Linq;
using SimpleHL7.Parser;

namespace SimpleHL7.Message
{

	/// <summary>
	/// The child object type of a RepeatingField or
	/// NonRepatingField.
	/// </summary>
	public class FieldItem : BaseField, IField
	{
		// TODO: Should this make an empty Array of Fields?
		// ... or just leave Fields null?

		public FieldItem(String rawText, Context context)
		{
			this._Value = rawText;
			this._Components = ComponentFactory.GetComponents(rawText, context).ToArray();			
		}


		public FieldItem(NonRepeatingField parent)
		{
			this._Value = parent.Value;
			this._Components = parent.Components;
		}
	}
}
