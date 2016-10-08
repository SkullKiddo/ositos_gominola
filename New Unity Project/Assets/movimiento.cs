using UnityEngine;
using System.Collections;

public class movimiento : MonoBehaviour {

    // Use this for initialization
    public float GRAVEDAD;
    public float MAXspeed;
    private Rigidbody rb;

    void DireccionMovimiento(ref float speed, ref Vector3 dir) {
        dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        speed = MAXspeed;
    }

    void Start () {
        Physics.gravity = new Vector3(0, -GRAVEDAD, 0);
    }
	
	// Update is called once per frame
	void Update () {
        float speed = 0.0F;
        Vector3 dir = new Vector3(0, 0, 0);
        DireccionMovimiento(ref speed, ref dir); //aqui se pilla el input para poder cambiarlo para moverlo al movil cambiando la
        if (speed > MAXspeed) speed = MAXspeed;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(dir * speed);



    }
}
