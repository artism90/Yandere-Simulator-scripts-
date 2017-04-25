using System;
using UnityEngine;

// Token: 0x0200003A RID: 58
[Serializable]
public class AnswerSheetScript : MonoBehaviour
{
	// Token: 0x060001B8 RID: 440 RVA: 0x00020A40 File Offset: 0x0001EC40
	public AnswerSheetScript()
	{
		this.Phase = 1;
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x00020A50 File Offset: 0x0001EC50
	public virtual void Start()
	{
		this.OriginalMesh = this.MyMesh.mesh;
		if (PlayerPrefs.GetInt("Scheme_5_Stage") == 100)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.active = false;
		}
		else
		{
			if (PlayerPrefs.GetInt("Scheme_5_Stage") > 4)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
			if (PlayerPrefs.GetInt("Weekday") == 5 && this.Clock.HourTime > 13.5f)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.active = false;
			}
		}
	}

	// Token: 0x060001BA RID: 442 RVA: 0x00020B0C File Offset: 0x0001ED0C
	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			if (this.Phase == 1)
			{
				PlayerPrefs.SetInt("Scheme_5_Stage", 2);
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.AnswerSheet = true;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.DoorGap.Prompt.enabled = true;
				this.MyMesh.mesh = null;
				this.Phase++;
			}
			else
			{
				PlayerPrefs.SetInt("Scheme_5_Stage", 5);
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.AnswerSheet = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.MyMesh.mesh = this.OriginalMesh;
				this.Phase++;
			}
		}
	}

	// Token: 0x060001BB RID: 443 RVA: 0x00020C14 File Offset: 0x0001EE14
	public virtual void Main()
	{
	}

	// Token: 0x040003AE RID: 942
	public SchemesScript Schemes;

	// Token: 0x040003AF RID: 943
	public DoorGapScript DoorGap;

	// Token: 0x040003B0 RID: 944
	public PromptScript Prompt;

	// Token: 0x040003B1 RID: 945
	public ClockScript Clock;

	// Token: 0x040003B2 RID: 946
	public Mesh OriginalMesh;

	// Token: 0x040003B3 RID: 947
	public MeshFilter MyMesh;

	// Token: 0x040003B4 RID: 948
	public int Phase;
}
