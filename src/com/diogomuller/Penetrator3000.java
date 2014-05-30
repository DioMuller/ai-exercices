package com.diogomuller;
import robocode.*;
import java.awt.Color;

// API help : http://robocode.sourceforge.net/docs/robocode/robocode/Robot.html

enum FightingStates 
{
	SEARCHING,
	ATTACKING,
	FIXEDSEARCHING,
	TURNING,
	RUNNING
}

/**
 * Penetrator3000 - a robot by DiogoMuller
 */
public class Penetrator3000 extends Robot
{
	
	private FightingStates _current;
	/**
	 * run: Penetrator3000's default behavior
	 */
	public void run() 
	{
		_current = FightingStates.SEARCHING;
		setColors(Color.black,Color.red,Color.yellow); // body,gun,radar

		// Robot main loop
		while(true) 
		{
			double arc = 15.0;
			
			switch( _current )
			{
				case SEARCHING:
					turnRight(10);
					break;
				case ATTACKING:
					fire(Rules.MAX_BULLET_POWER);
					ahead(50);
					arc = 15.0;
					_current = FightingStates.FIXEDSEARCHING;
					break;
				case FIXEDSEARCHING:
					turnRight(arc);
					turnLeft(arc);
					arc += 15.0;
					if( arc > 90 ) _current = FightingStates.SEARCHING;
					break;
				case TURNING:
					back(20);
					turnRight(180);
					_current = FightingStates.SEARCHING;
					break;
				case RUNNING:
					// Replace the next line with any behavior you would like
					back(10);
					turnRight(90);
					break;
			}
		}
	}

	/**
	 * onScannedRobot: What to do when you see another robot
	 */
	public void onScannedRobot(ScannedRobotEvent e) 
    {
		// Replace the next line with any behavior you would like
		_current = FightingStates.ATTACKING;
	}

	/**
	 * onHitByBullet: What to do when you're hit by a bullet
	 */
	public void onHitByBullet(HitByBulletEvent e) 
	{
		_current = FightingStates.RUNNING;
	}
	
	/**
	 * onHitWall: What to do when you hit a wall
	 */
	public void onHitWall(HitWallEvent e) 
	{
		_current = FightingStates.TURNING;
	}	
}
								