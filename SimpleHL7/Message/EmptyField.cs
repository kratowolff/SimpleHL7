using System;

namespace SimpleHL7.Message
{
	/// <summary>
	/// Empty field.
	/// This is a singleton instance that is used for all empty
	/// fields on the message.
	/// </summary>
	public class EmptyField : BaseField, IField
	{
		private static EmptyField _Instance = new EmptyField();

		public override String Value
		{
			get { return String.Empty; }
		}


		private EmptyField()
		{
			_Fields = new IField[] { EmptyFieldItem.GetInstance() };
			_Components = new IComponent[] { EmptyComponent.GetInstance() };
		}

		public static EmptyField GetInstance()
		{
			return _Instance;
		}

		public override string ToString()
		{
			return String.Empty;
		}
	}
}
