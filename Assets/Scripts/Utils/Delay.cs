using UnityEngine;

public class Delay : MonoBehaviour
{
    [SerializeField] private GameObject partikl;
    [SerializeField] private float delayValue;
    private float _delay;
    private bool begin;
    void OnEnable()
    {
        _delay = delayValue;
        begin = true;
    }

    void FixedUpdate()
    {
        if (begin)
        {
            _delay -= Time.fixedDeltaTime;
            if(_delay < 0)
            {
                partikl.SetActive(true);
                begin = false;
            }
        }
    }
}
