using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FolderManipulation.MovingImplementations
{
	public class Pattern_S1E01 : PatternBase, IMovingImplementation
	{
		public string GetTargetFolderName(string rootFolder, string fileName)
		{
			Regex SNumberENumberRegex = new Regex(@"(S|s)\d{1}(e|E)\d{2}");
			return this.GetTargetFolderName(SNumberENumberRegex, (s) => "0" + s.Substring(1, 1), (s) => s.Substring(3, 2), rootFolder, fileName);
		}
	}
}
