using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour {

	public void Move(Vector2 moveAmount) {

        float deltaY = moveAmount.y;

        transform.Translate(moveAmount);
	}
}
