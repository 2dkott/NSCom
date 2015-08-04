using System;
using System.Collections.Generic;
using UnityEngine;

public class ParticalSystemAnimation
{
    private ParticleSystem prtSystem;
    // Time in Seconds
    private float timeToAchiveEmissionRate;
    private float SecondsLeft;
    private float emmisionRate;
    private float minEmissionRate;

    public ParticalSystemAnimation(ParticleSystem prtSystem)
    {
        this.prtSystem = prtSystem;
        timeToAchiveEmissionRate = 1f;
        minEmissionRate = 0f;
        SecondsLeft = timeToAchiveEmissionRate;
        EmissionRate = this.prtSystem.emissionRate;
        this.prtSystem.emissionRate = minEmissionRate;
    }

    public ParticalSystemAnimation setTimeToAchiveEmissionRate(float time)
    {
        timeToAchiveEmissionRate = time;
        return this;
    }

    public ParticalSystemAnimation setMinEmissionRate(float rate)
    {
        this.prtSystem.emissionRate = rate;
        minEmissionRate = rate;
        return this;
    }

    public void playWithEmissionRateIncrementInTime(float maxEmissionRate)
    {
        if (this.prtSystem.emissionRate < maxEmissionRate)
        {
            float curValue = this.prtSystem.emissionRate;
            float difValue = maxEmissionRate - curValue;

            curValue += (difValue * (Time.deltaTime / SecondsLeft));

            SecondsLeft = SecondsLeft - Time.deltaTime;

            this.prtSystem.emissionRate = curValue;
        }
        else
        {
            SecondsLeft = timeToAchiveEmissionRate;
        }
        this.prtSystem.Play();
    }

    public void playWithEmissionRateIncrementInTime()
    {
        if (this.prtSystem.emissionRate < this.EmissionRate)
        {
            float curValue = this.prtSystem.emissionRate;
            float difValue = this.EmissionRate - curValue;
            curValue += (difValue * (Time.deltaTime / SecondsLeft));
            this.prtSystem.emissionRate = curValue;
        }
        prtSystem.Play();
    }

    public void stopAndEmissionRateToZero()
    {
        prtSystem.Stop();
        this.prtSystem.emissionRate = this.minEmissionRate;
    }
    public float EmissionRate { get; set; }
}

