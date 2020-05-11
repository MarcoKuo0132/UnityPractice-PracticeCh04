using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_ani : MonoBehaviour
{
    Animation spock_ani;
    // Start is called before the first frame update
    void Start()
    {
        spock_ani = this.GetComponent<Animation>();
        spock_ani.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            spock_ani.Play("Run_FW");
            transform.Translate(transform.forward * Time.deltaTime * 10, Space.World);

            if (Input.GetKey("a"))
            {
                transform.RotateAround(transform.position, new Vector3(0, 1, 0), Time.deltaTime * (-60));
            }
            if (Input.GetKey("d"))
            {
                transform.RotateAround(transform.position, new Vector3(0, 1, 0), Time.deltaTime * (60));
            }
        }

        if (Input.GetKey("s"))
        {
            spock_ani.Play("Run_BW");
            transform.Translate(transform.forward * Time.deltaTime * (-10), Space.World);

            if (Input.GetKey("a"))
            {
                transform.RotateAround(transform.position, new Vector3(0, 1, 0), Time.deltaTime * (-60));
            }
            if (Input.GetKey("d"))
            {
                transform.RotateAround(transform.position, new Vector3(0, 1, 0), Time.deltaTime * (60));
            }
        }

        if (Input.GetKeyUp("s") || Input.GetKeyUp("w"))
        {
            spock_ani.Play("Idle");
        }
    }
}
