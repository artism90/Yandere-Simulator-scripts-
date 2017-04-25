using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x020000B2 RID: 178
[Serializable]
public class HomeInternetScript : MonoBehaviour
{
	// Token: 0x060003DD RID: 989 RVA: 0x0004CCE4 File Offset: 0x0004AEE4
	public HomeInternetScript()
	{
		this.MenuSelected = 1;
		this.Selected = 1;
		this.ID = 1;
	}

	// Token: 0x060003DE RID: 990 RVA: 0x0004CD04 File Offset: 0x0004AF04
	public virtual void Start()
	{
		int num = -180;
		Vector3 localPosition = this.StudentPost1.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.StudentPost1.localPosition = localPosition;
		int num3 = -365;
		Vector3 localPosition2 = this.StudentPost2.localPosition;
		float num4 = localPosition2.y = (float)num3;
		Vector3 vector2 = this.StudentPost2.localPosition = localPosition2;
		int num5 = -88;
		Vector3 localPosition3 = this.YandereReply.localPosition;
		float num6 = localPosition3.y = (float)num5;
		Vector3 vector3 = this.YandereReply.localPosition = localPosition3;
		int num7 = -2;
		Vector3 localPosition4 = this.YanderePost.localPosition;
		float num8 = localPosition4.y = (float)num7;
		Vector3 vector4 = this.YanderePost.localPosition = localPosition4;
		int num9 = -40;
		Vector3 localPosition5 = this.StudentReplies[1].localPosition;
		float num10 = localPosition5.y = (float)num9;
		Vector3 vector5 = this.StudentReplies[1].localPosition = localPosition5;
		int num11 = -40;
		Vector3 localPosition6 = this.StudentReplies[2].localPosition;
		float num12 = localPosition6.y = (float)num11;
		Vector3 vector6 = this.StudentReplies[2].localPosition = localPosition6;
		int num13 = -40;
		Vector3 localPosition7 = this.StudentReplies[3].localPosition;
		float num14 = localPosition7.y = (float)num13;
		Vector3 vector7 = this.StudentReplies[3].localPosition = localPosition7;
		int num15 = -40;
		Vector3 localPosition8 = this.StudentReplies[4].localPosition;
		float num16 = localPosition8.y = (float)num15;
		Vector3 vector8 = this.StudentReplies[4].localPosition = localPosition8;
		int num17 = -40;
		Vector3 localPosition9 = this.StudentReplies[5].localPosition;
		float num18 = localPosition9.y = (float)num17;
		Vector3 vector9 = this.StudentReplies[5].localPosition = localPosition9;
		int num19 = -40;
		Vector3 localPosition10 = this.LameReply.localPosition;
		float num20 = localPosition10.y = (float)num19;
		Vector3 vector10 = this.LameReply.localPosition = localPosition10;
		this.Highlights[1].enabled = false;
		this.Highlights[2].enabled = false;
		this.Highlights[3].enabled = false;
		this.YanderePost.active = false;
		this.ChangeLabel.active = false;
		this.ChangeIcon.active = false;
		this.PostLabel.active = false;
		this.PostIcon.active = false;
		this.NewPostText.active = false;
		this.BG.active = false;
		if (PlayerPrefs.GetInt("Event2") == 0 || PlayerPrefs.GetInt("Student_7_Exposed") == 1)
		{
			this.WriteLabel.active = false;
			this.WriteIcon.active = false;
		}
	}

