# COVID-19 BUSTER


You're a janitor in a mall and are trying to stop the spread of COVID-19. There are multiple actions you
can make to achieve this goal.

# Gameplay
## Vaccinate

- 1st dose will make people less likely to be infected. 1 point.
- 2nd dose will make them immune. 

## Hand out masks

Infected people with masks are less likely to spread the virus by air. The people around the infected people 
also wear masks, there is very little chance for them to get infected. 

## Send to isolation
Infected people can be sent to isolation, they can however still spread the virus while leaving.

## Disinfect surfaces
Infected people may infect surfaces they come across. Make sure to disinfect those, as they're highly 
likely to infect others that come across them.

## Enforce social distancing
Sometimes, it may be a good idea to scream at people and tell them to stay 2m apart. Those that heard you 
will most likely keep that in mind. 


# Things to keep in mind
- "Levels" are represented by an increase in dificulty. People will get faster and spawn faster. 
- There are vulnerable people. They are very likely to get infected. 
- You have a limited suply of vaccines and masks at any given time. Try to keep pickups available for quick refils. It may be important to balance out how many vaccines/ masks you give out.

    i.e. Immune people won't get infected, thus if in a pinch, prioritize giving masks to vulnerable and non vaccinated people.

- The game ends when score reaches -20. The highest score achieved is kept as highscore.
- You can get bonus points by giving out 2 masks in quick succession
- Infected areas need to be disinfected ASAP, otherwise they'll spread the virus really fast, also penalizing your score over time.
- You can enter SPECIAL MODE, which will slow down time. During SPECIAL MODE, missed opportunities will cost 2 points and successful actions will be limited to 1 point each.
Be careful because this will also cause a wave of people to enter the mall.
- Enforcing social distancing on at least 2 people will yield a 5 point bonus, in addition to helping reduce the spread of the virus.


# Controls
**WASD**: Move

**LMB**: Shoot mask

**RMB**: Shoot vaccine

**Q**: Enter SPECIAL MODE

**E**: Disinfect area

**F**: Send to isolation

**SPACE**: Enforce social distancing

**ESC**: Pause game



# How to use code

Copy the Assets, Packages and Project settings folders to an empty directory, and open folder as a unity project. I'm using Unity 2020.3.17f1.
# Acknowledgements 

- Unity2D doesn't support NavMesh natively, and so I'm using a free 2D implementation by h8man
[NavMeshPlus](https://github.com/h8man/NavMeshPlus) which adapts the existing Unity NavMesh to 
work in 2D.
- I've yoinked the SS13 floor and wall tiles, as well as the base character body. The rest 
 of the pixel-art (hair, clothes, items, objects...) is done by me 


