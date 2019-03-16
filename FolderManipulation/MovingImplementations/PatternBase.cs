using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FolderManipulation.MovingImplementations
{
	public abstract class PatternBase
	{
		protected string GetTargetFolderName(Regex r, Func<string, string> seasonNumberFunc, Func<string, string> episodeNumberFunc, string rootFolder, string fileName)
		{
			//rootFolder = @"H:\TV Series\American Crime Story\OJ Simpson";
			//fileName = @"H:\TV Series\American Crime Story\OJ Simpson\American.Crime.Story.S01E03.mp4";
			
			var code = r.Match(fileName).Value.Trim().Replace(@"\", "").Replace(@".", "");
			var seasonNumber = seasonNumberFunc(code);
			var episodeNumber = episodeNumberFunc(code);

			var partOfDirectoryName = $"Sezona {seasonNumber} Epizoda {episodeNumber}";

			var directoryList = Directory.GetDirectories(rootFolder);
			foreach (var directoryPath in directoryList)
			{
				if (directoryPath.Trim().EndsWith(partOfDirectoryName))
				{
					return directoryPath;
				}
			}

			return null;
		}
	}
}
