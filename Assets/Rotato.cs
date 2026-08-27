using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotato : MonoBehaviour
{
    public float startPos;
    private Vector3 startScale;
    private float wobbleStartTime;
    private float wobbleMagnitude;
    private float targetWobbleMagnitude;
    private bool wobbling;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(new Vector3(0, 90 * Time.deltaTime, 0));
        transform.position = new Vector3(startPos, transform.position.y, transform.position.z) + Vector3.left * Mathf.Sin(Time.time * 3) * 4;
        if (Input.GetMouseButton(0))
        {
            if (!wobbling)
            {
                wobbling = true;
                wobbleStartTime = Time.time;
            }
            targetWobbleMagnitude += .25f;
        }
        wobbleMagnitude = Mathf.Lerp(wobbleMagnitude, targetWobbleMagnitude, 1f * Time.deltaTime);
        if (wobbling)
        {
            transform.localScale = startScale * 1 + Mathf.Sin((Time.time - wobbleStartTime) * 20) * wobbleMagnitude * Vector3.one;
        }
        targetWobbleMagnitude = Mathf.Clamp(targetWobbleMagnitude - 15f * Time.deltaTime, 0, Mathf.Infinity);
    }
}
