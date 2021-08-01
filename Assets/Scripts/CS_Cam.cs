using UnityEngine;

public class CS_Cam : MonoBehaviour
{
    //float pixToInches = Screen.dpi
    Touch currTouch;
    float rotLastTouchX;
    float rotCurrTouchX;
    float rotDelta;
    float inertiaRotVel;
    float inertiaRotDir;

    void Update()
    {
        Rotate();
        Inertia();
        Zoom();
    }

    void Rotate()
    {
        if (Input.touchCount == 0)
            return;

        currTouch = Input.GetTouch(0);

        if (currTouch.phase == TouchPhase.Began)
        {
            rotCurrTouchX = currTouch.position.x;
            rotLastTouchX = rotCurrTouchX;
        }

        rotLastTouchX = rotCurrTouchX;
        rotCurrTouchX = currTouch.position.x;

        rotDelta = (rotCurrTouchX - rotLastTouchX) * 10 * Time.deltaTime;
        rotDelta = Mathf.Clamp(rotDelta, -10f, 10f);
        inertiaRotVel = Mathf.Abs(rotDelta) / Time.deltaTime;
        inertiaRotDir = Mathf.Sign(rotDelta);

        transform.Rotate(0, rotDelta, 0);

    }

    void Inertia()
    {
        if (Input.touchCount > 0)
            return;

        inertiaRotVel -= Time.deltaTime * 100;
        if (inertiaRotVel < 0)
            inertiaRotVel = 0;
        transform.Rotate(0, inertiaRotVel * inertiaRotDir * Time.deltaTime, 0);
    }

    void Zoom()
    {

    }
}
