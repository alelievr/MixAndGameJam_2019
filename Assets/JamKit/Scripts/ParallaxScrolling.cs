using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
	public Transform[]	backgrounds;
	public float[]		parallaxScales;
	public float		smoothing = 1f;

	Transform			cameraTransform;
	Vector3				previousCameraPosition;

	void Awake()
	{
		cameraTransform = Camera.main.transform;
	}

	void Start ()
	{
		previousCameraPosition = cameraTransform.position;

		parallaxScales = new float[backgrounds.Length];

		for (int i = 0; i < backgrounds.Length; i++)
			parallaxScales[i] = -backgrounds[i].position.z;
	}
	
	void Update ()
	{
		for (int i = 0; i < backgrounds.Length; i++)
		{
			float parallax = (previousCameraPosition.x - cameraTransform.position.x) * parallaxScales[i];
			float backgroudTargetPosition = backgrounds[i].position.x + parallax;

			Vector3 backgroundTargetPosition = new Vector3(backgroudTargetPosition, backgrounds[i].position.y, backgrounds[i].position.z);

			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPosition, smoothing * Time.deltaTime);

		}

		previousCameraPosition = cameraTransform.position;
	}
}
