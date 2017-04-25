using System;
using UnityEngine;

// Token: 0x02000044 RID: 68
[Serializable]
public class AudioListenerScript : MonoBehaviour
{
	// Token: 0x060001E8 RID: 488 RVA: 0x000251F8 File Offset: 0x000233F8
	public virtual void Update()
	{
		if (Camera.main != null)
		{
			this.transform.position = this.Target.position;
			this.transform.eulerAngles = Camera.main.transform.eulerAngles;
		}
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x00025248 File Offset: 0x00023448
	public virtual void Main()
	{
	}

	// Token: 0x0400041D RID: 1053
	public Transform Target;
}
