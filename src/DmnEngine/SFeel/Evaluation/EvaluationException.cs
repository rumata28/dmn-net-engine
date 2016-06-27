using System;
using System.Runtime.Serialization;

namespace Softengi.DmnEngine.SFeel.Evaluation
{
	public class EvaluationException : ApplicationException
	{
		public EvaluationException()
		{}

		public EvaluationException(string message) : base(message)
		{}

		public EvaluationException(string message, Exception innerException) : base(message, innerException)
		{}

		protected EvaluationException(SerializationInfo info, StreamingContext context) : base(info, context)
		{}
	}
}