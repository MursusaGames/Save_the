using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private AudioSource ai;
    [SerializeField] private AudioSource tzong;
    [SerializeField] private AudioSource tsssss;
    [SerializeField] private GameObject smoke;
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
    public bool _stone;
    public bool _poop;
    public bool _tomate;
    public bool _fire;
    public bool _racet;
    public bool _tykw;
    public bool _shark;
    public bool _carrot;
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
    private void OnEnable()
    {
        if (_tykw)
        {
            smoke.SetActive(true);
        }
    }
    public void KnifeGo()
    {
        rg.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        if (_knife) levelController.PlaySound(0);
        else if (_tomate||_stone||_poop) levelController.PlaySound(1);
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
        }
        if (_knife)
        {
            if (collision.gameObject.CompareTag("Monster")|| collision.gameObject.CompareTag("Shark"))
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
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                levelController.ResetAnim();
                halfMonster.SetActive(true);                
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
            if (collision.gameObject.CompareTag("Tykw"))
            {
                Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
        }
        if (_superKnife)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Ches") || collision.gameObject.CompareTag("Shark"))
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
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                levelController.ResetAnim();
                halfMonster.SetActive(true);                
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
            if (collision.gameObject.CompareTag("Tykw"))
            {
                Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
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
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                levelController.ResetAnim();
                levelController.IsStone();                
                Invoke(nameof(GetWin), 3f);
            }
            if (collision.gameObject.CompareTag("Iron") || collision.gameObject.CompareTag("Ches") || collision.gameObject.CompareTag("Shark"))
            {
                Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.IsTomate();
                Invoke(nameof(GetFall), 3f);
            }
            if (collision.gameObject.CompareTag("Tykw"))
            {
                Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 1f;
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }

        }
        if (_carrot)
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
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                levelController.ResetAnim();
                levelController.IsStone();
                Invoke(nameof(GetWin), 3f);
            }
            if (collision.gameObject.CompareTag("Iron") || collision.gameObject.CompareTag("Ches")|| collision.gameObject.CompareTag("Tykw") 
                || collision.gameObject.CompareTag("Shark"))
            {
                Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.IsCarrot();
                Invoke(nameof(GetFall), 3f);
            }

        }
        if (_stone)
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
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                levelController.ResetAnim();
                levelController.IsStone();
                Invoke(nameof(GetWin), 3f);
            }
            if (collision.gameObject.CompareTag("Iron") || collision.gameObject.CompareTag("Ches")|| collision.gameObject.CompareTag("Tykw")
                || collision.gameObject.CompareTag("Shark"))
            {
                Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.IsStoneOut();
                Invoke(nameof(GetFall), 3f);
            }

        }
        if (_poop)
        {
            rg.constraints = RigidbodyConstraints2D.FreezePositionY;
            img.enabled = false;
            levelController.ResetAnim();
            levelController.IsPoop();
            Invoke(nameof(GetWin), 3f);
        }
        if (_tykw)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Tykw") || collision.gameObject.CompareTag("Shark"))
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
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                levelController.ResetAnim();
                halfMonster.SetActive(true);
                Invoke(nameof(GetWin), 1f);
            }
            if (collision.gameObject.CompareTag("Iron")|| collision.gameObject.CompareTag("Ches"))
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
        if (_shark)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Tykw") || collision.gameObject.CompareTag("Shark"))
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
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                levelController.ResetAnim();
                halfMonster.SetActive(true);
                Invoke(nameof(GetWin), 1f);
            }
            if (collision.gameObject.CompareTag("Iron") || collision.gameObject.CompareTag("Ches"))
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

    }
}
