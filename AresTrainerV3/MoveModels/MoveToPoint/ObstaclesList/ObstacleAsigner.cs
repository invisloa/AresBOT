using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AresTrainerV3.MoveModels.MoveToPoint.ObstaclesList
{
	internal struct ObstacleAsigner
	{
		Obstacle createObstacle(int tlX, int tlY, int bdX, int bdY)
		{
			return new Obstacle(new CoordsPoint(tlX, tlY), new CoordsPoint(bdX, bdY));
		}
		
		public List<Obstacle> GetMapObstacles()
		{
			List<Obstacle> obstaclesList = new List<Obstacle>()
			{
				createObstacle(0,0,1,1)
			};

			if (ProgramHandle.GetCurrentMap == TeleportValues.Hollina)
			{
				obstaclesList.Add(createObstacle(0,0,1,1));
			}
			return obstaclesList;
		}
	}
}
