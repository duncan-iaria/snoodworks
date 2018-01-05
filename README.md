# Snoodworks
## A super simple game framework meant for extension
### Perfect for game jams? Maybe so, maybe no!

## Usage
Make a new scene and attatch a Level script to a GameObject in the scene. The level will automatically spawn the game instance and associated requirements (GUI/View/Controller/Inputter). If a Game already exists, then it will just get the reference to that game. In this way, the level is aware of the Game, and the Game has references to all the other major elements.

## General Design
The Game has references to all the other major components (GUI/VIEW/CONTROLLER/INPUTTER). The flow is kinda like this: Input -> Controller -> Pawn -> Specific Pawn controls.

## Components Inlcuded:
- Game - singleton which has references to other major components
- View - meant for managing the view of the game (has a rig/camera which can be targeted)
- GUI - contains all the gui for the game and any hooks that are required
  - GUITransition - used to manage the transitions (currently meant to be used between level loads)
- Inputter - meant for gathering all the incoming inputs - will forward to a controller if it exists
- Controller - meant for keeping track of the current pawn to forward inputs to - wont forward if no pawn exists
- Level - meant for connecting the Pawns and the level to the rest of the game
- Pawn - something that is controller, most the time they are controlled by the current player