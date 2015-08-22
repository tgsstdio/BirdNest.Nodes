using System;

namespace ExampleOne
{
	public interface IPlayerLocator
	{ 
		bool Find(out Player target);
	}
}

