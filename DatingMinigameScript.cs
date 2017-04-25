using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000076 RID: 118
[Serializable]
public class DatingMinigameScript : MonoBehaviour
{
	// Token: 0x060002DB RID: 731 RVA: 0x000387DC File Offset: 0x000369DC
	public DatingMinigameScript()
	{
		this.ComplimentSelected = 1;
		this.TraitSelected = 1;
		this.TopicSelected = 1;
		this.GiftSelected = 1;
		this.Selected = 1;
		this.Phase = 1;
		this.GiftColumn = 1;
		this.GiftRow = 1;
		this.Column = 1;
		this.Row = 1;
		this.Side = 1;
		this.Line = 1;
		this.CurrentAnim = string.Empty;
	}

	// Token: 0x060002DC RID: 732 RVA: 0x00038850 File Offset: 0x00036A50
	public virtual void Start()
	{
		this.Affection = PlayerPrefs.GetFloat("Affection");
		float x = this.Affection / 100f;
		Vector3 localScale = this.AffectionBar.localScale;
		float num = localScale.x = x;
		Vector3 vector = this.AffectionBar.localScale = localScale;
		this.CalculateAffection();
		this.OriginalColor = this.ComplimentBGs[1].color;
		this.ComplimentSet.localScale = new Vector3((float)0, (float)0, (float)0);
		this.GiveGift.localScale = new Vector3((float)0, (float)0, (float)0);
		this.ShowOff.localScale = new Vector3((float)0, (float)0, (float)0);
		this.Topics.localScale = new Vector3((float)0, (float)0, (float)0);
		this.DatingSimHUD.active = false;
		this.DatingSimHUD.alpha = (float)0;
		for (int i = 1; i < 26; i++)
		{
			if (PlayerPrefs.GetInt("Topic_" + i + "_Discussed") == 1)
			{
				float a = 0.5f;
				Color color = this.TopicIcons[i].color;
				float num2 = color.a = a;
				Color color2 = this.TopicIcons[i].color = color;
			}
		}
		for (int i = 1; i < 11; i++)
		{
			if (PlayerPrefs.GetInt("Compliment_" + i + "_Given") == 1)
			{
				float a2 = 0.5f;
				Color color3 = this.ComplimentLabels[i].color;
				float num3 = color3.a = a2;
				Color color4 = this.ComplimentLabels[i].color = color3;
			}
		}
		this.UpdateComplimentHighlight();
		this.UpdateTraitHighlight();
		this.UpdateGiftHighlight();
	}

	// Token: 0x060002DD RID: 733 RVA: 0x00038A30 File Offset: 0x00036C30
	public virtual void CalculateAffection()
	{
		if (this.Affection == (float)0)
		{
			this.AffectionLevel = 0;
		}
		else if (this.Affection < (float)25)
		{
			this.AffectionLevel = 1;
		}
		else if (this.Affection < (float)50)
		{
			this.AffectionLevel = 2;
		}
		else if (this.Affection < (float)75)
		{
			this.AffectionLevel = 3;
		}
		else if (this.Affection < (float)100)
		{
			this.AffectionLevel = 4;
		}
		else
		{
			this.AffectionLevel = 5;
		}
	}

