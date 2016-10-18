# London Tube Problem
Paul Kehrer - 10/17/2016

There's not a whole lot of code, but I'll give a brief overview anyways:

There's two intersting classes:

### StationMapBuilder.cs
This class converts the data from the .csv file from https://www.doogal.co.uk/LondonTubeLinesCSV.ashx and turns it into a map-like data structure.
The map is pretty simple, it's made up of Stations and Connections. Stations have a collection of connections, and Connections are a
Line name and a destination station.

### StopFinder.cs
This is the class which actually handles the logic for solving the problem. It takes a starting station and a number of stops as arguments.
To find all of the stops, it uses simple recursion to calculate the stations that are N-1 stops away from all of the stations connected to 
the current station. Once the requested distance is 0, it returns only the current station. To avoid looping back on itself, a list of
"already visited" stations are passed along with each call.

Everything else is just models for the data and user input handling (the latter was perhaps not entirely necessary..)
