using System;
using UnityEngine;

// Token: 0x0200005A RID: 90
[Serializable]
public class ChallengeScript : MonoBehaviour
{
	// Token: 0x06000244 RID: 580 RVA: 0x00029BCC File Offset: 0x00027DCC
	public ChallengeScript()
	{
		this.Phase = 1;
	}

	// Token: 0x06000245 RID: 581 RVA: 0x00029BDC File Offset: 0x00027DDC
	public virtual void Update()
	{
		if (!this.Viewing)
		{
			if (!this.Switch)
			{
				if (this.InputManager.TappedUp || this.InputManager.TappedDown)
				{
					if (this.List == 0)
					{
						int num = -300;
						Vector3 localPosition = this.Arrows.localPosition;
						float num2 = localPosition.y = (float)num;
						Vector3 vector = this.Arrows.localPosition = localPosition;
						this.ViewButton.active = true;
						this.Panels[0].alpha = 0.5f;
						this.Panels[1].alpha = (float)1;
						this.List = 1;
					}
					else
					{
						int num3 = 200;
						Vector3 localPosition2 = this.Arrows.localPosition;
						float num4 = localPosition2.y = (float)num3;
						Vector3 vector2 = this.Arrows.localPosition = localPosition2;
						this.ViewButton.active = false;
						this.Panels[0].alpha = (float)1;
						this.Panels[1].alpha = 0.5f;
						this.List = 0;
					}
				}
				if (this.InputManager.DPadRight || Input.GetKey("right"))
				{
					float x = this.ChallengeList[this.List].localPosition.x - Time.deltaTime * (float)1000;
					Vector3 localPosition3 = this.ChallengeList[this.List].localPosition;
					float num5 = localPosition3.x = x;
					Vector3 vector3 = this.ChallengeList[this.List].localPosition = localPosition3;
				}
				if (this.InputManager.DPadLeft || Input.GetKey("left"))
				{
					float x2 = this.ChallengeList[this.List].localPosition.x + Time.deltaTime * (float)1000;
					Vector3 localPosition4 = this.ChallengeList[this.List].localPosition;
					float num6 = localPosition4.x = x2;
					Vector3 vector4 = this.ChallengeList[this.List].localPosition = localPosition4;
				}
				float x3 = this.ChallengeList[this.List].localPosition.x + Input.GetAxis("Horizontal") * (float)-10;
				Vector3 localPosition5 = this.ChallengeList[this.List].localPosition;
				float num7 = localPosition5.x = x3;
				Vector3 vector5 = this.ChallengeList[this.List].localPosition = localPosition5;
				if (this.ChallengeList[this.List].localPosition.x > (float)500)
				{
					int num8 = 500;
					Vector3 localPosition6 = this.ChallengeList[this.List].localPosition;
					float num9 = localPosition6.x = (float)num8;
					Vector3 vector6 = this.ChallengeList[this.List].localPosition = localPosition6;
				}
				else if (this.ChallengeList[this.List].localPosition.x < (float)(-250 * (this.Challenges[this.List] - 3)))
				{
					int num10 = -250 * (this.Challenges[this.List] - 3);
					Vector3 localPosition7 = this.ChallengeList[this.List].localPosition;
					float num11 = localPosition7.x = (float)num10;
					Vector3 vector7 = this.ChallengeList[this.List].localPosition = localPosition7;
				}
				if (this.LargeIcon.color.a > (float)0)
				{
					float a = this.LargeIcon.color.a - Time.deltaTime * (float)10;
					Color color = this.LargeIcon.color;
					float num12 = color.a = a;
					Color color2 = this.LargeIcon.color = color;
					if (this.LargeIcon.color.a < (float)0)
					{
						int num13 = 0;
						Color color3 = this.LargeIcon.color;
						float num14 = color3.a = (float)num13;
						Color color4 = this.LargeIcon.color = color3;
					}
				}
			}
		}
		else if (this.LargeIcon.color.a < (float)1)
		{
			float a2 = this.LargeIcon.color.a + Time.deltaTime * (float)10;
			Color color5 = this.LargeIcon.color;
			float num15 = color5.a = a2;
			Color color6 = this.LargeIcon.color = color5;
			if (this.LargeIcon.color.a > (float)1)
			{
				int num16 = 1;
				Color color7 = this.LargeIcon.color;
				float num17 = color7.a = (float)num16;
				Color color8 = this.LargeIcon.color = color7;
			}
		}
		float a3 = this.LargeIcon.color.a * 0.75f;
		Color color9 = this.Shadow.color;
		float num18 = color9.a = a3;
		Color color10 = this.Shadow.color = color9;
		if (!this.Switch && Input.GetButtonDown("A") && this.List == 1 && this.ChallengeList[this.List].localPosition.x > (float)-2375)
		{
			this.Viewing = true;
		}
		if (Input.GetButtonDown("B"))
		{
			if (this.Viewing)
			{
				this.Viewing = false;
			}
			else
			{
				this.Switch = true;
			}
		}
		if (this.Switch)
		{
			if (this.Phase == 1)
			{
				this.ChallengePanel.alpha = this.ChallengePanel.alpha - Time.deltaTime;
				if (this.ChallengePanel.alpha <= (float)0)
				{
					this.Phase++;
				}
			}
			else
			{
				this.CalendarPanel.alpha = this.CalendarPanel.alpha + Time.deltaTime;
				if (this.CalendarPanel.alpha >= (float)1)
				{
					this.Calendar.enabled = true;
					this.enabled = false;
					this.Switch = false;
					this.Phase = 1;
				}
			}
		}
	}

	// Token: 0x06000246 RID: 582 RVA: 0x0002A28C File Offset: 0x0002848C
	public virtual void Main()
	{
	}

	// Token: 0x040004DB RID: 1243
	public InputManagerScript InputManager;

	// Token: 0x040004DC RID: 1244
	public CalendarScript Calendar;

	// Token: 0x040004DD RID: 1245
	public GameObject ViewButton;

	// Token: 0x040004DE RID: 1246
	public Transform Arrows;

	// Token: 0x040004DF RID: 1247
	public Transform[] ChallengeList;

	// Token: 0x040004E0 RID: 1248
	public int[] Challenges;

	// Token: 0x040004E1 RID: 1249
	public UIPanel[] Panels;

	// Token: 0x040004E2 RID: 1250
	public UIPanel ChallengePanel;

	// Token: 0x040004E3 RID: 1251
	public UIPanel CalendarPanel;

	// Token: 0x040004E4 RID: 1252
	public UITexture LargeIcon;

	// Token: 0x040004E5 RID: 1253
	public UISprite Shadow;

	// Token: 0x040004E6 RID: 1254
	public bool Viewing;

	// Token: 0x040004E7 RID: 1255
	public bool Switch;

	// Token: 0x040004E8 RID: 1256
	public int Phase;

	// Token: 0x040004E9 RID: 1257
	public int List;
}
