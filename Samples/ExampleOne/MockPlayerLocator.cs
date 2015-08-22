using System;

namespace ExampleOne
{
	public class MockPlayerLocator : IPlayerLocator
	{
		private readonly Random mRandom;
		private readonly Player mPlayerOne;
		public MockPlayerLocator (Player playerOne)
		{
			mRandom = new Random ();			
			mPlayerOne = playerOne;
		}

		public bool Find(out Player target)
		{
			//			int roll = mRandom.Next (10);
			//			// odd numbers only
			//			if (roll % 2 == 1)
			//			{
			target = mPlayerOne;
			return true;
			//			}
			//			else
			//			{
			//				target = null;
			//				return false;
			//			}			
		}
	}
}

