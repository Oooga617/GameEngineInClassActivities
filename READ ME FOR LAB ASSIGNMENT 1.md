# John Philip Underwood

2026/9/28

Student #: 100982375


# Lab Assignment 2

Project Title: GameEngineInClass1. 

Game loop: This is the very first in class activity being modified to where it is a loose recreation of Mario, but now the enemies have health bars. This was initially done with having the Enemy script instantiate the enemy with the health bar as a prefab when spawned in.  

(I HAVE USED AI TO TRY AND HELP FIGURE OUT HOW TO IMPLEMENT OBSERVER).  

This will do a before implementing Observer patterns, and after implementations.  

Before:  
<img width="1018" height="568" alt="image" src="https://github.com/user-attachments/assets/354b544b-0c4f-486f-a8d2-d6f97cd055b2" />

 

There seems to be spikes in CPU and GPU usage after I implemented the modification of the enemy health bar system. Though at least a few spikes can be from the result of garbage collection systems in Unity.  

After:  
<img width="1276" height="796" alt="image" src="https://github.com/user-attachments/assets/0acc96b8-7f7c-4aa0-ba1b-f3090e237c9a" />

There appear to be very minor improvements, as the entire project uses simple shapes and sprites for it. The player loop and update scene is noticeably reduced by 0.01 millisecond. The observer pattern was implemented by having the HealthScript be inheriting from subject, so it can be notified that the health bar is being updated, and change the bar accordingly.  

 

What did you notice was impacting the performance of your project? 

The majority of the project is very simple, there is no complex graphics or that many objects spawned. At most the profiler shows spikes coming from the CPU, GPU or garbage collection systems.  

 

Which pattern(s) did you implement, and what behavior did they replace? 

I implemented the Observer pattern, and I ended up modifying my project to make it where the enemies have health, and they needed to be jumped on or hit twice to either die as a Goomba, or become a shell as a Koopa. The observer specifically was used to update the health bar to be shorter when the enemy takes damage and only gets notified upon those conditions and not constantly polled.  

 

Do your patterns / technique implementations improve performance? Why or why not? 

The pattern improved performance, but very slightly judging from the second screenshot. This is because that not much is happening over in the project. There are not a lot of objects that can cause a lot of lag from being loaded in, and having their logic executed.  
