# Overview

This is a requirements page to aid us in our creation of JUMPERS. There are two main sections for Functional and Non-Functional requirements, with further subsections categorizing each requirement. This document will be updated and expanded as time goes on and the scope of the project advances.

# Functional Requirements
1. Player Movement
    1. The player character shall stop moving and prepare to jump while the jump button is being pressed down, regardless of other keys pressed.
    2. The player character shall move horizontally with A and D, and shall jump with space bar, or with the respective arrow keys.
    3. The player character’s anticipated jump direction shall change if the left or right movement keys are pressed while charging a jump.
    4. The player shall not be allowed to jump while in midair.
    5. The player shall not carry momentum through movement or jumps.
2. Level Design
    1. Levels shall not take more than 1 minute to complete using the optimal path.
    2. Jumps shall not span more than 3 units high, or 4 units in length, unless under the influence of powerups
    3. Each level shall have a minimum of 5 coins, and a maximum of 20 coins available.
3. Character/Object Collision
    1. Character shall not fall through solid objects
    2. Background objects shall not have collision
    3. One way objects shall only have collision on the correct side
    4. Character collision shall cause breakaway objects to start breaking
    5. Break away objects shall lose collision when broken // do if possible

# Non-Functional Requirements
1. Player Movement
    1. There shall be unique animations for idling, running, and jumping.
    2. There shall not be more than a 5-frame delay before pressing a key and starting the corresponding animation.
    3. Movement shall be standardized and shall not depend on any external factors, such as monitor resolution.
2. Level Design
    1. All levels shall have atleast two distinct ways to be completed from start to finish.
    4. Levels shall be able to progress in any of the four cardinal directions, allowing for more creative design.
3. Menus
    1. The use of menus in game shall pause the game, stopping all timers and movement.
    2. Menus shall allow players to use powerups, quit the game, or return to the game.
4. Theme
    1. The levels shall have a consistent theme
    2. The game shall have a pixelated style with a similar background and music
    3. Characters shall have the same art style

