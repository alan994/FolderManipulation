using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FolderManipulation.MovingImplementations;

namespace FolderManipulation
{
	class Program
	{
		static void Main(string[] args)
		{
			//CreateEmptyFolders();
			//RenameFolders();
			//RenameMoviesFolderToContainYear();
			MoveSeriesInPropriateFolders();
		}

		private static void RenameMoviesFolderToContainYear()
		{
			var rootPath = @"H:\Movies";
			var directoryList = Directory.GetDirectories(rootPath);
			Regex r = new Regex(@"(19|20)\d{2}");
			int numberOfMoviesWithoutyear = 0;
			foreach (var moviePath in directoryList)
			{
				HashSet<int> years = new HashSet<int>();

				var filePaths = Directory.GetFiles(moviePath);
				foreach (var filePath in filePaths)
				{
					var match = r.Match(filePath);
					var yearStr = match.Value;
					var year = -1;
					if (int.TryParse(yearStr, out year) && year != -1)
					{
						years.Add(year);
					}
				}

				if (years.Count != 0)
				{
					Console.WriteLine(moviePath + " --> " + $"{moviePath} ({years.FirstOrDefault()})");
					//Directory.Move(moviePath, $"{moviePath} ({years.FirstOrDefault()})");
				}
				else
				{
					numberOfMoviesWithoutyear++;
				}
			}

			Console.WriteLine("total count of movies = " + directoryList.Length);
			Console.WriteLine("Number of movies without year: " + numberOfMoviesWithoutyear);
		}

		private static void RenameFolders()
		{
			var targetFolderPath = @"G:\My videos\Serije\Yukon men\Sezona 2";
			var targetWordToRename = "Yukon Men S02E";
			var correctWordToRename = "Yukon Men Sezona 02 Epizoda ";

			var folders = Directory.GetDirectories(targetFolderPath);
			foreach (var path in folders)
			{
				var originalFolderName = Path.GetFileName(path);
				var folderName = originalFolderName.Replace(targetWordToRename, correctWordToRename);
				if (originalFolderName != folderName)
				{
					var newPath = path.Replace(originalFolderName, folderName);
					Directory.Move(path, newPath);
				}
			}
		}

		private static void CreateEmptyFolders()
		{
			var targetFolderPath = @"G:\My videos\Serije\The Sopranos\Season 6";
			var seasonNumber = "06";
			var numberOfEpisodes = 21;
			var listOfEpisodes = new List<int>() { 8, 10, 12 };
			var name = "The Sopranos";
			var targetAlgoritam = TargetAlgoritam.List;


			CreateEmptyFolders(targetFolderPath, seasonNumber, numberOfEpisodes, listOfEpisodes, name, targetAlgoritam);
		}

		private static void CreateEmptyFolders(string targetFolderPath, string seasonNumber, int numberOfEpisodes, List<int> listOfEpisodes, string name, TargetAlgoritam targetAlgoritam)
		{
			if (targetAlgoritam == TargetAlgoritam.List)
			{
				for (int i = 1; i <= numberOfEpisodes; i++)
				{
					var folderName = $"{name} Sezona {seasonNumber} Epizoda {i.ToString("00")}";
					Console.WriteLine("Kreiram: " + folderName);
					if (!Directory.Exists(Path.Combine(targetFolderPath, folderName)))
					{
						Directory.CreateDirectory(Path.Combine(targetFolderPath, folderName));
					}
				}
			}
			else if (targetAlgoritam == TargetAlgoritam.Specific)
			{
				foreach (var i in listOfEpisodes)
				{
					var folderName = $"{name} Sezona {seasonNumber} Epizoda {i.ToString("00")}";
					Console.WriteLine("Kreiram: " + folderName);
					if (!Directory.Exists(Path.Combine(targetFolderPath, folderName)))
					{
						Directory.CreateDirectory(Path.Combine(targetFolderPath, folderName));
					}
				}
			}
		}

		private static void MoveSeriesInPropriateFolders()
		{
			var seasonNumber = 11;
			var numberOfEpisodes = 10;
			var targetFolderPath = $@"H:\TV Series\X-Files\Season" + $" {seasonNumber}";
			var seasonNumberStr = seasonNumber.ToString("00");

			DirectoryInfo parentDir = Directory.GetParent(targetFolderPath);
			string parent = parentDir.FullName;
			var name = Path.GetFileName(parent);

			var targetAlgoritam = TargetAlgoritam.List;

			MoveSeriesInPropriateFolders(targetFolderPath, seasonNumberStr, numberOfEpisodes, name, targetAlgoritam);
		}

		private static void MoveSeriesInPropriateFolders(string targetFolderPath, string seasonNumber, int numberOfEpisodes, string name, TargetAlgoritam targetAlgoritam)
		{
			CreateEmptyFolders(targetFolderPath, seasonNumber, numberOfEpisodes, null, name, targetAlgoritam);
			var filePaths = Directory.GetFiles(targetFolderPath);
			foreach (var filePath in filePaths)
			{
				var movingImplementationType = MovingImplementationHelper.GetMovingImplementationType(filePath);
				var handler = MovingImplementationFactory.GetHanlder(movingImplementationType);
				var folderToBeMoved = handler.GetTargetFolderName(targetFolderPath, filePath);
				if (string.IsNullOrEmpty(folderToBeMoved))
				{
					continue;
				}
				Console.WriteLine(filePath + " --> " + folderToBeMoved);
				//TODO: Move file in to folder
				var finalDestination = Path.Combine(folderToBeMoved, Path.GetFileName(filePath));
				File.Move(filePath, finalDestination);
			}

		}

		private static void RecursiveMoveFromSeriaPath()
		{
			var root = @"";
			var seasonPaths = Directory.GetDirectories(root);
			foreach (var seasonPath in seasonPaths)
			{
				var targetPath = seasonPath;
				Regex r = new Regex(@"\d{1,2}");
				var seasonNumber = r.Match(Path.GetFileName(targetPath)).Value;


				MoveSeriesInPropriateFolders();
			}

		}
	}

	internal enum TargetAlgoritam
	{
		List = 1,
		Specific = 2
	}
}
