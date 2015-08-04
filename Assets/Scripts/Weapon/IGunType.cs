using UnityEngine;

public interface IGunType
{
    void shoot();
    float Rate { get; }
    Transform HostShip { set; }
}