using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public float speed = 6f;
    public Transform pathParent;
    Transform targetPoint;
    public Camera newCamera;
    int index;
    private bool camMove = false;
    private bool cameraMoving = false;  // Kamera hareketi devam ediyor mu?

    public Camera mainCamera;   // Eski kamera

    public GameController gameController;
    public void OnDrawGizmos()
    {
        Vector3 from;
        Vector3 to;
        for (int a = 0; a < pathParent.childCount; a++)
        {
            from = pathParent.GetChild(a).position;
            to = pathParent.GetChild((a + 1) % pathParent.childCount).position;
            Gizmos.color = new Color(1, 0, 0);
            Gizmos.DrawLine(from, to);
        }
    }

    void Start()
    {
        index = 0;
        targetPoint = pathParent.GetChild(index);
    }

    void Update()
    {
        if (!gameController.isPatientActive && Input.GetKeyDown(KeyCode.N) && !cameraMoving)  // N tuşuna bir kez basıldığında çalışmasını sağlar
        {
            camMove = true;
            cameraMoving = true;
        }

        if (camMove)
        {
            CameraMove();
        }
    }

    private void CameraMove()
    {
        NewCamActive();
        newCamera.transform.position = Vector3.MoveTowards(newCamera.transform.position, targetPoint.position, speed * Time.deltaTime);
        if (Vector3.Distance(newCamera.transform.position, targetPoint.position) < 0.1f)
        {
            index++;
            if (index >= pathParent.childCount)
            {
                newCamera.gameObject.SetActive(false);
                index = 0;
                camMove = false;
                cameraMoving = false;  // Kamera hareketi tamamlandı
                NewCamDeactive();
                return;
            }
            index %= pathParent.childCount;
            targetPoint = pathParent.GetChild(index);
        }
    }

    public void NewCamActive()
    {
        mainCamera.gameObject.SetActive(false);
        newCamera.gameObject.SetActive(true);
    }

    public void NewCamDeactive()
    {
        newCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
    }
}
