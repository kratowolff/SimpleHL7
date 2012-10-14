using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SimpleHL7.Message;
using SimpleHL7.Model;
using SimpleHL7.Parser;

namespace SimpleHL7.Handler
{
	class StoredProcedureAction : ISegmentHandler, IDisposable
	{
		//private SqlConnection _Connection;
		
		public String ConnectionString { get; set; }
		public String ProcedureName { get; set; }
		public Model.ModelElement ModelElement { get; set; }



		public void HandleSegment(Segment segment)
		{


		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}



}
