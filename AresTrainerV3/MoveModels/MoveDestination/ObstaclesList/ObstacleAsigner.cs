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
			if (ProgramHandle.GetCurrentMap == TeleportValues.AllianceSacredLand)
			{
				obstaclesList.Add(createObstacle(802, 152, 816, 134));
			}

			else if (ProgramHandle.GetCurrentMap == TeleportValues.Hollina)
			{
				obstaclesList.Add(createObstacle(0, 0, 1, 1));
			}
			else if (ProgramHandle.GetCurrentMap == TeleportValues.KharonPlateau)
			{
				obstaclesList.Add(createObstacle(166, 180, 171, 177));
				obstaclesList.Add(createObstacle(130, 200, 145, 189));
			}
			return obstaclesList;
		}
	}
}
