using System;
using UnityEngine;

// Token: 0x020000A8 RID: 168
[Serializable]
public class HeartbrokenCursorScript : MonoBehaviour
{
	// Token: 0x060003B7 RID: 951 RVA: 0x0004A030 File Offset: 0x00048230
	public HeartbrokenCursorScript()
	{
		this.Selected = 1;
		this.Options = 4;
	}

	// Token: 0x060003B8 RID: 952 RVA: 0x0004A048 File Offset: 0x00048248
	public virtual void Start()
	{
		int num = -989;
		Vector3 localPosition = this.Darkness.transform.localPosition;
		float num2 = localPosition.z = (float)num;
		Vector3 vector = this.Darkness.transform.localPosition = localPosition;
		int num3 = 0;
		Color color = this.Continue.color;
		float num4 = color.a = (float)num3;
		Color color2 = this.Continue.color = color;
	}

	// Token: 0x060003B9 RID: 953 RVA: 0x0004A0CC File Offset: 0x000482CC
	public virtual void Update()
	{
		float y = Mathf.Lerp(this.transform.localPosition.y, (float)(255 - this.Selected * 50), Time.deltaTime * (float)10);
		Vector3 localPosition = this.transform.localPosition;
		float num = localPosition.y = y;
		Vector3 vector = this.transform.localPosition = localPosition;
		if (!this.FadeOut)
		{
			if (this.MyLabel.color.a >= (float)1)
			{
				if (this.InputManager.TappedDown)
				{
					this.Selected++;
					if (this.Selected > this.Options)
					{
						this.Selected = 1;
					}
					this.audio.clip = this.MoveSound;
					this.audio.Play();
				}
				if (this.InputManager.TappedUp)
				{
					this.Selected--;
					if (this.Selected < 1)
					{
						this.Selected = this.Options;
					}
					this.audio.clip = this.MoveSound;
					this.audio.Play();
				}
				if (this.Selected != 4)
				{
					int num2 = 1;
					Color color = this.Continue.color;
					float num3 = color.a = (float)num2;
					Color color2 = this.Continue.color = color;
				}
				else
				{
					int num4 = 0;
					Color color3 = this.Continue.color;
					float num5 = color3.a = (float)num4;
					Color color4 = this.Continue.color = color3;
				}
				if (Input.GetButtonDown("A"))
				{
					this.audio.clip = this.SelectSound;
					this.audio.Play();
					this.Nudge = true;
					if (this.Selected != 4)
					{
						this.FadeOut = true;
					}
				}
			}
		}
		else
		{
			this.Heartbroken.audio.volume = this.Heartbroken.audio.volume - Time.deltaTime;
			float a = this.Darkness.color.a + Time.deltaTime;
			Color color5 = this.Darkness.color;
			float num6 = color5.a = a;
			Color color6 = this.Darkness.color = color5;
			if (this.Darkness.color.a >= (float)1)
			{
				if (this.Selected == 1)
				{
					for (int i = 0; i < this.StudentManager.NPCsTotal; i++)
					{
						if (PlayerPrefs.GetInt("Student_" + i + "_Dying") == 1)
						{
							PlayerPrefs.SetInt("Student_" + i + "_Dying", 0);
						}
					}
					Application.LoadLevel(Application.loadedLevel);
				}
				else if (this.Selected == 2)
				{
					PlayerPrefs.DeleteAll();
					Application.LoadLevel("CalendarScene");
				}
				else if (this.Selected == 3)
				{
					Application.LoadLevel("TitleScene");
				}
			}
		}
		if (this.Nudge)
		{
			float x = this.transform.localPosition.x + Time.deltaTime * (float)250;
			Vector3 localPosition2 = this.transform.localPosition;
			float num7 = localPosition2.x = x;
			Vector3 vector2 = this.transform.localPosition = localPosition2;
			if (this.transform.localPosition.x > (float)-225)
			{
				int num8 = -225;
				Vector3 localPosition3 = this.transform.localPosition;
				float num9 = localPosition3.x = (float)num8;
				Vector3 vector3 = this.transform.localPosition = localPosition3;
				this.Nudge = false;
			}
		}
		else
		{
			float x2 = this.transform.localPosition.x - Time.deltaTime * (float)250;
			Vector3 localPosition4 = this.transform.localPosition;
			float num10 = localPosition4.x = x2;
			Vector3 vector4 = this.transform.localPosition = localPosition4;
			if (this.transform.localPosition.x < (float)-250)
			{
				int num11 = -250;
				Vector3 localPosition5 = this.transform.localPosition;
				float num12 = localPosition5.x = (float)num11;
				Vector3 vector5 = this.transform.localPosition = localPosition5;
			}
		}
	}

	// Token: 0x060003BA RID: 954 RVA: 0x0004A58C File Offset: 0x0004878C
	public virtual void Main()
	{
	}

	// Token: 0x04000928 RID: 2344
	public StudentManagerScript StudentManager;

	// Token: 0x04000929 RID: 2345
	public InputManagerScript InputManager;

	// Token: 0x0400092A RID: 2346
	public HeartbrokenScript Heartbroken;

	// Token: 0x0400092B RID: 2347
	public UISprite Darkness;

	// Token: 0x0400092C RID: 2348
	public UILabel Continue;

	// Token: 0x0400092D RID: 2349
	public UILabel MyLabel;

	// Token: 0x0400092E RID: 2350
	public bool FadeOut;

	// Token: 0x0400092F RID: 2351
	public bool Nudge;

	// Token: 0x04000930 RID: 2352
	public int Selected;

	// Token: 0x04000931 RID: 2353
	public int Options;

	// Token: 0x04000932 RID: 2354
	public AudioClip SelectSound;

	// Token: 0x04000933 RID: 2355
	public AudioClip MoveSound;
}
