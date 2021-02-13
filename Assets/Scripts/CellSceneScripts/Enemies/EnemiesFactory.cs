using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesFactory : MonoBehaviour
{
  
    public static void CreateGhost()
    {
        Enemy<Ghost> ghost = new Enemy<Ghost>("GhostEnemy");
        ghost.ScriptComponent.Initialize(
                speed: 2,
                position: new Vector3(12.12f, -3.2f, 1)
                );
    }

    public static void CreateBouncer()
    {
        Enemy<Bouncer> bouncer = new Enemy<Bouncer>("Eyeball");
        bouncer.ScriptComponent.Initialize(
            position: new Vector3(17.86f, -9.82f, 1)
            );

    }

    public static void CreateWizard()
    {
        Enemy<Wizard> wizard = new Enemy<Wizard>("Wizard");
        wizard.ScriptComponent.Initialize(
            position: new Vector3(8.4f, -1.81924f, 1));
    }
}