	// Token: 0x060002DE RID: 734 RVA: 0x00038AC8 File Offset: 0x00036CC8
	public virtual void Update()
	{
		if (this.Testing)
		{
			this.Prompt.enabled = true;
		}
		else if (this.LoveManager.RivalWaiting)
		{
			if (this.Rival == null)
			{
				this.Suitor = this.StudentManager.Students[13];
				this.Rival = this.StudentManager.Students[7];
			}
			if (this.Rival.MeetTimer > (float)0 && this.Suitor.MeetTimer > (float)0)
			{
				this.Prompt.enabled = true;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Suitor.enabled = false;
			this.Rival.enabled = false;
			this.Rival.Character.animation["f02_smile_00"].layer = 1;
			this.Rival.Character.animation.Play("f02_smile_00");
			this.Rival.Character.animation["f02_smile_00"].weight = (float)0;
			this.StudentManager.Clock.StopTime = true;
			this.Yandere.RPGCamera.enabled = false;
			this.HeartbeatCamera.active = false;
			this.Yandere.Headset.active = true;
			this.Yandere.CanMove = false;
			this.Yandere.transform.position = this.PeekSpot.position;
			this.Yandere.transform.eulerAngles = this.PeekSpot.eulerAngles;
			this.Yandere.Character.animation.Play("f02_treePeeking_00");
			Camera.main.transform.position = new Vector3((float)48, (float)3, (float)-44);
			Camera.main.transform.eulerAngles = new Vector3((float)15, (float)90, (float)0);
			this.WisdomLabel.text = "Wisdom: " + PlayerPrefs.GetInt("SuitorTrait2");
			if (!this.Suitor.Rose)
			{
				this.RoseIcon.enabled = false;
			}
			this.Matchmaking = true;
			this.UpdateTopics();
		}
		if (this.Matchmaking)
		{
			if (this.CurrentAnim != string.Empty && this.Rival.Character.animation[this.CurrentAnim].time >= this.Rival.Character.animation[this.CurrentAnim].length)
			{
				this.Rival.Character.animation.Play(this.Rival.IdleAnim);
			}
			if (this.Phase == 1)
			{
				this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, (float)0, Time.deltaTime);
				this.Timer += Time.deltaTime;
				Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3((float)54, 1.25f, -45.25f), this.Timer * 0.02f);
				Camera.main.transform.eulerAngles = Vector3.Lerp(Camera.main.transform.eulerAngles, new Vector3((float)0, (float)45, (float)0), this.Timer * 0.02f);
				if (this.Timer > (float)5)
				{
					this.Suitor.Character.animation.Play("insertEarpiece_00");
					this.Suitor.Character.animation["insertEarpiece_00"].time = (float)0;
					this.Suitor.Character.animation.Play("insertEarpiece_00");
					this.Suitor.Earpiece.active = true;
					Camera.main.transform.position = new Vector3(45.5f, 1.25f, -44.5f);
					Camera.main.transform.eulerAngles = new Vector3((float)0, (float)-45, (float)0);
					this.Rotation = (float)-45;
					this.Timer = (float)0;
					this.Phase++;
				}
			}
			else if (this.Phase == 2)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)4)
				{
					this.Suitor.Earpiece.transform.parent = this.Suitor.Head;
					this.Suitor.Earpiece.transform.localPosition = new Vector3((float)0, -1.12f, 1.14f);
					this.Suitor.Earpiece.transform.localEulerAngles = new Vector3((float)45, (float)-180, (float)0);
					Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(45.11f, 1.375f, (float)-44), (this.Timer - (float)4) * 0.02f);
					this.Rotation = Mathf.Lerp(this.Rotation, (float)90, (this.Timer - (float)4) * 0.02f);
					float rotation = this.Rotation;
					Vector3 eulerAngles = Camera.main.transform.eulerAngles;
					float num = eulerAngles.y = rotation;
					Vector3 vector = Camera.main.transform.eulerAngles = eulerAngles;
					if (this.Rotation > 89.9f)
					{
						this.Rival.Character.animation["f02_turnAround_00"].time = (float)0;
						this.Rival.Character.animation.CrossFade("f02_turnAround_00");
						float x = this.Affection / (float)100;
						Vector3 localScale = this.AffectionBar.localScale;
						float num2 = localScale.x = x;
						Vector3 vector2 = this.AffectionBar.localScale = localScale;
						this.DialogueLabel.text = this.Greetings[this.AffectionLevel];
						this.CalculateMultiplier();
						this.DatingSimHUD.active = true;
						this.Timer = (float)0;
						this.Phase++;
					}
				}
			}
			else if (this.Phase == 3)
			{
				this.DatingSimHUD.alpha = Mathf.MoveTowards(this.DatingSimHUD.alpha, (float)1, Time.deltaTime);
				if (this.Rival.Character.animation["f02_turnAround_00"].time >= this.Rival.Character.animation["f02_turnAround_00"].length)
				{
					int num3 = -90;
					Vector3 eulerAngles2 = this.Rival.transform.eulerAngles;
					float num4 = eulerAngles2.y = (float)num3;
					Vector3 vector3 = this.Rival.transform.eulerAngles = eulerAngles2;
					this.Rival.Character.animation.Play("f02_turnAround_00");
					this.Rival.Character.animation["f02_turnAround_00"].time = (float)0;
					this.Rival.Character.animation["f02_turnAround_00"].speed = (float)0;
					this.Rival.Character.animation.Play("f02_turnAround_00");
					this.Rival.Character.animation.CrossFade(this.Rival.IdleAnim);
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Confirm";
					this.PromptBar.Label[1].text = "Back";
					this.PromptBar.Label[4].text = "Select";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				if (this.AffectionGrow)
				{
					this.Affection = Mathf.MoveTowards(this.Affection, (float)100, Time.deltaTime * (float)10);
					this.CalculateAffection();
				}
				this.Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", this.Affection * 0.01f);
				this.Rival.CharacterAnimation["f02_smile_00"].weight = this.Affection * 0.01f;
				float y = Mathf.Lerp(this.Highlight.localPosition.y, this.HighlightTarget, Time.deltaTime * (float)10);
				Vector3 localPosition = this.Highlight.localPosition;
				float num5 = localPosition.y = y;
				Vector3 vector4 = this.Highlight.localPosition = localPosition;
				for (int i = 1; i < Extensions.get_length(this.Options); i++)
				{
					if (i == this.Selected)
					{
						float x2 = Mathf.Lerp(this.Options[i].localPosition.x, (float)750, Time.deltaTime * (float)10);
						Vector3 localPosition2 = this.Options[i].localPosition;
						float num6 = localPosition2.x = x2;
						Vector3 vector5 = this.Options[i].localPosition = localPosition2;
					}
					else
					{
						float x3 = Mathf.Lerp(this.Options[i].localPosition.x, (float)800, Time.deltaTime * (float)10);
						Vector3 localPosition3 = this.Options[i].localPosition;
						float num7 = localPosition3.x = x3;
						Vector3 vector6 = this.Options[i].localPosition = localPosition3;
					}
				}
				float x4 = Mathf.Lerp(this.AffectionBar.localScale.x, this.Affection / 100f, Time.deltaTime * (float)10);
				Vector3 localScale2 = this.AffectionBar.localScale;
				float num8 = localScale2.x = x4;
				Vector3 vector7 = this.AffectionBar.localScale = localScale2;
				if (!this.SelectingTopic && !this.Complimenting && !this.ShowingOff && !this.GivingGift)
				{
					this.Topics.localScale = Vector3.Lerp(this.Topics.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
					this.ComplimentSet.localScale = Vector3.Lerp(this.ComplimentSet.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
					this.ShowOff.localScale = Vector3.Lerp(this.ShowOff.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
					this.GiveGift.localScale = Vector3.Lerp(this.GiveGift.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
					if (this.InputManager.TappedUp)
					{
						this.Selected--;
						this.UpdateHighlight();
					}
					if (this.InputManager.TappedDown)
					{
						this.Selected++;
						this.UpdateHighlight();
					}
					if (Input.GetButtonDown("A") && this.Labels[this.Selected].color.a == (float)1)
					{
						if (this.Selected == 1)
						{
							this.SelectingTopic = true;
							this.Negative = true;
						}
						else if (this.Selected == 2)
						{
							this.SelectingTopic = true;
							this.Negative = false;
						}
						else if (this.Selected == 3)
						{
							this.Complimenting = true;
						}
						else if (this.Selected == 4)
						{
							this.ShowingOff = true;
						}
						else if (this.Selected == 5)
						{
							this.GivingGift = true;
						}
						else if (this.Selected == 6)
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Confirm";
							this.PromptBar.UpdateButtons();
							this.CalculateAffection();
							this.DialogueLabel.text = this.Farewells[this.AffectionLevel];
							this.Phase++;
						}
					}
				}
				else if (this.SelectingTopic)
				{
					this.Topics.localScale = Vector3.Lerp(this.Topics.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
					if (this.InputManager.TappedUp)
					{
						this.Row--;
						this.UpdateTopicHighlight();
					}
					else if (this.InputManager.TappedDown)
					{
						this.Row++;
						this.UpdateTopicHighlight();
					}
					if (this.InputManager.TappedLeft)
					{
						this.Column--;
						this.UpdateTopicHighlight();
					}
					else if (this.InputManager.TappedRight)
					{
						this.Column++;
						this.UpdateTopicHighlight();
					}
					if (Input.GetButtonDown("A") && this.TopicIcons[this.TopicSelected].color.a == (float)1)
					{
						this.SelectingTopic = false;
						float a = 0.5f;
						Color color = this.TopicIcons[this.TopicSelected].color;
						float num9 = color.a = a;
						Color color2 = this.TopicIcons[this.TopicSelected].color = color;
						PlayerPrefs.SetInt("Topic_" + this.TopicSelected + "_Discussed", 1);
						this.DetermineOpinion();
						if (PlayerPrefs.GetInt("Topic_" + this.Opinion + "_Student_7_Learned") == 0)
						{
							PlayerPrefs.SetInt("Topic_" + this.Opinion + "_Student_7_Learned", 1);
						}
						if (this.Negative)
						{
							float a2 = 0.5f;
							Color color3 = this.Labels[1].color;
							float num10 = color3.a = a2;
							Color color4 = this.Labels[1].color = color3;
							if (this.Opinion == 2)
							{
								this.DialogueLabel.text = "Hey! Just so you know, I take offense to that...";
								this.Rival.Character.animation.CrossFade("f02_refuse_00");
								this.CurrentAnim = "f02_refuse_00";
								this.Affection -= (float)1;
								this.CalculateAffection();
							}
							else if (this.Opinion == 1)
							{
								this.DialogueLabel.text = this.Negatives[this.AffectionLevel];
								this.Rival.Character.animation.CrossFade("f02_lookdown_00");
								this.CurrentAnim = "f02_lookdown_00";
								this.Affection += (float)this.Multiplier;
								this.CalculateAffection();
							}
							else if (this.Opinion == 0)
							{
								this.DialogueLabel.text = "Um...okay.";
							}
						}
						else
						{
							float a3 = 0.5f;
							Color color5 = this.Labels[2].color;
							float num11 = color5.a = a3;
							Color color6 = this.Labels[2].color = color5;
							if (this.Opinion == 2)
							{
								this.DialogueLabel.text = this.Positives[this.AffectionLevel];
								this.Rival.Character.animation.CrossFade("f02_lookdown_00");
								this.CurrentAnim = "f02_lookdown_00";
								this.Affection += (float)this.Multiplier;
								this.CalculateAffection();
							}
							else if (this.Opinion == 1)
							{
								this.DialogueLabel.text = "To be honest with you, I strongly disagree...";
								this.Rival.Character.animation.CrossFade("f02_refuse_00");
								this.CurrentAnim = "f02_refuse_00";
								this.Affection -= (float)1;
								this.CalculateAffection();
							}
							else if (this.Opinion == 0)
							{
								this.DialogueLabel.text = "Um...all right.";
							}
						}
						if (this.Affection > (float)100)
						{
							this.Affection = (float)100;
						}
						else if (this.Affection < (float)0)
						{
							this.Affection = (float)0;
						}
					}
					if (Input.GetButtonDown("B"))
					{
						this.SelectingTopic = false;
					}
				}
				else if (this.Complimenting)
				{
					this.ComplimentSet.localScale = Vector3.Lerp(this.ComplimentSet.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
					if (this.InputManager.TappedUp)
					{
						this.Line--;
						this.UpdateComplimentHighlight();
					}
					else if (this.InputManager.TappedDown)
					{
						this.Line++;
						this.UpdateComplimentHighlight();
					}
					if (this.InputManager.TappedLeft)
					{
						this.Side--;
						this.UpdateComplimentHighlight();
					}
					else if (this.InputManager.TappedRight)
					{
						this.Side++;
						this.UpdateComplimentHighlight();
					}
					if (Input.GetButtonDown("A") && this.ComplimentLabels[this.ComplimentSelected].color.a == (float)1)
					{
						float a4 = 0.5f;
						Color color7 = this.Labels[3].color;
						float num12 = color7.a = a4;
						Color color8 = this.Labels[3].color = color7;
						this.Complimenting = false;
						this.DialogueLabel.text = this.Compliments[this.ComplimentSelected];
						PlayerPrefs.SetInt("Compliment_" + this.ComplimentSelected + "_Given", 1);
						if (this.ComplimentSelected == 1 || this.ComplimentSelected == 4 || this.ComplimentSelected == 5 || this.ComplimentSelected == 8 || this.ComplimentSelected == 9)
						{
							this.Rival.Character.animation.CrossFade("f02_lookdown_00");
							this.CurrentAnim = "f02_lookdown_00";
							this.Affection += (float)this.Multiplier;
							this.CalculateAffection();
						}
						else
						{
							this.Rival.Character.animation.CrossFade("f02_refuse_00");
							this.CurrentAnim = "f02_refuse_00";
							this.Affection -= (float)1;
							this.CalculateAffection();
						}
						if (this.Affection > (float)100)
						{
							this.Affection = (float)100;
						}
						else if (this.Affection < (float)0)
						{
							this.Affection = (float)0;
						}
					}
					if (Input.GetButtonDown("B"))
					{
						this.Complimenting = false;
					}
				}
				else if (this.ShowingOff)
				{
					this.ShowOff.localScale = Vector3.Lerp(this.ShowOff.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
					if (this.InputManager.TappedUp)
					{
						this.TraitSelected--;
						this.UpdateTraitHighlight();
					}
					else if (this.InputManager.TappedDown)
					{
						this.TraitSelected++;
						this.UpdateTraitHighlight();
					}
					if (Input.GetButtonDown("A"))
					{
						float a5 = 0.5f;
						Color color9 = this.Labels[4].color;
						float num13 = color9.a = a5;
						Color color10 = this.Labels[4].color = color9;
						this.ShowingOff = false;
						if (this.TraitSelected == 2)
						{
							if (PlayerPrefs.GetInt("SuitorTrait2") > PlayerPrefs.GetInt("Trait_2_Demonstrated"))
							{
								PlayerPrefs.SetInt("Trait_2_Demonstrated", PlayerPrefs.GetInt("Trait_2_Demonstrated") + 1);
								this.DialogueLabel.text = this.ShowOffs[this.AffectionLevel];
								this.Rival.Character.animation.CrossFade("f02_lookdown_00");
								this.CurrentAnim = "f02_lookdown_00";
								this.Affection += (float)this.Multiplier;
								this.CalculateAffection();
							}
							else
							{
								this.DialogueLabel.text = "Uh...you already told me about that...";
							}
						}
						else
						{
							this.DialogueLabel.text = "Um...well...that sort of thing doesn't really matter to me...";
						}
						if (this.Affection > (float)100)
						{
							this.Affection = (float)100;
						}
						else if (this.Affection < (float)0)
						{
							this.Affection = (float)0;
						}
					}
					if (Input.GetButtonDown("B"))
					{
						this.ShowingOff = false;
					}
				}
				else if (this.GivingGift)
				{
					this.GiveGift.localScale = Vector3.Lerp(this.GiveGift.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
					if (this.InputManager.TappedUp)
					{
						this.GiftRow--;
						this.UpdateGiftHighlight();
					}
					else if (this.InputManager.TappedDown)
					{
						this.GiftRow++;
						this.UpdateGiftHighlight();
					}
					if (this.InputManager.TappedLeft)
					{
						this.GiftColumn--;
						this.UpdateGiftHighlight();
					}
					else if (this.InputManager.TappedRight)
					{
						this.GiftColumn++;
						this.UpdateGiftHighlight();
					}
					if (Input.GetButtonDown("A"))
					{
						if (this.GiftSelected == 1 && this.RoseIcon.enabled)
						{
							float a6 = 0.5f;
							Color color11 = this.Labels[5].color;
							float num14 = color11.a = a6;
							Color color12 = this.Labels[5].color = color11;
							this.GivingGift = false;
							this.DialogueLabel.text = this.GiveGifts[this.AffectionLevel];
							this.Rival.Character.animation.CrossFade("f02_lookdown_00");
							this.CurrentAnim = "f02_lookdown_00";
							this.Affection += (float)this.Multiplier;
							this.CalculateAffection();
						}
						if (this.Affection > (float)100)
						{
							this.Affection = (float)100;
						}
						else if (this.Affection < (float)0)
						{
							this.Affection = (float)0;
						}
					}
					if (Input.GetButtonDown("B"))
					{
						this.GivingGift = false;
					}
				}
			}
			else if (this.Phase == 5)
			{
				this.Speed += Time.deltaTime * (float)100;
				float y2 = this.AffectionSet.localPosition.y + this.Speed;
				Vector3 localPosition4 = this.AffectionSet.localPosition;
				float num15 = localPosition4.y = y2;
				Vector3 vector8 = this.AffectionSet.localPosition = localPosition4;
				float x5 = this.OptionSet.localPosition.x + this.Speed;
				Vector3 localPosition5 = this.OptionSet.localPosition;
				float num16 = localPosition5.x = x5;
				Vector3 vector9 = this.OptionSet.localPosition = localPosition5;
				if (this.Speed > (float)100 && Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
			}
			else if (this.Phase == 6)
			{
				this.DatingSimHUD.alpha = Mathf.MoveTowards(this.DatingSimHUD.alpha, (float)0, Time.deltaTime);
				if (this.DatingSimHUD.alpha == (float)0)
				{
					this.DatingSimHUD.active = false;
					this.Phase++;
				}
			}
			else if (this.Phase == 7)
			{
				if (this.Panel.alpha == (float)0)
				{
					this.LoveManager.RivalWaiting = false;
					this.LoveManager.Courted = true;
					this.Suitor.enabled = true;
					this.Rival.enabled = true;
					this.Suitor.CurrentDestination = this.Suitor.Destinations[this.Suitor.Phase];
					this.Suitor.Pathfinding.target = this.Suitor.Destinations[this.Suitor.Phase];
					this.Suitor.Prompt.Label[0].text = "     Talk";
					this.Suitor.Pathfinding.canSearch = true;
					this.Suitor.Pathfinding.canMove = true;
					this.Suitor.Pushable = false;
					this.Suitor.Meeting = false;
					this.Suitor.Routine = true;
					this.Suitor.MeetTimer = (float)0;
					this.Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", (float)0);
					this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
					this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
					this.Rival.CharacterAnimation["f02_smile_00"].weight = (float)0;
					this.Rival.Prompt.Label[0].text = "     Talk";
					this.Rival.Pathfinding.canSearch = true;
					this.Rival.Pathfinding.canMove = true;
					this.Rival.Pushable = false;
					this.Rival.Meeting = false;
					this.Rival.Routine = true;
					this.Rival.MeetTimer = (float)0;
					this.StudentManager.Clock.StopTime = false;
					this.Yandere.RPGCamera.enabled = true;
					this.Suitor.Earpiece.active = false;
					this.HeartbeatCamera.active = true;
					this.Yandere.Headset.active = false;
					PlayerPrefs.SetFloat("Affection", this.Affection);
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
				}
				else if (this.Panel.alpha == (float)1)
				{
					this.Matchmaking = false;
					this.Yandere.CanMove = true;
					this.gameObject.active = false;
				}
				this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, (float)1, Time.deltaTime);
			}
		}
	}

	// Token: 0x060002DF RID: 735 RVA: 0x0003A6AC File Offset: 0x000388AC
	public virtual void LateUpdate()
	{
		if (this.Phase == 4)
		{
		}
	}

	// Token: 0x060002E0 RID: 736 RVA: 0x0003A6BC File Offset: 0x000388BC
	public virtual void CalculateMultiplier()
	{
		this.Multiplier = 5;
		if (!this.Suitor.Cosmetic.Eyewear[6].active)
		{
			this.MultiplierIcons[1].mainTexture = this.X;
			this.Multiplier--;
		}
		if (!this.Suitor.Cosmetic.MaleAccessories[3].active)
		{
			this.MultiplierIcons[2].mainTexture = this.X;
			this.Multiplier--;
		}
		if (!this.Suitor.Cosmetic.MaleHair[22].active)
		{
			this.MultiplierIcons[3].mainTexture = this.X;
			this.Multiplier--;
		}
		if (this.Suitor.Cosmetic.HairColor != "Purple")
		{
			this.MultiplierIcons[4].mainTexture = this.X;
			this.Multiplier--;
		}
		if (PlayerPrefs.GetInt("PantiesEquipped") == 2)
		{
			this.PantyIcon.active = true;
			this.Multiplier++;
		}
		else
		{
			this.PantyIcon.active = false;
		}
		if (PlayerPrefs.GetInt("Seduction") + PlayerPrefs.GetInt("SeductionBonus") > 0)
		{
			this.SeductionLabel.text = string.Empty + (PlayerPrefs.GetInt("Seduction") + PlayerPrefs.GetInt("SeductionBonus"));
			this.Multiplier += PlayerPrefs.GetInt("Seduction") + PlayerPrefs.GetInt("SeductionBonus");
			this.SeductionIcon.active = true;
		}
		else
		{
			this.SeductionIcon.active = false;
		}
		this.MultiplierLabel.text = "Multiplier: " + this.Multiplier + "x";
	}

	// Token: 0x060002E1 RID: 737 RVA: 0x0003A8B8 File Offset: 0x00038AB8
	public virtual void UpdateHighlight()
	{
		if (this.Selected < 1)
		{
			this.Selected = 6;
		}
		else if (this.Selected > 6)
		{
			this.Selected = 1;
		}
		this.HighlightTarget = (float)(450 - 100 * this.Selected);
	}

	// Token: 0x060002E2 RID: 738 RVA: 0x0003A908 File Offset: 0x00038B08
	public virtual void UpdateTopicHighlight()
	{
		if (this.Row < 1)
		{
			this.Row = 5;
		}
		else if (this.Row > 5)
		{
			this.Row = 1;
		}
		if (this.Column < 1)
		{
			this.Column = 5;
		}
		else if (this.Column > 5)
		{
			this.Column = 1;
		}
		int num = 375 - 125 * this.Row;
		Vector3 localPosition = this.TopicHighlight.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.TopicHighlight.localPosition = localPosition;
		int num3 = -375 + 125 * this.Column;
		Vector3 localPosition2 = this.TopicHighlight.localPosition;
		float num4 = localPosition2.x = (float)num3;
		Vector3 vector2 = this.TopicHighlight.localPosition = localPosition2;
		this.TopicSelected = (this.Row - 1) * 5 + this.Column;
		if (PlayerPrefs.GetInt("Topic_" + this.TopicSelected + "_Discovered") == 1)
		{
			this.TopicNameLabel.text = this.TopicNames[this.TopicSelected];
		}
		else
		{
			this.TopicNameLabel.text = "??????????";
		}
	}

	// Token: 0x060002E3 RID: 739 RVA: 0x0003AA5C File Offset: 0x00038C5C
	public virtual void DetermineOpinion()
	{
		if (this.TopicSelected == 1)
		{
			this.Opinion = this.JSON.Topic1[7];
		}
		else if (this.TopicSelected == 2)
		{
			this.Opinion = this.JSON.Topic2[7];
		}
		else if (this.TopicSelected == 3)
		{
			this.Opinion = this.JSON.Topic3[7];
		}
		else if (this.TopicSelected == 4)
		{
			this.Opinion = this.JSON.Topic4[7];
		}
		else if (this.TopicSelected == 5)
		{
			this.Opinion = this.JSON.Topic5[7];
		}
		else if (this.TopicSelected == 6)
		{
			this.Opinion = this.JSON.Topic6[7];
		}
		else if (this.TopicSelected == 7)
		{
			this.Opinion = this.JSON.Topic7[7];
		}
		else if (this.TopicSelected == 8)
		{
			this.Opinion = this.JSON.Topic8[7];
		}
		else if (this.TopicSelected == 9)
		{
			this.Opinion = this.JSON.Topic9[7];
		}
		else if (this.TopicSelected == 10)
		{
			this.Opinion = this.JSON.Topic10[7];
		}
		else if (this.TopicSelected == 11)
		{
			this.Opinion = this.JSON.Topic11[7];
		}
		else if (this.TopicSelected == 12)
		{
			this.Opinion = this.JSON.Topic12[7];
		}
		else if (this.TopicSelected == 13)
		{
			this.Opinion = this.JSON.Topic13[7];
		}
		else if (this.TopicSelected == 14)
		{
			this.Opinion = this.JSON.Topic14[7];
		}
		else if (this.TopicSelected == 15)
		{
			this.Opinion = this.JSON.Topic15[7];
		}
		else if (this.TopicSelected == 16)
		{
			this.Opinion = this.JSON.Topic16[7];
		}
		else if (this.TopicSelected == 17)
		{
			this.Opinion = this.JSON.Topic17[7];
		}
		else if (this.TopicSelected == 18)
		{
			this.Opinion = this.JSON.Topic18[7];
		}
		else if (this.TopicSelected == 19)
		{
			this.Opinion = this.JSON.Topic19[7];
		}
		else if (this.TopicSelected == 20)
		{
			this.Opinion = this.JSON.Topic20[7];
		}
		else if (this.TopicSelected == 21)
		{
			this.Opinion = this.JSON.Topic21[7];
		}
		else if (this.TopicSelected == 22)
		{
			this.Opinion = this.JSON.Topic22[7];
		}
		else if (this.TopicSelected == 23)
		{
			this.Opinion = this.JSON.Topic23[7];
		}
		else if (this.TopicSelected == 24)
		{
			this.Opinion = this.JSON.Topic24[7];
		}
		else if (this.TopicSelected == 25)
		{
			this.Opinion = this.JSON.Topic25[7];
		}
	}

	// Token: 0x060002E4 RID: 740 RVA: 0x0003ADFC File Offset: 0x00038FFC
	public virtual void UpdateTopics()
	{
		for (int i = 1; i < Extensions.get_length(this.TopicIcons); i++)
		{
			if (PlayerPrefs.GetInt("Topic_" + i + "_Discovered") == 0)
			{
				this.TopicIcons[i].spriteName = string.Empty + 0;
				float a = 0.5f;
				Color color = this.TopicIcons[i].color;
				float num = color.a = a;
				Color color2 = this.TopicIcons[i].color = color;
			}
			else
			{
				this.TopicIcons[i].spriteName = string.Empty + i;
			}
		}
	}

	// Token: 0x060002E5 RID: 741 RVA: 0x0003AEC0 File Offset: 0x000390C0
	public virtual void UpdateComplimentHighlight()
	{
		for (int i = 1; i < Extensions.get_length(this.TopicIcons); i++)
		{
			this.ComplimentBGs[this.ComplimentSelected].color = this.OriginalColor;
		}
		if (this.Line < 1)
		{
			this.Line = 5;
		}
		else if (this.Line > 5)
		{
			this.Line = 1;
		}
		if (this.Side < 1)
		{
			this.Side = 2;
		}
		else if (this.Side > 2)
		{
			this.Side = 1;
		}
		this.ComplimentSelected = (this.Line - 1) * 2 + this.Side;
		this.ComplimentBGs[this.ComplimentSelected].color = Color.white;
	}

	// Token: 0x060002E6 RID: 742 RVA: 0x0003AF88 File Offset: 0x00039188
	public virtual void UpdateTraitHighlight()
	{
		if (this.TraitSelected < 1)
		{
			this.TraitSelected = 3;
		}
		else if (this.TraitSelected > 3)
		{
			this.TraitSelected = 1;
		}
		for (int i = 1; i < Extensions.get_length(this.TraitBGs); i++)
		{
			this.TraitBGs[i].color = this.OriginalColor;
		}
		this.TraitBGs[this.TraitSelected].color = Color.white;
	}

	// Token: 0x060002E7 RID: 743 RVA: 0x0003B008 File Offset: 0x00039208
	public virtual void UpdateGiftHighlight()
	{
		for (int i = 1; i < Extensions.get_length(this.GiftBGs); i++)
		{
			this.GiftBGs[i].color = this.OriginalColor;
		}
		if (this.GiftRow < 1)
		{
			this.GiftRow = 2;
		}
		else if (this.GiftRow > 2)
		{
			this.GiftRow = 1;
		}
		if (this.GiftColumn < 1)
		{
			this.GiftColumn = 2;
		}
		else if (this.GiftColumn > 2)
		{
			this.GiftColumn = 1;
		}
		this.GiftSelected = (this.GiftRow - 1) * 2 + this.GiftColumn;
		this.GiftBGs[this.GiftSelected].color = Color.white;
	}

	// Token: 0x060002E8 RID: 744 RVA: 0x0003B0C8 File Offset: 0x000392C8
	public virtual void Main()
	{
	}

	// Token: 0x040006E9 RID: 1769
	public StudentManagerScript StudentManager;

	// Token: 0x040006EA RID: 1770
	public InputManagerScript InputManager;

	// Token: 0x040006EB RID: 1771
	public LoveManagerScript LoveManager;

	// Token: 0x040006EC RID: 1772
	public PromptBarScript PromptBar;

	// Token: 0x040006ED RID: 1773
	public YandereScript Yandere;

	// Token: 0x040006EE RID: 1774
	public StudentScript Suitor;

	// Token: 0x040006EF RID: 1775
	public StudentScript Rival;

	// Token: 0x040006F0 RID: 1776
	public PromptScript Prompt;

	// Token: 0x040006F1 RID: 1777
	public JsonScript JSON;

	// Token: 0x040006F2 RID: 1778
	public Transform AffectionSet;

	// Token: 0x040006F3 RID: 1779
	public Transform OptionSet;

	// Token: 0x040006F4 RID: 1780
	public GameObject HeartbeatCamera;

	// Token: 0x040006F5 RID: 1781
	public GameObject SeductionIcon;

	// Token: 0x040006F6 RID: 1782
	public GameObject PantyIcon;

	// Token: 0x040006F7 RID: 1783
	public Transform TopicHighlight;

	// Token: 0x040006F8 RID: 1784
	public Transform ComplimentSet;

	// Token: 0x040006F9 RID: 1785
	public Transform AffectionBar;

	// Token: 0x040006FA RID: 1786
	public Transform Highlight;

	// Token: 0x040006FB RID: 1787
	public Transform GiveGift;

	// Token: 0x040006FC RID: 1788
	public Transform PeekSpot;

	// Token: 0x040006FD RID: 1789
	public Transform[] Options;

	// Token: 0x040006FE RID: 1790
	public Transform ShowOff;

	// Token: 0x040006FF RID: 1791
	public Transform Topics;

	// Token: 0x04000700 RID: 1792
	public Texture X;

	// Token: 0x04000701 RID: 1793
	public UITexture[] MultiplierIcons;

	// Token: 0x04000702 RID: 1794
	public UILabel[] ComplimentLabels;

	// Token: 0x04000703 RID: 1795
	public UISprite[] ComplimentBGs;

	// Token: 0x04000704 RID: 1796
	public UILabel MultiplierLabel;

	// Token: 0x04000705 RID: 1797
	public UILabel SeductionLabel;

	// Token: 0x04000706 RID: 1798
	public UILabel TopicNameLabel;

	// Token: 0x04000707 RID: 1799
	public UILabel DialogueLabel;

	// Token: 0x04000708 RID: 1800
	public UISprite[] TopicIcons;

	// Token: 0x04000709 RID: 1801
	public UIPanel DatingSimHUD;

	// Token: 0x0400070A RID: 1802
	public UILabel WisdomLabel;

	// Token: 0x0400070B RID: 1803
	public UISprite[] TraitBGs;

	// Token: 0x0400070C RID: 1804
	public UISprite[] GiftBGs;

	// Token: 0x0400070D RID: 1805
	public UITexture RoseIcon;

	// Token: 0x0400070E RID: 1806
	public UILabel[] Labels;

	// Token: 0x0400070F RID: 1807
	public UIPanel Panel;

	// Token: 0x04000710 RID: 1808
	public string[] Compliments;

	// Token: 0x04000711 RID: 1809
	public string[] TopicNames;

	// Token: 0x04000712 RID: 1810
	public string[] GiveGifts;

	// Token: 0x04000713 RID: 1811
	public string[] Greetings;

	// Token: 0x04000714 RID: 1812
	public string[] Farewells;

	// Token: 0x04000715 RID: 1813
	public string[] Negatives;

	// Token: 0x04000716 RID: 1814
	public string[] Positives;

	// Token: 0x04000717 RID: 1815
	public string[] ShowOffs;

	// Token: 0x04000718 RID: 1816
	public bool SelectingTopic;

	// Token: 0x04000719 RID: 1817
	public bool AffectionGrow;

	// Token: 0x0400071A RID: 1818
	public bool Complimenting;

	// Token: 0x0400071B RID: 1819
	public bool Matchmaking;

	// Token: 0x0400071C RID: 1820
	public bool GivingGift;

	// Token: 0x0400071D RID: 1821
	public bool ShowingOff;

	// Token: 0x0400071E RID: 1822
	public bool Negative;

	// Token: 0x0400071F RID: 1823
	public bool SlideOut;

	// Token: 0x04000720 RID: 1824
	public bool Testing;

	// Token: 0x04000721 RID: 1825
	public float HighlightTarget;

	// Token: 0x04000722 RID: 1826
	public float Affection;

	// Token: 0x04000723 RID: 1827
	public float Rotation;

	// Token: 0x04000724 RID: 1828
	public float Speed;

	// Token: 0x04000725 RID: 1829
	public float Timer;

	// Token: 0x04000726 RID: 1830
	public int ComplimentSelected;

	// Token: 0x04000727 RID: 1831
	public int TraitSelected;

	// Token: 0x04000728 RID: 1832
	public int TopicSelected;

	// Token: 0x04000729 RID: 1833
	public int GiftSelected;

	// Token: 0x0400072A RID: 1834
	public int Selected;

	// Token: 0x0400072B RID: 1835
	public int AffectionLevel;

	// Token: 0x0400072C RID: 1836
	public int Multiplier;

	// Token: 0x0400072D RID: 1837
	public int Opinion;

	// Token: 0x0400072E RID: 1838
	public int Phase;

	// Token: 0x0400072F RID: 1839
	public int GiftColumn;

	// Token: 0x04000730 RID: 1840
	public int GiftRow;

	// Token: 0x04000731 RID: 1841
	public int Column;

	// Token: 0x04000732 RID: 1842
	public int Row;

	// Token: 0x04000733 RID: 1843
	public int Side;

	// Token: 0x04000734 RID: 1844
	public int Line;

	// Token: 0x04000735 RID: 1845
	public string CurrentAnim;

	// Token: 0x04000736 RID: 1846
	public Color OriginalColor;
}
