using System;

static double CalculateEuclideanDistance(JunctionBox p1, JunctionBox p2)
{
    double deltaX = p2.X - p1.X;
    double deltaY = p2.Y - p1.Y;
    double deltaZ = p2.Z - p1.Z;

    double distanceSquared = (deltaX * deltaX) + (deltaY * deltaY) + (deltaZ * deltaZ);
    return Math.Sqrt(distanceSquared);
}

string[] lines = File.ReadAllLines("input.txt");
List<JunctionBox> JBList = new List<JunctionBox>();//for initially reading the points from the file
int idCounter = 0;

foreach (string line in lines) //adds each box to a list
{
    string[] coords = line.Split(',');
    JunctionBox box = new JunctionBox { Id = idCounter, X = int.Parse(coords[0]), Y = int.parse(coords[1]), Z = int.parse(coords[2]) };
    JBList.Add(box);
    idCounter++;
}

List<Connection> allConnections = new List<Connection>(); //hold every single possible connection
for(int i = 0; i < JBList.count; i++)
{
    for (int j = i+1; i < JBList.count; j++)
    {
        JunctionBox boxA = JBList[i];
        JunctionBox boxB = JBList[j];

        Connection conn = new Connection();
        conn.A = boxA;
        conn.B = boxB;
        
        conn.Distance = CalculateEuclideanDistance(boxA, boxB);

        allConnections.Add(conn);//adding to list of every connection
    }
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

