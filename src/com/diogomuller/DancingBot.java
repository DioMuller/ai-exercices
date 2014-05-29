package com.diogomuller;
import robocode.*;

import java.awt.Color;

enum DancingStates {
	SEARCHINGPAIR,
	GOINGTO,
	WAITING,
	DANCING,
	REEVALUATING
}

public class DancingBot extends AdvancedRobot {
	private DancingStates currentState; 
	/**
	 * run: DancingBot's default behavior
	 */
	public void run() {
		// Initialization of the robot should be put here
		currentState = DancingStates.SEARCHINGPAIR;
		
		setColors(Color.black,Color.blue,Color.yellow); // body,gun,radar

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
					setAhead(5);
					setTurnRight(360D);
					setTurnGunLeft(360D);
					setTurnRadarRight(30D);
					break;
				case REEVALUATING:
					back(10);
					currentState = DancingStates.DANCING;
					break;
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
}
			