using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulation.MovingImplementations
{
	public interface IMovingImplementation
	{
		string GetTargetFolderName(string rootFolder, string fileName);
	}
}
