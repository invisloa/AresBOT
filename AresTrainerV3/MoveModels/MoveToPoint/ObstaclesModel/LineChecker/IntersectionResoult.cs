namespace AresTrainerV3.MoveModels.MoveToPoint.ObstaclesModel.LineChecker
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
