using System;
using System.Linq;

namespace SimpleHL7.Message
{
	public class Segment : IElement
	{
		public String Name { get; private set; }
		public String[] FieldStrings { get; private set; }
		public IField[] Fields { get; private set; }

		private static IElement[] _emptyItems = new IElement[]{};
		public IElement[] Items
		{
			get { return _emptyItems; }
			set { throw new NotImplementedException(); }
		}

		public IField this [int index] {
			get { return Fields[index]; }
		}

		public Segment(String rawText, Context context)
		{
			this.FieldStrings = rawText.Split(context.FieldSeparator);
			this.Name = this.FieldStrings[0];

			// Do some extra processing for MSH segment
			if (this.Name == "MSH")
			{
				// Add an extra field for the field separator itself (MSH-1)
				this.FieldStrings = new String[] { this.Name, context.FieldSeparator.ToString() }.Concat(this.FieldStrings.Skip(1)).ToArray();
				// Set the HL7 version number (MSH-12)
				context.SetHL7Version(this.FieldStrings[12]);
			}

			this.Fields = FieldFactory.GetFields(this.FieldStrings, context).ToArray();

		}

		public override string ToString()
		{
			return Name;
		}
	}
}
