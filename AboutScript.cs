using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000036 RID: 54
[Serializable]
public class AboutScript : MonoBehaviour
{
	// Token: 0x060001A8 RID: 424 RVA: 0x0001FD70 File Offset: 0x0001DF70
	public virtual void Start()
	{
		while (this.ID < Extensions.get_length(this.Labels))
		{
			int num = 2000;
			Vector3 localPosition = this.Labels[this.ID].localPosition;
			float num2 = localPosition.x = (float)num;
			Vector3 vector = this.Labels[this.ID].localPosition = localPosition;
			this.ID++;
		}
	}

	// Token: 0x060001A9 RID: 425 RVA: 0x0001FDE8 File Offset: 0x0001DFE8
	public virtual void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			if (this.SlideID < Extensions.get_length(this.Labels))
			{
				this.SlideIn[this.SlideID] = true;
			}
			this.SlideID++;
		}
		if (this.SlideID < Extensions.get_length(this.Labels) + 1)
		{
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.Labels))
			{
				if (this.SlideIn[this.ID])
				{
					float x = Mathf.Lerp(this.Labels[this.ID].localPosition.x, (float)0, Time.deltaTime);
					Vector3 localPosition = this.Labels[this.ID].localPosition;
					float num = localPosition.x = x;
					Vector3 vector = this.Labels[this.ID].localPosition = localPosition;
				}
				this.ID++;
			}
		}
		else
		{
			this.Timer += Time.deltaTime * (float)10;
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.Labels))
			{
				if (this.Timer > (float)this.ID)
				{
					this.SlideOut[this.ID] = true;
					if (this.Labels[this.ID].localPosition.x > (float)0)
					{
						float x2 = -0.1f;
						Vector3 localPosition2 = this.Labels[this.ID].localPosition;
						float num2 = localPosition2.x = x2;
						Vector3 vector2 = this.Labels[this.ID].localPosition = localPosition2;
					}
				}
				this.ID++;
			}
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.Labels))
			{
				if (this.SlideOut[this.ID])
				{
					float x3 = this.Labels[this.ID].localPosition.x + this.Labels[this.ID].localPosition.x * 0.01f;
					Vector3 localPosition3 = this.Labels[this.ID].localPosition;
					float num3 = localPosition3.x = x3;
					Vector3 vector3 = this.Labels[this.ID].localPosition = localPosition3;
				}
				this.ID++;
			}
			if (this.SlideID > Extensions.get_length(this.Labels) + 1)
			{
				float a = this.LinkLabel.color.a + Time.deltaTime;
				Color color = this.LinkLabel.color;
				float num4 = color.a = a;
				Color color2 = this.LinkLabel.color = color;
			}
			if (this.SlideID > Extensions.get_length(this.Labels) + 2)
			{
				float a2 = this.Yuno1.color.a + Time.deltaTime;
				Color color3 = this.Yuno1.color;
				float num5 = color3.a = a2;
				Color color4 = this.Yuno1.color = color3;
			}
			if (this.SlideID > Extensions.get_length(this.Labels) + 3)
			{
				float a3 = this.Yuno2.color.a + Time.deltaTime;
				Color color5 = this.Yuno2.color;
				float num6 = color5.a = a3;
				Color color6 = this.Yuno2.color = color5;
				float x4 = this.Yuno2.transform.localScale.x + Time.deltaTime * 0.1f;
				Vector3 localScale = this.Yuno2.transform.localScale;
				float num7 = localScale.x = x4;
				Vector3 vector4 = this.Yuno2.transform.localScale = localScale;
				float y = this.Yuno2.transform.localScale.y + Time.deltaTime * 0.1f;
				Vector3 localScale2 = this.Yuno2.transform.localScale;
				float num8 = localScale2.y = y;
				Vector3 vector5 = this.Yuno2.transform.localScale = localScale2;
			}
		}
	}

	// Token: 0x060001AA RID: 426 RVA: 0x000202AC File Offset: 0x0001E4AC
	public virtual void Main()
	{
	}

	// Token: 0x04000390 RID: 912
	public Transform[] Labels;

	// Token: 0x04000391 RID: 913
	public bool[] SlideOut;

	// Token: 0x04000392 RID: 914
	public bool[] SlideIn;

	// Token: 0x04000393 RID: 915
	public UILabel LinkLabel;

	// Token: 0x04000394 RID: 916
	public UITexture Yuno1;

	// Token: 0x04000395 RID: 917
	public UITexture Yuno2;

	// Token: 0x04000396 RID: 918
	public int SlideID;

	// Token: 0x04000397 RID: 919
	public int ID;

	// Token: 0x04000398 RID: 920
	public float Timer;
}
