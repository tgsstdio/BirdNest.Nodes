namespace BirdNest.Nodes
{ 
	public class Sequence : Branch
	{
		public override INodeExaminer CreateNodeExaminer ()
		{
			return new SequenceExaminer<Sequence>(this);
		}
	}

}

