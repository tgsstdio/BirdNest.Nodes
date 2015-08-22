using System;
using BirdNest.Nodes;

namespace ExampleOne
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// build empty tree
			var store = new TreeDictionary();

			var minorBuilder = new BlackboardTreeBuilder<Enemy>(new TreeBuilder(), store);

			// gererate a behavior tree as a stub for later reuse
			minorBuilder
				.Sequence ()
				.Begin ()
					.Selector ()
					.Begin ()
						.IsTrue ((e) => e.WithinDistance ())
						.Step ((e) => e.MoveTowards ())
					.End ()
					.Sequence ()
					.Begin ()
						.IsTrue ((e) => e.WithinDistance ())
						.Step ((e) => e.HitTarget ())
					.End ()
				.End ()
				.BuildAndRegisterAs<BaseEnemyAI> ();

			var playerOne = new Player{ HealthPoints = 10, X = 10};
			var ogre = new Enemy ();
			var locator = new MockPlayerLocator(playerOne);
			var situation = new Simulation{Individual=ogre, Locator=locator, Current = playerOne };

			var upperTree = new BlackboardTreeBuilder<Simulation>(new TreeBuilder(), store); 
			upperTree
				.Sequence ()
				.Begin ()
					.Selector ()
					.Begin ()
					.IsTrue ((e) => e.Individual.HasTarget ())
					.Step ((e) =>  { 											
						bool result = e.Locator.Find (out e.Individual.Target);
						return (result) ? Result.SUCCESS : Result.FAILED;
					}
					)
				.End ()
				.UseStub<BaseEnemyAI, Enemy> ()
				.IsTrue((e) => e.Current.HealthPoints <= 0)
				.End ();

			var linker = new BlackboardLinker ();
			linker.AddDependency<Simulation, Enemy>((es) => es.Individual);

			var board = new Blackboard<Simulation>{Context = situation};
			linker.AddParameter<Simulation>(new StaticParameter<Simulation>(board));

			// generate tree as a stub for an BaseEnemyAI implementation
			var finalTree = upperTree.Build();

			var walker = new NodeWalker(finalTree, linker);

			Result outcome = Result.INCOMPLETE;
			while (!(outcome == Result.SUCCESS || outcome == Result.UNEXCEPTED_ERROR))
			{
				walker.Restart ();
				walker.ComputeAllSteps ();
				outcome  = walker.Outcome;
				Console.WriteLine ("Ogre X:{0}, Player [HP :{1}] X:{2}", ogre.X, playerOne.HealthPoints, playerOne.X);
			}	

			Console.WriteLine ("PLAYER IS DEAD");
		}
	}
}
