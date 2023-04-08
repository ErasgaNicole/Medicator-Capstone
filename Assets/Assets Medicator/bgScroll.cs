using UnityEngine;

public class bgScroll : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-1 * Time.deltaTime, 0);
        if (transform.position.x <= -17.5f)
        {
            transform.position = new Vector3(17.5f, transform.position.y, 1);
        }
    }
}
