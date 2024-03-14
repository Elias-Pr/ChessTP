using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MiniMax
{
    public class MiniMaxLogic
    {
        //model wikipedia
    
        /*function minimax(node, depth, maximizingPlayer) is
        if depth = 0 or node is a terminal node then
    return the heuristic value of node
    if maximizingPlayer then
    value := −∞
    for each child of node do
    value := max(value, minimax(child, depth − 1, FALSE))
    else (* minimizing player *)
    value := +∞
    for each child of node do
    value := min(value, minimax(child, depth − 1, TRUE))
    return value*/

        public int MinimaxFunction(Node node, int depth, bool maximizingPlayer)
        {
            if (depth == 0 || node.IsTerminal)
            {
                return node.GetHeuristicValue();
            } 
            int value = 0; //La valeur heuristique du node (max ou min en fonction du tour en cours)

            List<Node> currentNodeList = node.GetChilds();
            
            if (maximizingPlayer)
            {
                value = int.MinValue;
                foreach (Node childNode in currentNodeList)
                {
                    value = Math.Max(value, MinimaxFunction(childNode,
                        depth - 1, false));
                }
            }
            else
            {
                value = int.MaxValue;
                foreach (Node childNode in currentNodeList)
                {
                    value = Math.Min(value, MinimaxFunction(childNode,
                        depth - 1, true));
                }
            }

            return value;
        }

        
            
    }
    
}
