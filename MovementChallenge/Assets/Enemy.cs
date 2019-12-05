using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float runDist;
    public float returnDist;
    public float speed;
    public float maxSpeed;
    public float score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distFromPlayer = Vector3.Distance(Player.Instance.transform.position, transform.position);
        if(distFromPlayer < runDist)
        {
            Vector3 lookPos = transform.position - Player.Instance.transform.position;
            lookPos.y = 0;
            Quaternion look = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, look, 10 * Time.deltaTime);

            float chaseSpeed = speed * (runDist - distFromPlayer);
            if(chaseSpeed > maxSpeed)
            {
                transform.position += transform.forward * maxSpeed;
            }
            else
            {
                transform.position += transform.forward * chaseSpeed;
            }

        }
        else if(distFromPlayer > returnDist)
        {
            Vector3 lookPos = Player.Instance.transform.position - transform.position;
            lookPos.y = 0;
            Quaternion look = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, look, 10 * Time.deltaTime);

            transform.position += transform.forward * speed * ((distFromPlayer / returnDist) + 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.Find("TextBox").GetComponent<UnityEngine.UI.Text>().text = (float.Parse(GameObject.Find("TextBox").GetComponent<UnityEngine.UI.Text>().text) + score).ToString();
            Destroy(this.gameObject);
        }

    }
}
