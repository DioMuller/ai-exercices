package competition.diogomuller;

import ch.idsia.ai.agents.Agent;
import ch.idsia.mario.engine.sprites.Mario;
import ch.idsia.mario.environments.Environment;


/**
 * Created by Diogo on 11/08/2014.
 */
public class TestMario implements Agent
{


    private String name;
    private boolean[] action;


    public TestMario()
    {
        setName("Test Mario");
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
                break;
            case 0: // SMALL MARIO
                break;
            default: // EXISTENTIAL CRISIS MARIO
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