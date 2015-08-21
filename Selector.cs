namespace BirdNest.Nodes
{
	public class Selector : Branch
	{
		public Selector ()
		{
		}

		public override INodeExaminer CreateNodeExaminer ()
		{
			return new SelectorExaminer<Selector>(this);
		}
	}
}

