using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.HealBot.Repoter
{
	internal class RepoterStorage : IGoRepot
	{
		void OpenStorage()
		{
			ProgramHandle.OpenStorageWindow();
		}
		public void GoRepot()
		{
			throw new NotImplementedException();
		}
		void MoveItemsToStorage()
		{

		}
	}
}
