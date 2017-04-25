using System;
using UnityEngine;

// Token: 0x02000068 RID: 104
[Serializable]
public class CollectibleScript : MonoBehaviour
{
	// Token: 0x0600028C RID: 652 RVA: 0x0002F00C File Offset: 0x0002D20C
	public CollectibleScript()
	{
		this.Name = string.Empty;
	}

	// Token: 0x0600028D RID: 653 RVA: 0x0002F020 File Offset: 0x0002D220
	public virtual void Start()
	{
		if (PlayerPrefs.GetInt(this.Name + "_" + this.ID + "_Collected") == 1)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	// Token: 0x0600028E RID: 654 RVA: 0x0002F070 File Offset: 0x0002D270
	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			PlayerPrefs.SetInt(this.Name + "_" + this.ID + "_Collected", 1);
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	// Token: 0x0600028F RID: 655 RVA: 0x0002F0D4 File Offset: 0x0002D2D4
	public virtual void Main()
	{
	}

	// Token: 0x040005A9 RID: 1449
	public PromptScript Prompt;

	// Token: 0x040005AA RID: 1450
	public string Name;

	// Token: 0x040005AB RID: 1451
	public int ID;
}
