using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourSegmentDisplays : MonoBehaviour
{
    public SingleSegmentDisplay[] displays;
    private int currentDisplay = 0;
    private float displaySwitchDelay = 2.0f;

    void Start()
    {
        StartCoroutine(AnimateDisplays());
    }

    IEnumerator AnimateDisplays()
    {
        while (true)
        {
            displays[currentDisplay].gameObject.SetActive(true);
            yield return new WaitForSeconds(displaySwitchDelay);
            displays[currentDisplay].gameObject.SetActive(false);
            currentDisplay = (currentDisplay + 1) % displays.Length;
        }
    }
}
