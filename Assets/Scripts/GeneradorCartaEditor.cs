using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

[CustomEditor(typeof(GeneradorCarta))]
public class GeneradorCartaEditor : Editor
{
    //private int[] previousProbabilities;

    //public override void OnInspectorGUI()
    //{
    //    GeneradorCarta generadorCarta = (GeneradorCarta)target;

    //    DrawDefaultInspector();

    //    generadorCarta.amountOfCardsToCreate = EditorGUILayout.IntField("Amount of Cards To Create", generadorCarta.amountOfCardsToCreate);

    //    while (generadorCarta.rankProbabilities.Count < 5)
    //    {
    //        generadorCarta.rankProbabilities.Add(0);
    //    }

    //    EditorGUILayout.Space();
    //    EditorGUILayout.LabelField("Rank Probabilities", EditorStyles.boldLabel);
    //    EditorGUI.indentLevel++;
    //    for (int i = 0; i < generadorCarta.rankProbabilities.Count; i++)
    //    {
    //        if (previousProbabilities == null || previousProbabilities.Length < generadorCarta.rankProbabilities.Count)
    //        {
    //            previousProbabilities = new int[generadorCarta.rankProbabilities.Count];
    //        }

    //        previousProbabilities[i] = generadorCarta.rankProbabilities[i];

    //        generadorCarta.rankProbabilities[i] = EditorGUILayout.IntSlider("Rank " + i + " Probability", generadorCarta.rankProbabilities[i], 0, 100);
    //    }
    //    EditorGUI.indentLevel--;

    //    int totalProbability = generadorCarta.rankProbabilities.Sum();
    //    EditorGUILayout.LabelField("Total Probability: " + totalProbability);

    //    if (totalProbability != 100)
    //    {
    //        AdjustProbabilities(generadorCarta);
    //    }
    //}

    //private void AdjustProbabilities(GeneradorCarta generadorCarta)
    //{
    //    int adjustedIndex = -1;
    //    for (int i = 0; i < generadorCarta.rankProbabilities.Count; i++)
    //    {
    //        if (generadorCarta.rankProbabilities[i] != previousProbabilities[i])
    //        {
    //            adjustedIndex = i;
    //            break;
    //        }
    //    }

    //    if (adjustedIndex != -1)
    //    {
    //        int difference = generadorCarta.rankProbabilities.Sum() - 100;

    //        int higherRankIndex = -1;
    //        int highestValue = 0;
    //        for (int i = 0; i < generadorCarta.rankProbabilities.Count; i++)
    //        {
    //            if (i != adjustedIndex && generadorCarta.rankProbabilities[i] > highestValue)
    //            {
    //                higherRankIndex = i;
    //                highestValue = generadorCarta.rankProbabilities[i];
    //            }
    //        }

    //        if (higherRankIndex != -1)
    //        {
    //            generadorCarta.rankProbabilities[higherRankIndex] -= difference;
    //        }
    //        else
    //        {
    //            for (int i = 0; i < generadorCarta.rankProbabilities.Count; i++)
    //            {
    //                if (i != adjustedIndex)
    //                {
    //                    generadorCarta.rankProbabilities[i] -= 1;
    //                    difference--;
    //                    if (difference == 0)
    //                    {
    //                        break;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
}
