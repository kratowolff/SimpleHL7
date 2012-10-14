using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using System.Xml;

namespace SimpleHL7.Model
{
	public class ModelFactory
	{

		private static readonly ModelFactory 
			_DefaultInstance = new ModelFactory();

		private static Dictionary<String, ModelSet>
			_DefaultModelSets = new Dictionary<string, ModelSet>();

		private Dictionary<String, ModelSet>
			_NamedModelSets = new Dictionary<string, ModelSet>();


		private ModelFactory()
		{ }

		public static ModelFactory GetDefaultInstance()
		{
			return _DefaultInstance;
		}




		public static ModelSet GetModelSet(String version)
		{
			XmlSerializer xs = new XmlSerializer(typeof(SimpleHL7.Model.ModelSet));

			using (Stream stream = Assembly.GetExecutingAssembly()
				.GetManifestResourceStream("SimpleHL7.Resources.MessageStructures.xml"))
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					return (ModelSet)xs.Deserialize(stream);
				}

			}
		}

		public static ModelMessage GetModel(String messageType)
		{


			ModelMessage mm = new ModelMessage()
			{
				Name = messageType,
				Version = "2.3",
				Items = new IElement[] {
					new ModelSegment() { Name = "MSH", IsRequired = true},
					new ModelSegment() { Name = "PID", IsRequired = true},
					new ModelSegment() { Name = "XXX", IsRequired = false},
					new ModelSegment() { Name = "ORC", IsRequired = true},
					new ModelSegmentGroup() { Name = "OBR_NTE", IsRequired = true, CanRepeat = true, Items = new IElement[]{
						new ModelSegment() { Name = "OBR", IsRequired = true},
						new ModelSegment() { Name = "NTE", IsRequired = false, CanRepeat = true},
						new ModelSegmentGroup() { Name = "OBX_NTE", IsRequired = true, CanRepeat = true, Items = new IElement[]{
							new ModelSegment() { Name = "OBX", IsRequired = true},
							new ModelSegment { Name = "NTE", IsRequired = false, CanRepeat = true}
							}
							}
						}
					}
				}
			};
			return mm;
		}
	}
}

/*
Assembly.GetExecutingAssembly().GetManifestResourceStream("SimpleHL7.Resources.MessageStructures.xml")
<Message xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="ORU" version="2.3">
  <Items>
    <Segment name="MSH" isRequired="true" canRepeat="false" />
    <Segment name="PID" isRequired="true" canRepeat="false" />
    <Segment name="ORC" isRequired="true" canRepeat="false" />
    <SegmentGroup name="OBR_NTE" isRequired="true" canRepeat="false">
      <Items>
        <Segment name="OBR" isRequired="true" canRepeat="false" />
        <Segment name="NTE" isRequired="false" canRepeat="true" />
        <SegmentGroup name="OBX_NTE" isRequired="true" canRepeat="true">
          <Items>
            <Segment name="OBX" isRequired="true" canRepeat="false" />
            <Segment name="NTE" isRequired="false" canRepeat="true" />
          </Items>
        </SegmentGroup>
      </Items>
    </SegmentGroup>
  </Items>
</Message>

<?xml version="1.0" encoding="utf-16"?>
<Message 
	xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
	xmlns:xsd="http://www.w3.org/2001/XMLSchema" 
	name="ORM" 
	version="2.3">
  <Items>
    <Segment name="MSH" isRequired="true" />
    <Segment name="PID" isRequired="true" />
    <SegmentGroup name="OBR_NTE" isRequired="true">
      <Items>
        <Segment name="OBR" isRequired="true" />
        <Segment name="NTE" isRequired="false" />
      </Items>
    </SegmentGroup>
  </Items>
</Message>

*/