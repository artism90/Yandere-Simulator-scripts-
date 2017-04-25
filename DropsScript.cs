using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000086 RID: 134
[Serializable]
public class DropsScript : MonoBehaviour
{
	// Token: 0x0600032D RID: 813 RVA: 0x00042B40 File Offset: 0x00040D40
	public DropsScript()
	{
		this.Selected = 1;
		this.ID = 1;
	}

	// Token: 0x0600032E RID: 814 RVA: 0x00042B58 File Offset: 0x00040D58
	public virtual void Start()
	{
		for (int i = 1; i < Extensions.get_length(this.DropNames); i++)
		{
			this.NameLabels[i].text = this.DropNames[i];
		}
	}

	// Token: 0x0600032F RID: 815 RVA: 0x00042B98 File Offset: 0x00040D98
	public virtual void Update()
	{
		if (this.InputManager.TappedUp)
		{
			this.Selected--;
			if (this.Selected < 1)
			{
				this.Selected = Extensions.get_length(this.DropNames) - 1;
			}
			this.UpdateDesc();
		}
		if (this.InputManager.TappedDown)
		{
			this.Selected++;
			if (this.Selected > Extensions.get_length(this.DropNames) - 1)
			{
				this.Selected = 1;
			}
			this.UpdateDesc();
		}
		if (Input.GetButtonDown("A"))
		{
			if (!this.Purchased[this.Selected])
			{
				if (this.PromptBar.Label[0].text != string.Empty)
				{
					if (PlayerPrefs.GetInt("PantyShots") >= this.DropCosts[this.Selected])
					{
						PlayerPrefs.SetInt("PantyShots", PlayerPrefs.GetInt("PantyShots") - this.DropCosts[this.Selected]);
						this.Purchased[this.Selected] = true;
						this.InfoChanWindow.Orders = this.InfoChanWindow.Orders + 1;
						this.InfoChanWindow.ItemsToDrop[this.InfoChanWindow.Orders] = this.Selected;
						this.InfoChanWindow.DropObject();
						this.UpdateList();
						this.UpdateDesc();
						this.audio.clip = this.InfoPurchase;
						this.audio.Play();
						if (this.Selected == 2)
						{
							PlayerPrefs.SetInt("Scheme_3_Stage", 2);
							this.Schemes.UpdateInstructions();
						}
					}
				}
				else if (PlayerPrefs.GetInt("PantyShots") < this.DropCosts[this.Selected])
				{
					this.audio.clip = this.InfoAfford;
					this.audio.Play();
				}
				else
				{
					this.audio.clip = this.InfoUnavailable;
					this.audio.Play();
				}
			}
			else
			{
				this.audio.clip = this.InfoUnavailable;
				this.audio.Play();
			}
		}
		if (Input.GetButtonDown("B") && Input.GetButtonDown("B"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[5].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.FavorMenu.active = true;
			this.active = false;
		}
	}

	// Token: 0x06000330 RID: 816 RVA: 0x00042E64 File Offset: 0x00041064
	public virtual void UpdateList()
	{
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.DropNames))
		{
			if (!this.Purchased[this.ID])
			{
				this.CostLabels[this.ID].text = string.Empty + this.DropCosts[this.ID];
				int num = 1;
				Color color = this.NameLabels[this.ID].color;
				float num2 = color.a = (float)num;
				Color color2 = this.NameLabels[this.ID].color = color;
			}
			else
			{
				this.CostLabels[this.ID].text = string.Empty;
				float a = 0.5f;
				Color color3 = this.NameLabels[this.ID].color;
				float num3 = color3.a = a;
				Color color4 = this.NameLabels[this.ID].color = color3;
			}
			this.ID++;
		}
	}

	// Token: 0x06000331 RID: 817 RVA: 0x00042F8C File Offset: 0x0004118C
	public virtual void UpdateDesc()
	{
		if (!this.Purchased[this.Selected])
		{
			if (PlayerPrefs.GetInt("PantyShots") >= this.DropCosts[this.Selected])
			{
				this.PromptBar.Label[0].text = "Purchase";
				this.PromptBar.UpdateButtons();
			}
			else
			{
				this.PromptBar.Label[0].text = string.Empty;
				this.PromptBar.UpdateButtons();
			}
		}
		else
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		int num = 200 - 25 * this.Selected;
		Vector3 localPosition = this.Highlight.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.Highlight.localPosition = localPosition;
		this.DropIcon.mainTexture = this.DropIcons[this.Selected];
		this.DropDesc.text = this.DropDescs[this.Selected];
		this.UpdatePantyCount();
	}

	// Token: 0x06000332 RID: 818 RVA: 0x000430B4 File Offset: 0x000412B4
	public virtual void UpdatePantyCount()
	{
		this.PantyCount.text = string.Empty + PlayerPrefs.GetInt("PantyShots");
	}

	// Token: 0x06000333 RID: 819 RVA: 0x000430E8 File Offset: 0x000412E8
	public virtual void Main()
	{
	}

	// Token: 0x040007FB RID: 2043
	public InfoChanWindowScript InfoChanWindow;

	// Token: 0x040007FC RID: 2044
	public InputManagerScript InputManager;

	// Token: 0x040007FD RID: 2045
	public PromptBarScript PromptBar;

	// Token: 0x040007FE RID: 2046
	public SchemesScript Schemes;

	// Token: 0x040007FF RID: 2047
	public GameObject FavorMenu;

	// Token: 0x04000800 RID: 2048
	public Transform Highlight;

	// Token: 0x04000801 RID: 2049
	public UILabel PantyCount;

	// Token: 0x04000802 RID: 2050
	public UITexture DropIcon;

	// Token: 0x04000803 RID: 2051
	public UILabel DropDesc;

	// Token: 0x04000804 RID: 2052
	public UILabel[] CostLabels;

	// Token: 0x04000805 RID: 2053
	public UILabel[] NameLabels;

	// Token: 0x04000806 RID: 2054
	public bool[] Purchased;

	// Token: 0x04000807 RID: 2055
	public Texture[] DropIcons;

	// Token: 0x04000808 RID: 2056
	public int[] DropCosts;

	// Token: 0x04000809 RID: 2057
	public string[] DropDescs;

	// Token: 0x0400080A RID: 2058
	public string[] DropNames;

	// Token: 0x0400080B RID: 2059
	public int Selected;

	// Token: 0x0400080C RID: 2060
	public int ID;

	// Token: 0x0400080D RID: 2061
	public AudioClip InfoUnavailable;

	// Token: 0x0400080E RID: 2062
	public AudioClip InfoPurchase;

	// Token: 0x0400080F RID: 2063
	public AudioClip InfoAfford;
}
