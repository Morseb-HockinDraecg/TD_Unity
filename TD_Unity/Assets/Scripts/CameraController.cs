using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Camera cam;

    [Header("Controller")]
    public KeyCode toggleMovementKey;
    public KeyCode resetCamKey;

    [Header("Camera Movement")]
    public float panSpeed = 5f;
    public float mouseSensitivity = 3f;
    public float panBorderThickness = 10f;

    [Header("Camera Zoom")]
    public float scrollSpeed = 5f;
    public float maxZoom = 1.35f;
    public float minZoom = 10.35f;
    
    [Header("Map Size")]
    public float mapHeight = 10;
    public float mapWidth = 20;


    private bool toggleMovement = true;
    private float targetZoom;
    private float initCamSize;
    private Vector3 initCamPos;

    void Start (){
        targetZoom = cam.orthographicSize;

        if (toggleMovementKey == KeyCode.None)
            toggleMovementKey = KeyCode.Escape;

        if (resetCamKey == KeyCode.None)
            resetCamKey = KeyCode.Space;

        initCamPos = cam.transform.position;
        initCamSize = cam.orthographicSize;
    }

    void Update(){
        if (Input.GetKeyDown(toggleMovementKey))
            toggleMovement = !toggleMovement;

        if (Input.GetKeyDown(resetCamKey))
            resetCamSetting();

        if (!toggleMovement)
            return;

        Mouvement();
        Scroll();
    }

    void resetCamSetting(){
        cam.transform.position = initCamPos;
        cam.orthographicSize = initCamSize;
        targetZoom = initCamSize;      
    }

    void Scroll(){
        float newSize;
        
        targetZoom -= Input.GetAxis("Mouse ScrollWheel") * mouseSensitivity;
        targetZoom = Mathf.Clamp(targetZoom, maxZoom, minZoom);
        newSize = Mathf.MoveTowards(cam.orthographicSize, targetZoom, scrollSpeed * Time.deltaTime);
        cam.orthographicSize = newSize;
    }

    void Mouvement(){
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness )
            MoveUp();
        if (Input.GetKey("s") || Input.mousePosition.y <=  panBorderThickness )
            MoveDown();
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness )
            MoveRight();
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness )
            MoveLeft();
    }

    void MoveUp(){
        if (cam.transform.position.y >= mapHeight / 2)
            return;
        cam.transform.Translate(Vector3.up * panSpeed * Time.deltaTime, Space.World);
    }
    void MoveDown(){
        if (cam.transform.position.y <= - mapHeight / 2)
            return;
        cam.transform.Translate(Vector3.down * panSpeed * Time.deltaTime, Space.World);
    }
    void MoveRight(){
        if (cam.transform.position.x >= mapWidth / 2)
            return;
       cam.transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
    }
    void MoveLeft(){
        if (cam.transform.position.x <= - mapWidth / 2)
            return;
        cam.transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
    }

}
