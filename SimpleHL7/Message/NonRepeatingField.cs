using System;
using System.Linq;

namespace SimpleHL7.Message
{
	public class NonRepeatingField : BaseField, IField
	{
		public NonRepeatingField(String rawText, Context context)
		{
			this._Value = rawText;
			this._Components = ComponentFactory.GetComponents(rawText, context).ToArray();
		}

		
		public override IField[] Fields
		{
			get {
				// Lazy load an array of one FieldItem
				if (_Fields == null)
					_Fields = new IField[] { new FieldItem(this) };
				return _Fields;
			}
		}
	}
}
