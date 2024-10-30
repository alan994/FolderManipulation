

using System.IO;
using System.Text.RegularExpressions;

//new Worker().PrintPathsForSeasons("\\\\MEDIA\\jagar\\Serije");


//var path = @"\\MEDIA\jagar\Serije\Big Little Lies"; - DONE
//var path = @"\\MEDIA\jagar\Serije\Boardwalk Empire"; - DONE
//var path = @"\\MEDIA\jagar\Serije\Chicago Fire"; - DONE
//var path = @"\\MEDIA\jagar\Serije\Revenge"; - DONE
//var path = @"\\MEDIA\jagar\Serije\Masters Of Sex"; - DONE
//var path = @"\\MEDIA\jagar\Serije\Star Trek - Discovery"; - DONE
//var path = @"\\MEDIA\jagar\Serije\Divorce"; - DONE
//var path = @"\\MEDIA\jagar\Serije\Blacklist"; - DONE
//var path = @"\\MEDIA\jagar\Serije\The Undoing";  - DONE

//var path = @"\\MEDIA\jagar\Serije\Modern Family"; - DONE



//var path = @"\\MEDIA\jagar\Serije\The Man In The High Castle"; -DONE
//var path = @"\\MEDIA\jagar\Serije\Flashpoint"; -DONE
//var path = @"\\MEDIA\jagar\Serije\American Horror Story"; - DONE

var paths = new List<string>
{
    //@"\\MEDIA\jagar\Serije\Resident",
    //@"\\MEDIA\jagar\Serije\Homeland",
    //@"\\MEDIA\jagar\Serije\Mad Men",
    //@"\\MEDIA\jagar\Serije\The Sopranos",
    //@"\\MEDIA\jagar\Serije\The Haunting Of Hill House",
    //@"\\MEDIA\jagar\Serije\Silicon valley",
    //@"\\MEDIA\jagar\Serije\American Crime Story",
    //@"\\MEDIA\jagar\Serije\Star Trek - Enterprise",
    //@"\\MEDIA\jagar\Serije\Star Trek - Strange New Worlds",
    //@"\\MEDIA\jagar\Serije\Six Feet Under",
    //@"\\MEDIA\jagar\Serije\NCIS Los Angeles",
    //@"\\MEDIA\jagar\Serije\Luther",
    //@"\\MEDIA\jagar\Serije\Castle Rock",
    //@"\\MEDIA\jagar\Serije\The Witcher",
    //@"\\MEDIA\jagar\Serije\Lie To Me",
    //@"\\MEDIA\jagar\Serije\Ordeal By Innocence",
    //@"\\MEDIA\jagar\Serije\Blue Bloods",
    //@"\\MEDIA\jagar\Serije\The Chicago Code",
    //@"\\MEDIA\jagar\Serije\Chernobyl",
    //@"\\MEDIA\jagar\Serije\911",
    //@"\\MEDIA\jagar\Serije\True Detective",
    //@"\\MEDIA\jagar\Serije\Star Trek - The Original Series",
    //@"\\MEDIA\jagar\Serije\The Terror",
    //@"\\MEDIA\jagar\Serije\Prison Break",
    //@"\\MEDIA\jagar\Serije\Love Death Robots",
    //@"\\MEDIA\jagar\Serije\Marcella",
    //@"\\MEDIA\jagar\Serije\House MD",
    //@"\\MEDIA\jagar\Serije\The Walking Dead",
    //@"\\MEDIA\jagar\Serije\Star Trek - Voyager",
    //@"\\MEDIA\jagar\Serije\Star Trek - Picard",
    //@"\\MEDIA\jagar\Serije\Human Target",
    //@"\\MEDIA\jagar\Serije\X-Files",
    //@"\\MEDIA\jagar\Serije\The Resident",
    //@"\\MEDIA\jagar\Serije\Orange Is The New Black",
    //@"\\MEDIA\jagar\Serije\The Big Bang Theory",
    //@"\\MEDIA\jagar\Serije\Burn Notice",
    //@"\\MEDIA\jagar\Serije\Broadchurch",
    //@"\\MEDIA\jagar\Serije\The Escape Artist",
    //@"\\MEDIA\jagar\Serije\Taken",
    //@"\\MEDIA\jagar\Serije\Star Trek - Deep Space 9",
    //@"\\MEDIA\jagar\Serije\Sherlock",
    //@"\\MEDIA\jagar\Serije\Star Trek - The Next Generation",
    //@"\\MEDIA\jagar\Serije\Hijack",
    //@"\\MEDIA\jagar\Serije\Mare Of Easttown",
    //@"\\MEDIA\jagar\Serije\Sex Education",
    //@"\\MEDIA\jagar\Serije\The Fall",
    //@"\\MEDIA\jagar\Serije\I Used To Be Fat",
    //@"\\MEDIA\jagar\Serije\Haven",
    //@"\\MEDIA\jagar\Serije\Happy Valley",
    //@"\\MEDIA\jagar\Serije\Person of Interest",
    //@"\\MEDIA\jagar\Serije\You",
    //@"\\MEDIA\jagar\Serije\Miami Medical",
    //@"\\MEDIA\jagar\Serije\Roadkill",
    //@"\\MEDIA\jagar\Serije\The Outsider",
    //@"\\MEDIA\jagar\Serije\New Amsterdam",
    //@"\\MEDIA\jagar\Serije\The New Pope",
    //@"\\MEDIA\jagar\Serije\Star Trek - Lower Decks",
    //@"\\MEDIA\jagar\Serije\Dead Like Me",
    //@"\\MEDIA\jagar\Serije\The Comey Rule",
    //@"\\MEDIA\jagar\Serije\The Young Pope",
    //@"\\MEDIA\jagar\Serije\Mr. Mercedes",
    //@"\\MEDIA\jagar\Serije\CSI Cyber",
    //@"\\MEDIA\jagar\Serije\Vikings",
    //@"\\MEDIA\jagar\Serije\Hawaii five 0",
    //@"\\MEDIA\jagar\Serije\Departure",
    //@"\\MEDIA\jagar\Serije\American Gods",
    //@"\\MEDIA\jagar\Serije\The Staircase",
    //@"\\MEDIA\jagar\Serije\MacGyver",
    //@"\\MEDIA\jagar\Serije\The Sinner",
    //@"\\MEDIA\jagar\Serije\House Of Cards",
    //@"\\MEDIA\jagar\Serije\Yukon men",
    //@"\\MEDIA\jagar\Serije\Quantico",
    //@"\\MEDIA\jagar\Serije\Chasing Shadows",
    //@"\\MEDIA\jagar\Serije\The Knick",
    //@"\\MEDIA\jagar\Serije\The Affair",
    //@"\\MEDIA\jagar\Serije\The Good Doctor",
    //@"\\MEDIA\jagar\Serije\Mindhunter",
    //@"\\MEDIA\jagar\Serije\Game of Thrones",
    //@"\\MEDIA\jagar\Serije\Big Mouth",
    //@"\\MEDIA\jagar\Serije\Sex And The City",
    //@"\\MEDIA\jagar\Serije\S.W.A.T",
    //@"\\MEDIA\jagar\Serije\Midsomer Murders",
    //@"\\MEDIA\jagar\Serije\Manhunt Unabomber",
    //@"\\MEDIA\jagar\Serije\Hannibal"
};

