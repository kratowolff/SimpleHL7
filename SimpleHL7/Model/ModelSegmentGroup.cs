using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SimpleHL7.Model
{
	public class ModelSegmentGroup : ModelElement, IElement
	{
		//[XmlAttribute(AttributeName = "maxRepeats")]
		//public Int32 MaxRepeats { get; set; }

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
