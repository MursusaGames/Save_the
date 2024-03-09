using UnityEngine.SceneManagement;
using UnityEngine;

public class ChalangeMenu : MonoBehaviour
{
    [SerializeField] private MatchData data;
    private int _id;
    public void SetLevel(int id)
    {
        data.levelNumber = id;
        PlayerPrefs.SetInt(Constants.LEVEL, id);
        _id = id;
        Invoke(nameof(LoadScene), 1f);
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(_id);
    }
}
