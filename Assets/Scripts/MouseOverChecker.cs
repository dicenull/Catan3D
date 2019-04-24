using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverChecker : MonoBehaviour
{
	Material material;

	private void Awake()
	{
		material = GetComponent<Renderer>().material;
	}

	private void OnMouseOver()
	{
		material.color = Color.red;
		transform.Rotate(Vector3.up);
	}

	private void OnMouseExit()
	{
		material.color = Color.white;
		transform.rotation = Quaternion.identity;
	}
}
