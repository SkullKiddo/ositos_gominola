using UnityEngine;
using System.Collections;

public class seguimiento : MonoBehaviour {

    // Use this for initialization
    private Vector3 offset;
    public GameObject player = GameObject.Find("Player");
    void Start () {
        offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + offset;
    }
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}
