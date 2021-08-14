/* 
 * For lifting the flag.
 */
using UnityEngine;

public class CS_Flag : MonoBehaviour
{
    // Inspector
    [Header("Material the flags are using.")]
    public Material flagMat;

    [Header("Label of each flag on UI.")]
    public GameObject label;

    // Local
    private float liftGestureFac = 2f;
    private float liftReachTargetFac = 5f;
    private AudioSource audioSource;

    // Statics
    public static float liftState = 0f;
    private static float liftTarget = 0f;
    private static CS_Flag lastFlagChoosen;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        flagMat.SetFloat("Lift_Progress", liftState);
    }

    void OnEnable()
    {
        label.SetActive(true);
        TurnOffLastFlag();
    }

    void Update()
    {
        Lift();
        AnthemVolume();
    }

    private void TurnOffLastFlag()
    {
        if (lastFlagChoosen != null)
        {
            lastFlagChoosen.gameObject.SetActive(false);
            lastFlagChoosen.label.SetActive(false);
        }

        lastFlagChoosen = this;

        audioSource.Play();
    }

    private void Lift()
    {
        if (Input.touchCount == 0)
            return;

        // Lifting gesture on screen is based on screen percentage.
        // A height target is calculated and then the actual value reaches that target smoothly.

        liftTarget += liftGestureFac * (Input.GetTouch(0).deltaPosition.y) / Screen.height;
        liftTarget = Mathf.Clamp(liftTarget, 0f, 1f);

        liftState += (liftTarget - liftState) * Time.deltaTime * liftReachTargetFac;
        flagMat.SetFloat("Lift_Progress", liftState);
    }

    private void AnthemVolume()
    {
        audioSource.volume = liftState;
    }
}
