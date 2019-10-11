using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Text.RegularExpressions;

public class Trigger : MonoBehaviour
{
	[Header("On key press event")]
	public KeyCode			key;
	public UnityEvent		onKeyPressEvent;

	[Space, Header("On mouse press")]
	public int				button;
	public UnityEvent		onMousePress;

	[Space, Header("On Trigger event")]
	public LayerMask		triggerLayers = -1;
	public string			triggerTagRegex = ".*";
	public UnityEvent		onTriggerEvent;

	[Space, Header("On Collision event")]
	public LayerMask		collisionsLayers = -1;
	public string			collisionTagRegex = ".*";
	public UnityEvent		onCollisionEvent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(key))
			onKeyPressEvent.Invoke();
		
		if (Input.GetMouseButtonDown(button))
			onMousePress.Invoke();
	}

	bool ContainsLayer(LayerMask mask, int layer)
	{
		return ((mask.value >> layer) & 1) == 1;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (ContainsLayer(triggerLayers, other.gameObject.layer) && Regex.IsMatch(other.tag, triggerTagRegex))
			onTriggerEvent.Invoke();
	}

	void OnTriggerEnter(Collider other)
	{
		if (ContainsLayer(triggerLayers, other.gameObject.layer) && Regex.IsMatch(other.tag, triggerTagRegex))
			onTriggerEvent.Invoke();
	}

	void OnCollisionEnter(Collision other)
	{
		if (ContainsLayer(collisionsLayers, other.gameObject.layer) && Regex.IsMatch(other.gameObject.tag, collisionTagRegex))
			onCollisionEvent.Invoke();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (ContainsLayer(collisionsLayers, other.gameObject.layer) && Regex.IsMatch(other.gameObject.tag, collisionTagRegex))
			onCollisionEvent.Invoke();
	}
}
