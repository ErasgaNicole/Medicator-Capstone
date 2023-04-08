using UnityEngine;

public class cloudScroll2 : MonoBehaviour
{
    // Start is called before the first frame update
    int randomSpeed;
    void Start()
    {
        randomSpeed = Random.Range(-1, -5);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(randomSpeed * Time.deltaTime, 0);
        if (transform.position.x <= -11.4f)
        {
            randomSpeed = Random.Range(-1, -5);
            transform.position = new Vector3(13.9f, transform.position.y, 1);
        }
    }
}
