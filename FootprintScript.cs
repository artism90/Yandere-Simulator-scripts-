using System;
using UnityEngine;

// Token: 0x02000095 RID: 149
[Serializable]
public class FootprintScript : MonoBehaviour
{
	// Token: 0x0600036D RID: 877 RVA: 0x00047234 File Offset: 0x00045434
	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent("YandereScript");
		if (this.Yandere.Schoolwear == 0 || this.Yandere.Schoolwear == 2)
		{
			this.renderer.material.mainTexture = this.Footprint;
		}
		UnityEngine.Object.Destroy(this);
	}

	// Token: 0x0600036E RID: 878 RVA: 0x000472A0 File Offset: 0x000454A0
	public virtual void Main()
	{
	}

	// Token: 0x04000894 RID: 2196
	public YandereScript Yandere;

	// Token: 0x04000895 RID: 2197
	public Texture Footprint;
}
