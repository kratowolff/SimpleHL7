using System;
using System.Collections.Generic;
using System.Linq;
using SimpleHL7.Parser;

namespace SimpleHL7.Message
{

	public class FieldFactory
	{

		public static IField GetField(String rawText, Context context)
		{
				if (rawText == String.Empty)
					return EmptyField.GetInstance();
				
				else if (rawText.IndexOf(context.FieldRepeatSeparator) == -1)
					return new NonRepeatingField(rawText, context);
				
				else
					return new RepeatingField(rawText, context);
		}


		public static IEnumerable<IField> GetFields(String[] fields, Context context)
		{
			return
				from item in fields
				select FieldFactory.GetField(item, context);
		}


		public static IEnumerable<IField> GetRepeatingFields(String repeatingField, Context context)
		{
			return (IEnumerable<IField>)
				from item in repeatingField.Split(context.FieldRepeatSeparator)
				select new FieldItem(item, context);
		}
	}
}