var worker = new Worker();
foreach (var path in paths)
{
    try
    {
        worker.PrintSeasonNamesNotMatchingEnglishName(path);
    }
    catch(Exception ex)
    {
        Console.WriteLine($"GENERAL EXCEPTION: {ex.Message}");
    }
}


//Directory.Move(@"C:\Users\alanj\Desktop\Seazon 01\Season 01 Episode 01\directory", @"C:\Users\alanj\Desktop\Seazon 01\directory");
//File.Move(@"C:\Users\alanj\Desktop\Seazon 01\Season 01 Episode 01\file.txt", @"C:\Users\alanj\Desktop\Seazon 01\file.txt");




public class Worker
{
    public void PrintPathsForSeasons(string rootPath)
    {
        foreach (var dir in Directory.GetDirectories(rootPath))
        {
            Console.WriteLine($"Starting processing ${dir}");
            //PrintSeasonNamesNotMatchingEnglishName(dir);
            Console.WriteLine("");
            Console.WriteLine("");

        }
    }

    public void PrintSeasonNamesNotMatchingEnglishName(string seriesRootPath)
    {
        var reg = new Regex(@"Season \d+");
        foreach (var dir in Directory.GetDirectories(seriesRootPath))
        {

            //if (!reg.Match(dir).Success)
            //{

            //var changedPath = ReplaceCroatianNameWithEnglish(dir);
            //var hasProblem = dir == changedPath;
            //if(hasProblem)
            //{
            //    Console.WriteLine($"Skipping path {dir}");
            //    continue;
            //}

            //Console.WriteLine($"I will replace \"{dir}\" with \"{changedPath}\"");
            //Directory.Move(dir, changedPath);                
            //}

            if (reg.Match(dir).Success)
            {
                PrintContentOfPath(dir);
            }

        }
    }

    public string ReplaceCroatianNameWithEnglish(string path)
    {
        var directoryInfo = new DirectoryInfo(path);

        for (int i = 20; i >= 1; i--)
        {
            var targetMatch = $"Sezona {i}";
            string? secundaryMatch = i < 10 ? $"Sezona 0{i}" : null;

            var targetValue = i < 10 ? $"Season 0{i}" : $"Season {i}";
            if (directoryInfo.Name.Contains(targetMatch))
            {
                return RemoveEverythingExceptSeasonWithNumber(directoryInfo, targetValue);
            }
            else if (!string.IsNullOrEmpty(secundaryMatch) && directoryInfo.Name.Contains(secundaryMatch))
            {
                return RemoveEverythingExceptSeasonWithNumber(directoryInfo, targetValue);
            }
        }

        return directoryInfo.FullName;

        string RemoveEverythingExceptSeasonWithNumber(DirectoryInfo directoryInfo, string targetName)
        {
            return Path.Combine(directoryInfo.Parent!.FullName, targetName).ToString();
        }
    }

    public void PrintContentOfPath(string seasonRootPath)
    {
        try
        {
            foreach(var episodeFolderPath in Directory.GetDirectories(seasonRootPath))
            {
                //Console.WriteLine(episodeFolderPath);

                foreach (string directory in Directory.GetDirectories(episodeFolderPath).ToList())
                {
                    var fileName = Path.GetFileName(directory);

                    var originalPath = directory;
                    var targetPath = Path.Combine(seasonRootPath, fileName);

                    Directory.Move(originalPath, targetPath);
                    Console.WriteLine($"{originalPath} --> {targetPath}");
                }

                foreach (var file in Directory.GetFiles(episodeFolderPath))
                {
                    var fileName = Path.GetFileName(file);

                    var originalPath = file;
                    var targetPath = Path.Combine(seasonRootPath, fileName);

                    File.Move(originalPath, targetPath);
                    Console.WriteLine($"{originalPath} --> {targetPath}");
                }

                Directory.Delete(episodeFolderPath);

            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Exception message: " + ex.Message);
            Console.WriteLine("Season root Path: " + seasonRootPath);
            Console.WriteLine("------------------------------------------------------------------");
        }

        
    }
}