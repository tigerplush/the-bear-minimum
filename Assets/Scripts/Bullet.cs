using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 5f;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0f, speed * Time.deltaTime, 0f));
        lifetime -= Time.deltaTime;
        if(lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
