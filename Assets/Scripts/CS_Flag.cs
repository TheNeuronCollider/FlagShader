using System.Collections;
using UnityEngine;

public class CS_Flag : MonoBehaviour
{
    [Header("Material de la bandera")]
    public Material flagMat;

    [Header("Etiqueta de titulo en UI")]
    public GameObject label;


    private static float liftTarget = 1f;
    public static float liftState = 1f;
    private AudioSource audioSource;
    private static CS_Flag lastFlagChoosen;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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

    private void AnthemVolume()
    {
        audioSource.volume = liftState;
    }
}
