BARK
====

An awkward-like where you control a dog.  Made in Unity3D for Molyjam 2013.

Objective
---------

Walk in a straight line.

Goal
----

Cross a room without bumping into objects that make sound.

Controls
--------

Keyboard Input:

-   'B' - Move back right leg

-   'A' - Move back left leg

-   'R' - Move front left leg

-   'K' - Move front right leg

Based on videos of dog locomotion, the key sequence to move the dog properly
should be: A-R-B-K (Arbok!)

Mechanics
---------

Move the dog legs to maintain balance and move forward.  Forward motion is
automatic, but proper motion involves inputting the key sequence (see Controls),
at a specific tempo.

Leg failures (denoted by failing to input the right sequence) have the following
consequences:

-   1 leg failure: moves the body to the side of the leg failure

-   2 leg failure:

    -   If entire side of dog fails (two left legs, or two right legs), move the
        body to the side of the leg failure, and force player to compensate with
        force in the opposite direction of failure by making the dog move
        quicker toward the direction of failure.

    -   If front/back of dog fails (two front legs, or two back legs), move the
        body faster toward the front forcing the player to compensate with the
        opposite legs of failure.

    -   If legs cross-fail (front left, back right or front right, back left),
        body moves quicker toward the front, forcing the player to compensate
        with the opposite legs of failure.

-   3 leg failure:

    -   Leg that did succeed is now unavailable (it's numb), such that it
        automatically fails for next iteration of key sequence.

    -   Body moves to the side of majority leg failure.

    -   Body accelerates toward the side of majority leg failure, forcing player
        to compensate with force opposite of the failure.

-   4 leg failure:

    -   Bark!

Technical Direction
-------------------

### Art Assets Needed

-   Room

-   Chair

-   Lamp

-   Bookcase

-   Dog

    -   Left/Right

        -   Hind/Front Legs\*

    -   Body

\* All these are individual assets that must be modeled and rigged.

### Sound Assets Needed

-   Panting

-   Bark

-   Vase-breaking

-   Thud

-   Chair Grind (against floor)

-   Background Music

### Code Assets Needed

-   Title Screen

-   Dog-behavior Script

-   Trigger for Game End

-   Object on Collision Sound Prompt

-   Key-input
