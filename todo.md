## Wyrmshorde - The Plan
First, make campaign
- auto generate
- iterate loot
- Hire heroes to clear out enemy dungeons
	- different clasLses, random characters, different strengths and weaknesses
	- preview/teaser for dungeon

### Gameplay loop:
- raid dungeon
- get money
- use money to build base
	-base has training and where you live but also dungeon shit
	- spend rewards from raid and base on upgrade
	- repeat

### Then, dungeon designer
- share programs
- challenges mean gold when a hero hits them?
	- want to encourage dungeon designs that are fun, challenging, doable. Rating system. Cash per play not per failure - but how to avoid make boring easy maps?
- reward is proportionate to all the features. Decorations = a little more loot. Player does not lose loot when their dungeon is completed
- Colorways for floor and walls. Maybe you gotta buy em?
- Is it for players or bots? 
	- The joy of building a killbox - but it needs to be possible

Room features
- monster
- damsel
- empty 
- decorated room
- [ ] traps
	- [ ] swinging hammer
	- [ ] false floor?
	- [ ] pit
	- [ ] pressure plate activation
	- [ ] shooting darts
	- [ ] locked doors
	- [ ] enemies?
	- [ ] look to Fall Guys for inspiration
- [ ] treasure
- [ ] bear trap
- [ ] import cheat console
	- [ ] hide/show ceilings
- room root
	- [x] door
	- [x] wall
	- [ ] decor
	- [ ] stairs up/down
	- [x] lights
		- [x] flicker
		- [ ] animated mesh
		- [x] emmissive material
		- [ ] spot lights?
	- [x] door animation
	- [x] ability to add more rooms
		- [x] emmissive model
		- [x] on click hitbox
		- [x] hide until hovered
	torches are laggy. setting to turn off? Can I make them less laggy? maybe by turning into spot. Or, one light per room regardless of torch presense?
		- master torch controller: each torch, on instance, adds istelf to the master's list
		-setting for graphics
- [ ] player
	- [x] fly controls (thanks Sergey Stafeev)
	- [ ] UI
		- [ ] other tools?
			-redecorate
			-bulldoze wall
			-turn off torches (expensive)
			- add wall
			- going to need a pathfinder test to make sure you can still complete all rooms 
			- HORSE!
 - [ ] adventurer
	- [ ] character customization
		- [ ] plume color lol
	- [ ] open doors
	- [ ] duck/slide
	- [ ] pick up stuff
	- [ ] class system?
		-knight: extra hitpoint
		-mage: can teleport
		-rogue: can pick locks
		- ranger: favored terrain
- [ ] walls cutaway
up and down? spiral staircase?
	- add additional staircases
	- check if no staircases
- [ ] save files
	-parser
	should be sharable and editable, similar to stardew. Calculate cost at run time
- [x] delete rooms
- [ ] scoring
	- [ ] rooms in parallel get the cost of the cheaper rooms

Give knight a torch!

Can move objects if desired, like Portal mode. 

Before submitting to gallery, must be able to beat (Horse mode)

Decor is free! (Or real cheap)
- but don't you want to unlock it?

Weight makes you slower (loot, carrying chair? etc)

loot a magic weapon that glows, use it in future dungeons

Place traps wherever, but check for collisions?

Money spent on the dungeon equals how much you get out of it. If they want to make an arboretum, who am I to say no. Make decor cheap and let people rate each others' dungeons


### Multiplayer

- https://partner.steamgames.com/doc/features/multiplayer#networking
- steam has low cost servers, would work for something like file sharing