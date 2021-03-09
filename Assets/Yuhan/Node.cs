using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {

    public int Position_Num_One;//defining the node array position
    public int Position_Num_Two;//defining the node array position

    public bool Blocked;//if it is blocked by the wall
    public Vector3 Node_Location;//The world position of the node.

    public Node P_Node;//defining the previous node to help finding the shortest path

    public int Cost_G;//G (n) - Cost of the path calculated from start node to current node

    public int Cost_H;//H (n) - Cost of the shortest path from the current node to goal node 


    public int Sum { get { return Cost_G + Cost_H; } }// F(n) - Current estimated cost from current node n F(n) = G(n) + H(n)

    public Node(bool wall, Vector3 Location, int P_One, int P_Two)//Constructor
    {
        Blocked = wall;//check if it is blocked by the wall
        Node_Location = Location;//The world position of the node.
        Position_Num_One = P_One;//the position of the node array
        Position_Num_Two = P_Two;//the position of the node array
    }

}
