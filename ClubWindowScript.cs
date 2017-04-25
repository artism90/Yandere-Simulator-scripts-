using System;
using UnityEngine;

// Token: 0x02000067 RID: 103
[Serializable]
public class ClubWindowScript : MonoBehaviour
{
	// Token: 0x06000288 RID: 648 RVA: 0x0002E9CC File Offset: 0x0002CBCC
	public virtual void Start()
	{
		this.Window.active = false;
		if (PlayerPrefs.GetFloat("SchoolAtmosphere") < 33.33333f)
		{
			this.ActivityDescs[7] = this.LowAtmosphereDesc;
		}
		else if (PlayerPrefs.GetFloat("SchoolAtmosphere") < 66.66666f)
		{
			this.ActivityDescs[7] = this.MedAtmosphereDesc;
		}
	}

	// Token: 0x06000289 RID: 649 RVA: 0x0002EA30 File Offset: 0x0002CC30
	public virtual void Update()
	{
		if (this.Window.active)
		{
			if (this.Timer > 0.5f)
			{
				if (Input.GetButtonDown("A"))
				{
					if (!this.Quitting && !this.Activity)
					{
						PlayerPrefs.SetInt("Club", this.Club);
						this.Yandere.ClubAccessory();
						this.Yandere.TargetStudent.Interaction = 11;
						this.ClubManager.ActivateClubBenefit();
					}
					else if (this.Quitting)
					{
						this.ClubManager.DeactivateClubBenefit();
						PlayerPrefs.SetInt("QuitClub_" + this.Club, 1);
						PlayerPrefs.SetInt("Club", 0);
						this.Yandere.ClubAccessory();
						this.Yandere.TargetStudent.Interaction = 12;
						this.Quitting = false;
					}
					else if (this.Activity)
					{
						this.Yandere.TargetStudent.Interaction = 14;
					}
					this.Yandere.TargetStudent.TalkTimer = (float)100;
					this.Yandere.TargetStudent.ClubPhase = 2;
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
					this.Window.active = false;
				}
				if (Input.GetButtonDown("B"))
				{
					if (!this.Quitting && !this.Activity)
					{
						this.Yandere.TargetStudent.Interaction = 11;
					}
					else if (this.Quitting)
					{
						this.Yandere.TargetStudent.Interaction = 12;
						this.Quitting = false;
					}
					else if (this.Activity)
					{
						this.Yandere.TargetStudent.Interaction = 14;
						this.Activity = false;
					}
					this.Yandere.TargetStudent.TalkTimer = (float)100;
					this.Yandere.TargetStudent.ClubPhase = 3;
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
					this.Window.active = false;
				}
				if (Input.GetButtonDown("X") && !this.Quitting && !this.Activity)
				{
					if (!this.Warning.active)
					{
						this.ClubInfo.active = false;
						this.Warning.active = true;
					}
					else
					{
						this.ClubInfo.active = true;
						this.Warning.active = false;
					}
				}
			}
			this.Timer += Time.deltaTime;
		}
		if (this.PerformingActivity)
		{
			this.ActivityWindow.localScale = Vector3.Lerp(this.ActivityWindow.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
		}
		else if (this.ActivityWindow.localScale.x > 0.1f)
		{
			this.ActivityWindow.localScale = Vector3.Lerp(this.ActivityWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
		else if (this.ActivityWindow.localScale.x != (float)0)
		{
			this.ActivityWindow.localScale = new Vector3((float)0, (float)0, (float)0);
		}
	}

	// Token: 0x0600028A RID: 650 RVA: 0x0002ED9C File Offset: 0x0002CF9C
	public virtual void UpdateWindow()
	{
		this.ClubName.text = this.ClubNames[this.Club];
		if (!this.Quitting && !this.Activity)
		{
			this.ClubDesc.text = this.ClubDescs[this.Club];
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Refuse";
			this.PromptBar.Label[2].text = "More Info";
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = true;
			this.BottomLabel.text = "Will you join the " + this.ClubNames[this.Club] + "?";
		}
		else if (this.Activity)
		{
			this.ClubDesc.text = "Club activities last until 6:00 PM. If you choose to participate in club activities now, the day will end." + "\n" + "\n" + "If you don't join by 5:30 PM, you won't be able to participate in club activities today." + "\n" + "\n" + "If you don't participate in club activities at least once a week, you will be removed from the club.";
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Yes";
			this.PromptBar.Label[1].text = "No";
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = true;
			this.BottomLabel.text = "Will you participate in club activities?";
		}
		else if (this.Quitting)
		{
			this.ClubDesc.text = "Are you sure you want to quit this club? If you quit, you will never be allowed to return.";
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Confirm";
			this.PromptBar.Label[1].text = "Deny";
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = true;
			this.BottomLabel.text = "Will you quit the " + this.ClubNames[this.Club] + "?";
		}
		this.ClubInfo.active = true;
		this.Warning.active = false;
		this.Window.active = true;
		this.Timer = (float)0;
	}

	// Token: 0x0600028B RID: 651 RVA: 0x0002F008 File Offset: 0x0002D208
	public virtual void Main()
	{
	}

	// Token: 0x04000594 RID: 1428
	public ClubManagerScript ClubManager;

	// Token: 0x04000595 RID: 1429
	public PromptBarScript PromptBar;

	// Token: 0x04000596 RID: 1430
	public YandereScript Yandere;

	// Token: 0x04000597 RID: 1431
	public Transform ActivityWindow;

	// Token: 0x04000598 RID: 1432
	public GameObject ClubInfo;

	// Token: 0x04000599 RID: 1433
	public GameObject Window;

	// Token: 0x0400059A RID: 1434
	public GameObject Warning;

	// Token: 0x0400059B RID: 1435
	public string[] ActivityDescs;

	// Token: 0x0400059C RID: 1436
	public string[] ClubNames;

	// Token: 0x0400059D RID: 1437
	public string[] ClubDescs;

	// Token: 0x0400059E RID: 1438
	public string MedAtmosphereDesc;

	// Token: 0x0400059F RID: 1439
	public string LowAtmosphereDesc;

	// Token: 0x040005A0 RID: 1440
	public UILabel ActivityLabel;

	// Token: 0x040005A1 RID: 1441
	public UILabel BottomLabel;

	// Token: 0x040005A2 RID: 1442
	public UILabel ClubName;

	// Token: 0x040005A3 RID: 1443
	public UILabel ClubDesc;

	// Token: 0x040005A4 RID: 1444
	public bool PerformingActivity;

	// Token: 0x040005A5 RID: 1445
	public bool Activity;

	// Token: 0x040005A6 RID: 1446
	public bool Quitting;

	// Token: 0x040005A7 RID: 1447
	public float Timer;

	// Token: 0x040005A8 RID: 1448
	public int Club;
}
