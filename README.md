# Elucidate
This game is tested for 2 players, but it can hold more!

Quick Notes:
    The game has networked multiplayer, not local. To test
    the networked multiplayer start the application multiple
    times on your computer then switch between windows. The 
    game can be played single player, but the win conditions 
    are different since it is meant to be player vs. player.

CREATING A LOBBY:
    When starting a game, fill in the lobby name. Then simply
    click create and you will be loaded into the game,
    assuming the lobby name isn't already taken. Note, that
    once in a lobby, only the host client can start the game!

JOINING A LOBBY:
    When trying to join a lobby, fill in the lobby name and
    click join, if the lobby exists, you will join the lobby.


HOW TO PLAY:
    Player Controls
        Movement 
            Controlled by using the W, A, S, D keys.

        Aiming
            Controlled by using the mouse, the player will always face
            towards the mouse.
        
        Shooting
            Fire a bullet by left clicking. The bullet will go in the 
            direction that the player is looking. Each bullet will illuminate 
            the surrounding of its path.

        Picking Up Items
            Equip a new gun by pressing the SpaceBar while on top of the gun.

	Pause
	    Press escape to toggle the pause menu. Be warned, this will not 
	    actually pause the game, just prevent you from moving! Currently,
	    the options menu does not work, but the other buttons do.

    Win Condition
        Be the last human player standing in the battle arena.
        Use different guns to help you throughout the level!
	
        If playing in Singleplayer you must find and kill all 
	of the enemy AI in the level to win.

IMPORTANT NOTES:
    AI Modes:
        Chaser
            This is our original/default AI that has a normal movement speed, 
            detection radius, and behavioral focus. When this AI spots you,
            they will chase you until the end of time!

        Tactical
            The goal of this AI was very similar to Chaser, except for the fact 
            that it will stop chasing you at some point. It's a bit smarter and 
            takes its time to try and get you.

        Strafer
            This AI knows that staying still is gonna get it killed, therefore when
            the target is in range, it will strafe and circle them, changing direction
            and speed at random times and values.

        Collider
            For this AI, we wanted to have a different approach compared to all the
            other enemy robots we have made so far. This AI is a small droid that 
            is covered in spiked, they will charge full speed ahead at you, causing
            damage, then leaving to get another charge in later.

        Chicken
            Lastly, we decided to have a small droid that would be scared of the player,
            running away the moment they get too close.

HAVE FUN!

Known Bugs:

	Some audio options do not work.
	
	players will continually shoot when the user clicks off screen.

	some collisions and possibly pausing the game can cause the player to character to aim
	slightly away from the cursor.

	Upon disconnecting from a game, an error message occurs, but the game remains running appropriately.

	If a player plays a multiplayer game in which the game ends due to all but one player 
        disconnecting without dying(ie. the leave option in the pause menu) and then any player 
        attempts to play a single player game, the game will crash on win or loss condition.
	This does not occur in multiplayer and since the game is meant to be multiplayer, this bug
	was no the highest priority.
