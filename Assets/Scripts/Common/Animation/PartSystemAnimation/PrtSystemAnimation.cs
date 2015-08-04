using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrtSystemAnimation : MonoBehaviour, ISpaceObjectAnimation
{

    public List<ParticleSystem> PrtSystemsList;
    private List<ParticalSystemAnimation> prtStmAnimatiomList;
    public float timeToFullEmissionRate;
    public float minEmissionRate;

    // Use this for initialization
    void Start () {
        prtStmAnimatiomList = transformListToPrtStmAnimList(PrtSystemsList);
        if (timeToFullEmissionRate == 0) timeToFullEmissionRate = 1f;
	}
    
    private List<KeyValuePair<ParticleSystem, float>> transformListToPairsParticleList(List<ParticleSystem> list)
    {
        List<KeyValuePair<ParticleSystem, float>> pairsList = new List<KeyValuePair<ParticleSystem, float>>();
        foreach (ParticleSystem emitter in list)
        {
            pairsList.Add(new KeyValuePair<ParticleSystem, float>(emitter, emitter.emissionRate));
        }
        return pairsList;
    }

    private List<ParticalSystemAnimation> transformListToPrtStmAnimList(List<ParticleSystem> list)
    {
        List<ParticalSystemAnimation> pairsList = new List<ParticalSystemAnimation>();
        foreach (ParticleSystem emitter in list)
        {
            pairsList.Add(new ParticalSystemAnimation(emitter).setTimeToAchiveEmissionRate(timeToFullEmissionRate).setMinEmissionRate(minEmissionRate));
        }
        return pairsList;
    }

    public void play(bool start)
    {
        if (start) startAnimation(prtStmAnimatiomList);
        else stopAnimation(prtStmAnimatiomList);
    }

    private void startAnimation(List<ParticalSystemAnimation> pairsList)
    {
        foreach (ParticalSystemAnimation animation in pairsList)
        {
            animation.playWithEmissionRateIncrementInTime();
        }
    }

    private void stopAnimation(List<ParticalSystemAnimation> pairsList)
    {
        foreach (ParticalSystemAnimation animation in pairsList)
        {
            animation.stopAndEmissionRateToZero();
        }
    }
}