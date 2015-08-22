namespace BirdNest.Nodes
{
	public class BlackboardSetter<T> : Step, IBlackboardNode<T>
		where T : class
	{
		private System.Action<T> mAction;
		
		public BlackboardSetter (System.Action<T> func)
		{
			this.mAction = func;
		}
		
		#region IBlackboardNode implementation
		
		public Blackboard<T> Board
		{
			get;
			set;
		}
		
		#endregion
		
		#region implemented abstract members of Leaf
		
		public override Result DoStuff ()
		{
			this.mAction(this.Board.Context);
			return Result.SUCCESS;
		}
		
		#endregion
	}
}



