namespace BirdNest.Nodes
{

	public class EntireTreeNode : Decorator, IEntireTreeNode {
		public Tree ExistingTree {get;set;}
		
		public EntireTreeNode(Tree bTree)
		{
			this.ExistingTree = bTree;
		}

		#region implemented abstract members of Decorator

		public override INodeExaminer CreateNodeExaminer ()
		{
			return new EntireTreeNodeExaminer<EntireTreeNode> (this);
		}

		#endregion
	}		
	
}