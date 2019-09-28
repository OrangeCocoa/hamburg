using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InGameScript : MonoBehaviour
{
    public static float PlayTime { get; private set; }
    public static int Stage { get; private set; }

    void Awake()
    {
        PlayTime = 0f;
        var sceneName = this.gameObject.scene.name;
        StringBuilder sb = new StringBuilder(sceneName);
        Stage = int.Parse((sb.Remove(0, sceneName.Length - 1)).ToString());
    }

    private void Update()
    {

    }

    void FixedUpdate()
    {

    }
}
