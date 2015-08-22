# BirdNest.Nodes
---
C# implementation of a stack based behaviour tree. The library traverses a tree
non-recursively and therefore easier to debug & trace.
# Example
---

```C#
	public interface IPlayerLocator	{ ... }

	public class Enemy
	{
		public bool WithinDistance (){ ... }
		public bool HasTarget () { ... }
		public Result MoveTowards () { ... }
		public Result SelectTarget () { ... }
		public Result HitTarget () { ... } 
	}	
	
	public class EnemySituation
	{
		public IPlayerLocator Service;
		public Enemy Individual;
	}

	public abstract class BaseEnemyAI : Step, IBlackboardNode<Enemy>
	{
		#region IBlackboardNode implementation
		public Blackboard<Enemy> Board { get; set; }
		#endregion
	}	
	
	// initialise tree build
	var dictionary = new TreeDictionary();
	var builder = new BlackboardTreeBuilder<Enemy>(new TreeBuilder(), dictionary);

	// gererate a behavior tree
	builder
		.Sequence()
			.Begin ()
			.Selector()
				.Begin ()
					.IsTrue((e) => e.HasTarget())
					.Selector ()
					.Begin ()
						.Step((e) => e.SelectTarget())
					.End ()
				.End ()
			.Selector()
				.Begin ()
					.IsTrue((e) => e.WithinDistance())
					.Selector ()
					.Begin ()
						.Step((e) => e.MoveTowards())
					.End ()
				.End()
			.End ()
			.Step ((e) => e.HitTarget())
		.End ()
	.BuildAndRegisterAs<BaseEnemyAI>();

	var topBuilder = new BlackboardTreeBuilder<EnemySituation>(new TreeBuilder(), dictionary);
	
	// generate tree as a stub for an BaseEnemyAI implementation
	var tree = topBuilder
		.UseStub<BaseEnemyAI, Enemy>()
		.Build();

	var walker = new NodeWalker(tree);
	walker.AddBlackboard<EnemySituation>(new Blackboard<EnemySituation>{ Context = new EnemySituation()});
	walker.AddDependentBlackboard<EnemySituation, Enemy>((es) => {return es.Individual;});
```

# Changelog
---
## Version 1.1.0 
### 2015-08-22
Replaced library with PCL version 4.0 (Profile328)
Renamed Action type to Step because .NET already has a Action type

## Version 1.0.0 
### 2015-07-08
Initial check in

# LICENSE 
---
The MIT License (MIT)

Copyright (c) 2015 David Young

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN Step OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
