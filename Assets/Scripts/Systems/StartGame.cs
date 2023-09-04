using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private MatchData data;
    private void OnEnable()
    {
        SceneManager.LoadScene(data.levelNumber);
    }
}
