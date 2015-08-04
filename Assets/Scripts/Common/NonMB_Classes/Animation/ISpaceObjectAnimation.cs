using System.Collections.Generic;
using UnityEngine;

public interface ISpaceObjectAnimation
{
    void play(bool start);
}

public static class SpaceObjectAnimation
{
    
    public static List<ISpaceObjectAnimation> collectAnimations(List<Transform> componentList)
    {
        List<ISpaceObjectAnimation> aniamtionsList = new List<ISpaceObjectAnimation>();
        foreach (Transform component in componentList)
        {
            foreach (ISpaceObjectAnimation componentAnimation in GameObjectExtensions.GetInterfaces<ISpaceObjectAnimation>(component.gameObject))
            {
                aniamtionsList.Add(componentAnimation);
            }
        }
        return aniamtionsList;
    }


}