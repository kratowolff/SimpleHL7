using System;

namespace SimpleHL7.Message
{

	public class SegmentGroup : IElement
	{
		protected String _Name;
		protected IElement[] _Items;

		public String Name
		{
			get { return _Name; }
		}

		public IElement[] Items
		{
			get { return _Items; }
			set { _Items = value; }
		}

		public override string ToString()
		{
			return Name;
		}

		public SegmentGroup(String name)
		{
			_Name = name;
		}

	}
}