	// Token: 0x060003DF RID: 991 RVA: 0x0004D008 File Offset: 0x0004B208
	public virtual void Update()
	{
		if (!this.HomeYandere.CanMove && !this.PauseScreen.Show)
		{
			if (!this.ShowMenu)
			{
				this.Menu.localScale = Vector3.Lerp(this.Menu.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			}
			else
			{
				this.Menu.localScale = Vector3.Lerp(this.Menu.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			}
			if (this.WritingPost)
			{
				this.NewPost.transform.localPosition = Vector3.Lerp(this.NewPost.transform.localPosition, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.NewPost.transform.localScale = Vector3.Lerp(this.NewPost.transform.localScale, new Vector3(2.43f, 2.43f, 2.43f), Time.deltaTime * (float)10);
				for (int i = 1; i < Extensions.get_length(this.Highlights); i++)
				{
					if (!this.FadeOut)
					{
						float a = Mathf.MoveTowards(this.Highlights[i].color.a, (float)1, Time.deltaTime);
						Color color = this.Highlights[i].color;
						float num = color.a = a;
						Color color2 = this.Highlights[i].color = color;
					}
					else
					{
						float a2 = Mathf.MoveTowards(this.Highlights[i].color.a, (float)0, Time.deltaTime);
						Color color3 = this.Highlights[i].color;
						float num2 = color3.a = a2;
						Color color4 = this.Highlights[i].color = color3;
					}
				}
				if (this.Highlights[this.Selected].color.a == (float)1)
				{
					this.FadeOut = true;
				}
				else if (this.Highlights[this.Selected].color.a == (float)0)
				{
					this.FadeOut = false;
				}
				if (!this.ShowMenu)
				{
					if (this.InputManager.TappedRight)
					{
						this.Selected++;
						this.UpdateHighlight();
					}
					if (this.InputManager.TappedLeft)
					{
						this.Selected--;
						this.UpdateHighlight();
					}
				}
				else
				{
					if (this.InputManager.TappedDown)
					{
						this.MenuSelected++;
						this.UpdateMenuHighlight();
					}
					if (this.InputManager.TappedUp)
					{
						this.MenuSelected--;
						this.UpdateMenuHighlight();
					}
				}
			}
			else
			{
				this.NewPost.transform.localPosition = Vector3.Lerp(this.NewPost.transform.localPosition, new Vector3((float)175, (float)-10, (float)0), Time.deltaTime * (float)10);
				this.NewPost.transform.localScale = Vector3.Lerp(this.NewPost.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			}
			if (!this.PostSequence)
			{
				if (Input.GetButtonDown("A") && this.WriteIcon.active && !this.Posted)
				{
					if (!this.ShowMenu)
					{
						if (!this.WritingPost)
						{
							this.AcceptLabel.text = "Select";
							this.ChangeLabel.active = true;
							this.ChangeIcon.active = true;
							this.NewPostText.active = true;
							this.BG.active = true;
							this.WritingPost = true;
							this.Selected = 1;
							this.UpdateHighlight();
						}
						else if (this.Selected == 1)
						{
							this.PauseScreen.MainMenu.active = false;
							this.PauseScreen.Panel.enabled = true;
							this.PauseScreen.Sideways = true;
							this.PauseScreen.Show = true;
							this.StudentInfoMenu.gameObject.active = true;
							this.StudentInfoMenu.CyberBullying = true;
							this.StartCoroutine_Auto(this.StudentInfoMenu.UpdatePortraits());
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "View Info";
							this.PromptBar.Label[1].text = "Back";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
						}
						else if (this.Selected == 2)
						{
							this.MenuSelected = 1;
							this.UpdateMenuHighlight();
							this.ShowMenu = true;
							for (int i = 1; i < this.MenuLabels.Length; i++)
							{
								this.MenuLabels[i].text = this.Locations[i];
							}
						}
						else if (this.Selected == 3)
						{
							this.MenuSelected = 1;
							this.UpdateMenuHighlight();
							this.ShowMenu = true;
							for (int i = 1; i < this.MenuLabels.Length; i++)
							{
								this.MenuLabels[i].text = this.Actions[i];
							}
						}
					}
					else
					{
						if (this.Selected == 2)
						{
							this.Location = this.MenuSelected;
							this.PostLabels[2].text = string.Empty + this.Locations[this.MenuSelected];
							this.ShowMenu = false;
						}
						else if (this.Selected == 3)
						{
							this.Action = this.MenuSelected;
							this.PostLabels[3].text = string.Empty + this.Actions[this.MenuSelected];
							this.ShowMenu = false;
						}
						this.CheckForCompletion();
					}
				}
				if (Input.GetButtonDown("B"))
				{
					if (!this.ShowMenu)
					{
						if (!this.WritingPost)
						{
							this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
							this.HomeCamera.Target = this.HomeCamera.Targets[0];
							this.HomeYandere.CanMove = true;
							this.HomeWindow.Show = false;
							this.enabled = false;
						}
						else
						{
							this.AcceptLabel.text = "Write";
							this.ChangeLabel.active = false;
							this.ChangeIcon.active = false;
							this.PostLabel.active = false;
							this.PostIcon.active = false;
							this.ExitPost();
						}
					}
					else
					{
						this.ShowMenu = false;
					}
				}
				if (Input.GetButtonDown("X") && this.PostIcon.active)
				{
					this.YanderePostLabel.text = "Today, I saw " + this.PostLabels[1].text + " in " + this.PostLabels[2].text + ". She was " + this.PostLabels[3].text + ".";
					this.ExitPost();
					this.InternetPrompts.active = false;
					this.ChangeLabel.active = false;
					this.ChangeIcon.active = false;
					this.WriteLabel.active = false;
					this.WriteIcon.active = false;
					this.PostLabel.active = false;
					this.PostIcon.active = false;
					this.PostSequence = true;
					this.Posted = true;
					if (this.Student == 7 && this.Location == 7 && this.Action == 9)
					{
						this.Success = true;
					}
				}
			}
			if (this.PostSequence)
			{
				if (Input.GetButtonDown("A"))
				{
					this.Timer += (float)2;
				}
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)1 && this.Timer < (float)3)
				{
					this.YanderePost.active = true;
					float y = Mathf.Lerp(this.YanderePost.transform.localPosition.y, (float)-155, Time.deltaTime * (float)10);
					Vector3 localPosition = this.YanderePost.transform.localPosition;
					float num3 = localPosition.y = y;
					Vector3 vector = this.YanderePost.transform.localPosition = localPosition;
					float y2 = Mathf.Lerp(this.StudentPost1.transform.localPosition.y, (float)-365, Time.deltaTime * (float)10);
					Vector3 localPosition2 = this.StudentPost1.transform.localPosition;
					float num4 = localPosition2.y = y2;
					Vector3 vector2 = this.StudentPost1.transform.localPosition = localPosition2;
					float y3 = Mathf.Lerp(this.StudentPost2.transform.localPosition.y, (float)-550, Time.deltaTime * (float)10);
					Vector3 localPosition3 = this.StudentPost2.transform.localPosition;
					float num5 = localPosition3.y = y3;
					Vector3 vector3 = this.StudentPost2.transform.localPosition = localPosition3;
				}
				if (!this.Success)
				{
					if (this.Timer > (float)3 && this.Timer < (float)5)
					{
						float y4 = Mathf.Lerp(this.LameReply.transform.localPosition.y, (float)-88, Time.deltaTime * (float)10);
						Vector3 localPosition4 = this.LameReply.localPosition;
						float num6 = localPosition4.y = y4;
						Vector3 vector4 = this.LameReply.localPosition = localPosition4;
						float y5 = Mathf.Lerp(this.YandereReply.transform.localPosition.y, (float)-137, Time.deltaTime * (float)10);
						Vector3 localPosition5 = this.YandereReply.localPosition;
						float num7 = localPosition5.y = y5;
						Vector3 vector5 = this.YandereReply.localPosition = localPosition5;
						float y6 = Mathf.Lerp(this.StudentPost1.transform.localPosition.y, (float)-415, Time.deltaTime * (float)10);
						Vector3 localPosition6 = this.StudentPost1.localPosition;
						float num8 = localPosition6.y = y6;
						Vector3 vector6 = this.StudentPost1.localPosition = localPosition6;
					}
					if (this.Timer > (float)5)
					{
						PlayerPrefs.SetFloat("Reputation", PlayerPrefs.GetFloat("Reputation") - (float)5);
						this.InternetPrompts.active = true;
						this.PostSequence = false;
					}
				}
				else
				{
					if (this.Timer > (float)3 && this.Timer < (float)5)
					{
						float y7 = Mathf.Lerp(this.StudentReplies[1].transform.localPosition.y, (float)-88, Time.deltaTime * (float)10);
						Vector3 localPosition7 = this.StudentReplies[1].localPosition;
						float num9 = localPosition7.y = y7;
						Vector3 vector7 = this.StudentReplies[1].localPosition = localPosition7;
						float y8 = Mathf.Lerp(this.YandereReply.transform.localPosition.y, (float)-137, Time.deltaTime * (float)10);
						Vector3 localPosition8 = this.YandereReply.localPosition;
						float num10 = localPosition8.y = y8;
						Vector3 vector8 = this.YandereReply.localPosition = localPosition8;
						float y9 = Mathf.Lerp(this.StudentPost1.transform.localPosition.y, (float)-415, Time.deltaTime * (float)10);
						Vector3 localPosition9 = this.StudentPost1.localPosition;
						float num11 = localPosition9.y = y9;
						Vector3 vector9 = this.StudentPost1.localPosition = localPosition9;
					}
					if (this.Timer > (float)5 && this.Timer < (float)7)
					{
						float y10 = Mathf.Lerp(this.StudentReplies[2].transform.localPosition.y, (float)-88, Time.deltaTime * (float)10);
						Vector3 localPosition10 = this.StudentReplies[2].localPosition;
						float num12 = localPosition10.y = y10;
						Vector3 vector10 = this.StudentReplies[2].localPosition = localPosition10;
						float y11 = Mathf.Lerp(this.StudentReplies[1].transform.localPosition.y, (float)-136, Time.deltaTime * (float)10);
						Vector3 localPosition11 = this.StudentReplies[1].localPosition;
						float num13 = localPosition11.y = y11;
						Vector3 vector11 = this.StudentReplies[1].localPosition = localPosition11;
						float y12 = Mathf.Lerp(this.YandereReply.transform.localPosition.y, (float)-185, Time.deltaTime * (float)10);
						Vector3 localPosition12 = this.YandereReply.localPosition;
						float num14 = localPosition12.y = y12;
						Vector3 vector12 = this.YandereReply.localPosition = localPosition12;
						float y13 = Mathf.Lerp(this.StudentPost1.transform.localPosition.y, (float)-465, Time.deltaTime * (float)10);
						Vector3 localPosition13 = this.StudentPost1.localPosition;
						float num15 = localPosition13.y = y13;
						Vector3 vector13 = this.StudentPost1.localPosition = localPosition13;
					}
					if (this.Timer > (float)7 && this.Timer < (float)9)
					{
						float y14 = Mathf.Lerp(this.StudentReplies[3].transform.localPosition.y, (float)-88, Time.deltaTime * (float)10);
						Vector3 localPosition14 = this.StudentReplies[3].localPosition;
						float num16 = localPosition14.y = y14;
						Vector3 vector14 = this.StudentReplies[3].localPosition = localPosition14;
						float y15 = Mathf.Lerp(this.StudentReplies[2].transform.localPosition.y, (float)-136, Time.deltaTime * (float)10);
						Vector3 localPosition15 = this.StudentReplies[2].localPosition;
						float num17 = localPosition15.y = y15;
						Vector3 vector15 = this.StudentReplies[2].localPosition = localPosition15;
						float y16 = Mathf.Lerp(this.StudentReplies[1].transform.localPosition.y, (float)-184, Time.deltaTime * (float)10);
						Vector3 localPosition16 = this.StudentReplies[1].localPosition;
						float num18 = localPosition16.y = y16;
						Vector3 vector16 = this.StudentReplies[1].localPosition = localPosition16;
						float y17 = Mathf.Lerp(this.YandereReply.transform.localPosition.y, (float)-233, Time.deltaTime * (float)10);
						Vector3 localPosition17 = this.YandereReply.localPosition;
						float num19 = localPosition17.y = y17;
						Vector3 vector17 = this.YandereReply.localPosition = localPosition17;
						float y18 = Mathf.Lerp(this.StudentPost1.transform.localPosition.y, (float)-510, Time.deltaTime * (float)10);
						Vector3 localPosition18 = this.StudentPost1.localPosition;
						float num20 = localPosition18.y = y18;
						Vector3 vector18 = this.StudentPost1.localPosition = localPosition18;
					}
					if (this.Timer > (float)9 && this.Timer < (float)11)
					{
						float y19 = Mathf.Lerp(this.StudentReplies[4].transform.localPosition.y, (float)-88, Time.deltaTime * (float)10);
						Vector3 localPosition19 = this.StudentReplies[4].localPosition;
						float num21 = localPosition19.y = y19;
						Vector3 vector19 = this.StudentReplies[4].localPosition = localPosition19;
						float y20 = Mathf.Lerp(this.StudentReplies[3].transform.localPosition.y, (float)-136, Time.deltaTime * (float)10);
						Vector3 localPosition20 = this.StudentReplies[3].localPosition;
						float num22 = localPosition20.y = y20;
						Vector3 vector20 = this.StudentReplies[3].localPosition = localPosition20;
						float y21 = Mathf.Lerp(this.StudentReplies[2].transform.localPosition.y, (float)-184, Time.deltaTime * (float)10);
						Vector3 localPosition21 = this.StudentReplies[2].localPosition;
						float num23 = localPosition21.y = y21;
						Vector3 vector21 = this.StudentReplies[2].localPosition = localPosition21;
						float y22 = Mathf.Lerp(this.StudentReplies[1].transform.localPosition.y, (float)-232, Time.deltaTime * (float)10);
						Vector3 localPosition22 = this.StudentReplies[1].localPosition;
						float num24 = localPosition22.y = y22;
						Vector3 vector22 = this.StudentReplies[1].localPosition = localPosition22;
						float y23 = Mathf.Lerp(this.YandereReply.transform.localPosition.y, (float)-281, Time.deltaTime * (float)10);
						Vector3 localPosition23 = this.YandereReply.localPosition;
						float num25 = localPosition23.y = y23;
						Vector3 vector23 = this.YandereReply.localPosition = localPosition23;
						float y24 = Mathf.Lerp(this.StudentPost1.transform.localPosition.y, (float)-560, Time.deltaTime * (float)10);
						Vector3 localPosition24 = this.StudentPost1.localPosition;
						float num26 = localPosition24.y = y24;
						Vector3 vector24 = this.StudentPost1.localPosition = localPosition24;
					}
					if (this.Timer > (float)11 && this.Timer < (float)13)
					{
						float y25 = Mathf.Lerp(this.StudentReplies[5].transform.localPosition.y, (float)-88, Time.deltaTime * (float)10);
						Vector3 localPosition25 = this.StudentReplies[5].localPosition;
						float num27 = localPosition25.y = y25;
						Vector3 vector25 = this.StudentReplies[5].localPosition = localPosition25;
						float y26 = Mathf.Lerp(this.StudentReplies[4].transform.localPosition.y, (float)-136, Time.deltaTime * (float)10);
						Vector3 localPosition26 = this.StudentReplies[4].localPosition;
						float num28 = localPosition26.y = y26;
						Vector3 vector26 = this.StudentReplies[4].localPosition = localPosition26;
						float y27 = Mathf.Lerp(this.StudentReplies[3].transform.localPosition.y, (float)-184, Time.deltaTime * (float)10);
						Vector3 localPosition27 = this.StudentReplies[3].localPosition;
						float num29 = localPosition27.y = y27;
						Vector3 vector27 = this.StudentReplies[3].localPosition = localPosition27;
						float y28 = Mathf.Lerp(this.StudentReplies[2].transform.localPosition.y, (float)-232, Time.deltaTime * (float)10);
						Vector3 localPosition28 = this.StudentReplies[2].localPosition;
						float num30 = localPosition28.y = y28;
						Vector3 vector28 = this.StudentReplies[2].localPosition = localPosition28;
						float y29 = Mathf.Lerp(this.StudentReplies[1].transform.localPosition.y, (float)-280, Time.deltaTime * (float)10);
						Vector3 localPosition29 = this.StudentReplies[1].localPosition;
						float num31 = localPosition29.y = y29;
						Vector3 vector29 = this.StudentReplies[1].localPosition = localPosition29;
						float y30 = Mathf.Lerp(this.YandereReply.transform.localPosition.y, (float)-329, Time.deltaTime * (float)10);
						Vector3 localPosition30 = this.YandereReply.localPosition;
						float num32 = localPosition30.y = y30;
						Vector3 vector30 = this.YandereReply.localPosition = localPosition30;
					}
					if (this.Timer > (float)13)
					{
						PlayerPrefs.SetInt("Student_7_Exposed", 1);
						PlayerPrefs.SetInt("Student_7_Reputation", PlayerPrefs.GetInt("Student_7_Reputation") - 50);
						this.InternetPrompts.active = true;
						this.PostSequence = false;
					}
				}
			}
		}
	}

	// Token: 0x060003E0 RID: 992 RVA: 0x0004E57C File Offset: 0x0004C77C
	public virtual void ExitPost()
	{
		this.Highlights[1].enabled = false;
		this.Highlights[2].enabled = false;
		this.Highlights[3].enabled = false;
		this.NewPostText.active = false;
		this.BG.active = false;
		this.PostLabels[1].text = string.Empty;
		this.PostLabels[2].text = string.Empty;
		this.PostLabels[3].text = string.Empty;
		this.WritingPost = false;
	}

	// Token: 0x060003E1 RID: 993 RVA: 0x0004E608 File Offset: 0x0004C808
	public virtual void UpdateHighlight()
	{
		if (this.Selected > 3)
		{
			this.Selected = 1;
		}
		if (this.Selected < 1)
		{
			this.Selected = 3;
		}
		this.Highlights[1].enabled = false;
		this.Highlights[2].enabled = false;
		this.Highlights[3].enabled = false;
		this.Highlights[this.Selected].enabled = true;
	}

	// Token: 0x060003E2 RID: 994 RVA: 0x0004E678 File Offset: 0x0004C878
	public virtual void UpdateMenuHighlight()
	{
		if (this.MenuSelected > 10)
		{
			this.MenuSelected = 1;
		}
		if (this.MenuSelected < 1)
		{
			this.MenuSelected = 10;
		}
		int num = 220 - 40 * this.MenuSelected;
		Vector3 localPosition = this.MenuHighlight.transform.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.MenuHighlight.transform.localPosition = localPosition;
	}

	// Token: 0x060003E3 RID: 995 RVA: 0x0004E6F4 File Offset: 0x0004C8F4
	public virtual void CheckForCompletion()
	{
		if (this.PostLabels[1].text != string.Empty && this.PostLabels[2].text != string.Empty && this.PostLabels[3].text != string.Empty)
		{
			this.PostLabel.active = true;
			this.PostIcon.active = true;
		}
	}

	// Token: 0x060003E4 RID: 996 RVA: 0x0004E770 File Offset: 0x0004C970
	public virtual void Main()
	{
	}

	// Token: 0x04000993 RID: 2451
	public StudentInfoMenuScript StudentInfoMenu;

	// Token: 0x04000994 RID: 2452
	public InputManagerScript InputManager;

	// Token: 0x04000995 RID: 2453
	public PauseScreenScript PauseScreen;

	// Token: 0x04000996 RID: 2454
	public PromptBarScript PromptBar;

	// Token: 0x04000997 RID: 2455
	public HomeYandereScript HomeYandere;

	// Token: 0x04000998 RID: 2456
	public HomeCameraScript HomeCamera;

	// Token: 0x04000999 RID: 2457
	public HomeWindowScript HomeWindow;

	// Token: 0x0400099A RID: 2458
	public UILabel YanderePostLabel;

	// Token: 0x0400099B RID: 2459
	public UILabel AcceptLabel;

	// Token: 0x0400099C RID: 2460
	public GameObject InternetPrompts;

	// Token: 0x0400099D RID: 2461
	public GameObject NewPostText;

	// Token: 0x0400099E RID: 2462
	public GameObject ChangeLabel;

	// Token: 0x0400099F RID: 2463
	public GameObject ChangeIcon;

	// Token: 0x040009A0 RID: 2464
	public GameObject WriteLabel;

	// Token: 0x040009A1 RID: 2465
	public GameObject WriteIcon;

	// Token: 0x040009A2 RID: 2466
	public GameObject PostLabel;

	// Token: 0x040009A3 RID: 2467
	public GameObject PostIcon;

	// Token: 0x040009A4 RID: 2468
	public GameObject BG;

	// Token: 0x040009A5 RID: 2469
	public Transform MenuHighlight;

	// Token: 0x040009A6 RID: 2470
	public Transform StudentPost1;

	// Token: 0x040009A7 RID: 2471
	public Transform StudentPost2;

	// Token: 0x040009A8 RID: 2472
	public Transform YandereReply;

	// Token: 0x040009A9 RID: 2473
	public Transform YanderePost;

	// Token: 0x040009AA RID: 2474
	public Transform LameReply;

	// Token: 0x040009AB RID: 2475
	public Transform NewPost;

	// Token: 0x040009AC RID: 2476
	public Transform Menu;

	// Token: 0x040009AD RID: 2477
	public Transform[] StudentReplies;

	// Token: 0x040009AE RID: 2478
	public UISprite[] Highlights;

	// Token: 0x040009AF RID: 2479
	public UILabel[] PostLabels;

	// Token: 0x040009B0 RID: 2480
	public UILabel[] MenuLabels;

	// Token: 0x040009B1 RID: 2481
	public string[] Locations;

	// Token: 0x040009B2 RID: 2482
	public string[] Actions;

	// Token: 0x040009B3 RID: 2483
	public bool PostSequence;

	// Token: 0x040009B4 RID: 2484
	public bool WritingPost;

	// Token: 0x040009B5 RID: 2485
	public bool ShowMenu;

	// Token: 0x040009B6 RID: 2486
	public bool FadeOut;

	// Token: 0x040009B7 RID: 2487
	public bool Success;

	// Token: 0x040009B8 RID: 2488
	public bool Posted;

	// Token: 0x040009B9 RID: 2489
	public int MenuSelected;

	// Token: 0x040009BA RID: 2490
	public int Selected;

	// Token: 0x040009BB RID: 2491
	public int ID;

	// Token: 0x040009BC RID: 2492
	public int Location;

	// Token: 0x040009BD RID: 2493
	public int Student;

	// Token: 0x040009BE RID: 2494
	public int Action;

	// Token: 0x040009BF RID: 2495
	public float Timer;
}
