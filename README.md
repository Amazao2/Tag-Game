<h1>CS4482a: APP 2 – Write a Tag Game</h1>

This project is quick game I made for a university course meant to learn developing a video 
game using the Unity Game Engine.

WARNING: Code formatting and comments are almost non-existant. Functionality and learning the
engine's interface where the primary concern on this small project. I may revisit the code and
add comments in the future as a learning exercise.

<h2>PROJECT REQUIREMENTS (from professor):</h2>

The University of Western Ontario
</br>London, Ontario, Canada
</br>Department of Computer Science
</br>CS 4482a/9511a – Video Game Programming and Engine Development
</br>APP 2 – Write a tag game

<b>1 Introduction</b>

The year is 2011. You are one of the hottest PC game programmers around. The CEO of
Bioware comes to you in a panic one Friday afternoon; they need a new game, and they it
now.

Fortunately for you, it has been decided that the game will be a modern “re-imagining”
of the now-legendary Ultimate Tag: Deathmatch ’83, Beyond Thunderdome, originally
released for the Atari 2600. Of course, expectations will be high: players will expect
gameplay that reminds them of the classic game, but also demand all the shiny eye candy
that helps them justify the cost of their new Radforce Lobotomizer X900 graphics card.
One player will be “it” at any given time and when that player collides with another
player, the other player will become “it”. The human player should experience the game
from a first-person viewpoint, as in a first-person shooter game.
You have a great deal of flexibility in terms of the setting. You may use either an indoor
or outdoor map, at your discretion. You must implement at least one computer player,
with some sort of AI (it doesn’t have to be good, but bonus marks if it is), though you may
choose to implement multiple opponents (bonus marks).
Since this isn’t a course on 3D modelling and level design you may use the default
resources that come with you SDK of choice. You may also use any other resource you
find on the internet (just make sure you give credit to whomever built the models you are
using).

<b>1.1 Requirements</b>
<ul>
  <li>At least 2 players:</li>
    <ul>
      <li>A human controlled player.</li>
      <li>At least one computer controlled player.</li>
      <li>Players must be represented by 3D meshes.</li>
      <li>Players must display with an animated run-cycle or walk-cycle when they move. It doesn’t 
        have to be fancy, but it has to be animated.</li>
    </ul>
  <li>You must detect collisions between players and swap who is “it”.</li>
  <li>You do not have to indicate which player is currently “it”.</li>
  <li>You do, however, have to let the human player know if he is currently “it” or not.</li>
  <li>You must do this in an obvious way.</li>
  <li>You may choose for the tag match to take place either indoors or outdoors.</li>
</ul>
