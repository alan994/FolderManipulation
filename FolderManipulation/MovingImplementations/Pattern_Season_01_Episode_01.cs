using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FolderManipulation.MovingImplementations
{
	public class Pattern_Season_01_Episode_01 : PatternBase, IMovingImplementation
	{
		public string GetTargetFolderName(string rootFolder, string fileName)
		{
			Regex SNumberENumberRegex = new Regex(@"(Season|season)\s\d{2}\s(episode|Episode)\s\d{2}");
			return this.GetTargetFolderName(SNumberENumberRegex, (s) => s.Substring(7, 2), (s) => s.Substring(18, 2), rootFolder, fileName);
		}
	}
}
