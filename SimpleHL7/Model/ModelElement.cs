using System;
using System.Xml.Serialization;

namespace SimpleHL7.Model
{
	public abstract class ModelElement : IElement
	{

		[XmlAttribute(AttributeName="name")]
		public String Name { get; set; }

		[XmlIgnore]
		public IElement[] Items { get; set; }

		[XmlAttribute(AttributeName = "isRequired")]
		public Boolean IsRequired { get; set; }

		[XmlAttribute(AttributeName = "canRepeat")]
		public Boolean CanRepeat { get; set; }

		protected ModelElement()
		{
			Items = new IElement[] { };
		}
	}
}
