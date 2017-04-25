using System;
using UnityEngine;

// Token: 0x020000B0 RID: 176
[Serializable]
public class HomeDarknessScript : MonoBehaviour
{
	// Token: 0x060003D6 RID: 982 RVA: 0x0004C4FC File Offset: 0x0004A6FC
	public virtual void Start()
	{
		int num = 1;
		Color color = this.Sprite.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Sprite.color = color;
	}

	// Token: 0x060003D7 RID: 983 RVA: 0x0004C538 File Offset: 0x0004A738
	public virtual void Update()
	{
		if (this.FadeOut)
		{
			if (!this.FadeSlow)
			{
				float a = this.Sprite.color.a + Time.deltaTime;
				Color color = this.Sprite.color;
				float num = color.a = a;
				Color color2 = this.Sprite.color = color;
			}
			else
			{
				float a2 = this.Sprite.color.a + Time.deltaTime * 0.2f;
				Color color3 = this.Sprite.color;
				float num2 = color3.a = a2;
				Color color4 = this.Sprite.color = color3;
			}
			if (this.Sprite.color.a >= (float)1)
			{
				if (this.HomeCamera.ID != 2)
				{
					if (this.HomeCamera.ID == 5)
					{
						Application.LoadLevel("YanvaniaTitleScene");
					}
					else if (this.HomeCamera.ID == 9)
					{
						Application.LoadLevel("CalendarScene");
					}
					else if (this.HomeCamera.ID == 10)
					{
						PlayerPrefs.SetInt("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Kidnapped", 0);
						PlayerPrefs.SetInt("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Slave", 1);
						Application.LoadLevel("LoadingScene");
					}
					else if (this.HomeCamera.ID == 11)
					{
						PlayerPrefs.SetInt("KidnapConversation", 1);
						Application.LoadLevel("PhoneScene");
					}
					else if (this.HomeExit.ID == 1)
					{
						Application.LoadLevel("LoadingScene");
					}
					else if (this.HomeExit.ID == 2)
					{
						Application.LoadLevel("TownScene");
					}
					else if (this.HomeExit.ID == 3)
					{
						if (this.HomeYandere.transform.position.y > (float)-5)
						{
							this.HomeYandere.transform.position = new Vector3((float)-2, (float)-10, (float)-2);
							this.HomeYandere.transform.eulerAngles = new Vector3((float)0, (float)90, (float)0);
							this.HomeYandere.CanMove = true;
							this.FadeOut = false;
							this.HomeCamera.Destinations[0].position = new Vector3(2.425f, (float)-8, (float)0);
							this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
							this.HomeCamera.transform.position = this.HomeCamera.Destination.position;
							this.HomeCamera.Target = this.HomeCamera.Targets[0];
							this.HomeCamera.Focus.position = this.HomeCamera.Target.position;
							this.BasementLabel.text = "Upstairs";
							this.HomeCamera.DayLight.active = true;
						}
						else
						{
							this.HomeYandere.transform.position = new Vector3(-1.6f, (float)0, -1.6f);
							this.HomeYandere.transform.eulerAngles = new Vector3((float)0, (float)45, (float)0);
							this.HomeYandere.CanMove = true;
							this.FadeOut = false;
							this.HomeCamera.Destinations[0].position = new Vector3(-2.0615f, (float)2, 2.418f);
							this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
							this.HomeCamera.transform.position = this.HomeCamera.Destination.position;
							this.HomeCamera.Target = this.HomeCamera.Targets[0];
							this.HomeCamera.Focus.position = this.HomeCamera.Target.position;
							this.BasementLabel.text = "Basement";
							if (PlayerPrefs.GetInt("Night") == 1)
							{
								this.HomeCamera.DayLight.active = false;
							}
						}
					}
				}
				else
				{
					Application.LoadLevel("CalendarScene");
				}
			}
		}
		else
		{
			float a3 = this.Sprite.color.a - Time.deltaTime;
			Color color5 = this.Sprite.color;
			float num3 = color5.a = a3;
			Color color6 = this.Sprite.color = color5;
			if (this.Sprite.color.a < (float)0)
			{
				int num4 = 0;
				Color color7 = this.Sprite.color;
				float num5 = color7.a = (float)num4;
				Color color8 = this.Sprite.color = color7;
			}
		}
	}

	// Token: 0x060003D8 RID: 984 RVA: 0x0004CA48 File Offset: 0x0004AC48
	public virtual void Main()
	{
	}

	// Token: 0x04000984 RID: 2436
	public HomeYandereScript HomeYandere;

	// Token: 0x04000985 RID: 2437
	public HomeCameraScript HomeCamera;

	// Token: 0x04000986 RID: 2438
	public HomeExitScript HomeExit;

	// Token: 0x04000987 RID: 2439
	public UILabel BasementLabel;

	// Token: 0x04000988 RID: 2440
	public UISprite Sprite;

	// Token: 0x04000989 RID: 2441
	public bool FadeSlow;

	// Token: 0x0400098A RID: 2442
	public bool FadeOut;
}
