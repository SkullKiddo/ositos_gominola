using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
    public int velocity;
    private int count;
    public Text countText;
    public Text winText;
    private Vector2 startPos;
    private Vector2 paola_pos;


    void Start () {
		rb = GetComponent<Rigidbody>();
        winText.text = "";
        count = 0;
        SetCountText();
	}

void FixedUpdate()
{

        winText.text = "polla";
        if (Input.touchCount > 0)
        {

            winText.text = "tocáhte";

            if (Input.GetTouch(0).phase == TouchPhase.Began)startPos = Input.GetTouch(0).position;
            int gabri = 0;
            while (Input.GetTouch(0).phase != TouchPhase.Ended) {
                paola_pos = Input.GetTouch(0).position;
                ++gabri;
            } //endededed
            winText.text = "i = "; // + gabri.ToString();
            float swipeDistVertical = paola_pos.y - startPos.y;

            float swipeDistHorizontal = paola_pos.x - startPos.x;

        Vector3 movement = new Vector3(swipeDistVertical, 0.0f, swipeDistVertical);

        rb.AddForce(movement * movement.magnitude/(gabri));
    }
       // winText.text = "cosas";
}
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 12) winText.text = "You win!";
    }
		
}