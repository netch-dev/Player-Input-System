# \# Player Input System

# 

# This is a small recreation of an input routing system I came across while looking through the source code of Unity projects.

# 

# The main idea is to add a layer between Unitys Input System and the gameplay code. Instead of every script listening for input directly, input is routed to whichever context is currently active (Player, Vehicle, UI, etc).

# 

# For example, if the player enters a vehicle, the router switches to the Vehicle context. The same movement and interaction inputs are then sent to the vehicle instead of the player, without every script needing to check the game state or enable/disable actions on its own.

# 

# The goal was to keep input handling simple, make systems more modular, and avoid scattering input logic across multiple components. It also makes it easier to add new contexts later on without changing existing gameplay code.

# 

# This project was mainly an excercise in understanding and recreating an architecture I thought was clever, while putting together my own implementation.

