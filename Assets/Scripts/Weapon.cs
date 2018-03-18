using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public GameObject shot;
	public Transform[] shotSpawns;
	public float fireRate;
	public AudioClip audioClip;

	private float nextFire;
	private AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = audioClip;
	}

	public void Shot()
	{
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			foreach(var shotSpawn in shotSpawns) {
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			}

			audioSource.Play ();
		}
	}
}
