using System;
using UnityEngine;

// Token: 0x02000089 RID: 137
[Serializable]
public class DumpsterLidScript : MonoBehaviour
{
	// Token: 0x0600033C RID: 828 RVA: 0x00043764 File Offset: 0x00041964
	public virtual void Start()
	{
		this.FallChecker.active = false;
		this.Prompt.HideButton[3] = true;
	}

	// Token: 0x0600033D RID: 829 RVA: 0x0004378C File Offset: 0x0004198C
	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			if (!this.Open)
			{
				this.Prompt.Label[0].text = "     " + "Close";
				this.Open = true;
			}
			else
			{
				this.Prompt.Label[0].text = "     " + "Open";
				this.Open = false;
			}
		}
		if (!this.Open)
		{
			this.Rotation = Mathf.Lerp(this.Rotation, (float)0, Time.deltaTime * (float)10);
			this.Prompt.HideButton[3] = true;
		}
		else
		{
			this.Rotation = Mathf.Lerp(this.Rotation, (float)-115, Time.deltaTime * (float)10);
			if (this.Corpse != null)
			{
				if (this.Prompt.Yandere.PickUp != null)
				{
					if (this.Prompt.Yandere.PickUp.Garbage)
					{
						this.Prompt.HideButton[3] = false;
					}
					else
					{
						this.Prompt.HideButton[3] = true;
					}
				}
				else
				{
					this.Prompt.HideButton[3] = true;
				}
			}
			else
			{
				this.Prompt.HideButton[3] = true;
			}
			if (this.Prompt.Circle[3].fillAmount <= (float)0)
			{
				UnityEngine.Object.Destroy(this.Prompt.Yandere.PickUp.gameObject);
				this.Prompt.Circle[3].fillAmount = (float)1;
				this.Prompt.HideButton[3] = false;
				this.Fill = true;
			}
			if (this.transform.position.z > this.DisposalSpot - 0.05f && this.transform.position.z < this.DisposalSpot + 0.05f)
			{
				if (this.Prompt.Yandere.RoofPush)
				{
					this.FallChecker.active = true;
				}
				else
				{
					this.FallChecker.active = false;
				}
			}
			else
			{
				this.FallChecker.active = false;
			}
		}
		this.Hinge.localEulerAngles = new Vector3(this.Rotation, (float)0, (float)0);
		if (this.Fill)
		{
			float y = Mathf.Lerp(this.GarbageDebris.localPosition.y, (float)1, Time.deltaTime * (float)10);
			Vector3 localPosition = this.GarbageDebris.localPosition;
			float num = localPosition.y = y;
			Vector3 vector = this.GarbageDebris.localPosition = localPosition;
			if (this.GarbageDebris.localPosition.y > 0.99f)
			{
				this.Prompt.Yandere.Police.SuicideScene = false;
				this.Prompt.Yandere.Police.Suicide = false;
				this.Prompt.Yandere.Police.HiddenCorpses = this.Prompt.Yandere.Police.HiddenCorpses - 1;
				this.Prompt.Yandere.Police.Corpses = this.Prompt.Yandere.Police.Corpses - 1;
				this.Prompt.Yandere.NearBodies = this.Prompt.Yandere.NearBodies - 1;
				int num2 = 1;
				Vector3 localPosition2 = this.GarbageDebris.localPosition;
				float num3 = localPosition2.y = (float)num2;
				Vector3 vector2 = this.GarbageDebris.localPosition = localPosition2;
				UnityEngine.Object.Destroy(this.Corpse);
				this.Fill = false;
			}
		}
	}

	// Token: 0x0600033E RID: 830 RVA: 0x00043BB0 File Offset: 0x00041DB0
	public virtual void Main()
	{
	}

	// Token: 0x0400081C RID: 2076
	public Transform GarbageDebris;

	// Token: 0x0400081D RID: 2077
	public Transform Hinge;

	// Token: 0x0400081E RID: 2078
	public GameObject FallChecker;

	// Token: 0x0400081F RID: 2079
	public GameObject Corpse;

	// Token: 0x04000820 RID: 2080
	public PromptScript Prompt;

	// Token: 0x04000821 RID: 2081
	public float DisposalSpot;

	// Token: 0x04000822 RID: 2082
	public float Rotation;

	// Token: 0x04000823 RID: 2083
	public bool Fill;

	// Token: 0x04000824 RID: 2084
	public bool Open;
}
