
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    
    Grid Map;//to get grid class involved
    public Transform Original_Point;//Set Original_Point
    public Transform Destination_Point;//Set Destination_Point
    public List<Node> system_decision;


    private void Awake()//run when start
    {
        Map = GetComponent<Grid>();//to get game manager class involved
    }

    private void Update()//Update is called for every frame
    {
        Make_Decision(Original_Point.position, Destination_Point.position);//choose the path from start to Destination
       
        
            
    }

    void Make_Decision(Vector3 Node_One, Vector3 Node_Two)
    {
        Node Node_First = Map.Gets_closest(Node_One);//Obtain the node next to Original_Point
        Node Node_Second = Map.Gets_closest(Node_Two);//Obtain the node next to Destination_Point

        List<Node> Node_List_One = new List<Node>();//this will store the set of currently discovered nodes that are not evaluated yet.

        HashSet<Node> Node_List_Two = new HashSet<Node>();//closed list which does not check any value.

        Node_List_One.Add(Node_First);//add the starting node to the Node_List_One, which is the openlist

        while (Node_List_One.Count > 0)//while loop runs when Node_List_One count more than 0
        {
            Node Node_A = Node_List_One[0];//Create first object and put it into the Node_List_One
            for (int n = 1; n < Node_List_One.Count; n++)//Loop through from the second object
            {
                if (Node_List_One[n].Sum < Node_A.Sum || Node_List_One[n].Sum == Node_A.Sum && Node_List_One[n].Cost_H < Node_A.Cost_H)//Compare the Fcost
                {
                    Node_A = Node_List_One[n];//set the current node
                }
            }
            Node_List_One.Remove(Node_A);//Remove that from the Node_List_One
            Node_List_Two.Add(Node_A);//And add it to the Node_List_Two

            if (Node_A == Node_Second)//If the current node is the same as the target node
            {
                GetFinalPath(Node_First, Node_Second);//Calculate the final path
            }

            foreach (Node Node_Next in Map.GetNextNode(Node_A))//Loop through each neighbor of the current node
            {
                if (!Node_Next.Blocked || Node_List_Two.Contains(Node_Next))//continue to search if we got a wall or it is already checked 
                {
                    continue;
                }
                int Movement = Node_A.Cost_G + Get_Path_Distance(Node_A, Node_Next);//Get the FCost of the next_node

                if (Movement < Node_Next.Cost_G || !Node_List_One.Contains(Node_Next))//If the f cost is greater than the g cost or it is not in the open list
                {
                    Node_Next.Cost_G = Movement;//Set the g cost to the f cost
                    Node_Next.Cost_H = Get_Path_Distance(Node_Next, Node_Second);//Set the h cost
                    Node_Next.P_Node = Node_A;//Set the parent of the node for retracing steps

                    if (!Node_List_One.Contains(Node_Next))//it node is not in list one
                    {
                        Node_List_One.Add(Node_Next);//Add 
                    }
                }
            }

        }
    }



    void GetFinalPath(Node Node_Start, Node Node_End)
    {
        List<Node> system_decision = new List<Node>();//result list 
        Node Node_B = Node_End;//Node to store the current node being checked

        while (Node_B != Node_Start)
        {
            system_decision.Add(Node_B);//Add that node to the final path
            Node_B = Node_B.P_Node;//Move onto its parent node
        }

        system_decision.Reverse();//use reverse function to get the order

        Map.system_decision = system_decision;//return the result of the final path

    }
//Return the sum function
    int Get_Path_Distance(Node X, Node Y)
    {
        int Num_One = Mathf.Abs(X.Position_Num_One - Y.Position_Num_One);
        int Num_Two = Mathf.Abs(X.Position_Num_Two - Y.Position_Num_Two);

        return Num_One + Num_Two;
    }
}
