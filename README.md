# SnakeGame

## Game made by

* __Inês Gonçalves__
  * a21702076

* __Inês Nunes__
  * a21702520

* __Sara Gama__
  * a21705494

  ## Git repository

We worked in a private repository that will be available publicly in this
[link](https://github.com/FiammaVolts/SnakeGame) after the deadline.
We previously worked in another repository, but due to some issues, we 
had to drop it and start anew.
The old repository can be found here [link](https://github.com/FiammaVolts/SnakeGameOld).

## Task distribution

Both Inês Gonçalves and Inês Nunes worked equally as much, having worked
together in both computers, side by side.
Sara was away during part of the project, having done a menu,
 but when she returned, she worked on the highscore.

* __Inês Gonçalves__
  * Classes:Snake, InterfaceManager, GameManager, Program.
  * Made the UML.
  * Made the Fluxogram.
  

* __Inês Nunes__
  * Classes: Classes:Snake, InterfaceManager, GameManager.
  * Added comments.
  * Made the README
  

* __Sara Gama__
  * Classes: Draw, Highscore.


## Our solution

### Architecture

The program was organized using _classes_ for easier
understanding and to keep the code cleaner.
We have also used _Threads_ for our gameloop, _Files_ and_StreamReader/Writer_ for our highscores.

When launching the game starts by rendering the menu to the player, being given four options.
According to the input, a _switch case_ will call the corresponding _methods_.
The _GameLoop_ will manage everything, by calling the _Update() method_.

For example, the _GameLoop_ will run the game until the player loses, 
calling the _Lose() method_.

We have an _if_ that checks if the "nose"'s position, which is the front of our snake is equal
to our fruit's position. If it is, then our "tail", which is an _array_, will increase by one, the score
will increase by ten.

Once the player loses, their score will be saved and placed on an array, which then will be placed
on our highscore using _Files_ and _StreamReader/Writer_.

### UML Diagram

![UML Diagram](https://i.imgur.com/rTUAtTS.png)

### Fluxogram

<p align="center">
  <img src="https://i.imgur.com/lHH7wqG.png" alt="Fluxogram"/>
</p>

## Conclusions

With this project, we have consolidaded how to use _Files_ and _StreamReader/Writer_'s.
We too have now a better understanding how _Threads_ work and how to use them.

## References

* <a name="ref1">[1]</a> Whitaker, R. B. (2016). The C# Player's Guide
  (3rd Edition). Starbound Software.

* We have used other Snake games as references for ours, which can be found here:
[link](https://www.youtube.com/watch?v=qCPH-T9iGYI&t=9s), [link](https://www.youtube.com/watch?v=b-SvyCHHWsQ).
