using System;
using bt;
using System.Diagnostics;
using Brawler.Simulation;

namespace Blackboard.Demo.Console
{
	class MainClass
	{
		static Tree BuildSM (BlackboardTreeBuilder<CharacterInfo> builder)
		{
			var plan = builder.Parallel ().Begin ()// local information
			// is moving 
			.Selector ().Begin ().Sequence ().Begin ().IsTrue (c => 
			{
				return c.Input.MoveStick.X == 0.0;
			}).IsTrue (c => 
			{
				return c.Input.MoveStick.Y == 0.0;
			}).Set (c => 
			{
				c.Current.IsMoving = false;
			}).End ().Set (c => 
			{
				c.Current.IsMoving = true;
			}).End ()//					// is guard up
			//					.Sequence()
			//					.Begin ()
			//						.Set((c) => { c.Current.IsGuardUp = true; })
			//						.Selector ()
			//						.Begin ()
			//							.IsTrue((c) => {return c.Input.AttackStick.X == 0.0;})
			//							.IsTrue((c) => {return c.Input.AttackStick.Y == 0.0;})
			//							.Set((c) => { c.Current.IsGuardUp = false; })
			//						.End()
			//					.End()
			// is facing enemy						
			// nearest enemy gap
			//					// MOVE ANIMATION
			//					.Sequence()
			//					.Begin()
			//						.IsTrue((c) => { return c.Current.IsMoving ; })
			//						.Selector()
			//						.Begin()					
			//							// Stepping			
			//							.Sequence()
			//							.Begin()
			//								.IsTrue((c) => { return c.Current.IsFacingEnemy ; })
			//								.IsTrue((c) => { return c.Current.IsGuardUp ; })
			//								.Selector()
			//								.Begin()							
			//									.Sequence()
			//									.Begin ()
			//										.IsTrue((c) => { return c.Current.NearestEnemyGap <= 2.0f; })							
			//										.Selector()
			//										.Begin()
			////											// RaiseStepping	
			////											.Sequence()
			////											.Begin()
			////												.IsTrue((c) => {return c.Input.MoveStick.X > 0.0f;})
			////												.IsTrue((c) => {return c.Input.MoveStick.Y == 0.0f;})
			////												.Set ((c) => c.Current.LocomotionState = MoveAnimation.StepForward)
			////											.End ()	
			////
			////											.Sequence()
			////											.Begin()
			////												.IsTrue((c) => {return c.Input.MoveStick.X < 0.0f;})
			////												.IsTrue((c) => {return c.Input.MoveStick.Y == 0.0f;})
			////												.Set ((c) => c.Current.LocomotionState = MoveAnimation.StepForward)
			////											.End ()	
			////
			////											.Sequence()
			////											.Begin()
			////												.IsTrue((c) => {return c.Input.MoveStick.Y > 0.0f;})
			////												.IsTrue((c) => {return c.Input.MoveStick.X == 0.0f;})
			////												.Set ((c) => c.Current.LocomotionState = MoveAnimation.SidestepUp)
			////											.End ()	
			////
			////											.Sequence()
			////											.Begin()
			////												.IsTrue((c) => {return c.Input.MoveStick.Y < 0.0f;})
			////												.IsTrue((c) => {return c.Input.MoveStick.X == 0.0f;})
			////												.Set ((c) => c.Current.LocomotionState = MoveAnimation.SidestepDown)
			////											.End ()
			//										.End()
			//									.End()	
			//									// forward slide / set crease 
			//									.Sequence()
			//									.Begin()
			//										.IsTrue((c) => { return c.Current.NearestEnemyGap <= 3.0f;} )
			//										.Set ((c) => c.Current.LocomotionState = MoveAnimation.SlideForward)
			//									.End()
			//								.End()
			//							.End ()
			//							.Sequence ()
			//							.Begin()
			//								.Selector ()
			//									.Begin ()
			//										// if the distance is greater than 3 feet
			//										.IsTrue((c) => { return c.Current.NearestEnemyGap > 3.0f;} )	
			//										// OR is guard down
			//										.IsFalse((c) => { return c.Current.IsGuardUp ; })
			//									.End ()
			//								.End()
			//								// Raise Run / Walk
			//								.Selector()
			//								.Begin()
			////									.Sequence()
			////									.Begin()
			////										.IsTrue((c) => {return c.Input.MoveStick.X > 0.5f;})
			////										.IsTrue((c) => {return c.Input.MoveStick.Y == 0.0f;})
			////										.Set ((c) => c.Current.LocomotionState = MoveAnimation.RunForward)
			////									.End ()	
			////
			////									.Sequence()
			////									.Begin()
			////										.IsTrue((c) => {return c.Input.MoveStick.X > 0.0f;})
			////										.IsTrue((c) => {return c.Input.MoveStick.Y == 0.0f;})
			////										.Set ((c) => c.Current.LocomotionState = MoveAnimation.WalkForward)
			////									.End ()
			////
			////									.Sequence()
			////									.Begin()
			////										.IsTrue((c) => {return c.Input.MoveStick.X < 0.0f;})
			////										.IsTrue((c) => {return c.Input.MoveStick.Y == 0.0f;})
			////										.Set ((c) => c.Current.LocomotionState = MoveAnimation.WalkBack)
			////									.End ()	
			////									
			////									.Sequence()
			////									.Begin()
			////										.IsTrue((c) => {return c.Input.MoveStick.Y > 0.0f;})
			////										.IsTrue((c) => {return c.Input.MoveStick.X == 0.0f;})
			////										.Set ((c) => c.Current.LocomotionState = MoveAnimation.WalkUp)
			////									.End ()	
			////									
			////									.Sequence()
			////									.Begin()
			////										.IsTrue((c) => {return c.Input.MoveStick.Y < 0.0f;})
			////										.IsTrue((c) => {return c.Input.MoveStick.X == 0.0f;})
			////										.Set ((c) => c.Current.LocomotionState = MoveAnimation.WalkDown)
			////									.End ()
			//								.End()
			//							.End()
			//							// default
			//							.Set((c) => c.Current.LocomotionState = MoveAnimation.Idle)
			//						.End()
			//					.End()
			// HAND ANIMATION
			//					.Selector()
			//					.Begin ()
			//						// throwing punch
			//
			//						// idle default 
			//						.Set((c) => c.Current.HandsState = HandsAnimation.Idle)
			//					.End ()
			//					 //full body override
			//					.Selector()
			//					.Begin ()
			//						// idle default 
			//						.Set((c) => c.Current.OverrideState = BodyAnimation.Default)
			//					.End ()
			.End ();
			var compiled = plan.Build ();
			return compiled;
		}

