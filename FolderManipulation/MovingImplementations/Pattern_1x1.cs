using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FolderManipulation.MovingImplementations
{
	public class Pattern_1x1 : PatternBase, IMovingImplementation
	{
		public string GetTargetFolderName(string rootFolder, string fileName)
		{
			Regex SNumberENumberRegex = new Regex(@"\d{1}x\d{1}");
			return this.GetTargetFolderName(SNumberENumberRegex, (s) => "0" + s.Substring(0, 1), (s) => "0" + s.Substring(2, 1), rootFolder, fileName);
		}
	}
}
