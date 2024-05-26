using System.Collections;
using UnityEngine;

public class TurretFactory : MonoBehaviour
{
    [SerializeField] private Sprite shotSprite;
    private GameObject shot;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private CircleCollider2D cc;
    [SerializeField] private float cooldownTime = 1f;
    [SerializeField] private float shotForce = 500f;

    private void Start()
    {
        StartCoroutine(Fire());
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator Fire()
    {
        if (!shot)
        {
            shot = new GameObject
            {
                tag = "Respawn",
                transform =
                {
                    localScale = new Vector2(2, 2)
                }
            };
            shot.AddComponent<Rigidbody2D>();
            rb = shot.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0f;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            shot.AddComponent<SpriteRenderer>();
            sr = shot.GetComponent<SpriteRenderer>();
            sr.color = Color.yellow;
            sr.sprite = shotSprite;
            sr.sortingOrder = -2;

            shot.AddComponent<CircleCollider2D>();
        }

        shot.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        shot.transform.position = transform.position;
        rb.AddForce(new Vector2(shotForce, 0f));

        yield return new WaitForSeconds(cooldownTime);

        StartCoroutine(Fire());
    }
}