using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    public Transform[] background;
    private float[] parallaxScales;
    public float smoothing = 1f;

    private Transform cam;
    private Vector3 previouscamPos;

    void Awake()
    {
        cam = Camera.main.transform;
    }
    void Start()
    {
        previouscamPos = cam.position;

        parallaxScales = new float[background.Length];

        for (int i = 0; i< background.Length; i++)
        {
            parallaxScales[i] = background[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i =0; i< background.Length; i++)
        {
            float parallax = (previouscamPos.x = cam.position.x) * parallaxScales[i];

            float backgroundTargetPosX = background[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, background[i].position.y, background[i].position.z);

            background[i].position = Vector3.Lerp(background[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        previouscamPos = cam.position;
    }
}
