using General;
using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    private bool isRange;

    public GameObject car;

    public Transform destination;
    public float speed = 1f;
    public int timeStop;

    private Vector3 startPosition; 
    private bool isMoving = false;
    private bool isMovingTooGamer = false;

    private void OnEnable()
    {
        GameEvents.Instance.Subscribe(GameEventType.OrderCompleted, StartCar);
    }

    private void Start()
    {
        startPosition = transform.position; 
    }
    private void Update()
    {
        if(isMoving == true)
        {
            float step = speed * Time.deltaTime; 
            transform.position = Vector3.MoveTowards(transform.position, destination.position, step);
            if (transform.position == destination.position) {
                isMoving=false;
                StartCoroutine(TineStopCar());
            }
        }
        if(isMovingTooGamer == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, startPosition, step);
            if (transform.position == startPosition)
            {
                isMovingTooGamer = false;
            }
        }

    }
    [Button("StartCar")]
    void StartCar()
    {
        if(Application.isPlaying == false)
            return;

        isMoving = true;
    }

    IEnumerator TineStopCar()
    {
        yield return new WaitForSeconds(timeStop);
        isMovingTooGamer=true;

    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        isRange = true;
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        isRange = false;
    //    }

    //}

    private void OnDisable()
    {
        GameEvents.Instance.UnSubscribe(GameEventType.OrderCompleted, StartCar);
    }
}
