using System.Collections.Generic;
using UnityEngine;

public class DispenserPump
{
    public void MoveObject(List<Liquid> liquids, Vector3 exitPoint)
    {
        for (int i = 0; i < liquids.Count; i++)
        {
            Liquid liquid = liquids[i];

            if (i == 0)
            {
                liquid.transform.position = exitPoint;
            }
            else
            {
                int previousInstance = i - 1;

                liquid.transform.position = liquids[previousInstance].transform.position - liquids[previousInstance].Height * Vector3.up;
            }
        }
    }
}
