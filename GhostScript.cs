using System;
using UnityEngine;

// Token: 0x0200009F RID: 159
[Serializable]
public class GhostScript : MonoBehaviour
{
	// Token: 0x06000395 RID: 917 RVA: 0x000491A4 File Offset: 0x000473A4
	public virtual void Update()
	{
		if (Time.timeScale > (float)0)
		{
			if (this.Frame > 0)
			{
				((Animation)this.GetComponent(typeof(Animation))).enabled = false;
				this.active = false;
				this.Frame = 0;
			}
			this.Frame++;
		}
	}

	// Token: 0x06000396 RID: 918 RVA: 0x00049200 File Offset: 0x00047400
	public virtual void Look()
	{
		this.Neck.LookAt(this.SmartphoneCamera.position);
	}

	// Token: 0x06000397 RID: 919 RVA: 0x00049218 File Offset: 0x00047418
	public virtual void Main()
	{
	}

	// Token: 0x040008EE RID: 2286
	public Transform SmartphoneCamera;

	// Token: 0x040008EF RID: 2287
	public Transform Neck;

	// Token: 0x040008F0 RID: 2288
	public Transform GhostEyeLocation;

	// Token: 0x040008F1 RID: 2289
	public Transform GhostEye;

	// Token: 0x040008F2 RID: 2290
	public int Frame;
}
