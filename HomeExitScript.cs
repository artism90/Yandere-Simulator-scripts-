using System;
using UnityEngine;

// Token: 0x020000B1 RID: 177
[Serializable]
public class HomeExitScript : MonoBehaviour
{
	// Token: 0x060003D9 RID: 985 RVA: 0x0004CA4C File Offset: 0x0004AC4C
	public HomeExitScript()
	{
		this.ID = 1;
	}

	// Token: 0x060003DA RID: 986 RVA: 0x0004CA5C File Offset: 0x0004AC5C
	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("Night") == 1)
		{
			float a = 0.5f;
			Color color = this.Labels[1].color;
			float num = color.a = a;
			Color color2 = this.Labels[1].color = color;
			float a2 = 0.5f;
			Color color3 = this.Labels[2].color;
			float num2 = color3.a = a2;
			Color color4 = this.Labels[2].color = color3;
		}
	}

	// Token: 0x060003DB RID: 987 RVA: 0x0004CAF0 File Offset: 0x0004ACF0
	public virtual void Update()
	{
		if (!this.HomeYandere.CanMove && !this.HomeDarkness.FadeOut)
		{
			if (this.InputManager.TappedDown)
			{
				this.ID++;
				if (this.ID > 3)
				{
					this.ID = 1;
				}
				int num = 50 - this.ID * 50;
				Vector3 localPosition = this.Highlight.localPosition;
				float num2 = localPosition.y = (float)num;
				Vector3 vector = this.Highlight.localPosition = localPosition;
			}
			if (this.InputManager.TappedUp)
			{
				this.ID--;
				if (this.ID < 1)
				{
					this.ID = 3;
				}
				int num3 = 50 - this.ID * 50;
				Vector3 localPosition2 = this.Highlight.localPosition;
				float num4 = localPosition2.y = (float)num3;
				Vector3 vector2 = this.Highlight.localPosition = localPosition2;
			}
			if (Input.GetButtonDown("A") && (PlayerPrefs.GetInt("Night") == 0 || (PlayerPrefs.GetInt("Night") == 1 && this.ID == 3)))
			{
				if (this.ID < 3)
				{
					this.HomeDarkness.Sprite.color = new Color((float)1, (float)1, (float)1, (float)0);
				}
				this.HomeDarkness.FadeOut = true;
				this.HomeWindow.Show = false;
				this.enabled = false;
			}
			if (Input.GetButtonDown("B"))
			{
				this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
				this.HomeCamera.Target = this.HomeCamera.Targets[0];
				this.HomeYandere.CanMove = true;
				this.HomeWindow.Show = false;
				this.enabled = false;
			}
		}
	}

	// Token: 0x060003DC RID: 988 RVA: 0x0004CCE0 File Offset: 0x0004AEE0
	public virtual void Main()
	{
	}

	// Token: 0x0400098B RID: 2443
	public InputManagerScript InputManager;

	// Token: 0x0400098C RID: 2444
	public HomeDarknessScript HomeDarkness;

	// Token: 0x0400098D RID: 2445
	public HomeYandereScript HomeYandere;

	// Token: 0x0400098E RID: 2446
	public HomeCameraScript HomeCamera;

	// Token: 0x0400098F RID: 2447
	public HomeWindowScript HomeWindow;

	// Token: 0x04000990 RID: 2448
	public Transform Highlight;

	// Token: 0x04000991 RID: 2449
	public UILabel[] Labels;

	// Token: 0x04000992 RID: 2450
	public int ID;
}
