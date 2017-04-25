using System;
using UnityEngine;

// Token: 0x02000052 RID: 82
[Serializable]
public class BoundaryScript : MonoBehaviour
{
	// Token: 0x06000225 RID: 549 RVA: 0x00026F50 File Offset: 0x00025150
	public virtual void Update()
	{
		if (this.Yandere.position.z < (float)-94)
		{
			this.Intensity = -95f + Mathf.Abs(this.Yandere.position.z);
			this.AnimatedGif.enabled = true;
			float a = this.Intensity / 5f;
			Color color = this.Static.color;
			float num = color.a = a;
			Color color2 = this.Static.color = color;
			float a2 = this.Intensity / 5f;
			Color color3 = this.Label.color;
			float num2 = color3.a = a2;
			Color color4 = this.Label.color = color3;
			this.audio.volume = this.Intensity / 5f * 0.1f;
			float x = UnityEngine.Random.Range(-10f, 10f);
			Vector3 localPosition = this.Label.transform.localPosition;
			float num3 = localPosition.x = x;
			Vector3 vector = this.Label.transform.localPosition = localPosition;
			float y = UnityEngine.Random.Range(-10f, 10f);
			Vector3 localPosition2 = this.Label.transform.localPosition;
			float num4 = localPosition2.y = y;
			Vector3 vector2 = this.Label.transform.localPosition = localPosition2;
		}
		else if (this.AnimatedGif.enabled)
		{
			this.AnimatedGif.enabled = false;
			int num5 = 0;
			Color color5 = this.Static.color;
			float num6 = color5.a = (float)num5;
			Color color6 = this.Static.color = color5;
			int num7 = 0;
			Color color7 = this.Label.color;
			float num8 = color7.a = (float)num7;
			Color color8 = this.Label.color = color7;
			this.audio.volume = (float)0;
		}
	}

	// Token: 0x06000226 RID: 550 RVA: 0x0002717C File Offset: 0x0002537C
	public virtual void Main()
	{
	}

	// Token: 0x04000484 RID: 1156
	public AnimatedGifScript AnimatedGif;

	// Token: 0x04000485 RID: 1157
	public Transform Yandere;

	// Token: 0x04000486 RID: 1158
	public UISprite Static;

	// Token: 0x04000487 RID: 1159
	public UILabel Label;

	// Token: 0x04000488 RID: 1160
	public float Intensity;
}
