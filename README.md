# Documentation

## Description
This project was made as an interview task for Blue Gravity Studios to showcase my programming skills. The objective was to create a store that would allow the player to buy items, as well as a system that would allow players to equip those customization items and sell them back. My personal objective for this was to showcase my programming abilities and knowledge of Prrogramming Patterns, and I believe I did so effectively.

## Interactables
The system works primarily through a series of events and interfaces that communicate closely with each other. To begin, I created an IInteractable interface and an Interactor class. These allow our player to approach an interactable object, such as an item pedestal or the shopkeeper, and use the same trigger to activate their specific action.

## Player
The Player character is mainly composed of a PlayerController (which listens to input events), and an Inventory component, which keeps track of the items the player has and the items they have equipped.

## Item Data
Item data is all stored within Unity’s Scriptable Objects (SOs). These SOs work perfectly as a means of storing data as they can be passed around through events and always reference the same object. To prevent the changes to the objects on the scene affecting the objects saved in the project, you can instantiate a copy of the scriptable object at runtime.

## UI and Events
 The UI is mostly event oriented. For achieving this, I imported an event package I worked on during my time at Vancouver Film School. This package allows us to trigger events through scriptable objects, and any class in the scene who would like to subscribe to the event only needs to have a custom event listener component with the desired event scriptable object.

## Thought Process and Personal Assessment

During the interview, my thought process was clear: deliver what is asked of you first and then go beyond. This meant I would focus on core functionality for most of the systems before adding polish and details. Sadly, this means that in the end, certain features (while complete according to the standards set by the interview) don’t necessarily feel great, since they might be missing sounds or feedback that help with gamefeel. Overall though, I do feel that I delivered the best job I could within the designated timeframe, as I was able to properly design systems that achieve the joib that is needed, while still being fairly robust.

While I may submit my interview build and project in the current state, I whis to continue working on it to hone my skills and polish the product.

# External assets

Oscillator class (modified from side project)
ScriptableObject Events (under GameEvents folder, from school project)
Collider Callbacks class (from current side project)
Editor for Scriptable objects so that sprite was visible while editing (from https://www.sunnyvalleystudio.com/blog/unity-2d-sprite-preview-inspector-custom-editor)

Most sprites downloaded from Kenney (https://www.kenney.nl/)

Placeholder armor equipped sprites credits:
Icons made by <a href="https://www.freepik.com" title="Freepik">Freepik</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a>
Icons made by <a href="https://www.flaticon.com/authors/fuzzee" title="Fuzzee">Fuzzee</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a>
Icons made by <a href="https://www.flaticon.com/authors/andinur" title="andinur">andinur</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a>
Icons made by <a href="https://www.flaticon.com/authors/uniconlabs" title="Uniconlabs">Uniconlabs</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a>
