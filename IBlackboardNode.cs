using System.Collections.Generic;

namespace BirdNest.Nodes
{
	public interface IBlackboardNode<T> where T : class
	{
		Blackboard<T> Board { get; set; }
	}
}