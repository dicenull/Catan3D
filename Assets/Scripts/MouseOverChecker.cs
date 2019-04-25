using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverChecker : MonoBehaviour
{
	Material material;
	VillageSetter setter;

	private void Awake()
	{
		material = GetComponent<Renderer>().material;
		setter = transform.parent.GetComponent<VillageSetter>();
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

	private void OnMouseDown()
	{
		
		setter.CreateVillage(gameObject, Color.blue);
	}
}
