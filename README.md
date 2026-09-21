# GameEngineInClassActivities

I'm John Philip Underwood, and Im trying to do like Technical Art in the form of 3D modeling and maybe some shader and VFX work on the side. 

# In class activity 1:

I was only able to get as far as to create the ground, and a player controller script with moving left and right. You can jump but there is nothing checking the ground.

What I struggled the most is coding, specifically the C# because I havent done much programming in so long, but setting this project up took a while because Unity is slow in setting up the project and allowing me to switch over to the old input system because im more familiar with that. 

# In class activity 2:

<img width="1330" height="815" alt="image" src="https://github.com/user-attachments/assets/83056464-d26c-4d91-b640-50c1fcd59ef1" />

So, I was able to modify the first in class activity project to try and replicate Super Mario Bros. I have to accomplish the following:

-Implemented the new input system.

-Player movement and ground checking for jumping.

-2 enemy types: Goomba and Koopa classes derived from the base Enemy class. The koopa shell once kicked will continuously move and bounce around, not even jumping on it will stop it. The koopa shell overall in the direction of where it goes is kinda buggy. 

<img width="927" height="510" alt="image" src="https://github.com/user-attachments/assets/5119b4ff-46fa-42a6-b80b-01d81cca3ead" />

<img width="825" height="435" alt="image" src="https://github.com/user-attachments/assets/4f9318f8-6203-4ed0-8d04-ac9e79e007cc" />


-The gold block and breakable brick block scripts from the base Block class. 

-I have unfinished code for the fire flower powerup. 

-A lose state where your player character disappears when killed by an enemy or shell. 

-A win state where you can touch the flag pole to cause the flag to go down via lerping between positions on the y axis. 

<img width="857" height="472" alt="image" src="https://github.com/user-attachments/assets/b6ed0350-8033-4765-ac9a-cf8479851168" />

Reflection:

It was pretty challenging for me, only because I haven't touched C# in Unity for so long. The Koopa class I struggled with the most because of the shell functionality for when you stomp on it, and trying to get it to be kicked around without causing issues was messy. 

OOP Usage:

For the principles used in this project, I have used inheritance and polymorphism in making base classes and derived classes with inherited features for the different blocks and enemies. I have also used encapsulation to make it where certain properties like the direction to move be private, and other public properties like move speed to be freely modified on inspector and by other scripts. 
