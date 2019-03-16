using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FolderManipulation.MovingImplementations
{
	public class Pattern_101 : PatternBase, IMovingImplementation
	{
		public string GetTargetFolderName(string rootFolder, string fileName)
		{
			Regex SNumberENumberRegex = new Regex(@"\d{3}");
			return this.GetTargetFolderName(SNumberENumberRegex, (s) => "0" + s.Substring(0, 1), (s) => s.Substring(1, 2), rootFolder, fileName);
		}
	}
}
