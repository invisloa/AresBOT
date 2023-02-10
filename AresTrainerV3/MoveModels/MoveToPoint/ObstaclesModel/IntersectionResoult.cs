namespace AresTrainerV3.MoveModels
{
	public struct IntersectionResult
	{
		public bool IntersectsWithSomething;
		public Line IntersectedLine;

		public IntersectionResult(bool intersectsWithSomething, Line intersectedLine)
		{
			IntersectsWithSomething = intersectsWithSomething;
			IntersectedLine = intersectedLine;
		}
	}
}
