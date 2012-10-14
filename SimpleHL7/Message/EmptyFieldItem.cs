using System;

namespace SimpleHL7.Message
{

	/// <summary>
	/// Empty field item.
	/// This is a singleton instance that is used for all empty
	/// field items on the message.
	/// </summary>
	public class EmptyFieldItem : BaseField, IField
	{
		private static EmptyFieldItem _Instance = new EmptyFieldItem();

		public override String Value
		{
			get { return String.Empty; }
		}

		private EmptyFieldItem()
		{
			_Fields = new IField[] { };
			_Components = new Component[] { };
		}

		public static EmptyFieldItem GetInstance()
		{
			return _Instance;
		}

		public override string ToString()
		{
			return String.Empty;
		}
	}
}
