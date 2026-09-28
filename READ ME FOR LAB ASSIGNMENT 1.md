# John Philip Underwood

2026/9/28

Student #: 100982375


# Lab Assignment 1

The game I have made is called "Reach Your House", its a simple game of 3 levels where you have to find a key, jump on enemies, and unlock the gate blocking your way to your home. The observer pattern used in this assignment is the Singleton design pattern with the GameManager script:

<img width="632" height="490" alt="image" src="https://github.com/user-attachments/assets/c2bf3c9b-59a8-4930-9bc5-75fd53eb0176" />


How it works is that, a base singleton class is created so that it can be inherited by the GameManager script. The singleton class is set up so that only one instance of it exists at a time as a static instance, and so any other existing instance of the game manager gets deleted. Now the GameManager is static and a singleton, it can be easily accessed by different parts of the game, mainly the PickUp and PlayerController scripts. 

# What element of your game adopts the chosen pattern:

The element of the game that adopts the Singleton pattern is the GameManager script, as it allows the player to move on to different levels by scene switching when the player unlocks the gate and moves onto the next level. The PickUp script works by having it sense the player object collide with it's trigger, causing it to call on the collectKey() method from the GameManager instance and disappear. This makes the game manager object (with reference to the gate game object in the level) make the gate deactive, and thus allowing the player to collide with the house. When the player touches the house, it also calls on the GameManager instance with the nextLevel method that switches to the next scene. However, if the player gets killed by an enemy, it immediately calls on the game manager to retry the level automatically. Finally, the player can also press q to call on the quitGame() method in the GameManager to quickly exit the game. 

# Why is this pattern a good choice for the associated functionality:

The Singleton pattern choice is excellent for the GameManager script as in games you only really need one manager of a specific type to handle things, and in this case a game manager to check and update the conditions for winning and losing. Making the game manager static means that it can be accessed by script without having to directly reference it in code. Also, the game manager object itself persists between scenes, so it is further unnecessary to have multiple game managers given the nature of the Singleton implementation. Also, if you have multiple of these managers there can be unwanted behavior that can cause problems in the game. 
