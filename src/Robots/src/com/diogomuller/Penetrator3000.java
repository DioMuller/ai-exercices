package com.diogomuller;
import robocode.*;
import java.awt.Color;

// API help : http://robocode.sourceforge.net/docs/robocode/robocode/Robot.html

enum States {
	SEARCHING,
	SHOOTING,
	RUNNING,
	FOUNDTARGET
}

/**
 * Penetrator 3000 - a robot by Diogo Muller
 */
public class Penetrator3000 extends Robot
{
	private States currentState; 
	/**
	 * run: DiogoMuller's default behavior
	 */
	public void run() {
		int turns = 0;
		// Initialization of the robot should be put here
		currentState = States.SEARCHING;

		// After trying out your robot, try uncommenting the import at the top,
		// and the next line:

		setColors(Color.black,Color.blue,Color.yellow); // body,gun,radar

		// Robot main loop
		while(true) {
			switch(currentState)
			{
				case SEARCHING:
					turnLeft(15);
					turns++;
					if( turns > 30 ) currentState = States.RUNNING;
					break;
				case SHOOTING:
					fire(Rules.MAX_BULLET_POWER);
					currentState = States.FOUNDTARGET;
					break;
				case FOUNDTARGET:
					turns = 0;
					fire(Rules.MAX_BULLET_POWER);
					ahead(50);
					break;
				case RUNNING:
					turns = 0;
					ahead(100);
					currentState = States.SEARCHING;
					break;
				default:
					currentState = States.SEARCHING;
			}
		}
	}

	/**
	 * onScannedRobot: What to do when you see another robot
	 */
	public void onScannedRobot(ScannedRobotEvent e) {
		e.getName();
		// Replace the next line with any behavior you would like
		currentState = States.SHOOTING;
	}

	/**
	 * onHitByBullet: What to do when you're hit by a bullet
	 */
	public void onHitByBullet(HitByBulletEvent e) {
		// Replace the next line with any behavior you would like
		//currentState = States.RUNNING;
	}
	
	/**
	 * onHitWall: What to do when you hit a wall
	 */
	public void onHitWall(HitWallEvent e) {
		// Replace the next line with any behavior you would like
		back(20);
		turnRight(120);
	}	
	
	public void onBulletMissed(BulletMissedEvent event){
		currentState = States.SEARCHING;
	}
	
	public void onRobotDeath(RobotDeathEvent event) {
		if( currentState == States.SHOOTING )
		{
			currentState = States.SEARCHING;
		}
	}

}
																																								