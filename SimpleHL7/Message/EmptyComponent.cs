using System;

namespace SimpleHL7.Message
{
	public class EmptyComponent : IComponent
	{
		private static EmptyComponent _Instance = new EmptyComponent();

		public String Value
		{
			get { return String.Empty; }
		}

		private EmptyComponent()
		{ }

		public static EmptyComponent GetInstance()
		{
			return _Instance;
		}

		public override string ToString()
		{
			return String.Empty;
		}
	}

}
