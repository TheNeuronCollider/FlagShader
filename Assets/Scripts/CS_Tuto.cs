using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Tuto : MonoBehaviour
{
    [Header("Referencias a las animaciones de gestos para subir/bajar bandera")]
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
