using System;
using UnityEngine;

// Token: 0x02000057 RID: 87
[Serializable]
public class CabinetDoorScript : MonoBehaviour
{
	// Token: 0x0600023B RID: 571 RVA: 0x000290F0 File Offset: 0x000272F0
	public virtual void Update()
	{
		if (this.Locked)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
		}
		else
		{
			if (this.Prompt.Circle[0].fillAmount == (float)0)
			{
				this.Prompt.Circle[0].fillAmount = (float)1;
				if (!this.Open)
				{
					this.Open = true;
				}
				else
				{
					this.Open = false;
				}
			}
			if (this.Open)
			{
				float x = Mathf.Lerp(this.transform.localPosition.x, 0.41775f, Time.deltaTime * (float)10);
				Vector3 localPosition = this.transform.localPosition;
				float num = localPosition.x = x;
				Vector3 vector = this.transform.localPosition = localPosition;
			}
			else
			{
				float x2 = Mathf.Lerp(this.transform.localPosition.x, (float)0, Time.deltaTime * (float)10);
				Vector3 localPosition2 = this.transform.localPosition;
				float num2 = localPosition2.x = x2;
				Vector3 vector2 = this.transform.localPosition = localPosition2;
			}
		}
	}

	// Token: 0x0600023C RID: 572 RVA: 0x0002922C File Offset: 0x0002742C
	public virtual void Main()
	{
	}

	// Token: 0x040004C0 RID: 1216
	public PromptScript Prompt;

	// Token: 0x040004C1 RID: 1217
	public bool Locked;

	// Token: 0x040004C2 RID: 1218
	public bool Open;
}
