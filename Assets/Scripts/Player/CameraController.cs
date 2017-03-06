using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour {

  public int CameraSpeed;

  private int screenBoundry = 5;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	  GetKeyboardInput();
	  GetMouseInput();
	  //commented out for testing and debugging purposes
	  //CheckMouseLocation();
	}

  private void GetMouseInput()
  {
    var mouseScrollWheel = Input.GetAxisRaw("Mouse ScrollWheel");

    if (mouseScrollWheel > 0)
    {
        Camera.main.transform.Translate(Vector3.forward);
    }
    else if (mouseScrollWheel < 0)
    {
        Camera.main.transform.Translate(Vector3.back);
    }
  }

  private void CheckMouseLocation()
  {
    int x=0, z=0;
    if (Input.mousePosition.x > Screen.width - screenBoundry)
        x = CameraSpeed;
    else if (Input.mousePosition.x < screenBoundry)
        x = -CameraSpeed;

    if (Input.mousePosition.y > Screen.height - screenBoundry)
        z = CameraSpeed;
    else if (Input.mousePosition.y < screenBoundry)
        z = -CameraSpeed;

    MoveCamera(x, z);
  }

  private void MoveCamera(int x, int z)
  {
    if (x != 0 || z != 0)
    {
        transform.Translate(new Vector3(x * Time.deltaTime, 0, z * Time.deltaTime));
    }
  }

  private void GetKeyboardInput()
  {
    var x = (int)Input.GetAxisRaw("CameraHorizontal") * CameraSpeed;

    var z = (int)Input.GetAxisRaw("CameraVertical") * CameraSpeed;

    MoveCamera(x, z);
  }
}
