using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public Transform Original_Point;
    public LayerMask Box;
    public Vector2 world_units;
    public float Square_Size;
    public float Square_Interval;

    Node[,] A_Star_algorithm_Array;
    public List<Node> system_decision;


    float Node_Total;
    int Size_One, Size_Two;

    
    private void Start()//Function runs when start
    {
        Node_Total = Square_Size * 2;
        Size_One = Mathf.RoundToInt(world_units.x / Node_Total);
        Size_Two = Mathf.RoundToInt(world_units.y / Node_Total);
        CreateGrid();
    }

    void CreateGrid()//Function Create the Grid
    {
        A_Star_algorithm_Array = new Node[Size_One, Size_Two];//Declaretion
        Vector3 Graph_Position = transform.position - Vector3.right * world_units.x / 2 - Vector3.forward * world_units.y / 2;
        for (int a = 0; a < Size_One; a++)//For Loop
            for (int b = 0; b < Size_Two; b++){//For Loop
            {
                Vector3 World_Position = Graph_Position + Vector3.right * (a * Node_Total + Square_Size) + Vector3.forward * (b * Node_Total + Square_Size);//Get the world co ordinates of the bottom left of the graph
                bool Wall = true;

                if (Physics.CheckSphere(World_Position, Square_Size, Box))
                {
                    Wall = false;
                }

                A_Star_algorithm_Array[a, b] = new Node(Wall, World_Position, a, b);
            }
        }
    }

    //Function that gets the next nodes.
    public List<Node> GetNextNode(Node Next_Node)
    {
        List<Node> Next_Node_List = new List<Node>();
        int Position_One_Check;
        int Position_Two_Check;
        Position_One_Check = Next_Node.Position_Num_One + 1;
        Position_Two_Check = Next_Node.Position_Num_Two;
        if (Position_One_Check >= 0 && Position_One_Check < Size_One)
        {
            if (Position_Two_Check >= 0 && Position_Two_Check < Size_Two)
            {
                Next_Node_List.Add(A_Star_algorithm_Array[Position_One_Check, Position_Two_Check]);
            }
        }
        
        Position_One_Check = Next_Node.Position_Num_One - 1;
        Position_Two_Check = Next_Node.Position_Num_Two;
        if (Position_One_Check >= 0 && Position_One_Check < Size_One)
        {
            if (Position_Two_Check >= 0 && Position_Two_Check < Size_Two)
            {
                Next_Node_List.Add(A_Star_algorithm_Array[Position_One_Check, Position_Two_Check]);
            }
        }
        //Check the Top side of the current node.
        Position_One_Check = Next_Node.Position_Num_One;
        Position_Two_Check = Next_Node.Position_Num_Two + 1;
        if (Position_One_Check >= 0 && Position_One_Check < Size_One)
        {
            if (Position_Two_Check >= 0 && Position_Two_Check < Size_Two)
            {
                Next_Node_List.Add(A_Star_algorithm_Array[Position_One_Check, Position_Two_Check]);
            }
        }
        
        Position_One_Check = Next_Node.Position_Num_One;
        Position_Two_Check = Next_Node.Position_Num_Two - 1;
        if (Position_One_Check >= 0 && Position_One_Check < Size_One)
        {
            if (Position_Two_Check >= 0 && Position_Two_Check < Size_Two)
            {
                Next_Node_List.Add(A_Star_algorithm_Array[Position_One_Check, Position_Two_Check]);
            }
        }

        return Next_Node_List;
    }

    //Function that gets the closest node
    public Node Gets_closest(Vector3 world_position)
    {
        float Position_One_X = ((world_position.x + world_units.x / 2) / world_units.x);
        float Position_One_Y = ((world_position.z + world_units.y / 2) / world_units.y);

        Position_One_X = Mathf.Clamp01(Position_One_X);
        Position_One_Y = Mathf.Clamp01(Position_One_Y);

        int Num_One = Mathf.RoundToInt((Size_One - 1) * Position_One_X);
        int Num_Two = Mathf.RoundToInt((Size_Two - 1) * Position_One_Y);

        return A_Star_algorithm_Array[Num_One, Num_Two];
    }


    //Draw Function
    private void OnDrawGizmos()
    {

        Gizmos.DrawWireCube(transform.position, new Vector3(world_units.x, 1, world_units.y));

        if (A_Star_algorithm_Array != null)
        {
            foreach (Node n in A_Star_algorithm_Array)
            {
                if (n.Blocked)
                {
                    Gizmos.color = Color.white;
                }
                else
                {
                    Gizmos.color = Color.black;
                }


                if (system_decision != null)
                {
                    if (system_decision.Contains(n))
                    {
                        Gizmos.color = Color.blue;
                    }

                }


                Gizmos.DrawCube(n.Node_Location, Vector3.one * (Node_Total - Square_Interval));//Draw the node at the position of the node.
            }
        }
    }
}
