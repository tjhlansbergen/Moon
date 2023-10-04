# Available commands:
- exit (close, quit, q)
    to close the application

- up, down, left, right
    to move the cursor

- clear
    to clear the currently selected tile

- new <type>
    to build a tile of type <type> on the currently selected tile
    Example: `new road`

# Upcoming commands:
- info
    to display info on the currently selected tile

# Chaining commands
Multiple commands can be chained by seperating them with a semicolon.
Example: `left; down; clear` will move left, then down and then build on that tile

# Using repetition
Some commands support repetition, provide a number to repeat the command
Example: `left 10` moves the cursor left 10 times.
Example: `left 10; down 20;` moves the cursor left 10 times and then down 20 times.
