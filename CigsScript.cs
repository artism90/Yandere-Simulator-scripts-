using System;
using UnityEngine;

// Token: 0x02000060 RID: 96
[Serializable]
public class CigsScript : MonoBehaviour
{
	// Token: 0x0600025E RID: 606 RVA: 0x0002B0D8 File Offset: 0x000292D8
	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			PlayerPrefs.SetInt("Scheme_3_Stage", 3);
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Cigs = true;
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	// Token: 0x0600025F RID: 607 RVA: 0x0002B144 File Offset: 0x00029344
	public virtual void Main()
	{
	}

	// Token: 0x04000518 RID: 1304
	public PromptScript Prompt;
}
