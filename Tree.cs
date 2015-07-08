using System.Collections.Generic;
using System;

namespace BirdNest.Nodes
{	
	public class Tree {
		public string Name;
		public INode Root;
		public List<Type> Dependencies {get;set;}
	}
}