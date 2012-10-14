using System;
using System.Collections.Generic;
using System.Linq;
using SimpleHL7.Parser;

namespace SimpleHL7.Message
{

	/// <summary>
	/// Builds IComponent instances and collections.
	/// </summary>
	public class ComponentFactory
	{

		public static IComponent GetComponent(String rawText, Context context)
		{
			if (String.IsNullOrEmpty(rawText))
				return EmptyComponent.GetInstance();
			else
				return new Component(rawText, context);
		}


		public static IEnumerable<IComponent> GetComponents(String fieldRawText, Context context)
		{
			String[] componentStrings = fieldRawText.Split(context.ComponentSeparator);

			return
				from item in fieldRawText.Split(context.ComponentSeparator)
				select ComponentFactory.GetComponent(item, context);

		}


	}
}
