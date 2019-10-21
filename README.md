# Bunni

This is a basic game engine written in C# using monogame.

It is very basic and only has minimal functionality. Much more is planned for the future

It uses a basic component-entity system, with components holding logic and properties holding information important for multiple components. 

For example, the render component needs position information to render something to the screen. However, I don't want to hold the position information inside the render component, because you might want to give something a position without making it render to the screen. Therefore, you can add a property to the entity using the PositionVector class, which can be retrieved and read by many different components without being reliant on any of them.

# Currently Implemented

Right now there are Entity, Component, and Property classes which are the most basic. The ones that are implemented for actual usage is Render, Input, PositionVector,and Life.