using System;
using BirdNest.Nodes;

namespace ExampleOne
{
	public class Enemy
	{
		public Player Target;
		public int X;
		public bool WithinDistance()
		{ 
			return Math.Abs(Target.X - X) <= 0;
		}

		public bool HasTarget ()
		{
			return Target != null;
		}

		public Result MoveTowards ()
		{
			int diff = (X - Target.X);

			if (diff == 0)
			{
				return Result.SUCCESS;
			}

			X += (diff > 0) ? -1 : 1;
			return Result.SUCCESS;
		}

		public bool IsTargetDead()
		{
			return Target.HealthPoints <= 0;
		}

		public Result HitTarget ()
		{
			--Target.HealthPoints;
			return Result.SUCCESS;
		} 
	}	
}

