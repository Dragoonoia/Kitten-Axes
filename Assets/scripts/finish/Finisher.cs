using UnityEngine;
using Fusion;

public class Finisher : NetworkBehaviour
{
    [Networked] public bool P1Finished {  get; set; }
    void Start()
    {
        
    }

    public override void Spawned()
    {
        P1Finished = false;
    }


    void Update()
    {
        
    }


}
