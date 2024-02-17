using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public bool enemyBullet;
    public bool destroyedByCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemyBullet && collision.tag == "Player")
        {
            Player.instance.GetDamage(damage);
            if (destroyedByCollision)
                Destruction();
        }
        else if (!enemyBullet && collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().GetDamage(damage);
            if (destroyedByCollision)
                Destruction();
        }
    }

    void Destruction()
    {
        Destroy(gameObject);
    }
}



