using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{    
    public static Vector3 sourcePosition;
    
    public static Vector3 targetPosition;


    public static float currentDistance
    {
        get;
        private set;
    }


    // Update is called once per frame
    void Update()
    {
        currentDistance = Mathf.Abs(Vector3.Distance(targetPosition, sourcePosition));
    }

}
