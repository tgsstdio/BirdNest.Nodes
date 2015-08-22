using System;
using System.Collections.Generic;

namespace BirdNest.Nodes
{
	public class TreeBuilder : ITreeBuilder
	{
		private	Stack<TreeBuilderFrame> mCallStack;
		private INode mRoot;
		private uint noOfCommands;

		public BuilderState State { get; set; }
		private BuilderError mErrorCode;
		private INode mCurrent;
		
		public Tree Build()
		{
			if (mErrorCode != BuilderError.NO_ERROR)
			{
				throw new Exception("INVALID TREE STATE -" + mErrorCode.ToString());	
			}
			
			return new Tree{Root=mRoot};										
		}
		
		private void SetErrorCode(BuilderError error)
		{
			mErrorCode = error;
		}

		private bool IsAddingSibilingToRootNode()
		{
			return (mCallStack.Count > 0 && mRoot == null);
		}

		private bool RequiresRootNode()
		{
			return (mRoot == null);
		}

		public TreeBuilder ()
		{
			mCallStack = new Stack<TreeBuilderFrame> ();
			noOfCommands = 0;
			mErrorCode = BuilderError.NO_ERROR;
			State = BuilderState.INVALID_TREE;
			mRoot = null;
		}

		private INode GetParentNode()
		{
			if (ContainsItems())
			{
				return mCallStack.Peek().Parent;
			}
			else
			{
				return null;
			}
		}

		private bool CanAcceptNewChildrenNode()
		{
			INode parent = GetParentNode();
			if (parent != null)
			{
				return parent.AcceptsChildren();
			}
			else
			{
				return false;
			}
		}

		private INode GetCurrentNode()
		{
			return mCallStack.Peek().Parent;
		}

		private void AddChildNodeToParent (INode child)
		{
			if (ContainsItems())
			{
				INode parentNode = GetParentNode();
				parentNode.AddChild(child);
				mCurrent = child;
			}
		}

		public ITreeBuilder AddNode(INode newNode)
		{
			++noOfCommands;
			if(IsTreeInvalid())
			{
				return this;
			}

			if (RequiresRootNode())
			{
				mRoot = newNode;
				return this;
			}

			if (IsAddingSibilingToRootNode())
			{
				SetErrorCode(BuilderError.NO_OF_CHILDREN_EXCEEDED);
				return this;
			}

			if (CanAcceptNewChildrenNode())
			{
				AddChildNodeToParent(newNode);
				return this;
			}
			else
			{
				SetErrorCode(BuilderError.NO_OF_CHILDREN_EXCEEDED);
				return this;
			}

		}

		public bool IsTreeInvalid()
		{
			return (mErrorCode != BuilderError.NO_ERROR);
		}

		public ITreeBuilder Parallel()
		{
			Parallel p = new Parallel();

			return AddNode(p);
		}

		public ITreeBuilder Sequence()
		{
			var s = new Sequence();

			return AddNode(s);
		}

		public ITreeBuilder Selector()
		{
			var s = new Selector();

			return AddNode(s);
		}

		public ITreeBuilder AddStep(Step act)
		{
			return AddNode(act);
		}

		public ITreeBuilder AddDecorator (Decorator dec)
		{
			throw new NotImplementedException ();
		}

		public ITreeBuilder AddCondition (Condition con)
		{
			throw new NotImplementedException ();
		}

		public ITreeBuilder Begin()
		{
			++noOfCommands;

			if (RequiresRootNode())
			{
				SetErrorCode(BuilderError.REQUIRES_A_ROOT_NODE);
				return this;
			}

			if(IsTreeInvalid())
			{
				return this;
			}

			if (mCallStack.Count <= 0)
			{
				PushNewFrame(mRoot);
			}
			else
			{
				INode currentNode = GetNextChildNode();
				PushNewFrame(currentNode);
			}

			return this;
		}

		private void PushNewFrame (INode currentNode)
		{
			mCallStack.Push (new TreeBuilderFrame { Parent=currentNode });
			State = BuilderState.INVALID_TREE;
		}

		private INode GetNextChildNode()
		{
			return mCurrent;
		}

		private bool ContainsItems()
		{
			return mCallStack.Count > 0;
		}

		public ITreeBuilder End()
		{
			++noOfCommands;

			if (RequiresRootNode())
			{
				SetErrorCode(BuilderError.REQUIRES_A_ROOT_NODE);
				return this;
			}

			if(IsTreeInvalid())
			{
				return this;
			}

			if(mCallStack.Count <= 0)
			{
				SetErrorCode (BuilderError.STACK_UNDERFLOW);
				return this;
			}

			mCallStack.Pop();

			if(!ContainsItems())
			{
				State = BuilderState.TREE_OK;
				mErrorCode = BuilderError.NO_ERROR;
			}
			//delete frame;
			return this;
		}

		#region ITreeBuilder implementation
		public ITreeBuilder AddTree (Tree existTree)
		{
			EntireTreeNode current = new EntireTreeNode(existTree);
			return AddNode(current);
		}
		#endregion
	}
}
;