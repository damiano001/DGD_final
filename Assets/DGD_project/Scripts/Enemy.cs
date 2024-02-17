using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public GameObject Projectile;
    public GameObject destructionVFX;
    public GameObject hitEffect;

    public int shotChance;
    public float shotTimeMin, shotTimeMax;

    private void Start() {
        Invoke("ActivateShooting", Random.Range(shotTimeMin, shotTimeMax));
    }

    void ActivateShooting() {
        if (Random.value < (float)shotChance / 100) {
            Instantiate(Projectile,  gameObject.transform.position, Quaternion.identity);
        }
    }

    public void GetDamage(int damage) {
        health -= damage;
        if (health <= 0)
            Destruction();
        else
            Instantiate(hitEffect, transform.position, Quaternion.identity, transform);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            if (Projectile.GetComponent<Projectile>() != null)
                Player.instance.GetDamage(Projectile.GetComponent<Projectile>().damage);
            else
                Player.instance.GetDamage(1);
        }
    }

    void Destruction() {
        Instantiate(destructionVFX, transform.position, Quaternion.identity);
        ScoreManager.instance.AddScore(10);
        AudioManager.instance.PlayEnemyDestroySound();
        Destroy(gameObject);
    }
}

