using System;
using UnityEngine;

// Token: 0x02000041 RID: 65
[Serializable]
public class ArcTrailScript : MonoBehaviour
{
	// Token: 0x060001D5 RID: 469 RVA: 0x00021BF8 File Offset: 0x0001FDF8
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Trail.material.SetColor("_TintColor", new Color((float)1, (float)0, (float)0, (float)1));
		}
	}

	// Token: 0x060001D6 RID: 470 RVA: 0x00021C3C File Offset: 0x0001FE3C
	public virtual void Main()
	{
	}

	// Token: 0x040003E9 RID: 1001
	public TrailRenderer Trail;
}
