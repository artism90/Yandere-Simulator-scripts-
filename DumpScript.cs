using System;
using UnityEngine;

// Token: 0x02000087 RID: 135
[Serializable]
public class DumpScript : MonoBehaviour
{
	// Token: 0x06000335 RID: 821 RVA: 0x000430F4 File Offset: 0x000412F4
	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)5)
		{
			this.Incinerator.Corpses = this.Incinerator.Corpses + 1;
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	// Token: 0x06000336 RID: 822 RVA: 0x00043144 File Offset: 0x00041344
	public virtual void Main()
	{
	}

	// Token: 0x04000810 RID: 2064
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04000811 RID: 2065
	public IncineratorScript Incinerator;

	// Token: 0x04000812 RID: 2066
	public float Timer;
}
