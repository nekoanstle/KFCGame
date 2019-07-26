using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_speed = 5.0f;
    [SerializeField] float m_attackTime = 1.0f;
    [SerializeField] GameObject m_lineCollider = null;
    [SerializeField] GameObject m_coneCollider = null;
    [SerializeField] GameObject m_popCollider = null;
    [SerializeField] public Meter m_powerMeter = null;
    [SerializeField] Animator m_animuz = null;

    public bool isSheildActive = false;
    public ePowers attackPower = ePowers.LINE;
    private float attackLeft;
    bool attack = false;

   public GameObject bulletPlace = null;
    public GameObject bulletLeft = null;
    public GameObject bulletUp = null;
    public GameObject bulletDown = null;

    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;

    //facing
    public static bool left = false;
    public static bool right = false;
    public static bool up = false;
    public static  bool down = false;

    public static int amtOfEnemy = 10;

    public AudioSource m_attack = null;
    void Start()
    {
        attackLeft = m_attackTime;
        amtOfEnemy = 10;
    }

    void Update()
    {
        if (attack)
        {
            attackLeft -= Time.deltaTime;
            if (attackLeft <= 0)
            {
                EndAttack();
                attackLeft = m_attackTime;
            }
        }
        Vector3 direction = new Vector3();
        direction.z = 0;

        if (Input.GetKey(KeyCode.W))
        {
            SetBoolFace("up");
        
            direction.y = 1.0f;
            if(m_animuz.GetBool("WalkUp") == false)
            {
                this.SetAnimation("WalkUp");
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            SetBoolFace("left");

            direction.x = -1.0f;
            if (m_animuz.GetBool("WalkLeft") == false)
            {
                this.SetAnimation("WalkLeft");
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            SetBoolFace("down");

            direction.y = -1.0f;
            if (m_animuz.GetBool("WalkDown") == false)
            {
                this.SetAnimation("WalkDown");
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            SetBoolFace("right");

            direction.x = 1.0f;
            if (m_animuz.GetBool("WalkRight") == false)
            {
                this.SetAnimation("WalkRight");
            }
        }

        if (Input.GetMouseButtonDown(0) && !attack && Time.time > nextFire) { OnCLick(); }

        transform.position += direction.normalized * m_speed * Time.deltaTime;
    }
    //sets all the rest of the animation to false
    private void SetAnimation(string id)
    {
        switch(id)
        {
            case "WalkUp":
                m_animuz.SetBool(id, true);
                m_animuz.SetBool("WalkDown", false);
                m_animuz.SetBool("WalkRight", false);
                m_animuz.SetBool("WalkLeft", false);
                break;
            case "WalkDown":
                m_animuz.SetBool(id, true);
                m_animuz.SetBool("WalkUp", false);
                m_animuz.SetBool("WalkRight", false);
                m_animuz.SetBool("WalkLeft", false);
                break;
            case "WalkRight":
                m_animuz.SetBool(id, true);
                m_animuz.SetBool("WalkDown", false);
                m_animuz.SetBool("WalkUp", false);
                m_animuz.SetBool("WalkLeft", false);
                break;
            case "WalkLeft":
                m_animuz.SetBool(id, true);
                m_animuz.SetBool("WalkDown", false);
                m_animuz.SetBool("WalkRight", false);
                m_animuz.SetBool("WalkUp", false);
                break;
                
        }
    }
    private void SetBoolFace(string id)
    {
        switch(id)
        {
            case "right":
                right = true;

                left = false;
                up = false;
                down = false;
                break;
            case "left":
                left = true;

                right = false;
                up = false;
                down = false;
                break;
            case "down":
                down= true;

                left = false;
                up = false;
                right = false;
                break;
            case "up":
                up = true;

                left = false;
                right = false;
                down = false;
                break;
        }
    }
    public void Attack(float angle)
    {
        m_attack.Play();
        attack = true;

        bulletPos = transform.position;

        //If facing right do this
        if (right)
        {
            GameObject go = Instantiate(bulletPlace, bulletPos, Quaternion.identity);
            go.transform.position -= Vector3.right;
        }
        else if (left)
        {
            //If facing left do this
            GameObject go = Instantiate(bulletLeft, bulletPos, Quaternion.identity);
            go.transform.position -= Vector3.left;
        }
        else if(up)
        {
            GameObject go = Instantiate(bulletUp, bulletPos, Quaternion.identity);
            go.transform.position -= Vector3.up;
        }
        else if (down)
        {
            GameObject go = Instantiate(bulletDown, bulletPos, Quaternion.identity);
            go.transform.position -= Vector3.down;
        }

        //check power meter
        if (attackPower == ePowers.LINE)
        {

            m_lineCollider.SetActive(true);
            m_lineCollider.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        if (attackPower == ePowers.CONE)
        {
            m_coneCollider.SetActive(true);
            m_coneCollider.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        if (attackPower == ePowers.POPCORN)
        {
            m_popCollider.SetActive(true);
            m_popCollider.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnCLick()
    {
        nextFire = Time.time + fireRate;

        Debug.Log("Click");
        Vector3 mouse = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 dif = transform.position - ray.GetPoint(0.0f);

        if (Mathf.Abs(dif.x) > Mathf.Abs(dif.y))
        {
            if (dif.x >= 0)
            {
                Attack(180);
                Debug.Log("Left");
            }
            else
            {
                Attack(0);
                Debug.Log("Right");
            }
        }
        else
        {
            if (dif.y >= 0)
            {
                Attack(270);
                Debug.Log("Down");
            }
            else
            {

                Attack(90);
                Debug.Log("Up");
            }
        }
    }

    public void Die()
    {
        WinCondition.gameover = true;
        SceneManager.LoadScene("GameOver");
    }

    public void EndAttack()
    {
        attack = false;




        m_lineCollider.SetActive(false);
        m_coneCollider.SetActive(false);
        m_popCollider.SetActive(false);
        m_lineCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
        m_coneCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
        m_popCollider.transform.rotation = Quaternion.Euler(0, 0, 0);

        //m_lineCollider.transform.rotation.SetFromToRotation(m_lineCollider.transform.rotation, 0)
    }
}
