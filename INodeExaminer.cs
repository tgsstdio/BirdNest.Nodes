using System.Collections.Generic;

namespace BirdNest.Nodes
{
	public interface INodeExaminer
	{
		IEnumerator<INode> GetEnumerator();
		INodeValidator GetValidator();
	}
}

