using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSegmentDisplay : MonoBehaviour
{
    public Dictionary<int, bool[]> digitSegments;
    public GameObject[] segments;

    private int currentDigit = 0;

    void Start()
    {
        InitializeDigitSegments();
        DisplayDigit(currentDigit);
    }

    void Update()
    {
        // Überprüfe die Tastatureingabe
        for (int i = 0; i < 10; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                SetCurrentDigit(i);
                break;
            }
        }
    }

    void InitializeDigitSegments()
    {
        digitSegments = new Dictionary<int, bool[]>
        {
            {0, new bool[] { true, true, true, false, true, true, true }},
            {1, new bool[] { false, false, true, false, false, true, false }},
            {2, new bool[] { true, false, true, true, true, false, true }},
            {3, new bool[] { true, false, true, true, false, true, true }},
            {4, new bool[] { false, true, true, true, false, true, false }},
            {5, new bool[] { true, true, false, true, false, true, true }},
            {6, new bool[] { true, true, false, true, true, true, true }},
            {7, new bool[] { true, false, true, false, false, true, false }},
            {8, new bool[] { true, true, true, true, true, true, true }},
            {9, new bool[] { true, true, true, true, false, true, true }}
        };
    }

    void SetCurrentDigit(int digit)
    {
        currentDigit = digit;
        DisplayDigit(currentDigit);
    }

    void DisplayDigit(int digit)
    {
        if (digitSegments.ContainsKey(digit))
        {
            bool[] segmentsToDisplay = digitSegments[digit];

            for (int i = 0; i < segments.Length; i++)
            {
                segments[i].SetActive(segmentsToDisplay[i]);
            }
        }
    }
}
