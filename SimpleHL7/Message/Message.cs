using System;
using System.Collections.Generic;
using System.Linq;
using SimpleHL7.Model;
using SimpleHL7.Parser;

namespace SimpleHL7.Message
{


	public class DebugMessage
	{
		public String[] SegmentStrings { get; private set; }
	}

	/// <summary>
	/// Represents an instance of an HL7 message transaction.
	/// </summary>
	public class DelimitedMessage : IHL7Message, IElement
	{

		private Context _Context = new Context();

		#region Properties

		// IElement properties
		public String Name { get; set; }
		public IElement[] Items { get; set; }

		// IHL7Message properties
		public Context Context
		{
			get { return _Context; }
		}
		public String MessageType { get; set; }
		public String MessageEvent { get; set; }
		public String RawText { get; private set; }
		
		// TODO: Replace with something that iterates the Items?
		public IEnumerable<Segment> AllSegments
		{
			get;
			private set;
		}


		#endregion


		// TODO:

		// 1. Split into IHL7Message interface and a DelimitedMessageParser (or MessageParser) to give
		// flexiblity in type of message returned.

		// 2. Allow for parser to either use a model, which will validate that required segments
		// exist and create structure of repeating segments or to use no model and just make
		// an object that represents the raw message.

		// 3. Create a means to map callbacks/events to the iteration of message segments or groups.  
		// These events can be called during parse or as a separate step afterwards.

		public DelimitedMessage(String rawText)
		{
			// Set the Raw Text
			this.RawText = rawText.Trim();

			// Validate the the message begins with an MSH segment
			switch (this.RawText.IndexOf("MSH"))
			{
				case 0:
					break;
				case -1:
					throw new MessageException("Required segment MSH could not be found.");
				default:
					throw new MessageException("Message does not begin with the required segment MSH.");
			}

			// Set the encoding characters
			this.Context.SetEncodingCharacters(
				this.RawText[3], this.RawText.Substring(4, 4));

			// Get an array of all the segments as raw strings
			String[] segmentStrings = this.RawText.Split(
				new[] { this.Context.SegmentSeparator });

			// Get an array of all the segments as Segment objects, not
			// structured into groups
			Segment[] allSegments = (
				from i in segmentStrings
				select new Segment(i.Trim(), this.Context)).ToArray();


			// TODO: If we decide the enumerator is the way to go, ditch the ToArray and
			// just make the Enumerator the output of the above LINQ query
			IEnumerator<Segment> allSegmentsEnumerator = allSegments.ToList().GetEnumerator();
			

			// Get a list of the IElemnts (Segments and SegmentGroups)
			// that will be structured after the model.
			List<IElement> itemList = new List<IElement>(segmentStrings.Length);

			// Get the Model for the Ihl7Message
			// TODO: Pre-parse the message at least far enough to know the type and event
			ModelMessage model = ModelFactory.GetModel("ORU");


			// Prepare the segment enumerator (TryPopulate expects it to be at first element)
			allSegmentsEnumerator.MoveNext();

			
			// Try to populate the top-level group (the message)
			TryPopulateGroup(this, model, allSegmentsEnumerator, new HashSet<String>());

			/*
			//// Iterate the raw segment strings
			//while (segIt < segmentStrings.Length)
			//{
			//    // Windows-style line breaks may leave white space,
			//    // so trim it
			//    segmentStrings[segIt] = segmentStrings[segIt].Trim();

			//    // Build a segment and add it to the unstructured array
			//    Segment segment = new Segment(segmentStrings[segIt], this.Context);
			//    allSegments[segIt] = segment;

			//    ModelElement modelElement = (ModelElement) model.Items[modIt];

			//    // If name of current message item matches current
			//    // model item, add message item to the structured list
			//    if (modelElement.Name == segment.Name)
			//    {
			//        itemList.Add((IElement)segment);
			//        // If ModelElement can't repeat, then iterate model i
			//        // and bring the saved value up to the current value.
			//        if (!modelElement.CanRepeat)
			//        {
			//            modBookmark = ++modIt;
			//        }
			//    }

			//    // Finally, move the segment iterator forward
			//    segIt++;
			//}
*/

			//this.Items = itemList.ToArray();
			this.AllSegments = allSegments;
		}

