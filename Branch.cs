namespace BirdNest.Nodes
{
	public abstract class Branch : INode
	{
		public abstract INodeExaminer CreateNodeExaminer ();

		public INode Sibiling { get; set; }

		public bool HasChildren ()
		{
			return mChildNode != null;
		}

		public bool AcceptsChildren ()
		{
			return true;
		}

		protected INode mChildNode;
		public INode Child {
			get {
				return mChildNode;
			}
			set {
				mChildNode = value;
			}
		}

		public void AddChild (INode child)
		{
			if (mChildNode == null)
			{
				mChildNode = child;
			}
			else
			{
				INode currentNode = mChildNode;
				INode sibilingNode = currentNode.Sibiling;
				while(sibilingNode != null)
				{
					currentNode = sibilingNode;
					sibilingNode = currentNode.Sibiling;
				}

				currentNode.Sibiling = child;
			}
		}
	}
}

