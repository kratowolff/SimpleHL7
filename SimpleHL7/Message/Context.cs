using System;
using SimpleHL7.Parser;

namespace SimpleHL7.Message
{
	/// <summary>
	/// Stores contextual info about how to parse the current message.
	/// </summary>
	public class Context
	{

		// Segment Separator
		// This is set by the HL7 Standard, so use a constant
		private const Char _SegmentSeparator = '\r';

		// Encoding Characters
		// Default these to the recommended values
		private Char _FieldSeparator = '|';
		private Char _ComponentSeparator = '^';
		private Char _FieldRepeatSeparator = '~';
		private Char _EscapeCharacter = '\\';
		private Char _SubComponentSeparator = '&';

		/*
		\H\	start highlighting
		\N\	normal text (end highlighting)
		\F\	field separator
		\S\	component separator
		\T\	subcomponent separator
		\R\	repetition separator
		\E\	escape character
		\Xdddd...\	hexadecimal data
		\Zdddd...\	locally defined escape sequence
		*/

		// HL7 Version
		private String _HL7Version;

		// Parsing and reading rules
		private Boolean _AllowAccessFirstRepeatAsOnlyField = true;
		private Boolean _LazyParseFields = true;
		private Boolean _LasyParseComponents = false;


		/// <summary>
		/// Gets the character used to separate segments.
		/// </summary>
		public Char SegmentSeparator
		{
			get { return _SegmentSeparator; }
		}

		/// <summary>
		/// Gets the character used to separate fields in the current message context.
		/// </summary>
		public Char FieldSeparator
		{
			get { return _FieldSeparator; }
		}

		/// <summary>
		/// Gets the character used to separate components in the current message context.
		/// </summary>
		public Char ComponentSeparator
		{
			get { return _ComponentSeparator; }
		}

		/// <summary>
		/// Gets the character used to separate repeating fields in the current message context.
		/// </summary>
		public Char FieldRepeatSeparator
		{
			get { return _FieldRepeatSeparator; }
		}

		/// <summary>
		/// Gets the character used for escape sequences in the current message context.
		/// </summary>
		public Char EscapeCharacter
		{
			get { return _EscapeCharacter; }
		}

		/// <summary>
		/// Gets the character used to separate sub-components in the current message context.
		/// </summary>
		public Char SubComponentSeparator
		{
			get { return _SubComponentSeparator; }
		}

		/// <summary>
		/// Gets the HL7 version number for the current message context.
		/// </summary>
		public String HL7Version
		{
			get { return _HL7Version; }
		}

		/// <summary>
		/// Gets or sets an indicator as to whether the first element of a repeating field can
		/// be accessed as though it were a non-repeating field.  If true, access is allowed in
		/// this manner; If false, it is not.  The default value is true.
		/// </summary>
		public Boolean AllowAccessFirstRepeatAsOnlyField
		{
			get { return _AllowAccessFirstRepeatAsOnlyField; }
			set { _AllowAccessFirstRepeatAsOnlyField = value; }
		}

		/// <summary>
		/// Gets or sets an indicator as to whether fields should be parsed in a lazy manner.  If
		/// true, then all the fields on any given segment will be left unparsed until at least one
		/// field is accessed (at which time all the fields on the segment will be parsed); If
		/// false, then all fields will be parsed during the parent segment parsing.  The default
		/// value is true.
		/// </summary>
		public Boolean LazyParseFields
		{
			get { return _LazyParseFields; }
			set { _LazyParseFields = value; }
		}


		/// <summary>
		/// Gets or sets an indicator as to whether components should be parsed in a lazy manner.
		/// If true, then all the components of any given field will be left unparsed until at least
		/// one component is accessed (at which time all the components of the field will be parsed);
		/// If false, then all the components will be parsed during the parent file parsing.  The
		/// default value is false.
		/// </summary>
		public Boolean LasyParseComponents
		{
			get { return _LasyParseComponents; }
			set { _LasyParseComponents = value; }
		}

		/// <summary>
		/// Sets the encoding characters for the message context.
		/// </summary>
		/// <param name="fieldSeparator">The character used to separate field.  This value should
		/// be set from MSH-1.</param>
		/// <param name="encodingChars">The string that is the 4 encoding characters.  This value 
		/// should be set from MSH-2.</param>
		public void SetEncodingCharacters(Char fieldSeparator, String encodingChars) {
			if (encodingChars.Length != 4)
				throw new MessageException("Unexpected number of encoding characters.");

			this._FieldSeparator = fieldSeparator;
			this._ComponentSeparator = encodingChars[0];
			this._FieldRepeatSeparator = encodingChars[1];
			this._EscapeCharacter = encodingChars[2];
			this._SubComponentSeparator = encodingChars[3];
		}


		/// <summary>
		/// Sets the HL7 version for the message context.
		/// </summary>
		/// <param name="version">The string that is the HL7 version.  This value should be set
		/// from MSH-12.</param>
		public void SetHL7Version(String version)
		{
			_HL7Version = version;
		}

	}
}
