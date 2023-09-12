using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private AudioSource tzong;
    [SerializeField] private AudioSource tsssss;
    private TouchScreenSystem touchScreenSystem;
    private LevelController levelController;
    private Animator anim;
    public bool isGo;
    bool stopLine;
    private Rigidbody2D rg;
    private Image img;
    private AudioSource soundKnifeInTree;    
    [SerializeField] float speed = 0.1f;
    private GameObject halfMonster;
    private bool win;
    public bool _knife;
    public bool _superKnife;
    public bool _stown;
    public bool _tomate;
    public bool _fire;
    public bool _racet;
    private bool isRotate;
    void Awake()
    {
        anim = GetComponent<Animator>();
        img = GetComponent<Image>();
        rg = GetComponent<Rigidbody2D>();
        touchScreenSystem = FindObjectOfType<TouchScreenSystem>();
        levelController = FindObjectOfType<LevelController>();
        touchScreenSystem.GetKnife(this);
        soundKnifeInTree = GetComponent<AudioSource>();
        halfMonster = touchScreenSystem._halfMonster;
    }

    public void KnifeGo()
    {
        rg.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        if (_knife) levelController.PlaySound(0);
        else if (_tomate) levelController.PlaySound(1);
        else levelController.PlaySound(2);
    }
    void FixedUpdate()
    {
        if (isRotate)
        {
            rg.gameObject.transform.Rotate(Vector3.forward, 30f);
        }
        if (isGo)
        {
            rg.AddForce(Vector2.up * speed, ForceMode2D.Impulse);            
        }
    }

    private void GetWin()
    {
        levelController.Win();
        Destroy(gameObject);       
    }
    private void GetFall()
    {
        isRotate = false;
        levelController.Fall();
        Destroy(gameObject);        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ring"))
        {
            if (win) 
                return;
            Invoke(nameof(GetFall), 1f);
            //touchScreenSystem.KnifeIn();
            //gameObject.SetActive(false);
            //levelController.Fall();
            //Destroy(gameObject);
        }
        if (_knife)
        {
            if (collision.gameObject.CompareTag("Monster"))
            {
                win = true;
                Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                }
                levelController.ResetAnim();
                halfMonster.SetActive(true);
                //isGo = false;
                //img.enabled = false;
                //rg.velocity = Vector2.zero;
                Invoke(nameof(GetWin), 1f);
            }
            if (collision.gameObject.CompareTag("Iron"))
            {
                Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 1f);
            }
            if (collision.gameObject.CompareTag("Ches"))
            {
                Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                anim.enabled = true;
                tsssss.Play();
                levelController.IsChes();                
                Invoke(nameof(GetFall), 3f);
            }
        }
        if (_superKnife)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Ches"))
            {
                win = true;
                Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                }
                levelController.ResetAnim();
                halfMonster.SetActive(true);
                //isGo = false;
                //img.enabled = false;
                //rg.velocity = Vector2.zero;
                Invoke(nameof(GetWin), 1f);
            }
            if (collision.gameObject.CompareTag("Iron"))
            {
                Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 1f);
            }
            
        }
        if (_tomate)
        {
            if (collision.gameObject.CompareTag("Monster"))
            {
                win = true;
                Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                }
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                levelController.ResetAnim();
                levelController.IsStone();                
                Invoke(nameof(GetWin), 3f);
            }
            if (collision.gameObject.CompareTag("Iron") || collision.gameObject.CompareTag("Ches"))
            {
                Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                levelController.IsTomate();
                Invoke(nameof(GetFall), 3f);
            }

        }

    }

}
