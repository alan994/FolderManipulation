using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FolderManipulation.MovingImplementations
{
	public static class MovingImplementationHelper
	{
		public static MovingImplementationType GetMovingImplementationType(string filePath)
		{
			Regex r = new Regex(@"(S|s)\d{2}(e|E)\d{2}");
			if (r.IsMatch(filePath))
			{
				return MovingImplementationType.Pattern_S01E01;
			}

			r = new Regex(@"(Season|season)\s\d{1}\s(episode|Episode)\s\d{2}");
			if (r.IsMatch(filePath))
			{
				return MovingImplementationType.Pattern_Season_1_Episode_01;
			}
			r = new Regex(@"(Season|season)\s\d{2}\s(episode|Episode)\s\d{2}");
			if (r.IsMatch(filePath))
			{
				return MovingImplementationType.Pattern_Season_01_Episode_01;
			}

			r = new Regex(@"(S|s)\d{1}(e|E)\d{2}");
			if (r.IsMatch(filePath))
			{
				return MovingImplementationType.Pattern_S1E01;
			}

			r = new Regex(@"(S|s)\d{2}\s(e|E)\d{2}");
			if (r.IsMatch(filePath))
			{
				return MovingImplementationType.PatternS01_E01;
			}

			r = new Regex(@"\d{2}x\d{2}");
			if (r.IsMatch(filePath))
			{
				return MovingImplementationType.Pattern_01x01;
			}

			r = new Regex(@"\d{3}");
			if (r.IsMatch(filePath))
			{
				return MovingImplementationType.Pattern_101;
			}


			r = new Regex(@"\d{2}x\d{1}\D");
			if (r.IsMatch(filePath))
			{
				return MovingImplementationType.Pattern_01x1;
			}

			r = new Regex(@"\D?\d{1}x\d{2}");
			if (r.IsMatch(filePath))
			{
				return MovingImplementationType.Pattern_1x01;
			}

			r = new Regex(@"\d{1}x\d{1}");
			if (r.IsMatch(filePath))
			{
				return MovingImplementationType.Pattern_1x1;
			}


			return MovingImplementationType.CantDetermen;
		}
	}
}
