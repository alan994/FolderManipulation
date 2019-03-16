using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FolderManipulation.MovingImplementations
{
	public class Pattern_S01E01 : PatternBase, IMovingImplementation
	{
		public string GetTargetFolderName(string rootFolder, string fileName)
		{
			Regex SNumberENumberRegex = new Regex(@"(S|s)\d{2}(e|E)\d{2}");
			return this.GetTargetFolderName(SNumberENumberRegex, (s) => s.Substring(1, 2), (s) => s.Substring(4, 2), rootFolder, fileName);
		}
	}
}
