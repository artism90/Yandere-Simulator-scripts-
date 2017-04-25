using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000080 RID: 128
[Serializable]
public class DialogueWheelScript : MonoBehaviour
{
	// Token: 0x06000310 RID: 784 RVA: 0x0003E948 File Offset: 0x0003CB48
	public virtual void Start()
	{
		this.Interaction.localScale = new Vector3((float)1, (float)1, (float)1);
		this.Favors.localScale = new Vector3((float)0, (float)0, (float)0);
		this.Club.localScale = new Vector3((float)0, (float)0, (float)0);
		this.Love.localScale = new Vector3((float)0, (float)0, (float)0);
		this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
	}

	// Token: 0x06000311 RID: 785 RVA: 0x0003E9C4 File Offset: 0x0003CBC4
	public virtual void Update()
	{
		if (!this.Show)
		{
			if (this.transform.localScale.x > 0.1f)
			{
				this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			}
			else if (this.Panel.enabled)
			{
				this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
				this.Panel.enabled = false;
			}
		}
		else
		{
			if (this.ClubLeader)
			{
				this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.Club.localScale = Vector3.Lerp(this.Club.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.Love.localScale = Vector3.Lerp(this.Love.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			}
			else if (this.AskingFavor)
			{
				this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.Club.localScale = Vector3.Lerp(this.Club.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.Love.localScale = Vector3.Lerp(this.Love.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			}
			else if (this.Matchmaking)
			{
				this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.Club.localScale = Vector3.Lerp(this.Club.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.Love.localScale = Vector3.Lerp(this.Love.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			}
			else
			{
				this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.Club.localScale = Vector3.Lerp(this.Club.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.Love.localScale = Vector3.Lerp(this.Love.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			}
			this.MouseDelta.x = this.MouseDelta.x + Input.GetAxis("Mouse X");
			this.MouseDelta.y = this.MouseDelta.y + Input.GetAxis("Mouse Y");
			if (this.MouseDelta.x > (float)11)
			{
				this.MouseDelta.x = (float)11;
			}
			else if (this.MouseDelta.x < (float)-11)
			{
				this.MouseDelta.x = (float)-11;
			}
			if (this.MouseDelta.y > (float)11)
			{
				this.MouseDelta.y = (float)11;
			}
			else if (this.MouseDelta.y < (float)-11)
			{
				this.MouseDelta.y = (float)-11;
			}
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			if (!this.AskingFavor && !this.Matchmaking)
			{
				if (Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f)
				{
					this.Selected = 0;
				}
				if ((Input.GetAxis("Vertical") > 0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y > (float)10 && this.MouseDelta.x < (float)10 && this.MouseDelta.x > (float)-10))
				{
					this.Selected = 1;
				}
				if ((Input.GetAxis("Vertical") > (float)0 && Input.GetAxis("Horizontal") > 0.5f) || (this.MouseDelta.y > (float)0 && this.MouseDelta.x > (float)10))
				{
					this.Selected = 2;
				}
				if ((Input.GetAxis("Vertical") < (float)0 && Input.GetAxis("Horizontal") > 0.5f) || (this.MouseDelta.y < (float)0 && this.MouseDelta.x > (float)10))
				{
					this.Selected = 3;
				}
				if ((Input.GetAxis("Vertical") < -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y < (float)-10 && this.MouseDelta.x < (float)10 && this.MouseDelta.x > (float)-10))
				{
					this.Selected = 4;
				}
				if ((Input.GetAxis("Vertical") < (float)0 && Input.GetAxis("Horizontal") < -0.5f) || (this.MouseDelta.y < (float)0 && this.MouseDelta.x < (float)-10))
				{
					this.Selected = 5;
				}
				if ((Input.GetAxis("Vertical") > (float)0 && Input.GetAxis("Horizontal") < -0.5f) || (this.MouseDelta.y > (float)0 && this.MouseDelta.x < (float)-10))
				{
					this.Selected = 6;
				}
				if (!this.ClubLeader)
				{
					if (this.Selected == 5)
					{
						if (PlayerPrefs.GetInt(this.Yandere.TargetStudent.StudentID + "_Friend") == 0)
						{
							this.CenterLabel.text = this.Text[this.Selected];
						}
						else
						{
							this.CenterLabel.text = "Love";
						}
					}
					else
					{
						this.CenterLabel.text = this.Text[this.Selected];
					}
				}
				else
				{
					this.CenterLabel.text = this.ClubText[this.Selected];
				}
			}
			else
			{
				if (Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f)
				{
					this.Selected = 0;
				}
				if ((Input.GetAxis("Vertical") > 0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y > (float)10 && this.MouseDelta.x < (float)10 && this.MouseDelta.x > (float)-10))
				{
					this.Selected = 1;
				}
				if ((Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") > 0.5f) || (this.MouseDelta.y < (float)10 && this.MouseDelta.y > (float)-10 && this.MouseDelta.x > (float)10))
				{
					this.Selected = 2;
				}
				if ((Input.GetAxis("Vertical") < -0.5f && Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f) || (this.MouseDelta.y < (float)-10 && this.MouseDelta.x < (float)10 && this.MouseDelta.x > (float)-10))
				{
					this.Selected = 3;
				}
				if ((Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("Horizontal") < -0.5f) || (this.MouseDelta.y < (float)10 && this.MouseDelta.y > (float)-10 && this.MouseDelta.x < (float)-10))
				{
					this.Selected = 4;
				}
				if (this.AskingFavor)
				{
					if (this.Selected < this.FavorText.Length)
					{
						this.CenterLabel.text = this.FavorText[this.Selected];
					}
				}
				else if (this.Selected < this.FavorText.Length)
				{
					this.CenterLabel.text = this.LoveText[this.Selected];
				}
			}
			if (!this.ClubLeader)
			{
				for (int i = 1; i < 7; i++)
				{
					if (this.Selected == i)
					{
						this.Segment[i].transform.localScale = Vector3.Lerp(this.Segment[i].transform.localScale, new Vector3(1.3f, 1.3f, (float)1), Time.deltaTime * (float)10);
					}
					else
					{
						this.Segment[i].transform.localScale = Vector3.Lerp(this.Segment[i].transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
					}
				}
			}
			else
			{
				for (int i = 1; i < 7; i++)
				{
					if (this.Selected == i)
					{
						this.ClubSegment[i].transform.localScale = Vector3.Lerp(this.ClubSegment[i].transform.localScale, new Vector3(1.3f, 1.3f, (float)1), Time.deltaTime * (float)10);
					}
					else
					{
						this.ClubSegment[i].transform.localScale = Vector3.Lerp(this.ClubSegment[i].transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
					}
				}
			}
			if (!this.Matchmaking)
			{
				for (int i = 1; i < 5; i++)
				{
					if (this.Selected == i)
					{
						this.FavorSegment[i].transform.localScale = Vector3.Lerp(this.FavorSegment[i].transform.localScale, new Vector3(1.3f, 1.3f, (float)1), Time.deltaTime * (float)10);
					}
					else
					{
						this.FavorSegment[i].transform.localScale = Vector3.Lerp(this.FavorSegment[i].transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
					}
				}
			}
			else
			{
				for (int i = 1; i < 5; i++)
				{
					if (this.Selected == i)
					{
						this.LoveSegment[i].transform.localScale = Vector3.Lerp(this.LoveSegment[i].transform.localScale, new Vector3(1.3f, 1.3f, (float)1), Time.deltaTime * (float)10);
					}
					else
					{
						this.LoveSegment[i].transform.localScale = Vector3.Lerp(this.LoveSegment[i].transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
					}
				}
			}
			if (Input.GetButtonDown("A"))
			{
				if (this.ClubLeader)
				{
					if (this.Selected != 0 && this.ClubShadow[this.Selected].color.a == (float)0)
					{
						if (this.Selected == 1)
						{
							this.Impatience.fillAmount = (float)0;
							this.Yandere.TargetStudent.Interaction = 10;
							this.Yandere.TargetStudent.TalkTimer = (float)100;
							this.Yandere.TargetStudent.ClubPhase = 1;
							this.Show = false;
						}
						if (this.Selected == 2)
						{
							this.Impatience.fillAmount = (float)0;
							this.Yandere.TargetStudent.Interaction = 11;
							this.Yandere.TargetStudent.TalkTimer = (float)100;
							this.Show = false;
							this.ClubManager.CheckGrudge(this.Yandere.TargetStudent.Club);
							if (PlayerPrefs.GetInt("QuitClub_" + this.Yandere.TargetStudent.Club) == 1)
							{
								this.Yandere.TargetStudent.ClubPhase = 4;
							}
							else if (PlayerPrefs.GetInt("Club") != 0)
							{
								this.Yandere.TargetStudent.ClubPhase = 5;
							}
							else if (this.ClubManager.ClubGrudge)
							{
								this.Yandere.TargetStudent.ClubPhase = 6;
							}
							else
							{
								this.Yandere.TargetStudent.ClubPhase = 1;
							}
						}
						if (this.Selected == 3)
						{
							this.Impatience.fillAmount = (float)0;
							this.Yandere.TargetStudent.Interaction = 12;
							this.Yandere.TargetStudent.TalkTimer = (float)100;
							this.Yandere.TargetStudent.ClubPhase = 1;
							this.Show = false;
						}
						if (this.Selected == 4)
						{
							this.Impatience.fillAmount = (float)0;
							this.Yandere.TargetStudent.Interaction = 13;
							this.Yandere.TargetStudent.TalkTimer = this.Yandere.Subtitle.ClubFarewellClips[this.Yandere.TargetStudent.Club].length;
							this.Show = false;
						}
						if (this.Selected == 5)
						{
							this.Impatience.fillAmount = (float)0;
							this.Yandere.TargetStudent.Interaction = 14;
							this.Yandere.TargetStudent.TalkTimer = (float)100;
							if (this.Clock.HourTime < (float)17)
							{
								this.Yandere.TargetStudent.ClubPhase = 4;
							}
							else if (this.Clock.HourTime > 17.5f)
							{
								this.Yandere.TargetStudent.ClubPhase = 5;
							}
							else
							{
								this.Yandere.TargetStudent.ClubPhase = 1;
							}
							this.Show = false;
						}
						if (this.Selected == 6)
						{
						}
					}
				}
				else if (this.AskingFavor)
				{
					if (this.Selected != 0)
					{
						if (this.Selected < Extensions.get_length(this.FavorShadow) && this.FavorShadow[this.Selected] != null && this.FavorShadow[this.Selected].color.a == (float)0)
						{
							if (this.Selected == 1)
							{
								this.Impatience.fillAmount = (float)0;
								this.Yandere.Interaction = 6;
								this.Yandere.TalkTimer = (float)3;
								this.Show = false;
							}
							if (this.Selected == 2)
							{
								this.Impatience.fillAmount = (float)0;
								this.Yandere.Interaction = 7;
								this.Yandere.TalkTimer = (float)3;
								this.Show = false;
							}
							if (this.Selected == 4)
							{
								this.PauseScreen.StudentInfoMenu.Distracting = true;
								this.PauseScreen.StudentInfoMenu.gameObject.active = true;
								this.PauseScreen.StudentInfoMenu.Column = 0;
								this.PauseScreen.StudentInfoMenu.Row = 0;
								this.PauseScreen.StudentInfoMenu.UpdateHighlight();
								this.StartCoroutine_Auto(this.PauseScreen.StudentInfoMenu.UpdatePortraits());
								this.PauseScreen.MainMenu.active = false;
								this.PauseScreen.Panel.enabled = true;
								this.PauseScreen.Sideways = true;
								this.PauseScreen.Show = true;
								Time.timeScale = (float)0;
								this.PromptBar.ClearButtons();
								this.PromptBar.Label[1].text = "Cancel";
								this.PromptBar.UpdateButtons();
								this.PromptBar.Show = true;
								this.Impatience.fillAmount = (float)0;
								this.Yandere.Interaction = 8;
								this.Yandere.TalkTimer = (float)3;
								this.Show = false;
							}
						}
						if (this.Selected == 3)
						{
							this.AskingFavor = false;
						}
					}
				}
				else if (this.Matchmaking)
				{
					if (this.Selected != 0)
					{
						if (this.Selected < Extensions.get_length(this.LoveShadow) && this.LoveShadow[this.Selected] != null && this.LoveShadow[this.Selected].color.a == (float)0)
						{
							if (this.Selected == 1)
							{
								this.PromptBar.ClearButtons();
								this.PromptBar.Label[0].text = "Select";
								this.PromptBar.Label[4].text = "Change";
								this.PromptBar.UpdateButtons();
								this.PromptBar.Show = true;
								this.AppearanceWindow.gameObject.active = true;
								this.AppearanceWindow.Show = true;
								this.Show = false;
							}
							if (this.Selected == 2)
							{
								this.Impatience.fillAmount = (float)0;
								this.Yandere.Interaction = 19;
								this.Yandere.TalkTimer = (float)5;
								this.Show = false;
							}
							if (this.Selected == 4)
							{
								this.Impatience.fillAmount = (float)0;
								this.Yandere.Interaction = 20;
								this.Yandere.TalkTimer = (float)5;
								this.Show = false;
							}
						}
						if (this.Selected == 3)
						{
							this.Matchmaking = false;
						}
					}
				}
				else if (this.Selected != 0 && this.Shadow[this.Selected].color.a == (float)0)
				{
					if (this.Selected == 1)
					{
						this.Impatience.fillAmount = (float)0;
						this.Yandere.Interaction = 1;
						this.Yandere.TalkTimer = (float)3;
						this.Show = false;
					}
					if (this.Selected == 2)
					{
						this.Impatience.fillAmount = (float)0;
						this.Yandere.Interaction = 2;
						this.Yandere.TalkTimer = (float)3;
						this.Show = false;
					}
					if (this.Selected == 3)
					{
						this.PauseScreen.StudentInfoMenu.Gossiping = true;
						this.PauseScreen.StudentInfoMenu.gameObject.active = true;
						this.PauseScreen.StudentInfoMenu.Column = 0;
						this.PauseScreen.StudentInfoMenu.Row = 0;
						this.PauseScreen.StudentInfoMenu.UpdateHighlight();
						this.StartCoroutine_Auto(this.PauseScreen.StudentInfoMenu.UpdatePortraits());
						this.PauseScreen.MainMenu.active = false;
						this.PauseScreen.Panel.enabled = true;
						this.PauseScreen.Sideways = true;
						this.PauseScreen.Show = true;
						Time.timeScale = (float)0;
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "View Info";
						this.PromptBar.Label[1].text = "Cancel";
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
						this.Impatience.fillAmount = (float)0;
						this.Yandere.Interaction = 3;
						this.Yandere.TalkTimer = (float)3;
						this.Show = false;
					}
					if (this.Selected == 4)
					{
						this.Impatience.fillAmount = (float)0;
						this.Yandere.Interaction = 4;
						this.Yandere.TalkTimer = (float)2;
						this.Show = false;
					}
					if (this.Selected == 5)
					{
						if (PlayerPrefs.GetInt(this.Yandere.TargetStudent.StudentID + "_Friend") == 0)
						{
							this.CheckTaskCompletion();
							if (this.Yandere.TargetStudent.TaskPhase == 0)
							{
								this.Impatience.fillAmount = (float)0;
								this.Yandere.TargetStudent.Interaction = 5;
								this.Yandere.TargetStudent.TalkTimer = (float)100;
								this.Yandere.TargetStudent.TaskPhase = 1;
							}
							else
							{
								this.Impatience.fillAmount = (float)0;
								this.Yandere.TargetStudent.Interaction = 5;
								this.Yandere.TargetStudent.TalkTimer = (float)100;
							}
							this.Show = false;
						}
						else if (this.Yandere.LoveManager.SuitorProgress == 0)
						{
							this.PauseScreen.StudentInfoMenu.MatchMaking = true;
							this.PauseScreen.StudentInfoMenu.gameObject.active = true;
							this.PauseScreen.StudentInfoMenu.Column = 0;
							this.PauseScreen.StudentInfoMenu.Row = 0;
							this.PauseScreen.StudentInfoMenu.UpdateHighlight();
							this.StartCoroutine_Auto(this.PauseScreen.StudentInfoMenu.UpdatePortraits());
							this.PauseScreen.MainMenu.active = false;
							this.PauseScreen.Panel.enabled = true;
							this.PauseScreen.Sideways = true;
							this.PauseScreen.Show = true;
							Time.timeScale = (float)0;
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "View Info";
							this.PromptBar.Label[1].text = "Cancel";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
							this.Impatience.fillAmount = (float)0;
							this.Yandere.Interaction = 17;
							this.Yandere.TalkTimer = (float)3;
							this.Show = false;
						}
						else
						{
							this.Matchmaking = true;
						}
					}
					if (this.Selected == 6)
					{
						this.AskingFavor = true;
					}
				}
			}
		}
		this.PreviousPosition = Input.mousePosition;
	}

	// Token: 0x06000312 RID: 786 RVA: 0x0004022C File Offset: 0x0003E42C
	public virtual void HideShadows()
	{
		if (PlayerPrefs.GetInt(this.Yandere.TargetStudent.StudentID + "_Friend") == 1)
		{
			this.TaskIcon.spriteName = "Heart";
		}
		else
		{
			this.TaskIcon.spriteName = "Task";
		}
		this.Impatience.fillAmount = (float)0;
		for (int i = 1; i < 7; i++)
		{
			int num = 0;
			Color color = this.Shadow[i].color;
			float num2 = color.a = (float)num;
			Color color2 = this.Shadow[i].color = color;
		}
		for (int i = 1; i < 5; i++)
		{
			int num3 = 0;
			Color color3 = this.FavorShadow[i].color;
			float num4 = color3.a = (float)num3;
			Color color4 = this.FavorShadow[i].color = color3;
		}
		for (int i = 1; i < 7; i++)
		{
			int num5 = 0;
			Color color5 = this.ClubShadow[i].color;
			float num6 = color5.a = (float)num5;
			Color color6 = this.ClubShadow[i].color = color5;
		}
		for (int i = 1; i < 5; i++)
		{
			int num7 = 0;
			Color color7 = this.LoveShadow[i].color;
			float num8 = color7.a = (float)num7;
			Color color8 = this.LoveShadow[i].color = color7;
		}
		if (!this.Yandere.TargetStudent.Witness || this.Yandere.TargetStudent.Forgave)
		{
			float a = 0.75f;
			Color color9 = this.Shadow[1].color;
			float num9 = color9.a = a;
			Color color10 = this.Shadow[1].color = color9;
		}
		if (this.Yandere.TargetStudent.Complimented)
		{
			float a2 = 0.75f;
			Color color11 = this.Shadow[2].color;
			float num10 = color11.a = a2;
			Color color12 = this.Shadow[2].color = color11;
		}
		if (this.Yandere.TargetStudent.Gossiped)
		{
			float a3 = 0.75f;
			Color color13 = this.Shadow[3].color;
			float num11 = color13.a = a3;
			Color color14 = this.Shadow[3].color = color13;
		}
		if (this.Yandere.Bloodiness > (float)0 || this.Yandere.Sanity < 33.33333f)
		{
			float a4 = 0.75f;
			Color color15 = this.Shadow[3].color;
			float num12 = color15.a = a4;
			Color color16 = this.Shadow[3].color = color15;
			float a5 = 0.75f;
			Color color17 = this.Shadow[5].color;
			float num13 = color17.a = a5;
			Color color18 = this.Shadow[5].color = color17;
			float a6 = 0.75f;
			Color color19 = this.Shadow[6].color;
			float num14 = color19.a = a6;
			Color color20 = this.Shadow[6].color = color19;
		}
		else if (this.Reputation.Reputation < -33.33333f)
		{
			float a7 = 0.75f;
			Color color21 = this.Shadow[3].color;
			float num15 = color21.a = a7;
			Color color22 = this.Shadow[3].color = color21;
		}
		if (PlayerPrefs.GetInt(this.Yandere.TargetStudent.StudentID + "_Friend") == 0)
		{
			if (this.Yandere.TargetStudent.StudentID != 6 && this.Yandere.TargetStudent.StudentID != 7 && this.Yandere.TargetStudent.StudentID != 13 && this.Yandere.TargetStudent.StudentID != 14 && this.Yandere.TargetStudent.StudentID != 15 && this.Yandere.TargetStudent.StudentID != 32 && this.Yandere.TargetStudent.StudentID != 33)
			{
				float a8 = 0.75f;
				Color color23 = this.Shadow[5].color;
				float num16 = color23.a = a8;
				Color color24 = this.Shadow[5].color = color23;
			}
			else
			{
				if (this.Yandere.TargetStudent.TaskPhase > 0 && this.Yandere.TargetStudent.TaskPhase < 5)
				{
					float a9 = 0.75f;
					Color color25 = this.Shadow[5].color;
					float num17 = color25.a = a9;
					Color color26 = this.Shadow[5].color = color25;
				}
				if (this.Yandere.TargetStudent.StudentID == 32)
				{
					if (this.Clock.Period != 3)
					{
						float a10 = 0.75f;
						Color color27 = this.Shadow[5].color;
						float num18 = color27.a = a10;
						Color color28 = this.Shadow[5].color = color27;
					}
					else if (PlayerPrefs.GetInt("Task_32_Status") == 1 && this.Yandere.Inventory.Cigs)
					{
						int num19 = 0;
						Color color29 = this.Shadow[5].color;
						float num20 = color29.a = (float)num19;
						Color color30 = this.Shadow[5].color = color29;
					}
				}
			}
		}
		else if (this.Yandere.TargetStudent.StudentID != 7 && this.Yandere.TargetStudent.StudentID != 13)
		{
			float a11 = 0.75f;
			Color color31 = this.Shadow[5].color;
			float num21 = color31.a = a11;
			Color color32 = this.Shadow[5].color = color31;
		}
		else if (!this.Yandere.TargetStudent.Male && this.LoveManager.SuitorProgress == 0)
		{
			float a12 = 0.75f;
			Color color33 = this.Shadow[5].color;
			float num22 = color33.a = a12;
			Color color34 = this.Shadow[5].color = color33;
		}
		if (PlayerPrefs.GetInt(this.Yandere.TargetStudent.StudentID + "_Friend") == 0)
		{
			float a13 = 0.75f;
			Color color35 = this.Shadow[6].color;
			float num23 = color35.a = a13;
			Color color36 = this.Shadow[6].color = color35;
		}
		if ((this.Yandere.TargetStudent.Male && PlayerPrefs.GetInt("Seduction") + PlayerPrefs.GetInt("SeductionBonus") > 3) || PlayerPrefs.GetInt("Seduction") + PlayerPrefs.GetInt("SeductionBonus") > 4)
		{
			int num24 = 0;
			Color color37 = this.Shadow[6].color;
			float num25 = color37.a = (float)num24;
			Color color38 = this.Shadow[6].color = color37;
		}
		float a14 = 0.75f;
		Color color39 = this.ClubShadow[6].color;
		float num26 = color39.a = a14;
		Color color40 = this.ClubShadow[6].color = color39;
		if (PlayerPrefs.GetInt("Club") == this.Yandere.TargetStudent.Club)
		{
			float a15 = 0.75f;
			Color color41 = this.ClubShadow[1].color;
			float num27 = color41.a = a15;
			Color color42 = this.ClubShadow[1].color = color41;
			float a16 = 0.75f;
			Color color43 = this.ClubShadow[2].color;
			float num28 = color43.a = a16;
			Color color44 = this.ClubShadow[2].color = color43;
		}
		if (this.Yandere.ClubAttire || this.Yandere.Mask != null || this.Yandere.Gloves != null || this.Yandere.Container != null)
		{
			float a17 = 0.75f;
			Color color45 = this.ClubShadow[3].color;
			float num29 = color45.a = a17;
			Color color46 = this.ClubShadow[3].color = color45;
		}
		if (PlayerPrefs.GetInt("Club") != this.Yandere.TargetStudent.Club)
		{
			float a18 = 0.75f;
			Color color47 = this.ClubShadow[3].color;
			float num30 = color47.a = a18;
			Color color48 = this.ClubShadow[3].color = color47;
			float a19 = 0.75f;
			Color color49 = this.ClubShadow[5].color;
			float num31 = color49.a = a19;
			Color color50 = this.ClubShadow[5].color = color49;
		}
		if (this.Yandere.Followers > 0)
		{
			float a20 = 0.75f;
			Color color51 = this.FavorShadow[1].color;
			float num32 = color51.a = a20;
			Color color52 = this.FavorShadow[1].color = color51;
		}
		if (this.Yandere.TargetStudent.DistanceToDestination > 0.5f)
		{
			float a21 = 0.75f;
			Color color53 = this.FavorShadow[2].color;
			float num33 = color53.a = a21;
			Color color54 = this.FavorShadow[2].color = color53;
		}
		if (!this.Yandere.TargetStudent.Male)
		{
			float a22 = 0.75f;
			Color color55 = this.LoveShadow[1].color;
			float num34 = color55.a = a22;
			Color color56 = this.LoveShadow[1].color = color55;
		}
		if (this.DatingMinigame == null || !this.Yandere.Inventory.Headset || (this.Yandere.TargetStudent.Male && !this.LoveManager.RivalWaiting) || this.LoveManager.Courted)
		{
			float a23 = 0.75f;
			Color color57 = this.LoveShadow[2].color;
			float num35 = color57.a = a23;
			Color color58 = this.LoveShadow[2].color = color57;
		}
		if (!this.Yandere.TargetStudent.Male || !this.Yandere.Inventory.Rose || this.Yandere.TargetStudent.Rose)
		{
			float a24 = 0.75f;
			Color color59 = this.LoveShadow[4].color;
			float num36 = color59.a = a24;
			Color color60 = this.LoveShadow[4].color = color59;
		}
	}

	// Token: 0x06000313 RID: 787 RVA: 0x00040E2C File Offset: 0x0003F02C
	public virtual void CheckTaskCompletion()
	{
		if (PlayerPrefs.GetInt("Task_" + this.Yandere.TargetStudent.StudentID + "_Status") == 2 && this.Yandere.TargetStudent.StudentID == 32)
		{
			this.Yandere.Inventory.Cigs = false;
		}
	}

	// Token: 0x06000314 RID: 788 RVA: 0x00040E98 File Offset: 0x0003F098
	public virtual void End()
	{
		if (this.Yandere.TargetStudent != null)
		{
			this.Yandere.TargetStudent.Interaction = 0;
			this.Yandere.TargetStudent.WaitTimer = (float)1;
			if (this.Yandere.TargetStudent.enabled)
			{
				this.Yandere.TargetStudent.CurrentDestination = this.Yandere.TargetStudent.Destinations[this.Yandere.TargetStudent.Phase];
				this.Yandere.TargetStudent.Pathfinding.target = this.Yandere.TargetStudent.Destinations[this.Yandere.TargetStudent.Phase];
			}
			this.Yandere.TargetStudent.ShoulderCamera.OverShoulder = false;
			this.Yandere.TargetStudent.Waiting = true;
			this.Yandere.TargetStudent = null;
		}
		this.Yandere.Subtitle.Label.text = string.Empty;
		this.AskingFavor = false;
		this.Matchmaking = false;
		this.ClubLeader = false;
		this.Show = false;
	}

	// Token: 0x06000315 RID: 789 RVA: 0x00040FC4 File Offset: 0x0003F1C4
	public virtual void Main()
	{
	}

	// Token: 0x040007AF RID: 1967
	public AppearanceWindowScript AppearanceWindow;

	// Token: 0x040007B0 RID: 1968
	public ClubManagerScript ClubManager;

	// Token: 0x040007B1 RID: 1969
	public PauseScreenScript PauseScreen;

	// Token: 0x040007B2 RID: 1970
	public LoveManagerScript LoveManager;

	// Token: 0x040007B3 RID: 1971
	public ReputationScript Reputation;

	// Token: 0x040007B4 RID: 1972
	public ClubWindowScript ClubWindow;

	// Token: 0x040007B5 RID: 1973
	public TaskWindowScript TaskWindow;

	// Token: 0x040007B6 RID: 1974
	public PromptBarScript PromptBar;

	// Token: 0x040007B7 RID: 1975
	public YandereScript Yandere;

	// Token: 0x040007B8 RID: 1976
	public ClockScript Clock;

	// Token: 0x040007B9 RID: 1977
	public UIPanel Panel;

	// Token: 0x040007BA RID: 1978
	public GameObject DatingMinigame;

	// Token: 0x040007BB RID: 1979
	public Transform Interaction;

	// Token: 0x040007BC RID: 1980
	public Transform Favors;

	// Token: 0x040007BD RID: 1981
	public Transform Club;

	// Token: 0x040007BE RID: 1982
	public Transform Love;

	// Token: 0x040007BF RID: 1983
	public UISprite TaskIcon;

	// Token: 0x040007C0 RID: 1984
	public UISprite Impatience;

	// Token: 0x040007C1 RID: 1985
	public UILabel CenterLabel;

	// Token: 0x040007C2 RID: 1986
	public UISprite[] Segment;

	// Token: 0x040007C3 RID: 1987
	public UISprite[] Shadow;

	// Token: 0x040007C4 RID: 1988
	public string[] Text;

	// Token: 0x040007C5 RID: 1989
	public UISprite[] FavorSegment;

	// Token: 0x040007C6 RID: 1990
	public UISprite[] FavorShadow;

	// Token: 0x040007C7 RID: 1991
	public UISprite[] ClubSegment;

	// Token: 0x040007C8 RID: 1992
	public UISprite[] ClubShadow;

	// Token: 0x040007C9 RID: 1993
	public UISprite[] LoveSegment;

	// Token: 0x040007CA RID: 1994
	public UISprite[] LoveShadow;

	// Token: 0x040007CB RID: 1995
	public string[] FavorText;

	// Token: 0x040007CC RID: 1996
	public string[] ClubText;

	// Token: 0x040007CD RID: 1997
	public string[] LoveText;

	// Token: 0x040007CE RID: 1998
	public int Selected;

	// Token: 0x040007CF RID: 1999
	public int Victim;

	// Token: 0x040007D0 RID: 2000
	public bool AskingFavor;

	// Token: 0x040007D1 RID: 2001
	public bool Matchmaking;

	// Token: 0x040007D2 RID: 2002
	public bool ClubLeader;

	// Token: 0x040007D3 RID: 2003
	public bool Show;

	// Token: 0x040007D4 RID: 2004
	public Vector3 PreviousPosition;

	// Token: 0x040007D5 RID: 2005
	public Vector2 MouseDelta;
}
