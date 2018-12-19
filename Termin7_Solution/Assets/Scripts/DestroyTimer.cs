using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour {

    [SerializeField]
    private float _lifeTime = 3;
    private float _timer;
	
	// Update is called once per frame
	private void Update () {
        _timer += Time.deltaTime;

        if (_timer >= _lifeTime)
            Destroy(gameObject);
	}
}
