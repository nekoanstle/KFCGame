using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    //Fireballs

    [SerializeField] public GameObject m_projectile = null;
    private Rigidbody2D projectile_rb = null;
    public float velX = 5f;
    public float velY = 0f;

    public AudioSource m_enemydeath = null;
    // Start is called before the first frame update
    void Start()
    {
        projectile_rb = m_projectile.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.right)
        {

        projectile_rb.velocity = new Vector2(velX, velY);
            Destroy(gameObject, 2.0f);
        }
        else if(PlayerController.left)
        {
            projectile_rb.velocity = new Vector2(-velX, velY);
            Destroy(gameObject, 2.0f);
        }
        else if (PlayerController.up)
        {
            projectile_rb.velocity = new Vector2(0, velX);
            Destroy(gameObject, 2.0f);
        }
        else if (PlayerController.down)
        {
            projectile_rb.velocity = new Vector2(0, -velX);
            Destroy(gameObject, 2.0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        GameObject enemy = collision.gameObject;
        if(enemy.tag == "Enemy")
        {
            m_enemydeath.Play();
           
            Destroy(enemy);
            PlayerController.amtOfEnemy--;
        }
    }

}
