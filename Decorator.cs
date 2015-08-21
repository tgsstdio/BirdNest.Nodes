namespace BirdNest.Nodes
{
	public abstract class Decorator : INode
	{
		public abstract INodeExaminer CreateNodeExaminer ();

		public INode Sibiling { get; set; }

		public bool HasChildren ()
		{
			return mChildNode != null;
		}

		public bool AcceptsChildren ()
		{
			return (mChildNode == null);
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
		}
	}
}

