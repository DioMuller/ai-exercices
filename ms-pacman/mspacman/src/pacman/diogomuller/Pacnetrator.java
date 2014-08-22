package pacman.diogomuller;

import java.util.ArrayList;

import pacman.controllers.Controller;
import pacman.game.Game;
import pacman.game.Constants.DM;
import pacman.game.Constants.GHOST;
import pacman.game.Constants.MOVE;

public class Pacnetrator extends Controller<MOVE>
{	
	private static final int MIN_DISTANCE=20;	//if a ghost is this close, run away
	private static final int NEAR_DISTANCE=50;
	
	public MOVE getMove(Game game,long timeDue)
	{			
		int current=game.getPacmanCurrentNodeIndex();
		int ghosts_nearby = 0;
		
		//Strategy 1: if any non-edible ghost is too close (less than MIN_DISTANCE), run away
		for(GHOST ghost : GHOST.values())
		{
			if(game.getGhostEdibleTime(ghost)==0 && game.getGhostLairTime(ghost)==0)
			{
				int distance = game.getShortestPathDistance(current,game.getGhostCurrentNodeIndex(ghost));
				if( distance < MIN_DISTANCE) // Run if it is TOO close.
				{
					return game.getNextMoveAwayFromTarget(game.getPacmanCurrentNodeIndex(),game.getGhostCurrentNodeIndex(ghost),DM.PATH);
				}
				else if( distance < NEAR_DISTANCE ) // Count if it's just close.
				{
					ghosts_nearby++;
				}
			}
		}
		
		//Strategy 2: find the nearest edible ghost and go after them 
		int minDistance=Integer.MAX_VALUE;
		GHOST minGhost=null;		
		
		for(GHOST ghost : GHOST.values())
		{
			if(game.getGhostEdibleTime(ghost)>0)
			{
				int distance=game.getShortestPathDistance(current,game.getGhostCurrentNodeIndex(ghost));
				
				if(distance<minDistance)
				{
					minDistance=distance;
					minGhost=ghost;
				}
			}
		}
		
		if(minGhost!=null)	//we found an edible ghost
			return game.getNextMoveTowardsTarget(game.getPacmanCurrentNodeIndex(),game.getGhostCurrentNodeIndex(minGhost),DM.PATH);
		
		//Strategy 3: go after the pills and power pills
		int[] targetsArray = getClosestPills(game, ghosts_nearby > 1); // 2 or more ghosts nearby = seek power pill.
		
		//return the next direction once the closest target has been identified
		return game.getNextMoveTowardsTarget(current,game.getClosestNodeIndexFromNodeIndex(current,targetsArray,DM.PATH),DM.PATH);
	}
	
	public int[] getClosestPills(Game game, boolean seekPower)
	{
		int[] pills=game.getPillIndices();
		int[] powerPills=game.getPowerPillIndices();		
		
		ArrayList<Integer> targets=new ArrayList<Integer>();
		
		if( !seekPower ) // If player DOES NOT want power pills, seek normal pills.
		{
			for(int i=0;i<pills.length;i++)					//check which pills are available
			{
				if(game.isPillStillAvailable(i))
					targets.add(pills[i]);
			}
		}

		
		if( seekPower ) // Checks if player WANTS power pills.
		{
			for(int i=0;i<powerPills.length;i++)
			{
				if(game.isPowerPillStillAvailable(i))
					targets.add(powerPills[i]);				
			}
		}
		
		int[] targetsArray=new int[targets.size()];		//convert from ArrayList to array
		
		for(int i=0;i<targetsArray.length;i++)
			targetsArray[i]=targets.get(i);
		
		return targetsArray;
	}
}