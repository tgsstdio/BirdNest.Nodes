using System.Collections;

namespace BirdNest.Nodes
{

	public class UsePlanNode : Decorator 
	{
		public UsePlanNode(PlanNode bTree)
		{
	
		}

		#region implemented abstract members of Decorator

		public override INodeExaminer CreateNodeExaminer ()
		{
			return new UsePlanNodeExaminer (this);
		}

		#endregion
	}		
	
}