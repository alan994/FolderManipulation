using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FolderManipulation.MovingImplementations
{
	public class Pattern_01x1 : PatternBase, IMovingImplementation
	{
		public string GetTargetFolderName(string rootFolder, string fileName)
		{
			Regex SNumberENumberRegex = new Regex(@"\d{2}x\d{1}\D");
			return this.GetTargetFolderName(SNumberENumberRegex, (s) => s.Substring(0, 2), (s) => "0" + s.Substring(3, 1), rootFolder, fileName);
		}
	}
}
