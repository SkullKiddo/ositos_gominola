using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
    public int time;
    private int count;
    public Text countText;
    public Text winText;
    private Vector2 startPos;
    private Vector2 final_pos;
  


    void Start () {
		rb = GetComponent<Rigidbody>();
        winText.text = "";
        count = 0;
        SetCountText();
	}

void FixedUpdate()
{
    if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            winText.text = "tocado y hundido";

            switch (touch.phase)

        {

                case TouchPhase.Began:
                    startPos = touch.position;
                    final_pos = touch.position;
                    time = 0;
                    break;
                case TouchPhase.Moved:
                    final_pos = touch.position;
                    ++time;
                    break;
            }
            winText.text = "i = " + time.ToString();
            float swipeDistVertical = final_pos.y - startPos.y;

            float swipeDistHorizontal = final_pos.x - startPos.x;

            Vector3 movement = new Vector3(swipeDistVertical, 0.0f, swipeDistVertical);

            rb.AddForce(movement * time / 100);

        }
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