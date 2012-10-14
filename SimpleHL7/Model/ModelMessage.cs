using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SimpleHL7.Model
{
	[XmlType(TypeName="Message")]
	public class ModelMessage : ModelElement, IElement
	{

		[XmlAttribute(AttributeName="version")]
		public String Version { get; set; }



/// <summary>
/// Gets or sets the collection of IElement objects from
/// the Items property as type ModelElement
/// </summary>
/// <remarks>
/// This property is primarily here to allow the Items property
/// to be XML-serialized.  Items cannot be serialized directly
/// because it is not of a concrete type.
/// </remarks>
		[XmlArrayItem(ElementName = "Segment", Type = typeof(ModelSegment))]
		[XmlArrayItem(ElementName = "SegmentGroup", Type = typeof(ModelSegmentGroup))]
		[XmlArray(ElementName = "Items")]
		public ModelElement[] Elements
		{
			get { return Items.Cast<ModelElement>().ToArray(); }
			set { Items = value; }
		}

	}
}
