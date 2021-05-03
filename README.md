<a href="https://jakestewart.uk/">
    <img src="https://avatars.githubusercontent.com/u/42218259?v=4" alt="Jake Stewart Logo" title="Jake Stewrat Weather App" align="right" height="60">
</a>

# :jigsaw: Light Puzzle Game :joystick:

[Light Puzzler] is a simple to use puzzle game. Simply try to turn all the tiles off and you win, nothing complicated about that, or is there?

This App was built within a day for a technical challenge. It taught me more about the C# language and .Net framework alongside some simple XAML for the front end user interface.

## Tech Stack

- C#
- .NET 4.7.2
- XAML

## Running

This app is very simple to run, just download the source code and build it in VSCode or Visual Studio 2019+. You can also run the .exe in the Release folder.

## Theory

We have a 5x5 Grid containing a bunch of Button Objects.

- The grid is split up into a bunch of columns and rows for example Col0, Col1, Col2, Col3 and Col4, alongside Row0, Row1, Row2, Row3 and Row4 as shown in both the document screenshots below.
- We have a simple 1D array that stores the state of each button object, with each button being either active or inactive. This array matches up with the grid by having each item in the array match a single cell on the Grid as shown in screenshot 1.
- This allows us to match up a col / row with an index in that array, for example (Col1, Row2) would match the index 6. The math behind this is to get the column, then get the row and multiply by the column count (In our case it's 5 as we have 5 columns total).

_Example_

To get the Index for Col2, Row4 we would simply do:

- 2 + (4 \* 5) = 22

![Grid Layout Index](/Screenshots/Doc_Layout_1.png?raw=true "Index") Screenshot 1 ![Grid Layout Coords](/Screenshots/Doc_Layout_2.png?raw=true "Coords") Screenshot 2

## Screenshots

![Application in progress](/Screenshots/Game_1.png?raw=true "Game Running") ![Application in progress](/Screenshots/Game_2.png?raw=true "Game Running") ![Application in progress](/Screenshots/Game_3.png?raw=true "Game Running") ![Application in progress](/Screenshots/Game_Gif.gif?raw=true "Game Running")

## Links

- [My Personal Site](https://jakestewart.uk/)
- [My Freelance Site](https://fika-digital.co.uk/)
