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
    //public bool isGo;
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
    public bool _egg;
    public bool _tomate;
    public bool _fire;
    public bool _racet;
    public bool _tykw;
    public bool _shark;
    public bool _meduza;
    public bool _carrot;
    public bool _bullet;
    public bool _silverBullet;
    public bool _bomb;
    private bool isRotate;
    public bool inDrive;
    private bool scale1;
    private bool scale2;
    private bool scale3;
    private bool scale4;
    private bool scale5;
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
    public void SetTykw()
    {
        _tykw = true;
        smoke.SetActive(true);
    }
    public void KnifeGo()
    {
        inDrive = true;
        rg.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        if (_knife) levelController.PlaySound(0);
        else if (_tomate||_stone||_poop) levelController.PlaySound(1);
        else if (_bullet || _silverBullet)
        {
            levelController.Bullet();
            levelController.PlayBoom();
        }
            
    }
    void FixedUpdate()
    {
        if (isRotate)
        {
            rg.gameObject.transform.Rotate(Vector3.forward, 30f);
        }
        /*if (isGo)
        {
            rg.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
            inDrive = true;
        }*/
        if (inDrive)
        {
            var scaleGO = transform.localScale;
            var pos = transform.localPosition;
            if(pos.y > -500 && pos.y < -250 && !scale1)
            {
                scale1 = true;
                scaleGO.x = 0.9f;
                scaleGO.y = 0.9f;
                transform.localScale = scaleGO;
            }
            if (pos.y > -250 && pos.y < 0 && !scale2)
            {
                scale2 = true;
                scaleGO.x = 0.8f;
                scaleGO.y = 0.8f;
                transform.localScale = scaleGO;
            }
            if (pos.y > 0 && pos.y < 250 && !scale3)
            {
                scale3 = true;
                scaleGO.x = 0.7f;
                scaleGO.y = 0.7f;
                transform.localScale = scaleGO;
            }
            if (pos.y >250 && pos.y < 500 && !scale4)
            {
                scale4 = true;
                scaleGO.x = 0.6f;
                scaleGO.y = 0.6f;
                transform.localScale = scaleGO;
            }
            if (pos.y > 500 && !scale5)
            {
                scale5 = true;
                scaleGO.x = 0.5f;
                scaleGO.y = 0.5f;
                transform.localScale = scaleGO;
            }
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
            return;
        }
        if (_knife)
        {
            if (collision.gameObject.CompareTag("Monster")|| collision.gameObject.CompareTag("Shark"))
            {
                win = true;
                if(levelController.data.vibro) 
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
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
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
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                anim.enabled = true;
                if (levelController.data.sound)
                    tsssss.Play();
                levelController.IsChes();                
                Invoke(nameof(GetFall), 3f);
            }
            if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
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
                if (levelController.data.vibro)
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
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
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
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
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
                if (levelController.data.vibro)
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
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.IsTomate();
                Invoke(nameof(GetFall), 3f);
            }
            if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound) 
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.3f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }

        }
        if (_carrot)
        {
            if (collision.gameObject.CompareTag("Monster"))
            {
                win = true;
                if (levelController.data.vibro)
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
                if (levelController.data.vibro)
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
                if (levelController.data.vibro)
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
                if (levelController.data.vibro)
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
            //levelController.ResetAnim();
            levelController.IsPoop();
            Invoke(nameof(GetFall), 3f);
        }
        if (_tykw)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Tykw") || collision.gameObject.CompareTag("Shark"))
            {
                win = true;
                if (levelController.data.vibro)
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
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound) 
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
                if (levelController.data.vibro)
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
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
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
        if (_bullet)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Shark"))
            {
                win = true;
                if (levelController.data.vibro)
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
                //levelController.ResetAnim();
                levelController.IsBullet();
                Invoke(nameof(GetWin), 3f);
            }
            if (collision.gameObject.CompareTag("Iron"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
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
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                anim.enabled = true;
                if (levelController.data.sound)
                    tsssss.Play();
                levelController.IsChes();
                Invoke(nameof(GetFall), 3f);
            }
            if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
        }
        if (_silverBullet)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Shark") || collision.gameObject.CompareTag("Ches")
                || collision.gameObject.CompareTag("Tykw"))
            {
                win = true;
                if (levelController.data.vibro)
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
                //levelController.ResetAnim();
                levelController.IsSilverBullet();
                Invoke(nameof(GetWin), 3f);
            }
            if (collision.gameObject.CompareTag("Iron"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
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
        if (_egg)
        {
            rg.constraints = RigidbodyConstraints2D.FreezePositionY;
            img.enabled = false;
            //levelController.ResetAnim();
            levelController.IsEgg();
            Invoke(nameof(GetFall), 3f);
        }
        if (_bomb)
        {
            rg.constraints = RigidbodyConstraints2D.FreezePositionY;
            img.enabled = false;
            //levelController.ResetAnim();
            levelController.IsBomb();
            Invoke(nameof(GetWin), 3f);
        }

    }
}
