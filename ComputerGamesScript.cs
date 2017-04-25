using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000069 RID: 105
[Serializable]
public class ComputerGamesScript : MonoBehaviour
{
	// Token: 0x06000290 RID: 656 RVA: 0x0002F0D8 File Offset: 0x0002D2D8
	public ComputerGamesScript()
	{
		this.Subject = 1;
		this.ID = 1;
	}

	// Token: 0x06000291 RID: 657 RVA: 0x0002F0F0 File Offset: 0x0002D2F0
	public virtual void Start()
	{
		this.GameWindow.gameObject.active = false;
		this.DeactivateAllBenefits();
		this.OriginalColor = this.Yandere.PowerUp.color;
		if (PlayerPrefs.GetInt("Club") == 11)
		{
			this.EnableGames();
		}
		else
		{
			this.DisableGames();
		}
	}

	// Token: 0x06000292 RID: 658 RVA: 0x0002F14C File Offset: 0x0002D34C
	public virtual void Update()
	{
		if (this.ShowWindow)
		{
			this.GameWindow.localScale = Vector3.Lerp(this.GameWindow.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			if (this.InputManager.TappedUp)
			{
				this.Subject--;
				this.UpdateHighlight();
			}
			else if (this.InputManager.TappedDown)
			{
				this.Subject++;
				this.UpdateHighlight();
			}
			if (Input.GetButtonDown("A"))
			{
				this.ShowWindow = false;
				this.PlayGames();
				this.PromptBar.ClearButtons();
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = false;
			}
			if (Input.GetButtonDown("B"))
			{
				this.Yandere.CanMove = true;
				this.ShowWindow = false;
				this.PromptBar.ClearButtons();
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = false;
			}
		}
		else if (this.GameWindow.localScale.x > 0.1f)
		{
			this.GameWindow.localScale = Vector3.Lerp(this.GameWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
		else
		{
			this.GameWindow.localScale = new Vector3((float)0, (float)0, (float)0);
			this.GameWindow.gameObject.active = false;
		}
		if (this.Gaming)
		{
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.ComputerGames[this.GameID].transform.position.x, this.Yandere.transform.position.y, this.ComputerGames[this.GameID].transform.position.z) - this.Yandere.transform.position);
			this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
			this.Yandere.MoveTowardsTarget(new Vector3(-25.155f, this.Chairs[this.GameID].transform.position.y, this.Chairs[this.GameID].transform.position.z));
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)5)
			{
				this.Yandere.PowerUp.gameObject.active = true;
				this.Yandere.MyController.radius = 0.2f;
				this.Yandere.CanMove = true;
				this.Gaming = false;
				this.ActivateBenefit();
				this.EnableChairs();
			}
		}
		else if (this.Timer < (float)5)
		{
			this.ID = 1;
			while (this.ID < Extensions.get_length(this.ComputerGames))
			{
				if (this.ComputerGames[this.ID].Circle[0].fillAmount == (float)0)
				{
					this.ComputerGames[this.ID].Circle[0].fillAmount = (float)1;
					this.GameID = this.ID;
					if (this.ID == 1)
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "Confirm";
						this.PromptBar.Label[1].text = "Back";
						this.PromptBar.Label[4].text = "Select";
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
						this.Yandere.Character.animation.Play(this.Yandere.IdleAnim);
						this.Yandere.CanMove = false;
						this.GameWindow.gameObject.active = true;
						this.ShowWindow = true;
					}
					else
					{
						this.PlayGames();
					}
				}
				this.ID++;
			}
		}
		if (this.Yandere.PowerUp.gameObject.active)
		{
			this.Timer += Time.deltaTime;
			float y = this.Yandere.PowerUp.transform.localPosition.y + Time.deltaTime;
			Vector3 localPosition = this.Yandere.PowerUp.transform.localPosition;
			float num = localPosition.y = y;
			Vector3 vector = this.Yandere.PowerUp.transform.localPosition = localPosition;
			this.Yandere.PowerUp.transform.LookAt(this.MainCamera.position);
			float y2 = this.Yandere.PowerUp.transform.localEulerAngles.y + (float)180;
			Vector3 localEulerAngles = this.Yandere.PowerUp.transform.localEulerAngles;
			float num2 = localEulerAngles.y = y2;
			Vector3 vector2 = this.Yandere.PowerUp.transform.localEulerAngles = localEulerAngles;
			if (this.Yandere.PowerUp.color != new Color((float)1, (float)1, (float)1, (float)1))
			{
				this.Yandere.PowerUp.color = this.OriginalColor;
			}
			else
			{
				this.Yandere.PowerUp.color = new Color((float)1, (float)1, (float)1, (float)1);
			}
			if (this.Timer > (float)6)
			{
				this.Yandere.PowerUp.gameObject.active = false;
				this.gameObject.active = false;
			}
		}
	}

	// Token: 0x06000293 RID: 659 RVA: 0x0002F75C File Offset: 0x0002D95C
	public virtual void EnableGames()
	{
		for (int i = 1; i < Extensions.get_length(this.ComputerGames); i++)
		{
			this.ComputerGames[i].enabled = true;
		}
		this.gameObject.active = true;
	}

	// Token: 0x06000294 RID: 660 RVA: 0x0002F7A0 File Offset: 0x0002D9A0
	public virtual void PlayGames()
	{
		this.Yandere.Character.animation.CrossFade("f02_playingGames_01");
		this.Yandere.MyController.radius = 0.1f;
		this.Yandere.CanMove = false;
		this.Gaming = true;
		this.DisableChairs();
		this.DisableGames();
	}

	// Token: 0x06000295 RID: 661 RVA: 0x0002F7FC File Offset: 0x0002D9FC
	public virtual void DisableGames()
	{
		for (int i = 1; i < Extensions.get_length(this.ComputerGames); i++)
		{
			this.ComputerGames[i].enabled = false;
			this.ComputerGames[i].Hide();
		}
		if (!this.Gaming)
		{
			this.gameObject.active = false;
		}
	}

	// Token: 0x06000296 RID: 662 RVA: 0x0002F858 File Offset: 0x0002DA58
	public virtual void EnableChairs()
	{
		for (int i = 1; i < Extensions.get_length(this.Chairs); i++)
		{
			this.Chairs[i].enabled = true;
		}
		this.gameObject.active = true;
	}

	// Token: 0x06000297 RID: 663 RVA: 0x0002F89C File Offset: 0x0002DA9C
	public virtual void DisableChairs()
	{
		for (int i = 1; i < Extensions.get_length(this.Chairs); i++)
		{
			this.Chairs[i].enabled = false;
		}
	}

	// Token: 0x06000298 RID: 664 RVA: 0x0002F8D4 File Offset: 0x0002DAD4
	public virtual void ActivateBenefit()
	{
		if (this.GameID == 1)
		{
			if (this.Subject == 1)
			{
				PlayerPrefs.SetInt("BiologyBonus", 1);
			}
			else if (this.Subject == 2)
			{
				PlayerPrefs.SetInt("ChemistryBonus", 1);
			}
			else if (this.Subject == 3)
			{
				PlayerPrefs.SetInt("LanguageBonus", 1);
			}
			else if (this.Subject == 4)
			{
				PlayerPrefs.SetInt("PsychologyBonus", 1);
			}
		}
		else if (this.GameID == 2)
		{
			PlayerPrefs.SetInt("PhysicalBonus", 1);
		}
		else if (this.GameID == 3)
		{
			PlayerPrefs.SetInt("SeductionBonus", 1);
		}
		else if (this.GameID == 4)
		{
			PlayerPrefs.SetInt("NumbnessBonus", 1);
		}
		else if (this.GameID == 5)
		{
			PlayerPrefs.SetInt("SocialBonus", 1);
		}
		else if (this.GameID == 6)
		{
			PlayerPrefs.SetInt("StealthBonus", 1);
		}
		else if (this.GameID == 7)
		{
			PlayerPrefs.SetInt("SpeedBonus", 1);
		}
		else if (this.GameID == 8)
		{
			PlayerPrefs.SetInt("EnlightenmentBonus", 1);
		}
		if (this.Poison != null)
		{
			this.Poison.Start();
		}
		this.StudentManager.UpdatePerception();
		this.Yandere.UpdateNumbness();
	}

	// Token: 0x06000299 RID: 665 RVA: 0x0002FA50 File Offset: 0x0002DC50
	public virtual void DeactivateBenefit()
	{
		if (this.GameID == 1)
		{
			if (this.Subject == 1)
			{
				PlayerPrefs.SetInt("BiologyBonus", 0);
			}
			else if (this.Subject == 2)
			{
				PlayerPrefs.SetInt("ChemistryBonus", 0);
			}
			else if (this.Subject == 3)
			{
				PlayerPrefs.SetInt("LanguageBonus", 0);
			}
			else if (this.Subject == 4)
			{
				PlayerPrefs.SetInt("PsychologyBonus", 0);
			}
		}
		else if (this.GameID == 2)
		{
			PlayerPrefs.SetInt("PhysicalBonus", 0);
		}
		else if (this.GameID == 3)
		{
			PlayerPrefs.SetInt("SeductionBonus", 0);
		}
		else if (this.GameID == 4)
		{
			PlayerPrefs.SetInt("NumbnessBonus", 0);
		}
		else if (this.GameID == 5)
		{
			PlayerPrefs.SetInt("SocialBonus", 0);
		}
		else if (this.GameID == 6)
		{
			PlayerPrefs.SetInt("StealthBonus", 0);
		}
		else if (this.GameID == 7)
		{
			PlayerPrefs.SetInt("SpeedBonus", 0);
		}
		else if (this.GameID == 8)
		{
			PlayerPrefs.SetInt("EnlightenmentBonus", 0);
		}
		if (this.Poison != null)
		{
			this.Poison.Start();
		}
		this.StudentManager.UpdatePerception();
		this.Yandere.UpdateNumbness();
	}

	// Token: 0x0600029A RID: 666 RVA: 0x0002FBCC File Offset: 0x0002DDCC
	public virtual void DeactivateAllBenefits()
	{
		PlayerPrefs.SetInt("BiologyBonus", 0);
		PlayerPrefs.SetInt("ChemistryBonus", 0);
		PlayerPrefs.SetInt("LanguageBonus", 0);
		PlayerPrefs.SetInt("PsychologyBonus", 0);
		PlayerPrefs.SetInt("PhysicalBonus", 0);
		PlayerPrefs.SetInt("SeductionBonus", 0);
		PlayerPrefs.SetInt("NumbnessBonus", 0);
		PlayerPrefs.SetInt("SocialBonus", 0);
		PlayerPrefs.SetInt("StealthBonus", 0);
		PlayerPrefs.SetInt("SpeedBonus", 0);
		PlayerPrefs.SetInt("EnlightenmentBonus", 0);
		if (this.Poison != null)
		{
			this.Poison.Start();
		}
	}

	// Token: 0x0600029B RID: 667 RVA: 0x0002FC70 File Offset: 0x0002DE70
	public virtual void UpdateHighlight()
	{
		if (this.Subject < 1)
		{
			this.Subject = 4;
		}
		else if (this.Subject > 4)
		{
			this.Subject = 1;
		}
		int num = 200 - this.Subject * 100;
		Vector3 localPosition = this.Highlight.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.Highlight.localPosition = localPosition;
	}

	// Token: 0x0600029C RID: 668 RVA: 0x0002FCE8 File Offset: 0x0002DEE8
	public virtual void Main()
	{
	}

	// Token: 0x040005AC RID: 1452
	public PromptScript[] ComputerGames;

	// Token: 0x040005AD RID: 1453
	public Collider[] Chairs;

	// Token: 0x040005AE RID: 1454
	public StudentManagerScript StudentManager;

	// Token: 0x040005AF RID: 1455
	public InputManagerScript InputManager;

	// Token: 0x040005B0 RID: 1456
	public PromptBarScript PromptBar;

	// Token: 0x040005B1 RID: 1457
	public YandereScript Yandere;

	// Token: 0x040005B2 RID: 1458
	public PoisonScript Poison;

	// Token: 0x040005B3 RID: 1459
	public Quaternion targetRotation;

	// Token: 0x040005B4 RID: 1460
	public Transform GameWindow;

	// Token: 0x040005B5 RID: 1461
	public Transform MainCamera;

	// Token: 0x040005B6 RID: 1462
	public Transform Highlight;

	// Token: 0x040005B7 RID: 1463
	public bool ShowWindow;

	// Token: 0x040005B8 RID: 1464
	public bool Gaming;

	// Token: 0x040005B9 RID: 1465
	public float Timer;

	// Token: 0x040005BA RID: 1466
	public int Subject;

	// Token: 0x040005BB RID: 1467
	public int GameID;

	// Token: 0x040005BC RID: 1468
	public int ID;

	// Token: 0x040005BD RID: 1469
	public Color OriginalColor;
}
