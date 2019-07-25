using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
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

    void Start()
    {
        attackLeft = m_attackTime;
    }

    void Update()
    {
        Vector3 direction = new Vector3();
        direction.z = 0;

        if (Input.GetKey(KeyCode.W))
        {
            direction.y = 1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.y = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1.0f;
        }

        if (Input.GetMouseButtonDown(0)) { OnCLick(); }

        transform.position += direction.normalized * m_speed * Time.deltaTime;
    }
    public void Attack(float angle)
    {
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

    public void Die()
    {
        WinCondition.gameover = true;
    }

    public void EndAttack()
    {
        m_lineCollider.SetActive(false);
        m_coneCollider.SetActive(false);
        m_popCollider.SetActive(false);
        m_lineCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
        m_coneCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
        m_popCollider.transform.rotation = Quaternion.Euler(0, 0, 0);

        //m_lineCollider.transform.rotation.SetFromToRotation(m_lineCollider.transform.rotation, 0)
    }
}
