/* 
 * Tutorial Gestures.
 * They tell the user to lift the flag or get it down, depending where
 * is it at any moment.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Tuto : MonoBehaviour
{
    [Header("References to the tutorial objects in UI")]
    public GameObject gestureUp;
    public GameObject gestureDown;

    private IEnumerator Start()
    {
        var wait = new WaitForSeconds(1f);
        while (true)
        {
            gestureUp.SetActive(CS_Flag.liftState < 0.5f);
            gestureDown.SetActive(CS_Flag.liftState >= 0.5f);
            yield return wait;
        }
    }
}