		// TODO: Get rid of the HashSet param if we're not using it
		private Boolean TryPopulateGroup(
			IElement group, 
			ModelElement modelGroup,
			IEnumerator<Segment> segments,
			HashSet<String> matchedSegments)
		{
			List<IElement> itemsInGroup = new List<IElement>(modelGroup.Items.Length);
			Int32 i = 0, bookmark = 0;
			Boolean modelElementMatchedOnce = false;

			while (i < modelGroup.Items.Length)
			{
				Boolean didMatch = false;
				ModelElement modelElement = (ModelElement)modelGroup.Items[i];

				// If the current model item is a group...
				if (modelElement is ModelSegmentGroup)
				{
					// Create a container for the message tree
					SegmentGroup g = new SegmentGroup(modelElement.Name);

					// Then try to populate the new group
					if (TryPopulateGroup(g, modelElement, segments, matchedSegments))
					{
						itemsInGroup.Add(g);
						didMatch = true;
					}
				}
					// Else the current model item is a segment
				else
				{
					// If the current segment matches the current model
					// segment by name...
					if (segments.Current.Name == modelElement.Name)
					{
						// TODO: Check for a grouping definition here
						// and call a method to group segments

						itemsInGroup.Add(segments.Current);
						segments.MoveNext();
						didMatch = true;
					}
				}

				// If we did match...
				if (didMatch)
				{
					if (!modelElement.CanRepeat)
					{
						i++;
						bookmark = i;
						modelElementMatchedOnce = false;
					}
					else
						modelElementMatchedOnce = true;
				}

				// ...else we didn't match
				else
				{
					// If it's the first iteration, consider the possibility that the parent group is
					// a better place to try matching.
					if (i == 0 && modelGroup.CanRepeat)
						break;

					// If the model element is required and wasn't matched on a prior iteration...
					// We may also need to check here if the parent wasn't matched on a prior iteration
					if (modelElement.IsRequired && !modelElementMatchedOnce)
					{
						if (! segments.MoveNext())
							throw new Exception("Required element could not be matched.");
					}

					// Else if we've reached the end of the model group
					else if (i == modelGroup.Items.Length)
					{
						// Since we didn't match by peeking ahead to the end of the group, reset i to bookmarked value
						if (bookmark < i)
							i = bookmark;
					}

					// Otherwise, just move to the next element in the model group
					else
					{
						i++;
						modelElementMatchedOnce = false;
					}
				}

				// Always check if current is null and exit the while
				if (segments.Current == null)
					break;
			}

			group.Items = itemsInGroup.ToArray();
			return itemsInGroup.Any();
		}


		public override string ToString()
		{
			return Name;
		}
	}

	//public class SegmentEnumerator : IEnumerator<Segment>
	//{
	//    private String[] _SegmentStrings;
	//    private List<Segment> _Segments;
	//    private Int32 _Length = 0;
	//    private Int32 _ParseLocation = -1;
	//    private Int32 _Location = -1;

	//    public SegmentEnumerator(String[] segmentStrings)
	//    {
	//        this._SegmentStrings = segmentStrings;
	//        this._Length = segmentStrings.Length;
	//        this._Segments = new List<Segment>(this._Length);
	//    }

	//    public Segment Current
	//    {
	//        get
	//        {
	//            try
	//            {
	//                return this._Segments[_Location];
	//            }
	//            catch (IndexOutOfRangeException)
	//            {
	//                throw new InvalidOperationException();
	//            }
	//        }
	//    }

	//    public void Dispose()
	//    {
	//        throw new NotImplementedException();
	//    }

	//    object System.Collections.IEnumerator.Current
	//    {
	//        get { return Current; }
	//    }

	//    public bool MoveNext()
	//    {
	//        this._Location++;
	//        if (this._Location < this._Length)
	//        {
	//            if (this._ParseLocation < this._Location)
	//            {
	//                this._ParseLocation++;
	//                //this._Segments.Add
	//            }
	//            return true;
	//        }
	//        return false;
	//    }

	//    public void Reset()
	//    {
	//        this._Location = -1;
	//    }
	//}



}
