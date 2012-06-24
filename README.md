OpenCurtain
===========

Application for defining, editing, printing, and replaying scripts for (musical) drama, developed in C#.

Feature ideas
-------------
Structure:
Play (contains Acts)
Act (contains scenes)
Setting (defines stage layout/prerequisites, can be used for multiple Scenes)
Scene (divides Act into logical groups, with a Setting, and a set of Characters that appear in the Scene)
Character (appears in one or more Scenes and gets Directions)
Direction (defines what a Character does in a Scene)
Time (relative to Scene, Act or Play)

GUI:
Show Play name in title
Show Act number and name if set
Show Scene number (unique within Play) and name is set
Show Scene description if set
Show Setting name of current Scene
Show Setting description if set

Actions:
Add Act
Add Scene
Add Setting
Add Character
Set current Time
Set Time division (clock, changes (Directions) or bars (Music/Choreography)) 
Add Direction (for Character in Scene at Time)
Replay Play, Act, or Scene from start Time to end Time
