using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour
{

    [SerializeField] float boven = 1000f;
    [SerializeField] float LR = 50f;
    Rigidbody rigi;
    bool up;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {

        up = Input.GetKey(KeyCode.Space);
        float tilt = Input.GetAxis("Horizontal");

        if (!Mathf.Approximately(tilt, 0f))
        {
            rigi.freezeRotation = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (new Vector3(0f, 0f, (tilt * LR * Time.deltaTime))));
        }
        // terug resetten //
        rigi.freezeRotation = false;

    }

    private void FixedUpdate()
    {
        if (up)
        {
            rigi.AddRelativeForce(Vector3.up * boven * Time.deltaTime);
        }
    }
}
