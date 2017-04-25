using System;
using UnityEngine;

// Token: 0x020000A7 RID: 167
[Serializable]
public class HeadsetScript : MonoBehaviour
{
	// Token: 0x060003B5 RID: 949 RVA: 0x00049FC0 File Offset: 0x000481C0
	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			PlayerPrefs.SetInt("Headset", 1);
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Headset = true;
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	// Token: 0x060003B6 RID: 950 RVA: 0x0004A02C File Offset: 0x0004822C
	public virtual void Main()
	{
	}

	// Token: 0x04000927 RID: 2343
	public PromptScript Prompt;
}
