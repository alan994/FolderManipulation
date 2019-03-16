using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FolderManipulation.MovingImplementations
{
	public class Pattern_01x01 : PatternBase, IMovingImplementation
	{
		public string GetTargetFolderName(string rootFolder, string fileName)
		{
			Regex SNumberENumberRegex = new Regex(@"\d{2}x\d{2}");
			return this.GetTargetFolderName(SNumberENumberRegex, (s) => s.Substring(0, 2), (s) => s.Substring(3, 2), rootFolder, fileName);
		}
	}
}
