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
    }
}
