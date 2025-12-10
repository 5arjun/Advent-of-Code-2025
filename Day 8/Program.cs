using System;
List<JunctionBox> JBList = new List<JunctionBox>();

public class JunctionBox //for initially reading the points from the file
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
    public double distance { get; set; }
}