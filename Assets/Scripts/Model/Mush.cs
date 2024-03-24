using UnityEngine;

public class Mush : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private AudioSource audioSource;
    public float radius = 5f; // ������ ��������
    public float speed = 1f; // �������� ��������
    private float _angle; // ������� ����

    private void OnEnable()
    {
        if (data.sound)
        {
            audioSource.volume = PlayerPrefs.GetFloat(Constant.SOUND);
            audioSource.Play();
        }
    }
    private void Update()
    {
        _angle += speed * Time.deltaTime; // ����������� ���� �� ������� � ��������
        // ��������� ����� ���������� ������� �� ���������� � ������� ������������������ �������
        float x = Mathf.Cos(_angle) * radius;
        float y = Mathf.Sin(_angle) * radius;

        transform.localPosition = new Vector3(x, y, transform.localPosition.z); // ��������� ������� �������
    }
}
