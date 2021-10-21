# COMP 376 - Assignment 2


Your first Unity programming assignment is to develop a 2D variation of Paperboy but in
a COVID-19 context. In this variation rather than delivering papers, the game will have a
protagonist fighting against COVID-19 by providing masks and vaccines, disinfecting the
surfaces, and promoting social distancing. The game will be a single-screen platformer to
be set in a shopping mall or a funfair. Obstacles will be replaced by people of five kinds,
fully vaccinated, unvaccinated but wearing a mask, unvaccinated without masks, highly
susceptible to infection and infected ones. All five kind of people must be visually distinct
and must be attended to accordingly. The player will get a fixed amount of time to attend
all the anomalies in a level from passing mask to disinfecting the surfaces glowing due to
infection, and even sending infected people in isolation. Additionally, a mob of unmasked
shoppers will appear as a short outburst occasionally to offer bonus earning opportunity
to the player. The mob will have a mix of all five kind of people and the player will try and
achieve as high a score possible. People sent in isolation will immediately leave the scene
but can touch various items along the way. The player can promote social distancing via
many innovative ways (creative freedom). A non-disinfected surface will spread the virus
if left unattended. Highly susceptible people must be attended to first as they may die if
exposed to the virus. People with masks are also prone to infection from contact with any
of the infected surfaces. A change of level will be felt through the increased difficulty due
to fast paced motion or a larger people intake. The goal of the player is to get a high score
and, also to complete as many levels as possible.



## Basic Game Play:
Points are awarded for successfully averting the spread of the virus and promoting social
distancing.
- Every surface that is disinfected will yield 2 points and every missed infected surface will
penalize the player with 1 point in addition to further spread of the virus. All people will
spawn in random places, will follow random trajectories.
- To add to the challenge, the moving people should increase in speed or in numbers every
time there is a change of level.
- The player will be able to hand out two masks at a time if two unmasked people are in the
proximity of the player and will get a bonus of 2 points in this case.
- The mod should arrive at least twice in each level at random times.
- The player will be able to address only one anomaly at a time.
- Innovative measures to promote social distancing will yield a 5-point bonus to the player.


## Game Versions:
You have to develop two versions of the game as follows:
- Version-Normal – In this version, the basic version of the game is implemented as above.
The unending game ends when the player reaches a negative score of twenty.
- Variant-Special - In this version a player can get a speed boost for himself/herself or can
slow down time to do as many things as possible. In this special mode, number of people
will also increase. The player will use a special key to toggle this mode for a limited time
(say, 3 seconds). Missed opportunities will cost 2 points and successful actions will yield
1 point each in this mode.

