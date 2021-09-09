using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    public static LineRenderer line = Resources.Load<LineRenderer>("Line/RedLine");
    // Start is called before the first frame update
    public static LineRenderer DrawLine(Vector2 from, Vector2 to)
    {
        LineRenderer line = Instantiate<LineRenderer>(Lines.line);
        line.SetPosition(0, from);
        line.SetPosition(1, to);
        return line;
    }
}
