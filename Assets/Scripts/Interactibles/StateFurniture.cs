using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFurniture : MouseTarget
{
    [Header("State Furniture")]

    public string parameterName = "open";

    public override void Interact()
    {
        base.Interact();

        if (objectAnim.GetBool(parameterName))
            objectAnim.SetBool(parameterName, false);
        else
            objectAnim.SetBool(parameterName, true);
    }

}
