# Available commands:
- exit (close, quit, q)
    to close the application

- up <n>, down <n>, left <n>, right <n>
    to move the cursor by n distance
    Example: `left 10` moves the cursor 10 tiles to the left
    Note: the default of <n> is 1, leaving <n> away will move the cursor by 1. E.g. `up` moves to cursor up 1 tile.

- clear
    to clear the currently selected tile

- new <type>
    to build a tile of type <type> on the currently selected tile
    Example: `new road`

# Proposed commands:
- info
    to display info on the currently selected tile

# Chaining commands
Multiple commands can be chained by seperating them with a semicolon.
Example: `left; down; clear` will move left, then down and then build on that tile

# Using repetition
Repeat a chain of commands using x<n> as the last command in the chain.
Example: `right; new road; x10` will build 10 new roads towards the right of the current position (given that those tiles are available for building)
Example: `left; x10` moves the cursor five tiles to the left (note that `left 10` would do the same and is shorter to type)
