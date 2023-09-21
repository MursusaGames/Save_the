using UnityEngine;

public class AutoPlay : MonoBehaviour
{
    private ParticleSystem part;

    private void Awake()
    {
        part = GetComponent<ParticleSystem>();
    }
    void OnEnable()
    {
        part.Play();
    }    
}
