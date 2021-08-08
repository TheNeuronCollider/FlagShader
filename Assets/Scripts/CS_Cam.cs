/*
 * Camera´s Rotation and Inertia.
 */

using UnityEngine;
public class CS_Cam : MonoBehaviour
{
    private Touch currTouch;
    
    private float rotCurrTouchX;
    private float rotLastTouchX;
    private float rotDelta;
    private float rotFac = 10f;

    private float inertiaRotVel;
    private float inertiaRotDir;
    private float inertiaDecrease = 100f;

    void Update()
    {
        Rotate();
        Inertia();
    }

    void Rotate()
    { 
        // Abort if there is no finger on the screen.
        if (Input.touchCount == 0)
            return;

        // We calculate how much the finger moved horizontally, compared to the last
        //frame, and apply this value to the rotation in the Y axis.
        currTouch = Input.GetTouch(0);
        if (currTouch.phase == TouchPhase.Began)
        {
            rotCurrTouchX = currTouch.position.x;
            rotLastTouchX = rotCurrTouchX;
        }
        rotLastTouchX = rotCurrTouchX;
        rotCurrTouchX = currTouch.position.x;

        rotDelta = (rotCurrTouchX - rotLastTouchX) * rotFac * Time.deltaTime;
        rotDelta = Mathf.Clamp(rotDelta, -rotFac, rotFac);
        transform.Rotate(0, rotDelta, 0);
        
        // We catch some info for the inertia.
        inertiaRotVel = Mathf.Abs(rotDelta) / Time.deltaTime;
        inertiaRotDir = Mathf.Sign(rotDelta);
    }

    void Inertia()
    {
        // Inertia only works if there is no fingers on screen.
        
        if (Input.touchCount > 0)
            return;

        // The inertia velocity and direction was cached on the Rotation function.
        // Here is just decreased over time until it reaches 0.
        inertiaRotVel -= Time.deltaTime * inertiaDecrease;
        if (inertiaRotVel < 0)
            inertiaRotVel = 0;
        transform.Rotate(0, inertiaRotVel * inertiaRotDir * Time.deltaTime, 0);
    }
}
