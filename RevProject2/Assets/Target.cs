using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public Transform target;
    public float speed = 0.5f;
    Rigidbody rigid;

    public void Start()
    {
        rigid = GetComponent<Rigidbody>();

    }

    public void Update()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        rigid.MovePosition(pos);
        transform.LookAt(target);

    }
    public void TakeDamage(float damageReceived)
    {
        health -= damageReceived;

        if (health <= 0f)
        {
            Die();
        }

    }
    void Die()
    {
        soundManager.PlaySound("PowUp_01");
        Destroy(gameObject);
        scorescript.scoreValue += 10;
    }

}
