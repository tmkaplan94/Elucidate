/*
 * Author: Tyler Kaplan
 * Contributors: 
 * Description: Interface for robot states.
 *
 * Takes this.robotController
 */

public interface IRobotState
{
    public void Handle(RobotController robotController);
}
