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
        public int MinimaxFunction(Node node, int depth, int alpha, int beta, bool maximizingPlayer)
            {
                if (depth == 0 || node.IsTerminal)
                {
                    return node.GetHeuristicValue();
                }

                List<Node> currentNodeList = node.GetChilds();

                if (maximizingPlayer)
                {
                    int value = int.MinValue;
                    foreach (Node childNode in currentNodeList)
                    {
                        value = Math.Max(value, MinimaxFunction(childNode, depth - 1, alpha, beta, false));
                        alpha = Math.Max(alpha, value);
                        if (beta <= alpha)
                            break; // Beta cutoff
                    }
                    return value;
                }
                else
                {
                    int value = int.MaxValue;
                    foreach (Node childNode in currentNodeList)
                    {
                        value = Math.Min(value, MinimaxFunction(childNode, depth - 1, alpha, beta, true));
                        beta = Math.Min(beta, value);
                        if (beta <= alpha)
                            break; // Alpha cutoff
                    }
                    return value;
                }
            }
    }
}
    

