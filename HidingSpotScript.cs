using System;
using UnityEngine;

// Token: 0x020000AB RID: 171
[Serializable]
public class HidingSpotScript : MonoBehaviour
{
	// Token: 0x060003C4 RID: 964 RVA: 0x0004B69C File Offset: 0x0004989C
	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			float y = 0.3f;
			Vector3 center = this.Prompt.Yandere.MyController.center;
			float num = center.y = y;
			Vector3 vector = this.Prompt.Yandere.MyController.center = center;
			this.Prompt.Yandere.MyController.height = 0.5f;
			this.Prompt.Yandere.HidingSpot = this.Spot;
			this.Prompt.Yandere.ExitSpot = this.Exit;
			this.Prompt.Yandere.CanMove = false;
			this.Prompt.Yandere.Hiding = true;
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[1].text = "Stop Hiding";
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = true;
		}
	}

	// Token: 0x060003C5 RID: 965 RVA: 0x0004B7C0 File Offset: 0x000499C0
	public virtual void Main()
	{
	}

	// Token: 0x04000950 RID: 2384
	public PromptBarScript PromptBar;

	// Token: 0x04000951 RID: 2385
	public PromptScript Prompt;

	// Token: 0x04000952 RID: 2386
	public Transform Exit;

	// Token: 0x04000953 RID: 2387
	public Transform Spot;
}
