using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Doorman dm;
    private Vector2 startPos, endPos;
    private float t = 0f;

    private void Awake()
    {
        startPos = transform.position;
        endPos = new Vector2(startPos.x + 2, startPos.y);
        this.enabled = false;
    }

    private void Update()
    {
        t += Time.deltaTime;
        transform.position = Vector2.Lerp(startPos, endPos, t);
    }

    public void Reset()
    {
        t = 0f;
        transform.position = startPos;
        this.enabled = false;
    }

}
