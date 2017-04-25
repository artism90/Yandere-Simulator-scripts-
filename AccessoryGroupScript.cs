using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000037 RID: 55
[Serializable]
public class AccessoryGroupScript : MonoBehaviour
{
	// Token: 0x060001AC RID: 428 RVA: 0x000202B8 File Offset: 0x0001E4B8
	public virtual void ActivateParts()
	{
		for (int i = 0; i < Extensions.get_length(this.Parts); i++)
		{
			this.Parts[i].active = true;
		}
	}

	// Token: 0x060001AD RID: 429 RVA: 0x000202F0 File Offset: 0x0001E4F0
	public virtual void DeactivateParts()
	{
		for (int i = 0; i < Extensions.get_length(this.Parts); i++)
		{
			this.Parts[i].active = false;
		}
	}

	// Token: 0x060001AE RID: 430 RVA: 0x00020328 File Offset: 0x0001E528
	public virtual void Main()
	{
	}

	// Token: 0x04000399 RID: 921
	public GameObject[] Parts;
}
