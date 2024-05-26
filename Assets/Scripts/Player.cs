using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector2 initPos;
    private GameController gc;
    private InterfaceController ic;
    public Rigidbody2D rb;
    public TrailRenderer tr;
    public SpriteRenderer sr;
    private float initTrTime;
    public float speed;
    private IPlayerState state;

    private void Start()
    {
        initPos = transform.position;
        ic = InterfaceController.ic;
        gc = GameController.gc;
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        sr = GetComponent<SpriteRenderer>();

        state = new DefaultState();
        state.Enter(this);
    }

    private void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * (Time.deltaTime * speed));

        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }

        if (!Input.GetKeyDown(KeyCode.Space)) return;
        state.Next(ref state);
        state.Enter(this);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Respawn"))
        {
            Respawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Finish"))
        {
            gc.NextLevel();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Respawn()
    {
        initTrTime = tr.time;
        tr.time = -1;
        rb.isKinematic = true;
        rb.MovePosition(initPos);
        rb.velocity = Vector2.zero;
        Invoke(nameof(ResetComponents), 0.1f);
        GameController.gc.ResetDoormen();
    }

    private void ResetComponents()
    {
        rb.isKinematic = false;
        tr.time = initTrTime;
    }
}
