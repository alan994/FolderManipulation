using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulation.MovingImplementations
{
	public static class MovingImplementationFactory
	{
		public static IMovingImplementation GetHanlder(MovingImplementationType type)
		{
			switch (type)
			{
				case MovingImplementationType.Pattern_S01E01:
					return new Pattern_S01E01();
				case MovingImplementationType.Pattern_01x01:
					return new Pattern_01x01();
				case MovingImplementationType.Pattern_01x1:
					return new Pattern_01x1();
				case MovingImplementationType.Pattern_1x01:
					return new Pattern_1x01();
				case MovingImplementationType.Pattern_1x1:
					return new Pattern_1x1();
				case MovingImplementationType.Pattern_S1E01:
					return new Pattern_S1E01();
				case MovingImplementationType.Pattern_101:
					return new Pattern_101();
				case MovingImplementationType.PatternS01_E01:
					return new Pattern_S01_E01();
				case MovingImplementationType.Pattern_Season_1_Episode_01:
					return new Pattern_Season_1_Episode_01();
				case MovingImplementationType.Pattern_Season_01_Episode_01:
					return new Pattern_Season_01_Episode_01();
				default:
					throw new NotImplementedException();
			}

		}
	}
}
