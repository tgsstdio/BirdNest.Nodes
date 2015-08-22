using BirdNest.Nodes;

namespace ExampleOne
{
	public abstract class BaseEnemyAI : Step, IBlackboardNode<Enemy>
	{
		#region IBlackboardNode implementation
		public Blackboard<Enemy> Board { get; set; }
		#endregion
	}	
}

