using System;

namespace SimpleHL7.Message
{

	public abstract class BaseField : IField
	{
		protected String _Value;
		protected IField[] _Fields;
		protected IComponent[] _Components;

		public virtual String Value {
			get { return _Value;  }
		}
		
		public virtual IField[] Fields {
			get { return _Fields; }
		}

		public virtual IComponent[] Components
		{
			get { return _Components; }
		}

		public override string ToString()
		{
			return _Value;
		}

		protected BaseField()
		{ }
	}

}