		private const int MAX_TIMES = 1;

		public static void Main (string[] args)
		{
			System.Console.WriteLine ("Hello World!");

			var characterInfo = new CharacterInfo();

			characterInfo.Input = new Brawler.Input.Packets.ControllerState();
			characterInfo.Input.AttackStick = new Brawler.Input.Packets.AnalogStick();
			characterInfo.Input.MoveStick = new Brawler.Input.Packets.AnalogStick();

			characterInfo.Current = new Brawler.Simulation.PlayerInfo();
			characterInfo.Previous = new Brawler.Simulation.PlayerInfo();

			var dictionary = new TreeDictionary();

			var builder = new BlackboardTreeBuilder<CharacterInfo>(
				new TreeBuilder(),
				dictionary);

			var plan = builder
					.Selector()
					.Begin ()
						//.Success()
						.Failed ()
						.Success()
						.Success()
					.End ();
					
			var compiled = builder.Build();
			//var compiled = BuildSM (builder);
		
			var walker = new NodeWalker(compiled);
			walker.Restart ();
			walker.ComputeStep();
			System.Console.WriteLine ("walker.IsComplete : " + walker.IsComplete);
			System.Console.WriteLine ("walker.Outcome : " + walker.Outcome);
			walker.ComputeStep();
			System.Console.WriteLine ("walker.IsComplete : " + walker.IsComplete);
			System.Console.WriteLine ("walker.Outcome : " + walker.Outcome);
			walker.ComputeStep();
			System.Console.WriteLine ("walker.IsComplete : " + walker.IsComplete);
			System.Console.WriteLine ("walker.Outcome : " + walker.Outcome);
			walker.ComputeStep();
			System.Console.WriteLine ("walker.IsComplete : " + walker.IsComplete);
			System.Console.WriteLine ("walker.Outcome : " + walker.Outcome);
			walker.ComputeStep();
			System.Console.WriteLine ("walker.IsComplete : " + walker.IsComplete);
			System.Console.WriteLine ("walker.Outcome : " + walker.Outcome);
			walker.ComputeStep();
			System.Console.WriteLine ("walker.IsComplete : " + walker.IsComplete);
			System.Console.WriteLine ("walker.Outcome : " + walker.Outcome);
			//Test1 (characterInfo, walker);

			//Test2 (characterInfo, walker, timer, MAX_TIMES);
		}

		static void Test1 (CharacterInfo characterInfo, NodeWalker walker)
		{
			characterInfo.Input.MoveStick.X = 0.0f;
			characterInfo.Input.MoveStick.Y = 0.0f;
			characterInfo.Input.AttackStick.X = -0.5f;
			characterInfo.Input.AttackStick.Y = -0.5f;
			Stopwatch timer = new Stopwatch ();
			for (int i = 0; i < MAX_TIMES; ++i) {
				timer.Start ();
				walker.Restart ();
				walker.ComputeAllSteps ();
				timer.Stop ();
			}
			System.Console.WriteLine ("Time elapsed : " + timer.Elapsed.TotalMilliseconds / MAX_TIMES);
			System.Console.WriteLine ("walker.IsComplete : " + walker.IsComplete);
			System.Console.WriteLine ("walker.Outcome : " + walker.Outcome);
			System.Console.WriteLine ("IsMoving : " + characterInfo.Current.IsMoving);
			System.Console.WriteLine ("IsGuardUp : " + characterInfo.Current.IsGuardUp);
		}

		static void Test2 (CharacterInfo characterInfo, NodeWalker walker, Stopwatch timer)
		{
			characterInfo.Input.MoveStick.X = -0.5f;
			characterInfo.Input.MoveStick.Y = -0.5f;
			characterInfo.Input.AttackStick.X = 0.0f;
			characterInfo.Input.AttackStick.Y = 0.0f;
			timer.Reset ();
			for (int i = 0; i < MAX_TIMES; ++i)
			{
				timer.Start ();
				walker.Restart ();
				walker.ComputeAllSteps ();
				timer.Stop ();
			}
			System.Console.WriteLine ("Time elapsed : " + timer.Elapsed.TotalMilliseconds / MAX_TIMES);
			System.Console.WriteLine ("walker.IsComplete : " + walker.IsComplete);
			System.Console.WriteLine ("walker.Outcome : " + walker.Outcome);
			System.Console.WriteLine ("IsMoving : " + characterInfo.Current.IsMoving);
			System.Console.WriteLine ("IsGuardUp : " + characterInfo.Current.IsGuardUp);
		}
	}
}
