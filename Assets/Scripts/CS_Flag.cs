using System.Collections;
using UnityEngine;

public class CS_Flag : MonoBehaviour
{
    public Material flagMat;
    private float liftTarget = 1f;
    private float liftState = 1f;
    private WaitForSeconds wait = new WaitForSeconds(0.05f);
    private float liftProgress;

    private void Start()
    {
        StartCoroutine(ReachLiftTarget());
    }
    void Update()
    {
        if (Input.touchCount >= 1)
        {
            var normDelta = Input.GetTouch(0).deltaPosition.y / Screen.height;
            normDelta *= 2f;
            liftTarget += normDelta;
            liftTarget = Mathf.Clamp(liftTarget, 0f, 1f);
        }


        
        liftState += (liftTarget - liftState) * Time.deltaTime * 5f;

        flagMat.SetFloat("Lift_Progress", liftState);
    }

    private IEnumerator ReachLiftTarget()
    {
        while (true)
        {


            yield return wait;
        }
    }
}
