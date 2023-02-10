namespace AresTrainerV3.MoveModels
{
	internal interface IMoveToPoint
    {
        public void MoveToDestination(CoordsPoint endPosition, List<Obstacle> obstacles);


	}
}
