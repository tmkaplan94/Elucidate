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
    the game starts immediately since there is no actual lobby yet.
    other players can join your game however.

JOINING A LOBBY:
    When trying to join a lobby, fill in the lobby name and
    click join, if the lobby exist, it will put you into the
    game.


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
	    actually pause the game, just prevent you from moving!

    Win Condition
        Be the last player standing in the battle arena.
        Use different guns to help you throughout the level!
	If playing in Singleplayer you must find and kill all 
	of the enemy in the level AI to win.

IMPORTANT NOTES:
    AI Modes:
        Wandering
            This is our original/default AI that has a normal movement speed, 
            detection radius, and behavioral focus (always walking forward).

        Patrolling
            The goal of this AI was to have a higher passive perception. 
            Therefore, they have a wider detection radius and will stop walking 
            forward to turn, giving the illusion of patrolling an area.

        Sprinting
            For this AI, we wanted to have a very proactive AI who is looking for 
            action, so we gave them the highest movement speed with the lowest 
            detection radius.

        Run N Gunning
            This AI is faster than most and has the default detection radius, but
            has a special behavior: it will randomly shoot.

        Camping
            We decided to take Sprinting AI and flip it on its head. This AI has the
            lowest movement speed with the highest detection radius, making it a sniper.

HAVE FUN!

Known Bugs:
	The pause menu persists through scene changes if it is active when a new scene is loaded.

	Some audio options do not work.
	
	players will continually shoot when the user clicks off screen.

	some collisions and possibly pausing the game can cause the player to character to aim
	slightly away from the cursor.
