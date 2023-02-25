using static AresTrainerV3.Enums.EnumsList;

namespace AresTrainerV3.ItemInventory
{
	public interface IItemsOperationsGenerator
	{
		public List<int> ItemsForSaleListGenerate();
		public List<int> ItemsFromStorageListGenerate();
		public List<int> ItemsToStorageMoveListGenerate();
	}
}