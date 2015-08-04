using UnityEngine;
using System.Collections;

public class ParticleTest : MonoBehaviour {

	private float maxValue;
	private float startValue;
	private float curValue;
	public float Seconds;
	public ParticleSystem myParticle;
	private bool upDown;
	private float SecsLeft;

	void Start ()
	{
		upDown = true;
		maxValue = 200;
		startValue = 0;
		Seconds = 2;
		SecsLeft = Seconds;
		myParticle.emissionRate = startValue;
	}

	// Update is called once per frame
	void Update () {
		if(upDown)
		{
			if(myParticle.emissionRate < maxValue)
			{

				float curValue = myParticle.emissionRate;
				float difValue = maxValue - curValue;

                curValue += (difValue * (Time.deltaTime / SecsLeft));

				SecsLeft = SecsLeft - Time.deltaTime;

				myParticle.emissionRate = curValue;
			}
			else
			{
				upDown = false;
			}
		}
	}
}
