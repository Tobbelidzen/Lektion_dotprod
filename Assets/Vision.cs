using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public Transform target;
    private Vector3 VecToTarget;
    private float dotproduct;
    private float angle;
    private Vector3 VecDirection = new Vector3(1f,0, 0);
    public TextMeshProUGUI angleText;        // Dra och släpp Text-komponenten här
    public TextMeshProUGUI dotProductText;   // För att visa dotprodukten

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angleText.text = angle.ToString();
        dotProductText.text = dotproduct.ToString();
    }

    private void FixedUpdate()
    {
        VecToTarget = target.position - transform.position;
        VecToTarget.Normalize();

        Debug.DrawLine(transform.position, transform.parent.rotation * VecDirection * 50, Color.blue);
        
        dotproduct = (VecToTarget.x * transform.parent.TransformDirection(VecDirection).x) + 
            (VecToTarget.y * transform.parent.TransformDirection(VecDirection).y) ;

        // Omvandla till vinkel i grader
        angle = Mathf.Acos(dotproduct) * Mathf.Rad2Deg;


        if (dotproduct > 0 )
        {
            if(angle > -45 && angle < 45)
            {
                Debug.Log("Ser spelaren med angle: " + angle);
                GetComponent<ray>().CheckVision();
            }
        }



    }
}
