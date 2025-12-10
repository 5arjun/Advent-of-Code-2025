using System;
List<Connection> allConnections = new List<Connection>(); //hold every single possible connection


string[] lines = File.ReadAllLines("input.txt");
List<JunctionBox> JBList = new List<JunctionBox>();//for initially reading the points from the file
int idCounter = 0;
foreach (string line in lines)
{
    string[] coords = line.Split(',');
    JunctionBox box = new JunctionBox{Id = idCounter, X = coords[0], Y = coords[1], Z = coords[2]};
    JBList.Add(box);
    idCounter++;
}


public class JunctionBox 
{
    public int Id { get; set; } // unique ID 0 to n
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
}

public class Connection
{
    public JunctionBox A { get; set; }
    public JunctionBox B { get; set; }
    public double Distance { get; set; }
}