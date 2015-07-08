//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
namespace BirdNest.Nodes
{
	public class BlackboardCondition<T> : Condition, IBlackboardNode<T>
		where T : class
	{
		private System.Func<T, bool> mLocalFunction;
		
		public BlackboardCondition (System.Func<T, bool> func)
		{
			this.mLocalFunction = func;
		}

		public override Result DoStuff ()
		{
			if (this.mLocalFunction(this.Board.Context))
				return Result.SUCCESS;
			else
				return Result.FAILED;
		}

		#region IBlackboardNode implementation

		public Blackboard<T> Board
		{
			get;
			set;
		}

		#endregion
	}
}

