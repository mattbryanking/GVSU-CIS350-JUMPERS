# SRS (Software Requirements Specifications)

## Functional Requirements
1. **Player Movement**
    1. The player character shall stop moving and prepare to jump while the jump button is being pressed down, regardless of other keys pressed.
    2. The player character shall move horizontally with A and D, and shall jump with W, or with the respective arrow keys.
    3. The player character’s anticipated jump direction shall change if the left or right movement keys are pressed while charging a jump.
    4. The player shall not be allowed to move while in midair.
    5. The player shall not be allowed to jump while in midair.
    6. The player shall not carry momentum through movement or jumps.

## Non-Functional Requirements
1. **Player Movement**
    1. There shall be unique animations for idling, running, and jumping.
    2. There shall not be more than a 5-frame delay before pressing a key and starting the corresponding animation.
    3. Movement shall be standardized and shall not depend on any external factors, such as clock speed or monitor resolution.
