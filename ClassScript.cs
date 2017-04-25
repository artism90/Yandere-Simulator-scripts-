using System;
using UnityEngine;

// Token: 0x02000062 RID: 98
[Serializable]
public class ClassScript : MonoBehaviour
{
	// Token: 0x06000265 RID: 613 RVA: 0x0002B1F0 File Offset: 0x000293F0
	public virtual void Start()
	{
		this.GradeUpWindow.localScale = new Vector3((float)0, (float)0, (float)0);
		this.Subject[1] = PlayerPrefs.GetInt("Biology");
		this.Subject[2] = PlayerPrefs.GetInt("Chemistry");
		this.Subject[3] = PlayerPrefs.GetInt("Language");
		this.Subject[4] = PlayerPrefs.GetInt("Physical");
		this.Subject[5] = PlayerPrefs.GetInt("Psychology");
		this.DescLabel.text = this.Desc[this.Selected];
		this.UpdateSubjectLabels();
		int num = 1;
		Color color = this.Darkness.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Darkness.color = color;
		this.UpdateBars();
	}

	// Token: 0x06000266 RID: 614 RVA: 0x0002B2C0 File Offset: 0x000294C0
	public virtual void Update()
	{
		if (this.Show)
		{
			float a = this.Darkness.color.a - Time.deltaTime;
			Color color = this.Darkness.color;
			float num = color.a = a;
			Color color2 = this.Darkness.color = color;
			if (this.Darkness.color.a <= (float)0)
			{
				if (Input.GetKeyDown(KeyCode.Backslash))
				{
					this.GivePoints();
				}
				if (Input.GetKeyDown("p"))
				{
					this.MaxPhysical();
				}
				int num2 = 0;
				Color color3 = this.Darkness.color;
				float num3 = color3.a = (float)num2;
				Color color4 = this.Darkness.color = color3;
				if (this.InputManager.TappedDown)
				{
					this.Selected++;
					if (this.Selected > 5)
					{
						this.Selected = 1;
					}
					int num4 = 375 - 125 * this.Selected;
					Vector3 localPosition = this.Highlight.localPosition;
					float num5 = localPosition.y = (float)num4;
					Vector3 vector = this.Highlight.localPosition = localPosition;
					this.DescLabel.text = this.Desc[this.Selected];
					this.UpdateSubjectLabels();
				}
				if (this.InputManager.TappedUp)
				{
					this.Selected--;
					if (this.Selected < 1)
					{
						this.Selected = 5;
					}
					int num6 = 375 - 125 * this.Selected;
					Vector3 localPosition2 = this.Highlight.localPosition;
					float num7 = localPosition2.y = (float)num6;
					Vector3 vector2 = this.Highlight.localPosition = localPosition2;
					this.DescLabel.text = this.Desc[this.Selected];
					this.UpdateSubjectLabels();
				}
				if (this.InputManager.TappedRight && this.StudyPoints > 0 && this.Subject[this.Selected] + this.SubjectTemp[this.Selected] < 100)
				{
					this.SubjectTemp[this.Selected] = this.SubjectTemp[this.Selected] + 1;
					this.StudyPoints--;
					this.UpdateLabel();
					this.UpdateBars();
				}
				if (this.InputManager.TappedLeft && this.SubjectTemp[this.Selected] > 0)
				{
					this.SubjectTemp[this.Selected] = this.SubjectTemp[this.Selected] - 1;
					this.StudyPoints++;
					this.UpdateLabel();
					this.UpdateBars();
				}
				if (Input.GetButtonDown("A") && this.StudyPoints == 0)
				{
					this.Show = false;
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
					PlayerPrefs.SetInt("Biology", this.Subject[1] + this.SubjectTemp[1]);
					PlayerPrefs.SetInt("Chemistry", this.Subject[2] + this.SubjectTemp[2]);
					PlayerPrefs.SetInt("Language", this.Subject[3] + this.SubjectTemp[3]);
					PlayerPrefs.SetInt("Physical", this.Subject[4] + this.SubjectTemp[4]);
					PlayerPrefs.SetInt("Psychology", this.Subject[5] + this.SubjectTemp[5]);
					for (int i = 0; i < 6; i++)
					{
						this.Subject[i] = this.Subject[i] + this.SubjectTemp[i];
						this.SubjectTemp[i] = 0;
					}
					this.CheckForGradeUp();
				}
			}
		}
		else
		{
			float a2 = this.Darkness.color.a + Time.deltaTime;
			Color color5 = this.Darkness.color;
			float num8 = color5.a = a2;
			Color color6 = this.Darkness.color = color5;
			if (this.Darkness.color.a >= (float)1)
			{
				int num9 = 1;
				Color color7 = this.Darkness.color;
				float num10 = color7.a = (float)num9;
				Color color8 = this.Darkness.color = color7;
				if (!this.GradeUp)
				{
					if (this.GradeUpWindow.localScale.x > 0.1f)
					{
						this.GradeUpWindow.localScale = Vector3.Lerp(this.GradeUpWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
					}
					else
					{
						this.GradeUpWindow.localScale = new Vector3((float)0, (float)0, (float)0);
					}
					if (this.GradeUpWindow.localScale.x < 0.01f)
					{
						this.GradeUpWindow.localScale = new Vector3((float)0, (float)0, (float)0);
						this.CheckForGradeUp();
						if (!this.GradeUp)
						{
							if (PlayerPrefs.GetInt("ChemistryGrade") > 0 && this.Poison != null)
							{
								this.Poison.active = true;
							}
							if (PlayerPrefs.GetInt("Scheme_5_Stage") == 7)
							{
								PlayerPrefs.SetInt("Scheme_5_Stage", 100);
								this.PromptBar.ClearButtons();
								this.PromptBar.Label[0].text = "Continue";
								this.PromptBar.UpdateButtons();
								this.CutsceneManager.active = true;
								this.Schemes.UpdateInstructions();
								this.active = false;
							}
							else
							{
								this.PromptBar.Show = false;
								this.Portal.Proceed = true;
								this.active = false;
							}
						}
					}
				}
				else
				{
					if (this.GradeUpWindow.localScale.x == (float)0)
					{
						if (this.GradeUpSubject == 1)
						{
							this.GradeUpName.text = "BIOLOGY RANK UP";
							this.GradeUpDesc.text = string.Empty + this.Subject1GradeText[this.Grade];
						}
						else if (this.GradeUpSubject == 2)
						{
							this.GradeUpName.text = "CHEMISTRY RANK UP";
							this.GradeUpDesc.text = string.Empty + this.Subject2GradeText[this.Grade];
						}
						else if (this.GradeUpSubject == 3)
						{
							this.GradeUpName.text = "LANGUAGE RANK UP";
							this.GradeUpDesc.text = string.Empty + this.Subject3GradeText[this.Grade];
						}
						else if (this.GradeUpSubject == 4)
						{
							this.GradeUpName.text = "PHYSICAL RANK UP";
							this.GradeUpDesc.text = string.Empty + this.Subject4GradeText[this.Grade];
						}
						else if (this.GradeUpSubject == 5)
						{
							this.GradeUpName.text = "PSYCHOLOGY RANK UP";
							this.GradeUpDesc.text = string.Empty + this.Subject5GradeText[this.Grade];
						}
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "Continue";
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
					}
					else if (this.GradeUpWindow.localScale.x > 0.99f && Input.GetButtonDown("A"))
					{
						this.PromptBar.ClearButtons();
						this.GradeUp = false;
					}
					this.GradeUpWindow.localScale = Vector3.Lerp(this.GradeUpWindow.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				}
			}
		}
	}

	// Token: 0x06000267 RID: 615 RVA: 0x0002BABC File Offset: 0x00029CBC
	public virtual void UpdateSubjectLabels()
	{
		for (int i = 1; i < 6; i++)
		{
			this.SubjectLabels[i].color = new Color((float)0, (float)0, (float)0, (float)1);
		}
		this.SubjectLabels[this.Selected].color = new Color((float)1, (float)1, (float)1, (float)1);
	}

	// Token: 0x06000268 RID: 616 RVA: 0x0002BB14 File Offset: 0x00029D14
	public virtual void UpdateLabel()
	{
		this.StudyPointsLabel.text = "STUDY POINTS: " + this.StudyPoints;
		if (this.StudyPoints == 0)
		{
			this.PromptBar.Label[0].text = "Confirm";
			this.PromptBar.UpdateButtons();
		}
		else
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
	}

	// Token: 0x06000269 RID: 617 RVA: 0x0002BB98 File Offset: 0x00029D98
	public virtual void UpdateBars()
	{
		for (int i = 1; i < 6; i++)
		{
			if (this.Subject[1] + this.SubjectTemp[1] > (i - 1) * 20)
			{
				float x = (float)((i - 1) * 20 - (this.Subject[1] + this.SubjectTemp[1])) / 20f * (float)-1;
				Vector3 localScale = this.Subject1Bars[i].localScale;
				float num = localScale.x = x;
				Vector3 vector = this.Subject1Bars[i].localScale = localScale;
				if (this.Subject1Bars[i].localScale.x > (float)1)
				{
					int num2 = 1;
					Vector3 localScale2 = this.Subject1Bars[i].localScale;
					float num3 = localScale2.x = (float)num2;
					Vector3 vector2 = this.Subject1Bars[i].localScale = localScale2;
				}
			}
			else
			{
				int num4 = 0;
				Vector3 localScale3 = this.Subject1Bars[i].localScale;
				float num5 = localScale3.x = (float)num4;
				Vector3 vector3 = this.Subject1Bars[i].localScale = localScale3;
			}
		}
		for (int i = 1; i < 6; i++)
		{
			if (this.Subject[2] + this.SubjectTemp[2] > (i - 1) * 20)
			{
				float x2 = (float)((i - 1) * 20 - (this.Subject[2] + this.SubjectTemp[2])) / 20f * (float)-1;
				Vector3 localScale4 = this.Subject2Bars[i].localScale;
				float num6 = localScale4.x = x2;
				Vector3 vector4 = this.Subject2Bars[i].localScale = localScale4;
				if (this.Subject2Bars[i].localScale.x > (float)1)
				{
					int num7 = 1;
					Vector3 localScale5 = this.Subject2Bars[i].localScale;
					float num8 = localScale5.x = (float)num7;
					Vector3 vector5 = this.Subject2Bars[i].localScale = localScale5;
				}
			}
			else
			{
				int num9 = 0;
				Vector3 localScale6 = this.Subject2Bars[i].localScale;
				float num10 = localScale6.x = (float)num9;
				Vector3 vector6 = this.Subject2Bars[i].localScale = localScale6;
			}
		}
		for (int i = 1; i < 6; i++)
		{
			if (this.Subject[3] + this.SubjectTemp[3] > (i - 1) * 20)
			{
				float x3 = (float)((i - 1) * 20 - (this.Subject[3] + this.SubjectTemp[3])) / 20f * (float)-1;
				Vector3 localScale7 = this.Subject3Bars[i].localScale;
				float num11 = localScale7.x = x3;
				Vector3 vector7 = this.Subject3Bars[i].localScale = localScale7;
				if (this.Subject3Bars[i].localScale.x > (float)1)
				{
					int num12 = 1;
					Vector3 localScale8 = this.Subject3Bars[i].localScale;
					float num13 = localScale8.x = (float)num12;
					Vector3 vector8 = this.Subject3Bars[i].localScale = localScale8;
				}
			}
			else
			{
				int num14 = 0;
				Vector3 localScale9 = this.Subject3Bars[i].localScale;
				float num15 = localScale9.x = (float)num14;
				Vector3 vector9 = this.Subject3Bars[i].localScale = localScale9;
			}
		}
		for (int i = 1; i < 6; i++)
		{
			if (this.Subject[4] + this.SubjectTemp[4] > (i - 1) * 20)
			{
				float x4 = (float)((i - 1) * 20 - (this.Subject[4] + this.SubjectTemp[4])) / 20f * (float)-1;
				Vector3 localScale10 = this.Subject4Bars[i].localScale;
				float num16 = localScale10.x = x4;
				Vector3 vector10 = this.Subject4Bars[i].localScale = localScale10;
				if (this.Subject4Bars[i].localScale.x > (float)1)
				{
					int num17 = 1;
					Vector3 localScale11 = this.Subject4Bars[i].localScale;
					float num18 = localScale11.x = (float)num17;
					Vector3 vector11 = this.Subject4Bars[i].localScale = localScale11;
				}
			}
			else
			{
				int num19 = 0;
				Vector3 localScale12 = this.Subject4Bars[i].localScale;
				float num20 = localScale12.x = (float)num19;
				Vector3 vector12 = this.Subject4Bars[i].localScale = localScale12;
			}
		}
		for (int i = 1; i < 6; i++)
		{
			if (this.Subject[5] + this.SubjectTemp[5] > (i - 1) * 20)
			{
				float x5 = (float)((i - 1) * 20 - (this.Subject[5] + this.SubjectTemp[5])) / 20f * (float)-1;
				Vector3 localScale13 = this.Subject5Bars[i].localScale;
				float num21 = localScale13.x = x5;
				Vector3 vector13 = this.Subject5Bars[i].localScale = localScale13;
				if (this.Subject5Bars[i].localScale.x > (float)1)
				{
					int num22 = 1;
					Vector3 localScale14 = this.Subject5Bars[i].localScale;
					float num23 = localScale14.x = (float)num22;
					Vector3 vector14 = this.Subject5Bars[i].localScale = localScale14;
				}
			}
			else
			{
				int num24 = 0;
				Vector3 localScale15 = this.Subject5Bars[i].localScale;
				float num25 = localScale15.x = (float)num24;
				Vector3 vector15 = this.Subject5Bars[i].localScale = localScale15;
			}
		}
	}

	// Token: 0x0600026A RID: 618 RVA: 0x0002C144 File Offset: 0x0002A344
	public virtual void CheckForGradeUp()
	{
		if (PlayerPrefs.GetInt("Biology") >= 20 && PlayerPrefs.GetInt("BiologyGrade") < 1)
		{
			PlayerPrefs.SetInt("BiologyGrade", 1);
			this.GradeUpSubject = 1;
			this.GradeUp = true;
			this.Grade = 1;
		}
		else if (PlayerPrefs.GetInt("Chemistry") >= 20 && PlayerPrefs.GetInt("ChemistryGrade") < 1)
		{
			PlayerPrefs.SetInt("ChemistryGrade", 1);
			this.GradeUpSubject = 2;
			this.GradeUp = true;
			this.Grade = 1;
		}
		else if (PlayerPrefs.GetInt("Language") >= 20 && PlayerPrefs.GetInt("LanguageGrade") < 1)
		{
			PlayerPrefs.SetInt("LanguageGrade", 1);
			this.GradeUpSubject = 3;
			this.GradeUp = true;
			this.Grade = 1;
		}
		else if (PlayerPrefs.GetInt("Physical") >= 20 && PlayerPrefs.GetInt("PhysicalGrade") < 1)
		{
			PlayerPrefs.SetInt("PhysicalGrade", 1);
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 1;
		}
		else if (PlayerPrefs.GetInt("Physical") >= 40 && PlayerPrefs.GetInt("PhysicalGrade") < 2)
		{
			PlayerPrefs.SetInt("PhysicalGrade", 2);
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 2;
		}
		else if (PlayerPrefs.GetInt("Physical") >= 60 && PlayerPrefs.GetInt("PhysicalGrade") < 3)
		{
			PlayerPrefs.SetInt("PhysicalGrade", 3);
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 3;
		}
		else if (PlayerPrefs.GetInt("Physical") >= 80 && PlayerPrefs.GetInt("PhysicalGrade") < 4)
		{
			PlayerPrefs.SetInt("PhysicalGrade", 4);
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 4;
		}
		else if (PlayerPrefs.GetInt("Physical") == 100 && PlayerPrefs.GetInt("PhysicalGrade") < 5)
		{
			PlayerPrefs.SetInt("PhysicalGrade", 5);
			this.GradeUpSubject = 4;
			this.GradeUp = true;
			this.Grade = 5;
		}
		else if (PlayerPrefs.GetInt("Psychology") >= 20 && PlayerPrefs.GetInt("PsychologyGrade") < 1)
		{
			PlayerPrefs.SetInt("PsychologyGrade", 1);
			this.GradeUpSubject = 5;
			this.GradeUp = true;
			this.Grade = 1;
		}
	}

	// Token: 0x0600026B RID: 619 RVA: 0x0002C3C4 File Offset: 0x0002A5C4
	public virtual void GivePoints()
	{
		PlayerPrefs.SetInt("BiologyGrade", 0);
		PlayerPrefs.SetInt("ChemistryGrade", 0);
		PlayerPrefs.SetInt("LanguageGrade", 0);
		PlayerPrefs.SetInt("PhysicalGrade", 0);
		PlayerPrefs.SetInt("PsychologyGrade", 0);
		PlayerPrefs.SetInt("Biology", 19);
		PlayerPrefs.SetInt("Chemistry", 19);
		PlayerPrefs.SetInt("Language", 19);
		PlayerPrefs.SetInt("Physical", 19);
		PlayerPrefs.SetInt("Psychology", 19);
		this.Subject[1] = PlayerPrefs.GetInt("Biology");
		this.Subject[2] = PlayerPrefs.GetInt("Chemistry");
		this.Subject[3] = PlayerPrefs.GetInt("Language");
		this.Subject[4] = PlayerPrefs.GetInt("Physical");
		this.Subject[5] = PlayerPrefs.GetInt("Psychology");
		this.UpdateBars();
	}

	// Token: 0x0600026C RID: 620 RVA: 0x0002C4A4 File Offset: 0x0002A6A4
	public virtual void MaxPhysical()
	{
		PlayerPrefs.SetInt("PhysicalGrade", 0);
		PlayerPrefs.SetInt("Physical", 99);
		this.Subject[4] = PlayerPrefs.GetInt("Physical");
		this.UpdateBars();
	}

	// Token: 0x0600026D RID: 621 RVA: 0x0002C4D8 File Offset: 0x0002A6D8
	public virtual void Main()
	{
	}

	// Token: 0x0400051A RID: 1306
	public CutsceneManagerScript CutsceneManager;

	// Token: 0x0400051B RID: 1307
	public InputManagerScript InputManager;

	// Token: 0x0400051C RID: 1308
	public PromptBarScript PromptBar;

	// Token: 0x0400051D RID: 1309
	public SchemesScript Schemes;

	// Token: 0x0400051E RID: 1310
	public PortalScript Portal;

	// Token: 0x0400051F RID: 1311
	public GameObject Poison;

	// Token: 0x04000520 RID: 1312
	public UILabel StudyPointsLabel;

	// Token: 0x04000521 RID: 1313
	public UILabel[] SubjectLabels;

	// Token: 0x04000522 RID: 1314
	public UILabel GradeUpDesc;

	// Token: 0x04000523 RID: 1315
	public UILabel GradeUpName;

	// Token: 0x04000524 RID: 1316
	public UILabel DescLabel;

	// Token: 0x04000525 RID: 1317
	public UISprite Darkness;

	// Token: 0x04000526 RID: 1318
	public Transform[] Subject1Bars;

	// Token: 0x04000527 RID: 1319
	public Transform[] Subject2Bars;

	// Token: 0x04000528 RID: 1320
	public Transform[] Subject3Bars;

	// Token: 0x04000529 RID: 1321
	public Transform[] Subject4Bars;

	// Token: 0x0400052A RID: 1322
	public Transform[] Subject5Bars;

	// Token: 0x0400052B RID: 1323
	public string[] Subject1GradeText;

	// Token: 0x0400052C RID: 1324
	public string[] Subject2GradeText;

	// Token: 0x0400052D RID: 1325
	public string[] Subject3GradeText;

	// Token: 0x0400052E RID: 1326
	public string[] Subject4GradeText;

	// Token: 0x0400052F RID: 1327
	public string[] Subject5GradeText;

	// Token: 0x04000530 RID: 1328
	public Transform GradeUpWindow;

	// Token: 0x04000531 RID: 1329
	public Transform Highlight;

	// Token: 0x04000532 RID: 1330
	public int[] SubjectTemp;

	// Token: 0x04000533 RID: 1331
	public int[] Subject;

	// Token: 0x04000534 RID: 1332
	public string[] Desc;

	// Token: 0x04000535 RID: 1333
	public int GradeUpSubject;

	// Token: 0x04000536 RID: 1334
	public int StudyPoints;

	// Token: 0x04000537 RID: 1335
	public int Selected;

	// Token: 0x04000538 RID: 1336
	public int Grade;

	// Token: 0x04000539 RID: 1337
	public bool GradeUp;

	// Token: 0x0400053A RID: 1338
	public bool Show;
}
