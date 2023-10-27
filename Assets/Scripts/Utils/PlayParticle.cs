using UnityEngine;

public class PlayParticle : MonoBehaviour
{
    [SerializeField] private GameObject partikle;
    public void PlayPart()
    {
        partikle.SetActive(true);
    }
}
