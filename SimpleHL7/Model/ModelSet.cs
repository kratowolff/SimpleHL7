using System;
using System.Xml.Serialization;

namespace SimpleHL7.Model
{
	/// <summary>
	/// Contains the set of Message Models for a particular HL7 version.
	/// </summary>
	[XmlRoot(ElementName="ModelSet")]
	public class ModelSet
	{
		[XmlAttribute(AttributeName = "version")]
		public String HL7Version { get; set; }

		[XmlElement(ElementName="Message")]
		public ModelMessage[] Models { get; set; }

		public ModelSet()
		{
			//Models = new List<ModelMessage>();
		}
	}
}
