# Elucidate

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

    Win Condition
        Defeat all enemies, currently they are all AIs with different modes.
        Use different guns to help you throughout the level!

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
