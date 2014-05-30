package com.diogomuller;
import robocode.*;

import java.awt.Color;

enum DancingStates {
	SEARCHINGPAIR,
	GOINGTO,
	WAITING,
	DANCING,
	REEVALUATING,
	BACKTOSEARCH
}

public class DancingBot extends Robot {
	private DancingStates currentState; 
	/**
	 * run: DancingBot's default behavior
	 */
	public void run() {
		// Initialization of the robot should be put here
		currentState = DancingStates.SEARCHINGPAIR;
		
		setColors(Color.pink,Color.white,Color.red); // body,gun,radar

		// Robot main loop
		while(true) {
			switch(currentState)
			{
				case SEARCHINGPAIR:
					turnLeft(15);
					break;
				case GOINGTO:
					ahead(50);
					break;
				case WAITING:
					break;
				case DANCING:
					turnRight(360);
					turnGunLeft(360);
					turnRadarRight(30);
					turnLeft(360);
					break;
				case REEVALUATING:
					back(10);
					currentState = DancingStates.DANCING;
					break;
				case BACKTOSEARCH:
					back(10);
					currentState = DancingStates.SEARCHINGPAIR;
				default:
					currentState = DancingStates.SEARCHINGPAIR;
			}
		}
	}

	public void onHitRobot(HitRobotEvent e){
		currentState = DancingStates.REEVALUATING;
	}
	
	/**
	 * onScannedRobot: What to do when you see another robot
	 */
	public void onScannedRobot(ScannedRobotEvent e) {
		e.getName();
		// Replace the next line with any behavior you would like
		currentState = DancingStates.GOINGTO;
	}
	
	public void onHitWall(HitWallEvent e)
	{
		currentState = DancingStates.BACKTOSEARCH;
	}
}
			