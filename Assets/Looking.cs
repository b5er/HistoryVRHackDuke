using UnityEngine;
using System.Collections;

public class looking : MonoBehaviour {



    Vector2 mouseLook;

    Vector2 smooth;



    public float sensitive = 5.0f;

    public float smoothing = 2.0f;

    GameObject player;

    // Use this for initialization

    void Start()

    {

        player = this.transform.parent.gameObject;

    }



    // Update is called once per frame

    void Update()

    {



        var mul = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        float smoother = smoothing * sensitive;

        mul = Vector2.Scale(mul, new Vector2(smoother, smoothing));



        smooth.x = Mathf.Lerp(smooth.x, mul.x, 1f / smoothing);

        smooth.y = Mathf.Lerp(smooth.y, mul.y, 1f / smoothing);

        mouseLook += smooth;



        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);

        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);

    }
}
