package competition.diogomuller;

import ch.idsia.ai.agents.Agent;
import ch.idsia.mario.engine.sprites.Mario;
import ch.idsia.mario.environments.Environment;


/**
 * Created by Diogo on 11/08/2014.
 */
public class DesperateMario implements Agent
{


    private String name;
    private boolean[] action;


    public DesperateMario()
    {
        setName("Desperate Mario");
        reset();
    }

    public void reset()
    {
        action = new boolean[Environment.numberOfButtons];
    }

    public boolean[] getAction(Environment observation)
    {

        switch( observation.getMarioMode() )
        {
            case 2: // FIRE FLOWER
                action[Mario.KEY_RIGHT] = true;
                action[Mario.KEY_JUMP] = observation.mayMarioJump() || !observation.isMarioOnGround();
                action[Mario.KEY_SPEED] = !action[Mario.KEY_JUMP];
                break;
            case 1: // BIG MARIO
                action[Mario.KEY_RIGHT] = true;
                action[Mario.KEY_JUMP] = observation.mayMarioJump() || !observation.isMarioOnGround();
                action[Mario.KEY_SPEED] = true;
                break;
            case 0: // SMALL MARIO
                action[Mario.KEY_RIGHT] = true;
                action[Mario.KEY_JUMP] = observation.mayMarioJump() || !observation.isMarioOnGround();
                action[Mario.KEY_SPEED] = true;
                break;
            default: // EXISTENTIAL CRISIS MARIO
                action[Mario.KEY_RIGHT] = false;
                action[Mario.KEY_JUMP] = true;
                action[Mario.KEY_SPEED] = false;
                action[Mario.KEY_DOWN] = true;
                break;
        }



        return action;
    }


    public Agent.AGENT_TYPE getType()
    {
        return Agent.AGENT_TYPE.AI;
    }

    public String getName() { return name; }

    public void setName(String Name) { this.name = Name; }

}