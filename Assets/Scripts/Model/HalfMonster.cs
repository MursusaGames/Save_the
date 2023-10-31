using UnityEngine;
using UnityEngine.UI;

public class HalfMonster : MonoBehaviour
{
    [SerializeField] private GameObject leftHalf;
    [SerializeField] private GameObject rightHalf;
    //[SerializeField] private Image img;
    private Vector3 leftPos;
    private Vector3 rightPos;
    private void Awake()
    {
        leftPos = leftHalf.transform.localPosition;
        rightPos = rightHalf.transform.localPosition;
    }
    void OnEnable()
    {
        Invoke(nameof(Reset), 1.1f);
    }

    private void Reset()
    {
        leftHalf.transform.localPosition = leftPos;        
        rightHalf.transform.localPosition = rightPos;       
        //img.enabled = true;
        gameObject.SetActive(false);
    }
}
