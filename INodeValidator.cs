using System.Collections.Generic;

namespace BirdNest.Nodes
{
	public interface INodeValidator
	{
		void EvaluateEachChild (Evaluation result);

		Result EvaluateResults(List<Evaluation> tests);

		void BeginLoop ();
		void CleanupLoop();
	}
}

