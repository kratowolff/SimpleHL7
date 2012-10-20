using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleHL7;
using SimpleHL7.Message;
using SimpleHL7.Parser;
using SimpleHL7.Model;

namespace SimpleHL7_GUI
{
	public partial class Dashboard : Form
	{
		public Dashboard()
		{
			InitializeComponent();

#if DEBUG
			StartInDebug();
#endif

		}

		private void StartInDebug()
		{

			RawHL7TextBox.Text = @"MSH|^~\&|TEST_APP|TEST_FAC|EGATE|UPHS|20120519204300||ORM|123456789|P|2.3
EVN|||
ZSH|||
PID|1||123456789^^^HUP|987654321^^^CMRN|PATIENT^TEST^M|
PV1|||
ORC|||
OBR|1|1234|
NTE|||
NTE|||
OBX|1||
OBX|2||
OBR|2|5678|
OBX|1||
OBX|2||
OBX|3||
NTE|||
";

			var parser = new DelimitedMessageParser();
			DelimitedMessage msg = (DelimitedMessage) parser.ParseMessage(RawHL7TextBox.Text);

			BuildHL7ElementsRecursive(msg, null, HL7TreeView);

		}




		private void BuildHL7ElementsRecursive(IElement parentElement, TreeNode parentNode, TreeView tv)
		{
			var newNodes = new List<TreeNode>(parentElement.Items.Length);

			foreach (IElement el in parentElement.Items)
			{
				TreeNode node = new TreeNode(el.Name);
				newNodes.Add(node);
				if (el.Items.Any())
					BuildHL7ElementsRecursive(el, node, tv);
				else if (el is Segment)
					BuildHL7Fields((Segment) el, null, node, tv);
			}

			if (parentNode == null)
				tv.Nodes.AddRange(newNodes.ToArray());
			else
				parentNode.Nodes.AddRange(newNodes.ToArray());

		}


		private void BuildHL7Fields(Segment parentSegment, IField parentField, 
			TreeNode parentNode, TreeView tv)
		{
			IField[] fields;
			int i;

			if (parentField == null && parentSegment.Fields.Any())
			{
				fields = parentSegment.Fields;
				i = 0;
			}
			else if (parentField is RepeatingField)
			{
				fields = parentField.Fields;
				i = 1;
			}
			else
				return;

			var newNodes = new List<TreeNode>(fields.Length);
			

			foreach (IField f in fields)
			{
				TreeNode node = new TreeNode();
				if (f is RepeatingField)
				{
					BuildHL7Fields(parentSegment, f, node, tv);

				}
				else if (f.Components.Length > 1)
					BuildHL7Components(parentSegment, f, node, tv);

				if (parentField == null)
					node.Text = String.Concat(parentSegment, "-", i, ": ", f.Value);
				else
					node.Text = f.Value;

				if (i > 0)
					newNodes.Add(node);
	
				i++;
			}

			parentNode.Nodes.AddRange(newNodes.ToArray());

		}


		private void BuildHL7Components(Segment parentSegment, IField parentField,
			TreeNode parentNode, TreeView tv)
		{
			var newNodes = new List<TreeNode>(parentField.Components.Length);

			foreach (SimpleHL7.IComponent c in parentField.Components)
			{
				TreeNode node = new TreeNode(c.Value);
				newNodes.Add(node);
			}
			parentNode.Nodes.AddRange(newNodes.ToArray());
		}


		private void RawHL7TextBox_TextChanged(object sender, EventArgs e)
		{

		}

		private void HL7TreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{

		}
	}
}
