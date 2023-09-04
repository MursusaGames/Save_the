using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftWindow : MonoBehaviour
{
    [SerializeField] GameObject apples;
    [SerializeField] GameObject textBox;
    private void Start()
    {
        Invoke(nameof(ShowAll), 1f);
    }

    void ShowAll()
    {
        apples.Show();
        textBox.Show();
    }
}
